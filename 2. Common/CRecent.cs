using System.IO;

namespace IntelligentFactory
{
    public class CRecent
    {
        public string LastModel { get; set; } = "";
        public string ImagePath { get; set; } = "";
        // Model Count
        public string szModelChangeTime = "20240101:000000";

        public CRecent LoadConfig()
        {
            string savePath = $"{Global.m_MainPJTRoot}\\CONFIG\\Recent.xml";
            CRecent newData = null;

            if (File.Exists(savePath))
            {
                newData = SerializeHelper.FromXmlFile<CRecent>(savePath);
                if (newData != null)
                    return newData;
            }

            newData = new CRecent();
            newData.SaveConfig();
            return newData;
        }

        public void SaveConfig()
        {
            string savePath = $"{Global.m_MainPJTRoot}\\CONFIG\\Recent.xml";
            SerializeHelper.ToXmlFile(savePath, this);
        }
    }
}