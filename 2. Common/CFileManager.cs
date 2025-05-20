using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace IntelligentFactory
{
    //PKC 추가
    public class CFileManager
    {
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(String section, String key, String val, String filePath);

        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(String section, String key, String def, StringBuilder retVal, int size, String filePath);

        public bool bLoad = false;
        private String mstr_INIPath;
        //private string m_strMsg;

        public void set_INI_Path(String INIPath)
        {
            mstr_INIPath = INIPath;
        }

        public bool IsExist()
        {
            return File.Exists(mstr_INIPath);
        }

        public void WriteValue(string strSection, string strKey, string strValue, string lstr_INIPath)
        {
            try
            {
                WritePrivateProfileString(strSection, strKey, strValue, lstr_INIPath);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        public string ReadValue(string strSection, string Key, string lstr_INIPath)  //, string lstr_INIPath)
        {
            try
            {
                StringBuilder strValue = new StringBuilder(255);
                int i = GetPrivateProfileString(strSection, Key, "", strValue, 255, lstr_INIPath);
                return strValue.ToString();
            }
            catch
            {
                return "";
            }
        }

        //public void DeleteSection(string strSection) //,string lstr_INIPath)
        //{
        //    WritePrivateProfileString(strSection, null, null, mstr_INIPath);
        //}

        //public bool FileExist(string sFilePath)      //파일의 존재 유무
        //{
        //    System.IO.FileInfo fi = new System.IO.FileInfo(sFilePath);

        //    if (fi.Exists)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public void ImageSave()
        //{
        //}

        private object sync_lock = new object();

        //public void ImageSave(bool result, string FileName, CogImage24PlanarColor ColorImage = null)
        //{
        //    if (ColorImage == null)
        //    {
        //        return;
        //    }

        //    int idx = 1;

        //    string strImagePath = IGlobal.m_MainPJTRoot + "\\" + "_IMG\\";
        //    string strfile = strImagePath + DateTime.Now.ToString("yyyy-MM-dd") + "\\CODE_NG\\RESULT_" + idx + ".png";
        //    string filePath = "";

        //    if (!System.IO.Directory.Exists(strImagePath))
        //    {
        //        System.IO.Directory.CreateDirectory(strImagePath);
        //    }

        //    strImagePath = strImagePath + "\\" + DateTime.Now.ToString("yyyy-MM-dd");
        //    if (!System.IO.Directory.Exists(strImagePath))
        //    {
        //        System.IO.Directory.CreateDirectory(strImagePath);
        //    }

        //    if (FileName == null || FileName == "")
        //    {
        //        strImagePath = strImagePath + "\\CODE_NG";
        //    }
        //    else
        //    {
        //        if (result)
        //        {
        //            strImagePath = strImagePath + "\\" + FileName + "\\OK";
        //        }
        //        else
        //        {
        //            strImagePath = strImagePath + "\\" + FileName + "\\NG";
        //        }
        //    }

        //    if (!System.IO.Directory.Exists(strImagePath))
        //    {
        //        System.IO.Directory.CreateDirectory(strImagePath);
        //    }

        //    if (ColorImage.Allocated)
        //    {
        //        lock (sync_lock)
        //        {
        //            if (FileName == null || FileName == "")
        //            {
        //                while (true)
        //                {
        //                    if (FileExist(strfile))
        //                    {
        //                        idx++;
        //                    }
        //                    else
        //                    {
        //                        ICogImage image = ColorImage;
        //                        //filePath = strImagePath + "\\RESULT_" + idx + ".png";
        //                        filePath = strfile;
        //                        image.ToBitmap().Save(filePath);
        //                        break;
        //                    }
        //                    strfile = IGlobal.m_MainPJTRoot + "\\" + "_IMG\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\CODE_NG\\RESULT_" + idx + ".png";
        //                }
        //            }
        //            else
        //            {
        //                ICogImage image = ColorImage;
        //                filePath = strImagePath + "\\RESULT_" + FileName + ".png";
        //                image.ToBitmap().Save(filePath);
        //            }
        //        }
        //        //Common.SaveImageFileToPNG(ColorImage, filePath);
        //    }
        //}

        ////NG 영역만 저장
        //private object sync_loc = new object();

        //public void ResultRegion_ImageSave(List<ICogRegion> regions, List<string> name, string FileName, CogImage24PlanarColor ColorImage, int tool)
        //{
        //    if (ColorImage == null)
        //    {
        //        return;
        //    }

        //    string strImagePath = IGlobal.m_MainPJTRoot + "\\" + "_IMG";
        //    string filePath = "";

        //    if (!System.IO.Directory.Exists(strImagePath))
        //    {
        //        System.IO.Directory.CreateDirectory(strImagePath);
        //    }

        //    strImagePath = strImagePath + "\\" + DateTime.Now.ToString("yyyy-MM-dd");
        //    if (!System.IO.Directory.Exists(strImagePath))
        //    {
        //        System.IO.Directory.CreateDirectory(strImagePath);
        //    }

        //    strImagePath = strImagePath + "\\" + FileName + "\\NG";

        //    if (!System.IO.Directory.Exists(strImagePath))
        //    {
        //        System.IO.Directory.CreateDirectory(strImagePath);
        //    }

        //    if (ColorImage.Allocated)
        //    {
        //        lock (sync_loc)
        //        {
        //            for (int i = 0; i < name.Count; i++)
        //            {
        //                ICogImage image = null;

        //                if (regions[i] is CogRectangleAffine)
        //                {
        //                    image = CVisionTools.Run_CopyRegion(ColorImage, regions[i] as CogRectangleAffine);
        //                }
        //                else
        //                {
        //                    image = CVisionTools.Run_CopyRegion(ColorImage, regions[i] as CogRectangle);
        //                }

        //                switch (tool)
        //                {
        //                    case 0:
        //                        filePath = strImagePath + "\\Pattern_" + name[i] + ".png";
        //                        break;

        //                    case 1:
        //                        filePath = strImagePath + "\\BLOB_" + name[i] + ".png";
        //                        break;

        //                    case 2:
        //                        filePath = strImagePath + "\\COLORMATCH_" + name[i] + ".png";
        //                        break;

        //                    case 3:
        //                        filePath = strImagePath + "\\OCR_" + name[i] + ".png";
        //                        break;
        //                }

        //                if (image != null) image.ToBitmap().Save(filePath);
        //            }
        //        }
        //        //Common.SaveImageFileToPNG(ColorImage, filePath);
        //    }
        //}

        //public void ImageLoad()
        //{
        //}

        //public void IdDataSave()
        //{
        //}

        public void IdDataSave(string Data, bool Result)
        {
            string strDataPath = Global.m_MainPJTRoot + "\\" + "_DATA\\";
            string strRes;
            bool sw_col = false;

            if (!System.IO.Directory.Exists(strDataPath))
            {
                System.IO.Directory.CreateDirectory(strDataPath);
                sw_col = true;
            }

            strDataPath = strDataPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".CSV";

            if (Result == true)
            {
                strRes = "OK";
            }
            else
            {
                strRes = "NG";
            }
            try
            {
                using (FileStream fs = new FileStream(strDataPath, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter file = new StreamWriter(fs, Encoding.UTF8))
                    {
                        if (sw_col == true)
                        {
                            file.WriteLine("DATE,RESULT,DATA");
                            sw_col = false;
                        }
                        file.WriteLine("{0},{1},{2}", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), strRes, Data);
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                //MessageBox.Show(ex.Message);
            }
        }

        //public CogImage8Grey MaskingImageLoad(int Camindex, string model, string jobname, CogPMAlignMultiTool cogPMAlignMultiTool = null)
        //{
        //    try
        //    {
        //        CogImage8Grey image = null;
        //        string strRecipe = model;
        //        int nCamIndex = Camindex;
        //        string strPath;
        //        string filePath;
        //        if (cogPMAlignMultiTool == null)
        //        {
        //            strPath = $"{IGlobal.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\JOBS\\CAMERA{nCamIndex}\\";
        //            filePath = strPath + $"MaskImage_{jobname}" + ".bmp";
        //        }
        //        else
        //        {
        //            strPath = $"{IGlobal.m_MainPJTRoot}\\RECIPE\\{strRecipe}\\MULTIPMALIGN\\CAMERA{nCamIndex}\\";
        //            filePath = strPath + $"MaskImage_{jobname}" + ".bmp";
        //        }

        //        CogImageFile ImageFile1 = new CogImageFile();
        //        ImageFile1.Open(filePath, CogImageFileModeConstants.Read);

        //        ICogImage imageFile = ImageFile1[0];
        //        CogImageConvertTool cogImageConverter = new CogImageConvertTool();
        //        cogImageConverter.InputImage = imageFile;
        //        cogImageConverter.Run();
        //        //m_imgSource_Color = new CogImage24PlanarColor((CogImage24PlanarColor)image);
        //        image = (CogImage8Grey)cogImageConverter.OutputImage;
        //        return image;
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
        //        return null;
        //    }
        //}

        // NG Count 모델 별 저장 - JYH
        public void NG_Count_Save(string LogicInfo, string sNGCount, string LibraryName)
        {
            string sPath = $"{Application.StartupPath}\\RECIPE\\{LibraryName}";
            if (!Directory.Exists(sPath)) Directory.CreateDirectory(sPath);
            string filePaht = Path.Combine(sPath, "\\NG_Count.ini");
            if (!File.Exists(filePaht)) File.Create(filePaht);
                
            WriteValue("LogicInfo", LogicInfo, sNGCount, filePaht);
        }
        // NG Count 모델 별 로드 - JYH
        public void NG_Count_Load(string LibraryName)
        {
            string sPath = $"{Application.StartupPath}\\RECIPE\\{LibraryName}\\NG_Count.ini";
            string currentSection = "";
            int iNum = 0;
            if (File.Exists(sPath))
            {
                foreach (string rawLine in File.ReadLines(sPath))
                {
                    string line = rawLine.Trim();

                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith(";") || line.StartsWith("#"))
                        continue;

                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        currentSection = line.Substring(1, line.Length - 2);
                        continue;
                    }

                    if (line.Contains("="))
                    {
                        string[] keyValue = line.Split(new[] { '=' }, 2);
                        string key = keyValue[0].Trim();
                        string value = keyValue[1].Trim();

                        string[] keyParts = key.Split(',');

                        string part1 = keyParts.Length > 0 ? keyParts[0] : "";
                        string part2 = keyParts.Length > 1 ? keyParts[1] : "";
                        string part3 = keyParts.Length > 2 ? keyParts[2] : "";

                        IData.sNGArray[iNum] = part1;
                        IData.sNGLocationNo[iNum] = part2;
                        IData.sNGLogicName[iNum] = part3;
                        IData.sNGCount[iNum] = value;
                        iNum++;
                    }
                }
                IData.bNGCountLoad = true;

            }
        }
        // NG Count 삭제 메소드 생성 - JYH
        public void NG_Count_Delete(string keyToDelete, string LibraryName)
        {
            string sPath = $"{Application.StartupPath}\\RECIPE\\{LibraryName}\\NG_Count.ini";
            string sectionToEdit = "LogicInfo";
            List<string> lines = File.ReadAllLines(sPath).ToList();

            List<string> output = new List<string>();

            string currentSection = "";
            foreach (string rawLine in lines)
            {
                string line = rawLine.Trim();

                // 섹션 감지
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    currentSection = line.Substring(1, line.Length - 2);
                    output.Add(rawLine);
                    continue;
                }

                if (currentSection == sectionToEdit)
                {
                    if (line.StartsWith(keyToDelete + "="))
                    {
                        continue;
                    }
                }

                output.Add(rawLine);
            }

            File.WriteAllLines(sPath, output);
        }

        public void CountSave(IData data)
        {
            string path = $"{Global.m_MainPJTRoot}\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string file_paht = Path.Combine(path, "Count.ini");
            if (!File.Exists(file_paht)) File.Create(file_paht);
            double dYield = (double)(Global.Instance.Data.CurrentOK / ((double)Global.Instance.Data.CurrentOK + (double)Global.Instance.Data.CurrentNG)) * 100;
            if ((data.CurrentOK + data.CurrentNG) != 0)
                data.CurrentYield = ((double)(data.CurrentOK / (data.CurrentOK + data.CurrentNG))).ToString();
            else
                data.CurrentYield = "0";
            WriteValue("COUNT", "OK", data.CountOK.ToString(), file_paht);
            WriteValue("COUNT", "NG_T", data.CountNG_T.ToString(), file_paht);
            WriteValue("COUNT", "NG_F", data.CountNG_F.ToString(), file_paht);
            WriteValue("COUNT", "YIELD", data.yield.ToString(), file_paht);
            WriteValue("COUNT", "CURRENT_OK", data.CurrentOK.ToString(), file_paht);
            WriteValue("COUNT", "CURRENT_NG", data.CurrentNG.ToString(), file_paht);
            WriteValue("COUNT", "CURRENT_YIELD", dYield.ToString(), file_paht);
        }
        public void CountLoad()
        {
            string path = $"{Global.m_MainPJTRoot}\\Count.ini";

            if (File.Exists(path))
            {
                string strtmp;

                strtmp = ReadValue("COUNT", "OK", path);
                if (strtmp == null || strtmp == "")
                {
                    Global.Instance.Data.CountOK = 0;
                }
                else
                {
                    Global.Instance.Data.CountOK = int.Parse(strtmp);
                }

                strtmp = ReadValue("COUNT", "NG_F", path);
                if (strtmp == null || strtmp == "")
                {
                    Global.Instance.Data.CountNG_F = 0;
                }
                else
                {
                    Global.Instance.Data.CountNG_F = int.Parse(strtmp);
                }

                strtmp = ReadValue("COUNT", "NG_T", path);
                if (strtmp == null || strtmp == "")
                {
                    Global.Instance.Data.CountNG_T = 0;
                }
                else
                {
                    Global.Instance.Data.CountNG_T = int.Parse(strtmp);
                }

                strtmp = ReadValue("COUNT", "YIELD", path);
                if (strtmp == null || strtmp == "")
                {
                    Global.Instance.Data.yield = "0";
                }
                else
                {
                    Global.Instance.Data.yield = strtmp;
                }
                strtmp = ReadValue("COUNT", "CURRENT_OK", path);
                if (strtmp == null || strtmp == "")
                {
                    Global.Instance.Data.CurrentOK = 0;
                }
                else
                {
                    Global.Instance.Data.CurrentOK = int.Parse(strtmp);
                }
                strtmp = ReadValue("COUNT", "CURRENT_NG", path);
                if (strtmp == null || strtmp == "")
                {
                    Global.Instance.Data.CurrentNG = 0;
                }
                else
                {
                    Global.Instance.Data.CurrentNG = int.Parse(strtmp);
                }
                strtmp = ReadValue("COUNT", "CURRENT_YIELD", path);
                if (strtmp == null || strtmp == "")
                {
                    Global.Instance.Data.CurrentYield = "0";
                }
                else
                {
                    Global.Instance.Data.CurrentYield = strtmp;
                }
            }
            else
            {
                File.Create(path).Close();
            }
        }


        //public bool IMAGESAVETYPE_SAVE()
        //{
        //    string strPath = IGlobal.m_MainPJTRoot + "\\CONFIG\\IMAGE_SAVE_TYPE.xml";

        //    XmlWriterSettings settings = new XmlWriterSettings();
        //    settings.Indent = true;
        //    settings.NewLineOnAttributes = true;
        //    settings.IndentChars = "\t";
        //    settings.NewLineChars = "\r\n";
        //    XmlWriter xmlWriter = XmlWriter.Create(strPath, settings);
        //    try
        //    {
        //        xmlWriter.WriteStartDocument();
        //        xmlWriter.WriteStartElement("PROPERTY");
        //        xmlWriter.WriteElementString("OKIMAGESAVE", IGlobal.Instance.System.OK_IMAGE_SAVE.ToString());
        //        xmlWriter.WriteElementString("NGIMAGESAVE", IGlobal.Instance.System.NG_IMAGE_SAVE.ToString());

        //        xmlWriter.WriteEndElement();
        //        xmlWriter.WriteEndDocument();
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1} Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
        //    }
        //    finally
        //    {
        //        xmlWriter.Flush();
        //        xmlWriter.Close();
        //    }

        //    return true;
        //}

        //private string m_XMLName = "PROPERTY";

        //public bool IMAGESAVETYPE_LOAD()
        //{
        //    try
        //    {
        //        string strPath = IGlobal.m_MainPJTRoot + "\\CONFIG\\IMAGE_SAVE_TYPE.xml";

        //        if (File.Exists(strPath))
        //        {
        //            XmlTextReader xmlReader = new XmlTextReader(strPath);

        //            try
        //            {
        //                while (xmlReader.Read())
        //                {
        //                    if (xmlReader.NodeType == XmlNodeType.Element)
        //                    {
        //                        switch (xmlReader.Name)
        //                        {
        //                            case "OKIMAGESAVE": if (xmlReader.Read()) IGlobal.Instance.System.OK_IMAGE_SAVE = bool.Parse(xmlReader.Value); break;
        //                            case "NGIMAGESAVE": if (xmlReader.Read()) IGlobal.Instance.System.NG_IMAGE_SAVE = bool.Parse(xmlReader.Value); break;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (xmlReader.NodeType == XmlNodeType.EndElement)
        //                        {
        //                            if (xmlReader.Name == m_XMLName) break;
        //                        }
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1} Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
        //                xmlReader.Close();
        //            }

        //            xmlReader.Close();
        //        }
        //        else
        //        {
        //            //SaveConfig();
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1} Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
        //        return false;
        //    }
        //    return true;
        //}

        //public void SaveXML()
        //{
        //}

        //public void LoadXML()
        //{
        //}
    }
}