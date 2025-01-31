using System;
using System.Drawing;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormPopUp_MessageBox : Form
    {
        public enum MESSAGEBOX_TYPE
        { OKCANCEL, OK, CANCEL, EXIT, btnLotOpen, NOMAL };

        // 처음 생성 되는 버튼의 위치값을 알기위함...
        // 메세지 타입에 따른 버튼 위치 조정을 위함..
        static int OKbutton_location_X;
        static int OKbutton_location_Y;
        static int CANCELbutton_location_X;
        static int CANCELbutton_location_Y;

        public FormPopUp_MessageBox(string strHead, string strMessage)
        {
            InitializeComponent();

            lbName.Text = strHead;
            lbMessage.Text = strMessage;
            this.KeyPreview = true;
        }

        //private int START_T = 0;
        //private bool Temp = false;

        public FormPopUp_MessageBox(string strHead, string strMessage, MESSAGEBOX_TYPE type, bool bTemp)
        {
            InitializeComponent();

            OKbutton_location_X = btnOK.Location.X;
            OKbutton_location_Y = btnOK.Location.Y;
            CANCELbutton_location_X = btnCancel.Location.X;
            CANCELbutton_location_Y = btnCancel.Location.Y;

            this.Text = strHead;
            lbMessage.Text = strMessage;

            //START_T = Environment.TickCount;
            //timer_Temp.Enabled = true;

            switch (type)
            {
                case MESSAGEBOX_TYPE.OKCANCEL:
                    break;

                case MESSAGEBOX_TYPE.EXIT:
                    {
                        btnOK.Visible = false;
                        Point ptButton = btnOK.Location;
                        btnOK.Location = new Point((this.Size.Width / 2) - (btnOK.Size.Width / 2), ptButton.Y);
                        btnOK.Text = "EXIT";
                    }
                    break;

                case MESSAGEBOX_TYPE.OK:
                    {
                        //2023-03-10 박민우
                        btnOK.Visible = true;
                        btnCancel.Visible = false;
                        Point ptButton = btnOK.Location;
                        btnOK.Location = new Point((this.Size.Width / 2) - (btnOK.Size.Width / 2), ptButton.Y);
                    }
                    break;

                case MESSAGEBOX_TYPE.CANCEL:
                    {
                        btnCancel.Visible = false;
                        Point ptButton = btnCancel.Location;
                        btnCancel.Location = new Point((this.Size.Width / 2) - (btnCancel.Size.Width / 2), ptButton.Y);
                    }
                    break;
            }

            btnOK.Focus();
        }

        public FormPopUp_MessageBox(string strHead, string strMessage, MESSAGEBOX_TYPE type)
        {
            InitializeComponent();

            OKbutton_location_X = btnOK.Location.X;
            OKbutton_location_Y = btnOK.Location.Y;
            CANCELbutton_location_X = btnCancel.Location.X;
            CANCELbutton_location_Y = btnCancel.Location.Y;

            this.Text = strHead;
            lbMessage.Text = strMessage;

            switch (type)
            {
                case MESSAGEBOX_TYPE.OKCANCEL:
                    break;

                case MESSAGEBOX_TYPE.EXIT:
                    {
                        btnOK.Visible = false;
                        Point ptButton = btnOK.Location;
                        btnOK.Location = new Point((this.Size.Width / 2) - (btnOK.Size.Width / 2), ptButton.Y);
                        btnOK.Text = "EXIT";
                    }
                    break;

                case MESSAGEBOX_TYPE.OK:
                    {
                        btnOK.Visible = false;
                        Point ptButton = btnOK.Location;
                        btnOK.Location = new Point((this.Size.Width / 2) - (btnOK.Size.Width / 2), ptButton.Y);
                    }
                    break;

                case MESSAGEBOX_TYPE.CANCEL:
                    {
                        btnCancel.Visible = false;
                        Point ptButton = btnCancel.Location;
                        btnCancel.Location = new Point((this.Size.Width / 2) - (btnCancel.Size.Width / 2), ptButton.Y);
                    }
                    break;

                // 추가..
                case MESSAGEBOX_TYPE.NOMAL:
                    {
                        btnCancel.Visible = false;
                        btnOK.Visible = true;
                        btnOK.Location = new Point(CANCELbutton_location_X, CANCELbutton_location_Y);
                        btnOK.Text = "OK";
                    }
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FormMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyValue == Keys.Escape)
            {
                // CLogger.WriteLog(LOG.NORMAL, "[OK] {0}==>{1}   Action ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);

                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        #region FORM MOVING BY LABEL

        private bool m_bIsDrag_Form = false;
        private System.Drawing.Point m_ptForm = new System.Drawing.Point();

        private void lbMenu_MouseDown(object sender, MouseEventArgs e)
        {
            m_bIsDrag_Form = true;
            this.m_ptForm = new System.Drawing.Point(e.X, e.Y);
        }

        private void lbMenu_MouseUp(object sender, MouseEventArgs e)
        {
            m_bIsDrag_Form = false;
        }

        private void lbMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (!m_bIsDrag_Form) return;

            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            Location = new System.Drawing.Point(this.Left - (m_ptForm.X - e.X), this.Top - (m_ptForm.Y - e.Y));
        }

        #endregion FORM MOVING BY LABEL
    }
}