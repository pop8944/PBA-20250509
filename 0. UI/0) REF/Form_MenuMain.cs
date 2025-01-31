using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cognex.VisionPro.Display;


namespace IF
{
    public partial class Form_MenuMain : Form
    {
        Global Global = Global.Instance;
        private string _thisName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
        private Bitmap _image = null;


        private CogDisplay[] Display;

        public Form_MenuMain()
        {
            InitializeComponent();
        }

        private void OnGrabbedDisplay(object sender, (int, IntPtr) e)   //240704 mwpark 추가
        {
            try
            {

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
        
        private void InitUI()
        {
            Display = new CogDisplay[4] { cogDisplay_Array1, cogDisplay_Array2, cogDisplay_Array3, cogDisplay_Array4 };
            
        }

        public void InitDisplayLayout()
        {
            try
            {
                // 광주(true)는 왼쪽이 1번 
                if (Global.Setting.Enviroment.Country == Setting_Enviroment.COUNTRY.KOR)
                {
                    pnlArray1.Location = new System.Drawing.Point(1, 1);
                    pnlArray2.Location = new System.Drawing.Point(730, 1);
                    pnlArray3.Location = new System.Drawing.Point(1, 430);
                    pnlArray4.Location = new System.Drawing.Point(724, 430);
                }
                else //폴란드(false)는 오른쪽이 1번
                {
                    pnlArray1.Location = new System.Drawing.Point(730, 1);
                    pnlArray2.Location = new System.Drawing.Point(1, 1);
                    pnlArray3.Location = new System.Drawing.Point(730, 430);
                    pnlArray4.Location = new System.Drawing.Point(1, 430);
                }

                // 보드 카운트 수량에 따라...표시..
                if (Global.Setting.Recipe.Insp.ArrayCount == 1)
                {
                    pnlArray1.Visible = true;
                    pnlArray1.Size = new System.Drawing.Size(1460, 860);
                    pnlArray2.Visible = false;
                    pnlArray3.Visible = false;
                    pnlArray4.Visible = false;
                }
                else if (Global.Setting.Recipe.Insp.ArrayCount == 2)
                {
                    pnlArray1.Visible = true;
                    pnlArray1.Size = new System.Drawing.Size(730, 860);
                    pnlArray2.Visible = true;
                    pnlArray2.Size = new System.Drawing.Size(730, 860);
                    pnlArray3.Visible = false;
                    pnlArray4.Visible = false;
                }
                else if (Global.Setting.Recipe.Insp.ArrayCount == 3)
                {
                    pnlArray1.Visible = true;
                    pnlArray1.Size = new System.Drawing.Size(730, 430);
                    pnlArray2.Visible = true;
                    pnlArray2.Size = new System.Drawing.Size(730, 430);
                    pnlArray3.Visible = true;
                    pnlArray4.Visible = false;
                }
                else
                {
                    pnlArray1.Visible = true;
                    pnlArray1.Size = new System.Drawing.Size(723, 430);
                    pnlArray2.Visible = true;
                    pnlArray2.Size = new System.Drawing.Size(723, 430);
                    pnlArray3.Visible = true;
                    pnlArray4.Visible = true;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

        }
        private void OnInitEnd(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnInitEnd(sender, e);
                    }));
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
            else
            {
                try
                {
                    InitDisplayLayout();
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
        }

        //private void Grabber_OnAllocated(object sender, List<IIfCamera> e)
        //{
        //    Console.WriteLine("Connected");
        //}

        private void Form_MenuMain_Load(object sender, EventArgs e)
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            CLogger.Add(LOG.SYSTEM, $"Application Start => Method : {MethodName}");

            Global.SeqInitialize.EventInitEnd += OnInitEnd;

            try
            {
                InitEvent();
                InitComponents();
                InitUI();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void InitComponents()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void InitEvent()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
           
        }

        private void timerInit_Tick(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }


        private void btnOpenLogFolder_Click(object sender, EventArgs e)     //240628 mwpark 추가
        {
            System.Diagnostics.Process.Start($"{Application.StartupPath}\\log\\{DateTime.Now.Year:0000}\\{DateTime.Now.Month:00}\\{DateTime.Now.Day:00}");
        }

        private void Form_MenuMain_Shown(object sender, EventArgs e)
        {
          
        }

    }
}
