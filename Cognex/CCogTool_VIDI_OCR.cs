#if VPDL
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;
using System.Drawing;

using Cognex.VisionPro;

using ViDi2;
using ViDi2.Local;

namespace IntelligentFactory
{
    public class CCogTool_ViDi_OCR
    {
        public string NAME { get; set; } = "";

        private ViDi2.Runtime.IControl m_Control;// = new ViDi2.Runtime.Local.Control(GpuMode.Deferred);
        private IWorkspace[] m_workspace;
        private IStream[] m_stream;

        private List<string> m_strResult = new List<string>();
        public List<string> GetResult()
        {
            return m_strResult;
        }

        public CCogTool_ViDi_OCR(string strName, int nWorkSpaceCnt = 1)
        {
            NAME = strName;
            m_Control = new ViDi2.Runtime.Local.Control(GpuMode.Deferred);
            // Initializes all CUDA devices
            m_Control.InitializeComputeDevices(GpuMode.SingleDevicePerTool, new List<int>() { });

            m_workspace = new IWorkspace[nWorkSpaceCnt];
            m_stream = new IStream[nWorkSpaceCnt];
        }

        private string m_strPath = string.Empty;

        public void Initialize(int nWorkSpaceCnt = 1)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /* OCR, VIDI Recipe Open 
         * strPath : .vrws File이 있는 경로 명
         */
        public bool LoadConfig_Manual(string strPath)
        {
            try
            {
                for (int i = 0; i < m_Control.Workspaces.Count; i++)
                {
                    m_Control.Workspaces.Remove(m_workspace[i].UniqueName);
                }

                int nS = strPath.LastIndexOf('\\');
                int nE = strPath.LastIndexOf('.');
                string strWorkName = strPath.Substring(nS + 1, (nE - 1) - nS);
                for (int i = 0; i < m_workspace.Length; i++)
                {// 동일한 WorkSpace 이름은 Control에 등록이 안된다.
                    m_workspace[i] = m_Control.Workspaces.Add($"{strWorkName}{i + 1}", strPath);//{i + 1}
                    m_stream[i] = m_workspace[i].Streams["default"];
                }
                m_strPath = strPath;

                string strworkUniqueName = m_workspace[0].UniqueName;
                string strworkDisplayName = m_workspace[0].DisplayName;

                return true;
            }
            catch (System.Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            return false;
        }
        /* OCR, VIDI Recipe Open 
         * strPath : Recipe File 명
         */
        public bool LoadConfig(string strRecipeName)
        {
            try
            {
                for (int i = 0; i < m_Control.Workspaces.Count; i++)
                {
                    m_Control.Workspaces.Remove(m_workspace[i].UniqueName);
                }

                string strPath = $"{IGlobal.m_MainPJTRoot}\\RECIPE\\{strRecipeName}\\{NAME}.vrws";
                if (LoadConfig_Manual(strPath) == true)
                    return true;
            }
            catch (System.Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            return false;
        }
        public bool SaveConfig(string strRecipeName)
        {// ViDi 툴에서 작업 진행
            try
            {

            }
            catch (System.Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            return false;
        }
        /* VisionPro의 ICogImage 받아서 OCR 진행
         * CogImage : ICogImage 이미지
         * strReadString : 읽은 문자열
         * dblScore : 읽은 문자열의 정확도
         */
        public bool RUN(ICogImage CogImage, out List<string> strReadString, out List<double> dblScore, int nWorkSpaceIndex = 0)
        {
            strReadString = new List<string>();
            dblScore = new List<double>();
            try
            {
                if (m_stream[nWorkSpaceIndex] == null)
                    return false;
                if (CogImage == null)
                    return false;
                Bitmap bmp = CogImage.ToBitmap();
                IImage image = new FormsImage(bmp);

                // allocates a sample with the image
                using (ViDi2.ISample sample = m_stream[nWorkSpaceIndex].CreateSample(image))
                {
                    ITool tool = m_stream[nWorkSpaceIndex].Tools["Read"];

                    // process image with the blue read tool
                    sample.Process(tool);

                    IBlueMarking blueReadMarking = sample.Markings[tool.Name] as IBlueMarking;

                    foreach (IBlueView view in blueReadMarking.Views)
                    {
                        foreach (IMatch match in view.Matches)
                        {
                            strReadString.Add((match as IReadModelMatch).FeatureString);
                            dblScore.Add(match.Score);
                        }
                    }
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            return false;
        }
        /* 이미지 파일 읽어서 OCR 진행
         * strPath : 이미지 파일
         * strReadString : 읽은 문자열
         * dblScore : 읽은 문자열의 정확도
         */
        public bool RUN(string strPath, out List<string> strReadString, out List<double> dblScore, int nWorkSpaceIndex = 0)
        {
            strReadString = new List<string>();
            dblScore = new List<double>();
            try
            {
                // load an image from file
                using (IImage image = new LibraryImage(strPath)) //disposing the image when we do not need it anymore
                {
                    // allocates a sample with the image
                    using (ViDi2.ISample sample = m_stream[nWorkSpaceIndex].CreateSample(image))
                    {
                        ITool tool = m_stream[nWorkSpaceIndex].Tools["Read"];

                        // process image with the blue read tool
                        sample.Process(tool);

                        IBlueMarking blueReadMarking = sample.Markings[tool.Name] as IBlueMarking;

                        foreach (IBlueView view in blueReadMarking.Views)
                        {
                            foreach (IMatch match in view.Matches)
                            {
                                strReadString.Add((match as IReadModelMatch).FeatureString);
                                dblScore.Add(match.Score);
                            }
                        }
                        return true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            return false;
        }
    }
}

#endif