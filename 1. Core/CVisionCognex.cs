using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.PMAlign;
using System.Drawing;

namespace IntelligentFactory
{
    public static class CVisionCognex
    {
        public static void TrainGraphic(CogPMAlignTool tool, CogDisplay cogTrainDisplay)
        {
            cogTrainDisplay.StaticGraphics.AddList(tool.Pattern.CreateGraphicsCoarse(CogColorConstants.Yellow), "C");
        }

        public static Rectangle CogRectToRectangle(CogRectangle cogRect)
        {
            if (cogRect == null)
            {
                return new Rectangle(0, 0, 250, 250);
            }
            else
            {
                return new Rectangle((int)cogRect.X, (int)cogRect.Y, (int)cogRect.Width, (int)cogRect.Height);
            }
        }

        public static CogRectangle RectangleToCogRect(Rectangle rect)
        {
            CogRectangle cogRect = new CogRectangle();
            cogRect.X = rect.X;
            cogRect.Y = rect.Y;
            cogRect.Width = rect.Width == 0 ? 250 : rect.Width;
            cogRect.Height = rect.Height == 0 ? 250 : rect.Height;
            return cogRect;
        }

        public static CogPMAlignResult GetBestResult_PMAlign(CogPMAlignTool tool)
        {
            if (tool == null) return null;
            if (tool.Results == null) return null;
            if (tool.Results.Count == 0) return null;

            CogPMAlignResult result_Best = null;
            double dMaxScore = 0.0D;

            for (int i = 0; i < tool.Results.Count; i++)
            {
                if (dMaxScore < tool.Results[i].Score)
                {
                    dMaxScore = tool.Results[i].Score;
                    result_Best = tool.Results[i];
                }
            }

            return result_Best;
        }

        public static Rectangle PatternToRect(CogPMAlignTool tool, CogPMAlignResult result)
        {
            return new Rectangle((int)(result.GetPose().TranslationX - tool.Pattern.GetTrainedPatternImage().Width / 2), (int)(result.GetPose().TranslationY - tool.Pattern.GetTrainedPatternImage().Height / 2), tool.Pattern.GetTrainedPatternImage().Width, tool.Pattern.GetTrainedPatternImage().Height);
        }
    }
}