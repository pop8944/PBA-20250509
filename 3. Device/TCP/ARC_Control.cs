using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IntelligentFactory.ARC_Control;

namespace IntelligentFactory
{
    public static class ARC_CMD_1
    {
        public static string REQUEST = "REQUEST";
        public static string WRITE = "WRITE";
        public static string CHECK = "CHECK";
    }

    public static class ARC_CMD_2
    {
        public static string MCHANGE = "MCHANGE";
    }

    public static class ARC_CMD_3
    {
        public static string PREPARE = "PREPARE";
        public static string MACHINE_START = "MCHANGE_START";
        public static string MCHANGE_END = "MCHANGE_END";
        public static string NOW_MODEL = "NOW_MODEL";
        public static string MCHANGE_START = "MCHANGE_START";
    }


    public class ARC_Client
    {
        public SocketClient m_Socket;
        int m_nTimeout;
        public bool m_ThreadRecvDataRun = false;
        public bool m_ThreadRecvParsingRun = false;
        public Queue<byte[]> RECV_MSG = new Queue<byte[]>();
        public bool ISRUN = false;
        public string m_IP;
        public int m_Port;
        public string m_Name;
        // 통신 테스트 리스트 박스 로그 기록...
        // 테스트 용이므로 테스트 완료후 필요없음...
        public Queue<string> m_listLog = new Queue<string>();

        private Task m_Task;
        public bool ONLINE
        {
            get
            {
                bool bRet = false;
                if (m_Socket != null)
                {
                    return m_Socket.ONLINE;
                }
                return bRet;
            }
        }

        public ARC_Client(string _IP, int _Port, string _Name)
        {
            m_IP = _IP;
            m_Port = _Port;
            m_Name = _Name;

            if (!Open())
            {
                string msg = $"{m_Name} Not Client Connect..ReCheck Please!";
                CLogger.Add(LOG.DEVICE, msg);
                //IF_Util.ShowMessageBox("DEVICE", msg);
            }
        }

        public bool Open()
        {
            if (m_ThreadRecvDataRun) m_ThreadRecvDataRun = false;
            if (m_ThreadRecvParsingRun) m_ThreadRecvParsingRun = false;

            if (m_Socket != null)
            {
                m_Socket = null;
            }

            m_listLog.Clear();        // 초기화함...

            // Socket Connect 
            if (m_Socket == null)
            {
                RECV_MSG.Clear();     // 초기화
                m_nTimeout = 1000;
                m_Socket = new SocketClient(m_IP, m_Port, m_Name, new TimeSpan(0, 0, 1));
                byte[] byteData = { 0x02, 0x03 };
                m_Socket.ENDCHAR = byteData;
                m_Socket.Socket_Start(500); // 0.5sec reconnection Interval
                m_ThreadRecvDataRun = true;
                m_ThreadRecvParsingRun = true;
                RecvThread();
                ParsingThread();
                ISRUN = ONLINE;
            }

            return ISRUN;
        }

        public void Close()
        {
            m_listLog.Clear();        // 초기화함...
            m_ThreadRecvDataRun = false;
            m_ThreadRecvParsingRun = false;

            if (m_Socket != null)
            {
                m_Socket.Socket_Stop();
            }
        }

        public void RecvThread()
        {
            Task.Run(async () =>
            {
                while (m_ThreadRecvDataRun)
                {
                    try
                    {
                        await Task.Delay(3);
                        ReceiveData();
                    }

                    catch
                    {
                        RECV_MSG.Clear();
                    }
                }
            });
        }

        private void ReceiveData()
        {
            // 데이터 리드를 위해 쓰레드만 도는 함수이므로 별도 락 필요없음..
            // 락걸면 속도만 느려짐...데이터 누락이 발생될 소지가 있음
            if (!m_Socket.ONLINE)
            {
                return;
            }

            try
            {
                //1. [Message-Type] Read
                bool bRet = m_Socket.Socket_Read(out byte[] bReceive, 1000, out int nRdLen, m_nTimeout); // 패킷 읽은 사이즈는 100개로함

                //string hex = "";
                if (bRet)
                {
                    bReceive = Util.BytesZeroClear(bReceive);           // 0값을 없애서 바이트 크기 줄이기

                    // List Add
                    RECV_MSG.Enqueue(bReceive);
                }
                else
                {
                    string str_log = $"{m_Name} Cannot connect...!";
                    CLogger.Add(LOG.DEVICE, str_log);
                    m_listLog.Enqueue(str_log);
                    return;
                }
            }
            catch //(Exception ex)
            {
                return;
            }
        }

        public void ParsingThread()
        {
            Task.Run(async () =>
            {
                while (m_ThreadRecvParsingRun == true)
                {
                    try
                    {
                        await Task.Delay(3);
                        ReceiveParsing();
                    }

                    catch
                    {
                        RECV_MSG.Clear();
                    }
                }
            });
        }

        private void ReceiveParsing()
        {
            byte STX = 0x02;
            byte ETX = 0x03;
            //---------------------------------------------------

            if (0 < RECV_MSG.Count())
            {
                byte[] bReceive = RECV_MSG.Dequeue();

                if (bReceive[0] == STX && bReceive[bReceive.Length - 1] == ETX)
                {
                    byte[] ret = new byte[bReceive.Length - 2];

                    for (int i = 1; i < bReceive.Length - 1; i++)
                    {
                        ret[i - 1] = bReceive[i];
                    }

                    string sRet = Encoding.ASCII.GetString(ret);

                    // Receive 로그 찍기..
                    string str_byte = "";

                    for (int i = 0; i < bReceive.Length; i++)
                    {
                        if (i == 0) str_byte = $"{bReceive[i]}";
                        else
                        {
                            str_byte += $", {bReceive[i]}";
                        }
                    }

                    string strLog = string.Format($"Receive : {sRet}, Byte Receive Msg : {str_byte}");
                    CLogger.Add(LOG.DEVICE, strLog);
                    m_listLog.Enqueue(strLog);

                    Data_Parsing(sRet);           // 읽어온 스트링값을 분류
                }
            }
        }

        // 해당 함수에 레시피 로드 시나리오 처리 하면됨..
        // 레시피 로드 함수 호출되도록 추가 해주면됨..
        //======================================================
        private void Data_Parsing(string ret)
        {
            string[] strArrayData = ret.Split(',');

            if (strArrayData[1] == ARC_CMD_2.MCHANGE)
            {
                if (strArrayData[0] == ARC_CMD_1.REQUEST)
                {
                    if (strArrayData[2] == ARC_CMD_3.PREPARE)
                    {
                        if (Global.Instance.System.Mode == CSystem.MODE.READY)
                        {
                            CMD_PREPARE(Global.EQP_NAME, true);
                        }
                        else
                            CMD_PREPARE(Global.EQP_NAME, false);

                        // 레시피를 변경가능한 상태이면 OK를
                        //CMD_PREPARE(Global.EQP_NAME, true);

                        // 레시피를 변경 불가능 한 상태이면은 NG를
                        //CMD_PREPARE(Global.EQP_NAME, false);
                    }
                    else if (strArrayData[2] == ARC_CMD_3.MACHINE_START)
                    {
                        // 플래그 처리
                        Global.Instance.System.Mode = CSystem.MODE.AUTO;
                        CMD_MCHANGESTART(Global.EQP_NAME);
                    }
                }
                else if (strArrayData[0] == ARC_CMD_1.WRITE)
                {
                    if (strArrayData[2] == "MCHANGE_START")
                    {
                        // 쓰고자 하는 레시피의 이름을 가져옴..
                        Recipe_Job_Name = strArrayData[3].Replace("-", "");

                        // Recipe Change Start
                        m_Task = Task.Run(async () =>
                        {
                            await Task.Delay(1);
                            RecipeChage(Recipe_Job_Name);
                        });

                        //CHANGE START SEND
                        // 그리고 레시피 변경 작업 시작 처리

                    }
                }
                else if (strArrayData[0] == ARC_CMD_1.CHECK)
                {
                    // 레시피 쓰기가 완료되었는지를 묻는값...
                    if (strArrayData[2] == ARC_CMD_3.MCHANGE_END)
                    {
                        if (Global.Instance.System.Mode == CSystem.MODE.AUTO)
                        {
                            CMD_MCHANGEEND(Global.EQP_NAME, Param_Vlue.NG);
                        }
                        else if (!m_Task.IsCompleted && !m_Task.IsCanceled && !m_Task.IsFaulted) // Recipe Change 완료 상태 채크
                        {
                            CMD_MCHANGEEND(Global.EQP_NAME, Param_Vlue.WAIT);
                        }
                        else
                            CMD_MCHANGEEND(Global.EQP_NAME, Param_Vlue.OK);
                        // 현재 레시피 쓰는 중이면
                        //CMD_MCHANGEEND(Global.EQP_NAME, Param_Vlue.WAIT);

                        // 현재 레시피 쓰는게 NG날 경우
                        //CMD_MCHANGEEND(Global.EQP_NAME, Param_Vlue.NG);

                        // 현재 레시피 쓰는게 완료되면..
                        //CMD_MCHANGEEND(Global.EQP_NAME, Param_Vlue.OK);
                    }
                    // 레시피 새로운 모델을 물을 경우
                    else if (strArrayData[2] == ARC_CMD_3.NOW_MODEL)
                    {
                        // 새로운 모델 이름을 써서 값 써주기..
                        // 매개변수에 모델 이름 써주기..
                        string Model_Name = Global.Instance.System.Recipe.Name;
                        CMD_NOWMODEL(Global.EQP_NAME, Model_Name);
                    }
                }
                else
                {

                }
            }
        }

        // 메세지 전송
        public void SendMsg(string EQP_ID, string cmd, string data)
        {
            byte STX = 0x02;     // Frame 시작
            byte ETX = 0x03;     // Fream 끝

            // Socket Packet
            string _packet = $"{EQP_ID},{ARC_CMD_2.MCHANGE},{cmd},{data}";
            byte[] byteSend = Encoding.ASCII.GetBytes(_packet);
            byte[] WriteSend = new byte[byteSend.Length + 2];

            for (int i = 0; i < WriteSend.Length; i++)
            {
                if (i == 0)
                {
                    WriteSend[0] = STX;
                }
                else if (i == WriteSend.Length - 1)
                {
                    WriteSend[WriteSend.Length - 1] = ETX;
                }
                else
                {
                    WriteSend[i] = byteSend[i - 1];
                }
            }

            // SEND 로그 찍기..
            string str_byte = "";

            for (int i = 0; i < WriteSend.Length; i++)
            {
                if (i == 0) str_byte = $"{WriteSend[i]}";
                else
                {
                    str_byte += $", {WriteSend[i]}";
                }
            }

            string strLog = string.Format($"SEND_MSG : {_packet}, Byte Send Msg : {str_byte}");
            CLogger.Add(LOG.DEVICE, strLog);
            m_listLog.Enqueue(strLog);

            m_Socket.Send(WriteSend);
        }

        private bool RecipeChage(string RecipeName)
        {
            bool result = false;
            if (Global.Instance.SeqRecipeChage.IsRecipeChanging == false)
            {
                if (RecipeName != "")
                {
                    string strPrevRecipe = RecipeName;

                    CMD_MCHANGESTART(Global.EQP_NAME, Param_Vlue.OK); //send to ARC change result

                    // 해당 모델의 라이브러리 잡 리드..
                    // 레시피 데이터 가져올때 task로 가동하여서 별도 정지된 현상 없애기위함..
                    // 백그라운드의 별도 TASK쓰레드 형태로 가동되므로 폼을 건드릴때는 반드시 인보크 처리 필요함..
                    Task RecipeChangeTask = Task.Run(() =>
                    {
                        Global.Instance.Recent.LastModel = RecipeName;
                        Global.Instance.System.Recipe.Name = RecipeName;

                        Global.Instance.Recent.SaveConfig();
                        Global.Instance.SeqRecipeChage.ChageRecipe(Global.Instance.System.Recipe.Name);
                        Global.Instance.System.Recipe.Name = Recipe_Job_Name;
                        result = true;
                    });
                    RecipeChangeTask.Wait();

                    if (result)
                    {

                    }
                    else
                    {

                    }
                    return result;
                }
            }
            else
            {
                CMD_MCHANGESTART(Global.EQP_NAME, Param_Vlue.NG);//send to ARC change result
            }

            return result;

        }
    }

    public static class ARC_Control
    {
        public static ARC_Client m_ARC_Client = null;
        public static string IP = "";
        public static int Port = 0;
        public static string Name = "";
        public static string Recipe_Job_Name = "";

        public enum Param_Vlue
        {
            OK,
            WAIT,
            NG,
        }

        public static void Open(string _ip, int port, string name)
        {
            IP = _ip;
            Port = port;
            Name = name;
            m_ARC_Client = new ARC_Client(IP, Port, Name);
        }

        // 해당 보드의 연결되어있는지 상태 체크...
        public static bool IsRun
        {
            get
            {
                bool bRet = false;
                if (m_ARC_Client != null)
                {
                    if (m_ARC_Client.m_Socket != null) return m_ARC_Client.m_Socket.ONLINE;
                }
                return bRet;
            }
        }

        public static void Close()
        {
            // 해당 클라이언트 해제..
            m_ARC_Client.Close();
            m_ARC_Client = null;
        }

        // 프로토콜 메세지 처리
        //=====================================================
        // PREPARE 처리
        public static void CMD_PREPARE(string EQP_ID, bool OK_NG)
        {
            string value = "OK";
            if (!OK_NG) value = "NG";

            m_ARC_Client.SendMsg(EQP_ID, ARC_CMD_3.PREPARE, value);
        }

        // MCHANGE_START 처리
        public static void CMD_MCHANGESTART(string EQP_ID, Param_Vlue para_value = Param_Vlue.OK)
        {
            string value = "OK";
            if (para_value == Param_Vlue.OK) value = $"{Param_Vlue.OK}";
            else if (para_value == Param_Vlue.NG) value = $"{Param_Vlue.NG}";

            m_ARC_Client.SendMsg(EQP_ID, ARC_CMD_3.MACHINE_START, value);
        }

        // MCHANGE_END 처리
        public static void CMD_MCHANGEEND(string EQP_ID, Param_Vlue para_value)
        {
            string value;

            if (para_value == Param_Vlue.OK) value = $"{Param_Vlue.OK}";
            else if (para_value == Param_Vlue.NG) value = $"{Param_Vlue.NG}";
            else value = $"{Param_Vlue.WAIT}";

            m_ARC_Client.SendMsg(EQP_ID, ARC_CMD_3.MCHANGE_END, value);
        }

        // MCHANGE_END 처리
        public static void CMD_NOWMODEL(string EQP_ID, string Model_Name)
        {
            string value = Model_Name;
            m_ARC_Client.SendMsg(EQP_ID, ARC_CMD_3.NOW_MODEL, value);
        }
    }
}
