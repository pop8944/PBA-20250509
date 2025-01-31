using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ImageProcessing;
using IntelligentFactory.Excel;
using Microsoft.Office.Interop.Excel;
using OpenCvSharp.Extensions;

using Sunny.UI;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vila.Extensions;

namespace IntelligentFactory
{
    public partial class FormMenu_Viewer : Form
    {
        private Global Global = Global.Instance;
        //private int timerCount = 0;
        //private int Search;
        //private string path;
        private int SelectGridRow;
        private int SelectGridColumn;

        public CSQLite sqlite;

        public List<string> selectRow_Data = new List<string>();
        public List<CogDisplay> cogDisplays = new List<CogDisplay>();

        public bool RMS_Mode;
        public string BUFFER_ID = "";
        public string QRCode = "";
        public int SelectRowIndex = 0;

        public int g_SelectGB;
        public int g_SelectGBM;

        public int g_SelectIndex;
        public int g_FirstIndex;
        public Setting_RMS RMS = null;
        private Dictionary<int, string> dicBUFFER_ID_Viewer = new Dictionary<int, string>();


        public bool IsCell_Click_First_NG_Buffer_Grid = false;

        private FormMenu_MainFrame frmmain;


        public enum SearchMode
        {
            DATE,
            QR_CODE,
        }

        public FormMenu_Viewer(string str_BufferID, string strQrcodes, int nRowIndex)
        {
            InitializeComponent();
            BUFFER_ID = str_BufferID;
            QRCode = strQrcodes;
            SelectRowIndex = nRowIndex;
            g_SelectGB = g_SelectGBM = 1;
        }

        public FormMenu_Viewer()
        {
            InitializeComponent();
            g_SelectGB = g_SelectGBM = 1;
        }

        public FormMenu_Viewer(FormMenu_MainFrame m_form)
        {
            InitializeComponent();
            frmmain = m_form;
        }

        public FormMenu_Viewer(bool RMSMODE)
        {
            InitializeComponent();
            RMS_Mode = RMSMODE;
        }

        public FormMenu_Viewer(string BUFFER_DATA)
        {
            InitializeComponent();

            if (BUFFER_DATA == "" || BUFFER_DATA == null) { BUFFER_DATA = null; }

            BUFFER_ID = BUFFER_DATA;
        }

        private void FormPBAviewer_Load(object sender, EventArgs e)
        {
            //.//[2024-10-10 01] NG_Reason, Chkbox_All 초기화 관련
            RMS = new Setting_RMS();
            RMS = RMS.Load();



            int index = -1;
            int i = 0;
            foreach (string item in cboReason.Items)
            {
                if (item == RMS.NGBuffer.NG_REASON)
                {
                    index = i;
                    break;
                }
                i++;
            }

            if (index != -1)
            {
                // 찾았을 경우 해당 인덱스를 사용
                //Console.WriteLine("Reverse_Insert의 인덱스: " + index);
                cboReason.SelectedIndex = index;
            }
            else
            {
                // 찾지 못했을 경우 처리
                //Console.WriteLine("일치하는 항목 없음");
                cboReason.SelectedIndex = 0;
            }

            chkQRAll.Checked = false;
            //.//

            SetDate();

            InitUI();

            ClearDisplay();

            Global.System.BufferClick = false;

            Buffer_DISP();

            RMS_BufferMonitorDisp();

            lbl_BoardOutData.Text = $"ID : {Global.Buffer_BoardOut_QRCODE} ";

            lbSelectArray1.Visible = false;
            lbSelectArray2.Visible = false;

            Global.Instance.Data.Buffer_ID = BUFFER_ID;

            MainToRms();

            // 결과 내용 디스플레이...
            lbl_TotalCnt.Text = "0";
            lbl_NGcnt.Text = "0";
            lbl_OKcnt.Text = "0";
            lbl_Yield.Text = "0";
            lbl_TotalCnt_Board.Text = "0";
            lbl_NGcnt_Board.Text = "0";
            lbl_OKcnt_Board.Text = "0";
            lbl_Yield_Board.Text = "0";
        }

        private void MainToRms()
        {
            if (BUFFER_ID == "") return;

            DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(1, SelectRowIndex + 1);
            gridBuffer_CellClick(gridBuffer, e);

            BUFFER_ID = "";
            QRCode = "";
        }

        private void SetDate()
        {
            datePickerEnd.Value = DateTime.Now;
            datePickerStart.Value = DateTime.Now.AddDays(-1);
            timePickerStart.Value = DateTime.Now.AddDays(-1);
            timePickerEnd.Value = DateTime.Now;

            datePicker_End.Value = DateTime.Now;
            datePicker_Start.Value = DateTime.Now.AddDays(-1);
            timePicker_Start.Value = DateTime.Now.AddDays(-1);
            timePicker_End.Value = DateTime.Now;
        }

        private void FormPBAviewr_Show(object sender, EventArgs e)
        {
            SetDate();

            InitUI();

            Global.System.BufferClick = false;

            Buffer_DISP();

            RMS_BufferMonitorDisp();

            lbl_BoardOutData.Text = $"ID : {Global.Buffer_BoardOut_QRCODE} ";

            lbSelectArray1.Visible = false;
            lbSelectArray2.Visible = false;
        }

        private void FormMenu_Viewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //.//[2024-10-10 01] NG_Reason, Chkbox_All 초기화 관련
            RMS.NGBuffer.NG_REASON = cboReason.Text;
            RMS.NGBuffer.Check_ALL = false;

            RMS.Save();
            //.//

            if (task_ExcelMaking != null)
            {
                if (TaskStatus.Running == task_ExcelMaking.Status)
                {
                    IF_Util.ShowMessageBox("CHECK", "Excel file extractioning..!! Please Waitting..! ");
                    this.Visible = true;
                    e.Cancel = true;
                }
            }
        }

        public void InitUI()
        {
            InitDisplay();
            InitGridSQL();
            InitReason();
            cbResult.SelectedIndex = 0;
            cboID.Items.Clear();
            cboID.Items.Add("All");
            cboID.SelectedIndex = 0;
            cboModel.Items.Clear();
            cboModel.Items.Add("All");
            cboModel.SelectedIndex = 0;
            cboJudgeType.SelectedIndex = 0;

            cbResult_Board.SelectedIndex = 0;
            cboID_Board.Items.Clear();
            cboID_Board.Items.Add("All");
            cboID_Board.SelectedIndex = 0;
            cboModel_Board.Items.Clear();
            cboModel_Board.Items.Add("All");
            cboModel_Board.SelectedIndex = 0;
            cboJudgeType_Board.SelectedIndex = 0;

            if (Util.CheckExcelExist())
            {
                chb_Excel_ImgInput.Visible = true;
                rab_ExcelOutput.Enabled = true;
                rab_ExcelOutput.Checked = true;
                chb_Excel_ImgInput_Board.Visible = true;
                rab_ExcelOutput_Board.Enabled = true;
                rab_ExcelOutput_Board.Checked = true;
            }
            else
            {
                chb_Excel_ImgInput.Visible = false;
                rab_ExcelOutput.Enabled = false;
                rab_TxtOutput.Checked = true;
                chb_Excel_ImgInput_Board.Visible = false;
                rab_ExcelOutput_Board.Enabled = false;
                rab_TxtOutput_Board.Checked = true;
            }

            IF_Util.DoubleBuffered(gridHistory, true);
            IF_Util.DoubleBuffered(gridHistory_Board, true);
        }

        public void InitDisplay()
        {
            cogDisplays.Add(cogDisplay_NG);
            cogDisplays.Add(cogDisplay_Crop_NG);

            tcJobType.SelectedTab = tP_NGBuffer;

            // 버퍼 버튼 use 상태에 따라 visible 상태 표시
            btn_CallStage_Retest.Enabled = Global.Instance.Mode.IsRMS_CallStage_ReTest;
            btnRMS_Retest.Enabled = Global.Instance.Mode.IsRMS_NGBUFFER_ReTest;
            btn_CallStage_BoardPass.Enabled = Global.Instance.Mode.IsRMS_BoardPass;
            btnRMS_OK.Enabled = Global.Instance.Mode.IsRMS_FinalOk;
            btnRMS_BoardOut.Enabled = Global.Instance.Mode.IsRMS_BoardOut;
        }

        public void InitGridSQL()
        {
            btnSetDay_Click(null, null);

            List<string[]> list = null;
            sqlite = Global.DB;

            //기본 오늘날짜
            string time = DateTime.Now.ToString("yyyy-MM-dd");

            list = sqlite.SelectAll_DATE("HISTORY", time);

            gridHistory.Rows.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                gridHistory.Rows.Insert(0, list[i]);
            }
        }

        public void InitReason(int nSelect = 0)
        {
            //cboReason.Items.Clear();
            //cboReason.Items.Add("Not_Insert");
            //cboReason.Items.Add("Reverse_Insert");
            //cboReason.Items.Add("Error_Insert");
            //cboReason.Items.Add("Differ_Insert");
            //cboReason.Items.Add("LiftUp");
            //cboReason.Items.Add("Pin_Not_Insert");
            //cboReason.Items.Add("Pin_LiftUp");

            //.//주석처리함 <- [2024-10-10 01] NG_Reason, Chkbox_All 초기화 관련
            //if (nSelect >= cboReason.Items.Count)
            //    nSelect = cboReason.Items.Count - 1;
            //else if (nSelect < 0)
            //    nSelect = 0;
            //cboReason.SelectedIndex = nSelect;
            //.//
            cboReasonHist.SelectedIndex = nSelect;
            cboJudge.SelectedIndex = 0;
            cboSelect.SelectedIndex = 0;
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            //Update 쿼리
            try
            {
                int nSelect_Index = SelectGridRow;
                List<string> RowData = new List<string>();

                if (gridHistory.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = gridHistory.Rows[nSelect_Index];

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        RowData.Add(row.Cells[i].Value.ToString());
                    }

                    selectRow_Data = RowData;

                    if (selectRow_Data[5] == "NG" && (selectRow_Data[6] == null || selectRow_Data[6] == ""))
                    {
                    }

                    InitGridSQL();
                }

                //if(Global.System.Mode == CSystem.MODE.AUTO && (Global.System.RMS_SELECT_MODE || Global.System.RMS_TIMER_MODE)) // 오토런 상태일때만 결과 신호 나가게
                if (Global.System.Mode == CSystem.MODE.AUTO && (Global.System.RMS_TIMER_MODE)) // 오토런 상태일때만 결과 신호 나가게
                {
                    Global.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, true);
                    Global.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);
                    Global.Data.CountNG_F--;
                    Global.Data.CountNG_T++;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void gridHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // 해당 부분 디스플레이 안함..
                lbSelectArray1.Visible = false;
                lbSelectArray2.Visible = false;

                //ClearDisplay();

                SelectGridRow = e.RowIndex;
                SelectGridColumn = e.ColumnIndex;
                int nSelect_Index = e.RowIndex;
                List<string> RowData = new List<string>();

                if (gridHistory.SelectedRows.Count > 0 && nSelect_Index >= 0)
                {
                    DataGridViewRow row = gridHistory.Rows[nSelect_Index];

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Value != null)
                        {
                            RowData.Add(row.Cells[i].Value.ToString());
                        }
                        else
                        {
                            RowData.Add("");
                        }
                    }

                    selectRow_Data = RowData;

                    try { cogDisplay_Crop_NG.Image = new CogImage24PlanarColor(new Bitmap(selectRow_Data[7])); } catch { }
                    try
                    {
                        string[] imagePath = selectRow_Data[6].Split('/');

                        string qrCode = gridHistory[2, nSelect_Index].Value.ToString();
                        int ngPartsCnt = Global.DB.Select_NGBuffer("HISTORY", qrCode).Count;

                        lblNgPartsCount.Text = ngPartsCnt.ToString();
                        if (imagePath.Length == 2)
                        {
                            if (radioViewAll.Checked)
                            {
                                cogDisplay_NG.Image = new CogImage24PlanarColor(new Bitmap(imagePath[0]));
                            }
                            else
                            {
                                cogDisplay_NG.Image = new CogImage24PlanarColor(new Bitmap(imagePath[1]));
                            }

                            string sOriImgPath = imagePath[1].Replace("_NG.jpg", "_ORI.jpg");
                            if (File.Exists(sOriImgPath))
                            {
                                cogDisplay_OriginImage.Image = new CogImage24PlanarColor(new Bitmap(sOriImgPath));
                            }
                        }

                    }
                    catch { }


                    string strQrCode = selectRow_Data[2];
                    g_SelDate = selectRow_Data[0];
                    g_Part = selectRow_Data[9];
                    lbQrCode.Text = strQrCode;
                    g_SelectIndex = nSelect_Index;
                    g_FirstIndex = gridHistory.FirstDisplayedCell.RowIndex;
                    g_Model = selectRow_Data[1];
                }
                else
                {
                    //CompareGrid cmpList = new CompareGrid();
                    //cmpList.set(true, 0);
                    //gridHistory.Sort(cmpList);
                    //sort(gridHistory.Rows
                    //foreach (DataGridViewColumn dgvc in gridHistory.Columns)
                    //{
                    //    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    //}
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public void ClearDisplay()
        {
            cogDisplay_NG.Image = null;
            cogDisplay_NG.StaticGraphics.Clear();
            cogDisplay_Crop_NG.Image = null;
            cogDisplay_Crop_NG.StaticGraphics.Clear();
        }

        public void SetDisplayImage(CogDisplay cogDisplay, string imagePath)
        {
            try
            {
                cogDisplay.StaticGraphics.Clear();

                CogImageFile cogImageFile = new CogImageFile();

                cogImageFile.Open(imagePath, CogImageFileModeConstants.Read);
                if (cogImageFile.Count > 0)
                {
                    ICogImage image = cogImageFile[0];
                    CogImageConvertTool cogImageConverter = new CogImageConvertTool();
                    cogImageConverter.InputImage = image;
                    cogImageConverter.Run();
                    CogImage24PlanarColor cogColorImage = new CogImage24PlanarColor((CogImage24PlanarColor)image);
                    cogDisplay.Image = cogColorImage;
                    cogDisplay.Fit(true);
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        //public void SetDisplayImage(CogDisplay cogDisplay, string imagePath, string camera)
        //{
        //    try
        //    {
        //        CogImageFile cogImageFile = new CogImageFile();
        //        Bitmap img = new Bitmap(imagePath);

        //        CogImage24PlanarColor cogColorImage = new CogImage24PlanarColor(img);
        //        CogGraphicCollection cogGraphic = new CogGraphicCollection();

        //        if (cogDisplay.Name == "cogDisplay_Full_Image" || cogDisplay.Name == "cogDisplay_MasterImage")
        //        {
        //            if (camera == "CAMERA1")
        //            {
        //                for (int i = 0; i < CVisionTools.Jobs.Count; i++)
        //                {
        //                    cogGraphic.Add((ICogGraphic)CVisionTools.Jobs[i].Matching.Tool.SearchRegion);
        //                }

        //                for (int j = 0; j < CVisionTools.Blobs.Count; j++)
        //                {
        //                    cogGraphic.Add((ICogGraphic)CVisionTools.Blobs[j].BLOB.Tool.Region);
        //                }
        //            }
        //            else
        //            {
        //                for (int i = 0; i < CVisionTools.Jobs.Count; i++)
        //                {
        //                    cogGraphic.Add((ICogGraphic)CVisionTools.Jobs2[i].Matching.Tool.SearchRegion);
        //                }

        //                for (int j = 0; j < CVisionTools.Blobs2.Count; j++)
        //                {
        //                    cogGraphic.Add((ICogGraphic)CVisionTools.Blobs2[j].BLOB.Tool.Region);
        //                }
        //            }

        //            cogDisplay.StaticGraphics.AddList(cogGraphic, "");
        //        }

        //        cogDisplay.Image = cogColorImage;
        //        cogDisplay.Fit(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
        //    }
        //}

        private class CompareGrid : System.Collections.IComparer
        {
            private bool isAscending = true;
            private int nIndex = 0;

            public void set(bool bAscending, int index)
            {
                isAscending = bAscending;
                nIndex = index;
            }

            public int Compare(object x, object y)
            {
                DataGridViewRow dataGridViewRow1 = (DataGridViewRow)x;
                DataGridViewRow dataGridViewRow2 = (DataGridViewRow)y;

                int CompareResult = Compare(dataGridViewRow1.Cells[nIndex].ToString(), dataGridViewRow2.Cells[nIndex].ToString());
                int nSortModifier = -1;
                if (isAscending)
                    nSortModifier = 1;

                // index관련 추가하자

                return CompareResult * nSortModifier;
            }
        }

        private class CompareSmallList : IComparer<string[]>
        {
            public int Compare(string[] x, string[] y)
            {
                if (y[0].CompareTo(x[0]) == 0)
                    return 0;

                return y[0].CompareTo(x[0]);
            }
        }

        //private bool _isRmsOK = false;
        private void RMS_BufferMonitorDisp()
        {
            if (Global.Mode.UseRms)
            {
                gridBufferMonitor.Rows.Clear();
                string strBufferQR;
                if (Global.Device.NGBUFFER != null)
                {
                    strBufferQR = Global.Device.NGBUFFER.GetQRTitle();

                    if (strBufferQR.Length > 0) lb_Buffer.Text = $"Buffer_Monitor , QR_Header = [{strBufferQR}]";
                    else lb_Buffer.Text = $"Buffer_Monitor";

                    string strStartTime = $"{datePickerStart.Value.ToString("yyyyMMdd:HHmmss")}";
                    string strEndTime = $"{datePickerEnd.Value.ToString("yyyyMMdd:HHmmss")}";

                    List<string> NgBufferIds = new List<string>();
                    List<string> FullIDS = new List<string>();
                    List<string> IDs = new List<string>();
                    //for (int i = 0; i < Global.Device.MewtocolComm.GetBufferCount(); i++)
                    {
                        int i = g_SelectGB - 1;
                        (string exist, string id, string result) result = Global.Device.NGBUFFER.GetSignal_Mewtoxcol(i);
                        string ids = result.id;// Global.Device.NGBUFFER.GetID(i);

                        FullIDS = IF_Util.GetFullIDS_IDS_QR(ids, Global.Device.NGBUFFER.GetQR());
                        for (int j = 0; j < FullIDS.Count; j++)
                            NgBufferIds.Add(FullIDS[j]);
                    }
                    List<string[]> list = null;

                    //.//rg test
                    //if (NgBufferIds.Count < 1)
                    //{
                    //    NgBufferIds.Add("06DA9405311G100DW4M0223");
                    //    NgBufferIds.Add("06DA9405311G100DW4M0251");
                    //NgBufferIds.Add("06DA9405311G100DW4M0203");
                    //NgBufferIds.Add("06DA9405311G100DW4M0204");
                    //}
                    //.//

                    if (NgBufferIds.Count > 0)
                    {
                        list = Global.DB.SelectAll_NGBuffer("HISTORY", NgBufferIds.ToList());
                        CompareSmallList cmpList = new CompareSmallList();
                        list.Sort(cmpList);
                        string preDate = "";
                        string currentDate = "";
                        string previousDate = "";
                        string preQR = "";
                        string currentQR = "";
                        string previousQR = "";
                        bool bAddData = false;
                        List<object> uniqueBuffer = new List<object>();
                        List<string> uniqueQR = new List<string>();
                        bool flag = false;
                        gridBufferMonitor.Rows.Clear();
                        // 제목 행 추가
                        string[] arr = { "DATE", "MODEL", "QR_CODE", "INSP_JUDGE", "RMS_JUDGE", "", "", "", "", "NG_PART", "NG_REASON", "NG_POS" };
                        gridBufferMonitor.Rows.Add(arr);

                        //for (int i = list.Count -1; i > 0; i--)
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i][3] == "NG")
                            {
                                if (!uniqueQR.Contains(list[i][2]))
                                {
                                    (string bufferID, DateTime dateTime, string NG_PartName) idDatePart;
                                    idDatePart.bufferID = list[i][2];
                                    idDatePart.dateTime = DateTime.ParseExact(list[i][0], "yyyyMMdd:HHmmss", null);
                                    idDatePart.NG_PartName = list[i][9];
                                    uniqueQR.Add(idDatePart.bufferID);
                                    uniqueBuffer.Add(idDatePart);
                                }
                                else
                                {
                                    DateTime nowDateTime = DateTime.ParseExact(list[i][0], "yyyyMMdd:HHmmss", null);
                                    foreach ((string bufferID, DateTime dateTime, string NG_PartName) idDatePart in uniqueBuffer)
                                    {
                                        if (idDatePart.bufferID == list[i][2] && nowDateTime != idDatePart.dateTime)
                                        {
                                            flag = true;
                                        }
                                    }
                                    if (flag)
                                    {
                                        flag = false;
                                        continue;
                                    }
                                }

                                gridBufferMonitor.Rows.Add(list[i]);

                            }
                        }


                        //if (gridBufferMonitor.SelectedRows.Count == 0) return;
                        //int nRowIndex = gridBufferMonitor.SelectedRows[0].Index;

                        //bool isTotalOk = true;
                        for (int i = 0; i < gridBufferMonitor.Rows.Count - 1; i++)
                        {
                            if (gridBufferMonitor[4, i].Value.ToString() == "IDLE")
                            {
                                gridBufferMonitor.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                                gridBufferMonitor.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Orange;

                                //isTotalOk = false;
                            }

                            if (gridBufferMonitor[4, i].Value.ToString() == "OK")
                            {
                                gridBufferMonitor.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                                gridBufferMonitor.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Green;
                            }

                            if (gridBufferMonitor[4, i].Value.ToString() == "NG")
                            {
                                gridBufferMonitor.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                                gridBufferMonitor.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Red;
                            }

                            if (i == g_SelectGBM - 1)
                                gridBufferMonitor.Rows[i + 1].DefaultCellStyle.ForeColor = Color.Yellow;
                            else
                                gridBufferMonitor.Rows[i + 1].DefaultCellStyle.ForeColor = Color.White;
                        }

                        ////2024.05.21 송현수 : RMS 판정 완료 시 Final OK 가능하도록
                        //if (isTotalOk) _isRmsOK = true;
                        //else _isRmsOK = false;

                        //if (isTotalOk)
                        //{
                        //    btnRMS_OK.Enabled = true;
                        //}
                        //else
                        //{
                        //    //btnRMS_OK.Enabled = false;
                        //}

                        if (IsCell_Click_First_NG_Buffer_Grid)
                        {
                            if (Global.Instance.Mode.IsRMS_FinalOk)
                            {
                                btnRMS_OK.Enabled = true;
                            }
                            else
                            {
                                btnRMS_OK.Enabled = false;
                            }
                        }

                        gridBufferMonitor.Rows[0].Selected = true;
                        gridBufferMonitor.FirstDisplayedScrollingRowIndex = 0;
                    }
                }
                else
                {
                    lb_Buffer.Text = $"Buffer_Monitor";
                }
            }
        }

        private void tmrRMS_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Global.Device.NGBUFFER != null && Global.Device.NGBUFFER.IsOpen)
                    RMS_BufferMonitorDisp();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void Buffer_DISP()
        {

            if (Global.Device.NGBUFFER != null && Global.Device.NGBUFFER.IsOpen)
            {
                gridBuffer.Rows.Clear();
                gridBuffer.Rows.Add("No", "Is", "ID", "Result", "Time");
                for (int i = 0; i < Global.Device.NGBUFFER.GetBufferCount(); i++)
                {
                    DateTime bufTime = Global.Device.NGBUFFER.GetTime(i);
                    string strTime = "";
                    if (bufTime != new DateTime())
                        strTime = bufTime.ToShortTimeString();

                    (string exist, string id, string result) result = Global.Device.NGBUFFER.GetSignal_Mewtoxcol(i);

                    gridBuffer.Rows.Add(new string[] { $"{(i+1).ToString()}", result.exist,
                            result.id, result.result, strTime });

                    // status 추가..
                }

                for (int i = 0; i < gridBuffer.Rows.Count; i++)
                {
                    if (gridBuffer[3, i].Value.ToString() == "OK" && gridBuffer[1, i].Value.ToString() == "V" && gridBuffer[2, i].Value.ToString() != "")
                    {
                        gridBuffer.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                        gridBuffer.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Green;
                    }
                    else if (gridBuffer[3, i].Value.ToString() == "NG" && gridBuffer[1, i].Value.ToString() == "V" && gridBuffer[2, i].Value.ToString() != "")
                    {
                        gridBuffer.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                        gridBuffer.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Orange;

                        if (Global.Instance.SetRMS.dicBUFFER_ID_Done.ContainsKey(i))
                        {
                            if (Global.Instance.SetRMS.dicBUFFER_ID_Done[i].Equals(gridBuffer[2, i].Value.ToString()))
                            {
                                gridBuffer.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                                gridBuffer.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        gridBuffer.Rows[i].DefaultCellStyle.BackColor = Color.DimGray;
                        gridBuffer.Rows[i].DefaultCellStyle.SelectionBackColor = Color.DimGray;
                    }

                    if (i == g_SelectGB)
                        gridBuffer.Rows[i].DefaultCellStyle.ForeColor = Color.Yellow;
                    else
                        gridBuffer.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }

                // 광주 사이트에서만 디스플레이..
                if (Global.Instance.Mode.NG_Buffer_Type && Global.Setting.Enviroment.Country != Setting_Enviroment.COUNTRY.POL)
                {
                    if (Global.Device.NGBUFFER.GetInStageExists()) lbStageExist.BackColor = Color.Green;
                    else lbStageExist.BackColor = Color.DimGray;
                }
                else
                {
                    lbStageExist.Enabled = false;
                }

                Global.Device.NGBUFFER.Buffer_InBoard_PrevCall.Clear();

                for (int i = 0; i < Global.Device.NGBUFFER.GetBufferCount(); i++)
                {
                    (string exist, string id, string result) result = Global.Device.NGBUFFER.GetSignal_Mewtoxcol(i);

                    if (result.id != "")
                    {
                        Global.Device.NGBUFFER.Buffer_InBoard_PrevCall.Add(result.id);
                    }
                }
            }
        }

        private void timerIO_Tick(object sender, EventArgs e)
        {
            if (!this.Visible) return;


            if (Global.m_BoardOut) btnRMS_BoardOut.BackColor = Color.Green;
            else btnRMS_BoardOut.BackColor = Color.Transparent;

            if (Global.Device.NGBUFFER == null) return;

            // CALL STAGE의 보드 QR이름 표시
            lbRMS_CalledID.Text = $"Call Stage ID : {Global.Device.NGBUFFER.GetInStageID()}";

            if (gridBuffer.Rows.Count > 0)
            {
                for (int i = 0; i < Global.Device.NGBUFFER.GetBufferCount(); i++)
                {
                    (string exist, string id, string result) result = Global.Device.NGBUFFER.GetSignal_Mewtoxcol(i);

                    // ID값이 변경되었을 경우..다시 재 디스플레이...
                    if (gridBuffer.Rows[i].Cells[2].Value.ToString() != result.id.ToString())
                    {
                        //.//rg test
                        Buffer_DISP();
                        return;
                    }
                    //if (result.exist == "" && m_nSelect_BoardOut == i)
                    //{
                    //    Global.Buffer_BoardOut_QRCODE = "";
                    //}

                }

            }
        }
        private int m_nSelect_BoardOut = -1;
        private int m_nSelectedRow = -1;

        private void btnRMS_Retest_Click(object sender, EventArgs e)
        {
            if (Global.Instance.Data.Buffer_ID != "")
            {
                Global.Instance.Device.NGBUFFER.Command_ReTest(System.Convert.ToInt32(Global.Instance.Data.Buffer_ID));

                Task.Run(() =>
                {
                    (sender as System.Windows.Forms.Button).BackColor = Color.Green;
                    Thread.Sleep(1000);
                    (sender as System.Windows.Forms.Button).BackColor = Color.FromArgb(44, 46, 66);
                });
            }
            else
            {
                IF_Util.ShowMessageBox("Error", "Select Index Please");
            }
        }

        private void btnRMS_OK_Click(object sender, EventArgs e)
        {
            if (Global.Instance.Data.Buffer_ID != "")
            {
                Global.Instance.Device.NGBUFFER.Command_FinalOK(System.Convert.ToInt32(Global.Instance.Data.Buffer_ID));



                Task.Run(() =>
                {
                    (sender as System.Windows.Forms.Button).BackColor = Color.Green;
                    Thread.Sleep(1000);
                    (sender as System.Windows.Forms.Button).BackColor = Color.FromArgb(44, 46, 66);
                });

                Global.Data.CountNG_F -= g_ErrorCnt;
                Global.Data.CountNG_T += g_ErrorCnt;
                btnRMS_OK.Enabled = false;
            }
            else
            {
                IF_Util.ShowMessageBox("Error", "Select Index Please");
            }

        }

        //private void btnRMS_StageCall_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Global.Device.NGBUFFER.Buffer_InBoard_PrevCall.Clear();

        //        for (int i = 0; i < Global.Device.NGBUFFER.GetBufferCount(); i++)
        //        {
        //            if (Global.Device.NGBUFFER.GetID(i) != "")
        //            {
        //                Global.Device.NGBUFFER.Buffer_InBoard_PrevCall.Add(Global.Device.NGBUFFER.GetID(i));
        //            }
        //        }

        //        Global.Device.NGBUFFER.Command_Stage_Call();
        //        Task.Run(() =>
        //        {
        //            (sender as System.Windows.Forms.Button).BackColor = Color.Green;
        //            Thread.Sleep(1000);
        //            (sender as System.Windows.Forms.Button).BackColor = Color.FromArgb(44, 46, 66);

        //            Thread.Sleep(8000);

        //            for (int i = 0; i < Global.Device.NGBUFFER.GetPrevCallCount(); i++)
        //            {
        //                bool bFound = false;
        //                for (int j = 0; j < Global.Device.NGBUFFER.GetBufferCount(); j++)
        //                {
        //                    if (Global.Device.NGBUFFER.GetID(j) == Global.Device.NGBUFFER.GetBufferInPrevCall(i))
        //                    {
        //                        bFound = true;
        //                        break;
        //                    }
        //                }

        //                if (bFound == false)
        //                {
        //                    CUtil.SetLabelText(lbRMS_CalledID, Global.Device.NGBUFFER.GetBufferInPrevCall(i));
        //                }
        //            }
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
        //    }
        //}

        private void btnRMS_StageBoardRetest_Click(object sender, EventArgs e)
        {
            try
            {
                int index = _selectedIndex;

                string result = "";

                Global.Device.NGBUFFER.CommandQueue.Enqueue(("D", "9701", typeof(short), index));
                Global.Device.NGBUFFER.CommandQueue.Enqueue(("R", "70B", typeof(bool), true));
                //result += Global.Device.NGBUFFER.Set(index, 9701).ToString();
                //result += Global.Device.NGBUFFER.On("70B").ToString();

                Task.Run(() =>
                {
                    (sender as System.Windows.Forms.Button).BackColor = Color.Green;
                    Thread.Sleep(1000);
                    (sender as System.Windows.Forms.Button).BackColor = Color.FromArgb(44, 46, 66);
                });
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        // Board OUT 된 이미지의 ID를 기억해서 해당 ID의 이미지 읽어오기...
        // 이미지 할당 해줌...
        private void StageImage_Serch()
        {
            // 해당 이미지 파일을 찾을 경로....
            // NG 파일 찾기...
            string str_path = $"{Global.m_ImageFileRoot}\\{DateTime.Now.Year}\\{DateTime.Now.Month.ToString("D2")}";
            string str_type_path = $"{str_path}\\{DateTime.Now.Day.ToString("D2")}_Auto\\NG";

            // 해당되는 ID의 파일 경로 확인하여 파일 할당 해주기...
            string[] str = Global.Buffer_BoardOut_QRCODE.Split('/');
            if (str != null)
            {
                // 해당 되는 뒷 숫자 4자리와 동일한 폴더가 있는지 확인...
                // Full 보드는 2개의 어레이 보드의 공통이므로...MasterImage 해당 변수로 공통 사용..
                string ret = Util.GetFilePath_Serch(str_type_path, str[0], "ORI_0");
                // 해당 파일 경로가 있을 경우에만 디스플레이..
                if (ret != "")
                {
                    Cognex.VisionPro.CogImage24PlanarColor img = new Cognex.VisionPro.CogImage24PlanarColor(new Bitmap(ret));
                    if (img != null && img.Allocated) Global.Instance.MasterImage[0] = OpenCvSharp.Extensions.BitmapConverter.ToMat(img.ToBitmap());
                }
                else
                {
                    Global.Instance.MasterImage[0] = null;
                }

                ret = Util.GetFilePath_Serch(str_type_path, str[1], "ORI_1");
                // 해당 파일 경로가 있을 경우에만 디스플레이..
                if (ret != "")
                {
                    Cognex.VisionPro.CogImage24PlanarColor img = new Cognex.VisionPro.CogImage24PlanarColor(new Bitmap(ret));
                    if (img != null && img.Allocated) Global.Instance.MasterImage[1] = OpenCvSharp.Extensions.BitmapConverter.ToMat(img.ToBitmap());
                }
                else
                {
                    Global.Instance.MasterImage[1] = null;
                }

                ret = Util.GetFilePath_Serch(str_type_path, str[0], "ORI_2");
                // 해당 파일 경로가 있을 경우에만 디스플레이..
                if (ret != "")
                {
                    Cognex.VisionPro.CogImage24PlanarColor img = new Cognex.VisionPro.CogImage24PlanarColor(new Bitmap(ret));
                    if (img != null && img.Allocated) Global.Instance.MasterImage[2] = OpenCvSharp.Extensions.BitmapConverter.ToMat(img.ToBitmap());
                }
                else
                {
                    Global.Instance.MasterImage[2] = null;
                }

                ret = Util.GetFilePath_Serch(str_type_path, str[0], "ORI_3");
                // 해당 파일 경로가 있을 경우에만 디스플레이..
                if (ret != "")
                {
                    Cognex.VisionPro.CogImage24PlanarColor img = new Cognex.VisionPro.CogImage24PlanarColor(new Bitmap(ret));
                    if (img != null && img.Allocated) Global.Instance.MasterImage[3] = OpenCvSharp.Extensions.BitmapConverter.ToMat(img.ToBitmap());
                }
                else
                {
                    Global.Instance.MasterImage[3] = null;
                }

                ret = Util.GetFilePath_Serch(str_type_path, str[0], "ORI_4");
                // 해당 파일 경로가 있을 경우에만 디스플레이..
                if (ret != "")
                {
                    Cognex.VisionPro.CogImage24PlanarColor img = new Cognex.VisionPro.CogImage24PlanarColor(new Bitmap(ret));
                    if (img != null && img.Allocated) Global.Instance.MasterImage[4] = OpenCvSharp.Extensions.BitmapConverter.ToMat(img.ToBitmap());
                }
                else
                {
                    Global.Instance.MasterImage[4] = null;
                }

                ret = Util.GetFilePath_Serch(str_type_path, str[0], "OVL");
                // 해당 파일 경로가 있을 경우에만 디스플레이..
                if (ret != "")
                {
                    Cognex.VisionPro.CogImage24PlanarColor img = new Cognex.VisionPro.CogImage24PlanarColor(new Bitmap(ret));
                    if (img != null && img.Allocated) Global.Instance.ResultImage[0] = OpenCvSharp.Extensions.BitmapConverter.ToMat(img.ToBitmap());
                }
                else
                {
                    Global.Instance.ResultImage[0] = null;
                }

                ret = Util.GetFilePath_Serch(str_type_path, str[1], "OVL");
                // 해당 파일 경로가 있을 경우에만 디스플레이..
                if (ret != "")
                {
                    Cognex.VisionPro.CogImage24PlanarColor img = new Cognex.VisionPro.CogImage24PlanarColor(new Bitmap(ret));
                    if (img != null && img.Allocated) Global.Instance.ResultImage[1] = OpenCvSharp.Extensions.BitmapConverter.ToMat(img.ToBitmap());
                }
                else
                {
                    Global.Instance.ResultImage[1] = null;
                }
            }
        }

        private void btnRMS_BoardOut_Click(object sender, EventArgs e)
        {

            if (Global.Device.NGBUFFER != null)
            {
                // 광주 사이트에 확인하는 부분인지 체크
                // 폴란드 사이트는 확인 안함..
                if (Global.Instance.Mode.NG_Buffer_Type && Global.Setting.Enviroment.Country != Setting_Enviroment.COUNTRY.POL)
                {
                    if (Global.Device.NGBUFFER.GetInStageExists())
                    {
                        IF_Util.ShowMessageBox("CALL STAGE CHECK", "CALL STAGE BOARD Exists!! CALL Stage Check Plase!!");
                        return;
                    }
                }

                Global.Device.NGBUFFER.Command_Board_Out(System.Convert.ToInt32(Global.Data.Buffer_ID));

                Task.Run(() =>
                {
                    (sender as System.Windows.Forms.Button).BackColor = Color.Green;
                    Thread.Sleep(1000);
                    (sender as System.Windows.Forms.Button).BackColor = Color.FromArgb(44, 46, 66);
                });
            }

            Global.Buffer_BoardOut_QRCODE = select_id;
            m_nSelect_BoardOut = m_nSelectedRow - 1;
            if (Global.Buffer_BoardOut_QRCODE != "")
            {
                CRegistry.Registry_Data_Write(Global.Registry_BoardOut_ID_Name, Global.Registry_BoardOut_ID_Key, Global.Buffer_BoardOut_QRCODE);
                lbl_BoardOutData.Text = $"ID : {select_id} ";
                m_nSelect_BoardOut = m_nSelectedRow - 1;
            }
            else
            {
                IF_Util.ShowMessageBox("Error", "Not NG Buffer QR CODE Recive!!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime searchStartTime = datePickerStart.Value.Date + timePickerStart.Value.TimeOfDay;
                DateTime searchEndTime = datePickerEnd.Value.Date + timePickerEnd.Value.TimeOfDay;
                string strStartTime = $"{searchStartTime.ToString("yyyyMMdd:HHmmss")}";
                string strEndTime = $"{searchEndTime.ToString("yyyyMMdd:HHmmss")}";
                //string strStartTime1 = $"{datePickerStart.Value.ToString("yyyyMMdd:HHmmss")}";
                //string strEndTime1 = $"{datePickerEnd.Value.ToString("yyyyMMdd:HHmmss")}";

                List<string[]> list = null;

                gridHistory.Rows.Clear();
                gridBufferMonitor.Rows.Clear();

                if (cbResult.Text == null)
                {
                    IF_Util.ShowMessageBox("Check", "RMS_JUDGE Select First !!!");
                    return;
                }
                else if (cbResult.Text.Contains("ALL"))
                    list = sqlite.SelectAll_DateAndJUDGE("HISTORY", cboID.Text, cboModel.Text, strStartTime, strEndTime);
                else
                    list = sqlite.Select_DateAndJUDGE(cboJudgeType.SelectedIndex, "HISTORY", cboID.Text, cboModel.Text, strStartTime, strEndTime, cbResult.Text);

                List<string> IDs = new List<string>();
                List<string> Models = new List<string>();
                IDs.Add("All");
                Models.Add("All");
                for (int i = 0; i < list.Count; i++)
                {
                    if (Global.Device.NGBUFFER != null)
                    {
                        for (int j = 0; j < Global.Device.NGBUFFER.GetBufferCount(); j++)
                        {
                            (string exist, string id, string result) result = Global.Device.NGBUFFER.GetSignal_Mewtoxcol(j);

                            string strID = result.id;
                            if (strID != "")
                            {
                                string[] strID_Split = strID.Split('/');
                                if (strID_Split.Length == 2)
                                {
                                    string strID1 = strID_Split[0];
                                    string strID2 = strID_Split[1];
                                    if (list[i][4].Contains(strID1) || list[i][4].Contains(strID2))
                                    {
                                        gridBufferMonitor.Rows.Add(list[i]);
                                    }
                                }
                            }
                        }
                    }

                    // ID 리스트 확보
                    bool bFind = false;
                    for (int h = 1; h < IDs.Count; h++)
                    {
                        if (IDs[h] == list[i][2])
                        {
                            bFind = true;
                            break;
                        }
                    }
                    if (!bFind)
                        IDs.Add(list[i][2]);
                    // Model 리스트 확보
                    bFind = false;
                    for (int h = 1; h < Models.Count; h++)
                    {
                        if (Models[h] == list[i][1])
                        {
                            bFind = true;
                            break;
                        }
                    }
                    if (!bFind)
                        Models.Add(list[i][1]);

                    gridHistory.Rows.Insert(0, list[i]);
                }
                // ID들을 넣음
                cboID.Items.Clear();
                for (int i = 0; i < IDs.Count; i++)
                    cboID.Items.Add(IDs[i]);
                // Model들을 넣음
                cboModel.Items.Clear();
                for (int i = 0; i < Models.Count; i++)
                    cboModel.Items.Add(Models[i]);
                cboModel.SelectedIndex = 0;
                GoPrevPos(false);


                List<string> okList = new List<string>();
                List<string> ngList = new List<string>();
                for (int i = 0; i < gridHistory.Rows.Count; i++)
                {
                    string result = gridHistory.Rows[i].Cells[3].Value.ToString();
                    string qrCode = gridHistory.Rows[i].Cells[2].Value.ToString();
                    string key = $"{qrCode}_{result}";

                    if (result == "OK" && okList.Contains(key) == false) okList.Add(key);
                    if (result == "NG" && ngList.Contains(key) == false) ngList.Add(key);
                }

                int totalCnt = okList.Count + ngList.Count;
                int okCnt = okList.Count;
                int ngCnt = ngList.Count;

                // 결과 내용 디스플레이...
                lbl_TotalCnt.Text = totalCnt.ToString();
                lbl_NGcnt.Text = ngCnt.ToString();
                lbl_OKcnt.Text = okCnt.ToString();
                double percent = ((double)okCnt / totalCnt * 100);
                lbl_Yield.Text = $"{percent.ToString("0.0")}%";
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public void GoPrevPos(bool isGridHistory)
        {
            if (!isGridHistory)
            {
                if (gridHistory.Rows.Count > 0)
                {
                    gridHistory.FirstDisplayedCell = gridHistory.Rows[g_FirstIndex].Cells[0];
                    if (g_SelectIndex < gridHistory.Rows.Count)
                        gridHistory.Rows[g_SelectIndex].Cells[0].Selected = true;
                }
            }
            else
            {
                if (gridBufferMonitor.Rows.Count > 0)
                {
                    gridBufferMonitor.FirstDisplayedCell = gridBufferMonitor.Rows[g_FirstIndex].Cells[0];
                    if (g_SelectIndex < gridBufferMonitor.Rows.Count)
                        gridBufferMonitor.Rows[g_SelectIndex].Cells[0].Selected = true;
                }
            }
        }

        private void btnSetDay_Click(object sender, EventArgs e)
        {
            try
            {
                datePickerEnd.Value = DateTime.Now;
                datePickerStart.Value = DateTime.Now.AddDays(-1);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnRmsJudgeOk_Click(object sender, EventArgs e)
        {
            try
            {
                string strQrCode = lbQrCode.Text;
                string strReason = cboReason.Text;
                bool bQRAll = chkQRAll.Checked;

                if (string.IsNullOrEmpty(strQrCode) == false)
                {
                    Global.DB.UpdateJudgeNReason("HISTORY", "OK", true, g_SelDate, g_Part, strReason, bQRAll, strQrCode, Global.System.Recipe.Name);

                    if (Global.Instance.Mode.IsRMS_FinalOk == false)
                    {
                        btnRMS_OK.Enabled = true;
                    }

                    IsCell_Click_First_NG_Buffer_Grid = false;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void gridBuffer_SelectionChanged(object sender, EventArgs e)
        {
            //btn_Refresh_Click(null, null);
        }

        private void gridBufferMonitor_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void cogDisplay_Master_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormPopUp_ImageView form = new FormPopUp_ImageView((sender as CogDisplay).Image.ToBitmap());
                form.Show();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        // 그리드 셀 속성 결정 핸들러
        //private void gridBufferMonitor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (gridBufferMonitor.SelectedRows.Count == 0) return;
        //    int nRowIndex = gridBufferMonitor.SelectedRows[0].Index;
        //    if (e.RowIndex == nRowIndex)
        //    {
        //        //e.CellStyle.BackColor = Color.LightGoldenrodYellow;
        //        //e.CellStyle.ForeColor = Color.Black;
        //        e.CellStyle.BackColor = Color.YellowGreen;
        //        e.CellStyle.ForeColor = Color.Red;    //글자색 처리
        //    }
        //}

        public string g_SelDate = "";
        public string g_Part = "";
        public string g_Model = "";

        private string[] _lastImagePath_NG;
        private void gridBufferMonitor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridBufferMonitor.SelectedRows.Count == 0) return;

                // 해당 클릭하면은 타이머 스톱...
                tmrRMS.Enabled = false;

                int nRowIndex = 1;
                if (e != null) nRowIndex = e.RowIndex;

                //ClearDisplay();

                int selectedRowIdx = g_SelectGBM = nRowIndex;
                List<string> RowData = new List<string>();

                if (gridBufferMonitor.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = gridBufferMonitor.Rows[selectedRowIdx];

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        RowData.Add(row.Cells[i].Value.ToString());
                    }

                    selectRow_Data = RowData;

                    try { cogDisplay_Crop_NG.Image = new CogImage24PlanarColor(new Bitmap(selectRow_Data[7])); } catch { }

                    try
                    {
                        string[] imagePath = _lastImagePath_NG = selectRow_Data[6].Split('/');

                        string qrCode = gridBufferMonitor[2, selectedRowIdx].Value.ToString();
                        int ngPartsCnt = Global.DB.Select_NGBuffer("HISTORY", qrCode).Count;

                        lblNgPartsCount.Text = ngPartsCnt.ToString();
                        if (imagePath.Length == 2)
                        {
                            if (radioViewAll.Checked)
                            {
                                cogDisplay_NG.Image = new CogImage24PlanarColor(new Bitmap(imagePath[0]));
                            }
                            else
                            {
                                cogDisplay_NG.Image = new CogImage24PlanarColor(new Bitmap(imagePath[1]));
                            }

                            string sOriImgPath = imagePath[1].Replace("_NG.jpg", "_ORI.jpg");
                            if (File.Exists(sOriImgPath))
                            {
                                cogDisplay_OriginImage.Image = new CogImage24PlanarColor(new Bitmap(sOriImgPath));
                                cogDisplay_OriginImage.Fit(false);
                            }
                        }

                        string path = $"{Global.m_MainPJTRoot}\\RECIPE\\{Global.System.Recipe.Name}\\MasterBoard_{Global.System.Recipe.Name}.jpg";

                        if (File.Exists(path))
                        {
                            cogDisplay_MasterImage.Image = new CogImage24PlanarColor(IF_Util.SafetyImageLoad(path));
                            cogDisplay_MasterImage.Fit(false);
                        }
                    }
                    catch { }

                    string strQrCode = selectRow_Data[2];
                    g_SelDate = selectRow_Data[0];
                    g_Part = selectRow_Data[9];
                    lbQrCode.Text = strQrCode;
                    g_SelectIndex = selectedRowIdx;
                    g_FirstIndex = gridBufferMonitor.FirstDisplayedCell.RowIndex;

                    // 해당 클릭하면은 타이머 시작...
                    tmrRMS.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void Zoom_NG_Master_Display()
        {
            if (selectRow_Data[11].Length <= 0)
                return;

            if (cogDisplay_NG.Image == null) return;
            // 여기서 Zoom 조절
            string[] poses = selectRow_Data[11].Split(',');
            int imgWidth = cogDisplay_NG.Image.Width;
            int imgHeight = cogDisplay_NG.Image.Height;
            double imgXRate = (double.Parse(poses[0]) + double.Parse(poses[2]) / 2);
            double imgYRate = (double.Parse(poses[1]) + double.Parse(poses[3]) / 2);

            double imgXStart = imgWidth / 2;
            double imgYStart = imgHeight / 2;

            double imgXPos = imgXStart - imgXRate;
            double imgYpos = imgYStart - imgYRate;

            cogDisplay_NG.Zoom = 1;
            cogDisplay_NG.PanX = imgXPos;
            cogDisplay_NG.PanY = imgYpos;

        }

        private int g_ErrorCnt = 0;
        private int _selectedIndex = 0;

        private int GetErrorCount(List<string> NgBufferIds)
        {
            int nError = 0;
            List<bool> NgBufferJudges = new List<bool>();
            for (int j = 0; j < NgBufferIds.Count; j++)
            {
                NgBufferJudges.Add(true);
            }

            List<string[]> list = Global.DB.SelectAll_NGBuffer("HISTORY", NgBufferIds.ToList());
            CompareSmallList cmpList = new CompareSmallList();
            list.Sort(cmpList);
            bool bJudge = true;
            for (int i = 0; i < NgBufferIds.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (NgBufferIds[i].CompareTo(list[j][2]) == 0)
                    {
                        if (list[j][3] == "OK")
                            bJudge = true;
                        else
                            bJudge = false;
                        NgBufferJudges[i] = bJudge;
                        //nError++;
                        break;
                    }
                }
            }

            for (int i = 0; i < NgBufferJudges.Count; i++)
                if (NgBufferJudges[i] == false)
                    nError++;

            //for (int i = 0; i < list.Count; i++)
            //{
            //    if (list[i][3].Contains("NG") && list[i][4].Contains("OK"))
            //    {
            //        for (int j = 0; j < NgBufferIds.Count; j++)
            //        {
            //            if (NgBufferIds[j].CompareTo(list[i][2]) == 0)
            //                NgBufferJudges[j] = false;
            //        }
            //    }
            //}

            //for (int i = 0; i < NgBufferJudges.Count; i++)
            //    if (NgBufferJudges[i] == false)
            //        nError++;
            return nError;
        }

        private void btnRmsJudgeNG_Click(object sender, EventArgs e)
        {
            try
            {
                string strQrCode = lbQrCode.Text;
                string strReason = cboReason.Text;
                bool bOk = chkQRAll.Checked;

                if (string.IsNullOrEmpty(strQrCode) == false)
                {
                    Global.DB.UpdateJudgeNReason("HISTORY", "NG", true, g_SelDate, g_Part, strReason, bOk, strQrCode, Global.System.Recipe.Name);

                    if (Global.Instance.Mode.IsRMS_FinalOk == false)
                    {
                        btnRMS_OK.Enabled = true;
                    }

                    IsCell_Click_First_NG_Buffer_Grid = false;

                    int nIdx = -1;
                    if (Global.Instance.Data.Buffer_ID.IsNullOrWhiteSpace() == false)
                    {
                        nIdx = int.Parse(Global.Instance.Data.Buffer_ID);
                    }

                    if (nIdx >= 0)
                    {
                        gridBuffer.Rows[nIdx].DefaultCellStyle.BackColor = Color.Red;
                        gridBuffer.Rows[nIdx].DefaultCellStyle.SelectionBackColor = Color.Red;

                        Global.Instance.SetRMS.dicBUFFER_ID_Done[nIdx] = gridBuffer[2, nIdx].Value.ToString();
                        //dicBUFFER_ID_Viewer[nIdx] = gridBuffer[2, nIdx].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnRmsJudgeIDLE_Click(object sender, EventArgs e)
        {
            try
            {
                string strQrCode = lbQrCode.Text;
                string strReason = cboReason.Text;
                bool bOk = chkQRAll.Checked;

                if (string.IsNullOrEmpty(strQrCode) == false)
                {
                    Global.DB.UpdateJudgeNReason("HISTORY", "IDLE", true, g_SelDate, g_Part, strReason, bOk, strQrCode, Global.System.Recipe.Name);

                    if (Global.Instance.Mode.IsRMS_FinalOk == false)
                    {
                        btnRMS_OK.Enabled = true;
                    }

                    IsCell_Click_First_NG_Buffer_Grid = false;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        public void ExcelMake1(string strPath)
        {
            // 프로그래스바 관련
            int nExcel = 2, nTitle = 1, nStatistics = 5;
            int nMaxprs = gridHistory.Rows.Count + nExcel + nTitle + nStatistics;
            int nProgress = 0;
            List<System.Drawing.Image> images = new List<System.Drawing.Image>();
            images.Add(Properties.Resources.MagicSheet0);
            FormPopUp_ProgressBar prsForm = new FormPopUp_ProgressBar("Excel Make", "Excel Making Now !!!", (double)nMaxprs, images, 80);

            try
            {
                //List<string> Refs = new List<string>();
                //Refs.Add("Judge");
                //Refs.Add("OK");
                //Refs.Add("IDLE");
                //Refs.Add("NG");

                //InteropExcel excel = new InteropExcel();
                //excel.AddSheet("StatisticsData");
                //excel.AddSheet("BackData");
                //excel.AddSheet("Reference");
                //excel.AddDataes(0, Refs, null, new System.Drawing.Rectangle(1, 1, 1, 4), false);

                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                var excelWB = excelApp.Workbooks.Add();
                excelWB.Worksheets.Add();
                excelWB.Worksheets.Add();

                // 여기에 Reference 데이터를 넣는다.
                var excelWSRef = (Microsoft.Office.Interop.Excel.Worksheet)excelWB.Worksheets[3];
                excelWSRef.Name = "Reference";

                List<string> Refs = new List<string>();
                Refs.Add("Judge");
                Refs.Add("OK");
                Refs.Add("IDLE");
                Refs.Add("NG");
                for (int i = 0; i < Refs.Count; i++)
                {
                    Microsoft.Office.Interop.Excel.Range inCell = excelWSRef.Cells[i + 1, 1];
                    inCell.Value = Refs[i];
                }

                var excelWS = (Microsoft.Office.Interop.Excel.Worksheet)excelWB.Worksheets[2];
                excelWS.Name = "BackData";
                var excelWS2 = (Microsoft.Office.Interop.Excel.Worksheet)excelWB.Worksheets[1];
                excelWS2.Name = "StatisticsData";

                nProgress += nExcel;
                prsForm.SetCurPos(this, nProgress);
                //1행에 제목 문자열들 입력
                List<string> Titles = new List<string>();
                Titles.Add("Time");
                Titles.Add("Model");
                Titles.Add("QR(ID)");
                Titles.Add("Part_Method");
                Titles.Add("Insp_Judge");
                Titles.Add("RMS_Judge");
                Titles.Add("Match_Judge");
                Titles.Add("Total");
                Titles.Add("Insp_OK");
                Titles.Add("RMS_OK");
                Titles.Add("Match");
                Titles.Add("Insp_Rate");
                Titles.Add("RMS_RATE");
                Titles.Add("Match_Rate");
                Titles.Add("Reason");
                Titles.Add("Origin_Image");
                Titles.Add("Overlay_Image");

                for (int i = 0; i < 30; i++)
                {
                    Titles.Add("Crop_Image");
                    Titles.Add("Ref_Image");
                }

                for (int i = 0; i < Titles.Count; i++)
                {
                    Microsoft.Office.Interop.Excel.Range inCell = excelWS.Cells[1, i + 1];
                    inCell.Value = Titles[i];
                }

                // 여기부터 통계를 넣는다.
                int nStaticsRow = 10;

                Titles.Clear();
                Titles.Add("Start");
                Titles.Add("End");
                Titles.Add("Total");
                Titles.Add("Insp_OK");
                Titles.Add("RMS_OK");
                Titles.Add("Match");
                //Titles.Add("PBA Code");
                Titles.Add("Recipe");
                Titles.Add("JobTitle");
                Titles.Add("Insp_Rate");
                Titles.Add("RMS_Rate");
                Titles.Add("Match_Rate");
                for (int i = 0; i < Titles.Count; i++)
                {
                    Microsoft.Office.Interop.Excel.Range inCell = excelWS2.Cells[nStaticsRow, i + 1];
                    inCell.Value = Titles[i];
                }

                nProgress += nTitle;
                prsForm.SetCurPos(this, nProgress);

                List<string> Items = new List<string>();
                List<string> RowData = new List<string>();

                List<string> statistics = new List<string>();
                List<string> statistEnd = new List<string>();
                //int nNG = 0, nTot = 0, nMatch = 0, nInsNG = 0;
                string prevQR = "";
                string prevModel = "";
                string prevTime = "";
                string startModel = "";
                int nAddRow = 0;
                int nNextRow = 0;
                int nTitleRow = 1;
                int nPrevItemCnt = 0;
                int nNGCnt = 0;
                bool bNormalProcess = true;

                for (int h = 0; h < gridHistory.Rows.Count; h++)
                {
                    Items.Clear();
                    DataGridViewRow row = gridHistory.Rows[h];
                    RowData.Clear();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        RowData.Add(row.Cells[i].Value.ToString());
                    }
                    if (prevQR == RowData[2])
                        bNormalProcess = false;
                    else
                    {
                        nNextRow++;
                        nNGCnt = 0;
                        bNormalProcess = true;
                    }
                    if (h == 121)
                    {
                        //int nn = 0;
                    }

                    if (bNormalProcess)
                    {
                        if (prevModel != RowData[1])
                        {
                            if (statistEnd.Count > 0)
                            {
                                for (int j = 0; j < statistEnd.Count; j++)
                                    statistics.Add(statistEnd[j]);

                                for (int j = 0; j < statistics.Count; j++)
                                {
                                    Microsoft.Office.Interop.Excel.Range inCell = excelWS2.Cells[nStaticsRow + nAddRow, j + 1];
                                    if (j <= 1)
                                    {
                                        inCell.NumberFormat = "yyyy-mm-dd hh:mm:ss";
                                        string strDate = ConvertDateTimeString(statistics[j]);
                                        DateTime dt = DateTime.Parse(strDate);     // String 형식의 날짜를 DateTime 형식으로 변환
                                        inCell.Value = dt;
                                    }
                                    else if (j >= 8 && j <= 10)
                                    {
                                        inCell.NumberFormat = "0.00%";
                                        inCell.Value = statistics[j];
                                    }
                                    else
                                        inCell.Value = statistics[j];
                                }
                            }

                            //nNG = nTot = nMatch = nInsNG = 0;
                            nAddRow++;
                            startModel = $"${nNextRow + nTitleRow + nAddRow}";
                            statistics.Clear();
                            statistics.Add(RowData[0]);     // StartTime
                        }

                        // Time
                        Items.Add(RowData[0]);
                        prevTime = RowData[0];
                        // Model
                        Items.Add(RowData[1]);
                        prevModel = RowData[1];
                        // QR
                        Items.Add(RowData[2]);
                        prevQR = RowData[2];

                        // Part/Method
                        Items.Add(RowData[9]);
                        // Insp/RMS Judge
                        Items.Add(RowData[3]);
                        Items.Add(RowData[4]);

                        // Match
                        Items.Add($"=IF(E{nNextRow + nTitleRow + nAddRow}=F{nNextRow + nTitleRow + nAddRow},\"OK\",\"NG\")");

                        // Count(Tot/Insp/RMS/Match
                        Items.Add($"=COUNTA(E{startModel}:E{nNextRow + nTitleRow + nAddRow})");
                        Items.Add($"= COUNTIF(E{startModel}:E{nNextRow + nTitleRow + nAddRow}, \"OK\"");
                        Items.Add($"= COUNTIF(F{startModel}:F{nNextRow + nTitleRow + nAddRow}, \"OK\"");
                        Items.Add($"= COUNTIF(G{startModel}:G{nNextRow + nTitleRow + nAddRow}, \"OK\"");

                        // Rate(Insp/RMS/Match
                        Items.Add($"=I{nNextRow + nTitleRow + nAddRow}/H{nNextRow + nTitleRow + nAddRow}");
                        Items.Add($"=J{nNextRow + nTitleRow + nAddRow}/H{nNextRow + nTitleRow + nAddRow}");
                        Items.Add($"=K{nNextRow + nTitleRow + nAddRow}/H{nNextRow + nTitleRow + nAddRow}");

                        for (int j = 0; j < Items.Count; j++)
                        {
                            Microsoft.Office.Interop.Excel.Range inCell = excelWS.Cells[nNextRow + nTitleRow + nAddRow, j + 1];
                            if (j == 0)
                            {
                                inCell.NumberFormat = "yyyy-mm-dd hh:mm:ss";
                                string strDate = ConvertDateTimeString(Items[j]);
                                DateTime dt = DateTime.Parse(strDate);     // String 형식의 날짜를 DateTime 형식으로 변환
                                inCell.Value = dt;
                            }
                            else if (j >= 4 && j <= 5)      // Insp/RMS Judge - 목록 추가
                            {
                                inCell.Value = Items[j];
                                inCell.Validation.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertInformation, XlFormatConditionOperator.xlBetween, "=Reference!$A$2:$A$4", null);
                            }
                            else if (j >= 11 && j <= 13)    // Rate
                            {
                                inCell.NumberFormat = "0.00%";
                                inCell.Value = Items[j];
                                //inCell.Formula(Items[j]);
                            }
                            else
                                inCell.Value = Items[j];
                        }

                        // Reason
                        Microsoft.Office.Interop.Excel.Range ReasonCell = excelWS.Cells[nNextRow + nTitleRow + nAddRow, Items.Count + 1];
                        ReasonCell.Value = RowData[10];

                        // Origin Image
                        if (RowData[5].Length > 0 && IF_Util.FileExist(RowData[5]))
                        {
                            Microsoft.Office.Interop.Excel.Range inHyper1 = excelWS.Cells[nNextRow + nTitleRow + nAddRow, Items.Count + 2];
                            string strName1 = $"Origin_Image{nNextRow}";
                            string strFileHyper1 = $"{strPath}\\{strName1}.jpg";
                            System.IO.File.Copy(RowData[5], strFileHyper1, true);
                            excelWS.Hyperlinks.Add(inHyper1, strFileHyper1, Type.Missing, strName1, strName1);
                        }

                        // Overlay Image
                        if (RowData[6].Length > 0 && IF_Util.FileExist(RowData[6]))
                        {
                            Microsoft.Office.Interop.Excel.Range inHyper2 = excelWS.Cells[nNextRow + nTitleRow + nAddRow, Items.Count + 3];
                            string strName2 = $"Overlay_Image{nNextRow}";
                            string strFileHyper2 = $"{strPath}\\{strName2}.jpg";
                            System.IO.File.Copy(RowData[6], strFileHyper2, true);
                            excelWS.Hyperlinks.Add(inHyper2, strFileHyper2, Type.Missing, strName2, strName2);
                        }

                        // 여기서 통계자료 갱신 준비
                        statistEnd.Clear();

                        statistEnd.Add(RowData[0]); // EndTime
                        statistEnd.Add($"=\'{excelWS.Name}\'!H{nNextRow + nTitleRow + nAddRow}");   // TotCnt
                        statistEnd.Add($"=\'{excelWS.Name}\'!I{nNextRow + nTitleRow + nAddRow}");   // InspCnt
                        statistEnd.Add($"=\'{excelWS.Name}\'!J{nNextRow + nTitleRow + nAddRow}");   // RMSCnt
                        statistEnd.Add($"=\'{excelWS.Name}\'!K{nNextRow + nTitleRow + nAddRow}");   // MatchCnt

                        //statistEnd.Add(RowData[1]); // PBA코드 없으니 우선 모델로
                        statistEnd.Add(RowData[1]); // Recipe

                        // JobTitle
                        string strShortDate = ConvertShortDateString(statistEnd[0]);
                        string strJobTitle = strShortDate + "_" + RowData[1];
                        statistEnd.Add(strJobTitle);

                        statistEnd.Add($"=\'{excelWS.Name}\'!L{nNextRow + nTitleRow + nAddRow}");   // InspRate
                        statistEnd.Add($"=\'{excelWS.Name}\'!M{nNextRow + nTitleRow + nAddRow}");   // RMSRate
                        statistEnd.Add($"=\'{excelWS.Name}\'!N{nNextRow + nTitleRow + nAddRow}");   // MatchRate

                        nPrevItemCnt = Items.Count + 4; // Image위치 설정
                    }

                    // NG Image
                    if (RowData[7].Length > 0 && IF_Util.FileExist(RowData[7]))
                    {
                        Microsoft.Office.Interop.Excel.Range inHyper1 = excelWS.Cells[nNextRow + nTitleRow + nAddRow, nPrevItemCnt + (nNGCnt) * 2];
                        string strName1 = $"NG_Image{nNextRow}_{nNGCnt}";
                        string strFileHyper1 = $"{strPath}\\{strName1}.jpg";
                        System.IO.File.Copy(RowData[7], strFileHyper1, true);
                        excelWS.Hyperlinks.Add(inHyper1, strFileHyper1, Type.Missing, strName1, strName1);
                    }

                    // NG-참조 Image
                    if (RowData[8].Length > 0 && IF_Util.FileExist(RowData[8]))
                    {
                        Microsoft.Office.Interop.Excel.Range inHyper2 = excelWS.Cells[nNextRow + nTitleRow + nAddRow, nPrevItemCnt + (nNGCnt) * 2 + 1];
                        string strName2 = $"Ref_Image{nNextRow}_{nNGCnt}";
                        string strFileHyper2 = $"{strPath}\\{strName2}.jpg";
                        System.IO.File.Copy(RowData[8], strFileHyper2, true);
                        excelWS.Hyperlinks.Add(inHyper2, strFileHyper2, Type.Missing, strName2, strName2);
                        nNGCnt++;
                    }

                    nProgress++;
                    prsForm.SetCurPos(this, nProgress);
                }

                if (statistEnd.Count > 0)
                {
                    for (int j = 0; j < statistEnd.Count; j++)
                        statistics.Add(statistEnd[j]);

                    for (int j = 0; j < statistics.Count; j++)
                    {
                        Microsoft.Office.Interop.Excel.Range inCell = excelWS2.Cells[nStaticsRow + nAddRow, j + 1];
                        if (j <= 1)
                        {
                            inCell.NumberFormat = "yyyy-mm-dd hh:mm:ss";
                            string strDate = ConvertDateTimeString(statistics[j]);
                            DateTime dt = DateTime.Parse(strDate);     // String 형식의 날짜를 DateTime 형식으로 변환
                            inCell.Value = dt;
                        }
                        else if (j >= 4 && j <= 7)
                        {
                            inCell.Value = statistics[j];
                        }
                        else if (j >= 8 && j <= 10)
                        {
                            inCell.NumberFormat = "0.00%";
                            inCell.Value = statistics[j];
                        }
                        else
                            inCell.Value = statistics[j];
                    }
                }

                //Add chart.
                var charts = excelWB.Charts.Add();
                // Set chart range.
                Microsoft.Office.Interop.Excel.Range topLeft = excelWS2.Cells[nStaticsRow, 8];
                Microsoft.Office.Interop.Excel.Range bottomRight = excelWS2.Cells[nStaticsRow + nAddRow, 11];
                var range = excelWS2.get_Range(topLeft, bottomRight);
                charts.SetSourceData(range);

                // Set chart properties.
                //charts.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLine;
                charts.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xl3DColumnClustered;
                charts.ChartWizard(Source: range,
                    Title: "Inspect Report",
                    CategoryTitle: "Judge Process : Insp/RMS/Match",
                    ValueTitle: "Rate");

                nProgress += nStatistics;
                prsForm.SetCurPos(this, nProgress);
                excelWB.SaveAs($"{strPath}\\RMS_Report.xlsx");
                excelWB.Close(false);
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                prsForm.SetCurPos(this, nMaxprs);
            }
            GC.Collect();
        }

        public enum RMS_Sheet
        {
            StatisticsData = 0,
            BackData,
            Reference
        }

        private void CSVFileCheck(string Path, string Name)
        {
            if (!File.Exists($"{Path}\\{Name}"))
            {
                Directory.CreateDirectory(Path);
                using (FileStream fs = File.Create($"{Path}\\{Name}"))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        string str_Tilt = "Time, Model, QR(ID), Part_Method, Insp_Judge, RMS_Judge, Match_Judge, Total, Insp_OK, RMS_OK, Match, Insp_Rate, RMS_RATE, Match_Rate, Reason, TotCnt, InspCnt, RMSCnt, MatchCnt";

                        sw.WriteLine(str_Tilt);
                        sw.Close();
                    }
                    fs.Close();
                }
            }
        }

        private void CSVFileMake(string strPath)
        {
            string filename = $"RMS_Report_Format.csv";
            // 프로그래스바 관련
            int nExcel = 2, nTitle = 1, nStatistics = 5;
            nMaxp = gridHistory.Rows.Count + nExcel + nTitle + nStatistics;

            // 파일이 있는지 체크하고...그 파일이 없을 경우 파일 생성...
            // 해당 폴더에 파일이 있을 경우 삭제후 재 생성하도록함..
            // 생성은 엑셀 파일 세이브할때 생성됨..
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strPath);
            if (di.GetFiles().Length > 0)
            {
                foreach (System.IO.FileInfo file in di.GetFiles())
                {
                    if (file.ToString() == filename)
                    {
                        file.Delete();
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(new FileStream($"{strPath}\\{filename}", FileMode.Append, FileAccess.Write)))
            {
                //sw.WriteLine("[StatisticsData]");
                //string Statistics_Tilt = "Start, End, Total, Insp_OK, RMS_OK, Match, Recipe, JogTitle, Insp_Rate, RMS_Rate, Match_Rate";
                //sw.WriteLine(Statistics_Tilt);
                sw.WriteLine("[BackData]");
                string BackData_Tilt = "Time, Model, QR(ID), Part_Code, Insp_Judge, RMS_Judge, Match_Judge, Reason";
                sw.WriteLine(BackData_Tilt);
                for (int h = 0; h < gridHistory.Rows.Count; h++)
                {
                    string str = $"{gridHistory.Rows[h].Cells[0].Value}, {gridHistory.Rows[h].Cells[1].Value}, {gridHistory.Rows[h].Cells[2].Value}, {gridHistory.Rows[h].Cells[9].Value}, {gridHistory.Rows[h].Cells[3].Value}, {gridHistory.Rows[h].Cells[4].Value}, {gridHistory.Rows[h].Cells[3].Value}, {gridHistory.Rows[h].Cells[10].Value}";
                    sw.WriteLine(str);
                    nProgcnt++;
                }
                sw.Close();
            }

            IF_Util.ShowMessageBox("COMPLTE", $"Text File Write Complte!!");
        }

        double nProgress = 0;
        int nMaxp = 0;
        int nProgcnt = 0;

        public void ExcelMake2(string strPath)
        {
            // 프로그래스바 관련
            int nExcel = 2, nTitle = 1, nStatistics = 5;
            nMaxp = gridHistory.Rows.Count + nExcel + nTitle + nStatistics;
            List<System.Drawing.Image> images = new List<System.Drawing.Image>();
            images.Add(Properties.Resources.MagicSheet0);

            string _filepath = $"{strPath}\\RMS_Report_Format.xlsx";

            // 해당 폴더에 파일이 있을 경우 삭제후 재 생성하도록함..
            // 생성은 엑셀 파일 세이브할때 생성됨..
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strPath);
            if (di.GetFiles().Length > 0)
            {
                foreach (System.IO.FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }

            // 엑셀 파일은 하위 save에서 생성이 되므로...별도 생성 필요없음..
            InteropExcel excelRef = new InteropExcel();
            InteropExcel excel = new InteropExcel();

            if (File.Exists(_filepath))
            {
                excelRef.Open(_filepath);
            }
            else
            {
                excelRef.AddSheet(RMS_Sheet.StatisticsData.ToDbString());
                excelRef.AddSheet(RMS_Sheet.BackData.ToString());
                excelRef.AddSheet(RMS_Sheet.Reference.ToString());
            }

            try
            {
                excel.AddSheet(RMS_Sheet.StatisticsData.ToDbString());
                excel.AddSheet(RMS_Sheet.BackData.ToString());
                excel.AddSheet(RMS_Sheet.Reference.ToString());

                // Excel 초기화 백분율 진행
                nProgcnt += nExcel;

                // 진행변수 선언
                List<object> Titles = new List<object>();
                List<object> Formats = new List<object>();
                //List<Microsoft.Office.Interop.Excel.Range> cells = null;
                System.Drawing.Rectangle areas;

                // Reference 항목을 넣는다.
                Titles.Clear();
                Titles.Add("Judge");
                Titles.Add("OK");
                Titles.Add("IDLE");
                Titles.Add("NG");
                areas = new System.Drawing.Rectangle(1, 1, 1, Titles.Count);
                excel.CopyCells(excelRef, (int)RMS_Sheet.Reference, areas, false);
                Formats.Clear();
                excel.AddDataes((int)RMS_Sheet.Reference, Titles, Formats, areas, false);

                // BackData에 제목을 넣는다.
                Titles.Clear();
                Titles.Add("Time");
                Titles.Add("Model");
                Titles.Add("QR(ID)");
                Titles.Add("Part_Method");
                Titles.Add("Insp_Judge");
                Titles.Add("RMS_Judge");
                Titles.Add("Match_Judge");
                Titles.Add("Total");
                Titles.Add("Insp_OK");
                Titles.Add("RMS_OK");
                Titles.Add("Match");
                Titles.Add("Insp_Rate");
                Titles.Add("RMS_RATE");
                Titles.Add("Match_Rate");
                Titles.Add("Reason");
                // 이미지 추출 모드일 경우...가져오기..
                if (chb_Excel_ImgInput.Checked)
                {
                    Titles.Add("Origin_Image");
                    Titles.Add("Overlay_Image");
                    for (int i = 0; i < 30; i++)
                    {
                        Titles.Add("Crop_Image");
                        Titles.Add("Ref_Image");
                    }
                }

                areas = new System.Drawing.Rectangle(1, 1, Titles.Count, 1);
                excel.CopyCells(excelRef, (int)RMS_Sheet.BackData, areas);
                Formats.Clear();
                excel.AddDataes((int)RMS_Sheet.BackData, Titles, Formats, areas);

                // Statistics에 제목을 넣는다.
                int nStaticsRow = 10;
                Titles.Clear();
                Titles.Add("Start");
                Titles.Add("End");
                Titles.Add("Total");
                Titles.Add("Insp_OK");
                Titles.Add("RMS_OK");
                Titles.Add("Match");
                Titles.Add("Recipe");
                Titles.Add("JobTitle");
                Titles.Add("Insp_Rate");
                Titles.Add("RMS_Rate");
                Titles.Add("Match_Rate");
                areas = new System.Drawing.Rectangle(1, nStaticsRow, Titles.Count, 1);
                excel.CopyCells(excelRef, (int)RMS_Sheet.StatisticsData, areas);
                Formats.Clear();
                excel.AddDataes((int)RMS_Sheet.StatisticsData, Titles, Formats, areas);

                nProgcnt += nTitle;

                List<string> Items = new List<string>();
                List<string> RowData = new List<string>();

                List<string> statistics = new List<string>();
                List<string> statistEnd = new List<string>();
                string prevQR = "";
                string prevModel = "";
                string prevTime = "";
                string startModel = "";
                object inData = null;
                object inFormat = null;
                int nAddRow = 0;
                int nNextRow = 0;
                int nTitleRow = 1;
                int nPrevItemCnt = 0;
                int nNGCnt = 0;
                bool bNormalProcess = true;
                System.Drawing.Point inPt = new System.Drawing.Point();

                for (int h = 0; h < gridHistory.Rows.Count; h++)
                {
                    // 종료 플래그 발생시 리턴..
                    if (ExcelMaking_return) return;

                    Items.Clear();
                    DataGridViewRow row = gridHistory.Rows[h];
                    RowData.Clear();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        RowData.Add(row.Cells[i].Value.ToString());
                    }
                    if (prevQR == RowData[2])
                        bNormalProcess = false;
                    else
                    {
                        nNextRow++;
                        nNGCnt = 0;
                        bNormalProcess = true;
                    }

                    if (bNormalProcess)
                    {
                        if (prevModel != RowData[1])
                        {
                            if (statistEnd.Count > 0)
                            {
                                for (int j = 0; j < statistEnd.Count; j++)
                                    statistics.Add(statistEnd[j]);

                                for (int j = 0; j < statistics.Count; j++)
                                {
                                    inFormat = null;
                                    inPt = new System.Drawing.Point(j + 1, nStaticsRow + nAddRow);
                                    if (j <= 1)
                                    {
                                        inFormat = "yyyy-mm-dd hh:mm:ss";
                                        string strDate = ConvertDateTimeString(statistics[j]);
                                        DateTime dt = DateTime.Parse(strDate);     // String 형식의 날짜를 DateTime 형식으로 변환
                                        inData = dt;
                                    }
                                    else if (j >= 8 && j <= 10)
                                    {
                                        inFormat = "0.00%";
                                        inData = statistics[j];
                                    }
                                    else
                                        inData = statistics[j];
                                    excel.CopyCell(excelRef, (int)RMS_Sheet.StatisticsData, inPt);
                                    excel.AddData((int)RMS_Sheet.StatisticsData, inData, inFormat, inPt);
                                }
                            }

                            //nNG = nTot = nMatch = nInsNG = 0;
                            nAddRow++;
                            startModel = $"${nNextRow + nTitleRow + nAddRow}";
                            statistics.Clear();
                            statistics.Add(RowData[0]);     // StartTime
                        }

                        // Time
                        Items.Add(RowData[0]);
                        prevTime = RowData[0];
                        // Model
                        Items.Add(RowData[1]);
                        prevModel = RowData[1];
                        // QR
                        Items.Add(RowData[2]);
                        prevQR = RowData[2];

                        // Part/Method
                        Items.Add(RowData[9]);
                        // Insp/RMS Judge
                        Items.Add(RowData[3]);
                        Items.Add(RowData[4]);

                        // Match
                        Items.Add($"=IF(E{nNextRow + nTitleRow + nAddRow}=F{nNextRow + nTitleRow + nAddRow},\"OK\",\"NG\")");

                        // Count(Tot/Insp/RMS/Match
                        Items.Add($"=COUNTA(E{startModel}:E{nNextRow + nTitleRow + nAddRow})");
                        Items.Add($"= COUNTIF(E{startModel}:E{nNextRow + nTitleRow + nAddRow}, \"OK\"");
                        Items.Add($"= COUNTIF(F{startModel}:F{nNextRow + nTitleRow + nAddRow}, \"OK\"");
                        Items.Add($"= COUNTIF(G{startModel}:G{nNextRow + nTitleRow + nAddRow}, \"OK\"");

                        // Rate(Insp/RMS/Match
                        Items.Add($"=I{nNextRow + nTitleRow + nAddRow}/H{nNextRow + nTitleRow + nAddRow}");
                        Items.Add($"=J{nNextRow + nTitleRow + nAddRow}/H{nNextRow + nTitleRow + nAddRow}");
                        Items.Add($"=K{nNextRow + nTitleRow + nAddRow}/H{nNextRow + nTitleRow + nAddRow}");

                        for (int j = 0; j < Items.Count; j++)
                        {
                            inFormat = null;
                            inPt = new System.Drawing.Point(j + 1, nNextRow + nTitleRow + nAddRow);
                            if (j == 0)
                            {
                                inFormat = "yyyy-mm-dd hh:mm:ss";
                                string strDate = ConvertDateTimeString(Items[j]);
                                DateTime dt = DateTime.Parse(strDate);     // String 형식의 날짜를 DateTime 형식으로 변환
                                inData = dt;
                            }
                            else if (j >= 4 && j <= 5)      // Insp/RMS Judge - 목록 추가
                            {
                                inData = Items[j];
                                excel.DataValidation(1, "=Reference!$A$2:$A$4", inPt);
                            }
                            else if (j >= 11 && j <= 13)    // Rate
                            {
                                inFormat = "0.00%";
                                inData = Items[j];
                            }
                            else
                                inData = Items[j];

                            excel.CopyCell(excelRef, (int)RMS_Sheet.BackData, inPt);
                            excel.AddData((int)RMS_Sheet.BackData, inData, inFormat, inPt);
                        }

                        // Reason
                        inPt = new System.Drawing.Point(Items.Count + 1, nNextRow + nTitleRow + nAddRow);
                        inData = RowData[10];
                        excel.CopyCell(excelRef, (int)RMS_Sheet.BackData, inPt);
                        excel.AddData((int)RMS_Sheet.BackData, inData, inFormat, inPt);

                        // 이미지 추출모드일 경우에만 이미지 추출...
                        if (chb_Excel_ImgInput.Checked)
                        {
                            // Origin Image
                            if (RowData[5].Length > 0 && IF_Util.FileExist(RowData[5]))
                            {
                                string strName1 = $"Origin_Image{nNextRow}";
                                string strFileHyper1 = $"{strPath}\\{strName1}.jpg";
                                System.IO.File.Copy(RowData[5], strFileHyper1, true);                               // File Copy
                                inPt = new System.Drawing.Point(Items.Count + 2, nNextRow + nTitleRow + nAddRow);
                                excel.CopyCell(excelRef, (int)RMS_Sheet.BackData, inPt);
                                excel.AddHyperLink((int)RMS_Sheet.BackData, strFileHyper1, strName1, inPt);                               // Excel HyperLink
                            }

                            // Overlay Image
                            if (RowData[6].Length > 0 && IF_Util.FileExist(RowData[6]))
                            {
                                string strName2 = $"Overlay_Image{nNextRow}";
                                string strFileHyper2 = $"{strPath}\\{strName2}.jpg";
                                System.IO.File.Copy(RowData[6], strFileHyper2, true);
                                inPt = new System.Drawing.Point(Items.Count + 3, nNextRow + nTitleRow + nAddRow);
                                excel.CopyCell(excelRef, (int)RMS_Sheet.BackData, inPt);
                                excel.AddHyperLink((int)RMS_Sheet.BackData, strFileHyper2, strName2, inPt);                               // Excel HyperLink
                            }
                        }

                        // 여기서 통계자료 갱신 준비
                        statistEnd.Clear();

                        statistEnd.Add(RowData[0]); // EndTime
                        statistEnd.Add($"=\'{excel.GetSheetName((int)RMS_Sheet.BackData)}\'!H{nNextRow + nTitleRow + nAddRow}");   // TotCnt
                        statistEnd.Add($"=\'{excel.GetSheetName((int)RMS_Sheet.BackData)}\'!I{nNextRow + nTitleRow + nAddRow}");   // InspCnt
                        statistEnd.Add($"=\'{excel.GetSheetName((int)RMS_Sheet.BackData)}\'!J{nNextRow + nTitleRow + nAddRow}");   // RMSCnt
                        statistEnd.Add($"=\'{excel.GetSheetName((int)RMS_Sheet.BackData)}\'!K{nNextRow + nTitleRow + nAddRow}");   // MatchCnt

                        //statistEnd.Add(RowData[1]); // PBA코드 없으니 우선 모델로
                        statistEnd.Add(RowData[1]); // Recipe

                        // JobTitle
                        string strShortDate = ConvertShortDateString(statistEnd[0]);
                        string strJobTitle = strShortDate + "_" + RowData[1];
                        statistEnd.Add(strJobTitle);

                        statistEnd.Add($"=\'{excel.GetSheetName((int)RMS_Sheet.BackData)}\'!L{nNextRow + nTitleRow + nAddRow}");   // InspRate
                        statistEnd.Add($"=\'{excel.GetSheetName((int)RMS_Sheet.BackData)}\'!M{nNextRow + nTitleRow + nAddRow}");   // RMSRate
                        statistEnd.Add($"=\'{excel.GetSheetName((int)RMS_Sheet.BackData)}\'!N{nNextRow + nTitleRow + nAddRow}");   // MatchRate

                        nPrevItemCnt = Items.Count + 4; // Image위치 설정
                    }

                    if (chb_Excel_ImgInput.Checked)
                    {
                        // NG Image
                        if (RowData[7].Length > 0 && IF_Util.FileExist(RowData[7]))
                        {
                            string strName1 = $"NG_Image{nNextRow}_{nNGCnt}";
                            string strFileHyper1 = $"{strPath}\\{strName1}.jpg";
                            System.IO.File.Copy(RowData[7], strFileHyper1, true);
                            inPt = new System.Drawing.Point(nPrevItemCnt + (nNGCnt) * 2, nNextRow + nTitleRow + nAddRow);
                            excel.CopyCell(excelRef, (int)RMS_Sheet.BackData, inPt);
                            excel.AddHyperLink((int)RMS_Sheet.BackData, strFileHyper1, strName1, inPt);                               // Excel HyperLink
                        }

                        // NG-참조 Image
                        if (RowData[8].Length > 0 && IF_Util.FileExist(RowData[8]))
                        {
                            string strName2 = $"Ref_Image{nNextRow}_{nNGCnt}";
                            string strFileHyper2 = $"{strPath}\\{strName2}.jpg";
                            System.IO.File.Copy(RowData[8], strFileHyper2, true);
                            inPt = new System.Drawing.Point(nPrevItemCnt + (nNGCnt) * 2 + 1, nNextRow + nTitleRow + nAddRow);
                            excel.CopyCell(excelRef, (int)RMS_Sheet.BackData, inPt);
                            excel.AddHyperLink((int)RMS_Sheet.BackData, strFileHyper2, strName2, inPt);                               // Excel HyperLink
                            nNGCnt++;
                        }
                    }

                    nProgcnt++;
                }

                if (statistEnd.Count > 0)
                {
                    for (int j = 0; j < statistEnd.Count; j++)
                        statistics.Add(statistEnd[j]);

                    for (int j = 0; j < statistics.Count; j++)
                    {
                        inFormat = null;
                        inPt = new System.Drawing.Point(j + 1, nStaticsRow + nAddRow);
                        if (j <= 1)
                        {
                            inFormat = "yyyy-mm-dd hh:mm:ss";
                            string strDate = ConvertDateTimeString(statistics[j]);
                            DateTime dt = DateTime.Parse(strDate);     // String 형식의 날짜를 DateTime 형식으로 변환
                            inData = dt;
                        }
                        else if (j >= 8 && j <= 10)
                        {
                            inFormat = "0.00%";
                            inData = statistics[j];
                        }
                        else inData = statistics[j];
                        excel.CopyCell(excelRef, (int)RMS_Sheet.StatisticsData, inPt);
                        excel.AddData((int)RMS_Sheet.StatisticsData, inData, inFormat, inPt);
                    }
                }

                //Add chart.
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(8, nStaticsRow, 3, nAddRow);
                excel.AddChart((int)RMS_Sheet.StatisticsData, rect, XlChartType.xl3DColumnClustered, "Inspect Report", "Judge Process : Insp/RMS/Match", "Rate");

                nProgress = 100;
                excel.Save($"{_filepath}");
                excel.Close(_filepath);
                excelRef.Close(_filepath);

                IF_Util.ShowMessageBox("COMPLTE", $"Excel Write Complte!!");
            }
            catch (Exception ex)
            {
                excel.ReleaseExcel();
                excelRef.ReleaseExcel();

                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
            finally
            {
                excel.ReleaseExcel();
                excelRef.ReleaseExcel();
            }
        }

        Task task_ExcelMaking;
        bool ExcelMaking_return;

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string str;

            if (gridHistory.Rows.Count <= 0)
            {
                IF_Util.ShowMessageBox("CHECK", "No Search Data!! Data Search Please!!");
                return;
            }

            if (rab_TxtOutput.Checked)
            {
                str = "Txt File Write Start??, [Check] => No statistics Data Write! Current Data Write!";
            }
            else
            {
                str = "Excel File Write Start??";
            }

            if (IF_Util.ShowMessageBox("CHECK", str, FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
            {
                // 폴더 설정 및 파일 삭제
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                if (Util.CheckDriveInfo("D:\\"))
                    fbd.SelectedPath = "D:\\EXCEL_REPORT";
                else
                    fbd.SelectedPath = "E:\\EXCEL_REPORT";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string strExcel = fbd.SelectedPath;

                    if (!fbd.SelectedPath.Contains("EXCEL_REPORT"))
                    {
                        strExcel = $"{fbd.SelectedPath}\\EXCEL_REPORT";
                        Directory.CreateDirectory(strExcel);
                    }

                    nProgress = 0;
                    //pnl_ExcelMaking.Visible = true;
                    ExcelMaking_return = false;

                    task_ExcelMaking = Task.Run(() =>
                    {
                        if (rab_TxtOutput.Checked)
                        {
                            CSVFileMake(strExcel);
                        }
                        else
                        {
                            ExcelMake2(strExcel);
                        }
                    });
                }
            }
        }

        private string ConvertShortDateString(string strDate)
        {
            string retStr = "";
            retStr += strDate.Substring(2, 2);
            retStr += "/";
            retStr += strDate.Substring(4, 2);
            retStr += "/";
            retStr += strDate.Substring(6, 2);
            return retStr;
        }

        private string ConvertDateTimeString(string strDate)
        {
            string retStr = "";
            retStr += strDate.Substring(0, 4);
            retStr += "-";
            retStr += strDate.Substring(4, 2);
            retStr += "-";
            retStr += strDate.Substring(6, 2);
            retStr += " ";
            retStr += strDate.Substring(9, 2);
            retStr += ":";
            retStr += strDate.Substring(11, 2);
            retStr += ":";
            retStr += strDate.Substring(13, 2);
            return retStr;
        }

        private void btnSetWeek_Click(object sender, EventArgs e)
        {
            try
            {
                datePickerEnd.Value = DateTime.Now;
                datePickerStart.Value = DateTime.Now.AddDays(-7);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnExcel_MouseHover(object sender, EventArgs e)
        {
            //btnExcel.Image = Properties.Resources.Excel50_MouseHover;
            btnExcel.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnExcel_MouseLeave(object sender, EventArgs e)
        {
            //btnExcel.Image = Properties.Resources.Excel50_Normal;
            btnExcel.ForeColor = Color.White;
        }

        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            //btnSearch.Image = Properties.Resources.Search50_MouseHover;
            btnSearch.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            //btnSearch.Image = Properties.Resources.Search50_Normal;
            btnSearch.ForeColor = Color.White;
        }

        private void btnJudge_Click(object sender, EventArgs e)
        {
            string strQrCode = lbQrCode.Text;
            string strReason = cboReasonHist.Text;
            string strJudge = cboJudge.Text;
            bool bQR = false;
            if (cboSelect.Text == "QR")
                bQR = true;
            else if (cboSelect.Text == "BOARD")
                g_Part = "";
            bool isRMS = true;
            if (cboJudgeType.SelectedIndex > 0)
                isRMS = false;

            if (cboSelect.Text == "MODEl")
                Global.DB.UpdateJudgeNReason("HISTORY", strJudge, isRMS, g_SelDate, g_Part, strReason, bQR, strQrCode, g_Model);
            else
                Global.DB.UpdateJudgeNReason("HISTORY", strJudge, isRMS, g_SelDate, g_Part, strReason, bQR, strQrCode);
            btnSearch_Click(null, null);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            RMS_BufferMonitorDisp();
        }

        private void OnClick(object sender, EventArgs e)
        {
            lbSelectArray1.BackColor = Color.Transparent;
            lbSelectArray2.BackColor = Color.Transparent;

            System.Windows.Forms.Label lbl = sender as System.Windows.Forms.Label;
            lbl.BackColor = DEFINE_COMMON.COLOR_GREEN;

            if (lbl.Name == "lbSelectArray1")
            {
                gridBuffer_ClickDisp(0);
            }
            else
            {
                gridBuffer_ClickDisp(1);
            }
        }

        private void gridBuffer_ClickDisp(int index)
        {
            // QR을 기준으로 불량 내용 화면 표시..
            if (Global.Buffer_BoardOut_QRCODE != "")
            {
                if (Global.Instance.ResultImage[index] != null)
                {
                    cogDisplay_NG.Image = new CogImage24PlanarColor(new Bitmap(Global.Instance.ResultImage[index].ToBitmap()));
                    cogDisplay_NG.Fit(true);
                }
                else
                {
                    cogDisplay_NG.Image = null;
                }
            }
        }

        string select_id = "";

        private void gridBuffer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridBuffer.SelectedRows.Count == 0) return;

                IsCell_Click_First_NG_Buffer_Grid = true;

                int nRowIndex = 0;
                string strQrcods = "";

                if (BUFFER_ID == "")
                {
                    nRowIndex = m_nSelectedRow = g_SelectGB = gridBuffer.SelectedRows[0].Index;
                    Global.Instance.Data.Buffer_ID = gridBuffer[0, nRowIndex].Value.ToString();
                    strQrcods = gridBuffer[2, nRowIndex].Value.ToString();
                }
                else
                {
                    nRowIndex = m_nSelectedRow = g_SelectGB = e.RowIndex;
                    Global.Instance.Data.Buffer_ID = BUFFER_ID;
                    strQrcods = QRCode;
                }

                lbSelectedBuffer.Text = $"INDEX ==> {Global.Instance.Data.Buffer_ID}";
                RMS_BufferMonitorDisp();

                if (gridBufferMonitor.Rows.Count > 1)
                {
                    gridBufferMonitor.SelectedRows[0].Selected = true;
                    gridBufferMonitor.FirstDisplayedScrollingRowIndex = 0;

                    gridBufferMonitor_CellClick(null, null);
                }

                select_id = strQrcods;
                //gridBuffer_ClickDisp(0);

                List<string> NgBufferIds = new List<string>();

                for (int i = 0; i < Global.Instance.Device.NGBUFFER.GetBufferCount(); i++)
                {
                    (string exist, string id, string result) result = Global.Device.NGBUFFER.GetSignal_Mewtoxcol(i);

                    string ids = result.id;

                    if (ids.Length > 0)
                    {
                        string[] strParse = ids.Split('/');

                        for (int k = 0; k < gridBufferMonitor.Rows.Count; k++)
                        {
                            string QRCode = gridBufferMonitor[2, 1].Value.ToString();

                            NgBufferIds.Add(QRCode);

                            for (int j = 1; j < strParse.Length; j++)
                            {
                                QRParser qrAdd = new QRParser(QRCode + strParse[j], true);
                                NgBufferIds.Add(qrAdd.GetQR());
                            }
                        }

                        //QRParser qrMain = new QRParser(strParse[0], true);
                        //NgBufferIds.Add(qrMain.GetQR());

                        //for (int j = 1; j < strParse.Length; j++)
                        //{
                        //    QRParser qrAdd = new QRParser(qrMain.GetQRTitle() + strParse[i], true);
                        //    NgBufferIds.Add(qrAdd.GetQR());
                        //}
                    }
                }

                //if (NgBufferIds.Count > 0)
                //{
                //    List<string[]> list = IGlobal.Instance.DB.SelectAll_NGBuffer_RMS_IDLE("HISTORY", NgBufferIds.ToList());

                //    if (list.Count == 0)
                //    {
                //        btnRMS_OK.Enabled = false;
                //    }
                //    else
                //    {
                //        btnRMS_OK.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void lbl_BoardOutData_Click(object sender, EventArgs e)
        {
            string str = lbl_BoardOutData.Text;

            if (str == "ID :  ")
            {
                IF_Util.ShowMessageBox("Check", "Not QR Value ID");
                return;
            }
            string[] str_split = str.Split(':');

            Global.Buffer_BoardOut_QRCODE = str_split[1].Trim();

            lbSelectArray1.Visible = true;
            lbSelectArray2.Visible = true;

            lbSelectArray1.BackColor = DEFINE_COMMON.COLOR_GREEN;
            lbSelectArray2.BackColor = Color.Transparent;

            if (Global.Buffer_BoardOut_QRCODE != "")
            {
                // 파일의 경로에 이미지 읽어오기..
                StageImage_Serch();

                // 결과 이미지가 담겨올경우에..
                if (Global.Instance.ResultImage[0] != null) lbSelectArray1.Enabled = true;
                else lbSelectArray1.Enabled = false;
                if (Global.Instance.ResultImage[1] != null) lbSelectArray2.Enabled = true;
                else lbSelectArray2.Enabled = false;

                gridBuffer_ClickDisp(0);
                RMS_BufferMonitorDisp();
            }
            else
            {
                IF_Util.ShowMessageBox("Error", "Not Board Out Data!!");
            }
        }

        private void tmr_ExcelMaking_Progess_Tick(object sender, EventArgs e)
        {
            if (task_ExcelMaking == null)
            {
                //pnl_ExcelMaking.Visible = false;
                nProgcnt = 0;
                nProgress = 0;
                return;
            }

            if (TaskStatus.Running == task_ExcelMaking.Status)
            {
                btn_Cancel.Enabled = true;
                //pnl_ExcelMaking.Visible = true;
                if (nProgcnt != 0) nProgress = ((double)nProgcnt / nMaxp * 100);           // 프로그레스의 퍼센테이지를 확인...
                else nProgress = 0;

                if (nProgress > 0)
                {
                    //pnl_ExcelMaking.Visible = true;

                    if (nProgress < pb_ExcelMaking.Maximum)
                    {
                        lbl_ExcelMaking_Percent.Text = $"{nProgress.ToString("0.0")} %";
                        pb_ExcelMaking.Value = (int)nProgress;
                    }
                    else
                    {
                        pb_ExcelMaking.Value = pb_ExcelMaking.Maximum;
                    }
                }
            }
            else
            {
                //pnl_ExcelMaking.Visible = false;
                btn_Cancel.Enabled = false;
                nProgcnt = 0;
                nProgress = 0;
                pb_ExcelMaking.Value = 0;
                lbl_ExcelMaking_Percent.Text = $"0.0 %";
            }
        }

        // 추가...CALL STAGE RE-TEST
        private void btn_CallStage_Retest_Click(object sender, EventArgs e)
        {
            if (Global.Device.NGBUFFER != null)
            {
                Global.Device.NGBUFFER.Command_CallStage_Board_Retest();

                Task.Run(() =>
                {
                    (sender as System.Windows.Forms.Button).BackColor = Color.Green;
                    Thread.Sleep(1000);
                    (sender as System.Windows.Forms.Button).BackColor = Color.FromArgb(44, 46, 66);
                });
            }
        }

        private void btn_CallStage_BoardPass_Click(object sender, EventArgs e)
        {
            if (Global.Device.NGBUFFER != null)
            {
                Global.Device.NGBUFFER.Command_Board_Pass();

                Task.Run(() =>
                {
                    (sender as System.Windows.Forms.Button).BackColor = Color.Green;
                    Thread.Sleep(1000);
                    (sender as System.Windows.Forms.Button).BackColor = Color.FromArgb(44, 46, 66);
                });
            }
        }

        private void chb_Excel_ImgInput_Click(object sender, EventArgs e)
        {
            if (chb_Excel_ImgInput.Checked)
            {
                rab_ExcelOutput.Enabled = true;
                rab_TxtOutput.Enabled = false;
                rab_ExcelOutput.Checked = true;
            }
            else
            {
                rab_ExcelOutput.Enabled = true;
                rab_TxtOutput.Enabled = true;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (task_ExcelMaking != null)
            {
                ExcelMaking_return = true;
                task_ExcelMaking = null;

                IF_Util.ShowMessageBox("CHECK", "Excel File Write Cancel!");
            }
        }

        private void btnSetDay_MouseHover(object sender, EventArgs e)
        {
            btnSetDay.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnSetDay_MouseLeave(object sender, EventArgs e)
        {
            btnSetDay.ForeColor = Color.White;
        }

        private void btnSetWeek_MouseHover(object sender, EventArgs e)
        {
            btnSetWeek.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnSetWeek_MouseLeave(object sender, EventArgs e)
        {
            btnSetWeek.ForeColor = Color.White;
        }

        private void btnJudge_MouseHover(object sender, EventArgs e)
        {
            btnJudge.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnJudge_MouseLeave(object sender, EventArgs e)
        {
            btnJudge.ForeColor = Color.White;
        }

        private void btnRmsJudgeOk_MouseHover(object sender, EventArgs e)
        {
            btnRmsJudgeOk.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnRmsJudgeOk_MouseLeave(object sender, EventArgs e)
        {
            btnRmsJudgeOk.ForeColor = Color.White;
        }

        private void btnRmsJudgeNG_MouseHover(object sender, EventArgs e)
        {
            btnRmsJudgeNG.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnRmsJudgeNG_MouseLeave(object sender, EventArgs e)
        {
            btnRmsJudgeNG.ForeColor = Color.White;
        }

        private void btnRmsJudgeIDLE_MouseHover(object sender, EventArgs e)
        {
            btnRmsJudgeIDLE.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnRmsJudgeIDLE_MouseLeave(object sender, EventArgs e)
        {
            btnRmsJudgeIDLE.ForeColor = Color.White;
        }

        private void btn_Refresh_MouseHover(object sender, EventArgs e)
        {
            btn_Refresh.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btn_Refresh_MouseLeave(object sender, EventArgs e)
        {
            btn_Refresh.ForeColor = Color.White;
        }

        private void btn_CallStage_Retest_MouseHover(object sender, EventArgs e)
        {
            btn_CallStage_Retest.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btn_CallStage_Retest_MouseLeave(object sender, EventArgs e)
        {
            btn_CallStage_Retest.ForeColor = Color.White;
        }

        private void btn_CallStage_BoardPass_MouseHover(object sender, EventArgs e)
        {
            btn_CallStage_BoardPass.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btn_CallStage_BoardPass_MouseLeave(object sender, EventArgs e)
        {
            btn_CallStage_BoardPass.ForeColor = Color.White;
        }

        private void btnRMS_BoardOut_MouseHover(object sender, EventArgs e)
        {
            btnRMS_BoardOut.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnRMS_BoardOut_MouseLeave(object sender, EventArgs e)
        {
            btnRMS_BoardOut.ForeColor = Color.White;
        }

        private void btnRMS_Retest_MouseHover(object sender, EventArgs e)
        {
            btnRMS_Retest.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnRMS_Retest_MouseLeave(object sender, EventArgs e)
        {
            btnRMS_Retest.ForeColor = Color.White;
        }

        private void btnRMS_OK_MouseHover(object sender, EventArgs e)
        {
            btnRMS_OK.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnRMS_OK_MouseLeave(object sender, EventArgs e)
        {
            btnRMS_OK.ForeColor = Color.White;
        }

        private void lbl_BoardOutData_MouseHover(object sender, EventArgs e)
        {
            lbl_BoardOutData.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void lbl_BoardOutData_MouseLeave(object sender, EventArgs e)
        {
            lbl_BoardOutData.ForeColor = Color.White;
        }

        private void btn_Cancel_MouseHover(object sender, EventArgs e)
        {
            btn_Cancel.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btn_Cancel_MouseLeave(object sender, EventArgs e)
        {
            btn_Cancel.ForeColor = Color.White;
        }



        private void viewMode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioViewNG.Checked)
            {
                if (_lastImagePath_NG != null && _lastImagePath_NG.Length == 2)
                {
                    try
                    {
                        cogDisplay_NG.Image = new CogImage24PlanarColor(new Bitmap(_lastImagePath_NG[1]));

                        string sOriImgPath = _lastImagePath_NG[1].Replace("_NG.jpg", "_ORI.jpg");
                        if (File.Exists(sOriImgPath))
                        {
                            cogDisplay_OriginImage.Image = new CogImage24PlanarColor(new Bitmap(sOriImgPath));
                            cogDisplay_OriginImage.Fit();
                        }
                    }
                    catch { }
                }

                cogDisplay_NG.Visible = true;
            }
            else
            {
                cogDisplay_NG.Visible = false;
            }

            if (radioViewAll.Checked)
            {
                if (_lastImagePath_NG != null && _lastImagePath_NG.Length == 2)
                {
                    try
                    {
                        cogDisplay_NG.Image = new CogImage24PlanarColor(new Bitmap(_lastImagePath_NG[0]));
                    }
                    catch { }
                }

                cogDisplay_NG.Visible = true;
            }

            if (radioViewMaster.Checked)
            {
                cogDisplay_MasterImage.Visible = true;
            }
            else
            {
                cogDisplay_MasterImage.Visible = false;
            }

            if (radioViewOrigin.Checked)
            {
                cogDisplay_OriginImage.Visible = true;
            }
            else
            {
                cogDisplay_OriginImage.Visible = false;
            }
        }

        private void chkQRAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Board_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime searchStartTime = datePicker_Start.Value.Date + timePicker_Start.Value.TimeOfDay;
                DateTime searchEndTime = datePicker_End.Value.Date + timePicker_End.Value.TimeOfDay;

                string startDateTime = $"{searchStartTime.ToString("yyyyMMdd:HHmmss")}";
                string endDateTime = $"{searchEndTime.ToString("yyyyMMdd:HHmmss")}";

                List<string[]> list = null;

                gridHistory_Board.Rows.Clear();

                gridHistory_Board.SuspendLayout();
                //string modelName = combo_History_ModelName.Text;
                //string inspJudge = "ALL";
                //string rmsJudge = "ALL";

                //if (rb_History_InspJudge_Ok.Checked) inspJudge = "OK";
                //if (rb_History_InspJudge_Ng.Checked) inspJudge = "NG";

                //if (rb_History_RmsJudge_Ok.Checked) rmsJudge = "OK";
                //if (rb_History_RmsJudge_Ng.Checked) rmsJudge = "NG";
                if (cbResult_Board.Text == null)
                {
                    IF_Util.ShowMessageBox("Check", "RMS_JUDGE Select First !!!");
                    return;
                }
                else if (cbResult_Board.Text.Contains("ALL"))
                    list = sqlite.SelectAll_History(cboID_Board.Text, cboModel_Board.Text, startDateTime, endDateTime);
                else
                    list = sqlite.Select_History(cboJudgeType_Board.SelectedIndex, cboID_Board.Text, cboModel_Board.Text, startDateTime, endDateTime, cbResult_Board.Text);
                List<string> IDs = new List<string>();
                List<string> Models = new List<string>();
                IDs.Add("All");
                Models.Add("All");
                for (int i = 0; i < list.Count; i++)
                {
                    if (Global.Device.NGBUFFER != null)
                    {
                        for (int j = 0; j < Global.Device.NGBUFFER.GetBufferCount(); j++)
                        {
                            (string exist, string id, string result) result = Global.Device.NGBUFFER.GetSignal_Mewtoxcol(j);

                            string strID = result.id;
                            if (strID != "")
                            {
                                string[] strID_Split = strID.Split('/');
                                if (strID_Split.Length == 2)
                                {
                                    string strID1 = strID_Split[0];
                                    string strID2 = strID_Split[1];
                                    if (list[i][4].Contains(strID1) || list[i][4].Contains(strID2))
                                    {
                                        gridHistory_Board.Rows.Add(list[i]);
                                    }
                                }
                            }
                        }
                    }

                    // ID 리스트 확보
                    bool bFind = false;
                    for (int h = 1; h < IDs.Count; h++)
                    {
                        if (IDs[h] == list[i][2])
                        {
                            bFind = true;
                            break;
                        }
                    }
                    if (!bFind)
                        IDs.Add(list[i][2]);
                    // Model 리스트 확보
                    bFind = false;
                    for (int h = 1; h < Models.Count; h++)
                    {
                        if (Models[h] == list[i][1])
                        {
                            bFind = true;
                            break;
                        }
                    }
                    if (!bFind)
                        Models.Add(list[i][1]);

                    gridHistory_Board.Rows.Insert(0, list[i]);
                }
                // ID들을 넣음
                cboID_Board.Items.Clear();
                for (int i = 0; i < IDs.Count; i++)
                    cboID_Board.Items.Add(IDs[i]);
                // Model들을 넣음
                cboModel_Board.Items.Clear();
                for (int i = 0; i < Models.Count; i++)
                    cboModel_Board.Items.Add(Models[i]);
                cboModel_Board.SelectedIndex = 0;
                //GoPrevPos(false);
                gridHistory_Board.ResumeLayout();

                List<string> okList = new List<string>();
                List<string> ngList = new List<string>();
                for (int i = 0; i < gridHistory_Board.Rows.Count; i++)
                {
                    string result = gridHistory_Board.Rows[i].Cells[3].Value.ToString();
                    string qrCode = gridHistory_Board.Rows[i].Cells[2].Value.ToString();
                    string key = $"{qrCode}_{result}";

                    if (result == "OK" && okList.Contains(key) == false) okList.Add(key);
                    if (result == "NG" && ngList.Contains(key) == false) ngList.Add(key);
                }

                int totalCnt = okList.Count + ngList.Count;
                int okCnt = okList.Count;
                int ngCnt = ngList.Count;

                // 결과 내용 디스플레이...
                lbl_TotalCnt_Board.Text = totalCnt.ToString();
                lbl_NGcnt_Board.Text = ngCnt.ToString();
                lbl_OKcnt_Board.Text = okCnt.ToString();
                double percent = ((double)okCnt / totalCnt * 100);
                lbl_Yield_Board.Text = $"{percent.ToString("0.0")}%";
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void gridHistory_Board_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                try
                {
                    string[] imagePath = _lastImagePath_NG = gridHistory_Board[6, e.RowIndex].Value.ToString().Split('/');

                    if (imagePath.Length == 2)
                    {
                        if (radioViewAll.Checked)
                        {
                            cogDisplay_NG.Image = new CogImage24PlanarColor(new Bitmap(imagePath[0]));
                        }
                        else
                        {
                            cogDisplay_NG.Image = new CogImage24PlanarColor(new Bitmap(imagePath[1]));
                        }

                        string sOriImgPath = imagePath[1].Replace("_NG.jpg", "_ORI.jpg");
                        if (File.Exists(sOriImgPath))
                        {
                            cogDisplay_OriginImage.Image = new CogImage24PlanarColor(new Bitmap(sOriImgPath));
                            cogDisplay_OriginImage.Fit(false);
                        }
                    }

                    string model = gridHistory_Board[1, e.RowIndex].Value.ToString();
                    string path = $"{Global.m_MainPJTRoot}\\RECIPE\\{model}\\MasterBoard_{model}.jpg";

                    if (File.Exists(path))
                    {
                        cogDisplay_MasterImage.Image = new CogImage24PlanarColor(IF_Util.SafetyImageLoad(path));
                        cogDisplay_MasterImage.Fit(false);
                    }

                    lblNgPartsCount.Text = gridHistory_Board[7, e.RowIndex].Value.ToString();
                }
                catch { }
            }
            catch (Exception)
            {
            }
        }

        private void btnHistory_SetDay_Click(object sender, EventArgs e)
        {
            try
            {
                datePicker_End.Value = DateTime.Now;
                datePicker_Start.Value = DateTime.Now.AddDays(-1);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnHistory_SetWeek_Click(object sender, EventArgs e)
        {
            try
            {
                datePicker_End.Value = DateTime.Now;
                datePicker_Start.Value = DateTime.Now.AddDays(-7);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnHistory_SetWeeks_Click(object sender, EventArgs e)
        {
            try
            {
                datePicker_End.Value = DateTime.Now;
                datePicker_Start.Value = DateTime.Now.AddDays(-14);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void gridHistory_Board_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (gridHistory_Board.SelectedCells.Count > 0)
                    {
                        int RowIndex = gridHistory_Board.SelectedCells[0].RowIndex;

                        string[] imagePath = _lastImagePath_NG = gridHistory_Board[6, RowIndex].Value.ToString().Split('/');

                        if (imagePath.Length == 2)
                        {
                            if (radioViewAll.Checked)
                            {
                                cogDisplay_NG.Image = new CogImage24PlanarColor(new Bitmap(imagePath[0]));
                            }
                            else
                            {
                                cogDisplay_NG.Image = new CogImage24PlanarColor(new Bitmap(imagePath[1]));
                            }

                            string sOriImgPath = imagePath[1].Replace("_NG.jpg", "_ORI.jpg");
                            if (File.Exists(sOriImgPath))
                            {
                                cogDisplay_OriginImage.Image = new CogImage24PlanarColor(new Bitmap(sOriImgPath));
                                cogDisplay_OriginImage.Fit(false);
                            }
                        }

                        string model = gridHistory_Board[1, RowIndex].Value.ToString();
                        string path = $"{Global.m_MainPJTRoot}\\RECIPE\\{model}\\MasterBoard_{model}.jpg";

                        if (File.Exists(path))
                        {
                            cogDisplay_MasterImage.Image = new CogImage24PlanarColor(IF_Util.SafetyImageLoad(path));
                            cogDisplay_MasterImage.Fit(false);
                        }

                        lblNgPartsCount.Text = gridHistory_Board[7, RowIndex].Value.ToString();
                    }

                }
                catch { }
            }
            catch (Exception)
            {
            }
        }

        private void chb_Excel_ImgInput2_Click(object sender, EventArgs e)
        {
            if (chb_Excel_ImgInput_Board.Checked)
            {
                rab_ExcelOutput_Board.Enabled = true;
                rab_TxtOutput_Board.Enabled = false;
                rab_ExcelOutput_Board.Checked = true;
            }
            else
            {
                rab_ExcelOutput_Board.Enabled = true;
                rab_TxtOutput_Board.Enabled = true;
            }
        }
    }
}