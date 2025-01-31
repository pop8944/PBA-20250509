using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Threading;

namespace IntelligentFactory
{
    public class SeqCommParser : CSeqBase
    {
        private Global Global = Global.Instance;
        public EventHandler<EventArgs> EventInitEnd;
        public ConcurrentQueue<ImageSaveNode> ImgQueue;
        public SeqCommParser()
        {
            ThreadName = "SEQ_CommParser";
            StartThread();
        }

        private TcpIp _tcpip = null;
        public void SetTcpIp(TcpIp tcpip)
        {
            _tcpip = tcpip;
            ThreadSleepTime_ms = 1;
        }

        private string _msgSum = "";

        public override void Run()
        {
            try
            {
                if (_tcpip == null)
                {
                    Thread.Sleep(100);
                    return;
                }
                else
                {
                    //_tcpip.MessageQueue
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
            finally
            {
            }
        }

    }
}
