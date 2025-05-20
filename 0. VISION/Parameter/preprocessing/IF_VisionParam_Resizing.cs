using ImageProcessing;
using OpenCvSharp;
using System;
using System.ComponentModel;

namespace IntelligentFactory._0._VISION.Parameter
{
    [Serializable]
    public class IF_VisionParam_Resizing : IF_ImageProcessing
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute("출력 이미지 크기"), DisplayNameAttribute("DstSize")]
        public Size DstSize { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("가로 크기 비율"), DisplayNameAttribute("Fx")]
        public double Fx {  get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("세로 크기 비율"), DisplayNameAttribute("Fy")]
        public double Fy { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("보간법 방식"), DisplayNameAttribute("InterpolationFlag")]
        public InterpolationFlags InterpolationFlag { get; set; }

        public IF_VisionParam_Resizing()
        {
            DstSize = new Size(1,1);
            Fx = 1.0;
            Fy = 1.0;
        }
    }
}
