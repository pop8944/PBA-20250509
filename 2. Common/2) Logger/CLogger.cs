using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace IntelligentFactory
{
    public enum LOG
    {
        NORMAL = 0,
        TACTTIME,
        ALIGN,
        TIB,
        SYSTEM,
        COMM_DEBUG,
        SAMPLING,
        DEBUG,
        ABNORMAL,
        COMM,
        IO,
        Thread,
        INSP,
        MOTION,
        SEQ,
        ALARM,
        INTERLOCK,
        EXCEPTION,
        DEVICE,
        DFS,
        TEACHING,
        CONFIG,
        MES,
        LOT,
        FTP,
        APD,
        DATABASE,
        APD_COMPARE,
        APD_VERIFY,
        REPORT,
        REPEATABILITY
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

        public Color DisplayColor = Color.White;

        public LogItem(LOG etype, string strLog, Color color)
        {
            this.m_etype = etype;
            this.m_strLog = strLog;
            this.m_bDisplay = true;
            this.DisplayColor = color;
        }
    }

    public class CLogNode
    {
        public LOG type;
        public DateTime dt;
        public string log;

        public CLogNode(LOG type, DateTime dt, string log)
        {
            this.type = type;
            this.dt = dt;
            this.log = log;
        }
    }
    public static class CLogger
    {
        private const int MAX_TRY_WRITE_LOG_FILE = 10;

        public static ConcurrentQueue<CLogNode> LogQueue = new ConcurrentQueue<CLogNode>();

        private static List<string> m_lstFilebuffer = new List<string>();

        public static bool m_bStartLog = true;
        private static string m_strLogPath;// = @"D:\";

        public delegate void LogEvent(LogItem item);
        public static event LogEvent EventLog;

        public static Color GetColor(LOG type)
        {
            switch (type)
            {
                case LOG.NORMAL:
                case LOG.FTP:
                    return Color.White;
                case LOG.DEBUG:
                    return Color.LightSkyBlue;
                case LOG.IO:
                    return Color.Lime;
                //2023-03-22 박민우
                case LOG.SYSTEM:
                    return Color.Lime;
                case LOG.ABNORMAL:
                case LOG.ALARM:
                    return Color.Red;
                case LOG.COMM:
                    return Color.Magenta;
                case LOG.MES:
                    return Color.DarkMagenta;
                case LOG.APD:
                case LOG.APD_COMPARE:
                case LOG.DATABASE:
                    return Color.Teal;
                case LOG.Thread:
                    return Color.Silver;
                case LOG.INSP:
                    return Color.Yellow;
                case LOG.MOTION:
                    return Color.Teal;
                case LOG.SEQ:
                    return Color.Yellow;
                case LOG.INTERLOCK:
                    return Color.Orange;
                case LOG.EXCEPTION:
                    return Color.Red;
                case LOG.DEVICE:
                    return Color.White;
                case LOG.REPEATABILITY:
                    return Color.Orange;

            }

            return Color.Silver;
        }

        public static void SetPath(string strPath)
        {
            try
            {
                string strDir = strPath;
                if (Directory.Exists(strDir) == false)
                {
                    Directory.CreateDirectory(strPath);
                }

                m_strLogPath = strDir;
                Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        public static void Exception(string className, string funcName, Exception ex)
        {
            StackTrace stacktrace = new StackTrace();
            Add(LOG.EXCEPTION, $"[EXCEPTION] {className}==>{funcName}   Execption ==> {ex.ToString()} StackTrace ==> {stacktrace.GetFrame(1).GetMethod()}");
        }

        public static void Exception(string className, string funcName, string desc, Exception ex)
        {
            StackTrace stacktrace = new StackTrace();
            Add(LOG.EXCEPTION, $"[EXCEPTION] {className}==>{funcName}   Execption ==> {ex.ToString()} StackTrace ==> {stacktrace.GetFrame(1).GetMethod()} Desc : {desc}");
        }

        //        public static void Exception(string strClass, string strFunc, Exception ex = null)
        //        {
        //            if (ex != null)
        //            {
        //                StackTrace stacktrace = new StackTrace();

        //                {
        //                    string strLog = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")} : {(LOG.EXCEPTION).ToString(),-10} ==> [{strClass}:{strFunc}]{stacktrace.GetFrame(1).GetMethod()} Ex : {ex.Message}";
        //                    items.Enqueue(new LogItem((LOG.EXCEPTION), strLog));
        //                }

        //                {
        //                    string strLog = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")} : {(LOG.EXCEPTION).ToString(),-10} ==> [{strClass}:{strFunc}] {ex.ToString()}";
        //                    items.Enqueue(new LogItem((LOG.EXCEPTION), strLog));
        //                }

        //                logger.Error(ex);
        //            }
        //        }

        public static string GetPath()
        {
            return m_strLogPath;
        }

        public static void AddEvent(LogEvent newMethod)
        {
            EventLog += newMethod;
        }

        static private object lockObject = new object();


        public static bool Add(LOG type, string format, params object[] args)
        {
            string strLog = "";
            try
            {
                string strFileLog = DateTime.Now.ToString("yy-MM-dd HH:mm:ss.fff ", CultureInfo.InvariantCulture) + $"[{type.ToString().ToUpper()}] : " + string.Format(format, args);

                LogQueue.Enqueue(new CLogNode(type, DateTime.Now, strFileLog));

                if (EventLog != null) EventLog(new LogItem(type, strFileLog, GetColor(type)));

                Debug.WriteLine(strFileLog);
            }
            catch (Exception ex)
            {
                strLog = format;
            }

            return true;
        }

        public static bool Add(string format)
        {
            LOG type = LOG.NORMAL;
            string strLog = "";
            try
            {
                strLog = format;
                strLog = strLog.TrimEnd('\0');

                DateTime timestampNew = DateTime.Now;

                string strLogType = "[" + type.ToString().ToUpper() + "]";

                strLogType = strLogType.PadLeft(10, ' ');

                string strFileLog = timestampNew.ToString("yy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "," + strLogType + "  :  ," + strLog;
                Debug.WriteLine(strFileLog);

                LogQueue.Enqueue(new CLogNode(type, timestampNew, strFileLog));

                LogItem item = new LogItem(type, strFileLog, GetColor(type));

                if (EventLog != null)
                {
                    EventLog(item);
                }
            }
            catch (Exception ex)
            {
                strLog = format;
            }

            return true;
        }

        public static void LoggerFileDelete(string strDir, string strExt, int FileCount)
        {
            DirectoryInfo dinfo = new DirectoryInfo(strDir);
            if (!dinfo.Exists) dinfo.Create();

            if (FileCount < dinfo.GetFiles().Length)
            {
                List<FileInfo> files = new List<FileInfo>();
                foreach (FileInfo f in dinfo.GetFiles())
                {
                    if (f.Extension == strExt) files.Add(f);
                }

                files.Sort(new CompareFileInfoEntries());

                for (int i = 0; i <= files.Count - FileCount; i++)
                {
                    File.Delete(dinfo.FullName + "\\" + files[i].Name);
                    //WriteLog("Delete File ==> " + dinfo.FullName + "\\" + files[i].Name);
                }
            }
        }
    }

    public class CompareFileInfoEntries : IComparer<FileInfo>
    {
        public int Compare(FileInfo f1, FileInfo f2)
        {
            return (DateTime.Compare(f1.CreationTime, f2.CreationTime));
        }
    }
}
