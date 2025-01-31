using System;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormPopup_Progress : Form
    {
        public class evtArgsInspect : EventArgs
        {
            public bool isInspect;
        }

        public FormPopup_Progress(string strHead, string strDesc = "")
        {
            InitializeComponent();

            lbName.Text = strHead;
            lbDesc.Text = strDesc;
        }

        private void FormPopUp_Progress_Load(object sender, EventArgs e)
        {


        }

        private System.Diagnostics.Stopwatch m_swTackTime = new System.Diagnostics.Stopwatch();

        public string desc = "";
        public void OnShow_Progress(string str = "Waiting..")
        {
            //if (Global.Instance.SelectedMenu == "VISION")
            //{
            //    Invoke_Util.Set_Invoke_FromHide(this);
            //    return;
            //}

            Global.Instance.IsProgessing = true;

            desc = str;
            Invoke_Util.Set_Invoke_FromShow(this);
            //this.Show();
            m_swTackTime = new System.Diagnostics.Stopwatch();
            m_swTackTime.Start();
            timerTackTime.Enabled = true;
        }

        private void timerTackTime_Tick(object sender, EventArgs e)
        {
            lbDesc.Text = desc;
            Ontimer_Progress();
        }

        private void Ontimer_Progress()
        {
            int nM = (int)m_swTackTime.ElapsedMilliseconds / 60000;
            int nS = (int)m_swTackTime.ElapsedMilliseconds % 60000 / 1000;
            // ts = TimeSpan.FromMilliseconds(m_swTackTime.ElapsedMilliseconds);
            lbTackTime.Text = $"{nM:D2}:{nS:D2}";

            lbDesc.Text = Global.Notice;
        }


        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Global.Instance.System.Mode = CSystem.MODE.READY;

            if (Global.Instance.SeqVision != null) Global.Instance.SeqVision.SetStepEx("IDLE");
            Invoke_Util.Set_Invoke_FromHide(this);
            //this.Hide();
        }

        private void FormPopup_Progress_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnCancel_Click_1(null, null);
        }

        private void timerSelected_Tick(object sender, EventArgs e)
        {
            //if (Global.Instance.SelectedMenu == "VISION")
            //{
            //    Invoke_Util.Set_Invoke_FromHide(this);
            //}
        }
    }
}