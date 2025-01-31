using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.PMAlign;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Vila.Extensions;
using static IntelligentFactory.CVisionTools;


namespace IntelligentFactory
{
    public partial class FormMenu_Sub : Form
    {
        private Global Global = Global.Instance;
        private CogDisplay[] Display;

        private LogViewer logViewList = new LogViewer();
        private Dictionary<int, string> dicBUFFER_ID_Main = new Dictionary<int, string>();

        public FormMenu_Sub()
        {
            InitializeComponent();

            pnLog.Controls.Add(logViewList);
            logViewList.SetColumnImageWidth(pnLog.Width);

        }

        private void FormMenu_Sub_Load(object sender, EventArgs e)
        {
            Display = new CogDisplay[4] { cogDisplay_Array1, cogDisplay_Array2, cogDisplay_Array3, cogDisplay_Array4 };
            dicBUFFER_ID_Main = new Setting_RMS().dicBUFFER_ID_Done;
            InitUI();
            InitEvent();
        }

        private void InitUI() // P/A Compens
        {
            try
            {
                Init_CogDisplayVisible();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void InitEvent() // P/A Compens
        {
            try
            {
                Global.SeqVision.EventInspEnd += OnInspEnd;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public void OnInspEnd(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnInspEnd(sender, e);
                    }));
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
            else
            {
                try
                {
                    if (Global.Instance.System.Recipe.ArrayCount > 0)
                    {
                        for (int i = 0; i < Global.Instance.System.Recipe.ArrayCount; i++)
                        {
                            string result = Global.Instance.Data.ArrayResults[i] ? "OK" : "NG";
                            string qrCode = Global.Instance.Data.Array_QrCodes[i].GetQR();

                            //2024.04.02 송현수
                            //if (CVisionTools.QR_Reading_Error)
                            //{
                            //    desc = "QR Reading Error!! QR Check Please!";
                            //}
                            //else
                            //{ 
                            //    if (qrCode == "")
                            //    {
                            //        desc = "No Inspec!! Vision Setting Check!!";
                            //    }
                            //}

                            if (result == "NG")
                                result = $"{result} : {Global.Instance.Data.Result_NG_Count[i].ToString()}";

                            if (i == 0)
                            {
                                lblArray1.Text = $"Array [1] - {qrCode} ({result})";
                                //lblArray1.BackColor = cogDisplay_Array1.BackColor = result == "OK" ? Color.Green : DEFINE.COLOR_RED;
                                lblArray1.BackColor = result == "OK" ? Color.Green : DEFINE.COLOR_RED;
                            }
                            if (i == 1)
                            {
                                lblArray2.Text = $"Array [2] - {qrCode} ({result})";
                                //lblArray2.BackColor = cogDisplay_Array2.BackColor = result == "OK" ? Color.Green : DEFINE.COLOR_RED;
                                lblArray2.BackColor = result == "OK" ? Color.Green : DEFINE.COLOR_RED;
                            }
                            if (i == 2)
                            {
                                lblArray3.Text = $"Array [3] - {qrCode} ({result})";
                                //lblArray3.BackColor = cogDisplay_Array3.BackColor = result == "OK" ? Color.Green : DEFINE.COLOR_RED;
                                lblArray3.BackColor = result == "OK" ? Color.Green : DEFINE.COLOR_RED;
                            }
                            if (i == 3)
                            {
                                lblArray4.Text = $"Array [4] - {qrCode} ({result})";
                                //lblArray4.BackColor = cogDisplay_Array4.BackColor = result == "OK" ? Color.Green : DEFINE.COLOR_RED;
                                lblArray4.BackColor = result == "OK" ? Color.Green : DEFINE.COLOR_RED;
                            }

                            if (Display[i] != null && Global.Instance.ImageResults_array[i] != null)
                            {
                                Display[i].Image = new CogImage24PlanarColor(Global.Instance.ImageResults_array[i]);
                                Display[i].Fit(false);
                            }
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                    IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
                }
            }

        }
        // 보드 수량은 최대 4개...
        public void Init_CogDisplayVisible()
        {
            try
            {
                
                    pnlArray1.Location = new System.Drawing.Point(1, 1);
                    pnlArray2.Location = new System.Drawing.Point(724, 1);
                    pnlArray3.Location = new System.Drawing.Point(1, 445);
                    pnlArray4.Location = new System.Drawing.Point(724, 445);
               
                    //pnlArray1.Location = new System.Drawing.Point(724, 1);
                    //pnlArray2.Location = new System.Drawing.Point(1, 1);
                    //pnlArray3.Location = new System.Drawing.Point(724, 445);
                    //pnlArray4.Location = new System.Drawing.Point(1, 445);
               

                // 보드 카운트 수량에 따라...표시..
                if (Global.Instance.System.Recipe.ArrayCount == 1)
                {
                    pnlArray1.Visible = true;
                    pnlArray1.Size = new System.Drawing.Size(1448, 889);
                    pnlArray2.Visible = false;
                    pnlArray3.Visible = false;
                    pnlArray4.Visible = false;
                }
                else if (Global.Instance.System.Recipe.ArrayCount == 2)
                {
                    pnlArray1.Visible = true;
                    pnlArray1.Size = new System.Drawing.Size(723, 889);
                    pnlArray2.Visible = true;
                    pnlArray2.Size = new System.Drawing.Size(723, 889);
                    pnlArray3.Visible = false;
                    pnlArray4.Visible = false;
                }
                else if (Global.Instance.System.Recipe.ArrayCount == 3)
                {
                    pnlArray1.Visible = true;
                    pnlArray1.Size = new System.Drawing.Size(723, 444);
                    pnlArray2.Visible = true;
                    pnlArray2.Size = new System.Drawing.Size(723, 444);
                    pnlArray3.Visible = true;
                    pnlArray4.Visible = false;
                }
                else
                {
                    pnlArray1.Visible = true;
                    pnlArray1.Size = new System.Drawing.Size(723, 444);
                    pnlArray2.Visible = true;
                    pnlArray2.Size = new System.Drawing.Size(723, 444);
                    pnlArray3.Visible = true;
                    pnlArray4.Visible = true;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

        }


        // 수정된 io클래스의 형태에 맞춰서 io 디스플레이..
        private void timerIO_Tick(object sender, EventArgs e)
        {
            if (Global.Instance.Device == null) return;
            if (Global.Instance.Device.DIO_BD == null) return;
            if (Global.Instance.Device.DIO_BD.IO_DATA == null) return;
            if (Global.Instance.Device.DIO_BD.IO_DATA.list_DO_Data == null) return;

            IF_Util.UpdateLabelOnOff(lbInputStart, CDIO_BIT.INSP_START);
            IF_Util.UpdateLabelOnOff(lbOutputResultOK, CDIO_BIT.RESULT_OK);
            IF_Util.UpdateLabelOnOff(lbOutputResultNG, CDIO_BIT.RESULT_NG);

            if (Global.Device.NGBUFFER != null && Global.Device.NGBUFFER.IsOpen)
            {
                if (Global.Device.NGBUFFER.DEBUG_R2141_NG_JUDGE_SET != null) DEBUG_R2141_NG_JUDGE_SET.BackColor = Global.Device.NGBUFFER.DEBUG_R2141_NG_JUDGE_SET.Value == 1 ? Color.Green : Color.DimGray;
                if (Global.Device.NGBUFFER.DEBUG_R918_INSP_POS_ACTION != null) DEBUG_R918_INSP_POS_ACTION.BackColor = Global.Device.NGBUFFER.DEBUG_R918_INSP_POS_ACTION.Value == 1 ? Color.Green : Color.DimGray;
                if (Global.Device.NGBUFFER.DEBUG_R559_RACK_ENTERING != null) DEBUG_R559_RACK_ENTERING.BackColor = Global.Device.NGBUFFER.DEBUG_R559_RACK_ENTERING.Value == 1 ? Color.Green : Color.DimGray;
                if (Global.Device.NGBUFFER.DEBUG_R2120_RACK_ENTERING_NG_SET != null) DEBUG_R2141_NG_JUDGE_SET.BackColor = Global.Device.NGBUFFER.DEBUG_R2120_RACK_ENTERING_NG_SET.Value == 1 ? Color.Green : Color.DimGray;
            }

            Init_CogDisplayVisible();
            if (Global.SeqVision != null)
            {
                lbl_inspecRunTime.Text = $"Inspection Run Time : {Global.SeqVision.CycleTime} ms";
                //lblLastComm.Text = Global.SeqVision.LastCommInfo;
            }
        }

        public (string, string, string) GetSignal_Mewtoxcol(int idx)
        {
            string Exist = "";
            string ID = "";
            string Result = "NG";

            if (idx == 0)
            {
                Exist = Global.Device.NGBUFFER.IN_BUFFER1_EXISTS.Value == 1 ? "V" : "";
                ID = Global.Device.NGBUFFER.IN_BUFFER1_ID.ID;
                Result = Global.Device.NGBUFFER.IN_BUFFER1_RESULT.Value == 1 ? "OK" : "NG";
            }
            else if (idx == 1)
            {
                Exist = Global.Device.NGBUFFER.IN_BUFFER2_EXISTS.Value == 1 ? "V" : "";
                ID = Global.Device.NGBUFFER.IN_BUFFER2_ID.ID;
                Result = Global.Device.NGBUFFER.IN_BUFFER2_RESULT.Value == 1 ? "OK" : "NG";
            }
            else if (idx == 2)
            {
                Exist = Global.Device.NGBUFFER.IN_BUFFER3_EXISTS.Value == 1 ? "V" : "";
                ID = Global.Device.NGBUFFER.IN_BUFFER3_ID.ID;
                Result = Global.Device.NGBUFFER.IN_BUFFER3_RESULT.Value == 1 ? "OK" : "NG";
            }
            else if (idx == 3)
            {
                Exist = Global.Device.NGBUFFER.IN_BUFFER4_EXISTS.Value == 1 ? "V" : "";
                ID = Global.Device.NGBUFFER.IN_BUFFER4_ID.ID;
                Result = Global.Device.NGBUFFER.IN_BUFFER4_RESULT.Value == 1 ? "OK" : "NG";
            }
            else if (idx == 4)
            {
                Exist = Global.Device.NGBUFFER.IN_BUFFER5_EXISTS.Value == 1 ? "V" : "";
                ID = Global.Device.NGBUFFER.IN_BUFFER5_ID.ID;
                Result = Global.Device.NGBUFFER.IN_BUFFER5_RESULT.Value == 1 ? "OK" : "NG";
            }
            else if (idx == 5)
            {
                Exist = Global.Device.NGBUFFER.IN_BUFFER6_EXISTS.Value == 1 ? "V" : "";
                ID = Global.Device.NGBUFFER.IN_BUFFER6_ID.ID;
                Result = Global.Device.NGBUFFER.IN_BUFFER6_RESULT.Value == 1 ? "OK" : "NG";
            }
            else if (idx == 6)
            {
                Exist = Global.Device.NGBUFFER.IN_BUFFER7_EXISTS.Value == 1 ? "V" : "";
                ID = Global.Device.NGBUFFER.IN_BUFFER7_ID.ID;
                Result = Global.Device.NGBUFFER.IN_BUFFER7_RESULT.Value == 1 ? "OK" : "NG";
            }
            else if (idx == 7)
            {
                Exist = Global.Device.NGBUFFER.IN_BUFFER8_EXISTS.Value == 1 ? "V" : "";
                ID = Global.Device.NGBUFFER.IN_BUFFER8_ID.ID;
                Result = Global.Device.NGBUFFER.IN_BUFFER8_RESULT.Value == 1 ? "OK" : "NG";
            }
            else if (idx == 8)
            {
                Exist = Global.Device.NGBUFFER.IN_BUFFER9_EXISTS.Value == 1 ? "V" : "";
                ID = Global.Device.NGBUFFER.IN_BUFFER9_ID.ID;
                Result = Global.Device.NGBUFFER.IN_BUFFER9_RESULT.Value == 1 ? "OK" : "NG";
            }
            else if (idx == 9)
            {
                Exist = Global.Device.NGBUFFER.IN_BUFFER10_EXISTS.Value == 1 ? "V" : "";
                ID = Global.Device.NGBUFFER.IN_BUFFER10_ID.ID;
                Result = Global.Device.NGBUFFER.IN_BUFFER10_RESULT.Value == 1 ? "OK" : "NG";
            }
            else if (idx == 10)
            {
                Exist = Global.Device.NGBUFFER.IN_BUFFER11_EXISTS.Value == 1 ? "V" : "";
                ID = Global.Device.NGBUFFER.IN_BUFFER11_ID.ID;
                Result = Global.Device.NGBUFFER.IN_BUFFER11_RESULT.Value == 1 ? "OK" : "NG";
            }
            else if (idx == 11)
            {
                Exist = Global.Device.NGBUFFER.IN_BUFFER12_EXISTS.Value == 1 ? "V" : "";
                ID = Global.Device.NGBUFFER.IN_BUFFER12_ID.ID;
                Result = Global.Device.NGBUFFER.IN_BUFFER12_RESULT.Value == 1 ? "OK" : "NG";
            }

            return (Exist, ID, Result);
        }
        private void timerStatus_Tick(object sender, EventArgs e)
        {



            if (Global.Instance.Device.NGBUFFER != null)
            {
                gridBuffer.Rows.Clear();

                if (Global.Instance.Device.NGBUFFER.IsOpen)
                {
                    string strBufferQR = Global.Instance.Device.NGBUFFER.GetQRTitle();
                    if (strBufferQR.Length > 0)
                        lb_Buffer.Text = $"Buffer_Monitor , QR_Header = [{strBufferQR}]";
                    else
                        lb_Buffer.Text = $"Buffer_Monitor";

                    for (int i = 0; i < 12; i++)
                    {
                        (string exist, string id, string result) result = GetSignal_Mewtoxcol(i);

                        gridBuffer.Rows.Add(new string[] { $"{(i + 1).ToString()}", result.exist, result.id, result.result });
                    }

                    for (int i = 0; i < gridBuffer.Rows.Count; i++)
                    {
                        if (gridBuffer[3, i].Value.ToString() == "OK" && gridBuffer[1, i].Value.ToString() == "V")
                        {
                            gridBuffer.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                            gridBuffer.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Green;
                        }
                        else if (gridBuffer[3, i].Value.ToString() == "NG" && gridBuffer[1, i].Value.ToString() == "V" && gridBuffer[2, i].Value.ToString() != "")
                        {
                            gridBuffer.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                            gridBuffer.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Orange;
                            if (Global.Instance.SetRMS.dicBUFFER_ID_Done.ContainsKey(i + 1))
                            {
                                if (Global.Instance.SetRMS.dicBUFFER_ID_Done[i + 1].Equals(gridBuffer[2, i].Value.ToString()))
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
                    }
                    //gridBuffer.Columns[0].HeaderText = "TEST";
                    gridBuffer.Refresh();
                }
            }
            else
            {
                lb_Buffer.Text = $"Buffer_Monitor";
            }

            if (Global.Instance.Device.Cameras.Count > 0)
            {
                if (Global.Instance.Device.Cameras[DEFINE.CAM1].ViewModeCross)
                {
                    if (cogDisplay_Array2.Image == null) return;
                    CogLineSegment Hori = new CogLineSegment();
                    Hori.Color = CogColorConstants.Yellow;
                    Hori.StartX = 0;
                    Hori.StartY = cogDisplay_Array2.Image.Height / 2;
                    Hori.EndX = cogDisplay_Array2.Image.Width;
                    Hori.EndY = cogDisplay_Array2.Image.Height / 2;

                    CogLineSegment Verti = new CogLineSegment();
                    Verti.Color = CogColorConstants.Yellow;
                    Verti.StartX = cogDisplay_Array2.Image.Width / 2;
                    Verti.StartY = 0;
                    Verti.EndX = cogDisplay_Array2.Image.Width / 2;
                    Verti.EndY = cogDisplay_Array2.Image.Height;

                    cogDisplay_Array2.InteractiveGraphics.Add(Hori, "Hori", false);
                    cogDisplay_Array2.InteractiveGraphics.Add(Verti, "Verti", false);
                }
                else
                {
                    //cogDisplay_Cam1.InteractiveGraphics.Clear();
                }
            }
        }

        private void timerMode_Tick(object sender, EventArgs e)
        {
            if (Global.Instance.Mode.UseRms == false)
            {
                lbRmsNonUse.Visible = true;
                lbRmsNonUse.Size = gridBuffer.Size;
                gridBuffer.Visible = false;
            }
            else
            {
                lbRmsNonUse.Visible = false;
                gridBuffer.Visible = true;
            }

            // 하드 상태값 모두 Not Use일 경우..
            if (Global.m_DriverC.DriverUse || Global.m_DriverD.DriverUse && Global.m_DriverE.DriverUse)
            {
                //pnl_DriverStatus.Visible = true;               
            }
            else
            {
                //pnl_DriverStatus.Visible = false;
            }
        }


        private void gridBuffer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (gridBuffer.Rows.Count == 0) return;

                int nRowIndex = e.RowIndex; //gridBuffer.SelectedRows[0].Index;

                if (gridBuffer[1, nRowIndex].Value.ToString() != "V") return;
                string str_BufferID = gridBuffer[0, nRowIndex].Value.ToString();
                string strQrcodes = gridBuffer[2, nRowIndex].Value.ToString();

                if (Global.Instance.FrmViewer == null || !Global.Instance.FrmViewer.Created)
                {
                    Global.Instance.FrmViewer = new FormMenu_Viewer(str_BufferID, strQrcodes, nRowIndex);
                }
                Global.Instance.Data.Buffer_ID = str_BufferID;
                Global.Instance.FrmViewer.BringToFront();
                Global.Instance.FrmViewer.Owner = this;
                Global.Instance.FrmViewer.Show();

                //List<string> NgBufferIds = new List<string>();
                //for (int i = 0; i < IGlobal.Instance.Device.NGBUFFER.GetBufferCount(); i++)
                //{
                //    string ids = IGlobal.Instance.Device.NGBUFFER.GetID(i);

                //    if (ids.Length > 0)
                //    {
                //        string[] strParse = ids.Split('/');
                //        QRParser qrMain = new QRParser(strParse[0], true);
                //        NgBufferIds.Add(qrMain.GetQR());
                //        for (int j = 1; j < strParse.Length; j++)
                //        {
                //            QRParser qrAdd = new QRParser(qrMain.GetQRTitle() + strParse[j], true);
                //            NgBufferIds.Add(qrAdd.GetQR());
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }


        Stopwatch sw = Stopwatch.StartNew();
        private void btnManualInsp_Click(object sender, EventArgs e)
        {
            sw.Start();
            Global.SeqVision.ManualInsp = CSeqVision.ManualType.GRAB_INSP;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string strSource, strTarget;//, PbaPath, RcpPath;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                strSource = fbd.SelectedPath;
                strTarget = strSource + "_converted";
                UpdateRecipeNLiberary(strSource, strTarget);

                // Grba Copy - 임시
                //List<Tuple<string,int,DateTime>> toGrabFolder =  CUtil.GetFolderInfos(strSource);
                //for (int i = 0; i < toGrabFolder.Count; i++)
                //{
                //    string target = toGrabFolder[i].Item1 + "\\Grab.xml";
                //    System.IO.File.Copy("d:\\Grab.xml", target, true);
                //}
            }
        }

        private void UpdateRecipeNLiberary(string source, string Target)
        {
            string PbaPath = source + "\\PBA_LIBRARY";
            string RcpPath = source + "\\RECIPE";
            string configPath = source + "\\CONFIG";

            string PbaWPath = Target + "\\PBA_LIBRARY";
            string rcpWPath = Target + "\\RECIPE";
            string configWPath = Target + "\\CONFIG";

            // Create the destination directory
            Directory.CreateDirectory(Target);
            // Copy PBA Directory
            IF_Util.convertFolderNFiles(PbaPath, PbaWPath, true, 0);
            // Copy Recipe Direcoory
            IF_Util.convertFolderNFiles(RcpPath, rcpWPath, true, 1);
            // Config Folder 복사
            IF_Util.copyFolder(configPath, configWPath, true, true);

            List<Tuple<string, DateTime>> rcpJobs = IF_Util.GetFileList2(RcpPath, "Jobs.xml");
            List<Tuple<string, DateTime>> rcpParams = IF_Util.GetFileList2(RcpPath, "Parameter.xml");

            // PBA 중복 방지
            List<String> pbaWrites = new List<String>();
            // Recipe 처리
            //string strMsg = "";
            for (int i = 0; i < rcpParams.Count; i++)
            {
                //Label1:
                // Recipe 파일 읽기
                if (!File.Exists(rcpParams[i].Item1))
                {
                    MessageBox.Show($"[{rcpParams[i].Item1}] RecipeParamFile Read Text Error");
                    continue;
                }
                string rcpParam = System.IO.File.ReadAllText(rcpParams[i].Item1);

                string pbaName = (IF_Util.GetXMlItem(ref rcpParam, "PbaCode", true, true));
                string rcpJobPath = IF_Util.GetPath(rcpParams[i].Item1) + "\\JOBS\\Jobs.xml";
                string rcpNameOnly = IF_Util.GetPathName(IF_Util.GetPath(rcpParams[i].Item1));

                if (!File.Exists(rcpJobPath))
                {
                    MessageBox.Show($"[{rcpJobPath}] RecipeJob Read Text Error");
                    continue;
                }
                string rcpJob = System.IO.File.ReadAllText(rcpJobPath);
                int ArrayCount = (IF_Util.GetXMlItem(ref rcpJob, "ArrayCount", true, true)).ToDbInt();
                int nDarkExposure = (IF_Util.GetXMlItem(ref rcpJob, "Exposure_DarkGrab", true, true)).ToDbInt();
                int nLightExposure = (IF_Util.GetXMlItem(ref rcpJob, "Exposure_LightGrab", true, true)).ToDbInt();
                string pbaFile = $"{PbaPath}\\{pbaName}\\jobs.xml";
                if (!File.Exists(pbaFile))
                {
                    string strDisp = $"{rcpParams[i].Item1}\n{rcpParam}\n\n {pbaFile} is Not";
                    MessageBox.Show(strDisp);
                    continue;
                }
                string pbajob = System.IO.File.ReadAllText(pbaFile);
                List<string> names = IF_Util.GetXmlGroupes(ref pbajob, "Name", true);
                pbajob = System.IO.File.ReadAllText(pbaFile);
                List<string> enables = IF_Util.GetXmlGroupes(ref pbajob, "Enable", true);
                if (enables.Count <= 0)
                    enables = IF_Util.GetXmlGroupes(ref pbajob, "Enabled", true);
                pbajob = System.IO.File.ReadAllText(pbaFile);
                List<string> IsDarkGrabs = IF_Util.GetXmlGroupes(ref pbajob, "IsDarkGrab", true);

                // PBA파일 수정
                pbajob = System.IO.File.ReadAllText(pbaFile);
                string pbaAfter = IF_Util.InsertFindAfterLine(pbajob, "<MasterCount>", "<SamplingCount>1</SamplingCount>");
                pbaAfter = IF_Util.InsertFindAfterLine(pbaAfter, "<Name>", "<PartName>-</PartName>");
                int nGrabIndex = 0;
                if (nDarkExposure == 10000)
                    nGrabIndex = 0;
                else if (nDarkExposure == 50000)
                    nGrabIndex = 1;
                else if (nDarkExposure == 12000)
                    nGrabIndex = 2;
                else if (nDarkExposure == 15000)
                    nGrabIndex = 3;
                else if (nDarkExposure == 20000)
                    nGrabIndex = 4;
                string strReplace = $"<GrabIndex>{nGrabIndex}</GrabIndex>";
                pbaAfter = IF_Util.ReplaceLine(pbaAfter, "<IsDarkGrab>true</IsDarkGrab>", strReplace);

                nGrabIndex = 1;
                if (nLightExposure == 10000)
                    nGrabIndex = 0;
                else if (nLightExposure == 5000)
                    nGrabIndex = 1;
                else if (nLightExposure == 12000)
                    nGrabIndex = 2;
                else if (nLightExposure == 15000)
                    nGrabIndex = 3;
                else if (nLightExposure == 20000)
                    nGrabIndex = 4;
                strReplace = $"<GrabIndex>{nGrabIndex}</GrabIndex>";
                pbaAfter = IF_Util.ReplaceLine(pbaAfter, "<IsDarkGrab>false</IsDarkGrab>", strReplace);
                pbaAfter = IF_Util.ReplaceLine(pbaAfter, "<Exposure_DarkGrab>", "");
                pbaAfter = IF_Util.ReplaceLine(pbaAfter, "<Exposure_LightGrab>", "");
                // PBA파일 쓰기
                for (int j = 0; j < ArrayCount; j++)
                {
                    string pbaWFile = PbaWPath + "\\" + pbaName + $"\\jobs{j}.xml";

                    //if (!File.Exists(pbaWFile))
                    //{
                    //    CLogger.Exception($"Write Text Error", pbaWFile);
                    //    return;
                    //}
                    //System.IO.File.Copy(gFile.FullName, targetFilePath, true);
                    System.IO.File.WriteAllText(pbaWFile, pbaAfter);
                }
                // Grab파일 쓰기
                string targetGrab = PbaWPath + "\\" + pbaName + "\\Grab.xml";
                //if (!File.Exists(targetGrab))
                //{
                //    CLogger.Exception($"copy Targer Error", targetGrab);
                //    return;
                //}
                System.IO.File.Copy("d:\\Grab.xml", targetGrab, true);

                // Recipe파일 수정

                // Recipe 파일 읽기
                string rcpReLoad = System.IO.File.ReadAllText(rcpJobPath);
                // Recipe 파일 수정
                string rcpAfter = IF_Util.ReplaceLine(rcpReLoad, "<Exposure_DarkGrab>", "");
                rcpAfter = IF_Util.ReplaceLine(rcpAfter, "<Exposure_LightGrab>", "");

                //  <Jobs> 시작에서 </Jobs> 까지는 <Jobs />로 변경하고 names 등록은 보류하자.(<jobs>이전의 공백도 제거하자
                rcpAfter = IF_Util.ReplaceBeetweenItem(rcpAfter, "<Jobs>", "</Jobs>", "<Jobs />");

                // 이전 names를 지운다. - 일단 보류
                /* rcpAfter = CUtil.ReplaceLine(rcpAfter, "<EnabledJobs_Library>", "");
                    rcpAfter = CUtil.ReplaceLine(rcpAfter, "</EnabledJobs_Library>", "");
                    rcpAfter = CUtil.ReplaceLine(rcpAfter, "<string>", "");
                    // names를 등록 한다. - 일단 보류
                    rcpAfter = CUtil.InsertFindAfterLine(rcpAfter, "<Jobs />", "<EnabledJobs_Library>");
                    rcpAfter = CUtil.InsertFindAfterLine(rcpAfter, "<EnabledJobs_Library>", "</EnabledJobs_Library>");

                    if (names.Count > 0)
                    {
                        string inStr = $"<string>{names[0]}</string>";
                        rcpAfter = CUtil.InsertFindAfterLine(rcpAfter, "<EnabledJobs_Library>", inStr);
                        for (int j = 1; j < names.Count; j++)
                        {
                            inStr = $"<string>{names[j]}</string>";
                            string findStr = $"<string>{names[j-1]}</string>";
                            rcpAfter = CUtil.InsertFindAfterLine(rcpAfter, findStr, inStr);
                        }
                    }*/

                // Recipe 파일 쓰기
                string rcpWFile = rcpWPath + "\\" + rcpNameOnly + "\\JOBS\\jobs1.xml";
                System.IO.File.WriteAllText(rcpWFile, rcpAfter);

                // ArrayCount 처리 - vpp 복사 , jobs복사 , Grab.xml 생성
                string pbaSubPath = PbaPath + "\\" + pbaName;
                string pbaSubWPath = PbaWPath + "\\" + pbaName;

                //List<Tuple<string, DateTime>> pbaVpps = CUtil.GetFileList(pbaSubPath, "vpp");
                //for (int j = 0; j < pbaVpps.Count; j++)
                //{
                //    // 파일이름을 0번영역으로 수정한다.
                //    // ArrayCount 에 따라 복사를 진행한다.
                //    // Recipe폴더에 파일을 작성한다.
                //    string targetFilePath = pbaSubWPath + $"\\{i}_" + pbaVpps[j];
                //    File.CopyTo(targetFilePath);
                //}

                var dir = new DirectoryInfo(pbaSubPath);
                // Get the files in the source directory and copy to the destination directory
                foreach (FileInfo gFile in dir.GetFiles())
                {
                    string extension = gFile.Extension.ToLower();
                    if (gFile.Extension.ToLower().CompareTo(".vpp") == 0)
                    {
                        //string targetFilePath = Path.Combine(destinationDir, File.Name);
                        for (int j = 1; j < ArrayCount; j++)
                        {
                            string targetFilePath = pbaSubWPath + $"\\{j}_" + gFile.Name;

                            //if (!File.Exists(targetFilePath))
                            //{
                            //    CLogger.Exception($"copy[VPP{j}]", targetFilePath);
                            //    return;
                            //}
                            //System.IO.File.Copy(gFile.FullName, targetFilePath, true);
                            gFile.CopyTo(targetFilePath, true);
                        }
                    }
                    //else if (gFile.Extension.ToLower().CompareTo(".xml") == 0)
                    //{
                    //    //string targetFilePath = Path.Combine(destinationDir, File.Name);
                    //    for (int j = 1; j < ArrayCount; j++)
                    //    {
                    //        string targetFilePath = pbaSubWPath + $"\\" + Path.ChangeExtension(gFile.Name, null) + $"{j + 1}.xml";
                    //        if (!File.Exists(targetFilePath))
                    //        {
                    //            CLogger.Exception($"copyXml{j}]", targetFilePath);
                    //            return;
                    //        }
                    //        //System.IO.File.Copy(gFile.FullName, targetFilePath, true);
                    //        gFile.CopyTo(targetFilePath, true);

                    //    }
                    //}
                }

                //위의 정보로 Recipe 및 PBA_LIBRARY를 수정한다.
                // Recipe - EnableList, ArrayCount 기록
                // PBALibrary - isDarkGrab, 이외는 파일비교한다.

                // Dark, Bright Value를 얻는다.
                // ArrayCount Value를 얻는다.
                // PBA 이름을 얻는다.
                // PBA 파일을 연다
                // 파일이나 파라메터의 리스트 및 검사여부를 구한다.
                // GrabIndex여부로 수정여부를 결정한다.(파일존재 유무도 됨)
                // 수정여부 시 수정한다.
                // Recipe에 리스트의 내용들을 기록한다. - 이거 무시
            }

            IF_Util.CleanConvertedFolder(PbaWPath, 0);        // PBA폴더 정리
            IF_Util.CleanConvertedFolder(rcpWPath, 1);        // Recipe 폴더 정리

            MessageBox.Show("Update Completed !!!");
        }

        private void btn_JUDGE_OK_Click(object sender, EventArgs e)
        {
            CLogger.Add(LOG.SEQ, $"SEQ USER JUDGE ==> OK");
            Global.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, true);
            Global.Instance.Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);

            //IGlobal.Instance.Device.DIO_BD.On("RESULT_OK");
            //IGlobal.Instance.Device.DIO_BD.Off("RESULT_NG");
        }

        object bufferLock = new object();
        private void tmr_Disp_Tick(object sender, EventArgs e)
        {
            // Force Judg 설정 상태 표시
            // 강제 판정 사용 유무..
            if (Global.Instance.Mode.isForceJudge)
            {
                lbl_ForceJudgDisp.BackColor = Color.Green;

                // OK
                if (Global.Instance.Mode.AutoJudge) lbl_ForceJudgDisp.Text = "Force Judg : OK";
                else lbl_ForceJudgDisp.Text = "Force Judg : NG";
            }
            else
            {
                lbl_ForceJudgDisp.BackColor = Color.DimGray;
                lbl_ForceJudgDisp.Text = "Not force Judg";
            }

            HW_DATA_DISP();

            try
            {
                if (Global.SeqVision != null)
                {
                    gridDebug.Rows.Clear();

                    lock (bufferLock)
                    {
                        for (int i = 0; i < Global.SeqVision.NgBuffer.Count; i++)
                        {
                            gridDebug.Rows.Add(new string[] { Global.SeqVision.NgBuffer[i].Item1.ToString("yy/MM/dd HH:mm:ss"), Global.SeqVision.NgBuffer[i].Item2 });
                        }

                        if (Global.SeqVision.NgBuffer.Count > 0)
                        {
                            gridDebug.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                        }
                        else
                        {
                            gridDebug.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                        }
                    }


                }
            }
            catch
            {

            }
        }

        Cognex.VisionPro.CogImage24PlanarColor m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor();
        Cognex.VisionPro.CogImage8Grey m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey();

        private int i_cnt = 0;
        private void tmr_ChkTrainImage_Tick(object sender, EventArgs e)
        {
            //bool bol_ChkTrainImage = Global.Instance.System.Recipe.bol_ChkTrainImage;

            //if (!bol_ChkTrainImage)
            //{
            //    List<bool> ArrayResults;
            //    Bitmap[] _imagesResult;
            //    ArrayResults = Inspec_Run(m_imgSource_Color, out _imagesResult, Global.Instance.Mode.InspectProcess, false, true);

            //    tmr_ChkTrainImage.Enabled = false;
            //    // 프로그레스 동작 종료
            //    Global.Instance.OnEnd_Progress();

            //    if (i_cnt == 0) cogDisplay_Array1.Image = new Cognex.VisionPro.CogImage24PlanarColor(_imagesResult[0]);
            //    else if (i_cnt == 1) cogDisplay_Array2.Image = new Cognex.VisionPro.CogImage24PlanarColor(_imagesResult[0]);

            //    i_cnt++;
            //}
        }

        public bool ImageTest(string strRecipeName)
        {
            try
            {
                if (strRecipeName != "")
                {
                    string strPrevRecipe = strRecipeName;

                    Global.Instance.Recent.LastModel = strRecipeName;
                    Global.Instance.System.Recipe.Name = strRecipeName;

                    Global.Notice = "Model Loading..";
                    // 해당 모델의 라이브러리 잡 리드..
                    // 레시피 데이터 가져올때 task로 가동하여서 별도 정지된 현상 없애기위함..
                    // 백그라운드의 별도 TASK쓰레드 형태로 가동되므로 폼을 건드릴때는 반드시 인보크 처리 필요함..
                    Global.Instance.System.Recipe.LoadTools();
                    CLogger.Add(LOG.NORMAL, $"[Model : {Global.Instance.System.Recipe.Name}]LoadTools");

                    //IGlobal.Instance.System.Recipe.LoadConfig();
                    //IGlobal.Instance.System.Recipe.SettingJob();
                    //Set_Invoke_Form(IGlobal.Instance.FrmVision);

                    CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                return false;
            }
        }

        public static bool Inspection_ICRead(Graphics g, CJob job, CogImage8Grey images8_board, int nImageIndex, System.Drawing.Pen penSearchRegion, System.Drawing.Pen penPatternRegion_OK, int nJobIndex, bool bResult_Job, System.Drawing.Font font, System.Drawing.Font font_NG, SolidBrush brush_OK, SolidBrush brush_NG, int nArrayIndex)
        {
            CCogTool_PMAlign PMAlign = job.Tool;
            PMAlign.Tool.InputImage = images8_board;
            PMAlign.Tool.Run();

            CogPMAlignResult result_JopIcLead = null;

            g.DrawRectangle(penSearchRegion, CVisionCognex.CogRectToRectangle((CogRectangle)PMAlign.Tool.SearchRegion));

            if (PMAlign.Tool.Results != null)
            {
                for (int j = 0; j < PMAlign.Tool.Results.Count; j++)
                {
                    result_JopIcLead = PMAlign.Tool.Results[j];
                    g.DrawRectangle(penPatternRegion_OK, CVisionCognex.PatternToRect(PMAlign.Tool, result_JopIcLead));
                }
            }

            if (PMAlign.Tool.Results.Count == job.MasterCount)
            {
                bResult_Job = true;
                DrawStingAdjust($"[OK] {Global.Instance.System.Recipe.JobManager[nArrayIndex].Jobs[nJobIndex].Name} ({PMAlign.Tool.Results.Count}/{job.MasterCount}) ", font, brush_OK, job.SearchRegion.Location, g, 0);
            }
            else
            {
                bResult_Job = false;
                DrawStingAdjust($"[NG] {Global.Instance.System.Recipe.JobManager[nArrayIndex].Jobs[nJobIndex].Name} ({PMAlign.Tool.Results.Count}/{job.MasterCount}) ", font_NG, brush_NG, job.SearchRegion.Location, g, 0);
            }
            return bResult_Job;
        }
        public static bool Inspection_PatternMatching(Graphics g, CJob job, CogImage8Grey images8_board, int nImageIndex, CogImage24PlanarColor images24_board, bool bResult_Job, int nArrayIndex, int nJobIndex, bool bEnabledJob, bool bCalcCenter)
        {
            //// 임시로 패턴은 CA_ConvertGray, CC_GRAY로 Fix
            job.dRate = 0.0D;
            CogPMAlignResult result_Pattern = null;
            job.nPatternIndex = 0;

            for (int nPatternIndex = 0; nPatternIndex < 5; nPatternIndex++)
            {
                double dToolValue = 0.0;
                CCogTool_PMAlign PMAlign = job.GetTool(nPatternIndex);

                // 여기 이미지 가공 추가
                // 여기 이미지 전처리 추가
                if (job.CMethod == CJob.ColorMethod.CA_ConvertGray && job.CCoordinate == CJob.ColorCoordinate.CC_GRAY)
                {
                    PMAlign.Tool.InputImage = images8_board;
                }
                else
                {
                    Mat inImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(images24_board.ToBitmap()).Clone();
                    Bitmap imgIn = CVisionTools.GetPatterernImage(false, ref job, inImg);
                    CogImage8Grey cogInImg = new Cognex.VisionPro.CogImage8Grey(imgIn);
                    PMAlign.Tool.InputImage = cogInImg;
                }

                if (PMAlign.Tool.Pattern.Trained == false)
                    continue;

                PMAlign.Tool.Run();

                if (job.Judge_NaisNg && (PMAlign.Tool.Results == null || PMAlign.Tool.Results.Count == 0))
                {
                    //CLogger.Add(LOG_TYPE.ALARM, $"{job.Name} Pattern abNormal !!!!");
                    bResult_Job = false;
                    continue;
                }
                else
                {
                    CogPMAlignResult result_Best = CVisionCognex.GetBestResult_PMAlign(PMAlign.Tool);

                    if (result_Best == null)
                        dToolValue = 0;
                    else
                        dToolValue = result_Best.Score;
                    if (dToolValue > job.dRate)
                    {
                        job.dRate = dToolValue;
                        job.nPatternIndex = nPatternIndex;
                        result_Pattern = result_Best;
                    }

                    //NOT OK 는 패턴이 발견되면 NG
                    if (job.Judge_NaisNg == false)
                    {
                        if (job.MinScore < job.dRate)
                        {
                            bResult_Job = false;
                        }
                        else
                        {
                            bResult_Job = true;
                        }

                        break;
                    }
                    //NOT OK 가 아닐 때에는 패턴이 발견되고 Min Score 보다 높아야 OK
                    else
                    {
                        if (result_Best == null)
                        {
                            bResult_Job = false;
                        }
                        else
                        {
                            if (job.dRate > job.MinScore)
                            {
                                if (bEnabledJob == false)
                                {
                                    bResult_Job = false;
                                    break;
                                }
                                else
                                {
                                    bResult_Job = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (!chkPattern(job))
            {
                //CUtil.ShowMessageBox("Pattenr is None", $"Board-{nArrayIndex} {job.Name} Pattern is None !!!!", FormPopup_MessageBox.MESSAGEBOX_TYPE.OK);
                CLogger.Add(LOG.ALARM, $"Board-{nArrayIndex} {job.Name} Pattern is None !!!!");
                job.isPatternNone = true;
                bResult_Job = false;
            }

            if (job.Judge_NaisNg)
            {
                if (bCalcCenter)
                {
                    job.MasterPosition[nArrayIndex] = new Point2d(result_Pattern.GetPose().TranslationX, result_Pattern.GetPose().TranslationY);
                }

                if (job.MinScore > job.dRate)
                {
                    if (bEnabledJob == false)
                    {
                        bResult_Job = true;
                    }
                    else
                    {
                        bResult_Job = false;
                    }
                }

                if (bCalcCenter == false)
                {
                    g.DrawLine(Pens.Yellow, (int)job.MasterPosition[nArrayIndex].X - 5, (int)job.MasterPosition[nArrayIndex].Y, (int)job.MasterPosition[nArrayIndex].X + 10, (int)job.MasterPosition[nArrayIndex].Y);
                    g.DrawLine(Pens.Yellow, (int)job.MasterPosition[nArrayIndex].X, (int)job.MasterPosition[nArrayIndex].Y - 5, (int)job.MasterPosition[nArrayIndex].X, (int)job.MasterPosition[nArrayIndex].Y + 10);
                }
            }

            if (bResult_Job)
                return true;
            else
                return false;
        }
        private void HW_DATA_DISP()
        {
            // 현재 PC의 하드웨어 상태 표시...
            processBar_CPU.Value = Global.m_CPU;
            processBar_RAM.Value = Global.m_RAM;
            processBar_DiskC.Value = Global.m_DriverC.Percent;
            processBar_DiskD.Value = Global.m_DriverD.Percent;
            processBar_DiskE.Value = Global.m_DriverE.Percent;

            // 하드웨어의 상태조건 색깔 표시..
            // 90%이상일 경우...빨간색...
            if (Global.m_CPU > 90) processBar_CPU.RectColor = Color.Red;
            else processBar_CPU.RectColor = Color.FromArgb(68, 77, 86);

            if (Global.m_RAM > 90) processBar_RAM.RectColor = Color.Red;
            else processBar_RAM.RectColor = Color.FromArgb(68, 77, 86);

            if (Global.m_DriverC.Percent > 90) processBar_DiskC.RectColor = Color.Red;
            else processBar_DiskC.RectColor = Color.FromArgb(68, 77, 86);

            if (Global.m_DriverD.Percent > 90) processBar_DiskD.RectColor = Color.Red;
            else processBar_DiskD.RectColor = Color.FromArgb(68, 77, 86);

            if (Global.m_DriverE.Percent > 90) processBar_DiskE.RectColor = Color.Red;
            else processBar_DiskE.RectColor = Color.FromArgb(68, 77, 86);
        }

        private void chkAutoScroll_CheckedChanged(object sender, EventArgs e)
        {
            logViewList.AutoScroll = chkAutoScroll.Checked;
        }

        private void btnOpenLogFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start($"{Application.StartupPath}\\log\\{DateTime.Now.Year:0000}\\{DateTime.Now.Month:00}\\{DateTime.Now.Day:00}");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Global.SeqVision.NgBuffer.Clear();
        }
    }
}