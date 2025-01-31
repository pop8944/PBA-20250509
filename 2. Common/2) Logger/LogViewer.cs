using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class LogViewer : UserControl
    {
        private const int MAX_LOG_LINES = 500;
        private const int WM_VSCROLL = 0x115;
        private const int SB_BOTTOM = 7;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        public bool AutoScroll = true;
        Semaphore m_SemLockLog = new Semaphore(1, 1);

        private ConcurrentQueue<LogItem> qLog = new ConcurrentQueue<LogItem>();
        List<ListViewItem> listViewItems = new List<ListViewItem>();

        public LogViewer()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;
        }

        private void LogViewList_Load(object sender, EventArgs e)
        {
            CLogger.AddEvent(DisplayLog);
        }

        public void SetColumnImageWidth(int nWidth)
        {
        }

        private void DisplayLog(LogItem item)
        {
            try
            {
                qLog.Enqueue(item);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            int qCount = qLog.Count;

            try
            {
                if (qCount == 0)
                {
                    return;
                }
                else
                {
                    m_SemLockLog.WaitOne();

                    if (richTextBoxExLog.Lines.Length > MAX_LOG_LINES)
                    {
                        richTextBoxExLog.ReadOnly = false;
                        richTextBoxExLog.Select(0, richTextBoxExLog.GetFirstCharIndexFromLine(richTextBoxExLog.Lines.Length - MAX_LOG_LINES));
                        richTextBoxExLog.SelectedText = "";
                        richTextBoxExLog.ReadOnly = true;
                    }

                    while (qLog.TryDequeue(out LogItem log))
                    {
                        if (log.IsDisplay)
                        {
                            this.richTextBoxExLog.SelectionStart = this.richTextBoxExLog.TextLength;
                            this.richTextBoxExLog.SelectionLength = 0;
                            this.richTextBoxExLog.SelectionColor = log.DisplayColor;
                            this.richTextBoxExLog.AppendText(log.StrLog + "\r\n");
                            this.richTextBoxExLog.SelectionColor = this.richTextBoxExLog.ForeColor;
                            log.IsDisplay = false;
                        }
                    }

                    if (AutoScroll) SendMessage(richTextBoxExLog.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, IntPtr.Zero);
                    m_SemLockLog.Release();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Log Error : " + ex.Message);
            }
        }
    }
}
