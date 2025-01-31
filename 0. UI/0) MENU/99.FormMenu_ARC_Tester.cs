using System;
using System.Drawing;
using System.Windows.Forms;
using static IntelligentFactory.ARC_Control;

namespace IntelligentFactory
{
    public partial class FormMenu_ARC_Tester : Form
    {
        public FormMenu_ARC_Tester()
        {
            InitializeComponent();
        }

        private void FormMenu_ARC_Tester_Load(object sender, EventArgs e)
        {
            lb_ARC_Log.Items.Clear();
            txt_ARC_NOWMODEL_NAME.Text = Global.Instance.System.Recipe.CODE;

            if (IsRun)
            {
                btn_ARC_PREPARE.Enabled = true;
                btn_ARC_MACHINESTART.Enabled = true;
                btn_ARC_Mchange_End.Enabled = true;
                btn_ARC_NowModel.Enabled = true;
                lb_ARC_Log.Items.Add("ARC Connect!!");
            }
            else
            {
                btn_ARC_PREPARE.Enabled = false;
                btn_ARC_MACHINESTART.Enabled = false;
                btn_ARC_Mchange_End.Enabled = false;
                btn_ARC_NowModel.Enabled = false;
                lb_ARC_Log.Items.Add("ARC Not Connect!!");
            }
        }

        private void tmr_ARC_Log_Tick(object sender, EventArgs e)
        {
            // 해당 TCP가 생성되어있을때만 동작..
            if (IsRun)
            {
                lbl_ARC.BackColor = Color.Green;

                if (m_ARC_Client.m_listLog.Count > 0)
                {
                    for (int i = 0; i < m_ARC_Client.m_listLog.Count; i++)
                    {
                        string str = m_ARC_Client.m_listLog.Dequeue();
                        lb_ARC_Log.Items.Add(str);
                    }
                }
            }
            else
            {
                lbl_ARC.BackColor = Color.Red;
            }
        }

        private void btn_ARC_PREPARE_Click(object sender, EventArgs e)
        {
            if (rb_ARC_PREPARE_OK.Checked)
            {
                // 레시피를 변경가능한 상태이면 OK를
                CMD_PREPARE(Global.EQP_NAME, true);
            }
            else
            {
                // 레시피를 변경 불가능 한 상태이면은 NG를
                CMD_PREPARE(Global.EQP_NAME, false);
            }
        }

        private void btn_ARC_MACHINESTART_Click(object sender, EventArgs e)
        {
            CMD_MCHANGESTART(Global.EQP_NAME);
        }

        private void btn_ARC_Mchange_End_Click(object sender, EventArgs e)
        {
            if (rb_ARC_MACHINEEND_OK.Checked)
            {
                // 현재 레시피 쓰는게 완료되면..
                CMD_MCHANGEEND(Global.EQP_NAME, Param_Vlue.OK);
            }
            else if (rb_ARC_MACHINEEND_NG.Checked)
            {
                // 현재 레시피 쓰는게 NG날 경우
                CMD_MCHANGEEND(Global.EQP_NAME, Param_Vlue.NG);
            }
            else
            {
                // 현재 레시피 쓰는 중이면
                CMD_MCHANGEEND(Global.EQP_NAME, Param_Vlue.WAIT);
            }
        }

        private void btn_ARC_NowModel_Click(object sender, EventArgs e)
        {
            // 새로운 모델 이름을 써서 값 써주기..
            // 매개변수에 모델 이름 써주기..
            string Model_Name = txt_ARC_NOWMODEL_NAME.Text;
            CMD_NOWMODEL(Global.EQP_NAME, Model_Name);
        }
    }
}
