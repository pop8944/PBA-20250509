using Cognex.VisionPro.Caliper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Xml.Serialization;
using JsonException = System.Text.Json.JsonException;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace IntelligentFactory
{
    // 신규 추가 알고리즘 잡 클래스
    public class FIN_Algorithm
    {
        // 핀검출을 위한 알고리즘 내용 목록...
        // 핀 검출을 위해서는 매칭과 블랍을 혼용해서 사용...
        string Name = "";
        public CTemplateMatching FINFIND_MatchingTool = new CTemplateMatching("Fin");
        public Rectangle BlobSearchRoi { get; set; } = new Rectangle(0, 0, 100, 100);
        public System.Drawing.Point BlobAlignOffset { get; set; } = new System.Drawing.Point();
        public int BlobAreaMin { get; set; } = 100;
        public int BlobAreaMax { get; set; } = 100;
        public int BlobThreshold { get; set; } = 125;
        public bool BlobThresholdInv { get; set; } = false;

        public double Center_X { get; set; } = 0.0D;
        public double Center_Y { get; set; } = 0.0D;

        public FIN_Algorithm(string _name)
        {
            Name = _name;
        }
    }

    public static class JOB_TYPE
    {
        public const string Pattern = "Pattern";
        public const string Color = "Color";
        public const string Find = "Find";
        public const string Distance = "Distance";
        public const string Condensor = "Condensor";
        public const string Blob = "Blob";
        public const string EYED = "EYE-D";
        public const string ColorEx = "ColorEx";
        public const string Pin = "Pin";
        public const string Connector = "Connector";
    }

    internal class GFG : IComparer<CJob>
    {
        public int Compare(CJob x, CJob y)
        {
            if (x.Name.CompareTo(y.Name) == 0)
                return 0;

            return x.Name.CompareTo(y.Name);
        }
    }

    [Serializable]
    public class CInspJobs
    {
        public List<CJob> Jobs { get; set; } = new List<CJob>();
        //public List<string> EnabledJobs_Library { get; set; } = new List<string>();

        public CInspJobs()
        {
        }

        #region CONFIG BY XML

        public CInspJobs LoadNUpdateConfig(string strRecipe_path, int nIndex/*, bool bLibrary = false*/)
        {
            CInspJobs retConfig = LoadConfig(strRecipe_path, nIndex /*bLibrary*/);
            retConfig = AdjustConfig(retConfig);

            return retConfig;
        }

        public CInspJobs LoadConfig(string strRecipe, int nIndex/*, bool bLibrary = false*/)
        {
            CInspJobs newData = null;
            if (!Directory.Exists(strRecipe)) Directory.CreateDirectory(strRecipe);
            string strPath = Path.Combine(strRecipe, $"Jobs{nIndex}.xml");

            newData = SerializeHelper.FromXmlFile<CInspJobs>(strPath);
            if (newData != null)
            {
                GFG cmp = new GFG();
                newData.Jobs.Sort(cmp);
                //newData.Jobs.Sort(); - 여기를 name으로 정렬
            }

            newData = AdjustConfig(newData);
            return newData;
        }

        // 임시로 Recipe를 조정한다.
        public CInspJobs AdjustConfig(CInspJobs inJobs)
        {
            if (inJobs == null)
                return null;

            CInspJobs adjustJobs = inJobs;
            for (int i = 0; i < adjustJobs.Jobs.Count; i++)
            {
                CJob job = adjustJobs.Jobs[i];

                // 임시 Color 및 패턴 초기화
                if (job.Type.Contains("Color") && job.CMethod == CJob.ColorMethod.CA_ConvertGray)
                {
                    // 임시로 Color는 CA_ConvertGray, CC_GRAY로 Fix
                    job.CMethod = CJob.ColorMethod.CA_RANGE;
                    job.CCoordinate = CJob.ColorCoordinate.CC_HSV;

                    // 영역 자동 조정
                    //job.SearchRegion.Inflate(100, 100);
                    Rect Rct = CConverter.RectToCVRect(job.SearchRegion);
                    int xAdjust = Rct.Width / 3;
                    int yAdjust = Rct.Height / 3;
                    Rct.Inflate(-xAdjust, -yAdjust);
                    job.valueRect = CConverter.CVRectToRect(Rct);
                }
                else if (job.Type.Contains("Pattern"))
                {
                    // 임시로 패턴은 CA_ConvertGray, CC_GRAY로 Fix
                    //if (job.CMethod != CJob.ColorMethod.CA_ConvertGray)
                    //    job.CMethod = CJob.ColorMethod.CA_ConvertGray;
                    //if (job.CCoordinate != CJob.ColorCoordinate.CC_GRAY)
                    //    job.CCoordinate = CJob.ColorCoordinate.CC_GRAY;
                }
            }

            return adjustJobs;
        }

        public void SaveConfig(string strRecipe, int nIndex/*, bool bLibrary = false*/)
        {
            if (!Directory.Exists(strRecipe)) Directory.CreateDirectory(strRecipe);
            string strPath = $"Jobs{nIndex}.xml";
            string filepath = Path.Combine(strRecipe, strPath);

            if (SerializeHelper.ToXmlFile(filepath, this))
            {

            }

            //if (bLibrary)
            //{
            //    CUtil.InitDirectory($"PBA_LIBRARY\\{strRecipe}\\");

            //    string strPath = $"{IGlobal.m_MainPJTRoot}\\PBA_LIBRARY\\{strRecipe}\\Jobs{nIndex}.xml";
            //    SerializeHelper.ToXmlFile(strPath, this);
            //}
            //else
            //{
            //    CUtil.InitDirectory($"RECIPE\\{strRecipe}\\JOBS");

            //    string strPath = $"{IGlobal.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\JOBS\\Jobs{nIndex}.xml";
            //    SerializeHelper.ToXmlFile(strPath, this);
            //}
        }

        #endregion CONFIG BY XML
    }

    [Serializable]
    public class JobParameter
    {
        #region Option

        public bool UseCropSave { get; set; } = false;

        public bool UseFilter1 { get; set; } = false;
        public bool UseFilter2 { get; set; } = false;
        public CVisionTools.CV_FILTER Filter1 { get; set; } = (CVisionTools.CV_FILTER)1;
        public int Filter1_Kernel_W { get; set; } = 3;
        public int Filter1_Kernel_H { get; set; } = 3;
        public CVisionTools.CV_FILTER Filter2 { get; set; } = (CVisionTools.CV_FILTER)1;
        public int Filter2_Kernel_W { get; set; } = 3;
        public int Filter2_Kernel_H { get; set; } = 3;
        #endregion

        #region Condensor
        public string CondensorPolarity { get; set; } = "T";          // T, B, L, R
        public bool UseCondensorDist { get; set; } = false;
        public int CondensorRectWidth { get; set; } = 50;
        public int CondensorRectHeight { get; set; } = 50;
        public bool CondensorTypeTB { get; set; } = false;
        public int CondensorRadiusOffset { get; set; } = 0;

        #endregion

        #region EYE-D
        public string EyeD_InferType { get; set; } = "DET";
        public string EyeD_ModelName { get; set; }
        public string EyeD_CorrectAnswer { get; set; }
        public int EyeD_MasterCount { get; set; } = 1;
        public int EyeD_MaxCount { get; set; } = 1;
        public double EyeD_MinScore { get; set; } = 0.5;
        public bool EyeD_UseDistance { get; set; } = false;
        public int EyeD_ImageRotateAngle { get; set; } = 0;
        public bool EyeD_UseColorInsp { get; set; } = false;
        public bool EyeD_UseSpecRegion { get; set; } = false;
        public Rectangle EyeD_SpecRegion { get; set; } = new Rectangle(100, 100, 100, 100);
        public string EyeD_CorrectColor { get; set; } = "";
        #endregion

        #region ColorEx
        public bool ColorEx_SimpleMode { get; set; } = false;
        public int ColorEx_Range { get; set; } = 0;
        public ColorNode ColorEx_MasterColor { get; set; } = new ColorNode("", 0, 0, 0, 255, 255, 255);
        #endregion

        #region Pin
        public int Pin_OkCount { get; set; } = 1;
        public int Pin_AreaMin { get; set; } = 10;
        public int Pin_AreaMax { get; set; } = 1000;
        public int Pin_ColorR { get; set; } = 255;
        public int Pin_ColorG { get; set; } = 255;
        public int Pin_ColorB { get; set; } = 255;

        public int Pin_SpecRoiWidth { get; set; } = 50;
        public int Pin_SpecRoiHeight { get; set; } = 50;
        public int Pin_Threshold { get; set; } = 128;
        public bool Pin_BinaryInv { get; set; } = false;
        public bool Pin_ColorMatching { get; set; } = false;
        public List<Rectangle> Pin_Boundaries { get; set; } = new List<Rectangle>();
        #endregion

        #region Connector
        public double Connector_ScoreMin { get; set; } = 0.3;
        public bool Connector_Type_LR { get; set; } = true;
        public bool Connector_LargeFirst { get; set; } = true;
        public int Connector_AreaOK { get; set; } = 10;
        public int Connector_AreaMin { get; set; } = 10;
        public int Connector_AreaMax { get; set; } = 1000;
        public int Connector_BoxWidth { get; set; } = 50;
        public int Connector_BoxHeight { get; set; } = 50;
        public int Connector_Threshold { get; set; } = 128;
        public bool Connector_BinaryInv { get; set; } = false;

        #endregion

        #region Distance
        public bool UseDistanceAngle { get; set; } = false;
        public double DistanceAngleMax { get; set; } = 0.0D;
        public double DistanceAngleMin { get; set; } = 0.0D;
        public bool UseDistanceX { get; set; } = false;
        public double DistanceXMax { get; set; } = 0.0D;
        public double DistanceXMin { get; set; } = 0.0D;
        public bool UseDistanceY { get; set; } = false;
        public double DistanceYMax { get; set; } = 0.0D;
        public double DistanceYMin { get; set; } = 0.0D;
        #endregion
        #region BlobMaster Pos
        public int BlobMasterPos_X { get; set; } = 0;
        public int BlobMasterPos_Y { get; set; } = 0;

        #endregion

        public JobParameter Clone()
        {
            JobParameter newData = null;

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            string value;

            try
            {
                value = JsonSerializer.Serialize(this, options);
                newData = JsonSerializer.Deserialize<JobParameter>(value);
            }
            catch (Exception ex)
            {

            }

            return newData;
        }

        public JobParameter Load(string libraryCode, int arrayIdx, string jobName)
        {
            string path = $"{Global.m_MainPJTRoot}\\PBA_LIBRARY\\{libraryCode}\\Array_{arrayIdx}\\{jobName}.json";
            //string path = $"{libraryCode}\\Array_{arrayIdx}\\{jobName}.json";
            if (Directory.Exists(Path.GetDirectoryName(path))) Directory.CreateDirectory(Path.GetDirectoryName(path));

            JobParameter newData = null;

            if (File.Exists(path))
            {
                try
                {
                    newData = JsonSerializer.Deserialize<JobParameter>(File.ReadAllText(path));
                }
                catch (Exception ex)
                {
                }

                if (newData != null)
                    return newData;
            }

            newData = new JobParameter();
            newData.Save(libraryCode, arrayIdx, jobName);
            return newData;
        }

        public void Save(string libraryCode, int arrayIdx, string jobName)
        {
            string path = $"{Global.m_MainPJTRoot}\\PBA_LIBRARY\\{libraryCode}\\Array_{arrayIdx}\\{jobName}.json";
            //string path = $"{libraryCode}\\Array_{arrayIdx}\\{jobName}.json";
            if (Directory.Exists(Path.GetDirectoryName(path))) Directory.CreateDirectory(Path.GetDirectoryName(path));

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            string currRecipe;

            try
            {
                currRecipe = JsonSerializer.Serialize(this, options);

                if (File.Exists(path))
                {
                    //이전값과 비교하여 바뀐 부분 로깅
                    string prevRecipe = File.ReadAllText(path);

                    JObject previousObject = JObject.Parse(prevRecipe);
                    JObject currentObject = JObject.Parse(currRecipe);

                    var result = JToken.DeepEquals(previousObject, currentObject);

                    if (!result)
                    {
                        foreach (var item in previousObject)
                        {
                            if (!JToken.DeepEquals(item.Value, currentObject[item.Key]))
                            {
                                CLogger.Add(LOG.NORMAL, $"Property '{item.Key}' changed from '{item.Value}' to '{currentObject[item.Key]}'");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("JSON objects are equal");
                    }
                }

                if (jobName == "testD")
                    ;
                File.WriteAllText(path, currRecipe);
            }
            catch (JsonException ex)
            {
                options.IgnoreNullValues = true;
                currRecipe = JsonSerializer.Serialize(this, options);
                File.WriteAllText(path, currRecipe);

                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }

    [Serializable]
    public class CJob
    {
        public bool HasChanged = false;
        //public bool AlreadyPass = false;

        [XmlIgnore, JsonIgnore]
        public JobParameter Parameter { get; set; }

        public enum ColorCoordinate
        {
            CC_GRAY = 0,
            CC_BGR,
            CC_HSV,
            CC_XYZ,
            CC_YUV,
        }

        public enum ColorMethod
        {
            CA_THRESHILD = 0,
            CA_RANGE,
            CA_ConvertGray,
        }

        public string Name { get; set; } = "NEW";
        public string Type { get; set; } = "Pattern";
        public double MinScore { get; set; } = 0.5D;
        public bool Enabled { get; set; } = false;
        public bool Judge_NaisNg = true;

        public bool LC_ReadUse = false;
        public int MasterCount = 1;
        public int SamplingCount = 1;



        public OpenCvSharp.Point2d[] MasterPosition = new OpenCvSharp.Point2d[4] { new OpenCvSharp.Point2d(0, 0), new OpenCvSharp.Point2d(0, 0), new OpenCvSharp.Point2d(0, 0), new OpenCvSharp.Point2d(0, 0) };

        public int GrabIndex { get; set; } = 0;

        public Rectangle SearchRegion { get; set; } = new Rectangle();
        public Rectangle valueRect { get; set; } = new Rectangle(0, 0, 100, 100);

        public ColorCoordinate CCoordinate { get; set; } = ColorCoordinate.CC_HSV;
        public ColorMethod CMethod { get; set; } = ColorMethod.CA_RANGE;
        public bool useBinary { get; set; } = false;

        public bool isSavePart { get; set; } = false;

        public bool isPatternNone { get; set; } = false;

        public int nPatternIndex = 0;
        public double dRate = 0.0;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("00) Use Color Range")]
        public bool UseColorRange { get; set; } = true;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("00) Min (0)")]
        public int Min0 { get; set; } = 0;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("00) Max (0)")]
        public int Max0 { get; set; } = 255;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("01) Min (1)")]
        public int Min1 { get; set; } = 0;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("01) Max (1)")]
        public int Max1 { get; set; } = 255;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("02) Min (2)")]
        public int Min2 { get; set; } = 0;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("02) Max (2)")]
        public int Max2 { get; set; } = 255;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("03) Range Area Min")]
        public int RangeAreaMin { get; set; } = 0;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("03) Range Area Max")]
        public int RangeAreaMax { get; set; } = 0;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("04) Threshold")]
        public int Threshold { get; set; } = 128;

        public Rectangle drawStringRect { get; set; } = new Rectangle();

        public bool ChkColor = false;

        // Find 알고리즘 추가로인한 job 추가
        public int MinFoundCount { get; set; } = 1;

        // 해당 잡의 검사 Tack Time 기록
        public long Result_TackTime = 0;

        public CJob()
        {
            Tool.Tool.RunParams.RunAlgorithm = Cognex.VisionPro.PMAlign.CogPMAlignRunAlgorithmConstants.PatQuick;
            SubTool1.Tool.RunParams.RunAlgorithm = Cognex.VisionPro.PMAlign.CogPMAlignRunAlgorithmConstants.PatQuick;
            SubTool2.Tool.RunParams.RunAlgorithm = Cognex.VisionPro.PMAlign.CogPMAlignRunAlgorithmConstants.PatQuick;
            SubTool3.Tool.RunParams.RunAlgorithm = Cognex.VisionPro.PMAlign.CogPMAlignRunAlgorithmConstants.PatQuick;
            SubTool4.Tool.RunParams.RunAlgorithm = Cognex.VisionPro.PMAlign.CogPMAlignRunAlgorithmConstants.PatQuick;
        }

        [XmlIgnoreAttribute]
        public CCogTool_PMAlign Tool = new CCogTool_PMAlign("TOOL_MAIN");

        [XmlIgnoreAttribute]
        public CCogTool_PMAlign SubTool1 = new CCogTool_PMAlign("TOOL_SUB1");

        [XmlIgnoreAttribute]
        public CCogTool_PMAlign SubTool2 = new CCogTool_PMAlign("TOOL_SUB2");

        [XmlIgnoreAttribute]
        public CCogTool_PMAlign SubTool3 = new CCogTool_PMAlign("TOOL_SUB3");

        [XmlIgnoreAttribute]
        public CCogTool_PMAlign SubTool4 = new CCogTool_PMAlign("TOOL_SUB4");

        [XmlIgnoreAttribute]
        public CCogTool_OCR OCRTool = new CCogTool_OCR("TOOL_OCR");

        [XmlIgnoreAttribute]
        public CCogTool_PMAlign OCR_Align = new CCogTool_PMAlign("TOOL_Align");

        #region Distance
        [XmlIgnoreAttribute]
        public CogFindLineTool Find_Line = new CogFindLineTool();
        #endregion

        #region Condensor
        [XmlIgnoreAttribute]
        public CogFindCircleTool Find_Circle = new CogFindCircleTool();
        #endregion

        // fin 극성 검출에 사용되는 필요 알고리즘
        //==============================================================
        [XmlIgnoreAttribute]
        public FIN_Algorithm Fin_InspecTool = new FIN_Algorithm("FIN");
        //==============================================================

        public CCogTool_PMAlign GetTool(int nIndex)
        {
            if (nIndex == 0) return Tool;
            if (nIndex == 1) return SubTool1;
            if (nIndex == 2) return SubTool2;
            if (nIndex == 3) return SubTool3;
            if (nIndex == 4) return SubTool4;

            return Tool;
        }

        public CJob Clone()
        {
            try
            {
                CJob from = this;
                CJob to = new CJob();
                int buf_X = 0;
                int buf_Y = 0;
                int buf_Width = 0;
                int buf_Height = 0;
                to.Parameter = from.Parameter.Clone();

                if (from.Type.Contains("Pattern"))
                {
                    to.Name = from.Name;
                    to.Type = from.Type;
                    to.MinScore = from.MinScore;
                    to.Enabled = from.Enabled;
                    to.Judge_NaisNg = from.Judge_NaisNg;
                    to.MasterCount = from.MasterCount;
                    to.GrabIndex = from.GrabIndex;
                    to.MasterPosition = from.MasterPosition;
                    to.SamplingCount = from.SamplingCount;

                    to.SearchRegion = from.SearchRegion;

                    to.Tool.NAME = from.Tool.NAME;
                    to.Tool.Tool = new Cognex.VisionPro.PMAlign.CogPMAlignTool(from.Tool.Tool);

                    to.SubTool1.NAME = from.SubTool1.NAME;
                    to.SubTool1.Tool = new Cognex.VisionPro.PMAlign.CogPMAlignTool(from.SubTool1.Tool);

                    to.SubTool2.NAME = from.SubTool2.NAME;
                    to.SubTool2.Tool = new Cognex.VisionPro.PMAlign.CogPMAlignTool(from.SubTool2.Tool);

                    to.SubTool3.NAME = from.SubTool1.NAME;
                    to.SubTool3.Tool = new Cognex.VisionPro.PMAlign.CogPMAlignTool(from.SubTool3.Tool);

                    to.SubTool4.NAME = from.SubTool1.NAME;
                    to.SubTool4.Tool = new Cognex.VisionPro.PMAlign.CogPMAlignTool(from.SubTool4.Tool);
                }
                else if (from.Type.Contains("Via"))
                {
                    to.Name = from.Name;
                    to.Type = from.Type;
                    to.MinScore = from.MinScore;
                    to.Enabled = from.Enabled;
                    to.Judge_NaisNg = from.Judge_NaisNg;
                    to.MasterCount = from.MasterCount;
                    to.GrabIndex = from.GrabIndex;
                    to.MasterPosition = from.MasterPosition;
                    to.SamplingCount = from.SamplingCount;

                    to.SearchRegion = from.SearchRegion;

                    to.Tool.NAME = from.Tool.NAME;
                    to.Tool.Tool = new Cognex.VisionPro.PMAlign.CogPMAlignTool(from.Tool.Tool);

                    to.SubTool1.NAME = from.SubTool1.NAME;
                    to.SubTool1.Tool = new Cognex.VisionPro.PMAlign.CogPMAlignTool(from.SubTool1.Tool);

                    to.SubTool2.NAME = from.SubTool2.NAME;
                    to.SubTool2.Tool = new Cognex.VisionPro.PMAlign.CogPMAlignTool(from.SubTool2.Tool);

                    to.SubTool3.NAME = from.SubTool1.NAME;
                    to.SubTool3.Tool = new Cognex.VisionPro.PMAlign.CogPMAlignTool(from.SubTool3.Tool);

                    to.SubTool4.NAME = from.SubTool1.NAME;
                    to.SubTool4.Tool = new Cognex.VisionPro.PMAlign.CogPMAlignTool(from.SubTool4.Tool);
                }
                else if (from.Type.Contains("Color"))
                {
                    to.Name = from.Name;
                    to.Type = from.Type;
                    to.Enabled = from.Enabled;
                    to.GrabIndex = from.GrabIndex;
                    to.MasterPosition = from.MasterPosition;

                    to.SearchRegion = from.SearchRegion;

                    to.UseColorRange = from.UseColorRange;
                    to.Min2 = from.Min2;
                    to.Max2 = from.Max2;
                    to.Min1 = from.Min1;
                    to.Max1 = from.Max1;
                    to.Min0 = from.Min0;
                    to.Max0 = from.Max0;
                    to.Threshold = from.Threshold;
                }
                else if (from.Type.Contains("Condensor"))
                {
                    to.Name = from.Name;
                    to.Type = from.Type;
                    to.Enabled = from.Enabled;
                    to.GrabIndex = from.GrabIndex;

                    to.Tool = from.Tool;

                    to.Find_Circle = new CogFindCircleTool(from.Find_Circle);
                }
                else if (from.Type.Contains("Distance"))
                {
                    to.Name = from.Name;
                    to.Type = from.Type;
                    to.Enabled = from.Enabled;
                    to.GrabIndex = from.GrabIndex;

                    to.Tool = from.Tool;

                    to.Find_Line = new CogFindLineTool(from.Find_Line);
                }
                else if (from.Type.Contains("Blob"))
                {
                    to.Name = from.Name;
                    to.Type = from.Type;
                    to.Enabled = from.Enabled;
                    to.GrabIndex = from.GrabIndex;
                    to.Fin_InspecTool.FINFIND_MatchingTool = from.Fin_InspecTool.FINFIND_MatchingTool;

                    to.Tool = from.Tool;
                    to.Parameter = from.Parameter;
                }
                else if (from.Type.Contains("EYE-D"))
                {
                    to.Name = from.Name;
                    to.Type = from.Type;
                    to.Enabled = from.Enabled;
                    to.GrabIndex = from.GrabIndex;
                    to.Parameter.EyeD_InferType = from.Parameter.EyeD_InferType;
                    to.Parameter.EyeD_CorrectAnswer = from.Parameter.EyeD_CorrectAnswer;
                    to.Parameter.EyeD_MasterCount = from.Parameter.EyeD_MasterCount;
                    to.Parameter.EyeD_MaxCount = from.Parameter.EyeD_MaxCount;
                    to.Parameter.EyeD_MinScore = from.Parameter.EyeD_MinScore;
                    to.Parameter.EyeD_UseDistance = from.Parameter.EyeD_UseDistance;
                    to.Parameter.EyeD_ImageRotateAngle = from.Parameter.EyeD_ImageRotateAngle;
                    to.Parameter.EyeD_UseColorInsp = from.Parameter.EyeD_UseColorInsp;
                    to.Parameter.EyeD_UseSpecRegion = from.Parameter.EyeD_UseSpecRegion;
                    to.Parameter.EyeD_CorrectColor = from.Parameter.EyeD_CorrectColor;
                    to.Parameter.EyeD_SpecRegion = new Rectangle(
                                                                from.Parameter.EyeD_SpecRegion.X,
                                                                from.Parameter.EyeD_SpecRegion.Y,
                                                                from.Parameter.EyeD_SpecRegion.Width,
                                                                from.Parameter.EyeD_SpecRegion.Height
                                                                );
                }
                else if (from.Type.Contains("Pin"))
                {
                    to.Name = from.Name;
                    to.Type = from.Type;
                    to.Enabled = from.Enabled;
                    to.GrabIndex = from.GrabIndex;
                    to.Parameter = from.Parameter;
                }
                else if (from.Type.Contains("Connector"))
                {
                    to.Name = from.Name;
                    to.Type = from.Type;
                    to.Enabled = from.Enabled;
                    to.GrabIndex = from.GrabIndex;
                    to.Parameter = from.Parameter;
                    to.Tool = from.Tool;
                }
                to.SearchRegion = from.SearchRegion;

                return to;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
                return new CJob();
            }
        }
    }
}