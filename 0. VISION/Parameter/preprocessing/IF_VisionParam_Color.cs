using ImageProcessing;
using OpenCvSharp;
using System;
using System.ComponentModel;

namespace IntelligentFactory
{
    [Serializable]
    public class IF_VisionParam_Color : IF_ImageProcessing
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute("색상 공간 변환 코드"), DisplayNameAttribute("ColorConversionCodes")]
        public ColorConversionCodes CCC { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("출력 채널수 (기본값 : 0 / 0이면 자동 출력)"), DisplayNameAttribute("dstCn")]
        public int DstCn { get; set; }


        public IF_VisionParam_Color()
        {
            CCC = 0;
            DstCn = 0;
        }

    }
}
