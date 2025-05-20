using ImageProcessing;
using OpenCvSharp;
using System;
using System.ComponentModel;

namespace IntelligentFactory._0._VISION.Parameter
{
    [Serializable]
    public class IF_VisionParam_Perspective : IF_ImageProcessing
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute("소스 이미지의 코너 좌표 (좌상)"), DisplayNameAttribute("SrcPointLT")]
        public float SrcPointLT { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("소스 이미지의 코너 좌표 (우상)"), DisplayNameAttribute("SrcPointRT")]
        public float SrcPointRT { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("소스 이미지의 코너 좌표 (좌하)"), DisplayNameAttribute("SrcPointLB")]
        public float SrcPointLB { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("소스 이미지의 코너 좌표 (우하)"), DisplayNameAttribute("SrcPointRB")]
        public float SrcPointRB { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("출력 이미지의 코너 좌표 (좌상)"), DisplayNameAttribute("DstPointLT")]
        public float DstPointLT { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("출력 이미지의 코너 좌표 (우상)"), DisplayNameAttribute("DstPointRT")]
        public float DstPointRT { get; set; }
        
        [CategoryAttribute("Parameter"), DescriptionAttribute("출력 이미지의 코너 좌표 (좌하)"), DisplayNameAttribute("DstPointLB")]
        public float DstPointLB { get; set; }  
        
        [CategoryAttribute("Parameter"), DescriptionAttribute("출력 이미지의 코너 좌표 (우하)"), DisplayNameAttribute("DstPointRB")]
        public float DstPointRB { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("출력 이미지의 크기(출력 이미지 코너 좌표와 맞춰야함)"), DisplayNameAttribute("DstSizeX")]
        public int DstSizeX { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("출력 이미지의 크기(출력 이미지 코너 좌표와 맞춰야함)"), DisplayNameAttribute("DstSizeY")]
        public int DstSizeY { get; set; }

        public IF_VisionParam_Perspective()
        {
            SrcPointLT = 1;
            SrcPointRT = 1;
            SrcPointLB = 2;
            SrcPointRB = 2;
            DstPointLT = 1;
            DstPointRT = 1;
            DstPointLB = 2;
            DstPointRB = 2;
            DstSizeX = 1;
            DstSizeY = 1;
        }

    }
}
