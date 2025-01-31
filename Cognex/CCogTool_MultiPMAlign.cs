using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IntelligentFactory
{
    public class CCogTool_MultiPMAlign
    {
        public string NAME { get; set; } = "";

        private CogPMAlignMultiTool m_cogMultiPMAlignTool = new CogPMAlignMultiTool();

        public CogPMAlignMultiTool Tool
        {
            get => m_cogMultiPMAlignTool;
            set => m_cogMultiPMAlignTool = value;
        }

        private CogPMAlignMultiResults m_ResultMultiPMAlign = new CogPMAlignMultiResults();

        public CogPMAlignMultiResults Result
        {
            get { return m_ResultMultiPMAlign; }
            set { m_ResultMultiPMAlign = value; }
        }

        public CCogTool_MultiPMAlign(string strName)
        {
            NAME = strName;
        }

        private string m_strPath = string.Empty;

        public List<CogPMAlignTool> cogPMAlignTools = new List<CogPMAlignTool>();

        private CogPMAlignTool m_cogPMAlignTool = new CogPMAlignTool();

        public CogPMAlignTool PMAlign
        {
            get => m_cogPMAlignTool;
            set => m_cogPMAlignTool = value;
        }

        public bool LoadConfig(string strRecipe)
        {
            try
            {
                string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\{NAME}.vpp";
                if (CogSerializer.LoadObjectFromFile(strPath) is CogPMAlignMultiTool)
                {
                    m_strPath = strPath;
                    m_cogMultiPMAlignTool = CogSerializer.LoadObjectFromFile(strPath) as CogPMAlignMultiTool;
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
                if (CogSerializer.LoadObjectFromFile(strPath) is CogPMAlignMultiTool)
                {
                    m_strPath = strPath;
                    m_cogMultiPMAlignTool = CogSerializer.LoadObjectFromFile(strPath) as CogPMAlignMultiTool;
                    m_cogMultiPMAlignTool.RunParams.PMAlignRunParams.ScoreUsingClutter = false;
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
                CogSerializer.SaveObjectToFile(m_cogMultiPMAlignTool, strPath, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public void SaveConfig_Manual(string strPath)
        {
            try
            {
                CogSerializer.SaveObjectToFile(m_cogMultiPMAlignTool, strPath, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public void train()
        {
            CogPMAlignPattern alignPattern = new CogPMAlignPattern();
            CogPMAlignPatternItem cogPMAlignPatternItem = new CogPMAlignPatternItem();

            cogPMAlignPatternItem.Pattern.Train();
            List<CogPMAlignPatternItem> list = new List<CogPMAlignPatternItem>();
            list.Add(cogPMAlignPatternItem);
            Tool.Operator.Add(list[0]);
        }

        public CogPMAlignResults MultiPattern_Run(CogPMAlignMultiTool tool, ICogImage image)
        {
            try
            {
                CogPMAlignResults cogPMAlignResults = new CogPMAlignResults();
                List<CogPMAlignResults> cogPMAlign = new List<CogPMAlignResults>();
                List<double> PatterScore = new List<double>();
                double MaxVal;
                int Maxindex;
                if (tool.Operator.Count > 0)
                {
                    for (int i = 0; i < tool.Operator.Count; i++)
                    {
                        tool.RunParams.PMAlignRunParams.SearchRegionMode = CogRegionModeConstants.PixelAlignedBoundingBoxAdjustMask;
                        cogPMAlignResults = tool.Operator[i].Pattern.Execute(image, tool.SearchRegion, tool.RunParams.PMAlignRunParams);

                        if (cogPMAlignResults != null && cogPMAlignResults.Count != 0)
                        {
                            PatterScore.Add(cogPMAlignResults[0].Score);
                            cogPMAlign.Add(cogPMAlignResults);
                        }
                    }

                    if (PatterScore != null)
                    {
                        MaxVal = PatterScore.Max();
                        Maxindex = PatterScore.IndexOf(MaxVal);
                        double tm = cogPMAlign[Maxindex][0].Score;

                        return cogPMAlign[Maxindex];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }
    }
}