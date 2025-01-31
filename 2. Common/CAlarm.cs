using System;
using System.Collections.Generic;
using System.Linq;

namespace IntelligentFactory
{
    public class CNodeAlarm
    {
        public string Code { get; set; } = "1";
        public string Desc { get; set; } = "EMPTY";
        public bool IsIgnore { get; set; } = false;
        public DateTime Time { get; set; } = new DateTime();

        public CNodeAlarm(string strCode, string strDesc, bool bIsIgnore = false)
        {
            this.Code = strCode;
            this.Desc = strDesc;
            this.IsIgnore = bIsIgnore;
            this.Time = DateTime.Now;
        }
    }

    public static class CAlarm
    {
        private static Dictionary<string, CNodeAlarm> m_dicNodes = new Dictionary<string, CNodeAlarm>();

        //private static DateTime timestampOld;
        public static bool m_bStartLog = true;
        //private static string m_strLogPath = IGlobal.m_MainPJTRoot + "\\ALARM";
        //private static string m_strAppName;

        public delegate void AlarmEvent(CNodeAlarm item);

        //public static event AlarmEvent EventAlarm;

        public static bool Exists
        {
            get => m_dicNodes.Count > 0 ? true : false;
        }

        public static void Add(string code, string desc)
        {
            if (!m_dicNodes.ContainsKey(code))
            {
                try
                {
                    CNodeAlarm node = new CNodeAlarm(code, desc);
                    Global.Instance.System.Mode = CSystem.MODE.ALARM;

                    m_dicNodes.Add(code, node);

                    CLogger.Add(LOG.ALARM, $"ALARM CODE : {code} DESC : {desc}");
                }
                catch
                {
                }

            }
        }

        public static void Add(CNodeAlarm alarm)
        {
            if (!m_dicNodes.ContainsKey(alarm.Code))
            {
                try
                {
                    m_dicNodes.Add(alarm.Code, alarm);

                    CLogger.Add(LOG.ALARM, $"ALARM CODE : {alarm.Code} DESC : {alarm.Desc}");
                }
                catch
                {
                }

                if (!alarm.IsIgnore)
                {
                    //FormAlarm FrmAlarm = new FormAlarm(alarm.Code, alarm.Desc);
                    //if(!CUtil.OpenCheckForm(FrmAlarm))
                    //{
                    //    FrmAlarm.Show();
                    //}
                }
            }
        }

        public static (string, string) GetLastAlarm()
        {
            if (m_dicNodes.Count == 0) return ("N/A", "N/A");
            else
            {
                string strCode = m_dicNodes.ElementAt(m_dicNodes.Count - 1).Value.Code;
                string strDesc = m_dicNodes.ElementAt(m_dicNodes.Count - 1).Value.Desc;
                return (strCode, strDesc);
            }
        }

        public static void Clear()
        {
            m_dicNodes.Clear();
            CLogger.Add(LOG.NORMAL, $"ALARM CLEAR");
        }

        public static void AddEvent(AlarmEvent newMethod)
        {
            //EventAlarm += newMethod;
        }
    }
}