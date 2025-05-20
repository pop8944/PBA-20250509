using ImageProcessing;
using OpenCvSharp;
using System;
using System.ComponentModel;

namespace IntelligentFactory._0._VISION.Parameter
{
    [Serializable]
    public class IF_VisionParam_LaplacialFilter : IF_ImageProcessing
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute("출력 이미지의 깊이"), DisplayNameAttribute("DDepth")]
        public MatType DDepth {  get; set; } = MatType.CV_8U;

        [CategoryAttribute("Parameter"), DescriptionAttribute("커널 사이즈 (기본값 : 1 / 홀수)"), DisplayNameAttribute("KernerSize")]
        public int KernerSize { get; set; } = 1;

        [CategoryAttribute("Parameter"), DescriptionAttribute("결과 값의 스케일링 계수"), DisplayNameAttribute("Scale")]
        public double Scale { get; set; } = 1;

        [CategoryAttribute("Parameter"), DescriptionAttribute("출력 이미지에 추가할 값 (기본값 : 0)"), DisplayNameAttribute("Delta")]
        public double Delta { get; set; } = 0;

        [CategoryAttribute("Parameter"), DescriptionAttribute("외곽 픽셀 처리방식"), DisplayNameAttribute("Type")]
        public BorderTypes BorderType { get; set; } = BorderTypes.Default;

        public IF_VisionParam_LaplacialFilter()
        {
            DDepth = MatType.CV_8U;
            KernerSize = 1;
            Scale = 1;
            Delta = 0;
            BorderType = BorderTypes.Default;
        }

    }
}
