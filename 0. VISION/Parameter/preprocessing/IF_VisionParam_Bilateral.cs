using ImageProcessing;
using OpenCvSharp;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace IntelligentFactory._0._VISION.Parameter
{
    [Serializable]
    public class IF_VisionParam_Bilateral : IF_ImageProcessing
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Distance")]
        public int Distance { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Sigma Color")]
        public double SigmaColor { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Sigma Space")]
        public double SigmaSpace { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Border Type")]
        public BorderTypes BorderType { get; set; }


        public IF_VisionParam_Bilateral()
        {
            Distance = 10;
            SigmaColor = 10;
            SigmaSpace = 10;
            BorderType = BorderTypes.Reflect;
        }

    }
}
