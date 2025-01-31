using Cognex.VisionPro.ImageProcessing;
using System.ComponentModel;
using System.IO;

namespace IntelligentFactory
{
    public class CParameter_ImageProcess
    {
        public string Name { get; set; } = "";

        [CategoryAttribute("PARAMETER"), DescriptionAttribute(""), DisplayNameAttribute("USE THRESHOLD")]
        public bool UseThreshold { get; set; } = false;

        [CategoryAttribute("PARAMETER"), DescriptionAttribute(""), DisplayNameAttribute("THRESHOLD")]
        public double Threshold { get; set; } = 128;

        [CategoryAttribute("PARAMETER"), DescriptionAttribute(""), DisplayNameAttribute("USE MORPHOLOGY")]
        public bool UseMorp { get; set; } = false;

        [CategoryAttribute("PARAMETER"), DescriptionAttribute(""), DisplayNameAttribute("KERNEL SIZE")]
        public double MorpSize { get; set; } = 3;

        [CategoryAttribute("PARAMETER"), DescriptionAttribute(""), DisplayNameAttribute("FLIP/ROTATE")]
        public string FlipRotate { get; set; } = CogIPOneImageFlipRotateOperationConstants.None.ToString();

        public CParameter_ImageProcess()
        {
        }

        public CParameter_ImageProcess LoadConfig()
        {
            string savePath = $"{Global.m_MainPJTRoot}\\CONFIG\\DEVICE\\Parameter_ImageProcess_{Name}.xml";
            CParameter_ImageProcess newData = null;

            if (File.Exists(savePath))
            {
                newData = SerializeHelper.FromXmlFile<CParameter_ImageProcess>(savePath);
                if (newData != null)
                    return newData;
            }

            newData = new CParameter_ImageProcess();
            newData.Name = Name;
            newData.SaveConfig();
            return newData;
        }

        public void SaveConfig()
        {
            string savePath = $"{Global.m_MainPJTRoot}\\CONFIG\\DEVICE\\Parameter_ImageProcess_{Name}.xml";
            SerializeHelper.ToXmlFile(savePath, this);
        }
    }
}