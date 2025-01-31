using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public static class Util
    {
        //---------------------------------------------------------------------------------
        // byte값을 문자로 변환
        //---------------------------------------------------------------------------------
        public static string ByteToStr(byte bByte)
        {
            byte[] byte_Buf = { bByte };
            string sRet = Encoding.ASCII.GetString(byte_Buf);
            return sRet;
        }

        //---------------------------------------------------------------------------------
        // bytes를 우측 부터 ZERO값 만큼 Bytes버퍼 크기 줄이기
        //---------------------------------------------------------------------------------
        public static byte[] BytesZeroClear(byte[] byte_data)
        {
            int iBuf_Len = byte_data.Length;
            int iReversIdx = 0;
            for (int i = 0; i < byte_data.Length; i++)
            {
                iReversIdx = (byte_data.Length - i) - 1;
                if (byte_data[iReversIdx] == 0x00)
                {
                    iBuf_Len--;
                }
                else
                {
                    break;
                }
            }
            byte[] result = new byte[iBuf_Len];
            Array.Copy(byte_data, 0, result, 0, iBuf_Len);
            return result;
        }

        public static string GetExcutePath()
        {
            return System.Environment.CurrentDirectory;
        }

        public static DateTime GetCompiledDateTime()
        {
            System.Version assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1).AddDays(assemblyVersion.Build).AddSeconds(assemblyVersion.Revision * 2);
            return buildDate;
        }

        public static string GetsBetweenItem(ref string strData, string strStart, string strEnd, bool bDelString, bool bInString)
        {
            string strReturn = "";
            int nStart = strData.IndexOf(strStart);
            int nEnd = strData.IndexOf(strEnd);
            int nDel = nEnd + 1;
            if (nStart >= 0 && nEnd >= 0)
            {
                if (bInString)
                    nStart += (int)strStart.Length;
                if (!bInString)
                    nEnd += (int)strEnd.Length;
                strReturn = strData.Substring(nStart, nEnd - nStart);
                if (bDelString)
                    strData = strData.Substring(nDel);
            }
            return strReturn;
        }

        public static string GetXMlItem(ref string strData, string strKey, bool bDelString, bool bInString)
        {
            string strStart, strEnd;
            strStart = $"<{strKey}>";
            strEnd = $"</{strKey}>";
            return GetsBetweenItem(ref strData, strStart, strEnd, bDelString, bInString);
        }

        public static List<string> GetXmlGroupes(ref string strData, string strFind, bool bInString)
        {
            List<string> strReturns = new List<string>();
            string strValue;

            while (true)
            {
                strValue = GetXMlItem(ref strData, strFind, true, bInString);
                if (strValue.Length > 0)
                    strReturns.Add(strValue);
                else if (strValue.Length > 2000)
                    break;
                else
                    break;
            }
            return strReturns;
        }

        public static List<string> GetFileNames(string findFolder, string searchPattern = "*.*")
        {
            List<string> files = new List<string>();

            // 지정한 경로에 폴더가 있는지 확인
            if (System.IO.Directory.Exists(findFolder))
            {
                // DirectoryInfo Class를 생성합니다.
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(findFolder);

                foreach (System.IO.FileInfo File in di.GetFiles(searchPattern))
                    files.Add(File.FullName);
            }
            return files;
        }

        public static List<System.IO.FileInfo> GetFileLists(string findFolder, string searchPattern = "*.*")
        {
            List<System.IO.FileInfo> fileLists = new List<System.IO.FileInfo>();

            // 지정한 경로에 폴더가 있는지 확인
            if (System.IO.Directory.Exists(findFolder))
            {
                // DirectoryInfo Class를 생성합니다.
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(findFolder);

                foreach (System.IO.FileInfo File in di.GetFiles(searchPattern))
                    fileLists.Add(File);
            }
            return fileLists;
        }

        private const string PBA_UPDATE_ROOT = "Z:\\SiteSSE\\PBA\\ExcuteFiles";

        //const string PBA_UPDATE_ROOT = "E:\\PBA_ExcuteFiles";
        private const string PBA_EXCUTE = "E:\\exe_Vision_PBA";

        /// <summary>
        /// 실행파일들을 복사하여 deploy 파일을 만든다.
        /// </summary>
        /// <param name="sourcePath">실행경로(복사할경로)</param>
        /// <param name="targetRoot">추출하여 만들경로</param>
        /// <returns>결과에 대한 메시지</returns>
        public static string CopyExcuteFiles(string sourcePath = PBA_EXCUTE, string targetRoot = PBA_UPDATE_ROOT)
        {
            string retStr = "";
            DateTime toDay = DateTime.Now;
            string toDayString = toDay.ToString("yyyyMMdd");
            List<string> lstNew = new List<string>();
            List<string> lstUpdate = new List<string>();
            List<string> lstRemain = new List<string>();

            // 폴더 설정 및 파일 삭제
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "저장할 폴더를 지정하십시오.";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.SelectedPath = PBA_UPDATE_ROOT;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string targetPath = fbd.SelectedPath + "\\" + toDayString;
                // File Install
                System.IO.DirectoryInfo sourceDir = new System.IO.DirectoryInfo(sourcePath);
                System.IO.DirectoryInfo targetDir = new System.IO.DirectoryInfo(targetPath);
                if (!targetDir.Exists)
                    targetDir.Create();

                foreach (System.IO.FileInfo sourceFile in sourceDir.GetFiles())
                {
                    // 여기에 특정 PC조건 추가할 것
                    bool isCopy = sourceFile.Extension.Equals(".dll");
                    isCopy = isCopy || sourceFile.Extension.Equals(".exe");
                    isCopy |= sourceFile.Extension.Equals(".xlsx");
                    isCopy |= sourceFile.Extension.Equals(".msxmld");
                    isCopy |= sourceFile.Extension.Equals(".vi");
                    isCopy |= sourceFile.Extension.Equals(".bat");
                    isCopy |= sourceFile.Extension.Equals(".config");
                    isCopy |= sourceFile.Extension.Equals(".xml");
                    System.IO.FileInfo TargetFile = null;
                    if (isCopy)
                    {
                        TargetFile = new System.IO.FileInfo(targetPath + "\\" + sourceFile.Name);
                        if (TargetFile.Exists)
                        {
                            if (sourceFile.Length != TargetFile.Length || sourceFile.LastWriteTime > TargetFile.LastWriteTime)
                            {
                                lstUpdate.Add(sourceFile.Name);
                                sourceFile.CopyTo(TargetFile.FullName, true);
                            }
                            else
                            {
                                lstRemain.Add(sourceFile.Name);
                                continue;
                            }
                        }
                        else
                        {
                            lstNew.Add(sourceFile.Name);
                            sourceFile.CopyTo(TargetFile.FullName, true);
                        }
                    }
                }
                retStr = $"New Item Count : {lstNew.Count}\nUpdate Item Count : {lstUpdate.Count}\nRemain Item Count : {lstRemain.Count}";
                return retStr;
            }
            return retStr;
        }

        public static bool CheckDriveInfo(string driveInfo)
        {
            bool isChkDrive = false;
            DriveInfo[] AllDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in AllDrives)
            {
                if (d.Name.Equals(driveInfo))
                    isChkDrive = true;
            }
            return isChkDrive;
        }

        public static bool CheckExcelExist()
        {
            var appType = Type.GetTypeFromProgID("Excel.Application");
            return appType != null;
        }

        public static void DoubleBuffered(this ListView dgv, bool setting)
        {
            try
            {
                Type dgvType = dgv.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

                pi.SetValue(dgv, setting, null);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                //CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        // 하드웨어 볼륨의 용량 확인 부분..
        public static List<string> GetDriveVolume(string strTargetDriver, out List<double> list_TotalSize, out List<double> list_AvaliableSize, out List<double> list_UseSize)
        {
            double dPercent = 0;
            double TotalSize = 0.0D;
            double AvaliableSize = 0.0D;
            double UseSize = 0.0D;

            List<string> list = new List<string>();
            list_TotalSize = new List<double>();
            list_AvaliableSize = new List<double>();
            list_UseSize = new List<double>();

            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                // 드라이버 용량 다 가져오기...문자열로 받아오기..
                // 드라이브 전체 용량
                TotalSize = drive.TotalSize / 1000000.0D / 1024.0D;
                AvaliableSize = drive.AvailableFreeSpace / 1000000.0D / 1024.0D;
                UseSize = TotalSize - AvaliableSize;

                // 사용중인 용량 ( 전체 용량 - 사용 가능한 용량 )
                double dUsedSize = (int)((drive.TotalSize - drive.AvailableFreeSpace) / 1000000 / 1024.0D);

                dPercent = dUsedSize / TotalSize * 100.0D;

                // 드라이버 볼륨의 용량 크기의 값을 문자열로 작성..
                string str_DriverVolume = $"{drive}: {dPercent}%";

                list.Add(str_DriverVolume);
                list_TotalSize.Add(TotalSize);
                list_AvaliableSize.Add(AvaliableSize);
                list_UseSize.Add(UseSize);
            }

            return list;
        }

        // 추가
        public static void UfxWaitTime(int nMillisecond)
        {
            DateTime ThisMoment = DateTime.Now;

            TimeSpan duration = new TimeSpan(0, 0, 0, 0, nMillisecond);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
        }

        private static PerformanceCounter ncpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        // CPU 사용량 가져오기..
        public static int CPU()
        {
            return (int)ncpu.NextValue();
        }

        static System.Management.ManagementClass MCLS = new System.Management.ManagementClass("Win32_OperatingSystem");
        static System.Management.ManagementObjectCollection instances = MCLS.GetInstances();
        public static int RAM()
        {
            int ret = 0;

            foreach (ManagementObject mo in instances)
            {
                int total_mem = int.Parse(mo["TotalVisibleMemorySize"].ToString());
                int free_mem = int.Parse(mo["FreePhysicalMemory"].ToString());
                int remain_mem = total_mem - free_mem;

                ret = (int)((double)remain_mem / (double)total_mem * 100);
            }

            return ret;
        }

        // 현재 드라이브 사용량 확인..
        public static void Driver_Value(string driver_name, out int percent, out int TotalSize, out int FreeSize)
        {
            percent = 0;
            TotalSize = 0;
            FreeSize = 0;

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                switch (drive.DriveType)
                {
                    case DriveType.Fixed:
                        {
                            if (drive.Name.Contains(driver_name))
                            {
                                percent = (int)(100 - (double)drive.AvailableFreeSpace / (double)drive.TotalSize * 100);
                                TotalSize = Convert.ToInt32(drive.TotalSize / 1024 / 1024 / 1024);
                                FreeSize = Convert.ToInt32(drive.AvailableFreeSpace / 1024 / 1024 / 1024);
                            }
                        }
                        break;
                }
            }
        }

        public static void Driver_FileDelete(string drivername, string path, int deltime, int del_day, int hdd_value)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                if (drive.DriveType == DriveType.Fixed)
                {
                    if (drive.Name.Contains(drivername))
                    {
                        string time = deltime.ToString();
                        File_Del(drive, path, time, del_day, hdd_value);
                    }
                }
            }
        }

        private static void File_Del(DriveInfo driver, string path, string delchecktime, int del_day, int hdd_value)
        {
            string SdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string StimeData = SdateTime.Substring(11, 2);

            // 특정시간에 삭제...
            if (StimeData == delchecktime)
            {
                int percent = (int)(100 - (double)driver.AvailableFreeSpace / (double)driver.TotalSize * 100);

                // 설정 용량 보다...현재 파일누적용량이 더많을 경우..삭제..
                if (hdd_value < percent)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    DateTime fileCreatedTime;
                    string str = DateTime.Now.AddDays(-del_day).ToString("yyyyMMdd");
                    DateTime cmpTime = DateTime.ParseExact(str, "yyyyMMdd", null);

                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        fileCreatedTime = file.CreationTime;

                        //파일생성날짜가 strDate보다 이전이면 파일을 삭제한다.
                        int ret = DateTime.Compare(cmpTime, fileCreatedTime);

                        if (ret > 0)
                        {
                            File.Delete(file.FullName);
                        }

                    }
                }
            }
        }

        // 해당 현재 드라이브가 있는지 체크..
        // 해당 드라이브가 있으면 true, 없으면 fasle
        public static bool GetDriverCheck(string drivername)
        {
            bool ret = false;

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                if (drive.DriveType == DriveType.Fixed)
                {
                    if (drive.Name.Contains(drivername))
                    {
                        ret = true;
                    }
                }
            }

            return ret;
        }

        // 폴더 경로 설정
        public static string Select_Path()
        {
            string str = "";

            System.Windows.Forms.FolderBrowserDialog ofd = new System.Windows.Forms.FolderBrowserDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                str = ofd.SelectedPath;
            }

            return str;
        }

        // 폴더 찾기
        public static string GetFilePath_Serch(string path, string Directory_name, string serch_filename)
        {
            string FilePath = "";
            System.IO.DirectoryInfo Info = new System.IO.DirectoryInfo(path);
            if (Info.Exists)
            {
                System.IO.DirectoryInfo[] CInfo = Info.GetDirectories("*", System.IO.SearchOption.AllDirectories);
                foreach (System.IO.DirectoryInfo info in CInfo)
                {
                    string fullpath = info.FullName;
                    if (fullpath.Contains(Directory_name))
                    {
                        DirectoryInfo file = new DirectoryInfo(fullpath);
                        FileInfo[] infofile = file.GetFiles("*", System.IO.SearchOption.AllDirectories);

                        foreach (FileInfo fileserch in infofile)
                        {
                            string filepath = fileserch.FullName;
                            if (filepath.Contains(serch_filename))
                            {
                                FilePath = fileserch.FullName;
                                return FilePath;
                            }
                        }
                    }
                }
            }

            return FilePath;
        }
    }
}