using NLog;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace IntelligentFactory
{
    public enum LOG
    {
        NORMAL = 0,
        ABNORMAL,
        COMM,
        IO,
        Thread,
        INSP,
        MOTION,
        SEQ,
        ALARM,
        WARN,
        INTERLOCK,
        EXCEPTION,
        DEVICE,
        TEACHING,
        CONFIG,
        LOT
    }

    public class LogItem
    {
        private LOG m_etype;

        public LOG Type
        {
            get
            {
                return m_etype;
            }

            set
            {
                m_etype = value;
            }
        }

        private string m_strLog;

        public string StrLog
        {
            get
            {
                return m_strLog;
            }

            set
            {
                m_strLog = value;
            }
        }

        private bool m_bDisplay;

        public bool IsDisplay
        {
            get
            {
                return m_bDisplay;
            }

            set
            {
                m_bDisplay = value;
            }
        }

        public DateTime m_Time;

        public LogItem(LOG etype, string strLog)
        {
            this.m_etype = etype;
            this.m_strLog = strLog;
            this.m_bDisplay = true;
            this.m_Time = DateTime.Now;
        }
    }

    public static class CLogger
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static ConcurrentQueue<LogItem> items = new System.Collections.Concurrent.ConcurrentQueue<LogItem>();

        public static Color GetColor(LOG type)
        {
            switch (type)
            {
                case LOG.NORMAL:
                    return Color.White;

                case LOG.IO:
                    return Color.Lime;

                case LOG.ABNORMAL:
                case LOG.ALARM:
                    return Color.Red;

                case LOG.COMM:
                    return Color.DeepSkyBlue;

                case LOG.Thread:
                    return Color.Silver;

                case LOG.INSP:
                    return Color.Yellow;

                case LOG.MOTION:
                    return Color.Teal;

                case LOG.SEQ:
                    return Color.Blue;

                case LOG.INTERLOCK:
                    return Color.Orange;

                case LOG.EXCEPTION:
                    return Color.Red;

                case LOG.DEVICE:
                    return Color.White;
            }

            return Color.Black;
        }

        public static System.Windows.Forms.ListView rtb = null;

        public static void Add(LOG type, string format, params object[] args)
        {
            string strLog = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")} : {type.ToString(),-10} ==> {string.Format(format, args)}";
            items.Enqueue(new LogItem(type, strLog));

            switch (type)
            {
                case LOG.SEQ:
                    {
                        logger.Debug($"{format}", args);
                    }
                    break;

                case LOG.ABNORMAL:
                case LOG.ALARM:
                    {
                        logger.Error($"{format}", args);
                    }
                    break;

                case LOG.WARN:
                    {
                        logger.Warn($"{format}", args);
                    }
                    break;

                default:
                    {
                        int count = new StackTrace().FrameCount; //현재의 호출스택 카운트

                        if (count > 2)
                        {
                            StackTrace stacktrace = new StackTrace();
                            MethodBase method1 = stacktrace.GetFrame(1).GetMethod();
                            MethodBase method2 = stacktrace.GetFrame(2).GetMethod();

                            logger.Info($"[{method2.Name} -> {method1.Name}] ==> {format}", args);
                        }
                    }
                    break;
            }
        }

        public static void Exception(string strClass, string strFunc, Exception ex = null)
        {
            if (ex != null)
            {
                StackTrace stacktrace = new StackTrace();

                {
                    string strLog = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")} : {(LOG.EXCEPTION).ToString(),-10} ==> [{strClass}:{strFunc}]{stacktrace.GetFrame(1).GetMethod()} Ex : {ex.Message}";
                    items.Enqueue(new LogItem((LOG.EXCEPTION), strLog));
                }

                {
                    string strLog = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")} : {(LOG.EXCEPTION).ToString(),-10} ==> [{strClass}:{strFunc}] {ex.ToString()}";
                    items.Enqueue(new LogItem((LOG.EXCEPTION), strLog));
                }

                logger.Error(ex);
            }
        }
    }
}