using ImageProcessing;
using OpenCvSharp;
using System;
using System.ComponentModel;

namespace IntelligentFactory._0._VISION.Parameter
{
    [Serializable]
    public class IF_VisionParam_DFT : IF_ImageProcessing
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("DFT Flags")]
        public DftFlags Flag { get; set; } = DftFlags.None;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Nonzero Rows")]
        public int NonzeroRows { get; set; } = 0;

        public IF_VisionParam_DFT()
        {
            Flag = DftFlags.None;
            NonzeroRows = 0;
        }

    }
}
