using Cognex.VisionPro;
using Cognex.VisionPro.ImageProcessing;
using System.Threading.Tasks;

namespace IntelligentFactory
{
    public class CCogTool_CopyRegion
    {
        public string NAME { get; set; } = "";
        private CogCopyRegion m_cogTool = new CogCopyRegion();

        public CogCopyRegion Tool
        {
            get => m_cogTool;
            set => m_cogTool = value;
        }

        public CCogTool_CopyRegion() : this("CCogTool_CopyRegion")
        {
        }

        public CCogTool_CopyRegion(string strName)
        {
            NAME = strName;
            Tool = new CogCopyRegion();
        }

        public ICogImage Run(ICogImage cogImage, CogRectangle cogROI)
        {
            return Tool.Execute((ICogImage)cogImage, (ICogRegion)cogROI, null, out bool bSourceClipped, out bool bDestinationClipped, out ICogRegion region);
        }

        public ICogImage Run(ICogImage cogImage, CogRectangleAffine cogROI)
        {
            return Tool.Execute((ICogImage)cogImage, (ICogRegion)cogROI, null, out bool bSourceClipped, out bool bDestinationClipped, out ICogRegion region);
        }

        public async Task<ICogImage> Run(CogImage8Grey cogImage, CogRectangle cogROI)
        {
            await Task.Delay(1);

            return Tool.Execute((ICogImage)cogImage, (ICogRegion)cogROI, null, out bool bSourceClipped, out bool bDestinationClipped, out ICogRegion region);
        }
    }
}