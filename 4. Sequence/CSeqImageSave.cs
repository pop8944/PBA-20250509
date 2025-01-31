using OpenCvSharp;
using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Threading;

namespace IntelligentFactory
{
    public class CSeqImageSave : CSeqBase
    {
        private Global Global = Global.Instance;
        public EventHandler<EventArgs> EventInitEnd;
        public ConcurrentQueue<ImageSaveNode> ImgQueue;
        public CSeqImageSave()
        {
            ThreadName = "SEQ_ImageSave";
            StartThread();
        }

        public override void Run()
        {
            try
            {
                Thread.Sleep(10);
                while (ImgQueue.Count > 0)
                {
                    ImgQueue.TryDequeue(out var item);
                    //using (Mat image  = item.img.Clone())
                    //{
                    //    Cv2.ImWrite("");
                    //}

                }
                // Global에서 시작하는 초기화 처리..
                StopThread();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
            finally
            {
                EventInitEnd?.Invoke(this, EventArgs.Empty);
            }
        }

    }
    public class ImageSaveNode
    {
        Mat img;
        string SavePath;
    }
}
