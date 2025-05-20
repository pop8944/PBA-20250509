using ImageProcessing;
using OpenCvSharp;
using System;
using System.ComponentModel;

namespace IntelligentFactory._0._VISION.Parameter
{
    [Serializable]
    public class IF_VisionParam_SobelFilter : IF_ImageProcessing
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute("출력 이미지의 깊이"), DisplayNameAttribute("MatType")]
        public MatType MatType { get; set; } 

        [CategoryAttribute("Parameter"), DescriptionAttribute("x 방향 미분 차수 (1: 1차미분)"), DisplayNameAttribute("OrderX")]
        public int OrderX { get; set; } = 1;

        [CategoryAttribute("Parameter"), DescriptionAttribute("y 방향 미분 차수 (1: 1차미분)"), DisplayNameAttribute("OrderY")]
        public int OrderY { get; set; } = 1;

        [CategoryAttribute("Parameter"), DescriptionAttribute("커널 사이즈 (기본값:3)"), DisplayNameAttribute("KernerSize")]
        public int KernerSize { get; set; } = 3;

        [CategoryAttribute("Parameter"), DescriptionAttribute("연산 결과의 스케일링 값"), DisplayNameAttribute("Scale")]
        public double Scale { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("결과에 추가할 값"), DisplayNameAttribute("Delta")]
        public double Delta { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("외곽 처리 방식"), DisplayNameAttribute("BorderType")]
        public BorderTypes BorderType { get; set; }

        public IF_VisionParam_SobelFilter()
        {
            MatType = MatType.CV_8U;
            OrderX = 1;
            OrderY = 1;
            KernerSize = 3;
            Scale = 1;
            Delta = 1;
            BorderType = BorderTypes.Reflect;
        }

    }
}
