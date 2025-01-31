using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class CLogManager
    {
        #region Thread

        public ListView lv = null;
        public bool LogThread_Run = false;

        public CLogManager(ListView listview)
        {
            lv = listview;
            StartThread();
        }

        public void StartThread()
        {
            LogThread_Run = true;
            // 로그 쓰레드 동작...처리
            // Task 처리를 람다식으로 처리
            System.Threading.Tasks.Task.Run(async () =>
            {
                while (LogThread_Run)
                {
                    await Task.Delay(1);
                    ThreadLogDisp();
                }
            });
        }

        public void Stop()
        {
            LogThread_Run = false;
        }

        private void ThreadLogDisp()
        {
            try
            {
                if (Global.Instance.System.REQ_SYSTEM_CLOSE) return;
                if (lv == null) return;

                if (CLogger.items.Count > 0)
                {
                    while (CLogger.items.Count > 1000) CLogger.items.TryDequeue(out LogItem put);

                    if (CLogger.items.TryDequeue(out LogItem item))
                    {
                        if (lv != null)
                        {
                            lv.Invoke((System.Windows.Forms.MethodInvoker)delegate
                            {
                                if (lv.Items.Count > 1000) lv.Items.RemoveAt(1000);

                                lv.Items.Insert(0, item.StrLog);

                                switch (item.Type)
                                {
                                    case LOG.ABNORMAL:
                                    case LOG.ALARM:
                                    case LOG.EXCEPTION:
                                        {
                                            lv.Items[0].BackColor = DEFINE.COLOR_RED;
                                        }
                                        break;

                                    case LOG.SEQ:
                                        {
                                            lv.Items[0].BackColor = Color.Green;
                                        }
                                        break;
                                }
                            });
                        }
                    }
                }
            }
            catch (Exception Desc)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] Inspection Fail");
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}/{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
            }
        }
        #endregion Thread
    }
}