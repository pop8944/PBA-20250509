using System.ComponentModel;
using System.IO;

namespace IntelligentFactory
{
    public class CMode
    {
        public string Name { get; set; } = "";

        [CategoryAttribute("MODE"), DescriptionAttribute(""), DisplayNameAttribute("USE RMS")]
        public bool UseRms { get; set; } = false;

        [CategoryAttribute("MODE"), DescriptionAttribute(""), DisplayNameAttribute("Force JUDGE")]
        public bool isForceJudge { get; set; } = false;

        [CategoryAttribute("MODE"), DescriptionAttribute(""), DisplayNameAttribute("Auto JUDGE")]
        public bool AutoJudge { get; set; } = true;


        [CategoryAttribute("MODE"), DescriptionAttribute(""), DisplayNameAttribute("QR Pass")]
        public bool QrPass { get; set; } = false;

        public bool QRModelVerify { get; set; } = true;

        [CategoryAttribute("MODE"), DescriptionAttribute(""), DisplayNameAttribute("Result Alarm Mode")]
        public bool ResultAlarm { get; set; } = false;

        public double alarmRatio { get; set; } = 20.0;

        [CategoryAttribute("MODE"), DescriptionAttribute(""), DisplayNameAttribute("Result Visible")]
        public bool ResultVisible { get; set; } = false;

        [CategoryAttribute("MODE"), DescriptionAttribute(""), DisplayNameAttribute("Debugging")]
        public bool isDebugMode { get; set; } = false;

        [CategoryAttribute("MODE"), DescriptionAttribute(""), DisplayNameAttribute("NGisRecent")]
        public bool NGisRecent { get; set; } = true;


        public bool QRCheck { get; set; } = false;
        public string QRCheckText { get; set; } = "";

        public double availHdd { get; set; } = 20.0;

        public int deleteFileN { get; set; } = 30;

        public int RMSMargin { get; set; } = 50;

        public bool isSimulRMS { get; set; } = false;

        public bool isDeveloper { get; set; } = false;

        public bool isJudgeScreenShot { get; set; } = false;
        public bool isAddEnable { get; set; } = false;

        // RMS 사용 상태 모드 설정함..
        // 초기 디폴트는 true임..
        public bool IsRMS_CallStage_ReTest { get; set; } = true;
        public bool IsRMS_NGBUFFER_ReTest { get; set; } = true;
        public bool IsRMS_BoardOut { get; set; } = true;
        public bool IsRMS_BoardPass { get; set; } = true;
        public bool IsRMS_FinalOk { get; set; } = true;

        [CategoryAttribute("MODE"), DescriptionAttribute(""), DisplayNameAttribute("NG_ReInspec_Use")]
        public bool ReInspecUse { get; set; } = false;

        [CategoryAttribute("MODE"), DescriptionAttribute(""), DisplayNameAttribute("NG_ReInspec_Cnt")]
        public int ReInspecCnt { get; set; } = 0;

        // NG BUFFER의 폴란드 버젼과 광주, 말레시아 버젼으로 구분 [ 폴란드 / 광주, 말레시아 ]
        public bool NG_Buffer_Type { get; set; } = true;            // true [ 광주, 말레시아 ], false [ 폴란드 ]

        // 생산 Count Reset time
        public int Count_Reset_D { get; set; } = 0;
        public int Count_Reset_M { get; set; } = 0;
       
        public CMode LoadConfig()
        {
            string savePath = $"{Global.m_MainPJTRoot}\\CONFIG\\Mode.xml";
            CMode newData = null;

            if (File.Exists(savePath))
            {
                newData = SerializeHelper.FromXmlFile<CMode>(savePath);
                if (newData != null)
                    return newData;
            }

            newData = new CMode();
            newData.SaveConfig();
            return newData;
        }

        public void SaveConfig()
        {
            string savePath = $"{Global.m_MainPJTRoot}\\CONFIG\\Mode.xml";
            SerializeHelper.ToXmlFile(savePath, this);
        }
    }
}