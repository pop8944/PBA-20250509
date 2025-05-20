using ImageProcessing;
using OpenCvSharp;
using System;
using System.ComponentModel;

namespace IntelligentFactory._0._VISION.Parameter
{
    [Serializable]
    public class IF_VisionParam_Binarization : IF_ImageProcessing
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Threshold Type"), TypeConverter(typeof(BooleanConverter))]
        
        public bool ThresholdType { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Threshold Value")]
        public double ThresholdValue { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Max Value")]
        public double MaxValue { get; set; }


        public IF_VisionParam_Binarization()
        {
            ThresholdType = false;
            ThresholdValue = 100;
            MaxValue = 100;
        }

    }
}
