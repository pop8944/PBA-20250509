/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// ■ 파일명 : 
// ■ 작성자 : DTH
// ■ 작성일 :
// ■ 주기능 : SocketClient TCP
// ■ 수정일 및 수정 내용 : 
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Timers;

namespace IntelligentFactory
{
    public class SocketClient
    {
        #region Variables
        //---------------------------------------------------------------------------------------------------------------------------------------------
        public byte[] m_byEndChar;

        private IPEndPoint m_pEndPoint;
        private TcpClient m_pSocket;
        private NetworkStream m_pNetworkStream;
        private AsyncCallback m_pRead;

        private byte[] m_byReceive;
        private byte[] m_byData;
        private int m_nBufferIndex;
        private int m_nIoTimeout;
        private bool m_bOnline;

        private ManualResetEvent m_evtReceive;

        private bool m_bStarted;

        private System.Timers.Timer m_tmOnline;
        public static int m_Time_count = 0;
        #endregion
        //---------------------------------------------------------------------------------------------------------------------------------------------

        public byte[] ENDCHAR
        {
            get { return m_byEndChar; }
            set { m_byEndChar = value; }
        }

        public bool ONLINE
        {
            // get { return m_bOnline;  }
            get { return IsOnline(); }
        }

        private string m_IP_String;
        private int m_nPort;
        private object lockSection = new object();

        // 접속하고자하는 Client 이름
        private string m_Client_Name;

        //---------------------------------------------------------------------------------------------------------------------------------------------
        public SocketClient(string m_IP_Address, int port, string client_name, TimeSpan timeout)
        {
            m_byEndChar = new byte[1];
            m_byEndChar[0] = 0x00;

            m_IP_String = m_IP_Address;
            m_nPort = port;
            m_Client_Name = client_name;

            m_pEndPoint = new IPEndPoint(IPAddress.Parse(m_IP_Address), port);
            m_evtReceive = new ManualResetEvent(false);
            m_pSocket = null;

            m_nIoTimeout = (int)timeout.TotalMilliseconds;

            m_byData = new byte[1024];
            m_bOnline = false;
            m_bStarted = false;

            m_tmOnline = new System.Timers.Timer();
            m_tmOnline.AutoReset = false;
            m_tmOnline.Interval = 1000;
            m_tmOnline.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------

        private bool IsOnline()
        {
            bool bRet = true;

            if (m_pSocket == null) bRet = false;
            else if (m_pSocket.Connected == false) bRet = false;
            else if (m_bOnline == false) bRet = false;

            return bRet;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                m_tmOnline.Enabled = false;

                if (IsOnline() == false && m_bStarted == true)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(CheckOnline));
                }
                else
                {
                    m_tmOnline.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}   Client Name ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message, m_Client_Name);
                CLogger.Add(LOG.EXCEPTION, "[FAILED] Error MES : Retry Timer(m_tmOnline)의 예외가 발생했습니다.");
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void CheckOnline(object obj)
        {
            if (BeginReceive() == true)
            {
            }

            m_tmOnline.Enabled = true;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //
        //---------------------------------------------------------------------------------------------------------------------------------------------
        public void Socket_Start(int reconInterval)
        {
            if (m_bStarted == true) return;
            m_bStarted = true;

            BeginReceive();

            m_tmOnline.Interval = reconInterval;
            m_tmOnline.Enabled = true;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //
        //---------------------------------------------------------------------------------------------------------------------------------------------
        public void Socket_Stop()
        {
            m_tmOnline.Enabled = false;
            Disconnect(0);
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //
        //---------------------------------------------------------------------------------------------------------------------------------------------
        static bool ExceptionLog = false;
        private bool BeginReceive()
        {
            try
            {
                if (IsOnline() == false)
                {
                    m_pSocket = new TcpClient();
                    m_pRead = new AsyncCallback(OnRead);
                    m_pSocket.Connect(m_IP_String, m_nPort);
                    m_pNetworkStream = m_pSocket.GetStream();
                    m_bOnline = true;

                    string str_log = "[" + m_Client_Name + "] Connection to server...!";
                    CLogger.Add(LOG.ABNORMAL, "ReConnection success... $$$$");

                    ExceptionLog = false;
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (SocketException e)
            {
                m_bOnline = false;
                if (!ExceptionLog)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}   Client Name ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, e.Message, m_Client_Name);
                    ExceptionLog = true;
                }

                return false;
            }
            catch (Exception e)
            {
                m_bOnline = false;

                if (!ExceptionLog)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}   Client Name ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, e.Message, m_Client_Name);
                }
                return false;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private bool Socket_Receive(out byte[] data, int timeout)
        {
            if (m_evtReceive.WaitOne(timeout) != true)
            {
                data = null;
                return false;
            }

            data = m_byReceive;
            return true;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private bool Socket_Receive(out byte[] data, out int nRdLen, int timeout)
        {
            if (m_evtReceive.WaitOne(timeout) != true)
            {
                nRdLen = -1;
                data = null;
                return false;
            }

            data = m_byReceive;
            nRdLen = CntByte(data);
            return true;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //
        //---------------------------------------------------------------------------------------------------------------------------------------------
        public bool Socket_Read(out byte[] data, int nRdSize, out int nRdLen, int timeout)
        {
            data = null;
            nRdLen = -1;

            bool isPending = false;

            #region EndReceive
            try
            {
                if (IsOnline() == false) return false;

                data = new byte[nRdSize];
                nRdLen = m_pNetworkStream.Read(data, 0, nRdSize);
                //return true;
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode == SocketError.WouldBlock ||
                    e.SocketErrorCode == SocketError.IOPending ||
                    e.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                {
                    Thread.Sleep(1);
                    isPending = true;
                    //Console.WriteLine("Pending....#####");
                }
                else
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}   Client Name ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, e.Message, m_Client_Name);
                    Disconnect(4);
                    return false;
                }
            }
            catch (Exception e)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}   Client Name ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, e.Message, m_Client_Name);
                Disconnect(5);
                return false;
            }

            if (nRdLen <= 0 && isPending == false)
            {
                Disconnect(6);
                return false;
            }

            return true;

            #endregion
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //
        //---------------------------------------------------------------------------------------------------------------------------------------------
        public bool Socket_Read(out byte[] data, out int nRdLen, byte nEndByte, int timeout)
        {
            int nTotalBufCnt = 0;
            //            int nRdSize = 0;

            byte[] read_buf = new byte[128];
            byte[] data_buf = new byte[1024];

            data = null;
            nRdLen = -1;

            bool isPending = false;

            #region EndReceive
            try
            {
                if (IsOnline() == false) return false; ;
                while (true)
                {
                    nRdLen = m_pNetworkStream.Read(read_buf, 0, 1);
                    if (nRdLen <= 0 || read_buf[0] == nEndByte)
                    {
                        nRdLen = nTotalBufCnt;
                        break;
                    }
                    data_buf[nTotalBufCnt] = read_buf[0];
                    nTotalBufCnt++;
                }

                data = new byte[nTotalBufCnt];
                Array.Copy(data_buf, data, data.Length);
                //return true;
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode == SocketError.WouldBlock ||
                    e.SocketErrorCode == SocketError.IOPending ||
                    e.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                {
                    Thread.Sleep(100);
                    isPending = true;
                    //Console.WriteLine("Pending....#####");
                }
                else
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}   Client Name ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, e.Message, m_Client_Name);
                    Disconnect(4);
                    return false;
                }
            }
            catch (Exception e)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}   Client Name ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, e.Message, m_Client_Name);
                Disconnect(5);
                return false;
            }

            if (nRdLen <= 0 && isPending == false)
            {
                Disconnect(6);
                return false;
            }

            return true;

            #endregion
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private bool Socket_Receive(out byte[] data, int nRdSize, out int nRdLen, int timeout)
        {
            if (m_evtReceive.WaitOne(timeout) != true)
            {
                nRdLen = -1;
                data = null;
                return false;
            }

            if (nRdSize <= m_byReceive.Length)
            {
                data = new byte[nRdSize];

                Buffer.BlockCopy(m_byReceive, 0, data, 0, nRdSize);

                byte[] bufData = new byte[1024];

                Buffer.BlockCopy(m_byReceive, nRdSize, bufData, 0, m_byReceive.Length - nRdSize);

                m_byReceive = new byte[m_byReceive.Length - nRdSize + 1];
                Buffer.BlockCopy(bufData, 0, m_byReceive, 0, m_byReceive.Length);
                nRdLen = CntByte(data);
                return true;
            }
            else
            {
                data = new byte[nRdSize];
                Buffer.BlockCopy(m_byReceive, 0, data, 0, m_byReceive.Length);
                nRdLen = m_byReceive.Length;
                return false;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        public int CntByte(byte[] bData)
        {
            int cnt = 0;
            for (int idx = 0; idx < bData.Length; idx++)
            {
                if (bData[idx] != (byte)0x00) cnt = idx + 1;
            }

            return cnt;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        public void Wait_Establish()
        {
            m_evtReceive.Reset();
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        public bool Send(byte[] data, int timeout = 1000)
        {
            int totalSend = 0;

            if (IsOnline() != true) return false;

            // Nano Soft
            // critical... 
            lock (lockSection)
            {
                try
                {
                    m_pSocket.SendTimeout = timeout;
                }
                catch (Exception e)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}   Client Name ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, e.Message, m_Client_Name);
                    return false;
                }


                try
                {
                    if (m_pNetworkStream.CanWrite)
                    {
                        m_pNetworkStream.Write(data, totalSend, data.Length - totalSend);
                        m_pNetworkStream.Flush();
                    }
                    else
                    {
                        CLogger.Add(LOG.EXCEPTION, "[FAILED] CanWrite False");
                    }
                }
                catch (SocketException e)
                {
                    if (e.SocketErrorCode == SocketError.WouldBlock ||
                        e.SocketErrorCode == SocketError.IOPending ||
                        e.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        Thread.Sleep(100);
                    }
                    else
                    {
                        CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}   Client Name ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, e.Message, m_Client_Name);
                        Disconnect(1);
                        return false;
                    }
                }
                catch (Exception e)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}   Client Name ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, e.Message, m_Client_Name);
                    Disconnect(2);
                    return false;
                }

                Wait_Establish();
                return true;
            }

        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void OnRead(IAsyncResult ar)
        {
            NetworkStream stream = m_pNetworkStream;
            int recv = 0;
            bool isPending = false;

            #region EndReceive
            try
            {
                if (IsOnline() == false) return;
                recv = stream.EndRead(ar);
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode == SocketError.WouldBlock ||
                    e.SocketErrorCode == SocketError.IOPending ||
                    e.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                {
                    Thread.Sleep(100);
                    isPending = true;
                    Console.WriteLine("Pending....#####");
                }
                else
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}   Client Name ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, e.Message, m_Client_Name);
                    Disconnect(4);
                    return;
                }
            }
            catch (Exception e)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}   Client Name ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, e.Message, m_Client_Name);
                Disconnect(5);
                return;
            }

            if (recv <= 0 && isPending == false)
            {
                Disconnect(6);
                return;
            }
            #endregion

            #region 수신처리
            try
            {
                #region Head Packet 수신 처리

                if (m_byEndChar.Length > 1)
                {
                    int idx = 0;
                    int k = 0;
                    if (m_nBufferIndex > m_byEndChar.Length - 1)
                    {
                        if (m_byData[m_nBufferIndex] == m_byEndChar[m_byEndChar.Length - 1])
                        {
                            for (k = m_byEndChar.Length - 1; k >= 0; k--)
                            {
                                idx = m_nBufferIndex - ((m_byEndChar.Length - 1) - k);
                                if (m_byData[idx] != m_byEndChar[k]) break;
                            }

                            if (k == -1)
                            {
                                m_byReceive = new byte[m_nBufferIndex + 1];
                                Buffer.BlockCopy(m_byData, 0, m_byReceive, 0, m_byReceive.Length);

                                m_nBufferIndex = 0;
                                m_evtReceive.Set();
                            }
                            else
                            {
                                m_nBufferIndex += recv;
                                if (m_nBufferIndex >= m_byData.Length)
                                {
                                    Disconnect(7);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            m_nBufferIndex += recv;
                            if (m_nBufferIndex >= m_byData.Length)
                            {
                                Disconnect(8);
                                return;
                            }
                        }
                    }
                    else
                    {
                        m_nBufferIndex += recv;
                        if (m_nBufferIndex >= m_byData.Length)
                        {
                            Disconnect(9);
                            return;
                        }
                    }
                }
                else if (m_byEndChar.Length == 1)
                {
                    if (m_byData[m_nBufferIndex] == m_byEndChar[0])
                    {
                        m_byReceive = new byte[m_nBufferIndex + 1];
                        Buffer.BlockCopy(m_byData, 0, m_byReceive, 0, m_byReceive.Length);

                        m_nBufferIndex = 0;
                        m_evtReceive.Set();
                    }
                    else
                    {
                        m_nBufferIndex += recv;
                        if (m_nBufferIndex >= m_byData.Length)
                        {
                            Disconnect(10);
                            return;
                        }
                    }
                }
                else
                {

                }

                stream.BeginRead(m_byData, m_nBufferIndex, 1, m_pRead, m_pNetworkStream);
                return;

                #endregion
            }
            catch (SocketException e)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}   Client Name ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, e.Message, m_Client_Name);
                Disconnect(11);
                return;
            }
            catch (Exception e)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Ex ==> {2}   Client Name ==> {3}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, e.Message, m_Client_Name);
                Disconnect(12);
                return;
            }
            #endregion
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        public void Disconnect(int id)
        {
            lock (this)
            {
                if (IsOnline() == true)
                {
                    if (id == 0)
                    {
                        CLogger.Add(LOG.ABNORMAL, $"\"[ EVENT  ] Disconnect Case : {m_Client_Name} Not Connect\"");
                    }

                    m_pNetworkStream.Close();
                    m_pSocket.Close();
                }

                m_pSocket = null;
                m_bOnline = false;
                m_nBufferIndex = 0;
            }
        }


        //---------------------------------------------------------------------------------------------------------------------------------------------
        public Byte Check_Sum(Byte[] source, int cnt)
        {
            int nRet = 0xFF;

            int idx = 0;
            for (idx = 0; idx < cnt; idx++)
            {
                nRet = nRet ^ source[idx];
            }

            return (Byte)nRet;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        public Byte Check_Sum(Byte[] source)
        {
            int nRet = 0xFF;

            int idx = 0;
            for (idx = 0; source[idx] != 0x00; idx++)
            {
                nRet = nRet ^ source[idx];
            }

            return (Byte)nRet;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        public int Get_Bit(short nVal, int Bit_Pos)
        {
            Byte[] nByte = BitConverter.GetBytes(nVal);
            BitArray bitArray = new BitArray(nByte);

            if (bitArray.Get(Bit_Pos))
                return 1;
            else
                return 0;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        public string ByteToStr(byte bByte)
        {
            byte[] byte_Buf = { bByte };
            string sRet = Encoding.ASCII.GetString(byte_Buf);
            return sRet;
        }
    }

}
