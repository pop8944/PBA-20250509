using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFOnnxRuntime
{
    public static class YUtil
    {
        public static Mat Letterbox_img(Mat image)
        {
            int num = ((image.Cols > image.Rows) ? image.Cols : image.Rows);
            Mat mat = Mat.Zeros(num, num, MatType.CV_8UC3);
            mat *= 255.0;
            Rect roi = new Rect(0, 0, image.Cols, image.Rows);
            image.CopyTo(new Mat(mat, roi));
            return mat;
        }
    }
}
