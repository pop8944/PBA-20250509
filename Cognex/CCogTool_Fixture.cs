using Cognex.VisionPro;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.PMAlign;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class CCogTool_Fixture
    {
        public string NAME { get; set; } = "";

        private CogFixtureTool m_cogFixtureTool = new CogFixtureTool();

        public CogFixtureTool Tool
        {
            get => m_cogFixtureTool;
            set => m_cogFixtureTool = value;
        }

        public CCogTool_Fixture(string strName)
        {
            NAME = strName;
        }

        private string m_strPath = string.Empty;

        public bool FixtureUSE = false;

        public double Origin_Translation_X = 0;
        public double Origin_Translation_Y = 0;

        public bool LoadConfig(string strRecipe)
        {
            try
            {
                string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\{NAME}.vpp";
                if (CogSerializer.LoadObjectFromFile(strPath) is CogPMAlignTool)
                {
                    m_strPath = strPath;
                    m_cogFixtureTool = CogSerializer.LoadObjectFromFile(strPath) as CogFixtureTool;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            return true;
        }

        public bool LoadConfig_Manual(string strPath)
        {
            try
            {
                if (CogSerializer.LoadObjectFromFile(strPath) is CogPMAlignTool)
                {
                    m_strPath = strPath;
                    m_cogFixtureTool = CogSerializer.LoadObjectFromFile(strPath) as CogFixtureTool;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            return true;
        }

        public void SaveConfig(string strRecipe)
        {
            try
            {
                string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\{NAME}.vpp";
                CogSerializer.SaveObjectToFile(m_cogFixtureTool, strPath, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public bool Run(ICogImage imgSource, ICogTransform2D pos, out CogImage8Grey outputimage)
        {
            if (Tool == null)
            {
                MessageBox.Show("Fixture Tool is Empty");
                outputimage = null;
                return false;
            }

            Tool.InputImage = imgSource;

            if (Tool.InputImage == null)
            {
                MessageBox.Show("Fixture Tool Source Image is Empty");
                outputimage = null;
                return false;
            }

            Tool.RunParams.UnfixturedFromFixturedTransform = pos;
            Tool.Run();

            outputimage = (CogImage8Grey)Tool.OutputImage;

            return true;
        }

        public bool Run(CogImage8Grey imgSource, CogTransform2DLinear Transform, out ICogImage imgOutput)
        {
            if (Tool == null)
            {
                imgOutput = null;
                return false;
            }

            Tool.InputImage = imgSource;
            Tool.RunParams.UnfixturedFromFixturedTransform = Transform;
            Tool.RunParams.SpaceToOutput = CogFixtureSpaceToOutputConstants.FixturedSpace;
            Tool.RunParams.Action = CogFixtureActionConstants.EstablishNewFixture;
            Tool.RunParams.FixturedSpaceNameDuplicateHandling = CogFixturedSpaceNameDuplicateHandlingConstants.Enhanced;
            Tool.Run();

            imgOutput = Tool.OutputImage;

            return true;
        }
    }
}