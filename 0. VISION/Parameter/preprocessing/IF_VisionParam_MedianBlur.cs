using ImageProcessing;
using System;
using System.ComponentModel;

namespace IntelligentFactory._0._VISION.Parameter
{
    [Serializable]
    public class IF_VisionParam_MedianBlur : IF_ImageProcessing
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute("커널 사이즈 (최소 : 3 / 홀수)"), DisplayNameAttribute("KernerSize")]
        public int KernerSize { get; set; } = 3;

        public IF_VisionParam_MedianBlur()
        {
            KernerSize = 3;
        }

    }
}
