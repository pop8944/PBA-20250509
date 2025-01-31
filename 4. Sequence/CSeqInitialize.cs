using System;
using System.Reflection;
using System.Threading;

namespace IntelligentFactory
{
    //레시피 파일 을 로드하지 않고 고정적으로 Open 혹은 핸들링 하는 객체들
    public class CSeqInitialize : CSeqBase
    {
        private Global Global = Global.Instance;
        public EventHandler<EventArgs> EventInitEnd;

        public CSeqInitialize()
        {
            ThreadName = "SEQ_INITIALIZE";
            StartThread();
        }

        public override void Run()
        {
            try
            {
                Thread.Sleep(10);

                // Global에서 시작하는 초기화 처리..
                Global.Instance.Init();
                // 필요 메인 쓰레드 동작..
                Global.Instance.start();

                // Develop일시 실행파일 만든다.
                if (Global.Instance.Mode.isDeveloper)
                {
                    string strMsg = Util.CopyExcuteFiles();
                    CLogger.Add(LOG.NORMAL, strMsg);
                }

                Global.Instance.FileManager.CountLoad();
                Global.Instance.System.Authorization = DEFINE.AUTHORIZATION.MASTER;
                Global.Instance.OnEnd_Progress();

                // Cognex License가 없을때...인터락 메세지 표시..
                if (Global.m_Vision_CognexLicense_Error)
                {
                    IF_Util.ShowMessageBox("Error", "Not Cognex License Key!! Cognex License Key Insert Please!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);
                }



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
}

