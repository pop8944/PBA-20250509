using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace IntelligentFactory
{
    public class CSeqBase
    {
        public string SeqIndex = "IDLE";
        public int ScanIndex = 0;
        public string ThreadName = "";
        public int ThreadSleepTime_ms = 10;
        public int SeqRetryCount = 0;
        public Stopwatch swCycleTime = new Stopwatch();
        public TimeSpan CycleTime = new TimeSpan();

        public double TactTime_sec
        {
            get
            {
                return (double)swCycleTime.ElapsedMilliseconds / 1000.0;
            }
        }

        public string _ImagePath_OK = "";
        public string _ImagePath_NG = "";

        public bool ManualTrigger = false;

        private DateTime SeqChangedTime = DateTime.Now;

        public EventHandler<EventArgs> EventSeqComplete;

        public CThreadStatus ThreadStatus = new CThreadStatus();
        public void StartThread(string strThreadName = "")
        {
            if (strThreadName != "") ThreadName = strThreadName;

            CLogger.Add(LOG.Thread, $"Thread Start ==> {ThreadName}");

            if (ThreadStatus.IsExit())
            {
                SeqIndex = "IDLE";
                Thread t = new Thread(new ParameterizedThreadStart(ThreadMain));
                t.Start(ThreadStatus);
            }
        }

        public virtual void StopThread()
        {
            if (!ThreadStatus.IsExit())
            {
                CLogger.Add(LOG.Thread, $"Thread Stop ==> {ThreadName}");

                SeqIndex = "IDLE";

                ThreadStatus.Stop(100);
                ThreadStatus.End();
            }
        }

        public void SetStep(string strSeqIndex)
        {
            //CLogger.Add(LOG.SEQ, "SEQ {0} STEP {1} ==> {2}", ThreadName, SeqIndex, strSeqIndex);
            //CLogger.Add(LOG.SEQ, "SEQ {0} STEP {1}", ThreadName, SeqIndex);
            SeqChangedTime = DateTime.Now;

            SeqIndex = strSeqIndex;
        }

        public bool IsTimeOver(int nTimeOver_ms)
        {
            TimeSpan t = DateTime.Now - SeqChangedTime;
            if (t.TotalMilliseconds > nTimeOver_ms) return true;
            else return false;
        }

        private void ThreadMain(object ob)
        {
            CThreadStatus ThreadStatus = (CThreadStatus)ob;

            ThreadStatus.Start($"{ThreadName} Start");

            try
            {
                while (!ThreadStatus.IsExit())
                {
                    if (Global.Instance == null || Global.Instance.System == null)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    if (Global.Instance.System.REQ_SYSTEM_CLOSE)
                    {
                        StopThread();
                        return;
                    }

                    try
                    {
                        Run();
                    }
                    catch (Exception Desc)
                    {
                        string strMsg = $"[EXCEPTION] Thread : {ThreadName} Seq : {SeqIndex} Detail : {MethodBase.GetCurrentMethod().ReflectedType.Name}/{MethodBase.GetCurrentMethod().Name}   Execption ==> {Desc.Message}";
                        CLogger.Add(LOG.EXCEPTION, strMsg);
                    }


                    Thread.Sleep(ThreadSleepTime_ms);
                }

                ThreadStatus.End();
            }
            catch (Exception Desc)
            {
                string strMsg = $"[EXCEPTION] Thread : {ThreadName} Seq : {SeqIndex} Detail : {MethodBase.GetCurrentMethod().ReflectedType.Name}/{MethodBase.GetCurrentMethod().Name}   Execption ==> {Desc.Message}";
                CLogger.Add(LOG.EXCEPTION, strMsg);
                IF_Util.ShowMessageBox("EXCEPTION", strMsg);
                ThreadStatus.End();
            }
        }

        public virtual void Run()
        {

        }

        public virtual void IDLE()
        {
            CLogger.Add(LOG.SEQ, $"{ThreadName} Initilize");

            SeqIndex = "IDLE";
            ScanIndex = 0;

            swCycleTime.Reset();
            swCycleTime.Stop();
        }
    }
}
