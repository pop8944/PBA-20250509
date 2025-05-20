using ImageProcessing;
using OpenCvSharp;
using System;
using System.ComponentModel;

namespace IntelligentFactory._0._VISION.Parameter
{
    [Serializable]
    public class IF_VisionParam_GammaCorrection : IF_ImageProcessing
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute("변환할 데이터 타입"), DisplayNameAttribute("Mat Type")]
        public MatType MatType { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("스케일 계수 (기본값 1)"), DisplayNameAttribute("Alpha")]
        public double Alpha { get; set; } = 1;

        [CategoryAttribute("Parameter"), DescriptionAttribute("추가할 값 (기본값 0)"), DisplayNameAttribute("Beta")]
        public double Beta { get; set; } = 0;

        public IF_VisionParam_GammaCorrection()
        {
            MatType = MatType.CV_8U;
            Alpha = 1;
            Beta = 0;
        }

    }
}
