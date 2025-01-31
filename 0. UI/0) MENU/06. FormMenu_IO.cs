using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormMenu_IO : Form
    {
        private Global Global = Global.Instance;

        public FormMenu_IO()
        {
            InitializeComponent();
        }

        private void FormMenu_IO_Load(object sender, EventArgs e)
        {
            IF_Util.DoubleBuffered(gridInput, true);
            IF_Util.DoubleBuffered(gridOutput, true);

            try
            {
                IO_LOAD();
                timerStatus.Enabled = true;

                if (gridInput.Rows.Count > 16)
                {
                    pnl_Inputs.Size = new Size(625, 781);
                    this.Size = new Size(1280, 900);
                }

                if (gridOutput.Rows.Count > 16)
                {
                    pnl_Outputs.Size = new Size(625, 781);
                    this.Size = new Size(1280, 900);
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void IO_LOAD()
        {
            int in_maxcnt = Global.Device.DIO_BD.IO_DATA.DI_MAXCNT;
            gridInput.Rows.Clear();
            for (int i = 0; i < in_maxcnt; i++)
            {
                string addres = Global.Device.DIO_BD.IO_DATA.list_DI_Data[i].IO_ADRESS;
                string name = Global.Device.DIO_BD.IO_DATA.list_DI_Data[i].IO_NAME;
                gridInput.Rows.Add(new string[] { addres, name, "" });
            }

            int out_maxcnt = Global.Device.DIO_BD.IO_DATA.DO_MAXCNT;
            gridOutput.Rows.Clear();
            for (int i = 0; i < out_maxcnt; i++)
            {
                string addres = Global.Device.DIO_BD.IO_DATA.list_DO_Data[i].IO_ADRESS;
                string name = Global.Device.DIO_BD.IO_DATA.list_DO_Data[i].IO_NAME;
                gridOutput.Rows.Add(new string[] { addres, name, "" });
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private const int COL_VALUE = 2;

        private void IO_DISP()
        {
            gridInput.Invalidate();
            gridOutput.Invalidate();

            int in_max = Global.Instance.Device.DIO_BD.IO_DATA.DI_MAXCNT;
            int out_max = Global.Instance.Device.DIO_BD.IO_DATA.DO_MAXCNT;

            for (int i = 0; i < in_max; i++)
            {
                if (Global.Instance.Device.DIO_BD.IO_DATA.list_DI_Data[i].ONOFF)
                {
                    gridInput.Rows[i].Cells[COL_VALUE].Value = "ON";
                    gridInput.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    gridInput.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Green;
                }
                else
                {
                    gridInput.Rows[i].Cells[COL_VALUE].Value = "OFF";
                    gridInput.Rows[i].DefaultCellStyle.BackColor = DEFINE.COLOR_NAVY;
                    gridInput.Rows[i].DefaultCellStyle.SelectionBackColor = DEFINE.COLOR_NAVY;
                }
            }

            for (int i = 0; i < out_max; i++)
            {
                if (Global.Instance.Device.DIO_BD.IO_DATA.list_DO_Data[i].ONOFF)
                {
                    gridOutput.Rows[i].Cells[COL_VALUE].Value = "ON";
                    gridOutput.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    gridOutput.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Green;
                }
                else
                {
                    gridOutput.Rows[i].Cells[COL_VALUE].Value = "OFF";
                    gridOutput.Rows[i].DefaultCellStyle.BackColor = DEFINE.COLOR_NAVY;
                    gridOutput.Rows[i].DefaultCellStyle.SelectionBackColor = DEFINE.COLOR_NAVY;
                }
            }
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            if (Global.Instance.Device == null) return;
            if (Global.Instance.Device.DIO_BD == null) return;
            if (Global.Instance.Device.DIO_BD.IO_DATA == null) return;
            if (Global.Instance.Device.DIO_BD.IO_DATA.list_DI_Data == null) return;
            if (Global.Instance.Device.DIO_BD.IO_DATA.list_DO_Data == null) return;

            // io가 변경되었는지 확인...변경되면은 바로 변경 적용..
            if (Global.Instance.Device.DIO_BD.IO_DATA.IO_Edit)
            {
                IO_LOAD();
                Global.Instance.Device.DIO_BD.IO_DATA.IO_Edit = false;
            }

            IO_DISP();
        }

        private void gridOutput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int nIO = e.RowIndex;
            string name = Global.Instance.Device.DIO_BD.IO_DATA.list_DO_Data[nIO].IO_NAME;

            // 비트가 on일경우...off시켜줌..
            if (Global.Instance.Device.DIO_BD.IO_DATA.list_DO_Data[nIO].ONOFF)
            {
                Global.Instance.Device.DIO_BD.Bit_OnOff(name, false);
            }
            // 비트가 off일경우..on시켜줌..
            else
            {
                Global.Instance.Device.DIO_BD.Bit_OnOff(name, true);
            }
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.Image = Properties.Resources.Cancel50_MouseHover;
            btnClose.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = Properties.Resources.Cancel50_Normal;
            btnClose.ForeColor = Color.White;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Global.Instance.Frm_IO_Edit == null || !Global.Instance.Frm_IO_Edit.Created)
            {
                Global.Instance.Frm_IO_Edit = new FormMenu_IO_Edit();
            }

            Global.Instance.Frm_IO_Edit.BringToFront();
            Global.Instance.Frm_IO_Edit.Owner = this;
            Global.Instance.Frm_IO_Edit.Show();
        }

        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            btnEdit.Image = Properties.Resources.Check50_MouseHover;
            btnEdit.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.Image = Properties.Resources.Check50_Normal;
            btnEdit.ForeColor = Color.White;
        }
    }
}