using Cognex.VisionPro;
using OpenCvSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;

namespace IntelligentFactory
{
    public class CogRecentImage
    {
        public CogImage24PlanarColor[] recentImages = new CogImage24PlanarColor[5];
        public string Name;
        public string DateTime;

        public CogRecentImage()
        {
            //recentImages = new CogImage24PlanarColor[5]
            //{
            //     new CogImage24PlanarColor(),
            //     new CogImage24PlanarColor(),
            //     new CogImage24PlanarColor(),
            //     new CogImage24PlanarColor(),
            //     new CogImage24PlanarColor()
            //};
        }

    }

    public class QRParser
    {
        private bool errorQR = true;
        private string strPBA;
        private string strModel;
        private string strVender;
        private string strYMS;
        private string strSerialNo;
        private System.Drawing.Point ptDraw;

        public QRParser()
        {
            strPBA = "";
            strModel = "";
            strVender = "";
            strYMS = "";
            strSerialNo = "";
            errorQR = true;
        }

        public QRParser(string strQR, bool bError)
        {
            strPBA = strQR.Substring(0, 2);
            strModel = strQR.Substring(strPBA.Length, 10);
            //test 수정
            strVender = strQR.Substring(strPBA.Length + strModel.Length, 4);
            //strVender = strQR.Substring(strPBA.Length + strModel.Length, 3);
            strYMS = strQR.Substring(strPBA.Length + strModel.Length + strVender.Length, 3);
            strSerialNo = strQR.Substring(strPBA.Length + strModel.Length + strVender.Length + strYMS.Length);
            errorQR = bError;
        }

        public string GetPBA()
        {
            return strPBA;
        }

        public string GetModel()
        {
            return strModel;
        }

        public string GetVendor()
        {
            return strVender;
        }

        public string GetYMS()
        {
            return strYMS;
        }

        public string GetSerialNo()
        {
            return strSerialNo;
        }

        public string GetQR()
        {
            return strPBA + strModel + strVender + strYMS + strSerialNo;
        }

        public bool IsError()
        {
            return errorQR;
        }

        public string GetQRTitle()
        {
            return strPBA + strModel + strVender + strYMS;
        }

        public void SetQRTitle(QRParser inQR)
        {
            strPBA = inQR.GetPBA();
            strModel = inQR.GetModel();
            strVender = inQR.GetVendor();
            strYMS = inQR.GetYMS();
        }

        public void SetQRError(bool bError)
        {
            errorQR = bError;
        }

        public void SetPt(System.Drawing.Point pt)
        {
            ptDraw = pt;
        }

        public System.Drawing.Point GetPt()
        {
            return ptDraw;
        }
    }

    public class IData
    {
        public string StopReason = "IDLE";
        public List<CogRecentImage> cogRecentImages = new List<CogRecentImage>();
        public ConcurrentQueue<CGrabBuffer> GrabQueue = new ConcurrentQueue<CGrabBuffer>();

        public bool[] ArrayResults;
        #region COUNT

        public int CountOK = 0;
        public int CountNG_T = 0;
        public int CountNG_F = 0;
        public string yield;
        public string Last_Reset_D;

        public int CountOK_M = 0;
        public int CountNG_M = 0;
        public string CountYield_M;
        public string Last_Reset_M;
        #endregion COUNT

        #region FLAG

        public bool MODE_IO_BOARD = true;
        public bool MODE_BCR_PASS = false;
        public bool MODE_USE_MES = false;
        public bool MODE_USE_DRY_RUN = false;

        public bool IsCycleStart = false;
        public int InspIndex = 0;
        public int MAX_CELL_COUNT = 10;

        public bool[] HEAD_USE_INFO = new bool[10] { false, false, false, false, false, false, false, false, false, false };
        public bool[] HEAD_USE_RESULT_DIST = new bool[10] { false, false, false, false, false, false, false, false, false, false };
        public bool[] HEAD_USE_RESULT_BCR = new bool[10] { false, false, false, false, false, false, false, false, false, false };
        public string[] HEAD_CELL_BCR = new string[10] { "", "", "", "", "", "", "", "", "", "" };

        #endregion FLAG

        #region RESULT

        public bool Result_CAM1; //결과
        public bool Result_CAM2;
        public string IdData_CAM1; //ID DATA
        public string IdData_CAM2;

        public QRParser[] Array_QrCodes = new QRParser[4];
        public int[] Result_NG_Count = new int[4];
        public bool CodeCompare_CAM1;
        public bool CodeCompare_CAM2;

        public string Buffer_ID;
        public string Selected_Buffer_ID;
        public int Buffer_SlotNum;

        public QRParser GetStandardQR()
        {
            QRParser cStandardQR = Array_QrCodes[0];
            for (int i = 0; i < Array_QrCodes.Length; i++)
            {
                if (!Array_QrCodes[i].IsError())
                    cStandardQR = Array_QrCodes[i];
            }
            return cStandardQR;
        }

        #endregion RESULT

        #region I/O CHECK

        public bool In_trigger = false;
        public bool Out_OK = false;
        public bool Out_NG = false;

        #endregion I/O CHECK

        public IData()
        {
            //CUtil.InitDirectory("DATA");
        }

        public void ResetTotalCount()
        {
            CountOK = 0;
            CountNG_T = 0;
            CountNG_F = 0;
        }
        public void ResetTotalCount_M()
        {
            CountOK_M = 0;
            CountNG_M = 0;
        }
        #region CONFIG BY XML

        private string m_XMLName = "LastStatus";

        //public bool LoadConfig()
        //{
        //    try
        //    {
        //        string strPath = $"{IGlobal.m_MainPJTRoot}\\LastStatus.xml";

        //        if (File.Exists(strPath))
        //        {
        //            XmlTextReader xmlReader = new XmlTextReader(strPath);

        //            try
        //            {
        //                LoadConfigFromXML(xmlReader);
        //            }
        //            catch (Exception ex)
        //            {
        //                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
        //                xmlReader.Close();
        //            }

        //            xmlReader.Close();
        //        }
        //        else
        //        {
        //            SaveConfig();
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
        //        return false;
        //    }
        //    return true;
        //}

        public bool LoadConfigFromXML(XmlReader xmlReader)
        {
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    CLogger.Add(LOG.NORMAL, "CONFIG [{0}] ==> {1}", xmlReader.Name, xmlReader.Value);

                    switch (xmlReader.Name)
                    {
                        case "Threshold":
                            if (!xmlReader.Read()) return false;
                            //Tools[nIndex].Threshold = int.Parse(xmlReader.Value);
                            break;
                    }
                }
                else
                {
                    if (xmlReader.NodeType == XmlNodeType.EndElement)
                    {
                        if (xmlReader.Name == m_XMLName) break;
                    }
                }
            }

            CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            return true;
        }

        public bool SaveConfig()
        {
            string strPath = $"{Global.m_MainPJTRoot}\\LastStatus.xml";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\r\n";
            XmlWriter xmlWriter = XmlWriter.Create(strPath, settings);
            try
            {
                xmlWriter.WriteStartDocument();
                SaveConfigToXML(xmlWriter);
                xmlWriter.WriteEndDocument();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                xmlWriter.Flush();
                xmlWriter.Close();
            }
            return true;

            //CLogger.Add(LOG_TYPE.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            //return true;
        }

        public bool SaveConfigToXML(XmlWriter xmlWriter)
        {
            try
            {
                xmlWriter.WriteStartElement("Parameter");
                //xmlWriter.WriteElementString("Threshold", Tools[nIndex].Threshold.ToString());
                xmlWriter.WriteEndElement();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

            return true;
        }

        #endregion CONFIG BY XML
    }

    public class CGrabBuffer
    {
        public int Index = 0;
        public CogImage8Grey ImageGrab = null;
        public IntPtr Handle = IntPtr.Zero;

        public Mat MatImage = new Mat();

        public CGrabBuffer(CogImage8Grey image, int nIndex)
        {
            try
            {
                Index = nIndex;
                // 나중에 메모리 증가 사유일수 있음(Deep/Slow 확인 필요)
                ImageGrab = image.Copy();
            }
            catch (Exception Desc)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc);
            }
        }
    }
}