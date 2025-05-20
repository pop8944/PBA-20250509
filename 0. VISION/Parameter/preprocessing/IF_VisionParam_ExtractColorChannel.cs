using ImageProcessing;
using System;
using System.ComponentModel;

namespace IntelligentFactory._0._VISION.Parameter
{
    [Serializable]
    public class IF_VisionParam_ExtractColorChannel : IF_ImageProcessing
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute("추출 하려는 컬러 채널 번호"), DisplayNameAttribute("Channel Number")]
        public int Number { get; set; } // 0:B, 1:G, 2:R


        public IF_VisionParam_ExtractColorChannel()
        {
            Number = 0;
        }

    }
}
