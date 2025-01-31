using MetroFramework.Forms;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormPopUp_Alarm : MetroForm
    {
        //public EventHandler<EventArgs> EventExit;
        //public EventHandler<StringEventArgs> EventSkip;
        //public EventHandler<StringEventArgs> EventSolved;
        //public EventHandler<StringEventArgs> EventResetSeq;
        //public EventHandler<StringEventArgs> EventRetry;

        public string m_strCode = "";

        public FormPopUp_Alarm(string strCode, string strDesc)
        {
            InitializeComponent();

            m_strCode = strCode;

            this.TopMost = true;
        }

        private void FormAlarm_Load(object sender, EventArgs e)
        {
            //IntPtr ip = CUtil.CreateRoundRectRgn(0, 0, circularProgressBar5.Width, circularProgressBar5.Height, 150, 150);
            //CUtil.SetWindowRgn(circularProgressBar5.Handle, ip, true);

            //IntPtr ip2 = CUtil.CreateRoundRectRgn(0, 0, this.Width, this.Height, 150, 150);
            //CUtil.SetWindowRgn(this.Handle, ip2, true);
        }

        public void Set(string strCode, string strDesc)
        {
            lbAlarmCode.Text = strCode;
            lbAlarmDesc.Text = strDesc;
            lbAlarmTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            m_swTackTime = new System.Diagnostics.Stopwatch();
            m_swTackTime.Start();

            m_strCode = strCode;

            if (strCode.Contains(DEFINE.ALARM_CODE_METAL_TRAY_LOADING_PUSHER)
                || strCode.Contains(DEFINE.ALARM_CODE_TOP_COVER_LOADING_PUSHER))
            {
                btnRetry.Visible = true;
            }
            else
            {
                btnRetry.Visible = false;
            }
        }

        private System.Diagnostics.Stopwatch m_swTackTime = new System.Diagnostics.Stopwatch();

        public void OnShowProgress(object sender = null, EventArgs e = null)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnShowProgress(sender, e);
                    }));
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                    //CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
            else
            {
                if (lbAlarmCode.Text != "[1] 000")
                {
                    //if (this.Disposed == false)
                    {
                        this.Show();

                        if (m_strCode.Contains(DEFINE.ALARM_CODE_METAL_TRAY_LOADING_PUSHER)
                       || m_strCode.Contains(DEFINE.ALARM_CODE_TOP_COVER_LOADING_PUSHER)
                       || m_strCode.Contains(DEFINE.ALARM_CODE_DEVICE_LOST)
                       )
                        {
                            btnRetry.Visible = true;
                        }
                        else
                        {
                            btnRetry.Visible = false;
                        }
                    }

                }
            }
        }

        public void OnEndProgress(object sender = null, EventArgs e = null)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnEndProgress(sender, e);
                    }));
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                    //Logger.WriteLog(LOG.ERROR, "[FAILED] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
            else
            {
                try
                {
                    this.Hide();
                }
                catch
                {
                }
            }
        }

        private void timerTackTime_Tick(object sender, EventArgs e)
        {
            int nMinutie = (int)m_swTackTime.ElapsedMilliseconds / 60000;
            int nSeconds = (int)(m_swTackTime.ElapsedMilliseconds % 60000) / 1000;
            lbTackTime.Text = $"{nMinutie}:{nSeconds}";
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            Close();
            //if (EventSkip != null) EventSkip(this, new StringEventArgs("SKIP"));
        }

        private void btnResetSeq_Click(object sender, EventArgs e)
        {
            //if (EventResetSeq != null) EventResetSeq(this, new StringEventArgs("RESET_SEQ"));
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            //if (EventRetry != null) EventRetry(this, new StringEventArgs(m_strCode));
        }

        private void btnBuzzerOff_Click(object sender, EventArgs e)
        {

        }
    }
}