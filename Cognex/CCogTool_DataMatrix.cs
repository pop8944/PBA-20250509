using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ID;
using System.Drawing;

namespace IntelligentFactory
{
    public static class CCogTool_DataMatrix
    {
        public static string DMRead(CogDisplay DispMain, CogImage8Grey img, System.Drawing.Rectangle roi, out ICogGraphic resultGraphic)

        {
            string resultCode = "";
            resultGraphic = null;

            CogRectangle cogRegion = new CogRectangle
            {
                X = roi.X,
                Y = roi.Y,
                Width = roi.Width,
                Height = roi.Height,
                GraphicDOFEnable = CogRectangleDOFConstants.All,
                Interactive = true
            };

            using (CogIDTool tool = new CogIDTool())
            {
                tool.InputImage = img;

                tool.RunParams.ProcessingMode = CogIDProcessingModeConstants.IDMax;
                tool.Region = CConverter.RectToCogRect(roi);
                tool.HasChanged = false;
                tool.RunParams.DisableAllCodes();
                tool.RunParams.DataMatrix.Enabled = true;
                // tool.RunParams.QRCode.Enabled = true;

                tool.Run();


                if (tool.Results == null) return "";

                if (tool.Results.Count > 0)
                {
                    resultCode = tool.Results[0].DecodedData.DecodedString;
                    resultGraphic = tool.Results[0].CreateResultGraphics(Cognex.VisionPro.ID.CogIDResultGraphicConstants.All);

                    CogGraphicLabel cogGraphicLabel = new CogGraphicLabel();

                    cogGraphicLabel.X = tool.Results[0].CenterX;
                    cogGraphicLabel.Y = tool.Results[0].CenterY;
                    cogGraphicLabel.Text = resultCode;
                    cogGraphicLabel.Font = new Font("Tahoma", 20, FontStyle.Bold, GraphicsUnit.Pixel);


                    DispMain.StaticGraphics.Add(cogGraphicLabel, "");
                    return resultCode;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}

