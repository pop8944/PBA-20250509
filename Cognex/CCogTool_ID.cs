using Cognex.VisionPro;
using Cognex.VisionPro.ID;

namespace IntelligentFactory
{
    public static class IDTool
    {
        public static string Read(CogImage8Grey img, System.Drawing.Rectangle roi, out ICogGraphic resultGraphic)
        {
            string resultCode = "";
            resultGraphic = null;

            using (CogIDTool tool = new CogIDTool())
            {
                tool.InputImage = img;
                //test
                //Mat dst = (OpenCvSharp.Extensions.BitmapConverter.ToMat(img.ToBitmap())).Clone();
                //Rect cvRoi = new Rect(roi.X, roi.Y, roi.Width, roi.Height);
                //dst = new Mat(dst, cvRoi);
                //Cv2.ImShow("123", dst);
                tool.RunParams.ProcessingMode = CogIDProcessingModeConstants.IDMax;
                tool.Region = CConverter.RectToCogRect(roi);
                tool.HasChanged = false;
                tool.RunParams.DisableAllCodes();
                tool.RunParams.QRCode.Enabled = true;

                tool.Run();

                if (tool.Results == null) return "";

                if (tool.Results.Count > 0)
                {
                    resultCode = tool.Results[0].DecodedData.DecodedString;
                    resultGraphic = tool.Results[0].CreateResultGraphics(Cognex.VisionPro.ID.CogIDResultGraphicConstants.All);
                }
            }

            return resultCode;
        }
    }
}