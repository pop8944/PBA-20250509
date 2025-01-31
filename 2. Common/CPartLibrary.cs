using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

#if OPENCV
#endif

namespace IntelligentFactory
{
    public class CPartsLibrary
    {
        public List<CPart> Parts { get; set; } = new List<CPart>();

        public CPartsLibrary()
        {
        }

        #region CONFIG BY XML

        public CPartsLibrary LoadConfig()
        {
            string nodepath = $"{Global.m_MainPJTRoot}\\NODE";
            if (!Directory.Exists(nodepath)) Directory.CreateDirectory(nodepath);

            string strPath = $"{nodepath}\\Parts.xml";
            CPartsLibrary newData = null;

            if (File.Exists(strPath))
            {
                newData = SerializeHelper.FromXmlFile<CPartsLibrary>(strPath);
                if (newData != null) return newData;
                else newData = new CPartsLibrary();
            }
            else
            {
                SaveConfig();
            }

            return newData;
        }

        public void SaveConfig()
        {
            string nodepath = $"{Global.m_MainPJTRoot}\\NODE";
            if (!Directory.Exists(nodepath)) Directory.CreateDirectory(nodepath);

            string strPath = $"{nodepath}\\Parts.xml";
            SerializeHelper.ToXmlFile(strPath, this);

            LoadConfig();
        }

        #endregion CONFIG BY XML
    }

    public class CPart
    {
        public string Name { get; set; } = "TEST";
        public string ToolPath { get; set; } = "";

        [XmlIgnoreAttribute]
        public CCogTool_PMAlign Tool = new CCogTool_PMAlign("TOOL_MAIN");

        [XmlIgnoreAttribute]
        public CCogTool_PMAlign SubTool = new CCogTool_PMAlign("TOOL_SUB");
    }
}