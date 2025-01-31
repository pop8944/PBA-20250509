using System.IO;

namespace IntelligentFactory
{
    public class CGrabManager
    {
        public CNodeGrab[] Nodes = new CNodeGrab[5]
        {
            new CNodeGrab(),
            new CNodeGrab(),
            new CNodeGrab(),
            new CNodeGrab(),
            new CNodeGrab()
        };

        public CGrabManager LoadConfig()
        {
            string strpath = $"{Global.m_MainPJTRoot}\\PBA_LIBRARY\\{Global.Instance.System.Recipe.CODE}";
            string strFilePath = Path.Combine(strpath, "Grab.xml");
            CGrabManager newData = new CGrabManager();

            if (File.Exists(strFilePath))
            {
                newData = SerializeHelper.FromXmlFile<CGrabManager>(strFilePath);
                if (newData != null) return newData;
                else
                {
                    return newData;
                }
            }

            return newData;
        }

        public void SaveConfig()
        {
            string _path = $"{Global.m_MainPJTRoot}\\PBA_LIBRARY\\{Global.Instance.System.Recipe.CODE}";
            if (!Directory.Exists(_path)) Directory.CreateDirectory(_path);
            string strFilePath = Path.Combine(_path, "Grab.xml");

            SerializeHelper.ToXmlFile(strFilePath, this);
        }
    }

    public class CNodeGrab
    {
        public int ExposureTime_us { get; set; } = 5000;
        public float Gain { get; set; } = 1.0F;
        public bool Enabled { get; set; } = false;
        public int Light { get; set; } = 100;
    }
}