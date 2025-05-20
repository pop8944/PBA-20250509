using ImageProcessing;
using OpenCvSharp;
using System;
using System.ComponentModel;

namespace IntelligentFactory._0._VISION.Parameter
{
    [Serializable]
    public class IF_VisionParam_GaussianBlur : IF_ImageProcessing
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute("커널 사이즈 X (기본값 : 5 )"), DisplayNameAttribute("Kerner Size X")]
        public int KernerSizeX { get; set; } = 5;

        [CategoryAttribute("Parameter"), DescriptionAttribute("커널 사이즈 Y (기본값 : 5 )"), DisplayNameAttribute("Kerner Size Y")]
        public int KernerSizeY { get; set; } = 5;

        [CategoryAttribute("Parameter"), DescriptionAttribute("X 방향 표준편차"), DisplayNameAttribute("Sigma X")]
        public double SigmaX { get; set; } = 1.5;

        [CategoryAttribute("Parameter"), DescriptionAttribute("Y 방향 표준편차"), DisplayNameAttribute("Sigma Y")]
        public double SigmaY { get; set; } = 0;

        [CategoryAttribute("Parameter"), DescriptionAttribute("테두리 처리 방식 (기본값 : Default)"), DisplayNameAttribute("Type")]
        public BorderTypes BorderType { get; set; } = BorderTypes.Default;

        public IF_VisionParam_GaussianBlur()
        {
            KernerSizeX = 5;
            KernerSizeY = 5; 
            SigmaX = 1.5;
            SigmaY = 0;
            BorderType = BorderTypes.Default;
        }

    }
}
