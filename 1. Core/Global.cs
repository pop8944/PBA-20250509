using Cognex.VisionPro;
using IFOnnxRuntime;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class Global
    {
        //--------------------------------------------------------------------------------
        // IGlobal 클래스 인스턴스 선언 캡슐화
        //--------------------------------------------------------------------------------
        static readonly object padlock = new object();
        static Global m_Instance = null;
        public static Global Instance
        {
            get
            {
                lock (padlock)
                {
                    return m_Instance;
                }
            }
        }

        public static string EQP_NAME = "IF";

        // 프로그램 절대 경로 지정..
        // 실제 실행 레시피등의 동작 경로 지정..
        //public const string m_MainPJTRoot = "D:\\TEST_EXEPATH";//"C:\\exe_Vision_PBA";D:\\TEST_EXEPATH  //Mian folder
        //public const string m_MainPJTRoot = "C:\\PBA_EXEPATH";//D:\\TEST_EXEPATH  //Mian folder
        public const string m_MainPJTRoot = "C:\\PBA_EXEPATH_TEST";//D:\\TEST_EXEPATH  //Mian folder

        private CSystem m_iSystem = null;

        public CSystem System
        {
            get { return m_iSystem; }
            set { m_iSystem = value; }
        }

        private CSetting m_iSetting = null;
        public CSetting Setting
        {
            get => m_iSetting;
            set => m_iSetting = value;
        }

        private IData m_iData = null;

        public IData Data
        {
            get => m_iData;
            set => m_iData = value;
        }

        private IDevice m_iDevice = null;

        public IDevice Device
        {
            get => m_iDevice;
            set => m_iDevice = value;
        }

        public CLogManager LogManager { get; set; } = new CLogManager();

        #region SEQ
        public CSeqInitialize SeqInitialize = null;
        public CSeqRecipeChange SeqRecipeChage = null;
        public bool bRecipeChangeEnd = false;
        #endregion

        public CParameter Parameter = null;

        //public CSeqAutoInsp SeqAutoInsp = null;
        public CSeqVision SeqVision = null;
        //public static bool SEQ_RunCheck = false;

        public CFileManager m_FileManager = null;

        public CFileManager FileManager
        {
            get
            {
                return m_FileManager;
            }
            set { m_FileManager = value; }
        }


        // 추가 [프로그레스 동작 상태 값 가져감]
        public int m_LoadingProgress = 0;
        public int LoadingProgress_Vlue
        {
            get => m_LoadingProgress; set => m_LoadingProgress = value;
        }

        public bool m_Progessing = false;
        public bool IsProgessing
        {
            get => m_Progessing; set => m_Progessing = value;
        }

        public string SelectedMenu { get; set; } = "";


        //private CSQLite m_sqlite = null;
        public CSQLite DB { get; set; } = null;
        public CMode Mode { get; set; } = null;
        public CRecent Recent { get; set; } = null;
        public MetaData MetaData { get; set; } = null;
        public Setting_RMS SetRMS { get; set; } = null;
        // 해당 사용 폼 모두 생성 관리 진행...
        public FormMenu_MainFrame FrmMain = null;
        public FormPopup_Progress Progress = null;
        public Form_MenuVision FrmVision = null;
        public FormMenu_Sub FrmSub = null;
        public FormMenu_Viewer FrmViewer = null;
        public FormMenu_IO FrmIO = null;
        public FormMenuRecipe FrmRecipe = null;
        public FormMenu_Settings FrmSetting = null;
        public FormPopUp_Settings_Camera FrmSettings_Camera = null;
        public FormPopUp_Alarm FrmAlarm = null; // new FormAlarm("[1]000", "");
        //private FormMenu_Viewer FrmPBAviewer = null;
        public FormMenu_IO_Edit Frm_IO_Edit = null;
        public FormMenu_PbaLibrary Frm_PBA_Library = null;
        public FormPopUp_ImageView2 FrmPopup_View = null;
        public FormMenu_PbaLibrary2 Frm_PBA_Library2 = null;
        // TCP 자동기종변경 테스트 폼
        public FormMenu_ARC_Tester Frm_ARC_Tester = null;
        public static string Notice = "";
        public static bool IsInspecting = false;

        private bool isPass = false;
        public bool isOnGrab = false;
        public EYED eyeD = null;
        public void SetPass(bool pass)
        {
            isPass = pass;
        }

        public bool GetPass()
        {
            return isPass;
        }

        private string strLogPath = "";
        public string LogPath
        {
            get => strLogPath; set => strLogPath = value;
        }

        // 메인에서 그랩하는 5개 이미지를 해당 변수에 관리..
        public Cognex.VisionPro.CogImage24PlanarColor[] ImagesGrab = new Cognex.VisionPro.CogImage24PlanarColor[5]
        {
            new Cognex.VisionPro.CogImage24PlanarColor(),
            new Cognex.VisionPro.CogImage24PlanarColor(),
            new Cognex.VisionPro.CogImage24PlanarColor(),
            new Cognex.VisionPro.CogImage24PlanarColor(),
            new Cognex.VisionPro.CogImage24PlanarColor()
        };

        // Auto 결과 이미지 뿌리기..
        public Bitmap[] ImageResults_array = new Bitmap[4];
        // 메인 체크 쓰레드 런 플래그
        bool nMainSystemCheck = false;
        // 파일 삭제 쓰레드 플래그
        bool nFileDelCheck = false;
        // 최종 결과값 확인 변수 [ true : OK, false : NG ]
        public bool m_TotalResult = true;

        //Board Out 시 원본이미지와 결과이미지
        public Mat[] MasterImage;
        public Mat[] ResultImage;

        // 현재 PC의 시스템 하드웨어 상태 체크
        // 하드 드라이버는 추후 추가될시..해당부분에 변수 추가후 쓰레드 호출에서 값 할당 처리..
        public static int m_CPU = 0;
        public static int m_RAM = 0;
        // 하드 드라이브의 사이즈값 가져오기..
        public struct DRIVER_SIZE
        {
            public bool DriverUse;
            public int Percent;
            public int TotalSize;
            public int FreeSize;
            public int Usage;
        }
        public static DRIVER_SIZE m_DriverC = new DRIVER_SIZE();
        public static DRIVER_SIZE m_DriverD = new DRIVER_SIZE();
        public static DRIVER_SIZE m_DriverE = new DRIVER_SIZE();

        // 파일 삭제 처리 관련 구조체..
        public struct FILE_DELETE_CONTROL
        {
            public string FileDel_Path;
            public bool FileDel_Enabled;
            public int FileDel_Day;
            public int FileDel_Time;
            public int HDD;         // 삭제하기전에..얼마만큼의 용량이상일시..삭제..
        }

        public static FILE_DELETE_CONTROL m_FileDel_C = new FILE_DELETE_CONTROL();
        public static FILE_DELETE_CONTROL m_FileDel_D = new FILE_DELETE_CONTROL();
        public static FILE_DELETE_CONTROL m_FileDel_E = new FILE_DELETE_CONTROL();

        // 파일 삭제 자동 동작 확인...
        public static bool m_FileDel_AutoRun = false;

        // 파일삭제 관련 옵션내용 레지스트리에 기록할 네이밍 정리
        //==================================================================
        // 파일 삭제 쓰레드 동작 런 상태 체크 기록
        public const string Registry_FileDel_Run_Name = "File_Del_Run";
        public const string Registry_FileDel_Run_Key = "Run_Check";

        public const string Registry_FileDel_C_Name = "File_Del_C";
        public const string Registry_FileDel_D_Name = "File_Del_D";
        public const string Registry_FileDel_E_Name = "File_Del_E";
        public const string Registry_FileDel_Path_Key = "Path";
        public const string Registry_FileDel_Day_Key = "Day";
        public const string Registry_FileDel_Time_Key = "Time";
        public const string Registry_FileDel_Enabled_Key = "Enabled";
        public const string Registry_FileDel_HDD_Key = "HDD";
        //=================================================================
        // 이미지 파일 세이브 경로 설정...
        // 저장 레지스트리 기록
        public const string Registry_ImageFileSave_Name = "ImageFile_Save";
        public const string Registry_ImageFileSave_Key = "File_Path";

        public static string m_ImageFileRoot;

        public static bool m_BoardOut;

        // 보드 아웃 데이터 기억 레지스트리..
        public const string Registry_BoardOut_ID_Name = "BoardOut";
        public const string Registry_BoardOut_ID_Key = "ID";
        // 보드 아웃 데이터 기억...
        public static string Buffer_BoardOut_QRCODE;

        // TCP IP, PORT 저장할 레지스트리값
        public const string Registry_ARC_IP_Name = "ARC";
        public const string Registry_ARC_IP_Key = "IP";
        public const string Registry_ARC_PORT_Key = "PORT";
        public const string Registry_ARC_USE_Key = "USE";

        // 해당 ARC IP, PORT 값 기억..
        public static string m_ARC_IP = "0.0.0";
        public static string m_ARC_PORT = "0";
        public static bool m_ARC_USE = true;

        // EQP NAME을 기록함
        public const string Registry_EQP_Name = "EQP";
        public const string Registry_EQPNAME_Key = "Name";
        // 해당 메인 클래스 생성시 모든 필요 클래스 생성 진행..

        public Global()
        {
            m_Instance = this;


            // 초기 폼 생성...
            Progress = new FormPopup_Progress("Waiting...");

            // 결과값...AUTO일때..
            LogPath = IF_Util.InitLogDirectory();
            CLogger.SetPath(LogPath);

            m_iSystem = new CSystem();
            m_iData = new IData();

            //Have to set build platform => x64 (NO AnyCPU !~!!!!!)
            m_iDevice = new IDevice();
            m_iSetting = new CSetting();
            m_FileManager = new CFileManager();

            //SeqInitialize = new CSeqInitialize();
            SeqRecipeChage = new CSeqRecipeChange();

            Parameter = new CParameter();
            SeqVision = new CSeqVision();

            // 폼 생성...
            FrmMain = new FormMenu_MainFrame();
            // 폼 생성...
            FrmVision = new Form_MenuVision();
            FrmSub = new FormMenu_Sub();
            FrmViewer = new FormMenu_Viewer();
            FrmIO = new FormMenu_IO();
            FrmRecipe = new FormMenuRecipe();
            FrmSetting = new FormMenu_Settings();
            FrmSettings_Camera = new FormPopUp_Settings_Camera();
            FrmAlarm = new FormPopUp_Alarm("", "");
            Frm_IO_Edit = new FormMenu_IO_Edit();
            Frm_PBA_Library = new FormMenu_PbaLibrary();
            FrmPopup_View = new FormPopUp_ImageView2();
            Frm_PBA_Library2 = new FormMenu_PbaLibrary2();
            Frm_ARC_Tester = new FormMenu_ARC_Tester(); // TCP ARC 폼 테스트..

            InitCamera();
            InitDB(); //SQLite 추가
        }

        public void Init()
        {
            Mode = new CMode();
            Mode = Mode.LoadConfig();

            Recent = new CRecent();
            Recent = Recent.LoadConfig();

            MetaData = new MetaData();
            MetaData = MetaData.LoadFromCSV();

            Setting.Load();
            m_iDevice.Init();

            // 데이터 이니셜...
            InitRecipe(true);
            // Stage 이미지 관리 초기화
            StageImg_Init();
            // 파일 삭제 내용 로드
            FileDel_Registry_Load();
            // 이미지 세이브 경로 설정...
            ImageFileSave_Registry_Load();
            // 현재 보드 아웃된 ID 가져오기..
            BoardOut_Registry_Load();
            // 현재 사용되는 드라이브
            m_DriverC.DriverUse = Util.GetDriverCheck("C");
            m_DriverD.DriverUse = Util.GetDriverCheck("D");
            m_DriverE.DriverUse = Util.GetDriverCheck("E");

            eyeD = new EYED();
            CognexLicense_Check();
        }

        // 메인의 Stage 이미지 관리
        public void StageImg_Init()
        {
            MasterImage = new Mat[5];           // 그랩 이미지 개수가 5개임..5개 최대..
            ResultImage = new Mat[System.Recipe.ArrayCount];
        }

        // 해당 이벤트 및 동작에 필요한 클래스 생성
        public void start()
        {
            MainSystemCheck_Thread();
        }

        public void Close()
        {
            m_iSystem.REQ_SYSTEM_CLOSE = true;
            nMainSystemCheck = false;
            nFileDelCheck = false;

            if (m_iSystem != null) m_iSystem.Close();
            if (m_iDevice != null) m_iDevice.Close();

            // PLC 추가 예정
            if (FrmSettings_Camera != null) FrmSettings_Camera.Close();

            // 프로그램 종료 처리..
            Application.ExitThread();
            Application.Exit();
            if (Application.MessageLoop) Environment.Exit(0);
            else Environment.Exit(1);
        }

        public void OnStart_Porgess(string str = "Waiting...")
        {
            Global.IsInspecting = true;
            Global.Notice = str;
            if (Progress == null || !Progress.Created)
            {
                Progress = new FormPopup_Progress(str);
            }
            /*if (Global.Instance.FrmVision.Visible == false)*/
            Progress.OnShow_Progress(str);
        }

        public void OnEnd_Progress()
        {
            Global.IsInspecting = false;

            if (Progress.InvokeRequired)
            {
                Progress.Invoke(new MethodInvoker(() =>
                {
                    OnEnd_Progress();
                }));
            }
            else
            {
                IsProgessing = false;
                Progress.Hide();
            }
        }

        // 메인 시스템 체크..
        private void MainSystemCheck_Thread()
        {
            nMainSystemCheck = true;
            // Task 처리를 람다식으로 처리
            Task.Run(async () =>
            {
                while (nMainSystemCheck)
                {
                    await Task.Delay(1);
                    MainSystem_Check();
                }
            });
        }

        private void MainSystem_Check()
        {
            // 현재 PC의 하드웨어 상태 읽기...
            m_CPU = Util.CPU();
            m_RAM = Util.RAM();
            // 하드값 읽어오기...C, D, E
            Util.Driver_Value("C", out m_DriverC.Percent, out m_DriverC.TotalSize, out m_DriverC.FreeSize);
            Util.Driver_Value("D", out m_DriverD.Percent, out m_DriverD.TotalSize, out m_DriverD.FreeSize);
            Util.Driver_Value("E", out m_DriverE.Percent, out m_DriverE.TotalSize, out m_DriverE.FreeSize);

            m_DriverC.Usage = Convert.ToInt32(m_DriverC.TotalSize) - Convert.ToInt32(m_DriverC.FreeSize);
            m_DriverD.Usage = Convert.ToInt32(m_DriverD.TotalSize) - Convert.ToInt32(m_DriverD.FreeSize);
            m_DriverE.Usage = Convert.ToInt32(m_DriverE.TotalSize) - Convert.ToInt32(m_DriverE.FreeSize);
        }

        // 파일 삭제 쓰레드 동작...
        public void FileDelete_Thread()
        {
            nFileDelCheck = true;
            // Task 처리를 람다식으로 처리
            Task.Run(async () =>
            {
                while (nFileDelCheck)
                {
                    await Task.Delay(1);
                    File_Delete();
                }
            });
        }

        // 파일 삭제..
        private void File_Delete()
        {
            // 파일을 삭제할려고 설정될 경우만...
            // 해당 드라이브가 있을 경우에만..
            if (m_DriverC.DriverUse)
            {
                if (m_FileDel_C.FileDel_Enabled)
                {
                    Util.Driver_FileDelete("C", m_FileDel_C.FileDel_Path, m_FileDel_C.FileDel_Time, m_FileDel_C.FileDel_Day, m_FileDel_C.HDD);
                }
            }

            if (m_DriverD.DriverUse)
            {
                if (m_FileDel_D.FileDel_Enabled)
                {
                    Util.Driver_FileDelete("D", m_FileDel_D.FileDel_Path, m_FileDel_D.FileDel_Time, m_FileDel_D.FileDel_Day, m_FileDel_D.HDD);
                }
            }

            if (m_DriverE.DriverUse)
            {
                if (m_FileDel_E.FileDel_Enabled)
                {
                    Util.Driver_FileDelete("E", m_FileDel_E.FileDel_Path, m_FileDel_E.FileDel_Time, m_FileDel_E.FileDel_Day, m_FileDel_E.HDD);
                }
            }
        }

        public void FileDelete_Close()
        {
            nFileDelCheck = false;
        }

        // RMS 결과 프로세싱 처리
        // 결과값 쓰기..
        public bool RMS_PostProcessing()
        {
            Notice = "Inspecting : Judging";
            bool bTotalResult = true;
            string strData = "";
            int nErrorQR = 0;

            QRParser cStandardQR = Data.GetStandardQR();

            for (int i = 0; i < System.Recipe.ArrayCount; i++)
            {
                string strTitle = cStandardQR.GetQRTitle();
                //QRParser qrID = new QRParser(strID);

                //int nindex = strID.IndexOf("DT");
                //if (nindex > 0 && strID.Length >= (nindex + 8))
                //{
                //    strID = strID.Substring(nindex, 8);
                //}

                if (Data.Array_QrCodes[i].IsError()) nErrorQR++;

                // 여기 변경한다.
                //if (i == 0)
                //{
                //    //strData = cStandardQR.GetQRTitle() + Data.Board_QrCode[i].GetSerialNo();
                //    strData = Data.Board_QrCode[i].GetSerialNo();
                //}
                //else
                //{
                //    //strData = strData + "/" + Data.Board_QrCode[i].GetSerialNo();
                //    strData = strData + "/" + Data.Board_QrCode[i].GetSerialNo();
                //}
                if (i == 0)
                {
                    strData = Data.Array_QrCodes[i].GetSerialNo();
                }
                else
                {
                    strData = strData + "/" + Data.Array_QrCodes[i].GetSerialNo();
                }

                //if (ArrayResults[i] == false)
                //{
                //    bTotalResult = false;
                //    Data.CountNG_F++;
                //    Data.CurrentNG++;
                //}
                //else
                //{
                //    Data.CountOK++;
                //    Data.CurrentOK++;
                //}

                //FileManager.IdDataSave(Data.Board_QrCode[i].GetQR(), ArrayResults[i]);
            }

            if (nErrorQR > 0)
            {
                CLogger.Add(LOG.ABNORMAL, "[QR] ReadError");
            }

            double yield = 0;
            if (Data.yield != null) yield = double.Parse(Data.yield);

            //FileManager.CountSave(Data.CountOK, Data.CountNG_T, Data.CountNG_F, yield);
            FileManager.CountSave(Data);

            bool bRecent = false;
            if (!Mode.NGisRecent)
                bRecent = true;
            else
            {
                if (!bTotalResult)
                    bRecent = true;
            }

            if (bRecent)
            {
                CogRecentImage recent = new CogRecentImage();
                recent.Name = strData;
                recent.DateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                for (int i = 0; i < recent.recentImages.Length; i++)
                {
                    if (ImagesGrab[i] != null && ImagesGrab[i].Allocated)
                    {
                        recent.recentImages[i] = new Cognex.VisionPro.CogImage24PlanarColor(ImagesGrab[i]);
                    }
                }

                Data.cogRecentImages.Add(recent);

                if (Data.cogRecentImages.Count > 20)
                    Data.cogRecentImages.RemoveAt(0);
            }

            Device.strRMSQR = Device.NGBUFFER.GetQR().GetQR();
            Device.SaveConfig();

            // 폴란드 버젼에서 해당 비트가 ON되어있는지 체크를 위해 로그 기록..
            if (Global.Instance.Setting.Enviroment.Country == Setting_Enviroment.COUNTRY.POL)
            {
                if (!Mode.isForceJudge) //정상 시퀀스
                {
                    CLogger.Add(LOG.SEQ, $"SEQ isForceJudge ==> false");
                    if (bTotalResult) //OK
                    {
                        CLogger.Add(LOG.SEQ, $"SEQ NORMAL JUDGE ==> OK");
                        CLogger.Add(LOG.COMM, $"SEQ NORMAL JUDGE ==> OK");
                        Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, true);
                        Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);
                        Device.NGBUFFER.Command_PCBID_END_JUDGE(true);
                    }
                    else//NG
                    {
                        CLogger.Add(LOG.SEQ, $"SEQ NORMAL JUDGE ==> NG");
                        CLogger.Add(LOG.COMM, $"SEQ NORMAL JUDGE ==> NG");

                        if (!Global.Instance.Mode.isDebugMode)
                        {
                            Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
                            Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, true);
                            Device.NGBUFFER.Command_PCBID_END_JUDGE(false);
                        }
                        else // 디버그모드 ON이면 NG시 신호 안나가고 멈추고 수정후 재검사
                        {
                            CLogger.Add(LOG.SEQ, $"SEQ NORMAL JUDGE ==> DEBUG");
                            Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
                            Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);
                        }
                    }
                }
                else
                {
                    // 강제 결과 판정...
                    CLogger.Add(LOG.SEQ, $"SEQ isForceJudge ==> true");
                    // 강제 OK판정
                    if (Mode.AutoJudge)
                    {
                        CLogger.Add(LOG.SEQ, $"SEQ AUTO JUDGE ==> OK");
                        Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, true);
                        Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);

                        Device.NGBUFFER.Command_PCBID_END_JUDGE(true);
                    }
                    // 강제 NG판정
                    else
                    {
                        CLogger.Add(LOG.SEQ, $"SEQ AUTO JUDGE ==> NG");
                        Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
                        Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, true);

                        Device.NGBUFFER.Command_PCBID_END_JUDGE(false);
                    }
                }

                Stopwatch sw = Stopwatch.StartNew();
                while (sw.ElapsedMilliseconds < 300000)
                {
                    Thread.Sleep(1);

                    if (Device.NGBUFFER.GetInPutBoard())
                    {
                        CLogger.Add(LOG.SEQ, $"INPUT BOARD ING BIT : ON");
                        break;
                    }
                    else
                    {
                        CLogger.Add(LOG.SEQ, $"INPUT BOARD ING BIT : OFF");
                    }
                }

                Device.NGBUFFER.CommandQueue.Enqueue(("D", "10000", typeof(string), strData));
                CLogger.Add(LOG.COMM, $"QR Send -> NG Buffer : {strData}");
            }
            else
            {
                Device.NGBUFFER.CommandQueue.Enqueue(("D", "9800", typeof(string), strData));
                CLogger.Add(LOG.COMM, $"QR Send -> NG Buffer : {strData}");
                //var r = Device.NGBUFFER.engine.WriteDataAreaRegister("D", 9800, typeof(string), strData);

                //Device.NGBUFFER.SetString(9800, strData);
                //bool tmp = Device.NGBUFFER.Command_PCBID_INPUT(strData); //NG시 PCB 데이터 입력
                Device.strRMSQR = Device.NGBUFFER.GetQR().GetQR();
                Device.SaveConfig();

                Thread.Sleep(1000);

                if (!Mode.isForceJudge) //정상 시퀀스
                {
                    CLogger.Add(LOG.SEQ, $"SEQ isForceJudge ==> false");
                    if (bTotalResult) //OK
                    {
                        CLogger.Add(LOG.SEQ, $"SEQ NORMAL JUDGE ==> OK");
                        CLogger.Add(LOG.COMM, $"SEQ NORMAL JUDGE ==> OK");
                        Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, true);
                        Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);
                        Device.NGBUFFER.Command_PCBID_END_JUDGE(true);
                    }
                    else//NG
                    {
                        CLogger.Add(LOG.SEQ, $"SEQ NORMAL JUDGE ==> NG");
                        CLogger.Add(LOG.COMM, $"SEQ NORMAL JUDGE ==> NG");

                        if (!Mode.isDebugMode)
                        {
                            Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
                            Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, true);
                            Device.NGBUFFER.Command_PCBID_END_JUDGE(false);
                        }
                        else // 디버그모드 ON이면 NG시 신호 안나가고 멈추고 수정후 재검사
                        {
                            CLogger.Add(LOG.SEQ, $"SEQ NORMAL JUDGE ==> DEBUG");
                            Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
                            Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);
                        }
                    }
                }
                else
                {
                    // 강제 결과 판정...
                    CLogger.Add(LOG.SEQ, $"SEQ isForceJudge ==> true");
                    // 강제 OK판정
                    if (Mode.AutoJudge)
                    {
                        CLogger.Add(LOG.SEQ, $"SEQ AUTO JUDGE ==> OK");
                        Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, true);
                        Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, false);

                        Device.NGBUFFER.Command_PCBID_END_JUDGE(true);
                    }
                    // 강제 NG판정
                    else
                    {
                        CLogger.Add(LOG.SEQ, $"SEQ AUTO JUDGE ==> NG");
                        Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_OK, false);
                        Device.DIO_BD.Bit_OnOff(CDIO_BITNAME.RESULT_NG, true);

                        Device.NGBUFFER.Command_PCBID_END_JUDGE(false);
                    }
                }
            }



            return bTotalResult;
        }

        public void InitRecipe(bool bInit = false)
        {
            // 마지막 모델이름을 레시피 이름에 써줌..
            System.Recipe.Name = Recent.LastModel;
            Notice = $"Model Loading ==> {System.Recipe.Name}";
            //IGlobal.Instance.Progress.OnShowProgress();
            CLogger.Add(LOG.NORMAL, $"[CRecipe]Load Start");
            System.Recipe.InitDirectory(System.Recipe.Name);
            CLogger.Add(LOG.NORMAL, $"[CRecipe]Init Directory");
            System.Recipe.LoadTools();
            CLogger.Add(LOG.NORMAL, $"[CRecipe]LoadTools");

            Setting.Load(System.Recipe.Name);

            if (bInit)
            {
                Global.Instance.System.Recipe.Name = Global.Instance.Recent.LastModel;
            }
            else
            {
                // 마지막 라스트 모델 써주기..
                Global.Instance.Recent.LastModel = Global.Instance.System.Recipe.Name;
                Global.Instance.Recent.SaveConfig();
            }
        }

        public bool InitCamera()
        {
            try
            {
                Global.Instance.System.Notice = "Initialize The Init Camera";

                for (int i = 0; i < Global.Instance.Device.Cameras.Count; i++)
                {
                    if (Global.Instance.Device.Cameras[i].IsOpen) Global.Instance.Device.Cameras[i].Close();
                }

                Global.Instance.Device.Cameras.Clear();

                for (int i = 0; i < Global.Instance.Device.CAMERA_COUNT; i++)
                {
                    Camera camera = new Camera(i);
                    Cognex.VisionPro.Display.CogDisplay CogDisplay = new Cognex.VisionPro.Display.CogDisplay();

                    camera.Init(i, Global.Instance.Setting.Enviroment.Camera1);
                    //camera.Display = CogDisplay;
                    //camera.Display.Tag = i;
                    //camera.SetGrabMaxCount(Global.Instance.System.Recipe.GrabManager.Nodes.Length);
                    Global.Instance.Device.Cameras.Add(camera);
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
            return true;
        }

        private bool InitDB()
        {
            try
            {
                string strPathDB_PBA = $"{Global.m_MainPJTRoot}\\DB.sqlite";
                Global.Instance.DB = new CSQLite(strPathDB_PBA);

                if (!File.Exists(strPathDB_PBA))
                {
                    Global.Instance.DB.Create();
                    Global.Instance.DB.CreateTable("HISTORY", new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>("time", "TEXT NOT NULL"),
                        new KeyValuePair<string, string>("model", "TEXT"),
                        new KeyValuePair<string, string>("qrcode", "TEXT"),
                        new KeyValuePair<string, string>("insp_judge", "TEXT"),
                        new KeyValuePair<string, string>("rms_judge", "TEXT"),
                        new KeyValuePair<string, string>("master_img_path", "TEXT"),
                        new KeyValuePair<string, string>("ng_img_path", "TEXT"),
                        new KeyValuePair<string, string>("crop_img_path", "TEXT"),
                        new KeyValuePair<string, string>("master_crop_img_path", "TEXT"),
                        new KeyValuePair<string, string>("ng_part_code", "TEXT"),
                        new KeyValuePair<string, string>("ng_reason", "TEXT"),
                        new KeyValuePair<string, string>("ng_rect", "TEXT"),
                    });
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
            return true;
        }

        // 현재 보드 아웃된 ID이름을 기억하기..
        private void BoardOut_Registry_Load()
        {
            string ret = CRegistry.Registry_Data_Read(Registry_BoardOut_ID_Name, Registry_BoardOut_ID_Key);
            if (ret == null) { ret = ""; }
            Buffer_BoardOut_QRCODE = ret;
        }

        // 현재 이미지 세이브 파일 대표 경로 설정..
        private void ImageFileSave_Registry_Load()
        {
            string run = CRegistry.Registry_Data_Read(Registry_ImageFileSave_Name, Registry_ImageFileSave_Key);

            // 초기값...
            if (run == null) { run = $"E:\\VISION_IMAGE"; }

            m_ImageFileRoot = run;
        }

        // 현재 파일 삭제 관련 옵션 저장되어있는 내용 가져오기...
        private void FileDel_Registry_Load()
        {
            string run = CRegistry.Registry_Data_Read(Registry_FileDel_Run_Name, Registry_FileDel_Run_Key);
            if (run == null) { run = "false"; }
            m_FileDel_AutoRun = bool.Parse(run);

            // C드라이버...
            string path = CRegistry.Registry_Data_Read(Registry_FileDel_C_Name, Registry_FileDel_Path_Key);
            string Day = CRegistry.Registry_Data_Read(Registry_FileDel_C_Name, Registry_FileDel_Day_Key);
            string Time = CRegistry.Registry_Data_Read(Registry_FileDel_C_Name, Registry_FileDel_Time_Key);
            string Enabled = CRegistry.Registry_Data_Read(Registry_FileDel_C_Name, Registry_FileDel_Enabled_Key);
            string HDD = CRegistry.Registry_Data_Read(Registry_FileDel_C_Name, Registry_FileDel_HDD_Key);

            if (path == null) { path = "-"; }
            if (Day == null) { Day = "0"; }
            if (Time == null) { Time = "1"; }
            if (Enabled == null) { Enabled = "false"; }
            if (HDD == null) { HDD = "0"; }

            m_FileDel_C.FileDel_Path = path;
            m_FileDel_C.FileDel_Day = int.Parse(Day);
            m_FileDel_C.FileDel_Time = int.Parse(Time);
            m_FileDel_C.FileDel_Enabled = bool.Parse(Enabled);
            m_FileDel_C.HDD = int.Parse(HDD);

            // D드라이버...
            path = CRegistry.Registry_Data_Read(Registry_FileDel_D_Name, Registry_FileDel_Path_Key);
            Day = CRegistry.Registry_Data_Read(Registry_FileDel_D_Name, Registry_FileDel_Day_Key);
            Time = CRegistry.Registry_Data_Read(Registry_FileDel_D_Name, Registry_FileDel_Time_Key);
            Enabled = CRegistry.Registry_Data_Read(Registry_FileDel_D_Name, Registry_FileDel_Enabled_Key);
            HDD = CRegistry.Registry_Data_Read(Registry_FileDel_D_Name, Registry_FileDel_HDD_Key);

            if (path == null) { path = "-"; }
            if (Day == null) { Day = "0"; }
            if (Time == null) { Time = "1"; }
            if (Enabled == null) { Enabled = "false"; }
            if (HDD == null) { HDD = "0"; }

            m_FileDel_D.FileDel_Path = path;
            m_FileDel_D.FileDel_Day = int.Parse(Day);
            m_FileDel_D.FileDel_Time = int.Parse(Time);
            m_FileDel_D.FileDel_Enabled = bool.Parse(Enabled);
            m_FileDel_D.HDD = int.Parse(HDD);

            // E드라이버...
            path = CRegistry.Registry_Data_Read(Registry_FileDel_E_Name, Registry_FileDel_Path_Key);
            Day = CRegistry.Registry_Data_Read(Registry_FileDel_E_Name, Registry_FileDel_Day_Key);
            Time = CRegistry.Registry_Data_Read(Registry_FileDel_E_Name, Registry_FileDel_Time_Key);
            Enabled = CRegistry.Registry_Data_Read(Registry_FileDel_E_Name, Registry_FileDel_Enabled_Key);
            HDD = CRegistry.Registry_Data_Read(Registry_FileDel_E_Name, Registry_FileDel_HDD_Key);

            if (path == null) { path = "-"; }
            if (Day == null) { Day = "0"; }
            if (Time == null) { Time = "1"; }
            if (Enabled == null) { Enabled = "false"; }
            if (HDD == null) { HDD = "0"; }

            m_FileDel_E.FileDel_Path = path;
            m_FileDel_E.FileDel_Day = int.Parse(Day);
            m_FileDel_E.FileDel_Time = int.Parse(Time);
            m_FileDel_E.FileDel_Enabled = bool.Parse(Enabled);
            m_FileDel_E.HDD = int.Parse(HDD);

            // 런 플래그에서 true일 경우 런시작..
            if (m_FileDel_AutoRun)
            {
                FileDelete_Thread();
            }
        }

        public void EQPNAME_Registry_Load()
        {
            string run = CRegistry.Registry_Data_Read(Registry_EQP_Name, Registry_EQPNAME_Key);

            // 초기값...
            if (run == null) { run = "IF-PBA AOI"; }

            EQP_NAME = run;
        }

        // 현재 EQP NAME 값 저장하기
        public void EQPNAME_Registry_Write(string EQP_NAME)
        {
            CRegistry.Registry_Data_Write(Registry_EQP_Name, Registry_EQPNAME_Key, EQP_NAME.ToString());
        }

        // 현재 자동기종변경 IP, PORT 값 가져오기..
        public void ARC_Registry_Load()
        {
            string run = CRegistry.Registry_Data_Read(Registry_ARC_IP_Name, Registry_ARC_IP_Key);

            // 초기값...
            if (run == null) { run = $"192.168.0.1"; }

            m_ARC_IP = run;

            run = CRegistry.Registry_Data_Read(Registry_ARC_IP_Name, Registry_ARC_PORT_Key);

            // 초기값...
            if (run == null) { run = $"1000"; }

            m_ARC_PORT = run;

            run = CRegistry.Registry_Data_Read(Registry_ARC_IP_Name, Registry_ARC_USE_Key);

            // 초기값...
            if (run == null) { run = $"true"; }

            m_ARC_USE = bool.Parse(run);
        }

        // 현재 자동기종변경 IP, PORT 값 저장하기
        public void ARC_Registry_Write(string ip, string port, bool use)
        {
            CRegistry.Registry_Data_Write(Registry_ARC_IP_Name, Registry_ARC_IP_Key, ip.ToString());
            CRegistry.Registry_Data_Write(Registry_ARC_IP_Name, Registry_ARC_PORT_Key, port.ToString());
            CRegistry.Registry_Data_Write(Registry_ARC_IP_Name, Registry_ARC_USE_Key, use.ToString());
        }

        public void PopupImageView_Show()
        {
            if (Global.Instance.FrmPopup_View == null || !Global.Instance.FrmPopup_View.Created)
            {
                Global.Instance.FrmPopup_View = new FormPopUp_ImageView2();
            }

            Global.Instance.FrmPopup_View.BringToFront();
            Global.Instance.FrmPopup_View.Owner = FrmMain;
            Global.Instance.FrmPopup_View.Show();
        }

        // true : key 없음, false : key 있음
        public static bool m_Vision_CognexLicense_Error;
        public static bool CognexLicense_Check()
        {
            // 코그넥스 라이센스 키 확인
            try
            {
                m_Vision_CognexLicense_Error = CogLicense.CheckForExpiredVisionProLicenses();
            }
            catch
            {
                m_Vision_CognexLicense_Error = true;
            }

            return m_Vision_CognexLicense_Error;
        }
    }
}