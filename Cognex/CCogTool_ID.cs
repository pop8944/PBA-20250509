using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ID;
// using Cognex.VisionPro.Dimensioning;
using System.Drawing;

namespace IntelligentFactory
{
    public static class IDTool
    {
        /// <summary>
        /// 이미지에서 코드(DataMatrix 및/또는 QR)를 읽고 결과를 디스플레이에 표시합니다.
        /// </summary>
        /// <param name="display">결과 그래픽을 표시할 Cognex 디스플레이 객체입니다.</param>
        /// <param name="img">코드를 읽을 CogImage8Grey 이미지입니다.</param>
        /// <param name="roi">관심 영역(Rectangle)입니다. Rectangle.Empty일 경우 전체 이미지를 사용합니다.</param>
        /// <param name="resultGraphic">인식 결과로 생성된 그래픽(테두리 등)입니다.</param>
        /// <returns>인식된 코드 문자열입니다. 인식 실패 시 빈 문자열을 반환합니다.</returns>
        public static string Read(CogDisplay display, CogImage8Grey img, System.Drawing.Rectangle roi, out ICogGraphic resultGraphic)
        {
            string resultCode = "";
            resultGraphic = null; 

            if (img == null)
            {
                return "";
            }

            using (CogIDTool tool = new CogIDTool())
            {
                tool.InputImage = img;

                if (roi != System.Drawing.Rectangle.Empty)
                {
                    tool.Region = CConverter.RectToCogRect(roi);
                }
                else
                {
                    tool.Region = null;
                }

                tool.RunParams.DisableAllCodes(); 
                tool.RunParams.DataMatrix.Enabled = true;
                tool.RunParams.ProcessingMode = CogIDProcessingModeConstants.IDMax;
                tool.HasChanged = false;
                tool.Run();

                if (tool.Results != null && tool.Results.Count > 0)
                {
                    CogIDResult idResult = tool.Results[0];
                    resultCode = idResult.DecodedData.DecodedString;

                    resultGraphic = idResult.CreateResultGraphics(CogIDResultGraphicConstants.All);

                    if (display != null && display.StaticGraphics != null)
                    {
                        CogGraphicLabel cogGraphicLabel = new CogGraphicLabel();
                        cogGraphicLabel.X = idResult.CenterX; // 결과의 X 중심 좌표
                        cogGraphicLabel.Y = idResult.CenterY; // 결과의 Y 중심 좌표
                        cogGraphicLabel.Text = resultCode;
                        cogGraphicLabel.Font = new Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Pixel); // 폰트 설정 (크기 등 조절 가능)
                        cogGraphicLabel.Color = CogColorConstants.Green; // 라벨 색상 설정
                        cogGraphicLabel.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter; // 정렬 설정

                        // display.StaticGraphics.Clear(); // 이전 그래픽을 지우려면 주석 해제
                        display.StaticGraphics.Add(cogGraphicLabel, "LblDataMatrixData");
                    }
                }
            }
            return resultCode;
        }
    }
}