using ImageProcessing;
using OpenCvSharp;
using System;
using System.ComponentModel;

namespace IntelligentFactory._0._VISION.Parameter
{
    [Serializable]
    public class IF_VisionParam_CannyFilter : IF_ImageProcessing
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Low Threshold")]
        public double LowThreshold { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("High Threshold")]
        public double HighThreshold { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Aperture Size")]
        public int ApertureSize { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("L2Gradient")]
        public bool L2Gradient { get; set; }

        public IF_VisionParam_CannyFilter()
        {
            LowThreshold = 10;
            HighThreshold = 10;
            ApertureSize = 10;
            L2Gradient = false;
        }

    }
}
