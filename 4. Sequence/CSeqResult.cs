using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntelligentFactory
{
    internal class CSeqResult : CSeqBase
    {
        private Global Global = Global.Instance;
        public EventHandler<EventArgs> EventInitEnd;
        public CSeqResult()
        {
            ThreadName = "SEQ_Result";
            StartThread();
        }

        public override void Run()
        {
            try
            {
                Thread.Sleep(10);
               

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
