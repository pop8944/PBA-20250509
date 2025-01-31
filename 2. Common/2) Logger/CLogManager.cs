using log4net;

using System;
using System.Reflection;

namespace IntelligentFactory
{
    public class CLogManager : CSeqBase
    {
        public CLogManager()
        {
            this.StartThread();
        }

        //private static readonly ILog log_Total = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly ILog log_Total = LogManager.GetLogger("Total");
        private static readonly ILog log_Exception = LogManager.GetLogger("Exception");
        private static readonly ILog log_Normal = LogManager.GetLogger("Normal");
        private static readonly ILog log_System = LogManager.GetLogger("System");
        private static readonly ILog log_Alarm = LogManager.GetLogger("Alarm");
        //private static readonly ILog log_TactTime = LogManager.GetLogger("TactTime");
        private static readonly ILog log_Sequence = LogManager.GetLogger("Sequence");
        private static readonly ILog log_DataBase = LogManager.GetLogger("DataBase");
        //private static readonly ILog log_Repeatability = LogManager.GetLogger("Repeatability");

        public override void Run()
        {
            try
            {
                if (CLogger.LogQueue.Count > 0)
                {
                    if (CLogger.LogQueue.TryDequeue(out CLogNode logNode))
                    {
                        string strPath = CLogger.GetPath();
                        if (strPath != null && strPath != "")
                        {
                            log_Total.Info(logNode.log);

                            switch (logNode.type)
                            {
                                case LOG.NORMAL:
                                    log_Normal.Info(logNode.log);
                                    break;
                                case LOG.SYSTEM:
                                    log_System.Info(logNode.log);
                                    break;
                                case LOG.ALARM:
                                case LOG.EXCEPTION:
                                    log_Exception.Info(logNode.log);
                                    break;
                                case LOG.IO:
                                    //log_IO.Info(logNode.log);
                                    break;
                                //case LOG.TACTTIME: // [2023-12-24] 불필요하다고 판단되어 제거
                                //    log_TactTime.Info(logNode.log);
                                //    break;
                                case LOG.SEQ:
                                    log_Sequence.Info(logNode.log);
                                    break;
                                case LOG.INSP:
                                    //log_Insp.Info(logNode.log); 
                                    break;
                                case LOG.DATABASE:
                                    log_DataBase.Info(logNode.log);
                                    break;
                                    //case LOG.REPEATABILITY: // [2023-12-24] 불필요하다고 판단되어 제거
                                    //    log_Repeatability.Info(logNode.log);
                                    //    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
