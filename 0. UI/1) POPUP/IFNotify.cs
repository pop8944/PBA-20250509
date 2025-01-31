using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Sunny.UI
{
    public class UINotifier : Form
    {
        private class NoteLocation
        {
            internal int X;

            internal int Y;

            internal Point initialLocation;

            internal bool mouseIsDown;

            public NoteLocation(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        private static readonly List<UINotifier> Notes = new List<UINotifier>();

        private NoteLocation noteLocation;

        private short ID;

        private string Description;

        private string Title;

        private UINotifierType _uiNotifierType;

        private readonly bool IsDialog;

        private BackDialogStyle backDialogStyle;

        private Color HoverColor = Color.FromArgb(0, 0, 0, 0);

        private Color LeaveColor = Color.FromArgb(0, 0, 0, 0);

        private readonly int Timeout;

        private AutoResetEvent timerResetEvent;

        private readonly Form InApplication;

        private IContainer components;

        private Label noteContent;

        private Label noteDate;

        private ContextMenuStrip menu;

        private ToolStripMenuItem closeAllToolStripMenuItem;

        private Label noteTitle;

        private Label idLabel;

        [Browsable(false)]
        public bool IsScaled { get; private set; }

        public event EventHandler ItemClick;

        public void SetDPIScale()
        {
            if (IsScaled || !UIStyles.DPIScale)
            {
                return;
            }

            IsScaled = true;
        }

        private UINotifier(string dsc, UINotifierType type, string title, bool isDialog = false, int timeout_ms = 0, Form insideMe = null)
        {
            IsDialog = isDialog;
            Description = dsc;
            _uiNotifierType = type;
            Title = title;
            Timeout = timeout_ms;
            InApplication = insideMe;
            InitializeComponent();
            foreach (UINotifier note in Notes)
            {
                if (note.ID > ID)
                {
                    ID = note.ID;
                }
            }

            ID++;
            if (insideMe != null && !inAppNoteExists())
            {
                insideMe.LocationChanged += inApp_LocationChanged;
                insideMe.SizeChanged += inApp_LocationChanged;
            }

            foreach (Control control in base.Controls)
            {
                if (control is UISymbolLabel || control.Name == "icon")
                {
                    control.MouseDown += OnMouseDown;
                    control.MouseUp += OnMouseUp;
                    control.MouseMove += OnMouseMove;
                }
            }
        }

        private void inApp_LocationChanged(object sender, EventArgs e)
        {
            foreach (UINotifier note in Notes)
            {
                if (note.InApplication != null)
                {
                    NoteLocation noteLocation = adjustLocation(note);
                    note.Left = noteLocation.X;
                    note.Top = noteLocation.Y;
                }
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(40, 40, 40);
            base.TransparencyKey = Color.FromArgb(128, 128, 128);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Tag = "__Notifier|" + ID.ToString("X4");
            setNotifier(Description, _uiNotifierType, Title);
        }

        private void setNotifier(string description, UINotifierType noteType, string title, bool isUpdate = false)
        {
            Title = title;
            Description = description;
            _uiNotifierType = noteType;
            noteTitle.Text = title;
            noteContent.Text = description;
            noteContent.Font = new Font("Arial", 10);
            noteContent.ForeColor = Color.White;
            noteDate.Text = DateTime.Now.ToString() ?? "";
            noteDate.ForeColor = Color.White;

            switch (noteType)
            {
                case UINotifierType.ERROR:
                    LeaveColor = UIStyles.Red.ButtonFillColor;
                    HoverColor = UIStyles.Red.ButtonFillHoverColor;
                    break;
                case UINotifierType.INFO:
                    LeaveColor = Color.FromArgb(96, 125, 139);
                    HoverColor = Color.FromArgb(96, 125, 139);
                    break;
                case UINotifierType.WARNING:
                    LeaveColor = UIStyles.Orange.ButtonFillColor;
                    HoverColor = UIStyles.Orange.ButtonFillHoverColor;
                    break;
                case UINotifierType.OK:
                    LeaveColor = UIStyles.Green.ButtonFillColor;
                    HoverColor = UIStyles.Green.ButtonFillHoverColor;
                    break;
            }

            noteTitle.BackColor = Color.FromArgb(96, 125, 139);


            noteTitle.MouseHover += delegate
            {
                noteTitle.BackColor = HoverColor;
            };

            if (IsDialog)
            {
                Button button = new Button();
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = LeaveColor;
                button.ForeColor = Color.White;
                base.Size = new Size(base.Size.Width, base.Size.Height + 50);
                button.Size = new Size(120, 40);
                button.Location = new Point(base.Size.Width / 2 - button.Size.Width / 2, base.Size.Height - 50);
                button.Click += onOkButtonClick;
                base.Controls.Add(button);
                noteDate.Location = new Point(noteDate.Location.X, noteDate.Location.Y + 44);
                this.noteLocation = new NoteLocation(base.Left, base.Top);
            }

            if (!IsDialog && !isUpdate)
            {
                NoteLocation noteLocation = adjustLocation(this);
                base.Left = noteLocation.X;
                base.Top = noteLocation.Y;
            }
        }

        private NoteLocation adjustLocation(UINotifier note)
        {
            int num = 0;
            int num2 = 25;
            bool flag = false;
            Rectangle rectangle = ((InApplication == null || InApplication.WindowState != 0) ? new Rectangle(Screen.GetWorkingArea(note).Left, Screen.GetWorkingArea(note).Top, Screen.GetWorkingArea(note).Width, Screen.GetWorkingArea(note).Height) : InApplication.Bounds);
            int num3 = rectangle.Height / base.Height;
            int num4 = rectangle.Width / num2;
            noteLocation = new NoteLocation(rectangle.Width + rectangle.Left - base.Width, rectangle.Height + rectangle.Top - base.Height);
            while (num3 > 0 && !flag)
            {
                for (int i = 1; i <= num3; i++)
                {
                    noteLocation.Y = rectangle.Height + rectangle.Top - base.Height * i;
                    if (!isLocationAlreadyUsed(noteLocation, note))
                    {
                        flag = true;
                        break;
                    }

                    if (i == num3)
                    {
                        num++;
                        i = 0;
                        noteLocation.X = rectangle.Width + rectangle.Left - base.Width - num2 * num;
                    }

                    if (num >= num4)
                    {
                        flag = true;
                        break;
                    }
                }
            }

            noteLocation.initialLocation = new Point(noteLocation.X, noteLocation.Y);
            return noteLocation;
        }

        private void onCloseClick(object sender, EventArgs e)
        {
            if (e == null || ((MouseEventArgs)e).Button != MouseButtons.Right)
            {
                closeMe();
            }
        }

        private void onMenuClick(object sender, EventArgs e)
        {
        }

        private void onMenuCloseAllClick(object sender, EventArgs e)
        {
            CloseAll();
        }

        private void onOkButtonClick(object sender, EventArgs e)
        {
            onCloseClick(null, null);
        }

        private void closeMe()
        {
            Notes.Remove(this);
            Close();
            if (Notes.Count == 0)
            {
                ID = 0;
            }
        }

        private bool inAppNoteExists()
        {
            foreach (UINotifier note in Notes)
            {
                if (note.InApplication != null)
                {
                    return true;
                }
            }

            return false;
        }

        private bool isLocationAlreadyUsed(NoteLocation location, UINotifier note)
        {
            foreach (UINotifier note2 in Notes)
            {
                if (note2.Left == location.X && note2.Top == location.Y)
                {
                    if (note.InApplication != null && note2.ID == note.ID)
                    {
                        return false;
                    }

                    return true;
                }
            }

            return false;
        }

        public static void CloseAll()
        {
            for (int num = Notes.Count - 1; num >= 0; num--)
            {
                Notes[num].closeMe();
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            //Bitmap close = Resources.close;
            //if (close != null)
            //{
            //    Graphics graphics = e.Graphics;
            //    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //    graphics.DrawImage(close, buttonClose.Width - close.Width, buttonClose.Height - close.Height - 2, close.Width, close.Height);
            //}
        }

        public static short Show(string desc, UINotifierType type = UINotifierType.INFO, string title = "Notifier", bool isDialog = false, int timeout = 2000, Form inApp = null, EventHandler clickevent = null)
        {
            if (NotifierAlreadyPresent(desc, type, title, isDialog, out var updated_note_id, out var updated_note_occurence))
            {
                short iD = updated_note_id;
                short num = (updated_note_occurence = (short)(updated_note_occurence + 1));
                Update(iD, desc, type, "[" + num + "] " + title);
                return updated_note_id;
            }

            UINotifier uINotifier = new UINotifier(desc, type, title, isDialog, timeout, inApp);
            if (clickevent != null)
            {
                uINotifier.ItemClick = clickevent;
            }

            uINotifier.SetDPIScale();
            uINotifier.Show();
            if (uINotifier.Timeout >= 500)
            {
                uINotifier.timerResetEvent = new AutoResetEvent(initialState: false);
                BackgroundWorker backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += timer_DoWork;
                backgroundWorker.RunWorkerCompleted += timer_RunWorkerCompleted;
                backgroundWorker.RunWorkerAsync(uINotifier);
            }

            Notes.Add(uINotifier);
            return uINotifier.ID;
        }

        private static bool NotifierAlreadyPresent(string desc, UINotifierType type, string title, bool isDialog, out short updated_note_id, out short updated_note_occurence)
        {
            updated_note_id = 0;
            updated_note_occurence = 0;
            foreach (UINotifier note in Notes)
            {
                short result = 0;
                string text = note.Title;
                int num = text.IndexOf(']');
                if (num > 0)
                {
                    short.TryParse(text.Substring(0, num).Trim(' ', ']', '['), out result);
                    if (result > 1)
                    {
                        result = (short)(result - 1);
                    }

                    text = text.Substring(num + 1).Trim();
                }

                if (note.Tag != null && note.Description == desc && note.IsDialog == isDialog && text == title && note._uiNotifierType == type)
                {
                    short num2 = (updated_note_id = Convert.ToInt16(note.Tag.ToString().Split('|')[1], 16));
                    result = (updated_note_occurence = (short)(result + 1));
                    return true;
                }
            }

            return false;
        }

        public static void Update(short ID, string desc, UINotifierType noteType, string title)
        {
            foreach (UINotifier note in Notes)
            {
                if (note.Tag != null && note.Tag.Equals("__Notifier|" + ID.ToString("X4")))
                {
                    note.timerResetEvent?.Set();
                    note.setNotifier(desc, noteType, title, isUpdate: true);
                }
            }
        }

        private static void timer_DoWork(object sender, DoWorkEventArgs e)
        {
            UINotifier uINotifier = (UINotifier)e.Argument;
            bool flag = false;
            while (!flag)
            {
                if (!uINotifier.timerResetEvent.WaitOne(uINotifier.Timeout))
                {
                    flag = true;
                }
            }

            e.Result = e.Argument;
        }

        private static void timer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((UINotifier)e.Result).closeMe();
        }

        public static DialogResult ShowDialog(string content, UINotifierType type = UINotifierType.INFO, string title = "Notifier", BackDialogStyle backDialogStyle = BackDialogStyle.FadedScreen, Form application = null)
        {
            Form form = null;
            int num = 200;
            bool topMost = false;
            if (backDialogStyle == BackDialogStyle.FadedApplication && application == null)
            {
                backDialogStyle = BackDialogStyle.FadedScreen;
            }

            if (backDialogStyle != 0)
            {
                form = new Form();
                form.FormBorderStyle = FormBorderStyle.None;
                form.BackColor = Color.FromArgb(0, 0, 0);
                form.Opacity = 0.6;
                form.ShowInTaskbar = false;
            }

            UINotifier uINotifier = new UINotifier(content, type, title, isDialog: true);
            uINotifier.SetDPIScale();
            uINotifier.backDialogStyle = backDialogStyle;
            switch (uINotifier.backDialogStyle)
            {
                case BackDialogStyle.None:
                    if (application != null)
                    {
                        uINotifier.Owner = application;
                        uINotifier.StartPosition = FormStartPosition.CenterParent;
                    }
                    else
                    {
                        uINotifier.StartPosition = FormStartPosition.CenterScreen;
                    }

                    break;
                case BackDialogStyle.FadedScreen:
                    if (form != null && application != null)
                    {
                        form.Location = new Point(-num, -num);
                        form.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width + num, Screen.PrimaryScreen.WorkingArea.Height + num);
                        form.Show(application);
                        form.TopMost = true;
                        uINotifier.StartPosition = FormStartPosition.CenterScreen;
                    }

                    break;
                case BackDialogStyle.FadedApplication:
                    if (form != null && application != null)
                    {
                        topMost = application.TopMost;
                        application.TopMost = true;
                        form.StartPosition = FormStartPosition.Manual;
                        form.Size = application.Size;
                        form.Location = application.Location;
                        form.Show(application);
                        form.TopMost = true;
                        uINotifier.StartPosition = FormStartPosition.CenterParent;
                    }

                    break;
            }

            Notes.Add(uINotifier);
            uINotifier.ShowInTaskbar = false;
            uINotifier.ShowDialog();
            form?.Close();
            if (application != null)
            {
                application.TopMost = topMost;
            }

            return DialogResult.OK;
        }

        public static void ShowDialog(string content, string title = "Notifier", UINotifierType type = UINotifierType.INFO)
        {
            ShowDialog(content, type, title);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (noteLocation.mouseIsDown)
            {
                int num = noteLocation.initialLocation.X - e.Location.X;
                int num2 = noteLocation.initialLocation.Y - e.Location.Y;
                int x = base.Location.X - num;
                int y = base.Location.Y - num2;
                noteLocation.X = x;
                noteLocation.Y = y;
                base.Location = new Point(x, y);
            }
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            noteLocation.initialLocation = e.Location;
            noteLocation.mouseIsDown = true;
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            noteLocation.mouseIsDown = false;
        }

        private void UINotifier_Shown(object sender, EventArgs e)
        {
        }

        private void noteContent_Click(object sender, EventArgs e)
        {
            if (this.ItemClick != null)
            {
                this.ItemClick(this, e);
                closeMe();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                if (timerResetEvent != null)
                {
                    timerResetEvent.Close();
                }

                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.noteContent = new System.Windows.Forms.Label();
            this.noteDate = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noteTitle = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // noteContent
            // 
            this.noteContent.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.noteContent.Location = new System.Drawing.Point(20, 20);
            this.noteContent.Name = "noteContent";
            this.noteContent.Size = new System.Drawing.Size(270, 73);
            this.noteContent.TabIndex = 3;
            this.noteContent.Text = "Description";
            this.noteContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.noteContent.Click += new System.EventHandler(this.noteContent_Click);
            // 
            // noteDate
            // 
            this.noteDate.AutoSize = true;
            this.noteDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.noteDate.Location = new System.Drawing.Point(11, 97);
            this.noteDate.Name = "noteDate";
            this.noteDate.Size = new System.Drawing.Size(13, 9);
            this.noteDate.TabIndex = 4;
            this.noteDate.Text = "- -";
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeAllToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(119, 26);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.onMenuCloseAllClick);
            // 
            // noteTitle
            // 
            this.noteTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.noteTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.noteTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.noteTitle.ForeColor = System.Drawing.Color.White;
            this.noteTitle.Location = new System.Drawing.Point(0, 0);
            this.noteTitle.Name = "noteTitle";
            this.noteTitle.Size = new System.Drawing.Size(326, 24);
            this.noteTitle.TabIndex = 6;
            this.noteTitle.Text = "Note";
            this.noteTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.idLabel.Location = new System.Drawing.Point(296, 103);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(21, 9);
            this.idLabel.TabIndex = 7;
            this.idLabel.Text = "0000";
            this.idLabel.Visible = false;
            // 
            // UINotifier
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(326, 131);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.noteTitle);
            this.Controls.Add(this.noteDate);
            this.Controls.Add(this.noteContent);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UINotifier";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toast";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OnLoad);
            this.Shown += new System.EventHandler(this.UINotifier_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}