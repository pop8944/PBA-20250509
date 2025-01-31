using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IntelligentFactory.Version
{
    /// <summary>
    /// Version Manage Form
    /// </summary>
    public partial class FormPopUp_Version : Form
    {
        /// <summary>
        /// Version Display Buffer String
        /// </summary>
        private string versionString = "";

        /// <summary>
        /// Version Data Group
        /// </summary>
        public Version versionData = new Version();

        /// <summary>
        /// Version Creator - initialize , Version Data Load
        /// </summary>
        public FormPopUp_Version()
        {
            InitializeComponent();
            LoadVersionInfoes("IF_PBA");
        }

        /// <summary>
        /// Version Data Load (Main Version Load First)
        /// </summary>
        /// <param name="mainName">Main Version Name</param>
        public void LoadVersionInfoes(string mainName = "IF_PBA")
        {
            string excutePath = Util.GetExcutePath();
            List<string> versionList = Util.GetFileNames(excutePath, "*.vi");
            cmbLiberary.Items.Clear();
            // IF_PBA를 처음으로
            for (int i = 0; i < versionList.Count; i++)
            {
                if (versionList[i].Contains(mainName))
                {
                    cmbLiberary.Items.Add(versionList[i]);
                    versionList.Remove(versionList[i]);
                }
            }

            for (int i = 0; i < versionList.Count; i++)
                cmbLiberary.Items.Add(versionList[i]);
            cmbLiberary.SelectedIndex = 0;
        }

        /// <summary>
        /// Version Form View & Initialize
        /// </summary>
        public void View()
        {
            this.Show();
            cmbLiberary.SelectedIndex = 0;
            cmbLiberary_SelectedIndexChanged(null, null);
            //cmbLiberary_SelectedIndexChanged(this, EventArgs.0);
        }

        /// <summary>
        /// Update Version Data ([yy/mm/dd]로 버전업 체크)
        /// </summary>
        /// <param name="isLine">Line단위버전Up</param>
        public void UpdateVersion(bool isLine = false)
        {
            string strPath = cmbLiberary.Text;
            versionData = GetVersion(strPath, isLine);
        }

        /// <summary>
        /// Version Data Get
        /// </summary>
        /// <param name="strPath">Version File</param>
        /// <param name="isLine">Line단위버전Up</param>
        /// <returns>Version Data</returns>
        public Version GetVersion(string strPath, bool isLine = false)
        {
            Version retVersion = new Version();
            string line = "";
            retVersion.VERSION = 1.0;
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(strPath);
            //Read the first line of text
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                if (!isLine)
                {
                    if (line != null && line.Contains("[") && line.Contains("]") && line.Contains("/") && line.Length == 12)
                    {
                        retVersion.VERSION += 0.001;
                        retVersion.DATETIME_UPDATED = Util.GetsBetweenItem(ref line, "[", "]", false, true);
                    }
                }
                else
                {
                    retVersion.VERSION += 0.001;
                    retVersion.DATETIME_UPDATED = Util.GetCompiledDateTime().ToString();
                }
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
            retVersion.VERSION = Math.Round(retVersion.VERSION, 3);

            return retVersion;
        }

        /// <summary>
        /// Version Text Read
        /// </summary>
        /// <param name="strPath">Version File</param>
        /// <returns>Read String</returns>
        public string ReadTexts(string strPath)
        {
            string verString = "";
            string line = "";
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(strPath);
            //Read the first line of text
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                verString += line + "\r\n";
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();

            return verString;
        }

        /// <summary>
        /// Close Button Click
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">event</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Version Liberary ComboBox Change Event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">event</param>
        private void cmbLiberary_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateVersion();
            DisplayVersion(cmbLiberary.Text);
        }

        /// <summary>
        /// Version String Display
        /// </summary>
        /// <param name="versionPath">Version File</param>
        public void DisplayVersion(string versionPath)
        {
            versionString = ReadTexts(versionPath);
            tbVersion.Text = "";
            tbVersion.AppendText(versionString);
            string strBuildMode = "DEBUG";
#if DEBUG
            strBuildMode = "DEBUG";
#else
                            strBuildMode = "RELEASE";
#endif
            this.Text = $"{versionData.APP_NAME} : {versionData.VERSION.ToString()} - ({versionData.DATETIME_UPDATED}) - {strBuildMode}";
        }

        /// <summary>
        /// SW Documents Auto Make
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void btnMakeSWDocuments_Click(object sender, EventArgs e)
        {
            // 여기 Batch파일을 만들자

            // 폴더 설정 및 파일 삭제
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.SelectedPath = "E:\\IF\\SW_Documents";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string excelPath = fbd.SelectedPath + "\\SWDocMain.xlsx";
                string excelPath2 = fbd.SelectedPath + "\\SWDocMain2.xlsx";
                if (File.Exists(excelPath))
                {
                    IntelligentFactory.Excel.InteropExcel excel = new IntelligentFactory.Excel.InteropExcel();
                    excel.Open(excelPath);
                    int sheetNo = excel.GetSheetNo("Liberary");
                    if (sheetNo >= 0)
                    {
                        string outputPath = fbd.SelectedPath;
                        string excutePath = Util.GetExcutePath();
                        List<FileInfo> versionList = Util.GetFileLists(excutePath, "*.vi");
                        // Document Info Update
                        double docVer = (double)excel.GetCellValue(sheetNo, 3, 1);
                        excel.AddData(sheetNo, docVer + 0.01, 3, 1);
                        DateTime today = DateTime.Now;
                        excel.AddData(sheetNo, today, 4, 1);

                        foreach (FileInfo version in versionList)
                        {
                            string fileNameOnly = Path.GetFileNameWithoutExtension(version.FullName);
                            string fileName = version.Name;
                            Version verData = GetVersion(version.FullName);
                            string verString = "Ver" + verData.VERSION.ToString();

                            if (fileNameOnly == "IF_PBA")
                            {
                                string strFileHyper1 = fbd.SelectedPath + "\\" + fileName;
                                System.IO.File.Copy(version.FullName, strFileHyper1, true);                               // File Copy
                                System.Drawing.Point inPt = new Point(5, 1);
                                excel.AddHyperLink(sheetNo, strFileHyper1, verString, inPt);                               // Excel HyperLink
                            }
                            else
                            {
                                for (int i = 4; i < 12; i++)
                                {
                                    System.Drawing.Point findPt = new Point(2, i);
                                    string findValue = (string)excel.GetCellValue(sheetNo, findPt);
                                    if (findValue == fileNameOnly)
                                    {
                                        string strFileHyper1 = fbd.SelectedPath + "\\" + fileName;
                                        System.IO.File.Copy(version.FullName, strFileHyper1, true);                           // File Copy
                                        System.Drawing.Point inPt = new Point(5, i);
                                        excel.AddHyperLink(sheetNo, strFileHyper1, verString, inPt);                       // Excel HyperLink
                                    }
                                }
                            }
                        }
                        List<FileInfo> SWDocList = Util.GetFileLists(excutePath, "*.msxmld");
                        foreach (FileInfo SWDoc in SWDocList)
                        {
                            string fileNameOnly = Path.GetFileNameWithoutExtension(SWDoc.FullName);
                            string fileName = SWDoc.Name;
                            for (int i = 4; i < 12; i++)
                            {
                                System.Drawing.Point findPt = new Point(2, i);
                                string findValue = (string)excel.GetCellValue(sheetNo, findPt);
                                if (findValue == fileNameOnly)
                                {
                                    string strFileHyper1 = fbd.SelectedPath + "\\" + fileName;
                                    System.IO.File.Copy(SWDoc.FullName, strFileHyper1, true);                               // File Copy
                                    System.Drawing.Point inPt = new Point(2, i);
                                    // 여기 ExcelDoc작업을 한다.
                                    string inDoc = excutePath + "\\" + fileNameOnly + ".msxmld";
                                    string outDoc = fbd.SelectedPath + "\\" + fileNameOnly + ".xlsx";
                                    string refDoc = excutePath + "\\Library_Format.xlsx";
                                    if (File.Exists(outDoc))
                                        File.Delete(outDoc);
                                    cmdDSL.MSxmlDoc2MSExcel(inDoc, outDoc, refDoc);

                                    excel.AddHyperLink(sheetNo, outDoc, fileNameOnly, inPt);                                 // Excel HyperLink
                                }
                            }
                        }
                        if (File.Exists(excelPath2))
                            File.Delete(excelPath2);
                        excel.Save(excelPath2);
                    }
                    excel.Close(excelPath2);
                    File.Delete(excelPath);
                    File.Move(excelPath2, excelPath);
                }
                else
                {
                    MessageBox.Show($"{excelPath}가 존재하지 않아 작업을 할 수 없습니다\n 경로를 다시 설정하여 주십시오 !!!");
                }
            }
        }

        #region 명령 키 처리하기 - ProcessCmdKey(message, keys)

        /// <summary>
        /// 명령 키 처리하기
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="keys">Keys</param>
        /// <returns>처리 결과</returns>
        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            Keys workKey = keys & ~(Keys.Shift | Keys.Control);

            switch (workKey)
            {
                case Keys.F10:

                    if ((keys & Keys.Control) != 0)
                    {
                        //MessageBox.Show("Ctrl+S 키를 눌렀습니다.");
                        btnMakeSWDocuments.Visible = !btnMakeSWDocuments.Visible;

                        return true;
                    }

                    break;

                    //case Keys.F5:

                    //    MessageBox.Show("F5 키를 눌렀습니다.");

                    //    return true;
            }

            return base.ProcessCmdKey(ref message, keys);
        }

        #endregion 명령 키 처리하기 - ProcessCmdKey(message, keys)
    }

    /// <summary>
    /// Version Data Group
    /// </summary>
    public class Version
    {
        /// <summary>
        /// Application Name
        /// </summary>
        public string APP_NAME { get; set; } = "PBA_MVI-200";

        /// <summary>
        /// Version Number - double
        /// </summary>
        public double VERSION { get; set; } = 1.015;

        /// <summary>
        /// Version Update Date/Time
        /// </summary>
        public string DATETIME_UPDATED { get; set; } = Util.GetCompiledDateTime().ToString();

        /// <summary>
        /// Manager
        /// </summary>
        public string MANAGER { get; set; } = "SHS";
    }
}