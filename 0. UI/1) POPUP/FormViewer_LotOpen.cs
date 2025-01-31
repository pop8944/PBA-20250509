using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Collections.Generic;

namespace IntelligentFactory
{
    public partial class FormViewer_LotOpen : MetroForm
    {
        private IGlobal Global = IGlobal.Instance;

        private const int DGV_NO = 0;
        private const int DGV_ID = 1;
        private const int DGV_STATUS = 2;

        public EventHandler<EventArgs> EventUpdateStatus;
        public FormViewer_LotOpen()
        {
            InitializeComponent();
        }

        private void FormViewer_LotOpen_Load(object sender, EventArgs e)
        {
            InitUI();

            timerView.Enabled = true;

            Global.System.EventUpdateStyle += OnChangeStyle;

            this.KeyPreview = true;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyValue == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void FormViewer_LotOpen_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        public void OnChangeStyle(object sender, EventArgs e)
        {
        }        

        public bool InitUI()
        {
            try
            {
                tbLotTrayRows.Text = Global.iData.PropertyTrayLoading.ROWS.ToString();
                tbLotTrayCols.Text = Global.iData.PropertyTrayLoading.COLUMNS.ToString();

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

            return true;
        }


        private void timerView_Tick(object sender, EventArgs e)
        {
            try
            {
                if(Global.iDevice.DIO_BD.DI_WORK_LOADING_RAIL_LOADED_TRAY_DETECT.IsOn)
                {
                    lbStatusLoaderEmpty.BackColor = DEFINE.COLOR_TEAL;
                    lbStatusLoaderEmpty.Text = "EXIST";
                }
                else
                {
                    lbStatusLoaderEmpty.BackColor = DEFINE.COLOR_RED;
                    lbStatusLoaderEmpty.Text = "EMPTY";
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSaveZigElevatorBufferCount_Click(object sender, EventArgs e)
        {
            try
            {   
                Global.iData.PropertyBufferPitch.SaveConfig(Global.System.Recipe.Name);
                Global.iData.PropertyBufferPitch.LoadConfig(Global.System.Recipe.Name);
                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }            
        }

        private void btnLotLastLoad_Click(object sender, EventArgs e)
        {
            try
            {
                tbLotWorker.Text = Global.iData.PropertyLot.WORKER;
                tbLotNo.Text = Global.iData.PropertyLot.LOT_NO;
                tbLotMetalTrayID.Text = Global.iData.PropertyLot.METAL_TRAY_ID;
                tbLotTopCoverID.Text = Global.iData.PropertyLot.TOP_COVER_ID;

                tbLotDeviceCount.Text = Global.iData.PropertyLot.DEVICE_COUNT.ToString();
                tbLotTrayRows.Text = Global.iData.PropertyLot.ROWS.ToString();
                tbLotTrayCols.Text = Global.iData.PropertyLot.COLUMNS.ToString();

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnLotClear_Click(object sender, EventArgs e)
        {
            try
            {
                tbLotWorker.Text = "";
                tbLotNo.Text = "";
                tbLotMetalTrayID.Text = "";
                tbLotTopCoverID.Text = "";

                tbLotDeviceCount.Text = "";
                tbLotTrayRows.Text = "";
                tbLotTrayCols.Text = "";

                lbLotOpenTime.Text = "";

                IGlobal.Instance.iData.SEQ_DATA.IS_LOT_END = true;
                IGlobal.Instance.iData.SEQ_DATA.IS_COMPLETE_LOT_OPEN = false;

                pnLotOpen.Enabled = true;

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnLotOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Global.iDevice.DIO_BD.DI_WORK_LOADING_RAIL_LOADED_TRAY_DETECT.IsOn)
                {
                    CUtil.ShowMessageBox("ALARM", "BUFFER IS EMPTY");
                    return;
                }

                string strLotNo = tbLotNo.Text;
                if(Global.iData.PropertyLot.LOT_NO != strLotNo)
                {
                    if(Global.iData.SEQ_DATA.WorkDoneQueue.Count > 0)
                    {
                        CUtil.ShowMessageBox("ALARM", "PLEASE REJECT THE WORK DONE BUFFER");
                        return;
                    }
                }

                if (CUtil.ShowMessageBox("LOT_OPEN", "DO YOU WANT TO LOT OPEN?", FormMessageBox.MESSAGEBOX_TYPE.btnLotOpen))
                {
                    Global.iData.SEQ_DATA.IS_WORK_OUT_UNLOADING = false;
                    Global.iData.SEQ_DATA.IS_WORK_OUT_LOADING = false;

                    Global.iData.SEQ_DATA.REQ_JEDEC_TO_RAIL = false;
                    Global.iData.SEQ_DATA.REQ_JEDEC_TO_BUFFER = false;

                    Global.iData.SEQ_DATA.REQ_RECOVERY = false;

                    Global.iData.SEQ_DATA.REQ_START_LOADING_VISION = false;
                    Global.iData.SEQ_DATA.REQ_START_UNLOADING_VISION = false;

                    Global.iData.SEQ_DATA.REQ_UNLOADING_START = false;
                    Global.iData.SEQ_DATA.INSPECTED_DEVICE_COUNT = 0;

                    Global.SeqWorkPicker.SetStep(CSeqWorkPicker.STEP_SEQ.IDLE);

                    Global.iData.PropertyLot.OPEN_TIME = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                    Global.iData.PropertyLot.WORKER = tbLotWorker.Text;
                    Global.iData.PropertyLot.LOT_NO = (tbLotNo.Text).Replace(" ", "");

                    Global.iData.PropertyLot.METAL_TRAY_ID = (tbLotMetalTrayID.Text).Replace(" ", "");
                    Global.iData.PropertyLot.TOP_COVER_ID = (tbLotTopCoverID.Text).Replace(" ","");

                    Global.iData.PropertyLot.DEVICE_COUNT = int.Parse(tbLotDeviceCount.Text);
                    Global.iData.PropertyLot.ROWS = int.Parse(tbLotTrayRows.Text);
                    Global.iData.PropertyLot.COLUMNS = int.Parse(tbLotTrayCols.Text);

                    Global.iData.PropertyLot.PARTIAL_COUNT = Global.iData.PropertyLot.DEVICE_COUNT % (Global.iData.PropertyLot.ROWS * Global.iData.PropertyLot.COLUMNS);

                    lbLotOpenTime.Text = Global.iData.PropertyLot.OPEN_TIME;

                    int nTrayCount = Global.iData.PropertyLot.DEVICE_COUNT / (Global.iData.PropertyLot.ROWS * Global.iData.PropertyLot.COLUMNS);
                    nTrayCount = Global.iData.PropertyLot.DEVICE_COUNT % (Global.iData.PropertyLot.ROWS * Global.iData.PropertyLot.COLUMNS) > 0 ? nTrayCount + 1 : nTrayCount;
                    tbLotTrayCount.Text = nTrayCount.ToString();

                    IGlobal.Instance.iData.SEQ_DATA.BUFFER_LOT_OPEN_TRAY_COUNT = nTrayCount;
                    IGlobal.Instance.iData.SEQ_DATA.BUFFER_LOADING_TRAY_COUNT = nTrayCount;
                    IGlobal.Instance.iData.SEQ_DATA.BUFFER_UNLOADING_TRAY_COUNT = 0;

                    //IGlobal.Instance.iData.SEQ_DATA.BUFFER_LOADING_TRAY_COUNT = 5;
                    ////IGlobal.Instance.iData.SEQ_DATA.BUFFER_UNLOADING_TRAY_COUNT = 7;

                    //IGlobal.Instance.iData.SEQ_DATA.JIG_ELEVATOR_BUFFER[0] = CSeqData.TRAY_TYPE.JT;
                    //IGlobal.Instance.iData.SEQ_DATA.JIG_ELEVATOR_BUFFER[1] = CSeqData.TRAY_TYPE.JT;
                    //IGlobal.Instance.iData.SEQ_DATA.JIG_ELEVATOR_BUFFER[2] = CSeqData.TRAY_TYPE.JT;
                    //IGlobal.Instance.iData.SEQ_DATA.JIG_ELEVATOR_BUFFER[3] = CSeqData.TRAY_TYPE.JT;
                    //IGlobal.Instance.iData.SEQ_DATA.JIG_ELEVATOR_BUFFER[4] = CSeqData.TRAY_TYPE.JT;
                    //IGlobal.Instance.iData.SEQ_DATA.JIG_ELEVATOR_BUFFER[5] = CSeqData.TRAY_TYPE.JT;
                    //IGlobal.Instance.iData.SEQ_DATA.JIG_ELEVATOR_BUFFER[6] = CSeqData.TRAY_TYPE.JT;

                    CLogger.Add(LOG.LOT, "");
                    CLogger.Add(LOG.LOT, "==================== [LOT OPEN] ====================");
                    CLogger.Add(LOG.LOT, $"WORKER : {Global.iData.PropertyLot.WORKER}");
                    CLogger.Add(LOG.LOT, $"LOT_NO : {Global.iData.PropertyLot.LOT_NO}");
                    CLogger.Add(LOG.LOT, $"METAL_TRAY_ID : {Global.iData.PropertyLot.METAL_TRAY_ID}");
                    CLogger.Add(LOG.LOT, $"TOP_COVER_ID : {Global.iData.PropertyLot.METAL_TRAY_ID}");

                    CLogger.Add(LOG.LOT, $"DEVICE_COUNT : {Global.iData.PropertyLot.DEVICE_COUNT}");
                    CLogger.Add(LOG.LOT, $"TRAY_COUNT : {nTrayCount}");
                    CLogger.Add(LOG.LOT, $"ROWS : {Global.iData.PropertyLot.ROWS}");
                    CLogger.Add(LOG.LOT, $"COLUMNS : {Global.iData.PropertyLot.COLUMNS}");
                    CLogger.Add(LOG.LOT, $"DATETIME : {Global.iData.PropertyLot.OPEN_TIME}");
                    CLogger.Add(LOG.LOT, "==================== [--------] ====================");
                    CLogger.Add(LOG.LOT, "");

                    IGlobal.Instance.iData.SEQ_DATA.IS_COMPLETE_LOT_OPEN = true;

                    pnLotOpen.Enabled = false;
                }
                CUtil.ShowMessageBox("COMPLETE", "LOT OPEND");
                this.Close();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void keyPress_Device_Count(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
