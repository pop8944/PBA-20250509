using ImageProcessing;
using System;
using System.ComponentModel;

namespace IntelligentFactory
{
    [Serializable]
    public class IF_VisionParam_Affine : IF_ImageProcessing
    {

        [CategoryAttribute("Parameter"), DescriptionAttribute("X축 확대 비율"), DisplayNameAttribute("ScaleX")]
        public double ScaleX { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("X축 기울기"), DisplayNameAttribute("ShearingX")]
        public double ShearingX { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("X축 이동"), DisplayNameAttribute("TranslationX")]
        public double TranslationX { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("Y축 확대 비율"), DisplayNameAttribute("ScaleY")]
        public double ScaleY { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("Y축 기울기"), DisplayNameAttribute("ShearingY")]
        public double ShearingY { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute("Y축 이동"), DisplayNameAttribute("TranslationY")]
        public double TranslationY { get; set; }

        public IF_VisionParam_Affine()
        {
            ScaleX = 10;
            ShearingX = 0;
            TranslationX = 10;
            ScaleY = 1;
            ShearingY = 0;
            TranslationY = 10;
        }

      
    }
}
