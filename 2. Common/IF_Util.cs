using MetroFramework.Controls;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Vila.Extensions;

namespace IntelligentFactory
{
    public static class IF_Util
    {
        public static void setLabel(Label label, String text, Color backColor)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new EventHandler(delegate
                {
                    if (text != null) label.Text = text;
                    if (backColor != null) label.BackColor = backColor;
                }));
            }
            else
            {
                if (text != null) label.Text = text;
                if (backColor != null) label.BackColor = backColor;
            }
        }

        //public static string g_SaveRoot = $"E:\\VISION_IMAGE";

        public static List<Rect> ClusterRectangles(List<Rect> rectangles, double threshold)
        {
            var clusters = new List<List<Rect>>();
            var visited = new HashSet<Rect>();

            foreach (var rect in rectangles)
            {
                if (visited.Contains(rect)) continue;

                var cluster = new List<Rect>();
                Cluster(rect, rectangles, cluster, visited, threshold);
                clusters.Add(cluster);
            }

            return CalculateBoundingRectangles(clusters);
        }

        private static void Cluster(Rect current, List<Rect> allRects, List<Rect> cluster, HashSet<Rect> visited, double threshold)
        {
            visited.Add(current);
            cluster.Add(current);

            foreach (var rect in allRects)
            {
                if (!visited.Contains(rect) && IsWithinThreshold(current, rect, threshold))
                {
                    Cluster(rect, allRects, cluster, visited, threshold);
                }
            }
        }

        private static bool IsWithinThreshold(Rect a, Rect b, double threshold)
        {
            // 여기서는 간단히 중심점 간의 유클리드 거리를 사용합니다.
            var centerA = new PointF(a.Left + a.Width / 2, a.Top + a.Height / 2);
            var centerB = new PointF(b.Left + b.Width / 2, b.Top + b.Height / 2);
            return Math.Sqrt(Math.Pow(centerA.X - centerB.X, 2) + Math.Pow(centerA.Y - centerB.Y, 2)) < threshold;
        }

        private static List<Rect> CalculateBoundingRectangles(List<List<Rect>> clusters)
        {
            var boundingRects = new List<Rect>();
            foreach (var cluster in clusters)
            {
                float minX = float.MaxValue, minY = float.MaxValue;
                float maxX = float.MinValue, maxY = float.MinValue;

                foreach (var rect in cluster)
                {
                    minX = Math.Min(minX, rect.Left);
                    minY = Math.Min(minY, rect.Top);
                    maxX = Math.Max(maxX, rect.Right);
                    maxY = Math.Max(maxY, rect.Bottom);
                }

                boundingRects.Add(new Rect((int)minX, (int)minY, (int)maxX - (int)minX, (int)maxY - (int)minY));
            }
            return boundingRects;
        }

        public static Bitmap SafetyImageLoad(string path)
        {
            Bitmap bitmap = null;
            try
            {
                if (File.Exists(path))
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    {
                        bitmap = new Bitmap(Image.FromStream(fs));
                        fs.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
            }

            return bitmap;
        }

        public static void SafetyImageSave(string path, Bitmap img)
        {
            Bitmap bitmap = null;
            try
            {
                if (img != null) Cv2.ImWrite(path, OpenCvSharp.Extensions.BitmapConverter.ToMat(img));
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
            }
        }

        public static (Rectangle, Rectangle, Rectangle, Rectangle) GetRectPointsToRects(Rectangle rt, int radius)
        {
            Rectangle LT = new Rectangle(rt.Left - radius, rt.Top - radius, radius * 2, radius * 2);
            Rectangle LB = new Rectangle(rt.Left - radius, rt.Bottom - radius, radius * 2, radius * 2);
            Rectangle RT = new Rectangle(rt.Right - radius, rt.Top - radius, radius * 2, radius * 2);
            Rectangle RB = new Rectangle(rt.Right - radius, rt.Bottom - radius, radius * 2, radius * 2);

            return (LT, LB, RT, RB);
        }

        public static double GetAngle(Point2d start, Point2d end)
        {
            double dy = end.Y - start.Y;
            double dx = end.X - start.X;
            double dydx = dy / dx;
            double angle = Math.Atan(dydx) * (180.0 / Math.PI);

            if (double.IsNaN(angle))
            {
                return 90;
            }
            return angle;
        }

        public static (System.Drawing.Point, System.Drawing.Point, System.Drawing.Point, System.Drawing.Point) GetRectPoints(Rectangle rt)
        {
            System.Drawing.Point LT = new System.Drawing.Point(rt.Left, rt.Top);
            System.Drawing.Point LB = new System.Drawing.Point(rt.Left, rt.Bottom);
            System.Drawing.Point RT = new System.Drawing.Point(rt.Right, rt.Top);
            System.Drawing.Point RB = new System.Drawing.Point(rt.Right, rt.Bottom);
            return (LT, LB, RT, RB);
        }

        public static bool SendPing(string strIP, int nRetry = 1)
        {
            Ping pingSender = new Ping();
            int nTimeout = 1000;

            for (int i = 0; i < nRetry; i++)
            {
                PingReply reply = pingSender.Send(strIP, nTimeout);

                if (reply.Status == IPStatus.Success) return true;
            }

            return false;
        }

        public static double GetAngle(bool setTemp90Rot, Point2d start, Point2d end)
        {
            double dy = end.Y - start.Y;
            double dx = end.X - start.X;
            double dydx = dy / dx;
            double angle = Math.Atan(dydx) * (180.0 / Math.PI);

            if (double.IsNaN(angle))
            {
                return 90;
            }
            return angle;
        }

        public static PointF RotatePoint(System.Drawing.Point ptCenter, System.Drawing.Point ptTarget, double dRotatedAngle, double dOffsetX, double dOffsetY)
        {
            double rad = dRotatedAngle * Math.PI / 180.0;
            System.Drawing.PointF rP = new System.Drawing.PointF();

            rP.X = (float)(((ptTarget.X - ptCenter.X) * Math.Cos(rad) - (ptTarget.Y - ptCenter.Y) * Math.Sin(rad)) + ptCenter.X + dOffsetX);
            rP.Y = (float)(((ptTarget.X - ptCenter.X) * Math.Sin(rad) + (ptTarget.Y - ptCenter.Y) * Math.Cos(rad)) + ptCenter.Y + dOffsetY);

            return rP;
        }

        public static PointF RotatePointF(System.Drawing.PointF ptCenter, System.Drawing.PointF ptTarget, double dRotatedAngle, double dOffsetX, double dOffsetY)
        {
            double rad = dRotatedAngle * Math.PI / 180.0;
            System.Drawing.PointF rP = new System.Drawing.PointF();

            rP.X = (float)(((ptTarget.X - ptCenter.X) * Math.Cos(rad) - (ptTarget.Y - ptCenter.Y) * Math.Sin(rad)) + ptCenter.X + dOffsetX);
            rP.Y = (float)(((ptTarget.X - ptCenter.X) * Math.Sin(rad) + (ptTarget.Y - ptCenter.Y) * Math.Cos(rad)) + ptCenter.Y + dOffsetY);

            return rP;
        }

        public static Rectangle BondingBox_Circle(int centerX, int centerY, int radius, int offsetSize = 1)
        {
            // 사각형의 왼쪽 상단 모서리 좌표 계산
            int topLeftX = centerX - radius - offsetSize / 2;
            int topLeftY = centerY - radius - offsetSize / 2;

            // 사각형의 너비와 높이는 원의 지름과 같음
            int diameter = 2 * radius;

            // 경계 상자 생성 및 반환
            return new Rectangle(topLeftX, topLeftY, diameter + offsetSize, diameter + offsetSize);
        }

        public static double rad2deg(double rad)
        {
            double deg = 0.0;
            deg = rad * (180 / Math.PI);
            return deg;
        }

        public static void FindIntersection
         (
             PointF p1,
             PointF p2,
             PointF p3,
             PointF p4,
             out bool lineIntersect,
             out bool segmentIntersect,
             out PointF intersectPoint,
             out PointF closePoint1,
             out PointF closePoint2)
        {
            float dx21 = p2.X - p1.X;
            float dy21 = p2.Y - p1.Y;
            float dx43 = p4.X - p3.X;
            float dy43 = p4.Y - p3.Y;

            float denominator = (dy21 * dx43 - dx21 * dy43);

            float t1 = ((p1.X - p3.X) * dy43 + (p3.Y - p1.Y) * dx43) / denominator;

            if (float.IsInfinity(t1))
            {
                lineIntersect = false;
                segmentIntersect = false;

                intersectPoint = new PointF(float.NaN, float.NaN);
                closePoint1 = new PointF(float.NaN, float.NaN);
                closePoint2 = new PointF(float.NaN, float.NaN);

                return;
            }

            lineIntersect = true;

            float t2 = ((p3.X - p1.X) * dy21 + (p1.Y - p3.Y) * dx21) / -denominator;

            intersectPoint = new PointF(p1.X + dx21 * t1, p1.Y + dy21 * t1);

            segmentIntersect = ((t1 >= 0) && (t1 <= 1) && (t2 >= 0) && (t2 <= 1));

            if (t1 < 0)
            {
                t1 = 0;
            }
            else if (t1 > 1)
            {
                t1 = 1;
            }

            if (t2 < 0)
            {
                t2 = 0;
            }
            else if (t2 > 1)
            {
                t2 = 1;
            }

            closePoint1 = new PointF(p1.X + dx21 * t1, p1.Y + dy21 * t1);
            closePoint2 = new PointF(p3.X + dx43 * t2, p3.Y + dy43 * t2);
        }

        public static System.Drawing.Bitmap FlipRotateEX(System.Drawing.Bitmap imgSrc, System.Drawing.RotateFlipType op)
        {
            try
            {
                if (imgSrc != null || imgSrc.Width != 0) imgSrc.RotateFlip(op);
                return (System.Drawing.Bitmap)imgSrc.Clone();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        public static byte Checksum(IEnumerable<byte> bytes, int offset, int length)
        {
            return bytes.Skip(offset).Take(length).Aggregate<byte, byte>(0, (byte acc, byte b) => (byte)(acc ^ b));
        }

        public static string GetHashDir(string szString, int seed = 7919, int HASHFS_MAX_LAYER_THRESHOLD = 157)
        {
            string strDir = "";
            string strTemp = "";

            int nHashValue = 0;
            int nLayerCount = 1;
            int nLayerSize = 0;

            if (seed <= HASHFS_MAX_LAYER_THRESHOLD)
            {
                nLayerSize = seed;
            }
            else
            {
                nLayerCount = 2;
                nLayerSize = seed / ((int)Math.Pow((double)seed, (double)0.5));
            }

            for (int i = 0; i < szString.Length; i++)
            {
                Encoding iso = Encoding.GetEncoding("ISO-8859-1");
                Encoding utf8 = Encoding.UTF8;
                byte[] utfBytes = utf8.GetBytes(szString[i].ToString());
                byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);

                if (isoBytes.Length > 0)
                {
                    nHashValue = ((nHashValue * 0x00FF) + (0x00FF & isoBytes[0])) % seed;
                }
            }

            for (int i = 0; i < nLayerCount; i++)
            {
                if (i == 0)
                {
                    strTemp = (nHashValue / nLayerSize).ToString("D8");
                }
                else
                {
                    strTemp = (nHashValue % nLayerSize).ToString("D8");
                    strDir += ("\\");
                }

                strDir += strTemp;
            }

            return strDir;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public ushort YY;
            public ushort MM;
            public ushort W;
            public ushort DD;
            public ushort HH;
            public ushort mm;
            public ushort ss;
            public ushort ms;
        }

        [DllImport("kernel32.dll")]
        public static extern bool SetLocalTime(ref SYSTEMTIME time);

        public static void SetSystemTime(int YY, int MM, int DD, int HH, int mm, int ss)
        {
            SYSTEMTIME st = new SYSTEMTIME();
            st.YY = (ushort)YY;
            st.MM = (ushort)MM;
            st.W = (ushort)DateTime.Now.DayOfWeek;
            st.DD = (ushort)DD;
            st.HH = (ushort)HH;
            st.mm = (ushort)mm;
            st.ss = (ushort)ss;
            st.ms = (ushort)0;

            bool bRet = SetLocalTime(ref st);
        }

        public static bool CreateZip(string strPath_Zip, List<byte[]> images)
        {
            //string strPath_Zip = $"{IGlobal.m_MainPJTRoot}\\{DateTime.Now.ToString("yyMMdd_HHmmss")}.zip";
            try
            {
                if (strPath_Zip != null && strPath_Zip != "")
                {
                    using (var archive = ZipFile.Open(strPath_Zip, ZipArchiveMode.Create))
                    {
                        for (int i = 0; i < images.Count; i++)
                        {
                            //using (Bitmap img = new Bitmap(imagesPath[i]))
                            {
                                //압축 파일 내 이미지 이름
                                string strFileName = $"{i}.jpg";

                                var demoFile = archive.CreateEntry(strFileName);

                                using (var entryStream = demoFile.Open())
                                using (var streamWriter = new StreamWriter(entryStream))
                                //using (var stream = new MemoryStream())
                                {
                                    //img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                                    //byte[] buff = stream.ToArray();

                                    streamWriter.BaseStream.Write(images[i], 0, images[i].Length);
                                }
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

            return true;
        }

        public static Bitmap Crop(Bitmap imgSource, Rectangle rtRoi)
        {
            if (rtRoi.Width == 0 || rtRoi.Height == 0) return null;

            Bitmap target = new Bitmap(rtRoi.Width, rtRoi.Height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(imgSource, new Rectangle(0, 0, target.Width, target.Height),
                                 rtRoi,
                                 GraphicsUnit.Pixel);
            }

            return target;
        }

        public static string GetFileModifiedDate(string strPath)
        {
            try
            {
                var lastModified = System.IO.File.GetLastWriteTime(strPath);
                return lastModified.ToString("yyyy/MM/dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return "0000/00/00 00:00:00";
            }
        }

        public static DateTime GetCompiledDateTime()
        {
            System.Version assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            // assemblyVersion.Build = days after 2000-01-01          
            // assemblyVersion.Revision*2 = seconds after 0-hour  (NEVER daylight saving time)        
            DateTime buildDate = new DateTime(2000, 1, 1).AddDays(assemblyVersion.Build).AddSeconds(assemblyVersion.Revision * 2);
            return buildDate;
        }

        public static void SaveCaptureScreen(string strPath)
        {
            try
            {
                int w = Screen.PrimaryScreen.Bounds.Width;
                int h = Screen.PrimaryScreen.Bounds.Height;

                System.Drawing.Size s = new System.Drawing.Size(w, h);
                Bitmap b = new Bitmap(w, h);
                Graphics g = Graphics.FromImage(b);

                g.CopyFromScreen(0, 0, 0, 0, s);
                if (Directory.Exists($"{Application.StartupPath}\\CAPTURE\\") == false) Directory.CreateDirectory($"{Application.StartupPath}\\CAPTURE\\");
                b.Save(strPath + ".jpeg", ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public static void InitCombobox(Control.ControlCollection Controls)
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is MetroComboBox)
                {
                    if ((Controls[i] as MetroComboBox).Items.Count > 0) (Controls[i] as MetroComboBox).SelectedIndex = 0;
                }
            }
        }

        public static void InitCombobox(MetroComboBox combobox)
        {
            if (combobox.Items.Count > 0) combobox.SelectedIndex = 0;
        }

        public static void SetImageBox(ImageGlass.ImageBoxEx ib, Mat image)
        {
            try
            {
                if (ib.InvokeRequired)
                {
                    ib.Invoke(new Action<ImageGlass.ImageBoxEx, Mat>(SetImageBox), ib, image);
                }
                else
                {
                    ib.Image = CConverter.ToBitmap(image.Clone());
                    ib.ZoomToFit();
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
            }
        }

        public static void SetLabelResult(Label lb, DEFINE.RESULT result)
        {
            try
            {
                if (lb.InvokeRequired)
                {
                    lb.Invoke(new Action<Label, DEFINE.RESULT>(SetLabelResult), lb, result);
                }
                else
                {
                    if (result == DEFINE.RESULT.OK)
                    {
                        lb.BackColor = DEFINE.COLOR_TEAL;
                        lb.Text = "OK";
                    }
                    else if (result == DEFINE.RESULT.NA)
                    {
                        lb.BackColor = DEFINE.COLOR_RED;
                        lb.ForeColor = Color.White;
                        lb.Text = "N/A";
                    }
                    else if (result == DEFINE.RESULT.NG)
                    {
                        lb.BackColor = DEFINE.COLOR_RED;
                        lb.ForeColor = Color.Yellow;
                        lb.Text = "NG";
                    }
                    if (result == DEFINE.RESULT.RVS)
                    {
                        lb.BackColor = DEFINE.COLOR_RED;
                        lb.ForeColor = Color.White;
                        lb.Text = "REVERSE";
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
            }
        }

        public static void SynchFolder(DirectoryInfo existingDir, DirectoryInfo copyDir)
        {
            try
            {
                // 각각의 폴더에 있는 파일을 얻습니다.
                FileInfo[] existingFiles = existingDir.GetFiles(); // 원본
                FileInfo[] copyFiles = copyDir.GetFiles(); // 대상 파일

                bool findFile = false;
                int nIndex = 0;

                #region 파일 비교

                foreach (var existingFile in existingFiles)
                {
                    findFile = false;
                    nIndex = -1;
                    foreach (var copyFile in copyFiles)
                    {
                        nIndex++;

                        if (copyFile == null)
                        {
                            continue;
                        }

                        // 두 파일의 이름이 같다면
                        if (existingFile.Name == copyFile.Name)
                        {
                            findFile = true;

                            // 두 파일의 마지막 쓰기 시간이 틀리다면
                            if (existingFile.LastWriteTime != copyFile.LastWriteTime)
                            {
                                try
                                {
                                    if (existingFile.LastWriteTime > copyFile.LastWriteTime)
                                    {
                                        File.Copy(existingFile.FullName, copyFile.FullName, true);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }

                                copyFiles[nIndex] = null;

                                break;
                            }
                        }
                    }

                    // 원본에는 있는데, 대상 폴더에 없는 경우에는 무조건 복사
                    if (!findFile)
                    {
                        try
                        {
                            String path = copyDir.FullName + "\\" + existingFile.Name;
                            existingFile.CopyTo(path);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }

                #endregion 파일 비교

                #region 폴더 비교

                DirectoryInfo[] existingFolders = existingDir.GetDirectories();
                DirectoryInfo[] copyFolders = copyDir.GetDirectories();

                foreach (var existingFolder in existingFolders)
                {
                    findFile = false;
                    nIndex = -1;

                    foreach (var copyFolder in copyFolders)
                    {
                        nIndex++;

                        if (copyFolder == null)
                        {
                            continue;
                        }

                        // 폴더가 있다면
                        if (existingFolder.Name == copyFolder.Name)
                        {
                            findFile = true;

                            // 재귀함수를 호출하여 폴더안에 폴더를 검사
                            // 재귀함수이기에 첫번째부터 진행하였던 파일들을 다시 검사
                            // 매개변수는 foreach문으로 처음에 가져왔던 폴더들로 다시 진행
                            SynchFolder(existingFolder, copyFolder);

                            copyFolders[nIndex] = null;

                            //break;
                        }
                    }

                    // 원본에는 있는데, 대상 폴더에 없는 경우에는 무조건 복사
                    if (!findFile)
                    {
                        try
                        {
                            string path = copyDir.FullName + "\\" + existingFolder.Name;
                            Directory.CreateDirectory(path);
                            SynchFolder(existingFolder, new DirectoryInfo(path));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }

            #endregion 폴더 비교

            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
            }
        }

        public static bool OpenCheckForm(Form form)
        {
            try
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Name == form.Name)
                    {
                        frm.Activate();
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        public static OpenCvSharp.Point CeterFromRect(OpenCvSharp.Rect rt)
        {
            return new OpenCvSharp.Point(rt.X + rt.Width / 2, rt.Y + rt.Height / 2);
        }

        public static System.Drawing.Point CeterFromRectangle(Rectangle rt)
        {
            return new System.Drawing.Point(rt.X + rt.Width / 2, rt.Y + rt.Height / 2);
        }

        [DllImport("gdi32.dll")] public static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);

        [DllImport("user32.dll")] public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        public static Control[] GetControls(Control con)
        {
            var conList = new List<Control>();

            foreach (Control control in con.Controls)
            {
                //컨트롤 속성으로 찾는 방법
                if (control is Button)
                {
                    int nSize = 30;

                    //15 로 전달 되어 있는 인자 -> 실제 모서리 둥글게 표현 하는 인자
                    IntPtr ip = CreateRoundRectRgn(0, 0, control.Width, control.Height, nSize, nSize);
                    SetWindowRgn(control.Handle, ip, true);
                    conList.Add(control);
                }
                ////컨트롤 이름으로 찾는 방법
                //if (control.Name == "그리드뷰")
                //    conList.Add(control);

                //주석
                if (control.Controls.Count > 0)
                    conList.AddRange(GetControls(control));
            }

            return conList.ToArray();
        }

        public static OpenCvSharp.Point RectOfCenter(Rect rt)
        {
            return new OpenCvSharp.Point(rt.X + rt.Width / 2, rt.Y + rt.Height / 2);
        }

        public static OpenCvSharp.Point RectangleOfCenter(Rectangle rt)
        {
            return new OpenCvSharp.Point(rt.X + rt.Width / 2, rt.Y + rt.Height / 2);
        }

        public static void CaptureScreen()
        {
            try
            {
                Bitmap FullScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics g = Graphics.FromImage(FullScreen);
                g.CopyFromScreen(new System.Drawing.Point(0, 0), new System.Drawing.Point(0, 0), new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
                g.Dispose();
                g = null;
                FullScreen.Save(@"D:\SAVE IMAGE\FullScreen\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bmp");
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
            }
        }

        public static bool IsImageEmpty(Mat image)
        {
            if (image == null)
            {
                CLogger.Add(LOG.ABNORMAL, "Image is null");
                return true;
            }

            if (image.IsDisposed)
            {
                CLogger.Add(LOG.ABNORMAL, "Image Disposed");
                return true;
            }

            if (image.Width == 0 || image.Height == 0)
            {
                CLogger.Add(LOG.ABNORMAL, "Image Size Empty");
                return true;
            }

            return false;
        }

        public static bool IsRectEmpty(Rect rt)
        {
            if (rt == null)
            {
                CLogger.Add(LOG.ABNORMAL, "Rect is null");
                return true;
            }

            if (rt.Width == 0 || rt.Height == 0)
            {
                CLogger.Add(LOG.ABNORMAL, "Rect Size Empty");
                return true;
            }

            return false;
        }

        public static bool SetImageChannel4(Mat image)
        {
            if (IsImageEmpty(image)) return false;

            if (image.Channels() == 1) Cv2.CvtColor(image, image, ColorConversionCodes.GRAY2RGB);
            if (image.Channels() == 3) Cv2.CvtColor(image, image, ColorConversionCodes.RGB2RGBA);

            return true;
        }

        public static bool SetImageChannel3(Mat image)
        {
            if (IsImageEmpty(image)) return false;

            if (image.Channels() == 1) Cv2.CvtColor(image, image, ColorConversionCodes.GRAY2RGB);
            if (image.Channels() == 4) Cv2.CvtColor(image, image, ColorConversionCodes.RGBA2RGB);

            return true;
        }

        public static Mat SetImageChannel3ToMat(Mat image)
        {
            if (IsImageEmpty(image)) return null;

            if (image.Channels() == 1) Cv2.CvtColor(image, image, ColorConversionCodes.GRAY2RGB);
            if (image.Channels() == 4) Cv2.CvtColor(image, image, ColorConversionCodes.RGBA2RGB);

            return image;
        }

        public static bool SetImageChannel1(Mat image)
        {
            if (IsImageEmpty(image)) return false;

            if (image.Channels() == 3) Cv2.CvtColor(image, image, ColorConversionCodes.RGB2GRAY);
            if (image.Channels() == 4) Cv2.CvtColor(image, image, ColorConversionCodes.RGBA2GRAY);

            return true;
        }

        public static Bitmap MatToBmp(Mat img)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img.Clone());
        }

        public static Mat BmpToMat(Bitmap img)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToMat(img);
        }

        public struct SystemTime
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int SetSystemTime([In] SystemTime st);

        public static List<string> GetExistsFolderList(string strFolderPath)
        {
            List<string> ListFolder = new List<string>();
            DirectoryInfo Info = new System.IO.DirectoryInfo(strFolderPath);

            if (Info.Exists)
            {
                DirectoryInfo[] CInfo = Info.GetDirectories("*", System.IO.SearchOption.AllDirectories);

                foreach (DirectoryInfo info in CInfo)
                {
                    ListFolder.Add(info.Name);
                }
            }

            return ListFolder;
        }

        public static void DrawCross(Graphics g, int nW, int nH, System.Drawing.Point pt, Color cr)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            System.Drawing.Point ptStart = new System.Drawing.Point();
            System.Drawing.Point ptEnd = new System.Drawing.Point();

            {
                ptStart.X = pt.X;
                ptStart.Y = 0;

                ptEnd.X = pt.X;
                ptEnd.Y = nH;

                if (cr == Color.Yellow) g.DrawLine(new Pen(new SolidBrush(cr), 10), ptStart, ptEnd);
                else g.DrawLine(new Pen(new SolidBrush(cr), 2), ptStart, ptEnd);
            }

            {
                ptStart.X = 0;
                ptEnd.X = nW;
                ptStart.Y = pt.Y;
                ptEnd.Y = pt.Y; ;

                if (cr == Color.Yellow) g.DrawLine(new Pen(new SolidBrush(cr), 10), ptStart, ptEnd);
                else g.DrawLine(new Pen(new SolidBrush(cr), 2), ptStart, ptEnd);
            }
        }

        public static double DrivePercent(string strTargetDriver, out double TotalSize, out double AvaliableSize)
        {
            double dPercent = 0;

            TotalSize = 0.0D;
            AvaliableSize = 0.0D;

            try
            {
                System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
                foreach (System.IO.DriveInfo drive in drives)
                {
                    if (drive.Name == strTargetDriver)
                    {
                        // 드라이브 전체 용량
                        TotalSize = drive.TotalSize / 1000000.0D / 1024.0D;
                        AvaliableSize = drive.AvailableFreeSpace / 1000000.0D / 1024.0D;

                        // 사용중인 용량 ( 전체 용량 - 사용 가능한 용량 )
                        double dUsedSize = (int)((drive.TotalSize - drive.AvailableFreeSpace) / 1000000 / 1024.0D);

                        dPercent = dUsedSize / TotalSize * 100.0D;
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

            return dPercent;
        }

        public static string LoadImage()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Global.m_MainPJTRoot;
                ofd.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string strFilePath = ofd.FileName;
                    CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                    return strFilePath;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
                return "";
            }

            return "";
        }

        public static string LoadPath()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Global.m_MainPJTRoot;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string strFilePath = ofd.FileName;
                    CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                    return strFilePath;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
                return "";
            }

            return "";
        }

        public static string SaveImage()
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = Global.m_MainPJTRoot;
                sfd.Filter = "Images Files(*.jpg; *.bmp; *.png)|*.jpg;*.bmp;*.png";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string strFilePath = sfd.FileName;
                    CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                    return strFilePath;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
                return "";
            }

            return "";
        }

        public static string[] LoadImages()
        {
            string[] Images = null;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Global.m_MainPJTRoot;
                ofd.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Images = ofd.FileNames;
                    CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                    return Images;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
                return Images;
            }

            return Images;
        }

        public static string InitLogDirectory()
        {
            string strLogPath = $"{Global.m_MainPJTRoot}\\Log\\{DateTime.Now.ToString("yyyy")}\\{DateTime.Now.ToString("MM")}";
            return strLogPath;
        }

        public static void InputOnlyNumber(object sender, KeyPressEventArgs e, bool nIsUsePoint, bool bUseMinus)
        {
            bool isValidInput = false;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if (nIsUsePoint == true) { if (e.KeyChar == '.') isValidInput = true; }
                if (bUseMinus == true) { if (e.KeyChar == '-') isValidInput = true; }

                if (isValidInput == false) e.Handled = true;
            }

            if (sender is TextBox)
            {
                if (nIsUsePoint == true)
                {
                    if (e.KeyChar == '.' && (string.IsNullOrEmpty((sender as TextBox).Text.Trim()) || (sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
                }
                if (bUseMinus == true)
                {
                    if (e.KeyChar == '-' && (!string.IsNullOrEmpty((sender as TextBox).Text.Trim()) || (sender as TextBox).Text.IndexOf('-') > -1)) e.Handled = true;
                }
            }
            else if (sender is MetroFramework.Controls.MetroTextBox)
            {
                if (nIsUsePoint == true)
                {
                    if (e.KeyChar == '.' && (string.IsNullOrEmpty((sender as MetroTextBox).Text.Trim()) || (sender as MetroTextBox).Text.IndexOf('.') > -1)) e.Handled = true;
                }
                if (bUseMinus == true)
                {
                    if (e.KeyChar == '-' && (!string.IsNullOrEmpty((sender as MetroTextBox).Text.Trim()) || (sender as MetroTextBox).Text.IndexOf('-') > -1)) e.Handled = true;
                }
            }
        }

        public static bool ShowMessageBox(string strHead, string strMessage, FormPopUp_MessageBox.MESSAGEBOX_TYPE type = FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL)
        {
            try
            {
                FormPopUp_MessageBox FrmMessageBox = new FormPopUp_MessageBox(strHead, strMessage, type);
                FrmMessageBox.TopMost = true;
                CLogger.Add(LOG.NORMAL, "[{0}] ==> {1}", strHead, strMessage);

                if (FrmMessageBox.ShowDialog() == DialogResult.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
                return false;
            }
        }

        //public static bool ShowMessageBox_Temp(string strHead, string strMessage, FormPopUp_MessageBox.MESSAGEBOX_TYPE type = FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL)
        //{
        //    try
        //    {
        //        FormPopUp_MessageBox FrmMessageBox = new FormPopUp_MessageBox(strHead, strMessage, type, true);
        //        FrmMessageBox.TopMost = true;
        //        CLogger.Add(LOG.NORMAL, "[{0}] ==> {1}", strHead, strMessage);

        //        FrmMessageBox.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
        //        return false;
        //    }

        //    return true;
        //}

        //public static bool ShowMemoryAlarm(string strMessage, FormMessageBox.MESSAGEBOX_TYPE type = FormMessageBox.MESSAGEBOX_TYPE.OKCANCEL)
        //{
        //    try
        //    {
        //        FormMessageBox_MemoryAlarm FrmMessageBox = new FormMessageBox_MemoryAlarm(strMessage);

        //        CLogger.Add(LOG_TYPE.NORMAL, "[MEMORY ALARM] ==> {1}", strMessage);

        //        if (FrmMessageBox.ShowDialog() == DialogResult.OK)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Add(LOG_TYPE.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
        //        return false;
        //    }
        //}
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            try
            {
                Type dgvType = dgv.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

                pi.SetValue(dgv, setting, null);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
            }
        }

        public static string GetDirectory()
        {
            try
            {
                string strDirectory = "";

                FolderBrowserDialog fbd = new FolderBrowserDialog();

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    strDirectory = fbd.SelectedPath;
                    return strDirectory;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
                return "";
            }
        }

        public static void UpdateLabelSignal(Label lb, bool bOn)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new Action<Label, bool>(UpdateLabelSignal), lb, bOn);
            }
            else
            {
                if (bOn)
                {
                    lb.BackColor = Color.Aquamarine;
                    lb.ForeColor = Color.Black;
                    lb.Text = "ON";
                }
                else
                {
                    lb.BackColor = Color.DimGray;
                    lb.ForeColor = Color.White;
                    lb.Text = "OFF";
                }
            }
        }

        public static void UpdateLabelResult(Label lb, bool bOK)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new Action<Label, bool>(UpdateLabelResult), lb, bOK);
            }
            else
            {
                if (bOK)
                {
                    lb.BackColor = Color.Aquamarine;
                    lb.ForeColor = Color.Black;
                    lb.Text = "OK";
                }
                else
                {
                    lb.BackColor = Color.Red;
                    lb.ForeColor = Color.Yellow;
                    lb.Text = "NG";
                }
            }
        }

        public static void UpdateLabelOnOff(Label lb, bool bOn)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new Action<Label, bool>(UpdateLabelOnOff), lb, bOn);
            }
            else
            {
                if (bOn)
                {
                    lb.BackColor = Color.Green;
                }
                else
                {
                    lb.BackColor = Color.DimGray;
                }
            }
        }

        public static void UpdateLabelOnOff(MetroTile lb, bool bOn)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new Action<MetroTile, bool>(UpdateLabelOnOff), lb, bOn);
            }
            else
            {
                if (bOn)
                {
                    lb.BackColor = DEFINE.COLOR_TEAL;
                    //lb.Style = MetroColorStyle.Lime;
                }
                else
                {
                    lb.BackColor = Color.DimGray;
                    //lb.Style = MetroColorStyle.Silver;
                }
            }
        }

        public static void UpdateLabelExist(MetroTile lb, bool bOn)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new Action<MetroTile, bool>(UpdateLabelExist), lb, bOn);
            }
            else
            {
                if (bOn)
                {
                    lb.BackColor = DEFINE.COLOR_TEAL;
                    lb.Text = "EXIST";
                    //lb.Style = MetroColorStyle.Lime;
                }
                else
                {
                    lb.BackColor = Color.DimGray;
                    lb.Text = "N/A";
                    //lb.Style = MetroColorStyle.Silver;
                }
            }
        }

        public static void UpdateLabelExist(Label lb, bool bOn)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new Action<Label, bool>(UpdateLabelExist), lb, bOn);
            }
            else
            {
                if (lb.Visible == false) lb.Visible = true;

                if (bOn)
                {
                    lb.BackColor = DEFINE.COLOR_TEAL;
                    lb.Text = "EXIST";
                    //lb.Style = MetroColorStyle.Lime;
                }
                else
                {
                    lb.BackColor = Color.DimGray;
                    lb.Text = "N/A";
                    //lb.Style = MetroColorStyle.Silver;
                }
            }
        }

        public static void UpdateLabelResult(MetroTile lb, bool bOn)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new Action<Label, bool>(UpdateLabelResult), lb, bOn);
            }
            else
            {
                if (bOn)
                {
                    lb.BackColor = Color.Green;
                    //lb.Style = MetroColorStyle.Lime;
                }
                else
                {
                    lb.BackColor = Color.Red;
                    //lb.Style = MetroColorStyle.Silver;
                }
            }
        }

        //public static void InitDirectory(string strFolderName)
        //{
        //    string strFolderPath = $"{IGlobal.m_MainPJTRoot}\\{strFolderName}\\";
        //    DirectoryInfo dirRecipe = new DirectoryInfo(strFolderPath);
        //    if (dirRecipe.Exists == false) dirRecipe.Create();
        //}

        public static bool InitImageDirectory(string strFolderName)
        {
            try
            {
                string strFolderPath = strFolderName;
                DirectoryInfo dirRecipe = new DirectoryInfo(strFolderPath);
                if (dirRecipe.Exists == false) dirRecipe.Create();

                return true;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
                return false;
            }
        }

        public static Bitmap Resize(Bitmap bmp, OpenCvSharp.Size sz)
        {
            Bitmap bmpResize = null;

            try
            {
                OpenCvSharp.Mat ImageResize = new OpenCvSharp.Mat();
                ImageResize = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmp);

                ImageResize = ImageResize.Resize(new OpenCvSharp.Size(sz.Width, sz.Height));
                bmpResize = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(ImageResize);

                ImageResize.Dispose();
                ImageResize = null;

                GC.Collect();
                return bmpResize;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
                return bmpResize;
            }
        }

        public static string[] AvalibleComports()
        {
            return System.IO.Ports.SerialPort.GetPortNames();
        }

        //public static string InitSaveImageDirectory(string firstPath, string lastPath)
        //{
        //    string strLogPath = IGlobal.m_MainPJTRoot;
        //    try
        //    {
        //        firstPath = firstPath + "\\";
        //        CUtil.InitDirectory(firstPath + DateTime.Now.ToString("yyyy"));
        //        CUtil.InitDirectory(firstPath + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM"));
        //        CUtil.InitDirectory(firstPath + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd"));
        //        CUtil.InitDirectory(firstPath + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd") + "\\" + lastPath);
        //        return strLogPath = IGlobal.m_MainPJTRoot + "\\" + firstPath + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd") + "\\" + lastPath;
        //    }
        //    catch
        //    {
        //        return strLogPath;
        //    }
        //}

        //public static bool DirBackup(string strFrom, string strTo)
        //{
        //    try
        //    {
        //        InitDirectory("BACKUP");

        //        //삭제
        //        DirectoryInfo di = new DirectoryInfo(strTo);
        //        if (di.Exists) di.Delete(true);

        //        //복사
        //        DirectoryInfo existingDir = new DirectoryInfo(strFrom);
        //        DirectoryInfo copyDir = new DirectoryInfo(strTo);
        //        copyDir.Create();

        //        SynchFolder(existingDir, copyDir);

        //        CLogger.Add(LOG_TYPE.NORMAL, $"[BACK-UP] From : {strFrom} To : {strTo}");

        //        CLogger.Add(LOG_TYPE.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
        //        CUtil.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");

        //        return false;
        //    }

        //    return true;
        //}

        //public static List<T> CloneList<T>(List<T> oldList)
        //{
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    MemoryStream stream = new MemoryStream();
        //    formatter.Serialize(stream, oldList);
        //    stream.Position = 0;
        //    return (List<T>)formatter.Deserialize(stream);
        //}

        //public static void InitDirectory_DateTime_ID(string strDirPath, string strID, bool bAuto = true)
        //{
        //    // 폴더 생성...처리 다시진행..
        //    string str_path = $"{strDirPath}\\{DateTime.Now.Year}\\{DateTime.Now.Month.ToString("D2")}";
        //    string str_type_path;

        //    if (bAuto)
        //    {
        //        str_type_path = $"{str_path}\\{DateTime.Now.Day.ToString("D2")}_Auto";
        //    }
        //    else
        //    {
        //        str_type_path = $"{str_path}\\{DateTime.Now.Day.ToString("D2")}_User";
        //    }

        //    string OK_path = $"{str_type_path}\\OK";
        //    string OK_QR_path = $"{OK_path}\\{strID}";
        //    string OK_PART_path = $"{OK_QR_path}\\Part";

        //    string NG_path = $"{str_type_path}\\NG";
        //    string NG_QR_path = $"{NG_path}\\{strID}";
        //    string NG_PART_path = $"{NG_QR_path}\\Part";
        //    string NG_CORP_path = $"{NG_QR_path}\\Crop";

        //    // 해당 폴더가 없을 경우 폴더 생성...
        //    if (!Directory.Exists(OK_QR_path)) Directory.CreateDirectory(OK_QR_path);
        //    // 해당 폴더가 없을 경우 폴더 생성...
        //    if (!Directory.Exists(OK_PART_path)) Directory.CreateDirectory(OK_PART_path);

        //    // 해당 폴더가 없을 경우 폴더 생성...
        //    if (!Directory.Exists(NG_QR_path)) Directory.CreateDirectory(NG_QR_path);
        //    // 해당 폴더가 없을 경우 폴더 생성...
        //    if (!Directory.Exists(NG_CORP_path)) Directory.CreateDirectory(NG_CORP_path);
        //    // 해당 폴더가 없을 경우 폴더 생성...
        //    if (!Directory.Exists(NG_PART_path)) Directory.CreateDirectory(NG_PART_path);

        //    //try
        //    //{
        //    //    //폴더
        //    //    DirectoryInfo dir = new DirectoryInfo(strDirPath);
        //    //    if (dir.Exists == false) dir.Create();

        //    //    //폴더\\년
        //    //    string strDirYear = $"{strDirPath}\\{DateTime.Now.Year}";
        //    //    dir = new DirectoryInfo(strDirYear);
        //    //    if (dir.Exists == false) dir.Create();

        //    //    //폴더\\년\\월
        //    //    string strDirMonth = $"{strDirYear}\\{DateTime.Now.Month.ToString("D2")}";
        //    //    dir = new DirectoryInfo(strDirMonth);
        //    //    if (dir.Exists == false) dir.Create();

        //    //    //폴더\\년\\월\\일
        //    //    string strAuto;
        //    //    if (bAuto)
        //    //        strAuto = "Auto";
        //    //    else
        //    //        strAuto = "User"; 

        //    //    string strDirDay = $"{strDirMonth}\\{DateTime.Now.Day.ToString("D2")}_{strAuto}";
        //    //    dir = new DirectoryInfo(strDirDay);
        //    //    if (dir.Exists == false) dir.Create();


        //    //    if (bAuto) // AutoSave
        //    //    {
        //    //        if (nSaveType == 0)     // All
        //    //        {
        //    //            //폴더\\년월일\\OK
        //    //            string strDirDay_OK = $"{strDirDay}\\OK";
        //    //            dir = new DirectoryInfo(strDirDay_OK);
        //    //            if (dir.Exists == false) dir.Create();

        //    //            //폴더\\년월일\\NG
        //    //            string strDirDay_NG = $"{strDirDay}\\NG";
        //    //            dir = new DirectoryInfo(strDirDay_NG);
        //    //            if (dir.Exists == false) dir.Create();

        //    //            string strDirDay_OK_QR = $"{strDirDay_OK}\\{strID}";
        //    //            dir = new DirectoryInfo(strDirDay_OK_QR);
        //    //            if (dir.Exists == false) dir.Create();

        //    //            string strDirDay_NG_QR = $"{strDirDay_NG}\\{strID}";
        //    //            DirectoryInfo dirNG = new DirectoryInfo(strDirDay_NG_QR);
        //    //            if (dirNG.Exists == false) dirNG.Create();
        //    //        }
        //    //        else if (nSaveType == 1 || nSaveType == 3)    // OK , Part
        //    //        {
        //    //            //폴더\\OK
        //    //            string strDirDay_OK = $"{strDirDay}\\OK";
        //    //            dir = new DirectoryInfo(strDirDay_OK);
        //    //            if (dir.Exists == false) dir.Create();

        //    //            //폴더\\OK\\ID
        //    //            string strDirDay_OK_QR = $"{strDirDay_OK}\\{strID}";
        //    //            dir = new DirectoryInfo(strDirDay_OK_QR);
        //    //            if (dir.Exists == false) dir.Create();
        //    //            if (nSaveType == 3)
        //    //            {
        //    //                //폴더\\OK\\ID\\Part
        //    //                string strDirDay_OK_QR_PART = $"{strDirDay_OK_QR}\\Part";
        //    //                DirectoryInfo dir_Crop = new DirectoryInfo(strDirDay_OK_QR_PART);
        //    //                if (dir_Crop.Exists == false) dir_Crop.Create();
        //    //            }
        //    //        }
        //    //        else if (nSaveType == 2 || nSaveType == 4)    // NG , Part
        //    //        {
        //    //            //폴더\\NG
        //    //            string strDirDay_NG = $"{strDirDay}\\NG";
        //    //            dir = new DirectoryInfo(strDirDay_NG);
        //    //            if (dir.Exists == false) dir.Create();

        //    //            //폴더\\NG\\ID
        //    //            string strDirDay_NG_QR = $"{strDirDay_NG}\\{strID}";
        //    //            dir = new DirectoryInfo(strDirDay_NG_QR);
        //    //            if (dir.Exists == false) dir.Create();

        //    //            //폴더\\NG\\ID\\Crop
        //    //            string strDirDay_NG_QR_CROP = $"{strDirDay_NG_QR}\\Crop";
        //    //            dir = new DirectoryInfo(strDirDay_NG_QR_CROP);
        //    //            if (dir.Exists == false) dir.Create();

        //    //            if (nSaveType == 4)
        //    //            {
        //    //                //폴더\\NG\\ID\\Part
        //    //                string strDirDay_NG_QR_PART = $"{strDirDay_NG_QR}\\Part";
        //    //                dir = new DirectoryInfo(strDirDay_NG_QR_PART);
        //    //                if (dir.Exists == false) dir.Create();
        //    //            }
        //    //        }
        //    //    }
        //    //    else // User Save
        //    //    {
        //    //        //Mono
        //    //        //string strDirDay_Mono = $"{strDirDay}\\MONO";
        //    //        //dir = new DirectoryInfo(strDirDay_Mono);
        //    //        //if (dir.Exists == false) dir.Create();

        //    //        //Color
        //    //        //string strDirDay_Color = $"{strDirDay}\\COLOR";
        //    //        //dir = new DirectoryInfo(strDirDay_Color);
        //    //        //if (dir.Exists == false) dir.Create();
        //    //    }

        //    //    return true;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
        //    //    return false;
        //    //}
        //}

        public static void AddImageToControl(Bitmap bmp, FlowLayoutPanel pn, int nMaxCount = 10)
        {
            try
            {
                if (pn.InvokeRequired)
                {
                    try
                    {
                        pn.BeginInvoke(new MethodInvoker(() =>
                        {
                            AddImageToControl(bmp, pn, nMaxCount);
                        }));
                    }
                    catch (Exception Desc)
                    {
                        CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                    }
                }
                else
                {
                    if (pn.Controls.Count > nMaxCount)
                    {
                        pn.Controls.RemoveAt(0);
                    }

                    PictureBox pb = new PictureBox();
                    pb.Width = pn.Width - 10;
                    pb.Height = pn.Height / nMaxCount;
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.Image = bmp;
                    pn.Controls.Add(pb);
                    pn.HorizontalScroll.Enabled = true;
                    pn.AutoScroll = true;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public static void SetLabelResult(Label lb, bool bResult)
        {
            try
            {
                if (lb.InvokeRequired)
                {
                    lb.Invoke(new Action<Label, bool>(SetLabelResult), lb, bResult);
                }
                else
                {
                    if (bResult)
                    {
                        lb.BackColor = Color.Green;
                        lb.Text = "OK";
                    }
                    else
                    {
                        lb.BackColor = DEFINE.COLOR_RED;
                        lb.ForeColor = Color.Yellow;
                        lb.Text = "NG";
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public static void SetLabelText(Label lb, string strText)
        {
            try
            {
                if (lb.InvokeRequired)
                {
                    lb.Invoke(new Action<Label, string>(SetLabelText), lb, strText);
                }
                else
                {
                    lb.Text = strText;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public static void SetLabelModel(Label lb, string text)
        {
            try
            {
                lb.Text = text;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public static void ShowHideForm(Form form, bool show /* otherwise hide */)
        {
            if (form.InvokeRequired)
            {
                form.Invoke(new Action<Form, bool>((formInstance, isShow) =>
                {
                    if (isShow)
                        formInstance.Show();
                    else
                        formInstance.Hide();
                }), form, show);
            }
            else
            {
                if (show)

                    form.Show();
                else
                    form.Hide();
            } //if
        } //ShowHideForm

        public static List<string> ParsingBufferIDS_old(string ids)
        {
            List<string> NgBufferIds = new List<string>();
            if (ids.Length > 0)
            {
                string[] strParse = ids.Split('/');
                QRParser qrMain = new QRParser(strParse[0], true);
                NgBufferIds.Add(qrMain.GetQR());
                for (int j = 1; j < strParse.Length; j++)
                {
                    QRParser qrAdd = new QRParser(qrMain.GetQRTitle() + strParse[j], true);
                    NgBufferIds.Add(qrAdd.GetQR());
                }
            }
            return NgBufferIds;
        }

        public static List<QRParser> GetQRS_FullIDS(string ids)
        {
            List<QRParser> QRS = new List<QRParser>();
            if (ids.Length > 0)
            {
                string[] strParse = ids.Split("/");
                if (strParse.Length > 0)
                {
                    for (int i = 0; i < strParse.Length; i++)
                    {
                        if (strParse[i] != "")
                        {
                            QRS.Add(new QRParser(strParse[i], true));
                        }
                    }
                }
            }
            return QRS;
        }

        public static string GetIDS_QRS(List<QRParser> QRS)
        {
            string ids = "";
            for (int i = 0; i < QRS.Count; i++)
            {
                if (i > 0)
                    ids += "/";
                ids += QRS[i].GetSerialNo();
            }
            return ids;
        }

        public static List<string> GetFullIDS_IDS_QR(string ids, QRParser BufferQR)
        {
            List<string> NgBufferIds = new List<string>();
            if (ids.Length > 0)
            {
                string[] strParse = ids.Split("/");

                for (int i = 0; i < strParse.Length; i++)
                    NgBufferIds.Add(BufferQR.GetQRTitle() + strParse[i]);
            }
            return NgBufferIds;
        }

        public static bool SetImageRange(Mat image, Scalar scMin, Scalar scMax, Mat outImg)
        {
            if (IsImageEmpty(image)) return false;

            if (image.Channels() == 4)
            {
                scMin.Val3 = 0; scMax.Val3 = 255;
                Cv2.InRange(image, scMin, scMax, outImg);
            }
            else

                Cv2.InRange(image, scMin, scMax, outImg);

            return true;
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
            }
        }

        public static void UpdateLabelText(Label lb, string text)
        {
            if (lb.InvokeRequired)
            {
                if (text != null)
                {
                    lb.Invoke(new Action<Label, string>(UpdateLabelText), lb, text);
                }
                else
                {
                    lb.Invoke(new Action<Label, string>(UpdateLabelText), lb, lb.Text);
                }
            }
            else
            {
                lb.Text = text;
            }
        }

        public static void UpdateLabelResul_slot_results(Label lb, bool bOK, Label lb_ref)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new Action<Label, bool, Label>(UpdateLabelResul_slot_results), lb, bOK, lb_ref);
            }
            else
            {
                if (lb_ref.Text == "FILL")
                {
                    if (bOK)
                    {
                        lb.BackColor = Color.Aquamarine;
                        lb.ForeColor = Color.Blue;
                        lb.Text = "OK";
                    }
                    else
                    {
                        lb.BackColor = Color.Silver;
                        lb.ForeColor = Color.Blue;
                        lb.Text = "NG";
                    }
                }
                else
                {
                    lb.BackColor = Color.Silver;
                    lb.ForeColor = Color.Blue;
                    lb.Text = "-";
                }
            }
        }

        public static void UpdateLabelOnOff_Exist(Label lb, string bOn)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new Action<Label, bool>(UpdateLabelOnOff), lb, bOn);
            }
            else
            {
                if (bOn == "True")
                {
                    lb.BackColor = DEFINE.COLOR_TEAL;
                    lb.ForeColor = Color.Green;
                    //lb.Text = "FILL";
                }
                else
                {
                    lb.BackColor = Color.DimGray;
                    lb.ForeColor = DEFINE.COLOR_RED;
                    //lb.Text = "Empty";
                }
            }
        }

        public static void UpdateLabelOnOff(Label lb, bool bOn, bool result)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new Action<Label, bool>(UpdateLabelOnOff), lb, bOn);
            }
            else
            {
                if (bOn)
                {
                    if (result)
                    {
                        lb.BackColor = DEFINE.COLOR_TEAL;
                        lb.ForeColor = Color.White;
                    }
                    else
                    {
                        lb.BackColor = DEFINE.COLOR_RED;
                        lb.ForeColor = Color.White;
                    }
                }
                else
                {
                    lb.BackColor = Color.DimGray;
                    lb.ForeColor = DEFINE.COLOR_TEAL;
                }
            }
        }

        public static string String_Reverse(string text)
        {
            char[] array = text.ToCharArray();
            string reverse = String.Empty;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                reverse += array[i];
            }

            return reverse;
        }

        public static List<Tuple<string, DateTime>> GetFiles(string findFolder, string ext = "*")
        {
            List<Tuple<string, DateTime>> files = new List<Tuple<string, DateTime>>();

            // 지정한 경로에 폴더가 있는지 확인
            if (System.IO.Directory.Exists(findFolder))
            {
                // DirectoryInfo Class를 생성합니다.
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(findFolder);

                foreach (System.IO.FileInfo File in di.GetFiles())
                {
                    string extension = File.Extension.ToLower();
                    if (File.Extension.ToLower().CompareTo(ext.ToLower()) == 0 || ext.CompareTo("*") == 0)
                    {
                        //String FileNameOnly = File.Name.Substring(0, File.Name.Length - 4);
                        //String FullFileName = File.FullName;
                        //MessageBox.Show(FullFileName + " " + FileNameOnly);
                        //string inFile = File.FullName;
                        //DateTime inTime = File.CreationTime;
                        files.Add(new Tuple<string, DateTime>(File.FullName, File.CreationTime));
                    }
                }
            }
            return files;
        }

        public static List<Tuple<string, DateTime>> GetFiles2(string findFolder, string fName = "*")
        {
            List<Tuple<string, DateTime>> files = new List<Tuple<string, DateTime>>();

            // 지정한 경로에 폴더가 있는지 확인
            if (System.IO.Directory.Exists(findFolder))
            {
                // DirectoryInfo Class를 생성합니다.
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(findFolder);

                foreach (System.IO.FileInfo File in di.GetFiles())
                {
                    string extension = File.Extension.ToLower();
                    if (File.Name.ToLower().CompareTo(fName.ToLower()) == 0 || fName.CompareTo("*") == 0)
                    {
                        //String FileNameOnly = File.Name.Substring(0, File.Name.Length - 4);
                        //String FullFileName = File.FullName;
                        //MessageBox.Show(FullFileName + " " + FileNameOnly);
                        //string inFile = File.FullName;
                        //DateTime inTime = File.CreationTime;
                        files.Add(new Tuple<string, DateTime>(File.FullName, File.CreationTime));
                    }
                }
            }
            return files;
        }

        public static List<Tuple<string, int, DateTime>> GetFolderInfos(string findFolder)
        {
            List<Tuple<string, int, DateTime>> FolderInfos = new List<Tuple<string, int, DateTime>>();

            // 지정한 경로에 폴더가 있는지 확인
            if (System.IO.Directory.Exists(findFolder))
            {
                // DirectoryInfo Class를 생성합니다.
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(findFolder);

                // foreach 구문을 이용하여 폴더 내부에 있는 폴더정보(GetDirectories() 사용)를 가져옵니다.
                foreach (var item in di.GetDirectories())
                {
                    // 폴더이름 출력
                    String strLog;
                    strLog = "Folder Name : " + item.FullName + "\n";
                    //CLogger.Add("Folder Name : " + item.Name);
                    // 폴더 파일 갯수 출력
                    strLog += "File Count In Folder : " + item.GetFiles().Length + "\n";
                    //CLogger.Add("File Count In Folder : " + item.GetFiles().Length);
                    // 폴더 생성 날짜 출력
                    strLog += "Create Data : " + item.CreationTime.ToString() + "\n";
                    //MessageBox.Show(strLog);
                    //CLogger.Add("Create Data : " + item.CreationTime());
                    FolderInfos.Add(new Tuple<string, int, DateTime>(item.FullName, item.GetFiles().Length, item.CreationTime));
                }
            }

            return FolderInfos;
        }

        public static DriveInfo FindDriveInfo(string findDrive)
        {
            // Drive 구하기
            DriveInfo[] dList = DriveInfo.GetDrives();
            DriveInfo dMatch = null;
            for (int i = 0; i < dList.Length; i++)
            {
                //DriveInfos.Add(new Tuple<string, long, long>(dList[i].Name, dList[i].TotalSize, dList[i].TotalFreeSpace));
                if (dList[i].Name.ToLower().CompareTo(findDrive.ToLower()) == 0)
                {
                    dMatch = dList[i];
                }
            }

            return dMatch;
        }

        public static double GetAvailDrive(char chDrive = 'D')
        {
            double dPercent = -1;
            string strDrive = string.Format("{0}:\\", chDrive);
            DriveInfo dInfo = FindDriveInfo(strDrive);
            if (dInfo != null)
            {
                dPercent = dInfo.TotalFreeSpace.ToDbDouble() / dInfo.TotalSize.ToDbDouble() * 100;
                //string strText = string.Format("DiskSpace : \"{0}\" , {1:0.#0}%", dInfo.Name, dPercent);
                //DiskSpace.Text = strText;
                //this.DiskSpace.Text = "DiskSpace : " + dInfo.Name.ToString() + dPercent.ToString();
            }
            return dPercent;
        }

        public static Tuple<int, int> CleanDrive(double dDelPercent = 20, int nDel = 30, string strCleanPath = "D:\\VISION_IMAGE")
        {
            int nDelFileCount = 0, nDelFolderCnt = 0;
            //String strDisp;
            //bool bDel = false;

            double dAvail = GetAvailDrive();
            if (dAvail < dDelPercent)
            {
                List<Tuple<string, int, DateTime>> Folders = GetFolderInfos(strCleanPath);
                Folders.Sort((FoldA, FoldB) => FoldA.Item3.CompareTo(FoldB.Item3));  // 람다식으로 정렬 구현함.
                for (int i = 0; i < Folders.Count; i++)
                {
                    if (nDelFileCount >= nDel)
                        break;
                    Tuple<int, int> tRetl = CleanDrive(dDelPercent, nDel, Folders[i].Item1);
                    nDelFolderCnt += tRetl.Item1;
                    nDelFileCount += tRetl.Item2;
                }

                //    foreach (var item in Folders)
                //    {
                //        Tuple<int, int> tRetl = CleanDrive(item.Item1, nDel, dDelPercent);
                //        nDelFolderCnt += tRetl.Item1;
                //        nDelFileCount += tRetl.Item2;
                //    }
            }

            // 파일 삭제
            List<Tuple<string, DateTime>> Files = GetFiles(strCleanPath);
            Files.Sort((FileA, FileB) => FileA.Item2.CompareTo(FileB.Item2));    // 람다식으로 정렬 구현함.
            if (Files.Count > 0)
            {
                for (int i = 0; i < Files.Count; i++)
                {
                    if (nDelFileCount >= nDel)
                        break;

                    DeleteFile(Files[i].Item1);
                    Files.RemoveAt(i);
                    i--;
                    nDelFileCount++;
                    //bDel = true;
                }
                if (Files.Count == 0)
                {
                    DeleteDirectory(strCleanPath);
                    nDelFolderCnt++;
                    //bDel = true;
                }
            }

            //strDisp = "DeleteFolder : " + nDelFolderCnt + " , DeleteFile : " + nDelFileCount.ToString();
            //if (bDel)
            //    CLogger.Add(LOG_TYPE.NORMAL, strDisp);
            //MessageBox.Show(strDisp);
            Tuple<int, int> tRet = new Tuple<int, int>(nDelFolderCnt, nDelFileCount);
            return tRet;
        }

        public static List<Tuple<string, DateTime>> GetFileList(string findPath = "E:\\VISION_IMAGE", string strExt = "*")
        {
            List<Tuple<string, DateTime>> retList = new List<Tuple<string, DateTime>>();
            //int nDelFileCount = 0, nDelFolderCnt = 0;
            //String strDisp;
            //bool bDel = false;

            List<Tuple<string, int, DateTime>> Folders = GetFolderInfos(findPath);
            Folders.Sort((FoldA, FoldB) => FoldA.Item3.CompareTo(FoldB.Item3));  // 람다식으로 정렬 구현함.
            for (int i = 0; i < Folders.Count; i++)
            {
                List<Tuple<string, DateTime>> tRetl = GetFileList(Folders[i].Item1, strExt);
                for (int j = 0; j < tRetl.Count; j++)
                {
                    retList.Add(tRetl[j]);
                }
            }

            // 파일 추가
            List<Tuple<string, DateTime>> Files = GetFiles(findPath, strExt);
            Files.Sort((FileA, FileB) => FileA.Item2.CompareTo(FileB.Item2));    // 람다식으로 정렬 구현함.
            if (Files.Count > 0)
            {
                for (int i = 0; i < Files.Count; i++)
                {
                    retList.Add(Files[i]);
                }
            }

            return retList;
        }

        public static List<Tuple<string, DateTime>> GetFileList2(string findPath = "E:\\VISION_IMAGE", string strName = "*")
        {
            List<Tuple<string, DateTime>> retList = new List<Tuple<string, DateTime>>();

            List<Tuple<string, int, DateTime>> Folders = GetFolderInfos(findPath);
            Folders.Sort((FoldA, FoldB) => FoldA.Item3.CompareTo(FoldB.Item3));  // 람다식으로 정렬 구현함.
            for (int i = 0; i < Folders.Count; i++)
            {
                List<Tuple<string, DateTime>> tRetl = GetFileList2(Folders[i].Item1, strName);
                for (int j = 0; j < tRetl.Count; j++)
                {
                    retList.Add(tRetl[j]);
                }
            }

            // 파일 추가
            List<Tuple<string, DateTime>> Files = GetFiles2(findPath, strName);
            Files.Sort((FileA, FileB) => FileA.Item2.CompareTo(FileB.Item2));    // 람다식으로 정렬 구현함.
            if (Files.Count > 0)
            {
                for (int i = 0; i < Files.Count; i++)
                {
                    retList.Add(Files[i]);
                }
            }

            return retList;
        }

        public static string DeleteFile(string strPath)
        {
            string strMsg;
            if (File.Exists(strPath))
            {
                try
                {
                    File.Delete(strPath);
                    strMsg = string.Format("{0} File Delete Success!", strPath);
                }
                catch (Exception e)
                {
                    strMsg = string.Format("{1} File deletion failed: {0}", e.Message, strPath);
                    MessageBox.Show(strMsg);
                }
            }
            else
            {
                strMsg = string.Format("{0} file doesn't exist", strPath);
                MessageBox.Show(strMsg);
            }
            return strMsg;
        }

        public static void DeleteDirectory(string path)
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                DeleteDirectory(directory);
            }

            try
            {
                Directory.Delete(path, true);
            }
            catch (IOException)
            {
                Directory.Delete(path, true);
            }
            catch (UnauthorizedAccessException)
            {
                Directory.Delete(path, true);
            }
        }

        public static string ReplaceLine(string strFull, string strFind, string strReplace)
        {
            StringReader reader = new StringReader(strFull);

            string strLine = "", strRet = "";
            while (true)
            {
                strLine = reader.ReadLine();
                if (strLine.IsEmpty())
                    break;
                if (strLine.Contains(strFind))
                {
                    if (strReplace.Length > 0)
                    {
                        int nSpace = strLine.IndexOf(strFind);
                        strLine = "";
                        for (int i = 0; i < nSpace; i++)
                            strLine += " ";
                        strLine += strReplace;
                        strLine += "\n";
                        strRet += strLine;
                    }
                }
                else
                {
                    strLine += "\n";
                    strRet += strLine;
                }
                strLine = "";
            }
            return strRet;
        }

        public static string InsertFindAfterLine(string strFull, string strFind, string strInsert)
        {
            StringReader reader = new StringReader(strFull);
            bool bFind = false;
            int nSpace = 0;

            string strLine = "", strRet = "";
            while (true)
            {
                if (bFind)
                {
                    for (int i = 0; i < nSpace; i++)
                        strLine += " ";
                    strLine += strInsert;
                    bFind = false;
                    nSpace = 0;
                }
                else
                {
                    strLine = reader.ReadLine();
                    if (strLine.IsEmpty())
                        break;
                    if (strLine.Contains(strFind))
                    {
                        bFind = true;
                        nSpace = strLine.IndexOf(strFind);
                    }
                }

                strLine += "\n";
                strRet += strLine;
                strLine = "";
            }
            return strRet;
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

        public static string ReplaceBeetweenItem(string strData, string strStart, string strEnd, string strReplace, bool bInString = false)
        {
            string strPrve = "", strPost = "", strFind = "";
            string strRet = strData;
            int nStart = strData.IndexOf(strStart);
            int nEnd = strData.IndexOf(strEnd);
            int nDel = nEnd + 1;
            if (nStart >= 0 && nEnd >= 0)
            {
                if (bInString)
                    nStart += (int)strStart.Length;
                if (!bInString)
                    nEnd += (int)strEnd.Length;
                strPrve = strData.Substring(0, nStart);
                strFind = strData.Substring(nStart, nEnd - nStart);
                strPost = strData.Substring(nEnd);
                strRet = strPrve + strReplace + strPost;
            }
            return strRet; ;
        }

        //public static string InsertXml(string source, string findItem, string InputItem)
        //{
        //    int nFind = source.IndexOf(findItem);
        //    //int nStart = source.IndexOf()
        //}

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

        public static string GetPath(string strIn)
        {
            int nEnd = strIn.LastIndexOf("\\");
            return strIn.Substring(0, nEnd);
        }

        public static string GetPathName(string strFull)
        {
            int nStart = strFull.LastIndexOf("\\") + 1;
            return strFull.Substring(nStart);
        }

        public static void copyFolder(string sourceDir, string destinationDir, bool recursive, bool bFile = false)
        {
            List<string> vppLists = new List<string>();
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            if (bFile)
            {
                // Get the files in the source directory and copy to the destination directory
                foreach (FileInfo file in dir.GetFiles())
                {
                    string targetFilePath = Path.Combine(destinationDir, file.Name);
                    file.CopyTo(targetFilePath, true);
                }
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    copyFolder(subDir.FullName, newDestinationDir, recursive, bFile);
                }
            }
        }

        public static List<string> convertFolderNFiles(string sourceDir, string destinationDir, bool recursive, int nMode, string ext = ".xml")
        {
            List<string> vppLists = new List<string>();
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] Files = dir.GetFiles();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo fileObject in Files)
            {
                string extension = fileObject.Extension.ToLower();
                if (fileObject.Extension.ToLower().CompareTo(ext.ToLower()) != 0 || fileObject.Name.ToLower().CompareTo("parameter.xml") == 0)
                {
                    //string targetFilePath = Path.Combine(destinationDir, fileObject.Name);
                    string targetFilePath;
                    if (nMode == 0)
                    {
                        targetFilePath = destinationDir + $"\\0_" + fileObject.Name;
                    }
                    else
                    {
                        targetFilePath = destinationDir + "\\" + fileObject.Name;
                    }
                    vppLists.Add(targetFilePath);
                    fileObject.CopyTo(targetFilePath, true);
                }
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    List<string> retLists = convertFolderNFiles(subDir.FullName, newDestinationDir, recursive, nMode, ext);
                    for (int i = 0; i < retLists.Count; i++)
                    {
                        vppLists.Add(retLists[i]);
                    }
                }
            }
            return vppLists;
        }

        public static List<int> CleanConvertedFolder(string targetDir, int nMode, int nLevel = 0, string ext = ".vpp")
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(targetDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Target directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] Files = dir.GetFiles();

            int nCountExt = 0, nCountJobs = 0, nCountParams = 0;
            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo fileObject in Files)
            {
                if (fileObject.Name.ToLower().CompareTo("jobs0.xml") == 0)
                    nCountJobs++;
                if (fileObject.Name.ToLower().CompareTo("parameter.xml") == 0)
                    nCountParams++;
                if (fileObject.Extension.ToLower().CompareTo(ext.ToLower()) == 0)
                {
                    nCountExt++;
                    //if (nLevel > 1 && nMode == 1) // Recipe Jobs(Level2)일시
                    //    fileObject.Delete();
                }
            }

            // If recursive and copying subdirectories, recursively call this method

            foreach (DirectoryInfo subDir in dirs)
            {
                bool bDel = false;
                List<int> nRetLists = CleanConvertedFolder(subDir.FullName, nMode, nLevel + 1, ext);
                if (nMode == 0 && nLevel == 0) // Root PBA
                {
                    if (nRetLists[0] <= 0)
                        bDel = true;
                    else if (nRetLists[1] <= 0)
                        bDel = true;
                }
                else if (nMode == 1 && nLevel == 0) // Root Recipe
                {
                    if (nRetLists[2] <= 0)
                        bDel = true;
                }
                if (bDel)
                    DeleteDirectory(subDir.FullName);
                //subDir.Delete();
            }

            List<int> nRets = new List<int>();
            nRets.Add(nCountExt);
            nRets.Add(nCountJobs);
            nRets.Add(nCountParams);
            return nRets;
        }

        public static int GetFilesInCount(FileInfo[] Files, string extension)
        {
            int count = 0;
            foreach (FileInfo file in Files)
            {
                if (file.Extension.ToUpper() == extension.ToUpper())
                    count++;
            }
            return count;
        }

        public static string GetJudgeString(bool bOk)
        {
            string strOk;
            if (bOk)
                strOk = "OK";
            else
                strOk = "NG";
            return strOk;
        }

        [DllImport("GDI32.DLL", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern bool StretchBlt(IntPtr hdcDest, int nXDest, int nYDest, int nDestWidth, int nDestHeight,
                IntPtr hdcSrc, int nXSrc, int nYSrc, int nSrcWidth, int nSrcHeight, TernaryRasterOperations dwRop);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        private static extern IntPtr BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        public enum TernaryRasterOperations
        {
            SRCCOPY = 0x00CC0020, /* dest = source*/
            SRCPAINT = 0x00EE0086, /* dest = source OR dest*/
            SRCAND = 0x008800C6, /* dest = source AND dest*/
            SRCINVERT = 0x00660046, /* dest = source XOR dest*/
            SRCERASE = 0x00440328, /* dest = source AND (NOT dest )*/
            NOTSRCCOPY = 0x00330008, /* dest = (NOT source)*/
            NOTSRCERASE = 0x001100A6, /* dest = (NOT src) AND (NOT dest) */
            MERGECOPY = 0x00C000CA, /* dest = (source AND pattern)*/
            MERGEPAINT = 0x00BB0226, /* dest = (NOT source) OR dest*/
            PATCOPY = 0x00F00021, /* dest = pattern*/
            PATPAINT = 0x00FB0A09, /* dest = DPSnoo*/
            PATINVERT = 0x005A0049, /* dest = pattern XOR dest*/
            DSTINVERT = 0x00550009, /* dest = (NOT dest)*/
            BLACKNESS = 0x00000042, /* dest = BLACK*/
            WHITENESS = 0x00FF0062, /* dest = WHITE*/
        };

        public static void DrawStretchBlt(Graphics g, Bitmap bmp, Rectangle rctSource,
            Rectangle rctTarget, TernaryRasterOperations operations)
        {
            int width = bmp.Width;
            int height = bmp.Height;

            IntPtr hdc = g.GetHdc();//원본
            IntPtr hsrc = CreateCompatibleDC(hdc);//타겟
            IntPtr hwnd = GetDesktopWindow();

            //create Graphic from source bitmap

            Graphics bmpGraphic = Graphics.FromImage(bmp);
            //because (when uncommented) the following line works for coping a block from the form???
            //Graphics bmpGraphic = this.CreateGraphics();

            //get handle to source graphic
            IntPtr srcHdc = bmpGraphic.GetHdc();

            //copy it
            bool res = StretchBlt(hdc, rctTarget.X, rctTarget.Y, rctTarget.Width, rctTarget.Height,
                srcHdc, rctSource.X, rctSource.Y, rctSource.Width, rctSource.Height, operations);

            //release handles
            bmpGraphic.ReleaseHdc();
            ReleaseDC(hwnd, hdc);
        }

        public static bool FileExist(string path)
        {
            FileInfo info = new FileInfo(path);     // path를 이용하여 FileInfo 생성
            // 존재 유무 확인
            if (info.Exists)
                return true;
            else
                return false;
        }

        public static string GetExcutePath()
        {
            return System.Environment.CurrentDirectory;
        }
    }
}