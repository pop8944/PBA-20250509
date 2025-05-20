using ImageProcessing;
using OpenCvSharp;
using System;
using System.ComponentModel;

namespace IntelligentFactory._0._VISION.Parameter
{
    [Serializable]
    public class IF_VisionParam_Morphology : IF_ImageProcessing
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute("모폴로지 연산 종류"), DisplayNameAttribute("Morph Type")]
        public MorphTypes MorphType { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("커널 사이즈"), DisplayNameAttribute("KernerSize")]
        public int KernerSize { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("기준점 (기본값 : -1 / 중심)"), DisplayNameAttribute("PointX")]
        public int PointX { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("기준점 (기본값 : -1 / 중심)"), DisplayNameAttribute("PointY")]
        public int PointY { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("반복 횟수 (기본값 : 1)"), DisplayNameAttribute("Iterations")]
        public int Iterations { get; set; }

        public IF_VisionParam_Morphology()
        {
            MorphType = 0;
            KernerSize = 3;
            PointX = 1;
            PointY = 1;
            Iterations = 1;
        }

    }
}
