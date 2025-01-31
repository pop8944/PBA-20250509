using SuperSimpleTcp;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace IntelligentFactory
{
    //어떤 클라이언트에게 받았는지를 트래킹
    public class MultiClientsMessageManager
    {
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public ConcurrentQueue<string> RecvMessageQueue = new ConcurrentQueue<string>();
        public ConcurrentQueue<string> ParsedMessageQueue = new ConcurrentQueue<string>();
        public string SumMessage { get; set; } = "";

    }

    public class StringEventArgs : EventArgs
    {
        private string m_strMessage = "";
        public string Message
        {
            get { return m_strMessage; }
            set { m_strMessage = value; }
        }

        public StringEventArgs(string strMessage)
        {
            m_strMessage = strMessage;
        }

        public StringEventArgs()
        {

        }
    }

    public class TcpIp
    {
        private SimpleTcpServer _server;
        private SimpleTcpClient _client;

        private ConcurrentDictionary<string, MultiClientsMessageManager> _clientsManager = new ConcurrentDictionary<string, MultiClientsMessageManager>();

        private DeviceInfo_TcpIp _info;
        private string _name;
        private bool _isInit = false;

        public EventHandler<StringEventArgs> EventRecvResult;
        public EventHandler<StringEventArgs> EventSavedResult;

        public EventHandler<StringEventArgs> EventGetModel;

        public bool IsOpen
        {
            get
            {
                if (_info == null) return false;

                if (_info.IsServer)
                {
                    if (_server == null) return false;
                    return _server.IsListening;
                }
                else
                {
                    if (_client == null) return false;
                    return _client.IsConnected;
                }
            }
        }

        public TcpIp(string name, DeviceInfo_TcpIp info)
        {
            _name = name;
            _info = info;
        }

        public TcpIp(string name)
        {
            _name = name;
        }


        public bool Init(DeviceInfo_TcpIp info)
        {
            try
            {
                StartThread();

                _info = info;

                if (_info != null)
                {
                    if (_info.IsServer)
                    {
                        _server = new SimpleTcpServer($"{_info.ServerIP}:{_info.ServerPort}");

                        // set events
                        _server.Events.ClientConnected += OnClientConnected;
                        _server.Events.ClientDisconnected += OnClientDisconnected;
                        _server.Events.DataReceived += OnDataReceived;

                        _server.Keepalive.EnableTcpKeepAlives = true;
                        _server.Keepalive.TcpKeepAliveInterval = 5;      // seconds to wait before sending subsequent keepalive
                        _server.Keepalive.TcpKeepAliveTime = 5;          // seconds to wait before sending a keepalive
                        _server.Keepalive.TcpKeepAliveRetryCount = 5;    // number of failed keepalive probes before terminating connection

                        // let's go!
                        _server.Start();

                        CLogger.Add(LOG.DEVICE, $"[{_name}][{_info.ServerIP}:{_info.ServerPort}] Server Start IsListening : {_server.IsListening}");
                    }
                    else
                    {
                        _client = new SimpleTcpClient($"{_info.ClientIP}:{_info.ClientPort}");

                        // set events
                        _client.Events.Connected += OnConnected;
                        _client.Events.Disconnected += OnDisconnected;
                        _client.Events.DataReceived += OnDataReceived;

                        // let's go!
                        _client.Connect();
                        _client.ConnectWithRetries(_info.RetryConnectInterval_ms);

                        CLogger.Add(LOG.DEVICE, $"[{_name}][{_info.ClientIP}:{_info.ClientPort}] Cline Start IsConnected : {_client.IsConnected}");
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                //IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");

                return false;
            }
            finally
            {
                _isInit = true;
            }

            return true;
        }

        public bool Send(string msg, string ip)
        {
            try
            {
                if (_info != null)
                {
                    if (_info.IsServer)
                    {
                        _server.Send(ip, msg);
                        Console.WriteLine($"SERVER>>>>CLIENT[{ip}:{_info.ClientIP}] ==> {msg}");
                    }
                    else
                    {
                        _client.Send(msg);
                        Console.WriteLine($"CLIENT>>>>SERVER[{_info.ServerIP}:{_info.ServerPort}] ==> {msg}");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");

                return false;
            }
        }

        private void OnClientConnected(object sender, ConnectionEventArgs e)
        {
            try
            {
                if (_info != null)
                {
                    if (_info.IsServer)
                    {
                        if (_clientsManager.ContainsKey(e.IpPort) == false)
                        {
                            _clientsManager.TryAdd(e.IpPort, new MultiClientsMessageManager());
                        }

                        CLogger.Add(LOG.DEVICE, $"[{e.IpPort}] client connected");
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }

        }

        private void OnClientDisconnected(object sender, ConnectionEventArgs e)
        {
            try
            {
                if (_info != null)
                {
                    if (_info.IsServer) CLogger.Add(LOG.DEVICE, $"[{e.IpPort}] client disconnected ==> {e.Reason}");
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void OnConnected(object sender, ConnectionEventArgs e)
        {
            try
            {
                CLogger.Add(LOG.DEVICE, $"[{e.IpPort}] Server Connected");
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        static void OnDisconnected(object sender, ConnectionEventArgs e)
        {
            try
            {
                CLogger.Add(LOG.DEVICE, $"[{e.IpPort}] Server Disconnected");
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (_clientsManager.ContainsKey(e.IpPort) == false)
                {
                    _clientsManager.TryAdd(e.IpPort, new MultiClientsMessageManager());
                }

                if (e.Data.Array != null && e.Data.Array.Length > 0)
                {
                    string msg = Encoding.UTF8.GetString(e.Data.Array, 0, e.Data.Count);
                    _clientsManager[e.IpPort].RecvMessageQueue.Enqueue(msg);

                    //CLogger.Add(LOG.DEVICE, $"[{e.IpPort}] Server >>>> Client Recv ==> {msg}");
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        public CThreadStatus ThreadStatus = new CThreadStatus();
        public void StartThread(string strThreadName = "")
        {
            if (ThreadStatus.IsExit())
            {
                Thread tParse = new Thread(new ParameterizedThreadStart(ThreadParser));
                tParse.Start(ThreadStatus);

                Thread tAction = new Thread(new ParameterizedThreadStart(ThreadAction));
                tAction.Start(ThreadStatus);
            }
        }

        //private string _messageSum = "";
        private void ThreadParser(object ob)
        {
            CThreadStatus ThreadStatus = (CThreadStatus)ob;

            ThreadStatus.Start($"TCPIP -> ThreadParser Start");

            try
            {
                while (!ThreadStatus.IsExit())
                {
                    if (Global.Instance.System.REQ_SYSTEM_CLOSE == true)
                    {
                        return;
                    }

                    try
                    {
                        if (_info != null && _info.IsServer == false
                            && _client != null && _client.IsConnected == false
                            && _isInit == true)
                        {
                            Thread.Sleep(1000);
                            if (_client.IsConnected == false) _client.Connect();
                        }

                        for (int i = 0; i < _clientsManager.Keys.Count; i++)
                        {
                            string key = _clientsManager.Keys.ToList()[i];

                            if (string.IsNullOrEmpty(key) == false)
                            {
                                MultiClientsMessageManager manager = _clientsManager[key];

                                if (manager.RecvMessageQueue.TryDequeue(out string msgSerial))
                                {
                                    //CLogger.Add(LOG.NORMAL, $"Recv Queue : {msgSerial}");
                                    manager.SumMessage += msgSerial;
                                    //CLogger.Add(LOG.NORMAL, $"Recv Sum : {manager.SumMessage}");
                                    int indexOfEnd = -1;

                                    if (_info.UseCR && _info.UseLF)
                                    {
                                        indexOfEnd = manager.SumMessage.IndexOf("\r\n");
                                    }
                                    else if (_info.UseCR && _info.UseLF == false)
                                    {
                                        indexOfEnd = manager.SumMessage.IndexOf("\r");
                                    }
                                    else if (_info.UseCR == false && _info.UseLF)
                                    {
                                        indexOfEnd = manager.SumMessage.IndexOf("\n");
                                    }
                                    else if (_info.UseCR == false && _info.UseLF == false)
                                    {
                                        indexOfEnd = manager.SumMessage.IndexOf(_info.EndParser);
                                    }

                                    if (indexOfEnd > 0)
                                    {
                                        int indexOfStart = manager.SumMessage.IndexOf("[");

                                        if (indexOfStart >= 0)
                                        {
                                            string payload = manager.SumMessage.Substring(indexOfStart, indexOfEnd - indexOfStart);
                                            //CLogger.Add(LOG.NORMAL, $"Recv Payload : {payload}");

                                            if (indexOfEnd + ("\r\n").Length == manager.SumMessage.Length)
                                            {
                                                manager.SumMessage = "";
                                            }
                                            else
                                            {
                                                manager.SumMessage = _clientsManager[key].SumMessage.Substring(indexOfEnd + 2, _clientsManager[key].SumMessage.Length - (indexOfEnd + 2));
                                            }

                                            //CLogger.Add(LOG.NORMAL, $"Recv Sum Final : {manager.SumMessage}");

                                            manager.ParsedMessageQueue.Enqueue(payload);
                                        }
                                    }
                                }
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                    }


                    Thread.Sleep(1);
                }

                ThreadStatus.End();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                ThreadStatus.End();
            }
        }

        public ConcurrentDictionary<string, EyeD_Result> RecvResults = new ConcurrentDictionary<string, EyeD_Result>();
        public class EyeD_Result
        {
            public string UniqueID { get; set; }
            public string Model { get; set; }
            public string InferType { get; set; }
            public string ResultImagePath { get; set; }
            public string ResultString { get; set; }
        }
        private void ThreadAction(object ob)
        {
            CThreadStatus ThreadStatus = (CThreadStatus)ob;

            ThreadStatus.Start($"TCPIP -> ThreadAction Start");

            try
            {
                while (!ThreadStatus.IsExit())
                {
                    if (Global.Instance.System.REQ_SYSTEM_CLOSE == true)
                    {
                        return;
                    }

                    try
                    {
                        // 해당 결과 시퀀스를 어떻게 효율적으로 처리할지 고민
                        // 어떤 클라이언트에게서 받은 결과를 돌려줄 것인지에 대해 Dictionary Type 으로 Key (IPPort) Value (msg Sum) 을 관리

                        for (int keyIdx = 0; keyIdx < _clientsManager.Keys.Count; keyIdx++)
                        {
                            string key = _clientsManager.Keys.ToList()[keyIdx];

                            if (string.IsNullOrEmpty(key) == false)
                            {
                                MultiClientsMessageManager manager = _clientsManager[key];

                                if (manager.ParsedMessageQueue.TryDequeue(out string msgAction))
                                {
                                    string payload = msgAction;
                                    //CLogger.Add(LOG.COMM, $"Recv Message Payload <<<< {payload}");

                                    payload = payload.Replace("[", "");
                                    payload = payload.Replace("]", "");

                                    //CLogger.Add(LOG.COMM, $"Deleted Parsing Payload <<<< {payload}");

                                    string[] data = payload.Split(',');

                                    //[model,uniqueID,OCR,ImagePath,param]

                                    if (data.Length < 4) break;

                                    string model = data[0];
                                    string uniqueID = data[1];
                                    string inferType = data[2];
                                    string rootType = "FILE";
                                    string imagePath = data[3];
                                    string param = "";
                                    string resultString = data[4];

                                    //CLogger.Add(LOG.COMM, $"Parsing Complete");
                                    //EyeD_Protocl protocol = new EyeD_Protocl();
                                    //protocol = protocol.GetValue(payload);

                                    //if (protocol.ModelName != "")
                                    {
                                        // [,OCR,ImagePath,]\r\n
                                        // [,OCR,ResultPath,OCR DATA]\r\n

                                        //string model = protocol.ModelName;
                                        //string uniqueID = protocol.UniqueID;
                                        //string inferType = protocol.InferType; //DET or SEG or CLS or OBB ...
                                        //string rootType = protocol.RootType; //FILE or FOLDER
                                        //string imagePath = protocol.ImagePath;
                                        //string resultString = protocol.ResultString;

                                        CLogger.Add(LOG.COMM, $"EYE-D ==> {model},{inferType},{resultString}");
                                        EyeD_Result eyeD_Result = new EyeD_Result();

                                        eyeD_Result.Model = model;
                                        eyeD_Result.UniqueID = uniqueID;
                                        eyeD_Result.InferType = inferType;
                                        eyeD_Result.ResultImagePath = imagePath;
                                        eyeD_Result.ResultString = resultString;

                                        switch (inferType)
                                        {
                                            case "GET_MODELS":
                                                {
                                                    if (EventGetModel != null)
                                                    {
                                                        EventGetModel(this, new StringEventArgs(resultString));
                                                    }
                                                    //Global.Instance.Setting.Enviroment.EyeD_Info
                                                }
                                                break;
                                            case "CLS":
                                                {
                                                    if (RecvResults.ContainsKey(uniqueID) == false)
                                                    {
                                                        RecvResults.TryAdd(uniqueID, eyeD_Result);
                                                    }
                                                    else
                                                    {
                                                        RecvResults[uniqueID] = eyeD_Result;
                                                    }
                                                }
                                                break;
                                            case "DET":
                                                {
                                                    if (RecvResults.ContainsKey(uniqueID) == false)
                                                    {
                                                        RecvResults.TryAdd(uniqueID, eyeD_Result);
                                                    }
                                                    else
                                                    {
                                                        RecvResults[uniqueID] = eyeD_Result;
                                                    }
                                                }
                                                break;
                                            case "OBB":
                                                {
                                                    if (RecvResults.ContainsKey(uniqueID) == false)
                                                    {
                                                        RecvResults.TryAdd(uniqueID, eyeD_Result);
                                                    }
                                                    else
                                                    {
                                                        RecvResults[uniqueID] = eyeD_Result;
                                                    }
                                                }
                                                break;
                                            case "OCR":
                                                {
                                                    if (RecvResults.ContainsKey(uniqueID) == false)
                                                    {
                                                        RecvResults.TryAdd(uniqueID, eyeD_Result);
                                                    }
                                                    else
                                                    {
                                                        RecvResults[uniqueID] = eyeD_Result;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                    }


                    Thread.Sleep(1);
                }

                ThreadStatus.End();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                ThreadStatus.End();
            }
        }
    }
}
