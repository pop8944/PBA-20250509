//#if DIO_ADLINK
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentFactory
{
    public static class CDIO_BIT
    {
        // 별도의 비트 플래그 처리...
        public static bool INSP_START = false;
        public static bool INSP_START_ISDISPLAY = false;
        public static bool RESULT_NG = false;
        public static bool RESULT_OK = false;
    }

    public static class CDIO_BITNAME
    {
        public const string INSP_START = "INSP_START";
        public const string RESULT_NG = "RESULT_NG";
        public const string RESULT_OK = "RESULT_OK";
    }

    // DIO의 외부 IO 파일 읽어오기...
    // IO파일을 INI로 별도 관리해서 처리하기...
    public class CDIO_DATACONFIG
    {
        public struct CDIO_DATA
        {
            public string IO_ADRESS;          // IO 번호..
            public string IO_NAME;       // IO 이름...
            public bool ONOFF;          // IO ON : TRUE, OFF : FALSE
        }

        private string nDI_FilePath = "";
        private string nDO_FilePath = "";
        public int DI_MAXCNT = 16;       // INI파일에서 읽은 IO 갯수...확인..
        public int DO_MAXCNT = 16;
        public CDIO_DATA[] list_DI_Data;
        public CDIO_DATA[] list_DO_Data;

        // IO EDIT 플래그
        // IO값이 변경되었는지 확인
        public bool IO_Edit = false;

        // 해당 IO 데이터 읽어오기...
        public CDIO_DATACONFIG()
        {
            // 해당 파일 읽기..
            LOAD_CONIFG();
        }

        // 해당 파일이 있는지 체크함..
        private void File_Check()
        {
            // 파일 경로 확인..
            // 초기는 CONFIG의 DEVICE에 IO 파일 할당..
            string DI_Filename = "DI.ini";
            string DO_Filename = "DO.ini";
            string FolederPath = $"{Global.m_MainPJTRoot}\\CONFIG\\DEVICE\\IO";
            nDI_FilePath = Path.Combine(FolederPath, DI_Filename);
            nDO_FilePath = Path.Combine(FolederPath, DO_Filename);

            // 파일스트림을 사용했으므로 파일닫기를 항시 해줘야함(닫기를 하지 않을시 다른쪽에서 파일 접근 불가)
            FileStream _file;

            // System 파일 체크
            if (!Directory.Exists(FolederPath))
            {
                Directory.CreateDirectory(FolederPath);

                _file = File.Create(nDI_FilePath);
                _file.Close();

                _file = File.Create(nDO_FilePath);
                _file.Close();
            }
            else
            {
                if (!File.Exists(nDI_FilePath))
                {
                    _file = File.Create(nDI_FilePath);
                    _file.Close();
                }

                if (!File.Exists(nDO_FilePath))
                {
                    _file = File.Create(nDO_FilePath);
                    _file.Close();
                }
            }
        }

        // 세이브 추가...
        public void Config_Save()
        {
            CFileManager.WritePrivateProfileString("DI", null, null, nDI_FilePath);
            // DI 관련..
            CFileManager.WritePrivateProfileString("DI", "MAX_CNT", DI_MAXCNT.ToString(), nDI_FilePath);
            // DI값 쓰기..
            for (int i = 0; i < DI_MAXCNT; i++)
            {
                CFileManager.WritePrivateProfileString("DI", $"DI_INDEX_{i}", list_DI_Data[i].IO_ADRESS.ToString(), nDI_FilePath);
                CFileManager.WritePrivateProfileString("DI", $"DI_NAME_{i}", list_DI_Data[i].IO_NAME.ToString(), nDI_FilePath);
            }

            // DO 관련..
            CFileManager.WritePrivateProfileString("DO", null, null, nDO_FilePath);
            CFileManager.WritePrivateProfileString("DO", "MAX_CNT", DO_MAXCNT.ToString(), nDO_FilePath);
            // DI값 읽어오기...
            for (int i = 0; i < DO_MAXCNT; i++)
            {
                CFileManager.WritePrivateProfileString("DO", $"DO_INDEX_{i}", list_DO_Data[i].IO_ADRESS.ToString(), nDO_FilePath);
                CFileManager.WritePrivateProfileString("DO", $"DO_NAME_{i}", list_DO_Data[i].IO_NAME.ToString(), nDO_FilePath);
            }
        }

        private void Config_Load()
        {
            StringBuilder temp = new StringBuilder(255);
            CDIO_DATA DI_DATA = new CDIO_DATA();
            CDIO_DATA DO_DATA = new CDIO_DATA();

            bool ret = Convert.ToBoolean(CFileManager.GetPrivateProfileString("DI", "MAX_CNT", "", temp, 255, nDI_FilePath));
            if (ret == false)
            {
                DI_MAXCNT = 16;            // 기본 사용
                CFileManager.WritePrivateProfileString("DI", "MAX_CNT", DI_MAXCNT.ToString(), nDI_FilePath);
            }
            else
            {
                DI_MAXCNT = Convert.ToInt16(temp.ToString());
            }

            // 배열 생성
            list_DI_Data = new CDIO_DATA[DI_MAXCNT];

            string srtname;

            // DI값 읽어오기...
            for (int i = 0; i < DI_MAXCNT; i++)
            {
                ret = Convert.ToBoolean(CFileManager.GetPrivateProfileString("DI", $"DI_INDEX_{i}", "", temp, 255, nDI_FilePath));
                if (ret == false)
                {
                    // 초기값...
                    DI_DATA.IO_ADRESS = $"{i:00}";
                    CFileManager.WritePrivateProfileString("DI", $"DI_INDEX_{i}", DI_DATA.IO_ADRESS.ToString(), nDI_FilePath);
                }
                else
                {
                    string adress = temp.ToString();
                    DI_DATA.IO_ADRESS = $"{adress:00}";
                }

                ret = Convert.ToBoolean(CFileManager.GetPrivateProfileString("DI", $"DI_NAME_{i}", "", temp, 255, nDI_FilePath));
                if (ret == false)
                {
                    // 초기값...
                    if (i == 0) srtname = "INSP_START";
                    else srtname = $"IN_{i:00}";

                    DI_DATA.IO_NAME = srtname;
                    CFileManager.WritePrivateProfileString("DI", $"DI_NAME_{i}", DI_DATA.IO_NAME.ToString(), nDI_FilePath);
                }
                else
                {
                    DI_DATA.IO_NAME = temp.ToString();
                }

                list_DI_Data[i] = DI_DATA;
            }

            ret = Convert.ToBoolean(CFileManager.GetPrivateProfileString("DO", "MAX_CNT", "", temp, 255, nDO_FilePath));
            if (ret == false)
            {
                DO_MAXCNT = 16;            // 기본 사용
                CFileManager.WritePrivateProfileString("DO", "MAX_CNT", DO_MAXCNT.ToString(), nDO_FilePath);
            }
            else
            {
                DO_MAXCNT = Convert.ToInt16(temp.ToString());
            }

            // 배열 생성..
            list_DO_Data = new CDIO_DATA[DO_MAXCNT];

            // DO값 읽어오기...
            for (int i = 0; i < DO_MAXCNT; i++)
            {
                ret = Convert.ToBoolean(CFileManager.GetPrivateProfileString("DO", $"DO_INDEX_{i}", "", temp, 255, nDO_FilePath));
                if (ret == false)
                {
                    // 초기값...
                    DO_DATA.IO_ADRESS = $"{i:00}";
                    CFileManager.WritePrivateProfileString("DO", $"DO_INDEX_{i}", DO_DATA.IO_ADRESS.ToString(), nDO_FilePath);
                }
                else
                {
                    string adress = temp.ToString();
                    DO_DATA.IO_ADRESS = $"{adress:00}";
                }

                ret = Convert.ToBoolean(CFileManager.GetPrivateProfileString("DO", $"DO_NAME_{i}", "", temp, 255, nDO_FilePath));
                if (ret == false)
                {
                    // 초기값...
                    if (i == 1)
                        srtname = "RESULT_NG";
                    else if (i == 2)
                        srtname = "RESULT_OK";
                    else
                        srtname = $"OUT_{i:00}";

                    DO_DATA.IO_NAME = srtname;
                    CFileManager.WritePrivateProfileString("DO", $"DO_NAME_{i}", DO_DATA.IO_NAME.ToString(), nDO_FilePath);
                }
                else
                {
                    DO_DATA.IO_NAME = temp.ToString();
                }

                list_DO_Data[i] = DO_DATA;
            }
        }

        public void LOAD_CONIFG()
        {
            // 파일이 있는지 우선 체크함...
            File_Check();
            Config_Load();
        }
    }


    public class CDIO_ADLINK7432
    {
        public CDIO_DATACONFIG IO_DATA = new CDIO_DATACONFIG();

        private bool m_bIsAlive = false;
        public bool IsOpen
        {
            get { return m_bIsAlive; }
            set { m_bIsAlive = value; }
        }

        private ushort m_ushCarNo;
        public ushort CardNo
        {
            get { return m_ushCarNo; }
            set { m_ushCarNo = value; }
        }
        public CDIO_ADLINK7432(ushort ushPciCardNo = 0)
        {
            CardNo = ushPciCardNo;
            Open();
        }

        // 연결...초기화..
        private void Open()
        {
            try
            {
                int nRet = DASK.Register_Card(DASK.PCI_7230, CardNo); //PCI_7230, PCI_7432

                if (nRet == 0)
                {
                    IsOpen = true;
                    StartDIRead();
                    StartDORead();
                }
                else
                {
                    switch (nRet)
                    {
                        case DASK.ErrorTooManyCardRegistered:
                            {

                            }
                            break;
                        case DASK.ErrorUnknownCardType:
                            {

                            }
                            break;
                        case DASK.ErrorOpenDriverFailed:
                            {

                            }
                            break;
                        case DASK.ErrorOpenEventFailed:
                            {

                            }
                            break;
                    }
                    IsOpen = false;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
                //Logger.WriteLog(LOG.ERR, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

        }

        //private List<CSignal> m_ListInput = new List<CSignal>();
        //public List<CSignal> Inputs
        //{
        //    get { return m_ListInput; }
        //    set { m_ListInput = value; }
        //}

        //private List<CSignal> m_ListOutput = new List<CSignal>();
        //public List<CSignal> Outputs
        //{
        //    get { return m_ListOutput; }
        //    set { m_ListInput = value; }
        //}

        //public void SetInputEvent(CSignal signal, EventHandler<EventArgs> eventHandler)
        //{
        //    bool isDI = signal.isDI();
        //    int nIO_Num = signal.GetAddressNo();
        //    if (isDI)
        //        m_ListInput[nIO_Num].EventUpdateSignal += eventHandler;
        //    else
        //        m_ListOutput[nIO_Num].EventUpdateSignal += eventHandler;
        //    eventSignals.Add(signal);
        //}

        //public void SetOutputEvent(CSignal signal)
        //{
        //    eventSignals.Add(signal);
        //}
        #region Thread
        private bool ThreadDIRead = false;
        private bool ThreadDORead = false;

        public void StartDIRead()
        {
            ThreadDIRead = true;
            Task.Run(async () =>
            {
                while (ThreadDIRead)
                {
                    await Task.Delay(1);
                    DIRead();
                    // 플래그 업데이트...
                    //DI_BITUPDATE();
                }
            });
        }

        private void DIRead()
        {
            if (IsOpen)
            {
                int nRet = 0;
                uint unInputStatus;
                // Input은 DI_ReadPort로 읽는다.(16채널 한번에 읽음)
                // 데이터는 16비트 Data
                nRet = DASK.DI_ReadPort(CardNo, 0, out unInputStatus);
                if (nRet == 0)
                {
                    // 데이터를 2진수로 변환
                    string strBinaryArray = Convert.ToString(unInputStatus, 2);
                    // 16채널이므로 PadLeft로 16자릿수를 맞춤
                    strBinaryArray = strBinaryArray.PadLeft(32, '0');
                    int nStartIndex = 0;
                    int count = 32 - IO_DATA.DI_MAXCNT;

                    for (int i = strBinaryArray.Length - 1; i >= count; i--)
                    {
                        IO_DATA.list_DI_Data[nStartIndex].ONOFF = strBinaryArray[i] == '1' ? true : false;
                        if (IO_DATA.list_DI_Data[nStartIndex].IO_NAME == CDIO_BITNAME.INSP_START)
                        {
                            if (CDIO_BIT.INSP_START != IO_DATA.list_DI_Data[nStartIndex].ONOFF) CDIO_BIT.INSP_START_ISDISPLAY = true;
                            CDIO_BIT.INSP_START = IO_DATA.list_DI_Data[nStartIndex].ONOFF;
                        }
                        //Inputs[nStartIndex].Current = strBinaryArray[i] == '1' ? CSignal.SIGNAL_TYPE.ON : CSignal.SIGNAL_TYPE.OFF;
                        nStartIndex++;
                    }
                }
            }
        }


        public void StartDORead()
        {
            ThreadDORead = true;
            Task.Run(async () =>
            {
                while (ThreadDORead)
                {
                    await Task.Delay(1);
                    DORead();
                    // 플래그 업데이트...
                    DO_BITUPDATE();
                }
            });
        }

        public void DORead()
        {
            if (IsOpen)
            {
                uint unInputStatus;

                // Output은 DO_ReadPort 읽는다.(16채널 한번에 읽음)
                // 데이터는 16비트 Data
                int nRet = DASK.DO_ReadPort(CardNo, 0, out unInputStatus);
                if (nRet == 0)
                {
                    string strBinaryArray = Convert.ToString(unInputStatus, 2);
                    strBinaryArray = strBinaryArray.PadLeft(32, '0');

                    int nStartIndex = 0;
                    int count = 32 - IO_DATA.DO_MAXCNT;

                    for (int i = strBinaryArray.Length - 1; i >= count; i--)
                    {
                        IO_DATA.list_DO_Data[nStartIndex].ONOFF = strBinaryArray[i] == '1' ? true : false;
                        //Outputs[nStartIndex].Current = strBinaryArray[i] == '1' ? CSignal.SIGNAL_TYPE.ON : CSignal.SIGNAL_TYPE.OFF;
                        nStartIndex++;
                    }
                }
            }
        }

        private void DO_BITUPDATE()
        {
            for (int i = 0; i < IO_DATA.DO_MAXCNT; i++)
            {
                if (IO_DATA.list_DO_Data[i].IO_NAME == CDIO_BITNAME.RESULT_OK)
                {
                    CDIO_BIT.RESULT_OK = IO_DATA.list_DO_Data[i].ONOFF;
                }

                if (IO_DATA.list_DO_Data[i].IO_NAME == CDIO_BITNAME.RESULT_NG)
                {
                    CDIO_BIT.RESULT_NG = IO_DATA.list_DO_Data[i].ONOFF;
                }
            }
        }

        #endregion

        public bool Close()
        {
            try
            {
                //StopThreadRead();
                //Thread.Sleep(100);
                ThreadDIRead = false;
                ThreadDORead = false;

                int nRet = DASK.Release_Card(CardNo); //PCI_7230, PCI_7432            

                if (nRet == 0)
                {
                    IsOpen = false;
                }
                else
                {
                    IsOpen = true;
                }
                return true;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                //Logger.WriteLog(LOG.ERR, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }
        }

        public void Bit_OnOff(string _Bitname, bool onoff)
        {
            ushort value = 0;

            if (onoff) value = 1;

            for (int i = 0; i < IO_DATA.DO_MAXCNT; i++)
            {
                if (IO_DATA.list_DO_Data[i].IO_NAME == _Bitname)
                {
                    short shRet = DASK.DO_WriteLine(CardNo, 0, ushort.Parse(IO_DATA.list_DO_Data[i].IO_ADRESS), value);

                    if (onoff) CLogger.Add(LOG.NORMAL, $"[{_Bitname}] BIT ON SET : ret {shRet}");
                    else CLogger.Add(LOG.NORMAL, $"[{_Bitname}] BIT OFF SET : ret {shRet}");

                    return;
                }
            }
        }

        //2024.04.02 송현수 : BIT 핸들링 함수 추가
        public void On(string name)
        {
            for (int i = 0; i < IO_DATA.DO_MAXCNT; i++)
            {
                if (IO_DATA.list_DO_Data[i].IO_NAME == name)
                {
                    short shRet = DASK.DO_WriteLine(CardNo, 0, ushort.Parse(IO_DATA.list_DO_Data[i].IO_ADRESS), 1);
                    CLogger.Add(LOG.IO, $"I/O [{name}] : BIT ON");
                    return;
                }
            }
        }

        public void Off(string name)
        {
            for (int i = 0; i < IO_DATA.DO_MAXCNT; i++)
            {
                if (IO_DATA.list_DO_Data[i].IO_NAME == name)
                {
                    short shRet = DASK.DO_WriteLine(CardNo, 0, ushort.Parse(IO_DATA.list_DO_Data[i].IO_ADRESS), 0);
                    CLogger.Add(LOG.IO, $"I/O [{name}] : BIT OFF");
                    return;
                }
            }
        }
    }
}