using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.PMAlign;
using MetroFramework.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;

using OpenCvSharp;
using OpenCvSharp.Blob;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static IntelligentFactory.CJob;
using static IntelligentFactory.TcpIp;

namespace IntelligentFactory
{
    public partial class FormMenu_Vision_Backup : Form
    {
        private Global Global = Global.Instance;
        private CSeqRecipeSave SeqRecipeSave = new CSeqRecipeSave();

        private int m_nSelectedArrayIndex = 1;

        public int m_nSelectGrabIndex = 0;

        private CJob m_selectedJob = null;
        private int m_nSelectedIndex_Library = 0;

        public Cognex.VisionPro.CogImage8Grey m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey();
        public static Cognex.VisionPro.CogImage24PlanarColor m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor();
        public Cognex.VisionPro.CogImage24PlanarColor m_imgSource_Color_FullBoard = new Cognex.VisionPro.CogImage24PlanarColor();
        public Cognex.VisionPro.CogImage8Grey m_imgSource_Mono_FullBoard = new Cognex.VisionPro.CogImage8Grey();

        public Cognex.VisionPro.CogImage24PlanarColor[] _imagesGrab = new Cognex.VisionPro.CogImage24PlanarColor[5];
        public Cognex.VisionPro.CogImage24PlanarColor[] MenualInsImgArray = new Cognex.VisionPro.CogImage24PlanarColor[5];
        private Cognex.VisionPro.CogImage8Grey m_imgSource_Filter = new Cognex.VisionPro.CogImage8Grey();


        private CogDisplayStatusBarV2 m_cogDisplayStatus = new CogDisplayStatusBarV2();
        private string _ProcessMode = "IDLE";
        private List<Label> lbselectArraies = new List<Label>();
        private List<Label> lbselectResulties = new List<Label>();

        //private VisionTools visionTool = new VisionTools();
        private List<Cognex.VisionPro.CogRectangle> CropRect = new List<CogRectangle>();

        private Cognex.VisionPro.CogRectangle Roi_ColorSearchRegion = new Cognex.VisionPro.CogRectangle();
        private Cognex.VisionPro.CogRectangle Roi_ColorVAlues = new Cognex.VisionPro.CogRectangle();

        private int BlobPos_X = 0;
        private int BlobPos_Y = 0;
        private bool _bResult_Action = true;

        public FormMenu_Vision_Backup()
        {
            InitializeComponent();

            comboArray.SelectedIndex = 0;

            m_cogDisplayStatus.Display = DispMain;
            m_cogDisplayStatus.CoordinateSpaceName = "*\\#";
            m_cogDisplayStatus.Dock = DockStyle.Fill;
            m_cogDisplayStatus.ForeColor = Color.Yellow;
            pnStatus.Controls.Add(m_cogDisplayStatus);

            IF_Util.InitCombobox(comboCloneTo);
        }

        private void FormMenu_Vision_Load(object sender, EventArgs e)
        {
            try
            {
                this.DoubleBuffered = true;

                Global.SeqRecipeChage.EventRecipeChangeEnd += OnRecipeChageEnd;
                SeqRecipeSave.EventRecipeSaveEnd += OnRecipeSaveEnd;

                InitEvent();
                InitUI();
                Init_UI_FIN();
                InitProperty();
                CopyObject_Init();
                InitType();
                InitRecipeList();
                DisplayGrabIdx0.MouseWheelMode = CogDisplayMouseWheelModeConstants.None;
                DisplayGrabIdx1.MouseWheelMode = CogDisplayMouseWheelModeConstants.None;
                DisplayGrabIdx2.MouseWheelMode = CogDisplayMouseWheelModeConstants.None;
                DisplayGrabIdx3.MouseWheelMode = CogDisplayMouseWheelModeConstants.None;
                DisplayGrabIdx4.MouseWheelMode = CogDisplayMouseWheelModeConstants.None;

                // 이미지 어레이 처리 잡 매니저 수량만큼 생성..
                InitJobs();
                //====================================================================================
                // 그랩 이미지 디스플레이 런..
                GrabDisp_TaskRun();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

        }

        private void OnRecipeChageEnd(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnRecipeChageEnd(sender, e);
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
                    InitUI();
                    InitJobs();
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
        }

        private void OnRecipeSaveEnd(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnRecipeSaveEnd(sender, e);
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
                    //gridLibrary.Refresh();
                    //Global.OnEnd_Progress();
                    Global.Instance.SelectedMenu = "VISION";
                    IF_Util.ShowMessageBox("SAVE", "Completed the Save");
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
        }

        public void UpdateArrayButtones()
        {
            for (int i = 0; i < Global.System.Recipe.ArrayCount; i++)
            {
                lbselectArraies[i].Enabled = true;
                lbselectResulties[i].Enabled = true;
            }
            for (int i = Global.System.Recipe.ArrayCount; i < 4; i++)
            {
                lbselectArraies[i].Enabled = false;
                lbselectResulties[i].Enabled = false;
            }
        }

        public void CopyObject_Init()
        {
            lbselectArraies.Add(lbSelectArray1);
            lbselectArraies.Add(lbSelectArray2);
            lbselectArraies.Add(lbSelectArray3);
            lbselectArraies.Add(lbSelectArray4);

            lbselectResulties.Add(lbSelectResult1);
            lbselectResulties.Add(lbSelectResult2);
            lbselectResulties.Add(lbSelectResult3);
            lbselectResulties.Add(lbSelectResult4);

            UpdateArrayButtones();
            //OnClickSelectArray(lbSelectArray1, null);
        }

        private void Init_UI_FIN()
        {
            if (m_selectedJob == null) return;

            if (m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool == null) m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool = new CTemplateMatching("Fin");

            if (m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.m_MatchingTemplateImage != null)
            {
                CogDisplay_FinMatchingTemplateImg.Image = new CogImage8Grey(m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.m_MatchingTemplateImage);
            }
            else
            {
                CogDisplay_FinMatchingTemplateImg.Image = null;
            }

            txt_PinMatchingScoreMin.Text = m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.m_Score_Min.ToString();
            // 블랍 내용 추가..
            tbAreaMin.Text = m_selectedJob.Fin_InspecTool.BlobAreaMin.ToString();
            tbAreaMax.Text = m_selectedJob.Fin_InspecTool.BlobAreaMax.ToString();
            txtBlobThreshold.Text = m_selectedJob.Fin_InspecTool.BlobThreshold.ToString();
            //trbThreshold_Tab.Value = m_selectedJob.Fin_InspecTool.BlobThreshold;
            //chkThresholdInv.Check = m_selectedJob.Fin_InspecTool.BlobThresholdInv;
        }

        private void InitType()
        {
            comboAlgorithm.Items.Clear();
            for (int i = 0; i < tcAlgorithm.TabPages.Count; i++) comboAlgorithm.Items.Add(tcAlgorithm.TabPages[i].Text);
        }

        private void MoveRegion(CJob job, int offsetX, int offsetY)
        {
            switch (job.Type)
            {
                case "Pattern":
                    {
                        if (job.Tool.Tool.Pattern.Trained == true)
                        {
                            CogRectangle rect = (CogRectangle)job.Tool.Tool.SearchRegion;
                            rect.X = rect.X + offsetX;
                            rect.Y = rect.Y + offsetY;
                            job.Tool.Tool.SearchRegion = rect;
                        }
                        if (job.SubTool1.Tool.Pattern.Trained == true)
                        {
                            CogRectangle rect = (CogRectangle)job.SubTool1.Tool.SearchRegion;
                            rect.X = rect.X + offsetX;
                            rect.Y = rect.Y + offsetY;
                            job.SubTool1.Tool.SearchRegion = rect;
                        }
                        if (job.SubTool2.Tool.Pattern.Trained == true)
                        {
                            CogRectangle rect = (CogRectangle)job.SubTool2.Tool.SearchRegion;
                            rect.X = rect.X + offsetX;
                            rect.Y = rect.Y + offsetY;
                            job.SubTool2.Tool.SearchRegion = rect;
                        }
                        if (job.SubTool3.Tool.Pattern.Trained == true)
                        {
                            CogRectangle rect = (CogRectangle)job.SubTool3.Tool.SearchRegion;
                            rect.X = rect.X + offsetX;
                            rect.Y = rect.Y + offsetY;
                            job.SubTool3.Tool.SearchRegion = rect;
                        }
                        if (job.SubTool4.Tool.Pattern.Trained == true)
                        {
                            CogRectangle rect = (CogRectangle)job.SubTool4.Tool.SearchRegion;
                            rect.X = rect.X + offsetX;
                            rect.Y = rect.Y + offsetY;
                            job.SubTool4.Tool.SearchRegion = rect;
                        }
                    }
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            int nWild = 0;
            try
            {
                Keys key = keyData & ~(Keys.Shift | Keys.Control);

                switch (key)
                {
                    //case Keys.F1:
                    //    {
                    //        if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    //        {
                    //            btnViewJobs_Click(null, null);
                    //        }
                    //        else
                    //        {
                    //            pnlHelp.Visible = !pnlHelp.Visible;
                    //        }                                
                    //    }
                    //    break;
                    case Keys.Delete:
                        {
                            OnClickJobs(btnJobDelete, new EventArgs());
                        }
                        break;

                    case Keys.Space:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                //OnClickJob_Pattern(btnJobPattern_Insp, new EventArgs());
                            }
                        }
                        break;



                    case Keys.Left:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control
                                && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                            {
                                for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                                {
                                    MoveRegion(Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i], -1, 0);
                                }

                                CLogger.Add(LOG.NORMAL, $"Recipe Job's Search Roi Left");
                            }
                        }
                        break;

                    case Keys.Right:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control
                                && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                            {
                                for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                                {
                                    MoveRegion(Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i], 1, 0);
                                }

                                CLogger.Add(LOG.NORMAL, $"Recipe Job's Search Roi Right");
                            }


                        }
                        break;
                    case Keys.Up:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control
                                && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                            {
                                for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                                {
                                    MoveRegion(Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i], 0, -1);
                                }

                                CLogger.Add(LOG.NORMAL, $"Recipe Job's Search Roi Up");
                            }
                        }
                        break;
                    case Keys.Down:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control
                                && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                            {
                                for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                                {
                                    MoveRegion(Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i], 0, 1);
                                }

                                CLogger.Add(LOG.NORMAL, $"Recipe Job's Search Roi Down");
                            }
                        }
                        break;
                    case Keys.A:
                        {
                            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                            {
                                if (m_selectedJob != null)
                                {
                                    CCogTool_PMAlign PMAlign = null;

                                    if (comboAlgorithm.Text.Contains("Pattern"))
                                    {
                                        if (comboJobPattern_PatternType.Text == "Main") PMAlign = m_selectedJob.Tool;
                                        else
                                        {
                                            if (comboJobPattern_PatternType.Text == "Sub1") PMAlign = m_selectedJob.SubTool1;
                                            if (comboJobPattern_PatternType.Text == "Sub2") PMAlign = m_selectedJob.SubTool2;
                                            if (comboJobPattern_PatternType.Text == "Sub3") PMAlign = m_selectedJob.SubTool3;
                                            if (comboJobPattern_PatternType.Text == "Sub4") PMAlign = m_selectedJob.SubTool4;
                                        }

                                        Cognex.VisionPro.CogRectangle searchRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion;
                                        Cognex.VisionPro.CogRectangle patternRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Tool.Pattern.TrainRegion;

                                        nWild = 50;
                                        searchRegion.X = patternRegion.X - nWild;
                                        searchRegion.Y = patternRegion.Y - nWild;
                                        searchRegion.Width = patternRegion.Width + nWild * 2;
                                        searchRegion.Height = patternRegion.Height + nWild * 2;

                                        OnClickAlgorithm_Pattern(btnJobPattern_Roi, new EventArgs());
                                    }
                                    else if (comboAlgorithm.Text.Contains("Color"))
                                    {
                                        nWild = 50;
                                        Roi_ColorSearchRegion.X = Roi_ColorVAlues.X - nWild;
                                        Roi_ColorSearchRegion.Y = Roi_ColorVAlues.Y - nWild;
                                        Roi_ColorSearchRegion.Width = Roi_ColorVAlues.Width + nWild * 2;
                                        Roi_ColorSearchRegion.Height = Roi_ColorVAlues.Height + nWild * 2;
                                        //btnJobColor_Apply_Click(null, null);
                                        btnJobAllApply_Click(null, null);
                                        OnClickAlgorithm_Color(btnJobColor_Roi, null);
                                    }
                                }
                            }
                        }
                        break;

                    case Keys.W:
                        {
                            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                            {
                                if (m_selectedJob != null)
                                {
                                    CCogTool_PMAlign PMAlign = null;

                                    if (comboJobPattern_PatternType.Text == "Main") PMAlign = m_selectedJob.Tool;
                                    else
                                    {
                                        if (comboJobPattern_PatternType.Text == "Sub1") PMAlign = m_selectedJob.SubTool1;
                                        if (comboJobPattern_PatternType.Text == "Sub2") PMAlign = m_selectedJob.SubTool2;
                                        if (comboJobPattern_PatternType.Text == "Sub3") PMAlign = m_selectedJob.SubTool3;
                                        if (comboJobPattern_PatternType.Text == "Sub4") PMAlign = m_selectedJob.SubTool4;
                                    }

                                    Cognex.VisionPro.CogRectangle searchRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion;
                                    Cognex.VisionPro.CogRectangle patternRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Tool.Pattern.TrainRegion;

                                    nWild = 10;
                                    searchRegion.X = searchRegion.X - nWild;
                                    searchRegion.Y = searchRegion.Y - nWild;
                                    searchRegion.Width = searchRegion.Width + nWild * 2;
                                    searchRegion.Height = searchRegion.Height + nWild * 2;

                                    OnClickAlgorithm_Pattern(btnJobPattern_Roi, new EventArgs());
                                }
                            }
                        }
                        break;

                    case Keys.Q:
                        {
                            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                            {
                                if (m_selectedJob != null)
                                {
                                    CCogTool_PMAlign PMAlign = null;

                                    if (comboJobPattern_PatternType.Text == "Main") PMAlign = m_selectedJob.Tool;
                                    else
                                    {
                                        if (comboJobPattern_PatternType.Text == "Sub1") PMAlign = m_selectedJob.SubTool1;
                                        if (comboJobPattern_PatternType.Text == "Sub2") PMAlign = m_selectedJob.SubTool2;
                                        if (comboJobPattern_PatternType.Text == "Sub3") PMAlign = m_selectedJob.SubTool3;
                                        if (comboJobPattern_PatternType.Text == "Sub4") PMAlign = m_selectedJob.SubTool4;
                                    }

                                    Cognex.VisionPro.CogRectangle searchRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion;
                                    Cognex.VisionPro.CogRectangle patternRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Tool.Pattern.TrainRegion;

                                    nWild = 10;
                                    searchRegion.X = searchRegion.X + nWild;
                                    searchRegion.Y = searchRegion.Y + nWild;
                                    searchRegion.Width = searchRegion.Width - nWild * 2;
                                    searchRegion.Height = searchRegion.Height - nWild * 2;

                                    OnClickAlgorithm_Pattern(btnJobPattern_Roi, new EventArgs());
                                }
                            }
                        }
                        break;

                    case Keys.T:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                OnClickAlgorithm_Pattern(btnJobPattern_Train, new EventArgs());
                                OnClickAlgorithm_Pattern(btnJobPattern_Roi, new EventArgs());
                            }
                        }
                        break;
                    case Keys.F:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                Shorcut_Find();
                            }
                        }
                        break;

                    case Keys.R:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                Shorcut_Roi();
                            }
                        }
                        break;

                    case Keys.S:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                                {
                                    btnSave_Click(null, null);
                                }
                                else
                                {
                                    if (IF_Util.ShowMessageBox("Apply", "Do you want to Apply"))
                                    {
                                        btnJobAllApply_Click(this, new EventArgs());
                                    }
                                }
                            }
                        }
                        break;
                    case Keys.D0:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor(m_imgSource_Color_FullBoard);
                                m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey(m_imgSource_Mono_FullBoard);

                                DispMain.Image = m_imgSource_Color_FullBoard;
                                DispMain.Fit(true);
                            }
                        }
                        break;

                    case Keys.D1:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                OnClickSelectArray(lbSelectArray1, null);
                                CropArray(0);
                            }
                        }
                        break;

                    case Keys.D2:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                OnClickSelectArray(lbSelectArray2, null);
                                CropArray(1);
                            }
                        }
                        break;

                    case Keys.D3:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                OnClickSelectArray(lbSelectArray3, null);
                                CropArray(2);
                            }
                        }
                        break;

                    case Keys.V:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Add(m_selectedJob.Clone());
                                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count - 1].Name += "-COPY";

                                string strCode = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count - 1].Name;

                                CJob job = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count - 1];

                                string str_ColorMethod = "-";
                                if (job.Name.ToLower() == "pattern")
                                {
                                    if (job.ChkColor)
                                    {
                                        str_ColorMethod = $"{job.CCoordinate.ToString()}/{job.CMethod.ToString()}";
                                    }
                                }
                                gridLibrary.Rows[m_nSelectedIndex_Library].Cells[0].Value = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count - 1;
                                gridLibrary.Rows[m_nSelectedIndex_Library].Cells[1].Value = job.Enabled;                        //Enabled
                                gridLibrary.Rows[m_nSelectedIndex_Library].Cells[2].Value = job.Name;                           //Name
                                gridLibrary.Rows[m_nSelectedIndex_Library].Cells[3].Value = job.GrabIndex;                      //GrabIndex
                                gridLibrary.Rows[m_nSelectedIndex_Library].Cells[4].Value = job.Type;                           //Type
                                gridLibrary.Rows[m_nSelectedIndex_Library].Cells[5].Value = job.Judge_NaisNg;                   //Mode
                                gridLibrary.Rows[m_nSelectedIndex_Library].Cells[7].Value = str_ColorMethod;                    //ColorMethod
                                //gridLibrary.Rows[m_nSelectedIndex_Library].Cells[8].Value = job.Parameter.UseEyeD;                //DL Check
                                //gridLibrary.Rows[gridLibrary.Rows.Count - 1].Selected = true;
                                //gridLibrary.FirstDisplayedScrollingRowIndex = gridLibrary.Rows.Count - 1;
                                InitJobs();
                            }
                        }
                        break;

                    case Keys.Escape:
                        return true;

                    case Keys.F2:
                        btnGetDefaultParam_Click(null, null);
                        return true;

                    case Keys.F3:
                        {
                            if (!Global.Device.Cameras[0].IsOpen) return false;
                            btnLive.Text = "LIVE";
                            Global.Device.Cameras[0].Live(false);
                            Global.Device.Cameras[0].Grab(false);
                        }
                        return true;

                    case Keys.F5:
                        btnInspect_Click(null, null);
                        return true;

                    case Keys.F10:
                        //for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                        //    Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i].Tool.Tool.RunParams.AcceptThreshold = 0.01;

                        return true;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Shorcut_Find()
        {
            try
            {
                if (m_selectedJob.Type.Contains("Pattern")) OnClickAlgorithm_Pattern(btnJobPattern_Find, null);
                else if (m_selectedJob.Type.Contains("ColorEx")) btnJobColorEx_Get_Click(btnJobColorEx_Roi, null);
                else if (m_selectedJob.Type.Contains("Color")) OnClickAlgorithm_Color(btnJobColor_Insp, null);
                else if (m_selectedJob.Type.Contains("Condensor")) OnClickAlgorithm_Condensor(btnJobCondensor_Inspection, null);
                else if (m_selectedJob.Type.Contains("Distance")) OnClickAlgorithm_Distance(btnJobDistanceInsp, null);
                else if (m_selectedJob.Type.Contains("Blob")) OnClickAlgorithm_Blob(btnJobBlobInsp, null);
                else if (m_selectedJob.Type.Contains("EYE-D")) OnClickAlgorithm_EyeD(btnjobEyeDFind, null);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void Shorcut_Roi()
        {
            try
            {
                if (m_selectedJob.Type.Contains("Pattern")) OnClickAlgorithm_Pattern(btnJobPattern_Roi, null);
                else if (m_selectedJob.Type.Contains("ColorEx")) OnClickAlgorithm_ColorEx(btnJobColorEx_Roi, null);
                else if (m_selectedJob.Type.Contains("Color")) OnClickAlgorithm_Color(btnJobColor_Roi, null);
                else if (m_selectedJob.Type.Contains("Condensor")) OnClickAlgorithm_Condensor(btnJobCondensor_Roi, null);
                else if (m_selectedJob.Type.Contains("Distance")) OnClickAlgorithm_Distance(btnJobDistance_Roi, null);
                else if (m_selectedJob.Type.Contains("Blob")) OnClickAlgorithm_Blob(btnJobBlob_Roi, null);
                else if (m_selectedJob.Type.Contains("EYE-D")) OnClickAlgorithm_EyeD(btnJobEyeD_Roi, null);


            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }
        // 그랩이 끝나면은..해당 이미지 변경...
        // 이미지 큐에 있는 리시브 처리..
        // 코그넥스 이미지로 변환 처리..
        // 이미지 디스플레이 테스트 처리
        bool GrabDisp = false;
        private void GrabDisp_TaskRun()
        {
            GrabDisp = true;
            Task.Run(async () =>
            {
                while (GrabDisp)
                {
                    await Task.Delay(1);
                    Grab_Recive();
                }
            });
        }

        private void Grab_Recive()
        {
            // 화면 디스플레이 처리..
            // 라이브일때만 화면 디스플레이...
            if (Global.Instance.Device.Cameras[DEFINE.CAM1].ImageCogGrab != null && Global.Device.Cameras[0].IsLive)
            {
                m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor((Cognex.VisionPro.CogImage24PlanarColor)CCognexUtil.FlipRotateEx(Global.Instance.Device.Cameras[DEFINE.CAM1].ImageCogGrab, (CogIPOneImageFlipRotateOperationConstants)Enum.Parse(typeof(CogIPOneImageFlipRotateOperationConstants), Global.Parameter.Cam1_ImageProcess.FlipRotate), true));
                m_imgSource_Mono = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
                m_imgSource_Color_FullBoard = new Cognex.VisionPro.CogImage24PlanarColor(m_imgSource_Color);
                m_imgSource_Mono_FullBoard = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);

                DispMain.Image = Global.Instance.Device.Cameras[0].ImageCogGrab;
            }
        }

        public void InitJobs()
        {
            if (comboAlgorithm.Items.Count > 0) comboAlgorithm.SelectedIndex = 0;

            cbJobGrabIndex.SelectedIndex = 0;
            txtPartCode.Text = "-";
            nbJobSamplingCount.Value = 1;
            chkJobPattern_JudgeMode.Checked = true;
            chkColor.Checked = false;
            cogDisplay_JobPattern.Image = null;
            cogDisplay_JobPattern.InteractiveGraphics.Clear();
            cogDisplay_JobPattern.StaticGraphics.Clear();
            cboPatternColorCoordinate.SelectedIndex = 0;
            cboPatternColorAlg.SelectedIndex = 0;

            gridLibrary.Rows.Clear();

            int nRowIndex = m_nSelectedIndex_Library;

            // 현재 가지고있는 데이터를 뿌려줌..
            if (Global.Instance.System.Recipe.JobManager[m_nSelectedArrayIndex - 1] != null)
            {
                for (int i = 0; i < Global.Instance.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                {
                    CJob job = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i];
                    string str_ColorMethod = "-";

                    if (job.Type.Contains("Pattern"))
                    {
                        if (job.ChkColor)
                        {
                            str_ColorMethod = $"{job.CCoordinate}/{job.CMethod}";
                        }
                        
                        //if (job.ChkColor)
                        //{
                        //    str_ColorMethod = $"{job.CCoordinate.ToString()}/{job.CMethod.ToString()}";
                        //}
                    }
                    else if (job.Type.Contains("Color"))
                    {
                        str_ColorMethod = $"{job.CCoordinate}/{job.CMethod}";
                    }

                    string Jubdge = $"N/A:NG";

                    if (!job.Judge_NaisNg) Jubdge = $"N/A:OK";

                    gridLibrary.Rows.Add(i + 1, job.Enabled, job.Name, job.GrabIndex, job.Type, Jubdge, "", str_ColorMethod);

                    if (job.Type == "Pattern")
                    {
                        if (GetJobCount(job) == 0)
                        {
                            //gridLibrary.Rows[gridLibrary.Rows.Count - 1].DefaultCellStyle.BackColor = Color.IndianRed;
                            //IF_Util.ShowMessageBox("Error", $"Job Name : {job.Name} ==> Pattern not trained");
                        }
                        else
                        {
                            gridLibrary.Rows[gridLibrary.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
                        }
                    }
                    else
                    {
                        gridLibrary.Rows[gridLibrary.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
                    }

                }
            }

            m_nSelectedIndex_Library = nRowIndex;
            gridLibrary.ClearSelection();
        }

        public void AddJobs(bool bSelectArray = false)
        {
            bool bol_ChkName = false;

            if (Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1] != null)
            {
                for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                {
                    if (Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i].Name == txtPartCode.Text)
                    {
                        bol_ChkName = true;
                        MessageBox.Show($"{txtPartCode.Text} - 똑같은 Name을 가진 Job이 존재합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }

            if (bol_ChkName)
            {
                return;
            }

            CJob newJob = new CJob();
            newJob.Parameter = new JobParameter();
            newJob.Tool.Tool.RunParams.AcceptThreshold = 0.01;
            newJob.SubTool1.Tool.RunParams.AcceptThreshold = 0.01;
            newJob.SubTool2.Tool.RunParams.AcceptThreshold = 0.01;
            newJob.SubTool3.Tool.RunParams.AcceptThreshold = 0.01;
            newJob.SubTool4.Tool.RunParams.AcceptThreshold = 0.01;

            if (Global.Mode.isAddEnable) newJob.Enabled = true;
            else newJob.Enabled = false;

            newJob.Type = comboAlgorithm.Text;
            newJob.GrabIndex = cbJobGrabIndex.SelectedIndex;
            newJob.Name = txtPartCode.Text;
            newJob.SamplingCount = (int)nbJobSamplingCount.Value;
            newJob.Judge_NaisNg = chkJobPattern_JudgeMode.Checked;
            newJob.Parameter = new JobParameter();

            newJob.SearchRegion = new Rectangle(100, 100, 200, 200);

            if (newJob.Tool.Tool.SearchRegion == null || (newJob.Tool.Tool.SearchRegion is CogRectangle) == false)
            {
                newJob.Tool.Tool.SearchRegion = new CogRectangle();
            }

            (newJob.Tool.Tool.SearchRegion as CogRectangle).Width = 200;
            (newJob.Tool.Tool.SearchRegion as CogRectangle).Height = 200;


            string str_ColorMethod = "-";
            if (newJob.Type.Contains("Pattern"))
            {
                newJob.CCoordinate = (CJob.ColorCoordinate)cboPatternColorCoordinate.SelectedIndex - 1;
                newJob.CMethod = (CJob.ColorMethod)cboPatternColorAlg.SelectedIndex - 1;

                if (chkColor.Checked)
                {
                    newJob.ChkColor = true;
                    str_ColorMethod = $"{newJob.CCoordinate.ToString()}/{newJob.CMethod.ToString()}";
                }
                else
                {
                    newJob.ChkColor = false;
                }

                // -1처리가 될시에는...디폴트값으로 저장..
                if ((int)newJob.CCoordinate == -1) newJob.CCoordinate = CJob.ColorCoordinate.CC_GRAY;
                if ((int)newJob.CMethod == -1) newJob.CMethod = CJob.ColorMethod.CA_ConvertGray;
            }
            else if (newJob.Type.Contains("Color"))
            {
                newJob.CCoordinate = (CJob.ColorCoordinate)cboColorCoordinate.SelectedIndex;
                newJob.CMethod = (CJob.ColorMethod)cboColorAlg.SelectedIndex;
                str_ColorMethod = $"{newJob.CCoordinate.ToString()}/{newJob.CMethod.ToString()}";
            }
            else if (newJob.Type.ToLower() == "Condensor")
            {
                newJob.Type = JOB_TYPE.Condensor;
            }
            else if (newJob.Type.ToLower() == "Distance")
            {
                newJob.Type = JOB_TYPE.Distance;
            }
            else if (newJob.Type.Contains("fin"))
            {
                txt_PinMatchingScoreMin.Text = "60";
                tbAreaMin.Text = "100";
                tbAreaMax.Text = "100";
                txtBlobThreshold.Text = "150";
            }

            //newJob.useBinary = chkBinary.Checked;
            //newJob.isSavePart = chkSavePart.Checked;

            //newJob.LC_ReadUse = cb_LCReadUse.Checked;

            bool success = int.TryParse(tbPatternMasterCount.Text, out int masterCnt);
            if (success) newJob.MasterCount = masterCnt;

            if (Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1] == null)
            {
                //2024.03.15 송현수->안춘길 : 처음에 레시피 만들 때 할당이 안되어있음
                if (m_nSelectedArrayIndex - 1 == 0)
                {
                    Global.System.Recipe.JobManager_Array1 = new CInspJobs();
                    Global.System.Recipe.JobManager[0] = Global.System.Recipe.JobManager_Array1;
                }
                else if (m_nSelectedArrayIndex - 1 == 1)
                {
                    Global.System.Recipe.JobManager_Array2 = new CInspJobs();
                    Global.System.Recipe.JobManager[1] = Global.System.Recipe.JobManager_Array2;
                }
                else if (m_nSelectedArrayIndex - 1 == 2)
                {
                    Global.System.Recipe.JobManager_Array3 = new CInspJobs();
                    Global.System.Recipe.JobManager[2] = Global.System.Recipe.JobManager_Array3;
                }
                else if (m_nSelectedArrayIndex - 1 == 4)
                {
                    Global.System.Recipe.JobManager_Array2 = new CInspJobs();
                    Global.System.Recipe.JobManager[3] = Global.System.Recipe.JobManager_Array4;
                }
            }

            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Add(newJob);

            string str_Mode = "";
            if (newJob.Judge_NaisNg)
                str_Mode = $"N/A:NG";
            else
                str_Mode = $"N/A:OK";

            // 마지막에 추가되기때문에...내용 추가..
            int _no = gridLibrary.RowCount;
            gridLibrary.Rows.Add(_no + 1, newJob.Enabled, newJob.Name, newJob.GrabIndex, newJob.Type, str_Mode, "", str_ColorMethod);

            m_nSelectedIndex_Library = gridLibrary.Rows.Count - 1;

            gridLibrary.Rows[m_nSelectedIndex_Library].Selected = true;
            gridLibrary.FirstDisplayedScrollingRowIndex = m_nSelectedIndex_Library;
        }
        private void SelectGridJobs(bool isImageUpdate = true)
        {
            DispMain.InteractiveGraphics.Clear();
            DispMain.StaticGraphics.Clear();
            if (isImageUpdate)
            {
                m_selectedJob = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library];
            }

            txtPartCode.Text = m_selectedJob.Name;

            nbJobSamplingCount.Value = m_selectedJob.SamplingCount;

            int nGrabIndex = m_selectedJob.GrabIndex;

            cbJobGrabIndex.SelectedIndex = nGrabIndex;
            if (m_selectedJob.Parameter == null) m_selectedJob.Parameter = new JobParameter();

            if (m_imgSource_Mono_FullBoard != null && m_imgSource_Mono_FullBoard.Allocated)
            {
                SelectGrabImage(nGrabIndex, false);
            }

            if (isImageUpdate)
            {
                if (m_imgSource_Mono_FullBoard != null && m_imgSource_Mono_FullBoard.Allocated)
                {
                    CropArray(m_nSelectedArrayIndex - 1);
                }
            }


            //cb_LCReadUse.Checked = m_selectedJob.LC_ReadUse;
            if (!m_selectedJob.LC_ReadUse)
            {
                //tbJobIcLead_MasterCount.Enabled = false;
            }

            tbPatternMasterCount.Text = m_selectedJob.MasterCount.ToString();

            chkColor.Checked = m_selectedJob.ChkColor;

            tbCircleRectW.Text = m_selectedJob.Parameter.CondensorRectWidth.ToString();
            tbCircleRectH.Text = m_selectedJob.Parameter.CondensorRectHeight.ToString();
            tbCondensorRectRadio.Text = m_selectedJob.Parameter.CondensorRadiusOffset.ToString();

            int comboIndex = 0;
            for (int i = 0; i < comboAlgorithm.Items.Count; i++)
            {
                if (string.Equals(m_selectedJob.Type, comboAlgorithm.Items[i].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    comboIndex = i; break;
                }
            }

            comboAlgorithm.Text = m_selectedJob.Type;
            comboAlgorithm.SelectedIndex = comboIndex;

            comboAlgorithm_SelectedIndexChanged(null, null);

            if (m_selectedJob.Type.Contains("Pattern"))
            {
                if (chkColor.Checked)
                {
                    UpdateColorUI(lbPatternColor, lbPatternColor2, trbThreshold_Color, lbThreshold_Color);

                    for (int i = 0; i < cboPatternColorCoordinate.Items.Count; i++)
                    {
                        if (m_selectedJob.CCoordinate.ToString() == cboPatternColorCoordinate.Items[i].ToString())
                        {
                            cboPatternColorCoordinate.Text = m_selectedJob.CCoordinate.ToString();
                            cboPatternColorCoordinate.SelectedIndex = i;
                        }
                    }

                    for (int i = 0; i < cboPatternColorAlg.Items.Count; i++)
                    {
                        if (m_selectedJob.CMethod.ToString() == cboPatternColorAlg.Items[i].ToString())
                        {
                            cboPatternColorAlg.Text = m_selectedJob.CMethod.ToString();
                            cboPatternColorAlg.SelectedIndex = i;
                        }
                    }

                }

                // 20230112
                CCogTool_PMAlign pmAlign = null;

                if (comboJobPattern_PatternType.Text == "Main") pmAlign = m_selectedJob.Tool;
                else if (comboJobPattern_PatternType.Text == "Sub1") pmAlign = m_selectedJob.SubTool1;
                else if (comboJobPattern_PatternType.Text == "Sub2") pmAlign = m_selectedJob.SubTool2;
                else if (comboJobPattern_PatternType.Text == "Sub3") pmAlign = m_selectedJob.SubTool3;
                else if (comboJobPattern_PatternType.Text == "Sub4") pmAlign = m_selectedJob.SubTool4;
                if (pmAlign == null) pmAlign = new CCogTool_PMAlign();

                DisplayTrainCount();

                if (pmAlign.TrainedPatternImage != null)
                {
                    cogDisplay_JobPattern.InteractiveGraphics.Clear();
                    cogDisplay_JobPattern.StaticGraphics.Clear();
                    cogDisplay_JobPattern.Image = pmAlign.TrainedPatternImage;
                    cogDisplay_JobPattern.Fit(false);
                    CVisionCognex.TrainGraphic(pmAlign.Tool, cogDisplay_JobPattern);
                }
                else
                {
                    cogDisplay_JobPattern.Image = null;
                }

                tbJobPattern_AcceptScore.Text = m_selectedJob.Tool.Tool.RunParams.AcceptThreshold.ToString();
                btnJobPattern_Roi.Text = "Roi";
                OnClickAlgorithm_Pattern(btnJobPattern_Roi, null);
            }
            else if (m_selectedJob.Type.Contains("ColorEx"))
            {
                if (comboCorrectColorEx.Items.Contains(m_selectedJob.Parameter.EyeD_CorrectColor) == false)
                {
                    if (m_selectedJob.Parameter.EyeD_CorrectColor != "")
                    {
                        comboCorrectColorEx.Items.Add(m_selectedJob.Parameter.EyeD_CorrectColor);
                        comboCorrectColorEx.SelectedText = m_selectedJob.Parameter.EyeD_CorrectColor;
                    }
                }

                chkColorEx_SimpleMode.Checked = m_selectedJob.Parameter.ColorEx_SimpleMode;

                txtColorEx_R.IntValue = m_selectedJob.Parameter.ColorEx_MasterColor.Color.R;
                txtColorEx_G.IntValue = m_selectedJob.Parameter.ColorEx_MasterColor.Color.G;
                txtColorEx_B.IntValue = m_selectedJob.Parameter.ColorEx_MasterColor.Color.B;

                if (m_selectedJob.Parameter.ColorEx_Range == 15) radioColorEx_Range15.Checked = true;
                if (m_selectedJob.Parameter.ColorEx_Range == 30) radioColorEx_Range30.Checked = true;
                if (m_selectedJob.Parameter.ColorEx_Range == 45) radioColorEx_Range45.Checked = true;

                string colorStr = $"{m_selectedJob.Parameter.ColorEx_MasterColor.Color.R},{m_selectedJob.Parameter.ColorEx_MasterColor.Color.G},{m_selectedJob.Parameter.ColorEx_MasterColor.Color.B}";
                IF_Util.setLabel(lblJobColorEx_ResultColor, colorStr.ToString(), m_selectedJob.Parameter.ColorEx_MasterColor.Color);

                //ShowColorEx();
                btnJobColorEx_Roi.Text = "Roi";
                OnClickAlgorithm_ColorEx(btnJobColorEx_Roi, null);
            }
            else if (m_selectedJob.Type.Contains("Color"))
            {
                for (int i = 0; i < cboColorCoordinate.Items.Count; i++)
                {
                    if (m_selectedJob.CCoordinate.ToString() == cboColorCoordinate.Items[i].ToString())
                    {
                        cboColorCoordinate.Text = m_selectedJob.CCoordinate.ToString();
                        cboPatternColorCoordinate.Text = m_selectedJob.CCoordinate.ToString();
                        cboColorCoordinate.SelectedIndex = i;
                    }
                }

                for (int i = 0; i < cboColorAlg.Items.Count; i++)
                {
                    if (m_selectedJob.CMethod.ToString() == cboColorAlg.Items[i].ToString())
                    {
                        cboColorAlg.Text = m_selectedJob.CMethod.ToString();
                        cboPatternColorAlg.Text = m_selectedJob.CMethod.ToString();
                        cboColorAlg.SelectedIndex = i;
                    }
                }

                //propertyGrid_Jobs.SelectedObject = m_selectedJob;
                lbColorMaxArea.Text = m_selectedJob.RangeAreaMax.ToString();
                lbColorMinArea.Text = m_selectedJob.RangeAreaMin.ToString();
                btnJobColor_Roi.Text = "Roi";
                OnClickAlgorithm_Color(btnJobColor_Roi, null);

                InvalidateColorRects();

            }
            else if (m_selectedJob.Type.Contains("Condensor"))
            {
                if (m_selectedJob.Find_Circle.RunParams.CaliperRunParams.Edge0Polarity == CogCaliperPolarityConstants.DontCare) m_selectedJob.Find_Circle.RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight;
                tbIgnoreCount.Text = m_selectedJob.Find_Circle.RunParams.NumToIgnore.ToString();
                tbCircleContrast.Text = m_selectedJob.Find_Circle.RunParams.CaliperRunParams.ContrastThreshold.ToString();
                tbCircleThickness.Text = m_selectedJob.Find_Circle.RunParams.CaliperRunParams.FilterHalfSizeInPixels.ToString();

                if (m_selectedJob.Parameter.CondensorTypeTB)
                {
                    radioCondensorLR.Checked = false;
                    radioCondensorTB.Checked = true;
                }
                else
                {
                    radioCondensorLR.Checked = true;
                    radioCondensorTB.Checked = false;
                }
                comboCondensorPolarity.Text = m_selectedJob.Parameter.CondensorPolarity;

                chkCondensor_UseDist.Checked = m_selectedJob.Parameter.UseCondensorDist;
                cbXValue.Checked = m_selectedJob.Parameter.UseDistanceX;
                cbYValue.Checked = m_selectedJob.Parameter.UseDistanceY;

                tbAngleMaxValue.Text = m_selectedJob.Parameter.DistanceAngleMax.ToString();
                tbAngleMinValue.Text = m_selectedJob.Parameter.DistanceAngleMin.ToString();

                tbXMaxValue.Text = m_selectedJob.Parameter.DistanceXMax.ToString();
                tbYMaxValue.Text = m_selectedJob.Parameter.DistanceYMax.ToString();
                tbXMinValue.Text = m_selectedJob.Parameter.DistanceXMin.ToString();
                tbYMinValue.Text = m_selectedJob.Parameter.DistanceYMin.ToString();

                //ShowCondencerRIO();
                btnJobCondensor_Roi.Text = "Roi";
                OnClickAlgorithm_Condensor(btnJobCondensor_Roi, null);
            }
            else if (m_selectedJob.Type.Contains("Distance"))
            {
                if (m_selectedJob.Find_Line.RunParams.CaliperRunParams.Edge0Polarity == CogCaliperPolarityConstants.DontCare) m_selectedJob.Find_Line.RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight;
                if (m_selectedJob.Find_Line.RunParams.CaliperRunParams.Edge0Polarity == CogCaliperPolarityConstants.DarkToLight) comboLineEdgePolarity.SelectedIndex = 0;// cbEdgePolarity.Text = "Dark → Light";
                if (m_selectedJob.Find_Line.RunParams.CaliperRunParams.Edge0Polarity == CogCaliperPolarityConstants.LightToDark) comboLineEdgePolarity.SelectedIndex = 1;//cbEdgePolarity.Text = "Light → Dark";

                if (m_selectedJob.Find_Line.RunParams.CaliperRunParams.SingleEdgeScorers.Count > 0)
                {
                    if (m_selectedJob.Find_Line.RunParams.CaliperRunParams.SingleEdgeScorers[0] is CogCaliperScorerContrast) comboLineEdgeScorer.Text = "Contrast";
                    if (m_selectedJob.Find_Line.RunParams.CaliperRunParams.SingleEdgeScorers[0] is CogCaliperScorerPosition) comboLineEdgeScorer.Text = "Position (From End)";
                    if (m_selectedJob.Find_Line.RunParams.CaliperRunParams.SingleEdgeScorers[0] is CogCaliperScorerPositionNeg) comboLineEdgeScorer.Text = "Position (From Begin)";
                }
                if (m_selectedJob.Parameter.UseDistanceAngle)
                {
                    cbAngle.Checked = true;
                }
                else
                {
                    cbAngle.Checked = false;
                }
                if (m_selectedJob.Parameter.UseDistanceX)
                {
                    cbXValue.Checked = true;
                }
                else
                {
                    cbXValue.Checked = false;
                }
                if (m_selectedJob.Parameter.UseDistanceY)
                {
                    cbYValue.Checked = true;
                }
                else
                {
                    cbYValue.Checked = false;
                }
                tbAngleMaxValue.Text = m_selectedJob.Parameter.DistanceAngleMax.ToString();
                tbAngleMinValue.Text = m_selectedJob.Parameter.DistanceAngleMin.ToString();
                tbLineEdgeContrast.Text = m_selectedJob.Find_Line.RunParams.CaliperRunParams.ContrastThreshold.ToString();
                tbXMaxValue.Text = m_selectedJob.Parameter.DistanceXMax.ToString();
                tbYMaxValue.Text = m_selectedJob.Parameter.DistanceYMax.ToString();

                tbXMinValue.Text = m_selectedJob.Parameter.DistanceXMin.ToString();
                tbYMinValue.Text = m_selectedJob.Parameter.DistanceYMin.ToString();
                numericDistanceThickness.Value = m_selectedJob.Find_Line.RunParams.CaliperRunParams.FilterHalfSizeInPixels;
                numericDistanceSamplingCount.Value = m_selectedJob.Find_Line.RunParams.NumCalipers;
                btnJobDistance_Roi.Text = "Roi";
                OnClickAlgorithm_Distance(btnJobDistance_Roi, null);
            }
            else if (m_selectedJob.Type.Contains("Blob"))
            {
                Init_UI_FIN();
                uiSymbolButton26.Text = "Roi";
                OnClickAlgorithm_Blob(uiSymbolButton26, null);
            }
            else if (m_selectedJob.Type.Contains("EYE-D"))
            {
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                btnJobEyeD_Roi.Text = "Roi";
                //ShowEYEDRIO();
                OnClickAlgorithm_EyeD(btnJobEyeD_Roi, null);
                if (m_selectedJob.Parameter.EyeD_ModelName != null && comboEyeDModelName.Items.Contains(m_selectedJob.Parameter.EyeD_ModelName) == false) comboEyeDModelName.Items.Add(m_selectedJob.Parameter.EyeD_ModelName);
                comboEyeDModelName.Text = m_selectedJob.Parameter.EyeD_ModelName;
                comboEyeDInferType.Text = m_selectedJob.Parameter.EyeD_InferType;
                numericEyeDOkCount.Value = m_selectedJob.Parameter.EyeD_MasterCount;
                txtEyeDMinScore.DoubleValue = m_selectedJob.Parameter.EyeD_MinScore;
                txtEyeDCorrectAnswer.Text = m_selectedJob.Parameter.EyeD_CorrectAnswer;
                txtEyeDMaxCount.IntValue = m_selectedJob.Parameter.EyeD_MaxCount;
                chkEyeD_UseDist.Checked = m_selectedJob.Parameter.EyeD_UseDistance;
                chkEyeD_UseColor.Checked = m_selectedJob.Parameter.EyeD_UseColorInsp;
                chkJobEyeD_UseSpecRegion.Checked = m_selectedJob.Parameter.EyeD_UseSpecRegion;

                if (m_selectedJob.Parameter.EyeD_CorrectColor != null && comboCorrectColorEx.Items.Contains(m_selectedJob.Parameter.EyeD_CorrectColor) == false) comboCorrectColorEx.Items.Add(m_selectedJob.Parameter.EyeD_CorrectColor);

                cbXValue.Checked = m_selectedJob.Parameter.UseDistanceX;
                cbYValue.Checked = m_selectedJob.Parameter.UseDistanceY;

                tbAngleMaxValue.Text = m_selectedJob.Parameter.DistanceAngleMax.ToString();
                tbAngleMinValue.Text = m_selectedJob.Parameter.DistanceAngleMin.ToString();

                tbXMaxValue.Text = m_selectedJob.Parameter.DistanceXMax.ToString();
                tbYMaxValue.Text = m_selectedJob.Parameter.DistanceYMax.ToString();
                tbXMinValue.Text = m_selectedJob.Parameter.DistanceXMin.ToString();
                tbYMinValue.Text = m_selectedJob.Parameter.DistanceYMin.ToString();
            }
            else if (m_selectedJob.Type.Contains("Pin"))
            {
                nb_Pin_OkCount.Value = m_selectedJob.Parameter.Pin_OkCount;
                nb_Pin_AreaMax.Value = m_selectedJob.Parameter.Pin_AreaMax;
                nb_Pin_AreaMin.Value = m_selectedJob.Parameter.Pin_AreaMin;
                nb_Pin_SpecRoi_Width.Value = m_selectedJob.Parameter.Pin_SpecRoiWidth;
                nb_Pin_SpecRoi_Height.Value = m_selectedJob.Parameter.Pin_SpecRoiHeight;
                nb_Pin_Threshold.Value = m_selectedJob.Parameter.Pin_Threshold;
                chk_Pin_BinaryInv.Checked = m_selectedJob.Parameter.Pin_BinaryInv;
                chkJobPin_UseColorMatching.Checked = m_selectedJob.Parameter.Pin_ColorMatching;

                string colorStr = $"R:{m_selectedJob.Parameter.Pin_ColorR},G:{m_selectedJob.Parameter.Pin_ColorG},B:{m_selectedJob.Parameter.Pin_ColorB}";
                lblJobPin_ShapeColor.Text = colorStr;
                btnJobPin_Roi.Text = "Roi";
                OnClickAlgorithm_Pin(btnJobPin_Roi, null);
            }
            else if (m_selectedJob.Type.Contains("Connector"))
            {
                txtJobConnector_Score.DoubleValue = m_selectedJob.Parameter.Connector_ScoreMin;
                radioJobConnector_LR.Checked = m_selectedJob.Parameter.Connector_Type_LR;
                txtJobConnector_AreaMin.IntValue = m_selectedJob.Parameter.Connector_AreaMin;
                txtJobConnector_AreaMax.IntValue = m_selectedJob.Parameter.Connector_AreaMax;
                txtJobConnector_BoxWidth.IntValue = m_selectedJob.Parameter.Connector_BoxWidth;
                txtJobConnector_BoxHeight.IntValue = m_selectedJob.Parameter.Connector_BoxHeight;
                txtJobConnector_Threshold.IntValue = m_selectedJob.Parameter.Connector_Threshold;
                chkJobConnector_BinInv.Checked = m_selectedJob.Parameter.Connector_BinaryInv;
                txtJobConnector_OKArea.IntValue = m_selectedJob.Parameter.Connector_AreaOK;
                radioJobConnector_AreaLT.Checked = m_selectedJob.Parameter.Connector_LargeFirst;

                if (m_selectedJob.Tool.TrainedPatternImage != null)
                {
                    cogDisplay_Connector.InteractiveGraphics.Clear();
                    cogDisplay_Connector.StaticGraphics.Clear();
                    cogDisplay_Connector.Image = m_selectedJob.Tool.TrainedPatternImage;
                    cogDisplay_Connector.Fit(false);
                    CVisionCognex.TrainGraphic(m_selectedJob.Tool.Tool, cogDisplay_Connector);
                }
                else
                {
                    cogDisplay_Connector.Image = null;
                }
                btnJobConnector_Roi.Text = "Roi";
                OnClickAlgorithm_Connector(btnJobConnector_Roi, null);
            }

            //송현수 -> 안춘길 : 필터 관련 적용, 저장, 불러오기, UI 기능 정상 동작 기능 구현
            chkUseFilter1.Checked = m_selectedJob.Parameter.UseFilter1;
            chkUseFilter2.Checked = m_selectedJob.Parameter.UseFilter2;

            comboFilter1Type.SelectedIndex = (int)m_selectedJob.Parameter.Filter1;
            comboFilter2Type.SelectedIndex = (int)m_selectedJob.Parameter.Filter2;

            txtFilter1_KernelW.Text = m_selectedJob.Parameter.Filter1_Kernel_W.ToString();
            txtFilter1_KernelH.Text = m_selectedJob.Parameter.Filter1_Kernel_H.ToString();
            txtFilter2_KernelW.Text = m_selectedJob.Parameter.Filter2_Kernel_W.ToString();
            txtFilter2_KernelH.Text = m_selectedJob.Parameter.Filter2_Kernel_H.ToString();

            tbJobPattern_MinScore.Text = m_selectedJob.MinScore.ToString();

            tbPatternMasterCount.Text = m_selectedJob.MasterCount.ToString();

            chkJobPattern_JudgeMode.Checked = m_selectedJob.Judge_NaisNg;


            if (DispMain.Image == null)
                return;

        }

        private bool InitEvent()
        {
            try
            {
                Global.SeqVision.EventInspEnd += OnInspEnd;
                m_menuT.ItemClicked += Menu_Click;

                Global.Device.EyeD.EventGetModel += OnGetModel;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }
            return true;
        }

        //송현수 -> 안춘길 : 레시피 변경 시 업데이트 되어야하는 UI 는 여기에 표시
        private bool InitUI()
        {
            try
            {
                IF_Util.InitCombobox(comboGrabIndex_Fiducial);
                IF_Util.InitCombobox(comboAlgorithm);
                IF_Util.InitCombobox(comboJobPattern_PatternType);
                IF_Util.InitCombobox(comboQrGrabIndex);
                IF_Util.InitCombobox(comboLineEdgePolarity);
                IF_Util.InitCombobox(comboLineEdgeScorer);
                IF_Util.InitCombobox(comboCondensorPolarity);
                IF_Util.InitCombobox(cbRotateImageAngle);

                if (Global.Device.Cameras[0] != null)
                {
                    Global.Device.Cameras[0].Display_Teaching = DispMain;
                }

                tbCircleRectW.Text = "1";
                tbCircleContrast.Text = "1";
                tbCircleRectH.Text = "1";
                tbCircleThickness.Text = "1";
                tbIgnoreCount.Text = "1";
                txtArrayCount.Text = Global.Instance.System.Recipe.ArrayCount.ToString();
                comboQrGrabIndex.Text = Global.Instance.System.Recipe.QRBufferNo.ToString();
                radioFiducial_1.Checked = true;

                //ditance UI
                tbLineEdgeContrast.Text = "1";
                tbAngleMinValue.Text = "1";
                tbAngleMaxValue.Text = "1";
                tbXMaxValue.Text = "1";
                tbXMinValue.Text = "1";
                tbYMaxValue.Text = "1";
                tbYMinValue.Text = "1";


                //Blob UI
                tbAreaMin.Text = "1";
                tbAreaMax.Text = "1";
                txtBlobThreshold.Text = "0";
                txt_PinMatchingScoreMin.Text = "0.01";



                if (Global.Setting.Enviroment.Country != Setting_Enviroment.COUNTRY.KOR)
                {
                    lbExplain1.Visible = false;
                    lbExplain2.Visible = false;
                    lbExplain3.Visible = false;
                    lbExplain4.Visible = false;
                    lbExplain5.Visible = false;
                    lbExplain6.Visible = false;
                    lbExplain7.Visible = false;
                    lbExplain8.Visible = false;
                }

                InitFiducialLibraryGrid();
                _selectedFiducialLibrary = _fiducialLibrary.FirstOrDefault();

                if (_selectedFiducialLibrary != null)
                {
                    comboFiducialLibrary.Text = _selectedFiducialLibrary.LibraryNumber;
                }

                string path = $"{Global.m_MainPJTRoot}\\RECIPE\\{Global.System.Recipe.Name}\\MasterBoard_{Global.System.Recipe.Name}.jpg";

                if (File.Exists(path))
                {
                    cogDisplay_MasterImage.Image = new CogImage24PlanarColor(IF_Util.SafetyImageLoad(path));
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }

            ////if (Global.Device.Cameras.Count > 0)
            ////{
            ////    cbCamera.Items.Clear();
            ////    for (int i = 0; i < Global.Device.CAMERA_COUNT; i++) cbCamera.Items.Add("Camera " + (i + 1));
            ////    if (cbCamera.Items.Count > 0) 0 = 0;
            ////}
            //tbQRBufferNo.Text = Global.System.Recipe.QRBufferNo.ToString();

            //IF_Util.InitCombobox(this.Controls);

            //if (cbLightCh.Items.Count > 0) cbLightCh.SelectedIndex = 0;
            //if (cbJobInfoType.DataSource != null) cbJobInfoType.SelectedIndex = 0;

            return true;
        }

        private bool InitProperty()
        {
            cboPatternColorCoordinate.Items.Clear();
            cboColorCoordinate.Items.Clear();
            cboPatternColorCoordinate.Items.Add("-");
            cboColorCoordinate.Items.Add("-");
            foreach (string coords in Enum.GetNames(typeof(CJob.ColorCoordinate)))
            {
                cboPatternColorCoordinate.Items.Add(coords);
                cboColorCoordinate.Items.Add(coords);
            }

            cboPatternColorAlg.Items.Clear();
            cboColorAlg.Items.Clear();
            cboPatternColorAlg.Items.Add("-");
            cboColorAlg.Items.Add("-");
            CJob.ColorMethod nLast = CJob.ColorMethod.CA_ConvertGray;
            for (CJob.ColorMethod i = CJob.ColorMethod.CA_THRESHILD; (int)i <= (int)nLast; i++)
            {
                cboPatternColorAlg.Items.Add(i.ToString());
                cboColorAlg.Items.Add(i.ToString());
            }

            //송현수 -> 안춘길 : Job 클래스 안에서 각 파라미터 관리
            comboFilter1Type.Items.Clear();
            comboFilter1Type.DataSource = Enum.GetValues(typeof(CVisionTools.CV_FILTER));
            comboFilter1Type.SelectedItem = (CVisionTools.CV_FILTER)(1);

            comboFilter2Type.Items.Clear();
            comboFilter2Type.DataSource = Enum.GetValues(typeof(CVisionTools.CV_FILTER));
            comboFilter2Type.SelectedItem = (CVisionTools.CV_FILTER)(1);

            cboPatternColorCoordinate.SelectedIndex = (int)CJob.ColorCoordinate.CC_HSV + 1;
            cboColorCoordinate.SelectedIndex = (int)CJob.ColorCoordinate.CC_HSV + 1;
            cboPatternColorAlg.SelectedIndex = (int)CJob.ColorMethod.CA_RANGE + 1;
            cboColorAlg.SelectedIndex = (int)CJob.ColorMethod.CA_RANGE + 1;

            return true;
        }

        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispMain.InteractiveGraphics.Clear();
            DispMain.StaticGraphics.Clear();

            int nIndex = 0;

            CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
        }

        private object grabSync = new object();
        private void OnClickCameraOperation(object sender, EventArgs e)
        {
            try
            {
                string strIndex = "";
                if (sender is Button)
                    strIndex = (sender as Button).Text;
                else if (sender is CheckBox)
                    strIndex = (sender as CheckBox).Text;
                else
                    return;

                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                Camera Camera = Global.Device.Cameras.Count > 0 ? Global.Device.Cameras[0] : null;
                CRecipe Recipe = Global.System.Recipe;

                switch (strIndex)
                {
                    case "GRAB (1)":
                        {

                            if (Camera == null || Camera.IsOpen == false)
                            {
                                CLogger.Add(LOG.ABNORMAL, $"Camera Disconnected");
                                Thread.Sleep(1000);

                                return;
                            }

                            if (Global.SeqVision.SeqIndex != "IDLE")
                            {
                                CLogger.Add(LOG.ABNORMAL, "Can't Grab during the Inspection");
                                return;
                            }

                            DispMain.Image = null;
                            if (!Global.Device.Cameras[0].IsOpen)
                            {
                                IF_Util.ShowMessageBox("Error", "Check the Connection of Camera");
                                return;
                            }
                            btnLive.Text = "LIVE";
                            Global.Device.Cameras[0].Live(false);
                            Global.Device.Cameras[0].Grab(false);

                            bool success = Global.Device.Cameras[0].IsGrabDone.WaitOne(1000);

                            for (int i = 0; i < _imagesGrab.Length; i++)
                            {
                                _imagesGrab[i] = null;

                                string SNAB_str_LabelName = $"lbImage{i + 1}";
                                Control SNAB_foundControl_Label = Controls.Find(SNAB_str_LabelName, true).FirstOrDefault();

                                if (SNAB_foundControl_Label is Label SNAB_LBL)
                                {
                                    if (SNAB_LBL.InvokeRequired)
                                    {
                                        SNAB_LBL.Invoke((MethodInvoker)delegate
                                        {
                                            SNAB_LBL.ForeColor = DEFINE_COMMON.COLOR_NAVY;
                                            SNAB_LBL.Enabled = false;
                                        });
                                    }
                                    else
                                    {
                                        SNAB_LBL.ForeColor = DEFINE_COMMON.COLOR_NAVY;
                                        SNAB_LBL.Enabled = false;
                                    }
                                }

                                string SNAB_str_ImageName = $"CDImage{i + 1}";

                                Control SNAB_foundControl_CD = Controls.Find(SNAB_str_ImageName, true).FirstOrDefault();

                                if (SNAB_foundControl_CD is CogDisplay SNAB_CD)
                                {
                                    if (SNAB_CD.InvokeRequired)
                                    {
                                        SNAB_CD.Invoke((MethodInvoker)delegate
                                        {
                                            SNAB_CD.Image = null;
                                            SNAB_CD.Enabled = false;
                                        });
                                    }
                                    else
                                    {
                                        SNAB_CD.Image = null;
                                        SNAB_CD.Enabled = false;
                                    }
                                }
                            }

                            CogImage24PlanarColor img = new CogImage24PlanarColor(Global.Instance.Device.Cameras[DEFINE.CAM1].ImageGrab);

                            m_imgSource_Color = new CogImage24PlanarColor((CogImage24PlanarColor)CCognexUtil.FlipRotateEx(img, (CogIPOneImageFlipRotateOperationConstants)Enum.Parse(typeof(CogIPOneImageFlipRotateOperationConstants), Global.Parameter.Cam1_ImageProcess.FlipRotate), true));
                            m_imgSource_Mono = CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
                            m_imgSource_Color_FullBoard = new CogImage24PlanarColor(m_imgSource_Color);
                            m_imgSource_Mono_FullBoard = CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);

                            DispMain.Image = new CogImage24PlanarColor(img);
                        }

                        break;
                    case "GRAB (1~5)":
                        try
                        {
                            if (Camera == null || Camera.IsOpen == false)
                            {
                                CLogger.Add(LOG.ABNORMAL, $"Camera Disconnected");
                                Thread.Sleep(1000);

                                return;
                            }

                            if (Global.SeqVision.SeqIndex != "IDLE")
                            {
                                CLogger.Add(LOG.ABNORMAL, "Can't Grab during the Inspection");
                                //IF_Util.ShowMessageBox("Error", "Can't Grab during the Inspection");
                                return;
                            }

                            Global.Notice = "Total Grabbing";
                            Global.Instance.OnStart_Porgess();

                            Task.Run(() =>
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    try
                                    {
                                        Camera.SetExposure(Recipe.GrabManager.Nodes[i].ExposureTime_us);

                                        //그랩 실패 시 재 시도
                                        for (int grabRetryIndex = 0; grabRetryIndex < 3; grabRetryIndex++)
                                        {
                                            Camera.Grab();

                                            bool grabSuccess = Global.Instance.Device.Cameras[0].IsGrabDone.WaitOne(1000);

                                            if (grabSuccess)
                                            {
                                                lock (grabSync)
                                                {
                                                    Global.ImagesGrab[i] = new CogImage24PlanarColor((Bitmap)Camera.ImageGrab);
                                                }

                                                CLogger.Add(LOG.SEQ, $"GRAB INDEX #{i} Grab Success");
                                                break;
                                            }
                                            else
                                            {
                                                Thread.Sleep(100);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                                    }
                                }


                                if (_selectedFiducialLibrary == null || _selectedFiducialLibrary.Fiducial1.ImageTemplate == null || _selectedFiducialLibrary.Fiducial1.ImageTemplate.Width == 0
                                || _selectedFiducialLibrary.Fiducial2.ImageTemplate == null || _selectedFiducialLibrary.Fiducial2.ImageTemplate.Width == 0)
                                {
                                    // IF_Util.ShowMessageBox_Temp("Error", "Fiducial Mark is Empty");
                                }

                                if (Global.ImagesGrab[0] != null && Global.ImagesGrab[0].Allocated)
                                {
                                    CogImage24PlanarColor imgOrg_Index0 = new CogImage24PlanarColor();
                                    if (_imagesGrab[0] != null)
                                    {
                                        imgOrg_Index0 = new CogImage24PlanarColor(Global.ImagesGrab[0]);
                                    }

                                    for (int i = 0; i < Global.ImagesGrab.Length; i++)
                                    {
                                        if (imgOrg_Index0.Width == 0) imgOrg_Index0 = new CogImage24PlanarColor(Global.ImagesGrab[0]);
                                        if (Global.ImagesGrab[i] != null)
                                        {
                                            _imagesGrab[i] = new Cognex.VisionPro.CogImage24PlanarColor(Global.ImagesGrab[i]);
                                            if (chkAlignNoUse.Checked == false) _imagesGrab[i] = CVisionTools.RotateMarkedImage(new CogImage24PlanarColor(imgOrg_Index0), _imagesGrab[i], _selectedFiducialLibrary);
                                            MenualInsImgArray[i] = new CogImage24PlanarColor(_imagesGrab[i]);
                                            string GRAB_str_ImageName = $"CDImage{i + 1}";

                                            Control GRAB_foundControl = Controls.Find(GRAB_str_ImageName, true).FirstOrDefault();

                                            if (GRAB_foundControl is CogDisplay GRAB_CD)
                                            {
                                                if (GRAB_CD.InvokeRequired)
                                                {
                                                    GRAB_CD.Invoke((MethodInvoker)delegate
                                                    {
                                                        GRAB_CD.Image = _imagesGrab[i];
                                                    });
                                                }
                                                else
                                                {
                                                    GRAB_CD.Image = _imagesGrab[i];
                                                }
                                            }
                                        }
                                    }
                                }

                                SelectGrabImage(0);
                                Global.Instance.OnEnd_Progress();
                            });
                        }
                        catch (Exception ex)
                        {
                            CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                            IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                        }
                        break;
                    case DEFINE.Live:
                        // 카메라 타입 체크...
                        //if (!CCameraHikVision.m_CAMType_Check)
                        //{
                        //    IF_Util.ShowMessageBox("CAM Check", "Not Color Camera!! Color Camera Change!!");
                        //    return;
                        //}

                        DispMain.Image = null;
                        if (!Global.Device.Cameras[0].IsOpen) return;
                        (sender as Button).Text = "LIVE STOP";
                        Global.Device.Cameras[0].Live(true);
                        btnGrab.Enabled = false;
                        break;
                    case DEFINE.Live_Stop:
                        if (!Global.Device.Cameras[0].IsOpen) return;
                        (sender as Button).Text = "LIVE";
                        Global.Device.Cameras[0].Live(false);
                        btnGrab.Enabled = true;
                        break;
                    case DEFINE.Cross:
                        DispMain.InteractiveGraphics.Clear();
                        break;

                    case "LOAD (1)":
                        {
                            try
                            {
                                OpenFileDialog ofd = new OpenFileDialog();
                                ofd.InitialDirectory = Global.m_MainPJTRoot;
                                ofd.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";

                                if (ofd.ShowDialog() == DialogResult.OK)
                                {
                                    m_imgSource_Color = new CogImage24PlanarColor(new Bitmap(ofd.FileName));
                                    m_imgSource_Mono = new CogImage8Grey(new Bitmap(ofd.FileName));

                                    DispMain.Image = m_imgSource_Color;
                                    DispMain.Fit(true);

                                    m_imgSource_Color_FullBoard = new CogImage24PlanarColor(new Bitmap(ofd.FileName));
                                    m_imgSource_Mono_FullBoard = new CogImage8Grey(new Bitmap(ofd.FileName));
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        break;
                    case DEFINE.Image_Load:
                    case "LOAD (1~5)":
                        try
                        {
                            CommonOpenFileDialog FBD = new CommonOpenFileDialog();

                            FBD.IsFolderPicker = true;
                            if (FBD.ShowDialog() == CommonFileDialogResult.Ok)
                            {
                                string selectedFolderPath = FBD.FileName;

                                string[] fileEntries = Directory.GetFiles(selectedFolderPath);

                                int fileCount = Math.Min(fileEntries.Length, 5);
                                _imagesGrab = new CogImage24PlanarColor[5];
                                CogImage24PlanarColor imgOrg_Index0 = new CogImage24PlanarColor();
                                for (int i = 0, imageIndex = 0; i < fileEntries.Length && imageIndex < 5; i++)
                                {
                                    string filePath = fileEntries[i];
                                    string extension = Path.GetExtension(filePath).ToLower();

                                    if (extension == ".jpg" || extension == ".bmp" || extension == ".png")
                                    {
                                        _imagesGrab[imageIndex] = new Cognex.VisionPro.CogImage24PlanarColor(new Bitmap(filePath));
                                        Global.ImagesGrab[imageIndex] = new Cognex.VisionPro.CogImage24PlanarColor(new Bitmap(filePath));

                                        if (imageIndex == 0 && _imagesGrab[0] != null)
                                        {
                                            imgOrg_Index0 = new CogImage24PlanarColor(_imagesGrab[0]);
                                        }
                                        if (chkAlignNoUse.Checked == false) _imagesGrab[imageIndex] = CVisionTools.RotateMarkedImage(new CogImage24PlanarColor(imgOrg_Index0), _imagesGrab[imageIndex], _selectedFiducialLibrary);

                                        imageIndex++;
                                    }
                                }
                                m_imgSource_Color = _imagesGrab[0];

                                SelectGrabImage(0, false);

                                m_imgSource_Color_FullBoard = new Cognex.VisionPro.CogImage24PlanarColor(m_imgSource_Color);
                                m_imgSource_Mono_FullBoard = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;

                    case DEFINE.Image_Save:
                    case "SAVE (1~5)":
                        // 세이브하는것을 묻기전에 이미지가 있는지 확인
                        if (!m_imgSource_Color.Allocated)
                        {
                            IF_Util.ShowMessageBox("NO IMAGE", "Please proceed with Grab");
                            return;
                        }

                        //string strPath = CUtil.SaveImage();
                        string _filesave_name = "";
                        SaveFileDialog _savefiledialog = new SaveFileDialog();
                        bool _ret = false;

                        _savefiledialog.Title = "IMAGE SAVE";
                        _savefiledialog.OverwritePrompt = true;
                        _savefiledialog.Filter = "JPEG File(*.jpg)|*.jpg|Bitmap File(*.bmp)|*.bmp";

                        if (_savefiledialog.ShowDialog() == DialogResult.OK)
                        {
                            _filesave_name = _savefiledialog.FileName;

                            if (IF_Util.ShowMessageBox("SAVE", "Do you want to save it as that path?\nPath : " + _filesave_name, FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                            {
                                for (int i = 0; i < _imagesGrab.Count(); i++)
                                {
                                    int lastDotIndex = _filesave_name.LastIndexOf('.');
                                    string filename = "";
                                    if (lastDotIndex != -1)
                                    {
                                        filename = _filesave_name.Insert(lastDotIndex, $"{i}");
                                    }
                                    CogImage24PlanarColor ImageSource_Color = (CogImage24PlanarColor)_imagesGrab[i];
                                    _ret = CogUtil.RGB_SaveImage(ImageSource_Color, CogUtil.RGB_COLOR.O, $"{filename}");

                                }
                            }
                        }
                        break;
                    case "SAVE (1)":
                        // 세이브하는것을 묻기전에 이미지가 있는지 확인
                        if (!m_imgSource_Color.Allocated)
                        {
                            IF_Util.ShowMessageBox("NO IMAGE", "Please proceed with Grab");
                            return;
                        }

                        //string strPath = CUtil.SaveImage();
                        string savename = "";
                        SaveFileDialog _savefiled = new SaveFileDialog();

                        _savefiled.Title = "IMAGE SAVE";
                        _savefiled.OverwritePrompt = true;
                        _savefiled.Filter = "JPEG File(*.jpg)|*.jpg|Bitmap File(*.bmp)|*.bmp";

                        if (_savefiled.ShowDialog() == DialogResult.OK)
                        {
                            savename = _savefiled.FileName;

                            if (IF_Util.ShowMessageBox("SAVE", "Do you want to save it as that path?\nPath : " + savename, FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                            {
                                CogImage24PlanarColor ImageSource_Color = (CogImage24PlanarColor)DispMain.Image;
                                CogUtil.RGB_SaveImage(ImageSource_Color, CogUtil.RGB_COLOR.O, $"{savename}");
                            }
                        }
                        break;

                    case "ORIGINAL":
                        {
                            if (DispMain.Image == null) return;
                            DispMain.Image = m_imgSource_Color.ScaleImage(DispMain.Image.Width, DispMain.Image.Height);
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();
                        }
                        break;
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public CogImage24PlanarColor LoadImages(string strFileName)
        {

            _imagesGrab[m_nSelectGrabIndex] = new Cognex.VisionPro.CogImage24PlanarColor(new Bitmap(strFileName));

            string str_ImageName = $"CDImage{m_nSelectGrabIndex + 1}";

            Control foundControl = Controls.Find(str_ImageName, true).FirstOrDefault();

            if (foundControl is CogDisplay CD)
            {
                CD.Image = _imagesGrab[m_nSelectGrabIndex];
            }

            m_imgSource_Color = _imagesGrab[m_nSelectGrabIndex];
            m_imgSource_Mono = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
            m_imgSource_Color_FullBoard = _imagesGrab[m_nSelectGrabIndex];
            m_imgSource_Mono_FullBoard = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
            DispMain.Image = m_imgSource_Color;
            DispMain.Fit(true);

            Global.Recent.ImagePath = strFileName;
            Global.Recent.SaveConfig();
            SelectGrabImage(m_nSelectGrabIndex);
            return _imagesGrab[m_nSelectGrabIndex];
        }

        // 메뉴얼 이미지 세이브 시에 사용..
        public void SaveImages(string strFileTitle, string strExt)
        {
            string filePath = "";

            //// 5개 버퍼의 이미지를 저장한다. - 20221222
            for (int i = 0; i < Global.System.Recipe.GrabManager.Nodes.Length; i++)
            {
                if (_imagesGrab[i] == null)
                {
                    IF_Util.ShowMessageBox("Grab Image Check", "No Grab Image!!");
                    return;
                }

                if (Global.System.Recipe.GrabManager.Nodes[i].Enabled && _imagesGrab[i].Allocated)
                {
                    switch (strExt)
                    {
                        case "bmp":
                            filePath = strFileTitle + $"{i}" + ".bmp";
                            Common.SaveImageFileToBMP(_imagesGrab[i], filePath);
                            break;

                        case "png":
                            filePath = strFileTitle + $"{i}" + ".png";
                            Common.SaveImageFileToPNG(_imagesGrab[i], filePath);
                            break;

                        case "jpg":
                            filePath = strFileTitle + $"{i}" + ".jpg";
                            Common.SaveImageFileToJPEG(_imagesGrab[i], filePath);
                            break;

                        default:
                            CLogger.Add(LOG.ABNORMAL, $"{strExt} Format Not Support!");
                            break;
                    }
                }
            }
        }

        // 레시피의 이름을 체크하여 NEW라는 비정상적인 이름이 적용될시 확인..
        // 레시피의 Enabled중에서 Main Tool에서 매칭 데이터가 있는지 체크..


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (IF_Util.ShowMessageBox("SAVE", "Do you want to save the Vision Recipe?") == true)
            {
                try
                {
                    try
                    {
                        for (int i = 0; i < _fiducialLibrary.Count; i++)
                        {
                            _fiducialLibrary[i].Save(Global.Instance.System.Recipe.CODE, _fiducialLibrary[i].LibraryNumber);
                        }
                    }
                    catch (Exception ex)
                    {
                        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                        IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                    }

                    for (int i = 0; i < Global.System.Recipe.JobManager.Length; i++)
                    {
                        CInspJobs JobManager = Global.System.Recipe.JobManager[i];
                        if (JobManager == null)
                        {
                            JobManager = new CInspJobs();
                        }

                        List<string> list = new List<string>();
                        int temp = 0;
                        for (int j = 0; j < JobManager.Jobs.Count; j++)
                        {
                            temp++;
                            string name = JobManager.Jobs[j].Name;
                            if (!list.Contains(name))
                                list.Add(name);
                            else
                            {
                                MessageBox.Show($"{name} - 똑같은 Name을 가진 Job이 존재합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        //foreach (var item in JobManager.Jobs)
                        //{
                        //    temp++;
                        //    string name = item.Name;
                        //    if (!list.Contains(name))
                        //        list.Add(name);
                        //    else
                        //    {
                        //        MessageBox.Show($"{name} - 똑같은 Name을 가진 Job이 존재합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        return;
                        //    }
                        //}
                    }

                    //Global.OnStart_Porgess("Recipe Saving...");

                    Global.System.Recipe.ArrayCount = int.Parse(txtArrayCount.Text);
                    SeqRecipeSave.StartThread();
                }
                catch (Exception ex)
                {
                    IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
        }



        private string lastRecentImageName = "";
        private void timerStatus_Tick(object sender, EventArgs e)
        {

            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                btnDeleteJobAll.Enabled = true;
                pnlClone.Enabled = true;
            }
            else
            {
                btnDeleteJobAll.Enabled = false;
                pnlClone.Enabled = false;
            }
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift
                && (Control.ModifierKeys & Keys.Control) == Keys.Control
                && (Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                btnCloneJobAll.Enabled = true;
            }
            else
            {
                btnCloneJobAll.Enabled = false;

            }
            if (Global.IsInspecting == true)
            {
                if (pnlProgress.Visible == false) pnlProgress.Visible = true;
            }
            else
            {
                if (pnlProgress.Visible == true) pnlProgress.Visible = false;
            }
            // Total Tack Time 찍어주기...
            // 자동 검사 모드일경우..

            //lblTactTime.Text = $"T/T : {Global.SeqVision.CycleTime} ms";

            // 크로스라인 드로우
            try
            {
                label99.Text = Global.Instance.System.Recipe.CODE;

                string strText = string.Format("DiskSpace : {0:0.#0}%", IF_Util.GetAvailDrive());
                lblProcess.Text = $"{_ProcessMode}";
                int recentImageCount = Global.Data.cogRecentImages.Count;

                if (recentImageCount > 0)
                {
                    if (Global.Data.cogRecentImages[recentImageCount - 1].Name != lastRecentImageName)
                    {
                        gridRecentImages.Rows.Clear();

                        for (int i = 0; i < recentImageCount; i++)
                        {
                            gridRecentImages.Rows.Add(Global.Data.cogRecentImages[i].DateTime, Global.Data.cogRecentImages[i].Name);
                        }
                        lastRecentImageName = Global.Data.cogRecentImages[recentImageCount - 1].Name;
                    }
                }

                foreach (DataGridViewColumn dgvc in gridRecentImages.Columns)
                {
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (Global.Device.Cameras.Count > 0)
                {
                    if (btnCross.FillColor == Color.Green)
                    {
                        if (DispMain.Image == null) return;
                        Cognex.VisionPro.CogLineSegment Hori = new Cognex.VisionPro.CogLineSegment();
                        Hori.Color = Cognex.VisionPro.CogColorConstants.Yellow;
                        Hori.StartX = 0;
                        Hori.StartY = DispMain.Image.Height / 2;
                        Hori.EndX = DispMain.Image.Width;
                        Hori.EndY = DispMain.Image.Height / 2;

                        Cognex.VisionPro.CogLineSegment Verti = new Cognex.VisionPro.CogLineSegment();
                        Verti.Color = Cognex.VisionPro.CogColorConstants.Yellow;
                        Verti.StartX = DispMain.Image.Width / 2;
                        Verti.StartY = 0;
                        Verti.EndX = DispMain.Image.Width / 2;
                        Verti.EndY = DispMain.Image.Height;

                        DispMain.InteractiveGraphics.Add(Hori, "Hori", true);
                        DispMain.InteractiveGraphics.Add(Verti, "Vert", true);
                    }
                    else
                    {
                        int idxHori = DispMain.InteractiveGraphics.FindItem("Hori", CogDisplayZOrderConstants.Back);
                        if (idxHori > 0) DispMain.InteractiveGraphics.Remove(idxHori);

                        int idxVert = DispMain.InteractiveGraphics.FindItem("Vert", CogDisplayZOrderConstants.Back);
                        if (idxVert > 0) DispMain.InteractiveGraphics.Remove(idxVert);
                    }
                }

                lblImage_GrabIndex0.BackColor = (_imagesGrab[0] == null || _imagesGrab[0].Allocated == false) ? DEFINE_COMMON.COLOR_BLACK30 : Color.Green;
                lblImage_GrabIndex1.BackColor = (_imagesGrab[1] == null || _imagesGrab[1].Allocated == false) ? DEFINE_COMMON.COLOR_BLACK30 : Color.Green;
                lblImage_GrabIndex2.BackColor = (_imagesGrab[2] == null || _imagesGrab[2].Allocated == false) ? DEFINE_COMMON.COLOR_BLACK30 : Color.Green;
                lblImage_GrabIndex3.BackColor = (_imagesGrab[3] == null || _imagesGrab[3].Allocated == false) ? DEFINE_COMMON.COLOR_BLACK30 : Color.Green;
                lblImage_GrabIndex4.BackColor = (_imagesGrab[4] == null || _imagesGrab[4].Allocated == false) ? DEFINE_COMMON.COLOR_BLACK30 : Color.Green;

                DisplayGrabIdx0.Image = (_imagesGrab[0] == null || _imagesGrab[0].Allocated == false) ? null : _imagesGrab[0];
                DisplayGrabIdx1.Image = (_imagesGrab[1] == null || _imagesGrab[1].Allocated == false) ? null : _imagesGrab[1];
                DisplayGrabIdx2.Image = (_imagesGrab[2] == null || _imagesGrab[2].Allocated == false) ? null : _imagesGrab[2];
                DisplayGrabIdx3.Image = (_imagesGrab[3] == null || _imagesGrab[3].Allocated == false) ? null : _imagesGrab[3];
                DisplayGrabIdx4.Image = (_imagesGrab[4] == null || _imagesGrab[4].Allocated == false) ? null : _imagesGrab[4];
                CopyObject_Init();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void trbLightValue_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int nLightValue = trbLightValue.Value;

                lbLightValue.Text = nLightValue.ToString();
                int nChannel = cbLightCh.SelectedIndex + 1;
                Global.Device.LightController.SetValue(nChannel, nLightValue);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnLightOn_Click(object sender, EventArgs e)
        {
            try
            {
                Global.Device.LightController.AllOn();
                for (int i = 0; i < Global.Device.LightController.ChannelCount; i++) Global.Device.LightController.SetValue(i, 254);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }

        private void btnLightOff_Click(object sender, EventArgs e)
        {
            try
            {
                Global.Device.LightController.AllOff();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }

        public void SelectArray(int nArrayIndex)
        {
            ClearSelectArrays();
            ClearResultArrays();

            lbselectArraies[nArrayIndex].BackColor = DEFINE_COMMON.COLOR_GREEN;
        }

        private void OnClickSelectArray(object sender, EventArgs e)
        {
            try
            {
                string strIndex = (sender as Label).Text;

                if (strIndex == "FULL")
                {
                    ClearSelectArrays();
                    ClearResultArrays();
                    lbSelectFull.BackColor = DEFINE_COMMON.COLOR_GREEN;
                    SelectArray(m_nSelectedArrayIndex - 1);
                    if (_imagesGrab[cbJobGrabIndex.SelectedIndex] != null)
                    {
                        DispMain.Image = _imagesGrab[cbJobGrabIndex.SelectedIndex];
                        DispMain.Fit(true);
                    }
                }
                else
                {
                    if (tabControlAlgorithm.SelectedIndex == 0) // setup
                    {
                        m_nSelectedArrayIndex = int.Parse(strIndex);
                        comboCloneTo.Text = m_nSelectedArrayIndex.ToString();
                        SelectArray(m_nSelectedArrayIndex - 1);
                        int selectedGrab = 0;
                        if (tabControlSetup.SelectedIndex == 0)
                        {
                            selectedGrab = comboGrabIndex_Fiducial.SelectedIndex;
                        }
                        else if (tabControlSetup.SelectedIndex == 1)
                        {
                            selectedGrab = comboQrGrabIndex.SelectedIndex;
                        }

                        if (m_imgSource_Mono_FullBoard != null && m_imgSource_Mono_FullBoard.Allocated)
                        {
                            SelectGrabImage(selectedGrab, false);
                            CropArray(m_nSelectedArrayIndex - 1);
                        }


                    }
                    else if (tabControlAlgorithm.SelectedIndex == 1)
                    {
                        if (Global.System.Recipe.ArrayCount >= int.Parse(strIndex))
                        {
                            m_nSelectedArrayIndex = int.Parse(strIndex);
                            comboCloneTo.Text = m_nSelectedArrayIndex.ToString();
                            SelectArray(m_nSelectedArrayIndex - 1);
                            gridLibrary.SelectionChanged -= gridLibrary_SelectionChanged;
                            InitJobs();
                            gridLibrary.SelectionChanged += gridLibrary_SelectionChanged;
                            SelectGrabImage(cbJobGrabIndex.SelectedIndex, false);
                            CropArray(m_nSelectedArrayIndex - 1);


                        }
                    }
                }
                (sender as Label).BackColor = DEFINE_COMMON.COLOR_GREEN;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }

        public void ClearResultArrays()
        {
            lbSelectResult1.BackColor = DEFINE_COMMON.COLOR_BLACK30;
            lbSelectResult2.BackColor = DEFINE_COMMON.COLOR_BLACK30;
            lbSelectResult3.BackColor = DEFINE_COMMON.COLOR_BLACK30;
            lbSelectResult4.BackColor = DEFINE_COMMON.COLOR_BLACK30;
        }

        public void ClearSelectArrays()
        {
            lbSelectArray1.BackColor = DEFINE_COMMON.COLOR_BLACK30;
            lbSelectArray2.BackColor = DEFINE_COMMON.COLOR_BLACK30;
            lbSelectArray3.BackColor = DEFINE_COMMON.COLOR_BLACK30;
            lbSelectArray4.BackColor = DEFINE_COMMON.COLOR_BLACK30;
            lbSelectFull.BackColor = DEFINE_COMMON.COLOR_BLACK30;
        }

        private void OnClickSelectResult(object sender, EventArgs e)
        {
            try
            {
                // 현재 자동상태에서도 결과이미지 뿌려줌...

                _ProcessMode = "RESULT VIEW MODE";

                string strArrayIdx = (sender as Label).Text;

                ClearSelectArrays();
                ClearResultArrays();

                if (strArrayIdx == "1") if (Global.ImageResults_array[0] != null) DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.ImageResults_array[0]);
                if (strArrayIdx == "2") if (Global.ImageResults_array[1] != null) DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.ImageResults_array[1]);
                if (strArrayIdx == "3") if (Global.ImageResults_array[2] != null) DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.ImageResults_array[2]);
                if (strArrayIdx == "4") if (Global.ImageResults_array[3] != null) DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(Global.ImageResults_array[3]);

                (sender as Label).BackColor = DEFINE_COMMON.COLOR_GREEN;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }

        Mat _imageSourceCV;


        private void OnClick_Fiducial(object sender, EventArgs e)
        {
            try
            {
                string index = "";

                if (sender is Button) index = (sender as Button).Text;
                if (sender is UISymbolButton) index = (sender as UISymbolButton).Text;

                if (comboFiducialLibrary.Text == "" || _selectedFiducialLibrary == null)
                {
                    IF_Util.ShowMessageBox("Error", "Should to selecte the library of fiducial first");
                    return;
                }

                switch (index)
                {
                    case "ROI":
                    case "Roi":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            CogRectangle cogSearchRegion = new CogRectangle();

                            if (radioFiducial_1.Checked) cogSearchRegion = CCognexUtil.RectangleToCogRectangle(_selectedFiducialLibrary.Fiducial1.SearchRoi);
                            if (radioFiducial_2.Checked) cogSearchRegion = CCognexUtil.RectangleToCogRectangle(_selectedFiducialLibrary.Fiducial2.SearchRoi);

                            cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.Color = CogColorConstants.Red;
                            cogSearchRegion.SelectedColor = CogColorConstants.Red;

                            DispMain.InteractiveGraphics.Add(cogSearchRegion, "Search", false);

                            CogRectangle cogTrainRegion = new CogRectangle();

                            if (radioFiducial_1.Checked) cogTrainRegion = CCognexUtil.RectangleToCogRectangle(_selectedFiducialLibrary.Fiducial1.TemplateRoi);
                            if (radioFiducial_2.Checked) cogTrainRegion = CCognexUtil.RectangleToCogRectangle(_selectedFiducialLibrary.Fiducial2.TemplateRoi);

                            cogTrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                            cogTrainRegion.Interactive = true;
                            cogTrainRegion.Color = CogColorConstants.Blue;

                            if (cogTrainRegion.Width == 0 || cogTrainRegion.Height == 0)
                            {
                                cogTrainRegion.Width = 100;
                                cogTrainRegion.Height = 100;
                            }

                            DispMain.InteractiveGraphics.Add(cogTrainRegion, "Pattern", false);
                        }
                        break;

                    case "TRAIN":
                    case "Train":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);

                            if (idx == -1)
                            {
                                IF_Util.ShowMessageBox("Error", "Can't Roi Serch");
                                return;
                            }

                            CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            if (radioFiducial_1.Checked) _selectedFiducialLibrary.Fiducial1.SearchRoi = CCognexUtil.CogRectangleToRectangle(roi);
                            else _selectedFiducialLibrary.Fiducial2.SearchRoi = CCognexUtil.CogRectangleToRectangle(roi);

                            idx = DispMain.InteractiveGraphics.FindItem("Pattern", CogDisplayZOrderConstants.Back);
                            roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            using (Bitmap imgPattern = IF_Util.Crop(m_imgSource_Mono.ToBitmap(), new Rectangle((int)roi.X, (int)roi.Y, (int)roi.Width, (int)roi.Height)))
                            {
                                cogDisplay_Fiducial_Pattern.Image = new CogImage8Grey(imgPattern);
                                cogDisplay_Fiducial_Pattern.Fit(true);

                                CogRectangle cogTrainRegion = new CogRectangle();
                                CogRectangle cogSearchRegion = new CogRectangle();

                                if (radioFiducial_1.Checked)
                                {
                                    _selectedFiducialLibrary.Fiducial1.TemplateRoi = CCognexUtil.CogRectangleToRectangle(roi);
                                    _selectedFiducialLibrary.Fiducial1.ImageTemplate = (Bitmap)imgPattern.Clone();
                                }
                                else if (radioFiducial_2.Checked)
                                {
                                    _selectedFiducialLibrary.Fiducial2.TemplateRoi = CCognexUtil.CogRectangleToRectangle(roi);
                                    _selectedFiducialLibrary.Fiducial2.ImageTemplate = (Bitmap)imgPattern.Clone();
                                }
                            }
                        }
                        break;

                    case "FIND":
                    case "Find":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            int mag_1st = 1;
                            int mag_2st = 1;

                            Stopwatch sw = new Stopwatch();
                            sw.Start();

                            CTemplateMatching matching = new CTemplateMatching("Matching");
                            matching.SetSourceImage(m_imgSource_Mono.ToBitmap());

                            if (radioFiducial_1.Checked) matching.Run(_selectedFiducialLibrary.Fiducial1);
                            else matching.Run(_selectedFiducialLibrary.Fiducial2);

                            double dMaxScore = double.MinValue;
                            Rect rtMaxScore = new Rect();
                            Point2d pointMaxScore = new Point2d();

                            if (matching.Results.Count > 0)
                            {
                                if (dMaxScore < matching.Results[0].Score)
                                {
                                    dMaxScore = matching.Results[0].Score;
                                    rtMaxScore = matching.Results[0].Bounding;
                                    pointMaxScore = matching.Results[0].Center;
                                }

                                DispMain.StaticGraphics.Clear();

                                CogRectangle cogRectDetected = new CogRectangle();
                                cogRectDetected.X = rtMaxScore.X;
                                cogRectDetected.Y = rtMaxScore.Y;
                                cogRectDetected.Width = rtMaxScore.Width;
                                cogRectDetected.Height = rtMaxScore.Height;
                                cogRectDetected.Color = CogColorConstants.Green;

                                CCognexUtil.DrawString(DispMain, $"Score : {dMaxScore:0.00} %  ({pointMaxScore.X},{pointMaxScore.Y})", rtMaxScore.Location, CogColorConstants.Green, 10);
                                CCognexUtil.DrawPosMarker(pointMaxScore, rtMaxScore.Width, rtMaxScore.Height, DispMain, CogColorConstants.Green);
                                DispMain.StaticGraphics.Add(cogRectDetected, "RT");
                            }
                            else
                            {
                                IF_Util.ShowMessageBox("Error", "Can't Find the Mark");
                            }

                            sw.Stop();
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private Point2d FindFiducialMark(bool isDraw = true)
        {
            Point2d pos = new Point2d();
            try
            {
                if (isDraw) DispMain.StaticGraphics.Clear();

                int mag_1st = 1;
                int mag_2st = 1;

                Stopwatch sw = new Stopwatch();
                sw.Start();

                CTemplateMatching matching = new CTemplateMatching("Matching");
                matching.SetSourceImage(_imagesGrab[0].ToBitmap());

                matching.Run(_selectedFiducialLibrary.Fiducial1);

                double dMaxScore = double.MinValue;
                Rect rtMaxScore = new Rect();
                Point2d pointMaxScore = new Point2d();

                if (matching.Results.Count > 0)
                {
                    if (dMaxScore < matching.Results[0].Score)
                    {
                        dMaxScore = matching.Results[0].Score;
                        rtMaxScore = matching.Results[0].Bounding;
                        pos = pointMaxScore = matching.Results[0].Center;
                    }

                    if (isDraw)
                    {
                        CogRectangle cogRectDetected = new CogRectangle();
                        cogRectDetected.X = rtMaxScore.X;
                        cogRectDetected.Y = rtMaxScore.Y;
                        cogRectDetected.Width = rtMaxScore.Width;
                        cogRectDetected.Height = rtMaxScore.Height;
                        cogRectDetected.Color = CogColorConstants.Green;

                        CCognexUtil.DrawString(DispMain, $"Score : {dMaxScore:0.00} %  ({pointMaxScore.X},{pointMaxScore.Y})", rtMaxScore.Location, CogColorConstants.Green, 10);
                        CCognexUtil.DrawPosMarker(pointMaxScore, rtMaxScore.Width, rtMaxScore.Height, DispMain, CogColorConstants.Green);
                        DispMain.StaticGraphics.Add(cogRectDetected, "RT");
                    }
                }
                else
                {
                    IF_Util.ShowMessageBox("Error", "Can't Find the Mark");
                }

                sw.Stop();
            }
            catch (Exception ex)
            {
                return pos;
            }
            finally
            {

            }

            return pos;
        }

        private Point2d FindFiducialMarkInAarry()
        {
            Point2d pos = new Point2d();
            try
            {
                DispMain.StaticGraphics.Clear();

                int mag_1st = 1;
                int mag_2st = 1;

                Stopwatch sw = new Stopwatch();
                sw.Start();

                CTemplateMatching matching = new CTemplateMatching("Matching");
                matching.SetSourceImage(m_imgSource_Color.ToBitmap());

                matching.Run(_selectedFiducialLibrary.Fiducial1, new Rect((int)_selectedFiducialLibrary.OffsetArray1.X - _selectedFiducialLibrary.Fiducial1.SearchRoi.Width / 2, (int)_selectedFiducialLibrary.OffsetArray1.Y - _selectedFiducialLibrary.Fiducial1.SearchRoi.Height / 2, _selectedFiducialLibrary.Fiducial1.SearchRoi.Width, _selectedFiducialLibrary.Fiducial1.SearchRoi.Height));

                double dMaxScore = double.MinValue;
                Rect rtMaxScore = new Rect();
                Point2d pointMaxScore = new Point2d();

                if (matching.Results.Count > 0)
                {
                    if (dMaxScore < matching.Results[0].Score)
                    {
                        dMaxScore = matching.Results[0].Score;
                        rtMaxScore = matching.Results[0].Bounding;
                        pos = pointMaxScore = matching.Results[0].Center;
                    }

                    DispMain.StaticGraphics.Clear();

                    CogRectangle cogRectDetected = new CogRectangle();
                    cogRectDetected.X = rtMaxScore.X;
                    cogRectDetected.Y = rtMaxScore.Y;
                    cogRectDetected.Width = rtMaxScore.Width;
                    cogRectDetected.Height = rtMaxScore.Height;
                    cogRectDetected.Color = CogColorConstants.Green;

                    CCognexUtil.DrawString(DispMain, $"Score : {dMaxScore:0.00} %  ({pointMaxScore.X},{pointMaxScore.Y})", rtMaxScore.Location, CogColorConstants.Green, 10);
                    CCognexUtil.DrawPosMarker(pointMaxScore, rtMaxScore.Width, rtMaxScore.Height, DispMain, CogColorConstants.Green);
                    DispMain.StaticGraphics.Add(cogRectDetected, "RT");
                }
                else
                {
                    IF_Util.ShowMessageBox("Error", "Can't Find the Mark");
                }

                sw.Stop();
            }
            catch (Exception ex)
            {
                return pos;
            }
            finally
            {

            }

            return pos;
        }

        private void OnClickAlgorithm_Pattern(object sender, EventArgs e)
        {
            try
            {
                int idx;

                idx = DispMain.InteractiveGraphics.FindItem("Result", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);

                if (idx > 0)
                {
                    DispMain.InteractiveGraphics.Remove(idx);
                }

                DisplayTrainCount();

                string strIndex = (sender as UIButton).Text;

                CCogTool_PMAlign PMAlign = null;

                if (comboJobPattern_PatternType.Text == "" && comboJobPattern_PatternType.Items.Count > 0) comboJobPattern_PatternType.SelectedIndex = 0;

                if (comboJobPattern_PatternType.Text == "Main") PMAlign = m_selectedJob.Tool;
                else if (comboJobPattern_PatternType.Text == "Sub1") PMAlign = m_selectedJob.SubTool1;
                else if (comboJobPattern_PatternType.Text == "Sub2") PMAlign = m_selectedJob.SubTool2;
                else if (comboJobPattern_PatternType.Text == "Sub3") PMAlign = m_selectedJob.SubTool3;
                else if (comboJobPattern_PatternType.Text == "Sub4") PMAlign = m_selectedJob.SubTool4;
                if (PMAlign == null) return;

                //propertyGrid_Jobs.SelectedObject = PMAlign.Tool.RunParams;

                switch (strIndex)
                {
                    case "ROI":
                    case "Roi":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();
                            if (PMAlign.Tool.SearchRegion == null)
                            {
                                PMAlign.Tool.SearchRegion = new Cognex.VisionPro.CogRectangle();
                                cogSearchRegion.X = 50;
                                cogSearchRegion.Y = 50;
                                cogSearchRegion.Width = 300;
                                cogSearchRegion.Height = 300;
                                PMAlign.Tool.SearchRegion.FitToImage(m_imgSource_Mono, 1.0D, 1.0D);
                            }
                            else
                            { 
                              cogSearchRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion;
                            }

                            //검사 영역
                            cogSearchRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.DragColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.LineWidthInScreenPixels = 2;

                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogSearchRegion, "Search", false);

                            // Train 영역
                            Cognex.VisionPro.CogRectangle cogTrainRegion = new Cognex.VisionPro.CogRectangle();

                            if (PMAlign.Tool.Pattern.TrainRegion != null)
                            {
                                if (PMAlign.Tool.Pattern.TrainRegion.ToString() == "Cognex.VisionPro.CogRectangle")
                                {
                                    cogTrainRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Tool.Pattern.TrainRegion;
                                }
                                else
                                {
                                    cogTrainRegion.X = 30;
                                    cogTrainRegion.Y = 30;
                                    cogTrainRegion.Width = 250;
                                    cogTrainRegion.Height = 250;
                                }

                                cogTrainRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                                cogTrainRegion.Interactive = true;
                                cogTrainRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Blue;
                                cogTrainRegion.DragColor = Cognex.VisionPro.CogColorConstants.Blue;
                                cogTrainRegion.Color = Cognex.VisionPro.CogColorConstants.Blue;
                                cogTrainRegion.LineWidthInScreenPixels = 2;
                            }

                            if (cogTrainRegion.Width == 0) cogTrainRegion.Width = 250;
                            if (cogTrainRegion.Height == 0) cogTrainRegion.Height = 250;

                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogTrainRegion, "Pattern", false);

                            if (chkColor.Checked)
                            {
                                Cognex.VisionPro.CogRectangle cogPatternColorRegion = new CogRectangle();
                                cogPatternColorRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                                cogPatternColorRegion.Interactive = true;
                                cogPatternColorRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Yellow;
                                cogPatternColorRegion.DragColor = Cognex.VisionPro.CogColorConstants.Yellow;
                                cogPatternColorRegion.Color = Cognex.VisionPro.CogColorConstants.Yellow;
                                cogPatternColorRegion.LineWidthInScreenPixels = 2;

                                if (m_selectedJob.valueRect.X == 0 && m_selectedJob.valueRect.Y == 0 && m_selectedJob.valueRect.Width == 100 && m_selectedJob.valueRect.Height == 100)
                                {
                                    if (cogPatternColorRegion.Width == 0) cogPatternColorRegion.Width = 250;
                                    if (cogPatternColorRegion.Height == 0) cogPatternColorRegion.Height = 250;

                                    //cogDisplay_Source.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogPatternColorRegion, "PatternColor", false);
                                }
                                else
                                {
                                    cogPatternColorRegion.X = m_selectedJob.valueRect.X;
                                    cogPatternColorRegion.Y = m_selectedJob.valueRect.Y;
                                    cogPatternColorRegion.Width = m_selectedJob.valueRect.Width;
                                    cogPatternColorRegion.Height = m_selectedJob.valueRect.Height;

                                    //cogDisplay_Source.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogPatternColorRegion, "PatternColor", false);

                                    chkColor.Checked = true;
                                    cboPatternColorCoordinate.Text = m_selectedJob.CCoordinate.ToString();
                                    cboPatternColorAlg.Text = m_selectedJob.CMethod.ToString();
                                }
                                DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogPatternColorRegion, "PatternColor", false);
                            }
                        }
                        break;

                    case "TRAIN":
                    case "Train":
                        {
                            if (m_selectedJob.Type.Contains("Library") == true)
                            {
                                IF_Util.ShowMessageBox("ERROR", "Library Can't Train");
                                return;
                            }

                            int SelectArrayIndex = m_nSelectedArrayIndex - 1;

                            CogRectangle Roi_Search = new CogRectangle();
                            CogRectangle Roi_Pattern = new CogRectangle();
                            CogRectangle Roi_DeepLearning = new CogRectangle();
                            CogRectangle Roi_PatternColor = new CogRectangle();

                            idx = DispMain.InteractiveGraphics.FindItem("Search", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
                            if (idx > -1)
                            {
                                Roi_Search = (DispMain.InteractiveGraphics[idx] as CogRectangle);
                            }
                            idx = DispMain.InteractiveGraphics.FindItem("Pattern", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
                            if (idx > -1)
                            {
                                Roi_Pattern = (DispMain.InteractiveGraphics[idx] as CogRectangle);
                            }
                            idx = DispMain.InteractiveGraphics.FindItem("DeepLearning", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
                            if (idx > -1)
                            {
                                Roi_DeepLearning = (DispMain.InteractiveGraphics[idx] as CogRectangle);
                            }
                            idx = DispMain.InteractiveGraphics.FindItem("PatternColor", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
                            if (idx > -1)
                            {
                                Roi_PatternColor = (DispMain.InteractiveGraphics[idx] as CogRectangle);
                            }

                            Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SearchRegion = new Rectangle(Convert.ToInt32(Roi_Search.X), Convert.ToInt32(Roi_Search.Y), Convert.ToInt32(Roi_Search.Width), Convert.ToInt32(Roi_Search.Height));

                            if (m_selectedJob.CMethod.ToString() == ColorMethod.CA_ConvertGray.ToString() && m_selectedJob.CCoordinate.ToString() == ColorCoordinate.CC_GRAY.ToString())
                            {
                                PMAlign.Tool.Pattern.TrainImage = m_imgSource_Mono;
                            }
                            else
                            {
                                // 아래 이미지를 부품만 추릴수 있도록 가공 후 적용한다.
                                Mat inImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Color.ToBitmap()).Clone();
                                Bitmap imgIn = CVisionTools.GetPatterernImage_Train(false, ref m_selectedJob, inImg, Roi_Search, Roi_Pattern, Roi_DeepLearning, Roi_PatternColor);
                                m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey(imgIn);
                                PMAlign.Tool.Pattern.TrainImage = m_imgSource_Mono;
                            }

                            Cognex.VisionPro.CogRectangle CR = new CogRectangle();
                            CR.X = Roi_Pattern.X;
                            CR.Y = Roi_Pattern.Y;
                            CR.Width = Roi_Pattern.Width;
                            CR.Height = Roi_Pattern.Height;
                            if (comboJobPattern_PatternType.SelectedItem.ToString() == "Main")
                            {
                                Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].Tool.Tool.Pattern.TrainRegion = CR;
                                Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].Tool.Tool.SearchRegion = Roi_Search;
                            }
                            else if (comboJobPattern_PatternType.SelectedItem.ToString() == "Sub1")
                            {
                                Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool1.Tool.Pattern.TrainRegion = CR;
                                Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool1.Tool.SearchRegion = Roi_Search;
                            }
                            else if (comboJobPattern_PatternType.SelectedItem.ToString() == "Sub2")
                            {
                                Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool2.Tool.Pattern.TrainRegion = CR;
                                Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool2.Tool.SearchRegion = Roi_Search;
                            }
                            else if (comboJobPattern_PatternType.SelectedItem.ToString() == "Sub3")
                            {
                                Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool3.Tool.Pattern.TrainRegion = CR;
                                Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool3.Tool.SearchRegion = Roi_Search;
                            }
                            else if (comboJobPattern_PatternType.SelectedItem.ToString() == "Sub4")
                            {
                                Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool4.Tool.Pattern.TrainRegion = CR;
                                Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SubTool4.Tool.SearchRegion = Roi_Search;
                            }

                            // LC Read 기능 추가
                            //if (cb_LCReadUse.Checked)
                            //{
                            //    m_selectedJob.MasterCount = int.Parse(nbJobIcLead_MasterCount.ToString());
                            //    Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].Tool.Tool.RunParams.ApproximateNumberToFind = m_selectedJob.MasterCount;
                            //}

                            CogRectangle Roi;
                            if (chkColor.Checked)
                            {
                                idx = DispMain.InteractiveGraphics.FindItem("PatternColor", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
                                if (idx > -1)
                                {
                                    Roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);
                                    m_selectedJob.valueRect = new Rectangle((int)Roi.X, (int)Roi.Y, (int)Roi.Width, (int)Roi.Height);
                                    Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].valueRect = new Rectangle(Convert.ToInt32(Roi_PatternColor.X), Convert.ToInt32(Roi_PatternColor.Y), Convert.ToInt32(Roi_PatternColor.Width), Convert.ToInt32(Roi_PatternColor.Height));
                                    UpdateColorUI(lbPatternColor, lbPatternColor2, trbThreshold_Color, lbThreshold_Color);
                                }
                            }

                            PMAlign.Tool.Pattern.Origin.TranslationX = (PMAlign.Tool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterX;
                            PMAlign.Tool.Pattern.Origin.TranslationY = (PMAlign.Tool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterY;

                            // 현재 트레인시에...이미지 밝기 정도의 차이로 인해 트레인 안되는 경우가 있음..
                            // 체크 필요...
                            try
                            {
                                PMAlign.Tool.Pattern.Train();
                            }
                            catch
                            {
                                IF_Util.ShowMessageBox("Train Error", "Current Image Not Train!! Grab Image Index Change Please!!");
                                return;
                            }
                            if (tcAlgorithm.SelectedTab.Text == "Pattern")
                            {
                                cogDisplay_JobPattern.InteractiveGraphics.Clear();
                                cogDisplay_JobPattern.StaticGraphics.Clear();
                                cogDisplay_JobPattern.Image = PMAlign.Tool.Pattern.GetTrainedPatternImage();
                                CVisionCognex.TrainGraphic(PMAlign.Tool, cogDisplay_JobPattern);
                                cogDisplay_JobPattern.Fit(true);
                            }

                            DisplayTrainCount();
                        }
                        break;

                    case "RUN":
                    case "INSP":
                    case "Find":
                        {
                            Stopwatch tactTime = Stopwatch.StartNew();
                            Cognex.VisionPro.CogGraphicLabel label = new Cognex.VisionPro.CogGraphicLabel();
                            bool bol_Result = true;

                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();
                            Rectangle PMAlignRect = new Rectangle();
                            CogRectangle cogRectangle = new CogRectangle();
                            if (tbJobPattern_AcceptScore.Text != "")
                                PMAlign.Tool.RunParams.AcceptThreshold = double.Parse(tbJobPattern_AcceptScore.Text.ToString());

                            // 여기 이미지 전처리 추가
                            if ((int)m_selectedJob.CMethod < 0)
                                m_selectedJob.CMethod = 0;
                            if ((int)m_selectedJob.CCoordinate < 0)
                                m_selectedJob.CCoordinate = 0;
                            if (m_selectedJob.CMethod.ToString() == ColorMethod.CA_ConvertGray.ToString() && m_selectedJob.CCoordinate.ToString() == ColorCoordinate.CC_GRAY.ToString())
                            {
                                PMAlign.Tool.InputImage = m_imgSource_Mono;
                            }
                            else
                            {
                                Mat inImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Color.ToBitmap()).Clone();
                                Bitmap imgIn = CVisionTools.GetPatterernImage(false, ref m_selectedJob, inImg);
                                m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey(imgIn);
                                Bitmap img = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(inImg);
                                DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(img);
                                PMAlign.Tool.InputImage = m_imgSource_Mono;
                            }

                            DispMain.StaticGraphics.Add((Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion, "main");

                            PMAlign.Tool.Run();
                            label.Font = new Font("Arial", 14);
                            label.LineWidthInScreenPixels = 5;
                            for (int i = 0; i < PMAlign.Tool.Results.Count; i++)
                            {
                                label.X = PMAlign.Tool.Results[i].GetPose().TranslationX;
                                label.Y = PMAlign.Tool.Results[i].GetPose().TranslationY - 20;
                            }

                            string str_Result = "";
                            string[] strAry_InspResult;
                            string str_InspPartName;
                            float str_Score = 0;
                            int count = int.Parse(tbPatternMasterCount.Text);
                            List<CogPMAlignResult> pMAlignResult = new List<CogPMAlignResult>();

                            Inspection_PatternMatching(PMAlign, false, out pMAlignResult);

                            int MasterCount = int.Parse(tbPatternMasterCount.Text.ToString());

                            if (MasterCount == 1)
                            {
                                double ResultAcceptedScore = double.Parse(tbJobPattern_MinScore.Text.ToString());
                                CogRectangle Roi_Search1 = PMAlign.Tool.SearchRegion as CogRectangle;
                                label.X = Roi_Search1.X;
                                label.Y = Roi_Search1.Y;

                                if (pMAlignResult != null)
                                {

                                    label.Text = $"Result Score:{pMAlignResult[0].Score.ToString("F3")} Min Score: {ResultAcceptedScore}";
                                    lblDetectedPatternCount.Text = $"Count :1";
                                    if (m_selectedJob.Judge_NaisNg == true)
                                    {
                                        if (pMAlignResult[0].Score < ResultAcceptedScore)
                                        {
                                            bol_Result = false;
                                        }
                                    }
                                    else
                                    {
                                        if (pMAlignResult[0].Score > ResultAcceptedScore)
                                        {
                                            bol_Result = false;
                                        }
                                    }
                                }
                                else
                                {

                                    label.Text = $"Count NG Not Find";
                                    bol_Result = false;
                                }

                            }
                            else
                            {
                                int ResultAcceptedCount = 0;
                                CogRectangle Roi_Search = PMAlign.Tool.SearchRegion as CogRectangle;
                                label.X = Roi_Search.X;
                                label.Y = Roi_Search.Y;

                                if (pMAlignResult != null)
                                {
                                    foreach (var item in pMAlignResult)
                                    {
                                        if (item.Accepted)
                                        {
                                            ResultAcceptedCount++;
                                        }
                                    }
                                    if (ResultAcceptedCount != MasterCount)
                                    {
                                        label.Text = $"Count NG Find:{ResultAcceptedCount}  Master:{MasterCount}";
                                        bol_Result = false;
                                    }
                                    else
                                    {
                                        label.Text = $"Count OK Find:{ResultAcceptedCount}  Master:{MasterCount}";
                                    }
                                    lblDetectedPatternCount.Text = $"Count :{ResultAcceptedCount}";
                                }
                                else
                                {

                                    label.Text = $"Count NG Find:{ResultAcceptedCount}  Master:{MasterCount}";
                                    bol_Result = false;
                                }
                            }

                            if (bol_Result)
                            {
                                label.Color = CogColorConstants.Green;
                                cogRectangle.Color = CogColorConstants.Green;
                            }
                            else
                            {
                                label.Color = CogColorConstants.Red;
                                cogRectangle.Color = CogColorConstants.Red;
                            }

                            idx = DispMain.InteractiveGraphics.FindItem("Result", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);

                            if (idx > 0)
                            {
                                DispMain.InteractiveGraphics.Remove(idx);
                            }

                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)label, "Result", false);

                            tactTime.Stop();
                        }
                        break;

                    case "CUT ROI":
                        {
                            PMAlign.Tool.InputImage = m_imgSource_Mono;
                            PMAlign.Tool.Run();

                            CogPMAlignResult result = null;
                            double dMaxScore = 0.0D;
                            for (int i = 0; i < PMAlign.Tool.Results.Count; i++)
                            {
                                if (dMaxScore < PMAlign.Tool.Results[i].Score)
                                {
                                    dMaxScore = PMAlign.Tool.Results[i].Score;
                                    result = PMAlign.Tool.Results[i];
                                }
                            }

                            if (result == null)
                            {
                                IF_Util.ShowMessageBox("ERROR", "Can't Find the Board Pattern");
                                return;
                            }

                            m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor(IF_Util.Crop(m_imgSource_Color.ToBitmap(), new Rectangle((int)result.GetPose().TranslationX, (int)result.GetPose().TranslationY, PMAlign.TrainedPatternImage.Width, PMAlign.TrainedPatternImage.Height)));
                            DispMain.Image = m_imgSource_Color;
                            DispMain.Fit(true);
                        }
                        break;

                    case "MASK":
                    case "Mask":
                        {
                            FormPopUp_Settings_Masking Frm = new FormPopUp_Settings_Masking(m_selectedJob, m_imgSource_Mono);
                            Frm.ShowDialog();

                            cogDisplay_JobPattern.InteractiveGraphics.Clear();
                            cogDisplay_JobPattern.StaticGraphics.Clear();

                            CVisionCognex.TrainGraphic(m_selectedJob.Tool.Tool, cogDisplay_JobPattern);

                            cogDisplay_JobPattern.Image = m_selectedJob.Tool.Tool.Pattern.GetTrainedPatternImage();
                            cogDisplay_JobPattern.Fit(false);
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
            }
        }

        private void OnClickAlgorithm_EyeD(object sender, EventArgs e)
        {
            try
            {
                string strIndex = (sender as UIButton).Text;

                switch (strIndex)
                {
                    case "ROI":
                    case "Roi":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();
                            m_selectedJob = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library];
                            if (m_selectedJob.SearchRegion.Width == 0 || m_selectedJob.SearchRegion.Height == 0)
                            {
                                m_selectedJob.SearchRegion = new Rectangle(0, 0, 100, 100);
                            }
                            //검사 영역
                            Cognex.VisionPro.CogRectangle cogSearchRegion = CConverter.RectToCogRect(m_selectedJob.SearchRegion);
                            cogSearchRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.DragColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.LineWidthInScreenPixels = 2;
                            if (cogSearchRegion.Width == 0) cogSearchRegion.Width = 250;
                            if (cogSearchRegion.Height == 0) cogSearchRegion.Height = 250;

                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogSearchRegion, "Search", false);

                            //스펙 영역
                            Cognex.VisionPro.CogRectangle cogSpecRegion = CConverter.RectToCogRect(m_selectedJob.Parameter.EyeD_SpecRegion);
                            cogSpecRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                            cogSpecRegion.Interactive = true;
                            cogSpecRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Orange;
                            cogSpecRegion.DragColor = Cognex.VisionPro.CogColorConstants.Orange;
                            cogSpecRegion.Color = Cognex.VisionPro.CogColorConstants.Orange;
                            cogSpecRegion.LineWidthInScreenPixels = 2;
                            if (cogSpecRegion.Width == 0) cogSpecRegion.Width = 100;
                            if (cogSpecRegion.Height == 0) cogSpecRegion.Height = 100;

                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogSpecRegion, "SpecRegion", false);
                            (sender as UIButton).Text = "Complete";
                        }
                        break;
                    case "Complete":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                            CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            m_selectedJob.SearchRegion = CConverter.CogRectToRect(roi);

                            idx = DispMain.InteractiveGraphics.FindItem("SpecRegion", CogDisplayZOrderConstants.Back);
                            CogRectangle specRegion = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            m_selectedJob.Parameter.EyeD_SpecRegion = CConverter.CogRectToRect(specRegion);

                            (sender as UIButton).Text = "Roi";
                        }
                        break;
                    case "RUN":
                    case "INSP":
                    case "Find":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            string modelName = comboEyeDModelName.Text;
                            string inferType = comboEyeDInferType.Text;
                            Task.Run(() =>
                            {
                                Stopwatch tt = Stopwatch.StartNew();

                                using (Mat imgCrop = OpenCvSharp.Extensions.BitmapConverter.ToMat(IF_Util.Crop(m_imgSource_Color.ToBitmap(), m_selectedJob.SearchRegion)).Clone())
                                {


                                    string uniqueID = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
                                    string imageDir = $"{Application.StartupPath}\\EYED";
                                    if (Directory.Exists(imageDir) == false) Directory.CreateDirectory(imageDir);
                                    string imagePath = $"{imageDir}\\{modelName}_{inferType}_{DateTime.Now.ToString("yyyyMMdd_HHmmssfff")}.jpg";

                                    CVisionTools.RotateImage(imgCrop, m_selectedJob.Parameter.EyeD_ImageRotateAngle).SaveImage(imagePath);

                                    Global.Device.EyeD.Send($"[{modelName},{uniqueID},{inferType},{imagePath}]\r\n", "");

                                    while (tt.ElapsedMilliseconds < 200000)
                                    {
                                        if (Global.Device.EyeD.RecvResults.ContainsKey(uniqueID))
                                        {
                                            lblTactTime.Invoke((Action)(() =>
                                            {
                                                lblTactTime.Text = $"T/T : {tt.ElapsedMilliseconds}ms";
                                            }));

                                            //{[20240405_182031471, (relay;0.92;209;44;44;45)]}
                                            string resultString = Global.Device.EyeD.RecvResults[uniqueID].ResultString;

                                            List<string> resultList = new List<string>();
                                            MatchCollection matches = Regex.Matches(resultString, @"\([^()]*\)");

                                            // 추출된 내용을 리스트에 추가
                                            foreach (Match match in matches)
                                            {
                                                resultList.Add(match.Value);
                                            }

                                            if (resultList.Count > 0)
                                            {
                                                string resultInferType = resultList[0];
                                                string bestTag = "";
                                                double bestScore = 0.0D;

                                                for (int i = 1; i < resultList.Count; i++)
                                                {
                                                    string value = resultList[i];
                                                    double score = 0.0D;

                                                    value = value.Replace("(", "");
                                                    value = value.Replace(")", "");
                                                    string[] values = value.Split(";");

                                                    if (string.Equals(resultInferType, "(CLS)"))
                                                    {
                                                        if (values.Length == 2)
                                                        {
                                                            double.TryParse(values[1], out score);

                                                            if (bestScore < score)
                                                            {
                                                                bestScore = score;
                                                                bestTag = values[0];
                                                            }
                                                        }
                                                    }
                                                    else if (string.Equals(resultInferType, "(DET)"))
                                                    {
                                                        if (values.Length == 6)
                                                        {
                                                            string tag = values[0];


                                                            double.TryParse(values[1], out score);

                                                            bool success = true;
                                                            success &= int.TryParse(values[2], out int x);
                                                            success &= int.TryParse(values[3], out int y);
                                                            success &= int.TryParse(values[4], out int w);
                                                            success &= int.TryParse(values[5], out int h);

                                                            if (success)
                                                            {
                                                                Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();

                                                                cogSearchRegion.LineWidthInScreenPixels = 2;

                                                                if (m_selectedJob.Parameter.EyeD_ImageRotateAngle == 0 || m_selectedJob.Parameter.EyeD_ImageRotateAngle == 180)
                                                                {
                                                                    cogSearchRegion.X = m_selectedJob.SearchRegion.X + x;
                                                                    cogSearchRegion.Y = m_selectedJob.SearchRegion.Y + y;
                                                                    cogSearchRegion.Width = w;
                                                                    cogSearchRegion.Height = h;
                                                                }
                                                                else if (m_selectedJob.Parameter.EyeD_ImageRotateAngle == 90 || m_selectedJob.Parameter.EyeD_ImageRotateAngle == 270)
                                                                {
                                                                    cogSearchRegion.X = m_selectedJob.SearchRegion.X + y;
                                                                    cogSearchRegion.Y = m_selectedJob.SearchRegion.Y + x;
                                                                    cogSearchRegion.Width = h;
                                                                    cogSearchRegion.Height = w;
                                                                }


                                                                Cognex.VisionPro.CogCircle cogCircleCenter = new CogCircle();
                                                                cogCircleCenter.CenterX = cogSearchRegion.X + cogSearchRegion.Width / 2;
                                                                cogCircleCenter.CenterY = cogSearchRegion.Y + cogSearchRegion.Height / 2;
                                                                cogCircleCenter.Radius = 5;
                                                                cogCircleCenter.Color = CogColorConstants.Orange;

                                                                if (m_selectedJob.Parameter.EyeD_MinScore <= score)
                                                                {
                                                                    if (m_selectedJob.Parameter.EyeD_UseSpecRegion)
                                                                    {
                                                                        if (m_selectedJob.Parameter.EyeD_SpecRegion.Contains(IF_Util.CeterFromRectangle(CConverter.CogRectToRect(cogSearchRegion))))
                                                                        {
                                                                            cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Green;
                                                                            CCognexUtil.DrawString(DispMain, $"Model : {tag} Score : {score} RECT : {cogSearchRegion.X.ToString("F1")},{cogSearchRegion.Y.ToString("F1")},{cogSearchRegion.Width.ToString("F1")},{cogSearchRegion.Height.ToString("F1")}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Green, 10);
                                                                        }
                                                                        else
                                                                        {
                                                                            cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                                                                            CCognexUtil.DrawString(DispMain, $"SpecRegion : Out Model : {tag} Score : {score}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Red, 10);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Green;
                                                                        CCognexUtil.DrawString(DispMain, $"Model : {tag} Score : {score} RECT : {cogSearchRegion.X.ToString("F1")},{cogSearchRegion.Y.ToString("F1")},{cogSearchRegion.Width.ToString("F1")},{cogSearchRegion.Height.ToString("F1")}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Green, 10);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                                                                    CCognexUtil.DrawString(DispMain, $"Model : {tag} Score : {score}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Red, 10);
                                                                }

                                                                DispMain.InteractiveGraphics.Add(cogSearchRegion, "", false);

                                                                if (m_selectedJob.Parameter.EyeD_UseSpecRegion)
                                                                {
                                                                    Cognex.VisionPro.CogRectangle cogSpecRegion = CConverter.RectToCogRect(m_selectedJob.Parameter.EyeD_SpecRegion);

                                                                    cogSpecRegion.LineWidthInScreenPixels = 2;
                                                                    cogSpecRegion.Color = CogColorConstants.Orange;

                                                                    DispMain.InteractiveGraphics.Add(cogCircleCenter, "", false);
                                                                    DispMain.InteractiveGraphics.Add(cogSpecRegion, "", false);

                                                                }

                                                            }
                                                        }
                                                    }
                                                    else if (string.Equals(resultInferType, "(OBB)"))
                                                    {
                                                        if (values.Length == 7)
                                                        {
                                                            string tag = values[0];


                                                            double.TryParse(values[1], out score);

                                                            bool success = true;
                                                            success &= int.TryParse(values[2], out int x);
                                                            success &= int.TryParse(values[3], out int y);
                                                            success &= int.TryParse(values[4], out int w);
                                                            success &= int.TryParse(values[5], out int h);
                                                            success &= double.TryParse(values[6], out double t);

                                                            if (success)
                                                            {
                                                                Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();

                                                                //cogSearchRegion.SetOriginLengthsRotationSkew(m_selectedJob.SearchRegion.X + x, m_selectedJob.SearchRegion.Y + y,w, h, t,0 );//* Math.PI / 180,0
                                                                //cogSearchRegion.SetCenterLengthsRotationSkew(m_selectedJob.SearchRegion.X + x, m_selectedJob.SearchRegion.Y + y,w, h, t * Math.PI / 180, 0);//* Math.PI / 180,0
                                                                //cogSearchRegion.SetCenterLengthsRotationSkew(m_selectedJob.SearchRegion.X + w / 2 + x, m_selectedJob.SearchRegion.Y + h / 2 + y, w, h, t * Math.PI / 180, 0);//* Math.PI / 180,0

                                                                if (m_selectedJob.Parameter.EyeD_ImageRotateAngle == 0 || m_selectedJob.Parameter.EyeD_ImageRotateAngle == 180)
                                                                {
                                                                    cogSearchRegion.X = m_selectedJob.SearchRegion.X + x;
                                                                    cogSearchRegion.Y = m_selectedJob.SearchRegion.Y + y;
                                                                    cogSearchRegion.Width = w;
                                                                    cogSearchRegion.Height = h;
                                                                }
                                                                else if (m_selectedJob.Parameter.EyeD_ImageRotateAngle == 90 || m_selectedJob.Parameter.EyeD_ImageRotateAngle == 270)
                                                                {
                                                                    cogSearchRegion.X = m_selectedJob.SearchRegion.X + y;
                                                                    cogSearchRegion.Y = m_selectedJob.SearchRegion.Y + x;
                                                                    cogSearchRegion.Width = h;
                                                                    cogSearchRegion.Height = w;
                                                                }

                                                                cogSearchRegion.LineWidthInScreenPixels = 2;


                                                                if (m_selectedJob.Parameter.EyeD_MinScore <= score)
                                                                {
                                                                    cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Green;
                                                                    CCognexUtil.DrawString(DispMain, $"Model : {tag} Score : {score}", new Point2d(cogSearchRegion.X + x, cogSearchRegion.Y + y - 10), CogColorConstants.Green, 10);
                                                                }
                                                                else
                                                                {
                                                                    cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                                                                    CCognexUtil.DrawString(DispMain, $"Model : {tag} Score : {score}", new Point2d(cogSearchRegion.X + x, cogSearchRegion.Y + y - 10), CogColorConstants.Red, 10);
                                                                }

                                                                DispMain.InteractiveGraphics.Add(cogSearchRegion, "", false);
                                                            }
                                                        }
                                                    }

                                                }

                                                if (string.Equals(resultInferType, "(CLS)"))
                                                {
                                                    Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();

                                                    cogSearchRegion.LineWidthInScreenPixels = 2;
                                                    cogSearchRegion.X = m_selectedJob.SearchRegion.X;
                                                    cogSearchRegion.Y = m_selectedJob.SearchRegion.Y;
                                                    cogSearchRegion.Width = m_selectedJob.SearchRegion.Width;
                                                    cogSearchRegion.Height = m_selectedJob.SearchRegion.Height;
                                                    if (m_selectedJob.Parameter.EyeD_MinScore <= bestScore && m_selectedJob.Parameter.EyeD_CorrectAnswer == bestTag)
                                                    {
                                                        cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Green;
                                                        CCognexUtil.DrawString(DispMain, $"Model : {m_selectedJob.Parameter.EyeD_ModelName}/{bestTag} Score : {bestScore}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Green, 10);
                                                    }
                                                    else
                                                    {
                                                        cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                                                        CCognexUtil.DrawString(DispMain, $"Model : {m_selectedJob.Parameter.EyeD_ModelName}/{bestTag} Score : {bestScore}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Red, 10);
                                                    }

                                                    DispMain.InteractiveGraphics.Add(cogSearchRegion, "", false);
                                                }

                                            }


                                            IF_Util.setLabel(lblEyeDResult, Global.Device.EyeD.RecvResults[uniqueID].ResultString, lblEyeDResult.BackColor);

                                            Global.Device.EyeD.RecvResults.TryRemove(uniqueID, out EyeD_Result result);
                                            break;
                                        }

                                        Thread.Sleep(10);
                                    }
                                }

                            });

                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
                (sender as UIButton).Text = "Roi";
            }
        }
        private void OnClickAlgorithm_ColorEx(object sender, EventArgs e)
        {
            try
            {
                string strIndex = (sender as UIButton).Text;

                switch (strIndex)
                {
                    case "ROI":
                    case "Roi":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            if (m_selectedJob.SearchRegion.Width == 0 || m_selectedJob.SearchRegion.Height == 0)
                            {
                                m_selectedJob.SearchRegion = new Rectangle(0, 0, 100, 100);
                            }
                            //검사 영역
                            Cognex.VisionPro.CogRectangle cogSearchRegion = CConverter.RectToCogRect(m_selectedJob.SearchRegion);
                            cogSearchRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.DragColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.LineWidthInScreenPixels = 2;
                            if (cogSearchRegion.Width == 0) cogSearchRegion.Width = 250;
                            if (cogSearchRegion.Height == 0) cogSearchRegion.Height = 250;

                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogSearchRegion, "Search", false);
                            (sender as UIButton).Text = "Complete";
                        }
                        break;
                    case "Complete":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                            CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            m_selectedJob.SearchRegion = CConverter.CogRectToRect(roi);
                            (sender as UIButton).Text = "Roi";
                        }
                        break;
                    case "RUN":
                    case "INSP":
                    case "Find":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            Stopwatch tt = Stopwatch.StartNew();

                            using (Mat imgCrop = OpenCvSharp.Extensions.BitmapConverter.ToMat(IF_Util.Crop(m_imgSource_Color.ToBitmap(), m_selectedJob.SearchRegion)).Clone())
                            {

                            }

                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
                (sender as UIButton).Text = "Roi";
            }
        }
        private void btnInspect_Click(object sender, EventArgs e)
        {
            // 프로그레스 동작
            Global.Instance.OnStart_Porgess();
            Global.Notice = "Inspect Manual";

            Task.Run(() =>
            {
                (bool totalResult, bool qrResult, List<bool> results) results = CVisionTools.MainInsp(new Stopwatch(), 2, Global.ImagesGrab, out Global.ImageResults_array, false, !chb_Manual_InspecSave.Checked, chkImageSaveAndOpen.Checked);

                // 결과값 드로우..처리..
                if (Global.ImageResults_array[0] != null)
                {
                    DispMain.StaticGraphics.Clear();
                    DispMain.InteractiveGraphics.Clear();

                    // 첫번째 이미지에 비트맵 이미지로 결과 표시처리 해줌...
                    DispMain.Image = new CogImage24PlanarColor(Global.ImageResults_array[0]);
                }

                if (results.results.Count == 0)
                {
                    // 프로그레스 동작 종료
                    Global.Instance.OnEnd_Progress();
                    return;
                }

                // 여기 임시로 처리
                //if (Global.Mode.isSimulRMS)
                //{
                    Global.RMS_PostProcessing();
                //}

                // 프로그레스 동작 종료
                Global.Instance.OnEnd_Progress();

                OnClickSelectResult(lbSelectResult1, new EventArgs());
            });
        }

        public string GetOnnxPath(string str_JobPartName)
        {
            string onnxPath = $"{Global.m_MainPJTRoot}\\Onnx\\";
            string partsName = "";

            if (Directory.Exists(onnxPath) == false) Directory.CreateDirectory(onnxPath);
            if (str_JobPartName == "condenser" || str_JobPartName == "fuse" || str_JobPartName == "barista" || str_JobPartName == "via" || str_JobPartName == "relay")
            {
                partsName = str_JobPartName;
            }
            else
            {
                string[] strAry_PartName = str_JobPartName.Split('_');
                strAry_PartName[0] = strAry_PartName[0].Trim();
                partsName = strAry_PartName[0];
            }

            string[] files = Directory.GetFiles(onnxPath);

            for (int i = 0; i < files.Length; i++)
            {
                string strFilePath = files[i];

                if (strFilePath.Contains(partsName))
                {
                    onnxPath = files[i];
                    break;
                }
            }

            return onnxPath;
        }

        private void OnClickJobs(object sender, EventArgs e)
        {
            try
            {
                if (!(sender is UIButton)) return;

                string strIndex = (sender as UIButton).Text;

                string strCode = txtPartCode.Text;

                switch (strIndex)
                {
                    case "Add Job":
                    case "Add":
                        AddJobs();
                        break;

                    case "Del Job":
                    case "Delete":
                        {
                            if (IF_Util.ShowMessageBox("Check", $"Do you want to delete {strCode}?"))
                            {
                                if (m_selectedJob == null) return;

                                int nIndex = -1;

                                for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                                {
                                    if (Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i].Name == strCode)
                                    {
                                        nIndex = i;
                                        break;
                                    }
                                }
                                //nIndex = gridLibrary.SelectedRows[0].Index;
                                if (nIndex != -1) Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.RemoveAt(nIndex);

                                gridLibrary.Rows.RemoveAt(nIndex);
                                InitJobs();
                                //for (int i = 0; i < gridLibrary.Rows.Count; i++)
                                //{
                                //    gridLibrary.Rows[i].Cells[0].Value = i + 1;
                                //    gridLibrary.Rows[i].Cells[1].Value = gridLibrary.Rows[i].Cells[1].Value;
                                //    gridLibrary.Rows[i].Cells[2].Value = gridLibrary.Rows[i].Cells[2].Value;
                                //    gridLibrary.Rows[i].Cells[3].Value = gridLibrary.Rows[i].Cells[3].Value;
                                //    gridLibrary.Rows[i].Cells[4].Value = gridLibrary.Rows[i].Cells[4].Value;
                                //    gridLibrary.Rows[i].Cells[5].Value = gridLibrary.Rows[i].Cells[5].Value;
                                //    gridLibrary.Rows[i].Cells[6].Value = gridLibrary.Rows[i].Cells[6].Value;
                                //    gridLibrary.Rows[i].Cells[7].Value = gridLibrary.Rows[i].Cells[7].Value;
                                //}
                            }
                        }
                        break;

                    case "Edit Job":
                    case "Edit":
                    case "Apply":
                        {
                            if (m_selectedJob == null)
                                return;

                            bool bol_ChkName = false;

                            for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                            {
                                if (Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i].Name == txtPartCode.Text && txtPartCode.Text != m_selectedJob.Name)
                                {
                                    bol_ChkName = true;
                                    break;
                                }
                            }

                            if (bol_ChkName)
                            {
                                MessageBox.Show($"{txtPartCode.Text} - 똑같은 Name을 가진 Job이 존재합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }


                            int i_GrabIndex = cbJobGrabIndex.SelectedIndex;
                            string str_Type = comboAlgorithm.Text;
                            string str_JobCode = txtPartCode.Text;
                            int i_Sampling = (int)nbJobSamplingCount.Value;
                            bool bol_Binary = false; //chkBinary.Checked;
                            bool bol_SavePart = false;  //chkSavePart.Checked;
                            bool bol_ColorCheck = chkColor.Checked;
                            m_selectedJob.GrabIndex = i_GrabIndex;
                            m_selectedJob.Type = str_Type;
                            m_selectedJob.Name = str_JobCode;
                            m_selectedJob.SamplingCount = i_Sampling;

                            string str_ColorMethod = "-";

                            if (str_Type == "Pattern")
                            {
                                m_selectedJob.CCoordinate = (CJob.ColorCoordinate)cboPatternColorCoordinate.SelectedIndex - 1;
                                m_selectedJob.CMethod = (CJob.ColorMethod)cboPatternColorAlg.SelectedIndex - 1;
                                str_ColorMethod = $"{cboPatternColorCoordinate.SelectedItem}/{cboPatternColorAlg.SelectedItem}";
                                m_selectedJob.ChkColor = bol_ColorCheck;
                                m_selectedJob.MasterCount = int.Parse(tbPatternMasterCount.Text.ToString());
                            }
                            else if (str_Type == "Color")
                            {
                                m_selectedJob.CCoordinate = (CJob.ColorCoordinate)cboColorCoordinate.SelectedIndex - 1;
                                m_selectedJob.CMethod = (CJob.ColorMethod)cboColorAlg.SelectedIndex - 1;
                                str_ColorMethod = $"{m_selectedJob.CCoordinate}/{m_selectedJob.CMethod}";
                            }
                            else if (str_Type == "Condensor")
                            {
                                m_selectedJob.Parameter.CondensorPolarity = comboCondensorPolarity.Text;
                                m_selectedJob.Parameter.CondensorTypeTB = radioCondensorTB.Checked;
                                m_selectedJob.Parameter.CondensorRectWidth = int.Parse(tbCircleRectW.Text);
                                m_selectedJob.Parameter.CondensorRectHeight = int.Parse(tbCircleRectH.Text);
                                m_selectedJob.Find_Circle.RunParams.CaliperRunParams.ContrastThreshold = int.Parse(tbCircleContrast.Text);
                                m_selectedJob.Find_Circle.RunParams.CaliperRunParams.FilterHalfSizeInPixels = int.Parse(tbCircleThickness.Text);
                                m_selectedJob.Parameter.CondensorRadiusOffset = int.Parse(tbCondensorRectRadio.Text);
                            }
                            else if (str_Type == "Distance")
                            {
                                m_selectedJob.Find_Line.RunParams.CaliperRunParams.ContrastThreshold = int.Parse(tbLineEdgeContrast.Text.ToString());
                                m_selectedJob.Find_Line.RunParams.CaliperRunParams.FilterHalfSizeInPixels = (int)numericDistanceThickness.Value;
                                m_selectedJob.Find_Line.RunParams.NumCalipers = (int)numericDistanceSamplingCount.Value;

                                if (comboLineEdgePolarity.Text == "Dark → Light") m_selectedJob.Find_Line.RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight;
                                else m_selectedJob.Find_Line.RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;

                                m_selectedJob.Find_Line.RunParams.CaliperRunParams.SingleEdgeScorers.Clear();
                                if (comboLineEdgeScorer.Text == "Contrast")
                                {
                                    CogCaliperScorerContrast scorer = new CogCaliperScorerContrast();
                                    scorer.Enabled = true;
                                    m_selectedJob.Find_Line.RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
                                }
                                else if (comboLineEdgeScorer.Text == "Position (From End)")
                                {
                                    CogCaliperScorerPosition scorer = new CogCaliperScorerPosition();
                                    scorer.Enabled = true;
                                    m_selectedJob.Find_Line.RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
                                }
                                else if (comboLineEdgeScorer.Text == "Position (From Begin)")
                                {
                                    CogCaliperScorerPositionNeg scorer = new CogCaliperScorerPositionNeg();
                                    scorer.Enabled = true;
                                    m_selectedJob.Find_Line.RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
                                }

                                m_selectedJob.Parameter.DistanceAngleMax = double.Parse(string.IsNullOrEmpty(tbAngleMaxValue.Text.ToString()) ? "0" : tbAngleMaxValue.Text.ToString());
                                m_selectedJob.Parameter.DistanceAngleMin = double.Parse(string.IsNullOrEmpty(tbAngleMinValue.Text.ToString()) ? "0" : tbAngleMinValue.Text.ToString());
                                m_selectedJob.Parameter.DistanceXMax = double.Parse(string.IsNullOrEmpty(tbXMaxValue.Text.ToString()) ? "0" : tbXMaxValue.Text.ToString());
                                m_selectedJob.Parameter.DistanceYMax = double.Parse(string.IsNullOrEmpty(tbYMaxValue.Text.ToString()) ? "0" : tbYMaxValue.Text.ToString());
                                m_selectedJob.Parameter.DistanceXMin = double.Parse(string.IsNullOrEmpty(tbXMaxValue.Text.ToString()) ? "0" : tbXMinValue.Text.ToString());
                                m_selectedJob.Parameter.DistanceYMin = double.Parse(string.IsNullOrEmpty(tbYMaxValue.Text.ToString()) ? "0" : tbYMinValue.Text.ToString());
                                m_selectedJob.Parameter.UseDistanceAngle = cbAngle.Checked;
                                m_selectedJob.Parameter.UseDistanceX = cbXValue.Checked;
                                m_selectedJob.Parameter.UseDistanceY = cbYValue.Checked;
                            }

                            m_selectedJob.useBinary = bol_Binary;
                            m_selectedJob.isSavePart = bol_SavePart;

                            m_selectedJob.Judge_NaisNg = chkJobPattern_JudgeMode.Checked;

                            string str_Mode = "";
                            if (chkJobPattern_JudgeMode.Checked)
                                str_Mode = $"N/A:NG";
                            else
                                str_Mode = $"N/A:OK";

                            //m_selectedJob.LC_ReadUse = cb_LCReadUse.Checked;
                            bool lcReaduse = m_selectedJob.LC_ReadUse;
                            int lcMasterCount = m_selectedJob.MasterCount;

                            gridLibrary.Rows[m_nSelectedIndex_Library].Cells[0].Value = m_nSelectedIndex_Library + 1;
                            gridLibrary.Rows[m_nSelectedIndex_Library].Cells[1].Value = gridLibrary.Rows[m_nSelectedIndex_Library].Cells[1].Value; //Enabled
                            gridLibrary.Rows[m_nSelectedIndex_Library].Cells[2].Value = str_JobCode;                                               //Name
                            gridLibrary.Rows[m_nSelectedIndex_Library].Cells[3].Value = i_GrabIndex;                                               //GrabIndex
                            gridLibrary.Rows[m_nSelectedIndex_Library].Cells[4].Value = str_Type;                                                  //Type
                            gridLibrary.Rows[m_nSelectedIndex_Library].Cells[5].Value = str_Mode;                                                  //Mode
                            gridLibrary.Rows[m_nSelectedIndex_Library].Cells[7].Value = str_ColorMethod;                                            //ColorMethod

                            //송현수 -> 안춘길 : 정합성 체크 필요
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Enabled = bool.Parse(gridLibrary.Rows[m_nSelectedIndex_Library].Cells[1].Value.ToString());
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Name = str_JobCode;
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].GrabIndex = i_GrabIndex;
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Type = str_Type;
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Judge_NaisNg = chkJobPattern_JudgeMode.Checked;
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].ChkColor = bol_ColorCheck;
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].CCoordinate = (CJob.ColorCoordinate)cboPatternColorCoordinate.SelectedIndex - 1;
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].CMethod = (CJob.ColorMethod)cboPatternColorAlg.SelectedIndex - 1;
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].useBinary = bol_Binary;
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].isSavePart = bol_SavePart;
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].LC_ReadUse = lcReaduse;
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].MasterCount = lcMasterCount;

                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.UseFilter1 = chkUseFilter1.Checked;
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.UseFilter2 = chkUseFilter2.Checked;
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.Filter1 = (CVisionTools.CV_FILTER)comboFilter1Type.SelectedIndex;
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.Filter1_Kernel_W = int.Parse(txtFilter1_KernelW.Text);
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.Filter1_Kernel_H = int.Parse(txtFilter1_KernelH.Text);
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.Filter2 = (CVisionTools.CV_FILTER)comboFilter2Type.SelectedIndex;
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.Filter2_Kernel_W = int.Parse(txtFilter2_KernelW.Text);
                            Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.Filter2_Kernel_H = int.Parse(txtFilter2_KernelH.Text);
                        }
                        break;
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public void DisplayTrainCount()
        {
            // Train 숫자를 표시한다.
            int nTrain = 0;
            if (m_selectedJob.Tool.Tool.Pattern.Trained)
                nTrain++;
            if (m_selectedJob.SubTool1.Tool.Pattern.Trained)
                nTrain++;
            if (m_selectedJob.SubTool2.Tool.Pattern.Trained)
                nTrain++;
            if (m_selectedJob.SubTool3.Tool.Pattern.Trained)
                nTrain++;
            if (m_selectedJob.SubTool4.Tool.Pattern.Trained)
                nTrain++;
            label137.Text = $"({nTrain:D2}/05)";
        }

        public int GetJobCount(CJob job)
        {
            try
            {
                // Train 숫자를 표시한다.
                int nTrain = 0;
                if (job.Tool.Tool.Pattern.Trained)
                    nTrain++;
                if (job.SubTool1.Tool.Pattern.Trained)
                    nTrain++;
                if (job.SubTool2.Tool.Pattern.Trained)
                    nTrain++;
                if (job.SubTool3.Tool.Pattern.Trained)
                    nTrain++;
                if (job.SubTool4.Tool.Pattern.Trained)
                    nTrain++;

                return nTrain;
            }
            catch
            {
                return 0;
            }

        }

        public void InvalidateColorRects()
        {
            if (m_selectedJob.SearchRegion != null)
            {
                if (m_selectedJob.SearchRegion.Width == 0)
                {
                    m_selectedJob.SearchRegion = new Rectangle(0, 0, 100, 100);
                }

                Roi_ColorSearchRegion.X = m_selectedJob.SearchRegion.X;
                Roi_ColorSearchRegion.Y = m_selectedJob.SearchRegion.Y;
                Roi_ColorSearchRegion.Width = m_selectedJob.SearchRegion.Width;
                Roi_ColorSearchRegion.Height = m_selectedJob.SearchRegion.Height;
            }

            if (m_selectedJob.valueRect != null)
            {
                if (m_selectedJob.valueRect.Width == 0)
                {
                    m_selectedJob.valueRect = new Rectangle(0, 0, 100, 100);
                }

                Roi_ColorVAlues.X = m_selectedJob.valueRect.X;
                Roi_ColorVAlues.Y = m_selectedJob.valueRect.Y;
                Roi_ColorVAlues.Width = m_selectedJob.valueRect.Width;
                Roi_ColorVAlues.Height = m_selectedJob.valueRect.Height;
            }

            if (m_imgSource_Color.Allocated == true)
            {
                Mat inImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Color.ToBitmap()).Clone();

                if (Roi_ColorSearchRegion.Y + Roi_ColorSearchRegion.Height > inImg.Height)
                {
                    Roi_ColorSearchRegion.Height = inImg.Height - Roi_ColorSearchRegion.Y;
                }

                if (Roi_ColorSearchRegion.X + Roi_ColorSearchRegion.Width > inImg.Width)
                {
                    Roi_ColorSearchRegion.Width = inImg.Width - Roi_ColorSearchRegion.X;
                }

                if (Roi_ColorVAlues.Y + Roi_ColorVAlues.Height > inImg.Height)
                {
                    Roi_ColorVAlues.Height = inImg.Height - Roi_ColorVAlues.Y;
                }

                if (Roi_ColorVAlues.X + Roi_ColorVAlues.Width > inImg.Width)
                {
                    Roi_ColorVAlues.Width = inImg.Width - Roi_ColorVAlues.X;
                }
            }
        }

        private void btnViewJobs_Click(object sender, EventArgs e)
        {
            if (m_imgSource_Color == null || m_imgSource_Color.Width == 0 || m_imgSource_Color.Height == 0)
            {
                MessageBox.Show("Have no Orignal Image");
                return;
            }
            using (Bitmap imgResult = m_imgSource_Color.ToBitmap())
            using (Graphics g = Graphics.FromImage(imgResult))
            using (Pen penSearchRegion = new Pen(Color.Yellow, 10))
            using (Pen penSearchRegion2 = new Pen(Color.Orange, 10))
            using (Pen penPatternRegion_OK = new Pen(Color.Lime, 3))
            using (Pen penPatternRegion_NG = new Pen(Color.Red, 3))
            using (SolidBrush brush_OK = new SolidBrush(Color.Lime))
            using (SolidBrush brush_NG = new SolidBrush(Color.Red))
            using (SolidBrush brush_READY = new SolidBrush(Color.Blue))
            using (Font font = new Font("Arial", 36, FontStyle.Bold))
            {
                for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                {
                    CJob job = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i];
                    CCogTool_PMAlign PMAlign = job.Tool;

                    if (job.Enabled)
                    {
                        if (job.Type.Contains("Color"))
                        {
                            g.DrawString($"{job.Name}", font, brush_OK, job.SearchRegion.Location);
                            g.DrawRectangle(penSearchRegion, job.SearchRegion);
                        }
                        else if (job.Type.Contains("Condensor") || job.Type.Contains("Blob") || job.Type.Contains("Distance") || job.Type.Contains("Pin"))
                        {
                            g.DrawString($"{job.Name}", font, brush_OK, job.SearchRegion.Location);
                            g.DrawRectangle(penSearchRegion, job.SearchRegion);
                        }
                        else if (job.Type.Contains("EYE-D"))
                        {
                            g.DrawString($"{job.Name}", font, brush_OK, job.SearchRegion.Location);
                            g.DrawRectangle(penSearchRegion, job.SearchRegion);
                        }
                        else
                        {
                            g.DrawString($"{job.Name}", font, brush_OK, CVisionCognex.CogRectToRectangle((Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion).Location);
                            g.DrawRectangle(penSearchRegion, CVisionCognex.CogRectToRectangle((Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion));
                        }
                    }
                    else
                    {
                        if (job.Type.Contains("Color"))
                        {
                            g.DrawString($"{job.Name}", font, brush_OK, job.SearchRegion.Location);
                            g.DrawRectangle(penSearchRegion2, job.SearchRegion);
                        }
                        else if (job.Type.Contains("Condensor") || job.Type.Contains("Blob") || job.Type.Contains("Distance") || job.Type.Contains("Pin"))
                        {
                            g.DrawString($"{job.Name}", font, brush_OK, job.SearchRegion.Location);
                            g.DrawRectangle(penSearchRegion2, job.SearchRegion);
                        }
                        else if (job.Type.Contains("EYE-D"))
                        {
                            g.DrawString($"{job.Name}", font, brush_OK, job.SearchRegion.Location);
                            g.DrawRectangle(penSearchRegion2, job.SearchRegion);
                        }
                        else
                        {
                            g.DrawString($"{job.Name}", font, brush_OK, CVisionCognex.CogRectToRectangle((Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion).Location);
                            g.DrawRectangle(penSearchRegion2, CVisionCognex.CogRectToRectangle((Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion));
                        }
                    }
                }

                DispMain.Image = new Cognex.VisionPro.CogImage24PlanarColor(imgResult);
            }
        }

        private void cogDisplay_Source_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (m_selectedJob == null)
                    return;

                cogDisplay_JobPattern.InteractiveGraphics.Clear();
                cogDisplay_JobPattern.StaticGraphics.Clear();
                CCogTool_PMAlign PMAlign = null;
                if (comboJobPattern_PatternType.Text == "" || comboJobPattern_PatternType.Text == "Main")
                {
                    PMAlign = m_selectedJob.Tool;
                }
                else
                {
                    if (comboJobPattern_PatternType.Text == "Sub1") PMAlign = m_selectedJob.SubTool1;
                    if (comboJobPattern_PatternType.Text == "Sub2") PMAlign = m_selectedJob.SubTool2;
                    if (comboJobPattern_PatternType.Text == "Sub3") PMAlign = m_selectedJob.SubTool3;
                    if (comboJobPattern_PatternType.Text == "Sub4") PMAlign = m_selectedJob.SubTool4;
                }

                if (PMAlign.Tool.Pattern.Trained)
                {
                    cogDisplay_JobPattern.Image = PMAlign.Tool.Pattern.GetTrainedPatternImage();
                    CVisionCognex.TrainGraphic(PMAlign.Tool, cogDisplay_JobPattern);
                }
                else
                    cogDisplay_JobPattern.Fit(true);
                DisplayTrainCount();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
            }
        }

        private ContextMenuStrip m_menuT = new ContextMenuStrip();
        private List<Tuple<ToolStripMenuItem, int>> m_menus = new List<Tuple<ToolStripMenuItem, int>>();
        private void cogDisplay_Source_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                DispMain.StaticGraphics.Clear();

                Cognex.VisionPro.CogTransform2DLinear xForm;
                xForm = DispMain.GetTransform("*\\#", "*") as Cognex.VisionPro.CogTransform2DLinear;
                xForm.MapPoint(e.X, e.Y, out double dPosX, out double dPosY);

                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    //2024.03.15 송현수 -> 안춘길 : Control Click 시 m_selectedArrayIndex -1 버그 수정
                    //2024.03.15 송현수 -> 안춘길 : Job Type 별로 비교
                    for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                    {
                        CJob job = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i];
                        bool isContain = false;

                        if (job.Type == "Pattern")
                        {
                            if (job.Tool.Tool.SearchRegion != null) isContain |= CConverter.CogRectToRect((CogRectangle)job.Tool.Tool.SearchRegion).Contains((int)dPosX, (int)dPosY);
                            if (job.SubTool1.Tool.SearchRegion != null) isContain |= CConverter.CogRectToRect((CogRectangle)job.SubTool1.Tool.SearchRegion).Contains((int)dPosX, (int)dPosY);
                            if (job.SubTool2.Tool.SearchRegion != null) isContain |= CConverter.CogRectToRect((CogRectangle)job.SubTool2.Tool.SearchRegion).Contains((int)dPosX, (int)dPosY);
                            if (job.SubTool3.Tool.SearchRegion != null) isContain |= CConverter.CogRectToRect((CogRectangle)job.SubTool3.Tool.SearchRegion).Contains((int)dPosX, (int)dPosY);
                            if (job.SubTool4.Tool.SearchRegion != null) isContain |= CConverter.CogRectToRect((CogRectangle)job.SubTool4.Tool.SearchRegion).Contains((int)dPosX, (int)dPosY);
                        }

                        else
                        {
                            isContain = job.SearchRegion.Contains((int)dPosX, (int)dPosY);
                        }


                        CCogTool_PMAlign PMAlign = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i].Tool;

                        if (isContain)
                        {
                            //Cognex.VisionPro.CogGraphicLabel label = new Cognex.VisionPro.CogGraphicLabel();

                            //label.Text = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i].Name;
                            //label.X = CVisionCognex.CogRectToRectangle((Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion).X;
                            //label.Y = CVisionCognex.CogRectToRectangle((Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion).Y;
                            //label.Color = Cognex.VisionPro.CogColorConstants.Blue;
                            //label.LineWidthInScreenPixels = 3;

                            //Cognex.VisionPro.CogRectangle rtRoi = CVisionCognex.RectangleToCogRect(Global.System.Recipe.JobManager[m_nSelectedArrayIndex-1].Jobs[i].SearchRegion);
                            //rtRoi.LineWidthInScreenPixels = 5;
                            //rtRoi.Color = Cognex.VisionPro.CogColorConstants.Green;
                            //rtRoi.SelectedColor = Cognex.VisionPro.CogColorConstants.Green;

                            //cogDisplay_Source.StaticGraphics.Add((Cognex.VisionPro.ICogGraphic)rtRoi, "ROI");
                            //cogDisplay_Source.StaticGraphics.Add(label, "ROI");

                            string strCode = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i].Name;

                            m_selectedJob = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i];

                            for (int rowIdx = 0; rowIdx < gridLibrary.Rows.Count; rowIdx++)
                            {
                                string name = gridLibrary[2, rowIdx].Value.ToString();

                                if (m_selectedJob.Name == name)
                                {
                                    gridLibrary.ClearSelection(); // 선택 해제
                                    gridLibrary.Rows[rowIdx].Selected = true; // 원하는 행 선택
                                    gridLibrary.FirstDisplayedScrollingRowIndex = rowIdx;

                                    break;
                                }
                            }

                            break;
                        }
                    }



                    // 여기 여러개 선택 시 처리
                    int nFindCnt = 0;
                    m_menuT.Items.Clear();
                    m_menus.Clear();
                    for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                    {
                        if (Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i].SearchRegion.Contains((int)dPosX, (int)dPosY))
                        {
                            nFindCnt++;
                            m_menus.Add(new Tuple<ToolStripMenuItem, int>(new ToolStripMenuItem(Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i].Name), i));
                            int nPos = m_menus.Count - 1;

                            m_menuT.Items.Add(m_menus[nPos].Item1.Text);
                        }
                    }
                    //if (m_menuT.Items.Count == 1)
                    //    SelectJob(m_menus[0].Item2);
                    //else if (m_menuT.Items.Count > 1)
                    //{
                    //    System.Drawing.Point mousePoint = new System.Drawing.Point(e.X, e.Y); //마우스가 클릭된 위치
                    //    m_menuT.Show(this, mousePoint);//마우스 클릭된 위치에 스트립 메뉴를 보여준다
                    //}
                }

                if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
                {
                    if (m_selectedJob.Type.Contains("Pattern"))
                    {
                        //2024.03.15 송현수->안춘길 : TrainRegion 의 자료형이 다를 경우가 있는 것 같습니다.
                        if (m_selectedJob.Tool.Tool.Pattern.TrainRegion is CogRectangleAffine) m_selectedJob.Tool.Tool.Pattern.TrainRegion = new CogRectangle();
                        if (m_selectedJob.SubTool1.Tool.Pattern.TrainRegion is CogRectangleAffine) m_selectedJob.SubTool1.Tool.Pattern.TrainRegion = new CogRectangle();
                        if (m_selectedJob.SubTool2.Tool.Pattern.TrainRegion is CogRectangleAffine) m_selectedJob.SubTool2.Tool.Pattern.TrainRegion = new CogRectangle();
                        if (m_selectedJob.SubTool3.Tool.Pattern.TrainRegion is CogRectangleAffine) m_selectedJob.SubTool3.Tool.Pattern.TrainRegion = new CogRectangle();
                        if (m_selectedJob.SubTool4.Tool.Pattern.TrainRegion is CogRectangleAffine) m_selectedJob.SubTool4.Tool.Pattern.TrainRegion = new CogRectangle();

                        if (comboJobPattern_PatternType.Text == "Main")
                        {
                            if (m_selectedJob.Tool.Tool.SearchRegion == null)
                            {
                                m_selectedJob.Tool.Tool.SearchRegion = new Cognex.VisionPro.CogRectangle();
                            }
                            (m_selectedJob.Tool.Tool.SearchRegion as Cognex.VisionPro.CogRectangle).X = dPosX;
                            (m_selectedJob.Tool.Tool.SearchRegion as Cognex.VisionPro.CogRectangle).Y = dPosY;

                            (m_selectedJob.Tool.Tool.SearchRegion as Cognex.VisionPro.CogRectangle).Width = 200;
                            (m_selectedJob.Tool.Tool.SearchRegion as Cognex.VisionPro.CogRectangle).Height = 200;

                            if (m_selectedJob.Tool.Tool.Pattern.TrainRegion == null)
                            {
                                m_selectedJob.Tool.Tool.Pattern.TrainRegion = new Cognex.VisionPro.CogRectangle();
                                (m_selectedJob.Tool.Tool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).Width = 200;
                                (m_selectedJob.Tool.Tool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).Height = 200;
                            }


                            (m_selectedJob.Tool.Tool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).X = dPosX + 10;
                            (m_selectedJob.Tool.Tool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).Y = dPosY + 10;
                        }

                        OnClickAlgorithm_Pattern(btnJobPattern_Roi, null);
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }

        public void OnInspEnd(object sender, EventArgs e)
        {
            try
            {
                //if (Global.Device.Cameras[0].GrabBuffer[0] != null)
                //{
                //    for (int i = 0; i < Global.ImageResults_array.Length; i++)
                //    {
                //        if (Global.Instance.Device.Cameras[DEFINE.CAM1].GrabBuffer[i] != null)
                //        {
                //            _imagesGrab[i] = new Cognex.VisionPro.CogImage24PlanarColor((Bitmap)Global.Instance.Device.Cameras[DEFINE.CAM1].GrabBuffer[i].Clone());

                //            string GRAB_str_ImageName = $"CDImage{i + 1}";

                //            Control GRAB_foundControl = Controls.Find(GRAB_str_ImageName, true).FirstOrDefault();

                //            if (GRAB_foundControl is CogDisplay GRAB_CD)
                //            {
                //                if (GRAB_CD.InvokeRequired)
                //                {
                //                    GRAB_CD.Invoke((MethodInvoker)delegate
                //                    {
                //                        GRAB_CD.Image = _imagesGrab[i];
                //                    });
                //                }
                //                else
                //                {
                //                    GRAB_CD.Image = _imagesGrab[i];
                //                }
                //            }
                //        }
                //    }
                //}


                if (_bResult_Action == true)
                {
                    EventArgs E = new EventArgs();
                    OnClickSelectResult(lbSelectResult1, E);
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }

        public void OnGetModel(object sender, StringEventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnGetModel(sender, e);
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
                    comboEyeDModelName.Items.Clear();

                    string recvMsg = e.Message;
                    string[] models = recvMsg.Split('/');
                    comboEyeDModelName.Items.AddRange(models);
                }
                catch (Exception ex)
                {
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                    IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
                }
            }
        }

        public void Menu_Click(Object sender, EventArgs e)
        {
            if ((sender as ContextMenuStrip).Items.Count > 0)
            {
                for (int i = 0; i < (sender as ContextMenuStrip).Items.Count; i++)
                {
                    if ((sender as ContextMenuStrip).Items[i].Selected)
                    {
                        string strTest = (sender as ContextMenuStrip).Items[i].Text;
                        int index = m_menus[i].Item2;
                        SelectJob(index);
                    }
                }
            }
        }

        private void SelectJob(int nJob)
        {
            CCogTool_PMAlign PMAlign = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[nJob].Tool;

            gridLibrary.Rows[nJob].Selected = true;

            Cognex.VisionPro.CogGraphicLabel label = new Cognex.VisionPro.CogGraphicLabel();

            label.Text = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[nJob].Name;

            label.X = CVisionCognex.CogRectToRectangle((Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion).X;
            label.Y = CVisionCognex.CogRectToRectangle((Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion).Y;
            label.Color = Cognex.VisionPro.CogColorConstants.Blue;
            label.LineWidthInScreenPixels = 3;

            Cognex.VisionPro.CogRectangle rtRoi = CVisionCognex.RectangleToCogRect(Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[nJob].SearchRegion);
            rtRoi.LineWidthInScreenPixels = 5;
            rtRoi.Color = Cognex.VisionPro.CogColorConstants.Green;
            rtRoi.SelectedColor = Cognex.VisionPro.CogColorConstants.Green;

            DispMain.StaticGraphics.Add((Cognex.VisionPro.ICogGraphic)rtRoi, "ROI");
            DispMain.StaticGraphics.Add(label, "ROI");

            //string strCode = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[nJob].Name;
            SelectGridJobs();
        }

        private void OnClickAlgorithm_Color(object sender, EventArgs e)
        {
            string strIndex = (sender as Button).Text;

            string strCode = txtPartCode.Text;

            DispMain.InteractiveGraphics.Clear();
            DispMain.StaticGraphics.Clear();

            InvalidateColorRects();
            UpdateColorUI(lbExtractedColor, lbExtractedColor2, trbThreshold_Color, lbThreshold_Color);

            switch (strIndex)
            {
                case "ROI":
                    {
                        DispMain.InteractiveGraphics.Clear();
                        DispMain.StaticGraphics.Clear();

                        if (Roi_ColorSearchRegion.Width == 0) Roi_ColorSearchRegion.Width = 100;
                        if (Roi_ColorSearchRegion.Height == 0) Roi_ColorSearchRegion.Height = 100;

                        if (Roi_ColorVAlues.Width == 0) Roi_ColorVAlues.Width = 100;
                        if (Roi_ColorVAlues.Height == 0) Roi_ColorVAlues.Height = 100;

                        Roi_ColorSearchRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                        Roi_ColorSearchRegion.Interactive = true;
                        Roi_ColorSearchRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Red;
                        Roi_ColorSearchRegion.DragColor = Cognex.VisionPro.CogColorConstants.Red;
                        Roi_ColorSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                        DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)Roi_ColorSearchRegion, "Search", false);

                        Roi_ColorVAlues.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                        Roi_ColorVAlues.Interactive = true;
                        if (m_selectedJob.CCoordinate == CJob.ColorCoordinate.CC_GRAY && m_selectedJob.CMethod == CJob.ColorMethod.CA_THRESHILD)
                        {
                            Roi_ColorVAlues.SelectedColor = Cognex.VisionPro.CogColorConstants.Blue;
                            Roi_ColorVAlues.DragColor = Cognex.VisionPro.CogColorConstants.Blue;
                            Roi_ColorVAlues.Color = Cognex.VisionPro.CogColorConstants.Blue;
                        }
                        else
                        {
                            Roi_ColorVAlues.SelectedColor = Cognex.VisionPro.CogColorConstants.Yellow;
                            Roi_ColorVAlues.DragColor = Cognex.VisionPro.CogColorConstants.Yellow;
                            Roi_ColorVAlues.Color = Cognex.VisionPro.CogColorConstants.Yellow;
                        }

                        DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)Roi_ColorVAlues, "Values", false);
                    }
                    break;
            }
        }

        public void Inspection_Circle(out Point2d centerOfCircle, CogImage8Grey img = null, string resultDir = "B")
        {
            centerOfCircle = new Point2d();
            string ResultTime;

            Stopwatch tactTime = new Stopwatch();
            tactTime.Start();

            if (img == null) m_selectedJob.Find_Circle.InputImage = m_imgSource_Mono;
            else m_selectedJob.Find_Circle.InputImage = img;

            m_selectedJob.Find_Circle.Run();

            DispMain.InteractiveGraphics.Clear();
            DispMain.StaticGraphics.Clear();

            try
            {
                if (m_selectedJob.Find_Circle.Results == null || m_selectedJob.Find_Circle.Results.NumPointsFound < m_selectedJob.MinFoundCount)
                {
                    ResultTime = $"Result : N/A TactTime : {tactTime.ElapsedMilliseconds}ms";
                    CCognexUtil.DrawText(DispMain, new Point2d(100, 100), ResultTime, CogColorConstants.Red);
                }
                else if (m_selectedJob.Find_Circle.Results != null && m_selectedJob.Find_Circle.Results.Count > 0)
                {
                    //for (int i = 0; i < job.Find_Circle.Results.Count; i++)
                    //{
                    //    //cogDisplay_Camera.StaticGraphics.Add(_tool.Results[i].CreateResultGraphics(CogFindCircleResultGraphicConstants.All), "RESULT");
                    //}

                    CogCircle resultGraphic = m_selectedJob.Find_Circle.Results.GetCircle();

                    if (resultGraphic != null)
                    {
                        DispMain.StaticGraphics.Add(resultGraphic, "resultGraphic");

                        centerOfCircle.X = resultGraphic.CenterX;
                        centerOfCircle.Y = resultGraphic.CenterY;

                        Rectangle boundingBox = IF_Util.BondingBox_Circle((int)resultGraphic.CenterX, (int)resultGraphic.CenterY, (int)resultGraphic.Radius, 50);

                        int offsetSize = boundingBox.Width / 2;
                        int offsetWidth = m_selectedJob.Parameter.CondensorRectWidth;
                        int offsetHeight = m_selectedJob.Parameter.CondensorRectHeight;

                        using (Mat imgOrg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Mono.ToBitmap()).Clone())
                        {
                            IF_Util.SetImageChannel1(imgOrg);

                            CogRectangle Find_rect = new CogRectangle();
                            string str_value = "";
                            string str_Group = "";
                            double posX = 0;
                            double posY = 0;

                            // top to bottom
                            if (m_selectedJob.Parameter.CondensorTypeTB)
                            {
                                CogRectangle meanRectTop = new CogRectangle();
                                meanRectTop.SetCenterWidthHeight(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + offsetSize / 4 - m_selectedJob.Parameter.CondensorRadiusOffset, offsetWidth, offsetHeight);

                                CogRectangle meanRectBtm = new CogRectangle();
                                meanRectBtm.SetCenterWidthHeight(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + boundingBox.Height - offsetSize / 4 + m_selectedJob.Parameter.CondensorRadiusOffset, offsetWidth, offsetHeight);

                                Rect rect_top = CConverter.CogRectToCVRect(meanRectTop);
                                Rect rect_bottom = CConverter.CogRectToCVRect(meanRectBtm);

                                // roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width
                                int t_colstart = rect_top.X + rect_top.Width;
                                if (imgOrg.Width < t_colstart)
                                {
                                    IF_Util.ShowMessageBox("Error", "Not Find Top Position Rectgle!!");
                                    return;
                                }

                                int b_colstart = rect_bottom.X + rect_bottom.Width;
                                if (imgOrg.Width < b_colstart)
                                {
                                    IF_Util.ShowMessageBox("Error", "Not Find Bottom Position Rectgle!!");
                                    return;
                                }

                                using (Mat imgSubMat_T = imgOrg.SubMat(rect_top))
                                using (Mat imgSubMat_B = imgOrg.SubMat(rect_bottom))
                                {
                                    Dictionary<string, double> meanValues = new Dictionary<string, double>();
                                    meanValues.Add("T", Cv2.Mean(imgSubMat_T).Val0);
                                    meanValues.Add("B", Cv2.Mean(imgSubMat_B).Val0);

                                    string brightnestKey = "";
                                    double brightnestValue = 0;
                                    foreach (var item in meanValues)
                                    {
                                        if (brightnestValue < item.Value)
                                        {
                                            brightnestKey = item.Key;
                                            brightnestValue = item.Value;
                                        }
                                    }

                                    CCognexUtil.DrawText(DispMain, new Point2d(meanRectTop.X, meanRectTop.Y - 20), $"Brightness : {meanValues["T"].ToString("F3")}", CogColorConstants.Blue);
                                    CCognexUtil.DrawText(DispMain, new Point2d(meanRectBtm.X, meanRectBtm.Y - 20), $"Brightness : {meanValues["B"].ToString("F3")}", CogColorConstants.Blue);

                                    if (brightnestKey == "T")
                                    {
                                        posX = meanRectTop.X;
                                        posY = meanRectTop.Y - 20;
                                        Find_rect = meanRectTop;
                                        str_Group = "meanRectTop";
                                        str_value = $"Brightness : {meanValues["T"].ToString("F3")}";

                                        CCognexUtil.DrawText(DispMain, new Point2d(meanRectTop.X, meanRectTop.Y - 20), $"Brightness : {meanValues["T"].ToString("F3")}", CogColorConstants.Blue);
                                        DispMain.StaticGraphics.Add(meanRectTop, "meanRectTop");
                                    }
                                    else if (brightnestKey == "B")
                                    {
                                        posX = meanRectBtm.X;
                                        posY = meanRectBtm.Y - 20;
                                        Find_rect = meanRectBtm;
                                        str_Group = "meanRectBtm";
                                        str_value = $"Brightness : {meanValues["B"].ToString("F3")}";

                                        CCognexUtil.DrawText(DispMain, new Point2d(meanRectBtm.X, meanRectBtm.Y - 20), $"Brightness : {meanValues["B"].ToString("F3")}", CogColorConstants.Blue);
                                        DispMain.StaticGraphics.Add(meanRectBtm, "meanRectBtm");
                                    }

                                    CogColorConstants RESULT_COLOR;

                                    string nResult;
                                    // OK
                                    if (brightnestKey == resultDir)
                                    {
                                        Find_rect.Color = CogColorConstants.Green;
                                        RESULT_COLOR = CogColorConstants.Green;
                                        nResult = "OK";
                                    }
                                    // NG
                                    else
                                    {
                                        Find_rect.Color = CogColorConstants.Red;
                                        RESULT_COLOR = CogColorConstants.Red;
                                        nResult = "NG";
                                    }

                                    CCognexUtil.DrawText(DispMain, new Point2d(posX, posY), str_value, CogColorConstants.Blue);
                                    DispMain.StaticGraphics.Add(Find_rect, str_Group);

                                    ResultTime = $"Result : {nResult}, Brightness : {brightnestKey} TactTime : {tactTime.ElapsedMilliseconds}ms";
                                    CCognexUtil.DrawText(DispMain, new Point2d(posX, posY - 20), ResultTime, RESULT_COLOR);


                                }
                            }
                            else
                            {
                                CogRectangle meanRectLeft = new CogRectangle();
                                meanRectLeft.SetCenterWidthHeight(boundingBox.X + offsetSize / 4 - m_selectedJob.Parameter.CondensorRadiusOffset, boundingBox.Y + boundingBox.Height / 2, offsetWidth, offsetHeight);

                                CogRectangle meanRectRight = new CogRectangle();
                                meanRectRight.SetCenterWidthHeight(boundingBox.X + boundingBox.Width - offsetSize / 4 + m_selectedJob.Parameter.CondensorRadiusOffset, boundingBox.Y + boundingBox.Height / 2, offsetWidth, offsetHeight);

                                Rect rect_left = CConverter.CogRectToCVRect(meanRectLeft);
                                Rect rect_right = CConverter.CogRectToCVRect(meanRectRight);

                                int l_colstart = rect_left.X + rect_left.Width;
                                if (imgOrg.Width < l_colstart)
                                {
                                    IF_Util.ShowMessageBox("Error", "Not Find Left Position Rectgle!!");
                                    return;
                                }

                                int r_colstart = rect_right.X + rect_right.Width;
                                if (imgOrg.Width < r_colstart)
                                {
                                    IF_Util.ShowMessageBox("Error", "Not Find Right Position Rectgle!!");
                                    return;
                                }

                                using (Mat imgSubMat_L = imgOrg.SubMat(rect_left))
                                using (Mat imgSubMat_R = imgOrg.SubMat(rect_right))
                                {
                                    Dictionary<string, double> meanValues = new Dictionary<string, double>();
                                    meanValues.Add("L", Cv2.Mean(imgSubMat_L).Val0);
                                    meanValues.Add("R", Cv2.Mean(imgSubMat_R).Val0);

                                    string brightnestKey = "";
                                    double brightnestValue = 0;
                                    foreach (var item in meanValues)
                                    {
                                        if (brightnestValue < item.Value)
                                        {
                                            brightnestKey = item.Key;
                                            brightnestValue = item.Value;
                                        }
                                    }

                                    CCognexUtil.DrawText(DispMain, new Point2d(meanRectLeft.X, meanRectLeft.Y - 20), $"Brightness : {meanValues["L"].ToString("F3")}", CogColorConstants.Blue);
                                    CCognexUtil.DrawText(DispMain, new Point2d(meanRectRight.X, meanRectRight.Y - 20), $"Brightness : {meanValues["R"].ToString("F3")}", CogColorConstants.Blue);

                                    if (brightnestKey == "L")
                                    {
                                        posX = meanRectLeft.X;
                                        posY = meanRectLeft.Y - 20;
                                        Find_rect = meanRectLeft;
                                        str_Group = "meanRectLeft";
                                        str_value = $"Brightness : {meanValues["L"].ToString("F3")}";

                                        CCognexUtil.DrawText(DispMain, new Point2d(meanRectLeft.X, meanRectLeft.Y - 20), $"Brightness : {meanValues["L"].ToString("F3")}", CogColorConstants.Blue);
                                        DispMain.StaticGraphics.Add(meanRectLeft, "meanRectLeft");
                                    }
                                    else
                                    {
                                        posX = meanRectRight.X;
                                        posY = meanRectRight.Y - 20;
                                        Find_rect = meanRectRight;
                                        str_Group = "meanRectRight";
                                        str_value = $"Brightness : {meanValues["R"].ToString("F3")}";

                                        CCognexUtil.DrawText(DispMain, new Point2d(meanRectRight.X, meanRectRight.Y - 20), $"Brightness : {meanValues["R"].ToString("F3")}", CogColorConstants.Blue);
                                        DispMain.StaticGraphics.Add(meanRectRight, "meanRectRight");

                                    }

                                    string str_Result;
                                    CogColorConstants RESULT_COLOR;


                                    //송현수 -> 안춘길 : 정답 체크
                                    string nResult;
                                    // OK
                                    if (brightnestKey == resultDir)
                                    {
                                        Find_rect.Color = CogColorConstants.Green;
                                        RESULT_COLOR = CogColorConstants.Green;
                                        nResult = "OK";
                                    }
                                    // NG
                                    else
                                    {
                                        Find_rect.Color = CogColorConstants.Red;
                                        RESULT_COLOR = CogColorConstants.Red;
                                        nResult = "NG";
                                    }

                                    CCognexUtil.DrawText(DispMain, new Point2d(posX, posY), str_value, CogColorConstants.Blue);
                                    DispMain.StaticGraphics.Add(Find_rect, str_Group);

                                    ResultTime = $"Result : {nResult}, Brightness : {brightnestKey} TactTime : {tactTime.ElapsedMilliseconds}ms";
                                    CCognexUtil.DrawText(DispMain, new Point2d(posX, posY - 20), ResultTime, RESULT_COLOR);

                                }
                            }
                        }
                    }
                    else
                    {
                        IF_Util.ShowMessageBox("Error", "Find Circle Results Empty");
                    }
                }
                else
                {
                    IF_Util.ShowMessageBox("Error", "Find Circle Results Empty");
                }
            }
            catch
            {
                IF_Util.ShowMessageBox("Error", "Find Circle And No Rectgle Results Not Brightness Empty");
            }
        }

        public void Inspection_Circle(CogImage8Grey img = null, string resultDir = "B")
        {
            string ResultTime;

            Stopwatch tactTime = new Stopwatch();
            tactTime.Start();

            if (img == null) m_selectedJob.Find_Circle.InputImage = m_imgSource_Mono;
            else m_selectedJob.Find_Circle.InputImage = img;

            m_selectedJob.Find_Circle.Run();

            DispMain.InteractiveGraphics.Clear();
            DispMain.StaticGraphics.Clear();

            try
            {
                if (m_selectedJob.Find_Circle.Results == null || m_selectedJob.Find_Circle.Results.NumPointsFound < m_selectedJob.MinFoundCount)
                {
                    ResultTime = $"Result : N/A TactTime : {tactTime.ElapsedMilliseconds}ms";
                    CCognexUtil.DrawText(DispMain, new Point2d(100, 100), ResultTime, CogColorConstants.Red);
                }
                else if (m_selectedJob.Find_Circle.Results != null && m_selectedJob.Find_Circle.Results.Count > 0)
                {
                    for (int i = 0; i < m_selectedJob.Find_Circle.Results.Count; i++)
                    {
                        DispMain.StaticGraphics.Add(m_selectedJob.Find_Circle.Results[i].CreateResultGraphics(CogFindCircleResultGraphicConstants.All), "RESULT");
                    }

                    CogCircle resultGraphic = m_selectedJob.Find_Circle.Results.GetCircle();

                    if (resultGraphic != null)
                    {
                        DispMain.StaticGraphics.Add(resultGraphic, "resultGraphic");

                        Rectangle boundingBox = IF_Util.BondingBox_Circle((int)resultGraphic.CenterX, (int)resultGraphic.CenterY, (int)resultGraphic.Radius, 50);

                        int offsetSize = boundingBox.Width / 2;
                        int offsetWidth = m_selectedJob.Parameter.CondensorRectWidth;
                        int offsetHeight = m_selectedJob.Parameter.CondensorRectHeight;

                        using (Mat imgOrg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Mono.ToBitmap()).Clone())
                        {
                            IF_Util.SetImageChannel1(imgOrg);

                            CogRectangle Find_rect = new CogRectangle();
                            string str_value = "";
                            string str_Group = "";
                            double posX = 0;
                            double posY = 0;

                            // top to bottom
                            if (m_selectedJob.Parameter.CondensorTypeTB)
                            {
                                CogRectangle meanRectTop = new CogRectangle();
                                meanRectTop.SetCenterWidthHeight(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + offsetSize / 4 - m_selectedJob.Parameter.CondensorRadiusOffset, offsetWidth, offsetHeight);

                                CogRectangle meanRectBtm = new CogRectangle();
                                meanRectBtm.SetCenterWidthHeight(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + boundingBox.Height - offsetSize / 4 + m_selectedJob.Parameter.CondensorRadiusOffset, offsetWidth, offsetHeight);

                                Rect rect_top = CConverter.CogRectToCVRect(meanRectTop);
                                Rect rect_bottom = CConverter.CogRectToCVRect(meanRectBtm);

                                // roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width
                                int t_colstart = rect_top.X + rect_top.Width;
                                if (imgOrg.Width < t_colstart)
                                {
                                    IF_Util.ShowMessageBox("Error", "Not Find Top Position Rectgle!!");
                                    return;
                                }

                                int b_colstart = rect_bottom.X + rect_bottom.Width;
                                if (imgOrg.Width < b_colstart)
                                {
                                    IF_Util.ShowMessageBox("Error", "Not Find Bottom Position Rectgle!!");
                                    return;
                                }

                                using (Mat imgSubMat_T = imgOrg.SubMat(rect_top))
                                using (Mat imgSubMat_B = imgOrg.SubMat(rect_bottom))
                                {
                                    Dictionary<string, double> meanValues = new Dictionary<string, double>();
                                    meanValues.Add("T", Cv2.Mean(imgSubMat_T).Val0);
                                    meanValues.Add("B", Cv2.Mean(imgSubMat_B).Val0);

                                    string brightnestKey = "";
                                    double brightnestValue = 0;
                                    foreach (var item in meanValues)
                                    {
                                        if (brightnestValue < item.Value)
                                        {
                                            brightnestKey = item.Key;
                                            brightnestValue = item.Value;
                                        }
                                    }

                                    CCognexUtil.DrawText(DispMain, new Point2d(meanRectTop.X, meanRectTop.Y - 20), $"Brightness : {meanValues["T"].ToString("F3")}", CogColorConstants.Blue);
                                    CCognexUtil.DrawText(DispMain, new Point2d(meanRectBtm.X, meanRectBtm.Y - 20), $"Brightness : {meanValues["B"].ToString("F3")}", CogColorConstants.Blue);

                                    if (brightnestKey == "T")
                                    {
                                        posX = meanRectTop.X;
                                        posY = meanRectTop.Y - 20;
                                        Find_rect = meanRectTop;
                                        str_Group = "meanRectTop";
                                        str_value = $"Brightness : {meanValues["T"].ToString("F3")}";

                                        CCognexUtil.DrawText(DispMain, new Point2d(meanRectTop.X, meanRectTop.Y - 20), $"Brightness : {meanValues["T"].ToString("F3")}", CogColorConstants.Blue);
                                        DispMain.StaticGraphics.Add(meanRectTop, "meanRectTop");
                                    }
                                    else if (brightnestKey == "B")
                                    {
                                        posX = meanRectBtm.X;
                                        posY = meanRectBtm.Y - 20;
                                        Find_rect = meanRectBtm;
                                        str_Group = "meanRectBtm";
                                        str_value = $"Brightness : {meanValues["B"].ToString("F3")}";

                                        CCognexUtil.DrawText(DispMain, new Point2d(meanRectBtm.X, meanRectBtm.Y - 20), $"Brightness : {meanValues["B"].ToString("F3")}", CogColorConstants.Blue);
                                        DispMain.StaticGraphics.Add(meanRectBtm, "meanRectBtm");
                                    }

                                    CogColorConstants RESULT_COLOR;

                                    string nResult;
                                    // OK
                                    if (brightnestKey == resultDir)
                                    {
                                        Find_rect.Color = CogColorConstants.Green;
                                        RESULT_COLOR = CogColorConstants.Green;
                                        nResult = "OK";
                                    }
                                    // NG
                                    else
                                    {
                                        Find_rect.Color = CogColorConstants.Red;
                                        RESULT_COLOR = CogColorConstants.Red;
                                        nResult = "NG";
                                    }

                                    CCognexUtil.DrawText(DispMain, new Point2d(posX, posY), str_value, CogColorConstants.Blue);
                                    DispMain.StaticGraphics.Add(Find_rect, str_Group);

                                    ResultTime = $"Result : {nResult}, Brightness : {brightnestKey} TactTime : {tactTime.ElapsedMilliseconds}ms";
                                    CCognexUtil.DrawText(DispMain, new Point2d(posX, posY - 20), ResultTime, RESULT_COLOR);


                                }
                            }
                            else
                            {
                                CogRectangle meanRectLeft = new CogRectangle();
                                meanRectLeft.SetCenterWidthHeight(boundingBox.X + offsetSize / 4 - m_selectedJob.Parameter.CondensorRadiusOffset, boundingBox.Y + boundingBox.Height / 2, offsetWidth, offsetHeight);

                                CogRectangle meanRectRight = new CogRectangle();
                                meanRectRight.SetCenterWidthHeight(boundingBox.X + boundingBox.Width - offsetSize / 4 + m_selectedJob.Parameter.CondensorRadiusOffset, boundingBox.Y + boundingBox.Height / 2, offsetWidth, offsetHeight);

                                Rect rect_left = CConverter.CogRectToCVRect(meanRectLeft);
                                Rect rect_right = CConverter.CogRectToCVRect(meanRectRight);

                                int l_colstart = rect_left.X + rect_left.Width;
                                if (imgOrg.Width < l_colstart)
                                {
                                    IF_Util.ShowMessageBox("Error", "Not Find Left Position Rectgle!!");
                                    return;
                                }

                                int r_colstart = rect_right.X + rect_right.Width;
                                if (imgOrg.Width < r_colstart)
                                {
                                    IF_Util.ShowMessageBox("Error", "Not Find Right Position Rectgle!!");
                                    return;
                                }

                                using (Mat imgSubMat_L = imgOrg.SubMat(rect_left))
                                using (Mat imgSubMat_R = imgOrg.SubMat(rect_right))
                                {
                                    Dictionary<string, double> meanValues = new Dictionary<string, double>();
                                    meanValues.Add("L", Cv2.Mean(imgSubMat_L).Val0);
                                    meanValues.Add("R", Cv2.Mean(imgSubMat_R).Val0);

                                    string brightnestKey = "";
                                    double brightnestValue = 0;
                                    foreach (var item in meanValues)
                                    {
                                        if (brightnestValue < item.Value)
                                        {
                                            brightnestKey = item.Key;
                                            brightnestValue = item.Value;
                                        }
                                    }

                                    CCognexUtil.DrawText(DispMain, new Point2d(meanRectLeft.X, meanRectLeft.Y - 20), $"Brightness : {meanValues["L"].ToString("F3")}", CogColorConstants.Blue);
                                    CCognexUtil.DrawText(DispMain, new Point2d(meanRectRight.X, meanRectRight.Y - 20), $"Brightness : {meanValues["R"].ToString("F3")}", CogColorConstants.Blue);

                                    if (brightnestKey == "L")
                                    {
                                        posX = meanRectLeft.X;
                                        posY = meanRectLeft.Y - 20;
                                        Find_rect = meanRectLeft;
                                        str_Group = "meanRectLeft";
                                        str_value = $"Brightness : {meanValues["L"].ToString("F3")}";

                                        CCognexUtil.DrawText(DispMain, new Point2d(meanRectLeft.X, meanRectLeft.Y - 20), $"Brightness : {meanValues["L"].ToString("F3")}", CogColorConstants.Blue);
                                        DispMain.StaticGraphics.Add(meanRectLeft, "meanRectLeft");
                                    }
                                    else
                                    {
                                        posX = meanRectRight.X;
                                        posY = meanRectRight.Y - 20;
                                        Find_rect = meanRectRight;
                                        str_Group = "meanRectRight";
                                        str_value = $"Brightness : {meanValues["R"].ToString("F3")}";

                                        CCognexUtil.DrawText(DispMain, new Point2d(meanRectRight.X, meanRectRight.Y - 20), $"Brightness : {meanValues["R"].ToString("F3")}", CogColorConstants.Blue);
                                        DispMain.StaticGraphics.Add(meanRectRight, "meanRectRight");

                                    }

                                    string str_Result;
                                    CogColorConstants RESULT_COLOR;


                                    //송현수 -> 안춘길 : 정답 체크
                                    string nResult;
                                    // OK
                                    if (brightnestKey == resultDir)
                                    {
                                        Find_rect.Color = CogColorConstants.Green;
                                        RESULT_COLOR = CogColorConstants.Green;
                                        nResult = "OK";
                                    }
                                    // NG
                                    else
                                    {
                                        Find_rect.Color = CogColorConstants.Red;
                                        RESULT_COLOR = CogColorConstants.Red;
                                        nResult = "NG";
                                    }

                                    CCognexUtil.DrawText(DispMain, new Point2d(posX, posY), str_value, CogColorConstants.Blue);
                                    DispMain.StaticGraphics.Add(Find_rect, str_Group);

                                    ResultTime = $"Result : {nResult}, Brightness : {brightnestKey} TactTime : {tactTime.ElapsedMilliseconds}ms";
                                    CCognexUtil.DrawText(DispMain, new Point2d(posX, posY - 20), ResultTime, RESULT_COLOR);

                                }
                            }
                        }
                    }
                    else
                    {
                        IF_Util.ShowMessageBox("Error", "Find Circle Results Empty");
                    }
                }
                else
                {
                    IF_Util.ShowMessageBox("Error", "Find Circle Results Empty");
                }
            }
            catch
            {
                IF_Util.ShowMessageBox("Error", "Find Circle And No Rectgle Results Not Brightness Empty");
            }
        }

        private void OnClickArrayQrCode(object sender, EventArgs e)
        {
            string strIndex = (sender as UIButton).Text;

            try
            {
                switch (strIndex)
                {
                    case "ROI":
                    case "Roi":
                        {
                            SelectArray(m_nSelectedArrayIndex - 1);
                            //InitJobs();
                            if (m_imgSource_Mono_FullBoard != null && m_imgSource_Mono_FullBoard.Allocated)
                            {
                                SelectGrabImage(comboQrGrabIndex.SelectedIndex);
                                CropArray(m_nSelectedArrayIndex - 1);
                            }
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            CogRectangle cogSearchRegion = new CogRectangle();

                            if (m_nSelectedArrayIndex == 1) cogSearchRegion = CCognexUtil.RectangleToCogRectangle(Global.Setting.Recipe.Insp.QrRegionArray1);
                            if (m_nSelectedArrayIndex == 2) cogSearchRegion = CCognexUtil.RectangleToCogRectangle(Global.Setting.Recipe.Insp.QrRegionArray2);
                            if (m_nSelectedArrayIndex == 3) cogSearchRegion = CCognexUtil.RectangleToCogRectangle(Global.Setting.Recipe.Insp.QrRegionArray3);
                            if (m_nSelectedArrayIndex == 4) cogSearchRegion = CCognexUtil.RectangleToCogRectangle(Global.Setting.Recipe.Insp.QrRegionArray4);

                            cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.Color = CogColorConstants.Red;
                            cogSearchRegion.SelectedColor = CogColorConstants.Red;

                            DispMain.InteractiveGraphics.Add(cogSearchRegion, "Search", false);
                            btnQrRoi.Text = "Complete";
                        }
                        break;

                    case "Complete":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                            CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            if (m_nSelectedArrayIndex == 1) Global.Setting.Recipe.Insp.QrRegionArray1 = CCognexUtil.CogRectangleToRectangle(roi);
                            if (m_nSelectedArrayIndex == 2) Global.Setting.Recipe.Insp.QrRegionArray2 = CCognexUtil.CogRectangleToRectangle(roi);
                            if (m_nSelectedArrayIndex == 3) Global.Setting.Recipe.Insp.QrRegionArray3 = CCognexUtil.CogRectangleToRectangle(roi);
                            if (m_nSelectedArrayIndex == 4) Global.Setting.Recipe.Insp.QrRegionArray4 = CCognexUtil.CogRectangleToRectangle(roi);

                            btnQrRoi.Text = "Roi";
                        }
                        break;
                    case "RUN":
                    case "INSP":
                    case "Read":
                        {
                            string qrCode = "";

                            ICogGraphic resultGraphic = null;

                            if (m_nSelectedArrayIndex == 1) qrCode = IDTool.Read(m_imgSource_Mono, Global.Setting.Recipe.Insp.QrRegionArray1, out resultGraphic);
                            if (m_nSelectedArrayIndex == 2) qrCode = IDTool.Read(m_imgSource_Mono, Global.Setting.Recipe.Insp.QrRegionArray2, out resultGraphic);
                            if (m_nSelectedArrayIndex == 3) qrCode = IDTool.Read(m_imgSource_Mono, Global.Setting.Recipe.Insp.QrRegionArray3, out resultGraphic);
                            if (m_nSelectedArrayIndex == 4) qrCode = IDTool.Read(m_imgSource_Mono, Global.Setting.Recipe.Insp.QrRegionArray4, out resultGraphic);


                            lbQrCodeData.Text = qrCode;

                            if (resultGraphic != null)
                            {
                                DispMain.StaticGraphics.Add(resultGraphic, "RESULT");
                                lbQrCodeData.Text = qrCode;
                            }
                            else
                            {
                                lbQrCodeData.Text = "Can't Find the Code of QR";
                            }

                        }
                        break;
                }
            }

            catch (Exception ex)
            {
                btnQrRoi.Text = "Roi";
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnJobColor_Insp_Click(object sender, EventArgs e)
        {
            try
            {
                int tickProcessStart = Environment.TickCount;
                InvalidateColorRects();
                Mat inImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Color.ToBitmap()).Clone();
                Rect Roi = new Rect((int)Roi_ColorSearchRegion.X, (int)Roi_ColorSearchRegion.Y, (int)Roi_ColorSearchRegion.Width, (int)Roi_ColorSearchRegion.Height);
                Rect RoiValue = new Rect((int)Roi_ColorVAlues.X, (int)Roi_ColorVAlues.Y, (int)Roi_ColorVAlues.Width, (int)Roi_ColorVAlues.Height);
                List<Mat> images = CVisionTools.GetColorImages(inImg, m_selectedJob, Roi, RoiValue);
                //propertyGrid_Jobs.SelectedObject = m_selectedJob;

                if (m_selectedJob.CMethod == CJob.ColorMethod.CA_ConvertGray)
                {
                    IF_Util.ShowMessageBox("EXCEPTION", "This Method Not Prepare !!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OK);
                    return;
                }
                else
                {
                    blobProcessVis(images[0], Roi, images[1], DispMain);                  // Blob 연산
                    //propertyGrid_Jobs.SelectedObject = m_selectedJob;
                }
                int tickProcessEnd = Environment.TickCount;
                string strMsg = $"Color Process Time = {tickProcessEnd - tickProcessStart} msec";
                CLogger.Add(LOG.NORMAL, strMsg);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        //private void btnJobColor_Apply_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        m_selectedJob.SearchRegion = CVisionCognex.CogRectToRectangle(Roi_ColorSearchRegion);
        //        m_selectedJob.valueRect = CVisionCognex.CogRectToRectangle(Roi_ColorVAlues);
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
        //        IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
        //    }
        //}

        private void chkJobPattern_JudgeMode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_selectedJob == null)
                {
                    IF_Util.ShowMessageBox("ERROR", "Job isn't selected");
                    return;
                }
                else
                {
                    bool bol_JudgeMode = chkJobPattern_JudgeMode.Checked;

                    if (bol_JudgeMode)
                    {
                        lbJobPattern_JudgeMode.Text = "N/A : NG";
                        lbJobPattern_JudgeMode.BackColor = Color.Green;
                    }
                    else
                    {
                        lbJobPattern_JudgeMode.Text = "N/A : OK";
                        lbJobPattern_JudgeMode.BackColor = Color.IndianRed;
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void cbJobPattern_PatternType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cogDisplay_JobPattern.InteractiveGraphics.Clear();
            cogDisplay_JobPattern.StaticGraphics.Clear();

            if (m_selectedJob == null) return;

            CCogTool_PMAlign PMAlign = null;

            double dAcceptScore = 0.0;

            if (comboJobPattern_PatternType.Text == "Main") PMAlign = m_selectedJob.Tool;
            else if (comboJobPattern_PatternType.Text == "Sub1") PMAlign = m_selectedJob.SubTool1;
            else if (comboJobPattern_PatternType.Text == "Sub2") PMAlign = m_selectedJob.SubTool2;
            else if (comboJobPattern_PatternType.Text == "Sub3") PMAlign = m_selectedJob.SubTool3;
            else if (comboJobPattern_PatternType.Text == "Sub4") PMAlign = m_selectedJob.SubTool4;

            if (comboJobPattern_PatternType.Text == "Main") { PMAlign = m_selectedJob.Tool; dAcceptScore = m_selectedJob.Tool.Tool.RunParams.AcceptThreshold; }
            else if (comboJobPattern_PatternType.Text == "Sub1") { PMAlign = m_selectedJob.SubTool1; dAcceptScore = m_selectedJob.SubTool1.Tool.RunParams.AcceptThreshold; }
            else if (comboJobPattern_PatternType.Text == "Sub2") { PMAlign = m_selectedJob.SubTool2; dAcceptScore = m_selectedJob.SubTool2.Tool.RunParams.AcceptThreshold; }
            else if (comboJobPattern_PatternType.Text == "Sub3") { PMAlign = m_selectedJob.SubTool3; dAcceptScore = m_selectedJob.SubTool3.Tool.RunParams.AcceptThreshold; }
            else if (comboJobPattern_PatternType.Text == "Sub4") { PMAlign = m_selectedJob.SubTool4; dAcceptScore = m_selectedJob.SubTool4.Tool.RunParams.AcceptThreshold; }

            tbJobPattern_AcceptScore.Text = dAcceptScore.ToString();

            if (PMAlign != null)
            {
                if (PMAlign.Tool.Pattern.Trained)
                {
                    cogDisplay_JobPattern.Image = PMAlign.Tool.Pattern.GetTrainedPatternImage();
                    cogDisplay_JobPattern.Fit(false);
                }
                else
                {
                    cogDisplay_JobPattern.Image = null;
                }
            }
            //OnClickJob_Pattern(btnJobPattern_SetRoi, new EventArgs());
        }

        private void btnMasterBoardImageSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.ShowMessageBox("Message", "Do you want to save the image?"))
                {
                    cogDisplay_MasterImage.Image = new CogImage24PlanarColor((CogImage24PlanarColor)DispMain.Image);
                    string path = $"{Global.m_MainPJTRoot}\\RECIPE\\{Global.System.Recipe.Name}\\MasterBoard_{Global.System.Recipe.Name}.jpg";
                    IF_Util.SafetyImageSave(path, DispMain.Image.ToBitmap());
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnBareBoardImageSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.ShowMessageBox("Message", "Do you want to save the image?"))
                {
                    string strTitle = $"{Global.m_MainPJTRoot}\\RECIPE\\{Global.System.Recipe.Name}\\BareBoard_";
                    SaveImages(strTitle, "jpg");
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }
        private void btnBareBoardImageLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string strFirstFileName = $"{Global.m_MainPJTRoot}\\RECIPE\\{Global.System.Recipe.Name}\\BareBoard_0.jpg";
                //cogDisplay2.Image = LoadImages(strFirstFileName);
                //cogDisplay2.Fit();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnInspectAuto_Click(object sender, EventArgs e)
        {
            if (Global.Instance.System.Recipe.Task_TrainImage != null)
            {
                if (Global.Instance.System.Recipe.Task_TrainImage.Status == TaskStatus.Running)
                {
                    IF_Util.ShowMessageBox("Auto Inspect", $"Setting the Train image.{Environment.NewLine}Please wait a moment!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);
                    return;
                }
            }

            Global.Notice = "Auto Inspection SEQ Run";
            Global.SeqVision.ManualInsp = CSeqVision.ManualType.GRAB_INSP;
        }

        private void btnGetDefaultParam_Click(object sender, EventArgs e)
        {
            try
            {
                FormPopUp_Settings_DefaultParameter Frm = new FormPopUp_Settings_DefaultParameter();
                Frm.Show();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void trbThreshold_Color_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int nThreshold = trbThreshold_Color.Value;

                Mat inImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Color.ToBitmap());

                Mat imgBin = CVisionTools.GetThresholImage(inImg, nThreshold, cboColorCoordinate.SelectedIndex, cboColorAlg.SelectedIndex);

                Cognex.VisionPro.CogImage8Grey imgCogSource = new Cognex.VisionPro.CogImage8Grey(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgBin));
                DispMain.Image = imgCogSource;

                lbThreshold_Color.Text = nThreshold.ToString();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void btnPbaCodeChange_Click(object sender, EventArgs e)
        {
            if (Global.Instance.Frm_PBA_Library == null || !Global.Instance.Frm_PBA_Library.Created)

            {
                Global.Instance.Frm_PBA_Library = new FormMenu_PbaLibrary();
            }

            Global.Instance.Frm_PBA_Library.BringToFront();
            Global.Instance.Frm_PBA_Library.Owner = this;
            Global.Instance.Frm_PBA_Library.Show();
        }

        //private void btnRecentImage_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string strFilePath = Global.Recent.ImagePath;

        //        if (File.Exists(strFilePath))
        //        {
        //            m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor(new Bitmap(strFilePath));
        //            m_imgSource_Mono = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
        //            m_imgSource_Color_FullBoard = new Cognex.VisionPro.CogImage24PlanarColor(new Bitmap(strFilePath));
        //            m_imgSource_Mono_FullBoard = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);

        //            cogDisplay_Source.Image = m_imgSource_Color;
        //            cogDisplay_Source.Fit(true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
        //        CUtil.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
        //    }
        //}

        //private void btnCustomToLibrary_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (CUtil.ShowMessageBox("SAVE", "Do you want to Cloning Custom To Library?") == true)
        //        {
        //            Global.System.CommonCode.JobManager[m_nSelectedArrayIndex - 1].Jobs = CUtil.CloneList<CJob>(Global.System.Recipe.JobManager.Jobs);
        //            InitJobs();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
        //        CUtil.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
        //    }
        //}

        // 현재 셀의 값이 변경될때 확인..
        private void gridLibrary_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Enable을 기억하기..
            Enabled_Check();
        }
        // Enabled 체크함수..
        private void Enabled_Check()
        {
            for (int i = 0; i < gridLibrary.Rows.Count; i++)
            {
                string name = gridLibrary[2, i].Value.ToString();
                bool enabled = bool.Parse(gridLibrary[1, i].Value.ToString());

                for (int j = 0; j < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; j++)
                {
                    if (Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[j].Name == name)
                    {
                        Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[j].Enabled = enabled;
                        break;
                    }
                }
            }
        }
        // 체크박스 클릭시 즉시 변경..
        private void gridLibrary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridLibrary.CommitEdit(DataGridViewDataErrorContexts.Commit))
            {
            }
            else
            {
                IF_Util.ShowMessageBox("Error", "Fail CommitEdit");
            }
        }

        private void gridLibrary_SelectionChanged(object sender, EventArgs e)
        {
            if (gridLibrary.SelectedRows.Count > 0)
            {
                int nRowIndex = gridLibrary.SelectedRows[0].Index;
                string jobName = gridLibrary[2, nRowIndex].Value.ToString();

                //2024.03.15 송현수->안춘길 : 선택 불량 버그
                for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                {
                    CJob job = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i];
                    if (job.Name == jobName)
                    {
                        m_selectedJob = job;
                        m_nSelectedIndex_Library = i;
                        break;
                    }
                }

                //요기 체크
                comboJobPattern_PatternType.Text = "Main";
                SelectGridJobs(true);
                lbSelectFull.BackColor = DEFINE_COMMON.COLOR_BLACK30;
                if (btnJobBlob_Roi.Text != "ROI")
                {
                    btnJobBlob_Roi.Text = "ROI";
                    FinBlobRoiSetting = false;
                }
            }
        }

        private void btnSetting_GrabManager_Click(object sender, EventArgs e)
        {
            try
            {
                FormSettings_GrabManager form = new FormSettings_GrabManager(Global.System.Recipe.GrabManager, Global.Device.Cameras[0]);
                form.Show();
                form.BringToFront();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public void SelectGrabImage(int nImage, bool isImageUpdate = true)
        {
            try
            {
                m_nSelectGrabIndex = nImage;
                if (_imagesGrab[nImage] != null && _imagesGrab[nImage].Allocated)
                {
                    if (Global.Parameter.Cam1_ImageProcess.FlipRotate == "None")
                    {
                        m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor(_imagesGrab[nImage]);
                    }
                    else
                    {
                        m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor((Cognex.VisionPro.CogImage24PlanarColor)CCognexUtil.FlipRotateEx(_imagesGrab[nImage], (CogIPOneImageFlipRotateOperationConstants)Enum.Parse(typeof(CogIPOneImageFlipRotateOperationConstants), Global.Parameter.Cam1_ImageProcess.FlipRotate), true));
                    }

                    m_imgSource_Mono = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
                    m_imgSource_Color_FullBoard = new Cognex.VisionPro.CogImage24PlanarColor(m_imgSource_Color);
                    m_imgSource_Mono_FullBoard = Cognex.VisionPro.CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);

                    switch (nImage)
                    {
                        case 0:
                            DisplayGrabIdx0.Image = m_imgSource_Color;
                            break;

                        case 1:
                            DisplayGrabIdx1.Image = m_imgSource_Color;
                            break;

                        case 2:
                            DisplayGrabIdx2.Image = m_imgSource_Color;
                            break;

                        case 3:
                            DisplayGrabIdx3.Image = m_imgSource_Color;
                            break;

                        case 4:
                            DisplayGrabIdx4.Image = m_imgSource_Color;
                            break;
                    }

                    if (isImageUpdate) DispMain.Image = m_imgSource_Color;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }

        private void OnClickCDGrabImage(object sender, EventArgs e)
        {
            try
            {
                int nIdx = int.Parse((sender as CogDisplay).Tag.ToString());

                SelectGrabImage(nIdx);
                //SelectArray(m_nSelectedArrayIndex - 1);
                // CropArray(m_nSelectedArrayIndex - 1);
                cbJobGrabIndex.SelectedIndex = nIdx;

                lblImage_GrabIndex0.ForeColor = Color.White;
                lblImage_GrabIndex1.ForeColor = Color.White;
                lblImage_GrabIndex2.ForeColor = Color.White;
                lblImage_GrabIndex3.ForeColor = Color.White;
                lblImage_GrabIndex4.ForeColor = Color.White;

                if (nIdx == 0) lblImage_GrabIndex0.ForeColor = Color.Yellow;
                if (nIdx == 1) lblImage_GrabIndex1.ForeColor = Color.Yellow;
                if (nIdx == 2) lblImage_GrabIndex2.ForeColor = Color.Yellow;
                if (nIdx == 3) lblImage_GrabIndex3.ForeColor = Color.Yellow;
                if (nIdx == 4) lblImage_GrabIndex4.ForeColor = Color.Yellow;

            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }

        private void gridRecentImages_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int nIdx = e.RowIndex;
                CogImage24PlanarColor imgOrg_Index0 = new CogImage24PlanarColor();

                if (Global.Data.cogRecentImages[nIdx].recentImages[0] != null && Global.Data.cogRecentImages[nIdx].recentImages[0].Allocated != null)
                {
                    imgOrg_Index0 = new CogImage24PlanarColor((CogImage24PlanarColor)Global.Data.cogRecentImages[nIdx].recentImages[0]);
                }
                for (int i = 0; i < Global.Data.cogRecentImages[nIdx].recentImages.Length; i++)
                {
                    if (Global.Data.cogRecentImages[nIdx].recentImages[i] != null && Global.Data.cogRecentImages[nIdx].recentImages[i].Allocated)
                    {
                        _imagesGrab[i] = new Cognex.VisionPro.CogImage24PlanarColor(Global.Data.cogRecentImages[nIdx].recentImages[i]);
                        if (chkAlignNoUse.Checked == false) _imagesGrab[i] = CVisionTools.RotateMarkedImage(new CogImage24PlanarColor(imgOrg_Index0), _imagesGrab[i], _selectedFiducialLibrary);
                        MenualInsImgArray[i] = new CogImage24PlanarColor(_imagesGrab[i]);
                    }
                }

                SelectGrabImage(0);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }


        private void btnJobPattern_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                cogDisplay_JobPattern.InteractiveGraphics.Clear();
                cogDisplay_JobPattern.StaticGraphics.Clear();

                CCogTool_PMAlign PMAlign = null;

                if (comboJobPattern_PatternType.Text == "Main") PMAlign = m_selectedJob.Tool;
                else
                {
                    if (comboJobPattern_PatternType.Text == "Sub1") PMAlign = m_selectedJob.SubTool1;
                    if (comboJobPattern_PatternType.Text == "Sub2") PMAlign = m_selectedJob.SubTool2;
                    if (comboJobPattern_PatternType.Text == "Sub3") PMAlign = m_selectedJob.SubTool3;
                    if (comboJobPattern_PatternType.Text == "Sub4") PMAlign = m_selectedJob.SubTool4;
                }

                PMAlign.Tool = new CogPMAlignTool();

                if (PMAlign != null)
                {
                    if (PMAlign.Tool.Pattern.Trained)
                    {
                        cogDisplay_JobPattern.Image = PMAlign.Tool.Pattern.GetTrainedPatternImage();
                        cogDisplay_JobPattern.Fit(false);
                    }
                    else
                    {
                        cogDisplay_JobPattern.Image = null;
                    }
                }
                DisplayTrainCount();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnGrabMove_Click(object sender, EventArgs e)
        {
            try
            {
                int nGrabIndex = cbJobGrabIndex.SelectedIndex;
                SelectGrabImage(nGrabIndex, false);
                SelectArray(m_nSelectedArrayIndex - 1);
                CropArray(m_nSelectedArrayIndex - 1);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }


        private void btnJobColor_AutoColor_Click(object sender, EventArgs e)
        {
            try
            {
                string strIndex = (sender as Button).Text;

                string strCode = txtPartCode.Text;

                InvalidateColorRects();

                Rect Roi = new Rect((int)Roi_ColorSearchRegion.X, (int)Roi_ColorSearchRegion.Y, (int)Roi_ColorSearchRegion.Width, (int)Roi_ColorSearchRegion.Height);
                Rect RoiValue = new Rect((int)Roi_ColorVAlues.X, (int)Roi_ColorVAlues.Y, (int)Roi_ColorVAlues.Width, (int)Roi_ColorVAlues.Height);

                Mat inImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Color.ToBitmap()).Clone();

                cColorResult resultColor = CVisionTools.AutoColorParam(inImg, Roi, RoiValue, m_selectedJob.CCoordinate, m_selectedJob.CMethod, m_selectedJob.Name);
                resultColor.SetJob(ref m_selectedJob);

                // Gray / Threshold시
                if (m_selectedJob.CMethod == CJob.ColorMethod.CA_THRESHILD && m_selectedJob.CCoordinate == CJob.ColorCoordinate.CC_GRAY)
                {
                    // UI의 색상 및 정보를 넣는다.
                    UpdateColorUI(lbExtractedColor, lbExtractedColor2, trbThreshold_Color, lbThreshold_Color);

                    CVisionTools.InsertResultImg(resultColor.imgBin, inImg, Roi);                                          // 결과 이미지 생성
                    cBlobSize blobSize = blobProcessVis(resultColor.imgBin, Roi, inImg, DispMain);   // Blob 이미지 처리
                    //propertyGrid_Jobs.SelectedObject = m_selectedJob;
                }
                else if (m_selectedJob.CMethod == CJob.ColorMethod.CA_ConvertGray)
                {
                    IF_Util.ShowMessageBox("EXCEPTION", "This Method Not Prepare !!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OK);
                    return;
                }
                else
                {
                    // UI의 색상 및 정보를 넣는다.
                    UpdateColorUI(lbExtractedColor, lbExtractedColor2, trbThreshold_Color, lbThreshold_Color);

                    cBlobSize blobSize = blobProcessVis(resultColor.imgBin, Roi, inImg, DispMain);
                    //propertyGrid_Jobs.SelectedObject = m_selectedJob;

                    // Blob에서 구한 값으로 레시피를 설정 한다.
                    m_selectedJob.RangeAreaMax = (int)(blobSize.nMaxArea * 1.5);
                    m_selectedJob.RangeAreaMin = (int)(blobSize.nMaxArea * 0.5);

                    lbColorMaxArea.Text = m_selectedJob.RangeAreaMax.ToString();
                    lbColorMinArea.Text = m_selectedJob.RangeAreaMin.ToString();

                    blobProcessVis(resultColor.imgBin, Roi, inImg, DispMain);
                    //propertyGrid_Jobs.SelectedObject = m_selectedJob;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        public void UpdateColorUI(Label minLabel, Label maxLabel, MetroTrackBar thresholdBar, Label thresLabel)
        {
            Scalar scrMin = new Scalar(m_selectedJob.Min0, m_selectedJob.Min1, m_selectedJob.Min2);
            Scalar scrMax = new Scalar(m_selectedJob.Max0, m_selectedJob.Max1, m_selectedJob.Max2);

            string strMin = "", strMax = "";

            Color crMin = GetRGBColor(m_selectedJob.CCoordinate, scrMin);
            if (thresholdBar == null && scrMin[0] == 0 && scrMin[1] == 0 && scrMin[2] == 0)
                strMin = "Threshold";
            else
                strMin = scrMin.ToString() + "   ~";

            minLabel.ForeColor = Color.Gray;
            minLabel.Text = strMin;
            minLabel.BackColor = crMin;

            if ((int)m_selectedJob.CCoordinate < 0) m_selectedJob.CCoordinate = ColorCoordinate.CC_GRAY;
            Color crMax = GetRGBColor(m_selectedJob.CCoordinate, scrMax);
            if (thresLabel == null && scrMax[0] == 0 && scrMax[1] == 0 && scrMax[2] == 0)
                strMax = m_selectedJob.Threshold.ToString();
            else
                strMax = scrMax.ToString();
            maxLabel.ForeColor = Color.Gray;
            maxLabel.Text = strMax;
            maxLabel.BackColor = crMax;

            if (thresholdBar != null)
            {
                if (m_selectedJob.Threshold <= 0)
                    trbThreshold_Color.Value = 1;
                else
                    trbThreshold_Color.Value = m_selectedJob.Threshold;
            }

            if (thresLabel != null)
                lbThreshold_Color.Text = m_selectedJob.Threshold.ToString();
        }


        public class cColorResult
        {
            // Image Data
            public Mat imgAll { get; set; } = new Mat();

            public Mat imgBin { get; set; } = new Mat();

            // Recipe Data
            public Scalar scrMin { get; set; } = new Scalar();

            public Scalar scrMax { get; set; } = new Scalar();

            //int nThreshold = 0;
            public int nRangeAreaMax { get; set; } = 0;

            public int nRangeAreaMin { get; set; } = 0;
            public int nThreshold { get; set; } = 0;

            public void InputAreaInfo(int min, int max)
            {
                nRangeAreaMax = max; nRangeAreaMin = min;
            }

            public void InputAreaInfo(int min, int max, int thres)
            {
                nRangeAreaMax = max; nRangeAreaMin = min; nThreshold = thres;
            }

            public void InputColorInfo(Scalar min, Scalar max)
            {
                scrMax = max; scrMin = min;
            }

            public void InputImages(Mat bin, Mat all)
            {
                imgAll = all.Clone(); imgBin = bin.Clone();
            }

            public void SetJob(ref CJob job)
            {
                job.Min2 = (int)scrMin.Val2;
                job.Max2 = (int)scrMax.Val2;
                job.Min1 = (int)scrMin.Val1;
                job.Max1 = (int)scrMax.Val1;
                job.Min0 = (int)scrMin.Val0;
                job.Max0 = (int)scrMax.Val0;
                job.RangeAreaMax = nRangeAreaMax;
                job.RangeAreaMin = nRangeAreaMin;
                job.Threshold = nThreshold;
                job.UseColorRange = true;
            }

            public Mat GetImgFull()
            {
                return imgAll.Clone();
            }

            public Mat GetImgBin()
            {
                return imgBin.Clone();
            }
        }

        public Color GetRGBColor(CJob.ColorCoordinate ColorCoord, Scalar ColorValue)
        {
            Color retColor = new Color();
            Mat inMat = new Mat(1, 1, MatType.CV_8UC3, ColorValue);
            Mat resultMat = new Mat();
            MatType type = MatType.CV_8UC3;

            switch (ColorCoord)
            {
                case CJob.ColorCoordinate.CC_GRAY:
                    Cv2.CvtColor(inMat, resultMat, ColorConversionCodes.BGR2RGB);
                    break;

                case CJob.ColorCoordinate.CC_BGR:
                    Cv2.CvtColor(inMat, resultMat, ColorConversionCodes.BGR2RGB);
                    break;

                case CJob.ColorCoordinate.CC_HSV:
                    Cv2.CvtColor(inMat, resultMat, ColorConversionCodes.HSV2RGB);
                    break;

                case CJob.ColorCoordinate.CC_YUV:
                    Cv2.CvtColor(inMat, resultMat, ColorConversionCodes.YUV2RGB);
                    break;

                case CJob.ColorCoordinate.CC_XYZ:
                    Cv2.CvtColor(inMat, resultMat, ColorConversionCodes.XYZ2RGB);
                    break;
            }
            Scalar resultScr = (Scalar)resultMat.At<Vec3b>(0, 0);

            retColor = Color.FromArgb((int)resultScr.Val0, (int)resultScr.Val1, (int)resultScr.Val2);

            return retColor;
        }

        public class cBlobSize
        {
            public int nMaxArea = 0;
            public int nAcceptMaxArea = 0;
        }

        public cBlobSize blobProcessVis(Mat imgIn, Rect Roi, Mat imgAll, Cognex.VisionPro.Display.CogDisplay display)
        {
            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();

            CvBlobs blobs = new CvBlobs();
            blobs.Label(imgIn);
            if (m_selectedJob != null) blobs.FilterByArea(100, 200000);

            cBlobSize blobSize = new cBlobSize();
            Bitmap img = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgAll);
            display.Image = new Cognex.VisionPro.CogImage24PlanarColor(img);
            foreach (var b in blobs)
            {
                Cognex.VisionPro.CogRectangle boundingRect = new Cognex.VisionPro.CogRectangle();
                boundingRect.X = Roi.X + b.Value.Rect.X;
                boundingRect.Y = Roi.Y + b.Value.Rect.Y;
                boundingRect.Width = b.Value.Rect.Width;
                boundingRect.Height = b.Value.Rect.Height;
                boundingRect.LineWidthInScreenPixels = 3;

                Cognex.VisionPro.CogGraphicLabel lb = new Cognex.VisionPro.CogGraphicLabel();
                if (b.Value.Area > m_selectedJob.RangeAreaMin && b.Value.Area < m_selectedJob.RangeAreaMax)
                {
                    boundingRect.Color = Cognex.VisionPro.CogColorConstants.Green;
                    lb.Color = Cognex.VisionPro.CogColorConstants.Green;
                    if (blobSize.nAcceptMaxArea < b.Value.Area)
                        blobSize.nAcceptMaxArea = b.Value.Area;
                }
                else
                {
                    boundingRect.Color = Cognex.VisionPro.CogColorConstants.Red;
                    lb.Color = Cognex.VisionPro.CogColorConstants.Red;
                }

                lb.Text = $"Area : {b.Value.Area}";
                lb.Font = new Font("Arial", 12);
                lb.X = boundingRect.CenterX;
                lb.Y = boundingRect.CenterY;

                if (blobSize.nMaxArea < b.Value.Area)
                    blobSize.nMaxArea = b.Value.Area;

                display.StaticGraphics.Add(boundingRect, "Rect");
                display.StaticGraphics.Add(lb, "Rect");
            }
            Image imgLast = display.CreateContentBitmap(Cognex.VisionPro.Display.CogDisplayContentBitmapConstants.Image);
            Bitmap bmpLast = (Bitmap)imgLast.Clone();

            return blobSize;
        }

        private void btnJobColor_Roi_MouseHover(object sender, EventArgs e)
        {
            btnJobColor_Roi.Image = Properties.Resources.Roi50_MouseHover;
            btnJobColor_Roi.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnJobColor_Roi_MouseLeave(object sender, EventArgs e)
        {
            btnJobColor_Roi.Image = Properties.Resources.Roi50_Normal;
            btnJobColor_Roi.ForeColor = Color.White;
        }

        private void btnJobColor_AutoColor_MouseHover(object sender, EventArgs e)
        {
            btnJobColor_AutoColor.Image = Properties.Resources.AutoColor50_MouseHover;
            btnJobColor_AutoColor.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnJobColor_AutoColor_MouseLeave(object sender, EventArgs e)
        {
            btnJobColor_AutoColor.Image = Properties.Resources.AutoColor50_Normal;
            btnJobColor_AutoColor.ForeColor = Color.White;
        }

        private void btnJobColor_Insp_MouseHover(object sender, EventArgs e)
        {
            btnJobColor_Insp.Image = Properties.Resources.InspectManual50_MouseHover;
            btnJobColor_Insp.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnJobColor_Insp_MouseLeave(object sender, EventArgs e)
        {
            btnJobColor_Insp.Image = Properties.Resources.InspectManual50_Normal;
            btnJobColor_Insp.ForeColor = Color.White;
        }

        private void btnViewJobs_MouseHover(object sender, EventArgs e)
        {
            btnViewJobs.Image = Properties.Resources.ViewJobs50_MouseHover;
            btnViewJobs.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnViewJobs_MouseLeave(object sender, EventArgs e)
        {
            btnViewJobs.Image = Properties.Resources.ViewJobs50_Normal;
            btnViewJobs.ForeColor = Color.White;
        }

        private void btnInspectAuto_MouseHover(object sender, EventArgs e)
        {
            btnInspectAuto.Image = Properties.Resources.InspectAuto50_MouseHover;
            btnInspectAuto.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnInspectAuto_MouseLeave(object sender, EventArgs e)
        {
            btnInspectAuto.Image = Properties.Resources.InspectAuto50_Normal;
            btnInspectAuto.ForeColor = Color.White;
        }

        private void btnInspect_MouseHover(object sender, EventArgs e)
        {
            btnInspect.Image = Properties.Resources.InspectManual50_MouseHover;
            btnInspect.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnInspect_MouseLeave(object sender, EventArgs e)
        {
            btnInspect.Image = Properties.Resources.InspectManual50_Normal;
            btnInspect.ForeColor = Color.White;
        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            btnSave.Image = Properties.Resources.Save50_MouseHover;
            btnSave.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.Image = Properties.Resources.Save50_Normal;
            btnSave.ForeColor = Color.White;
        }

        //private void btnLeftRotate_Click(object sender, EventArgs e)
        //{
        //    double angle = Convert.ToDouble(txbAngle.Text);
        //    RotateImage(angle);
        //}

        //private void btnRightRotate_Click(object sender, EventArgs e)
        //{
        //    double angle = -Convert.ToDouble(txbAngle.Text);
        //    RotateImage(angle);
        //}

        //private void RotateImage(double angle, int bufferNo = -1)
        //{
        //    double allAngle = Convert.ToDouble(txbAllAngle.Text);
        //    allAngle += angle;
        //    txbAllAngle.Text = allAngle.ToString();
        //    Point2d rotateCenter = new Point2d(0, 0);
        //    Cognex.VisionPro.CogRectangle refRect = new Cognex.VisionPro.CogRectangle();
        //    // 여기 Rotate 기준에 대한 정의를 한다.
        //    if (cmbRotateCenter.Text.Contains("ROI"))
        //    {
        //        CCogTool_PMAlign pMAlign = GetPMAlignArray();
        //        switch (cmbRotateCenter.Text)
        //        {
        //            case "ROI_Left_Top":
        //                refRect = (Cognex.VisionPro.CogRectangle)pMAlign.Tool.Pattern.TrainRegion;
        //                rotateCenter = new Point2d(Convert.ToDouble(refRect.X), Convert.ToDouble(refRect.Y));
        //                break;

        //            case "ROI_Right_Top":
        //                refRect = (Cognex.VisionPro.CogRectangle)pMAlign.Tool.Pattern.TrainRegion;
        //                rotateCenter = new Point2d(Convert.ToDouble(refRect.X + refRect.Width), Convert.ToDouble(refRect.Y));
        //                break;

        //            case "ROI_Left_Bottom":
        //                refRect = (Cognex.VisionPro.CogRectangle)pMAlign.Tool.Pattern.TrainRegion;
        //                rotateCenter = new Point2d(Convert.ToDouble(refRect.X), Convert.ToDouble(refRect.Y + refRect.Height));
        //                break;

        //            case "ROI_Right_Bottom":
        //                refRect = (Cognex.VisionPro.CogRectangle)pMAlign.Tool.Pattern.TrainRegion;
        //                rotateCenter = new Point2d(Convert.ToDouble(refRect.X + refRect.Width), Convert.ToDouble(refRect.Y + refRect.Height));
        //                break;

        //            case "ROI_Center":
        //                refRect = (Cognex.VisionPro.CogRectangle)pMAlign.Tool.Pattern.TrainRegion;
        //                rotateCenter = new Point2d(Convert.ToDouble(refRect.CenterX), Convert.ToDouble(refRect.CenterY));
        //                break;
        //        }

        //        SetPMAlignArray(pMAlign);
        //    }
        //    else
        //        rotateCenter = new Point2d(Convert.ToDouble(m_imgSource_Color.Width) / 2.0, Convert.ToDouble(m_imgSource_Color.Height) / 2.0);
        //    m_imgSource_Color = VisionTools.rotateImage(rotateCenter, angle, m_imgSource_Color);
        //    m_imgSource_Mono = VisionTools.rotateImage(rotateCenter, angle, m_imgSource_Mono);
        //    if (bufferNo >= 0)
        //        _imagesGrab[bufferNo] = m_imgSource_Color;
        //    cogDisplay_Source.Image = m_imgSource_Color;
        //}

        //private void btnCancelRotate_Click(object sender, EventArgs e)
        //{
        //    txbAllAngle.Text = "0.00";
        //    m_imgSource_Color = _imagesGrab[m_nSelectGrabIndex];
        //    cogDisplay_Source.Image = m_imgSource_Color;
        //}

        //private void btnRotateAllImage_Click(object sender, EventArgs e)
        //{
        //    int pervGrabIndex = m_nSelectGrabIndex;
        //    double allAngle = Convert.ToDouble(txbAllAngle.Text);
        //    for (int i = 0; i < Global.System.Recipe.GrabManager.Nodes.Length; i++)
        //    {
        //        if (Global.System.Recipe.GrabManager.Nodes[i].Enabled)
        //        {
        //            SelectGrabImage(i);
        //            RotateImage(allAngle, i);
        //        }
        //    }
        //    txbAllAngle.Text = "0.00";
        //}

        //public void Inspection_PatternMatching(CCogTool_PMAlign PMAlign, CogGraphicLabel label, out string str_Result)
        //{
        //    str_Result = "";

        //    if (PMAlign.Tool.Results == null)
        //    {
        //        str_Result = "0";
        //        return;
        //    }
        //    for (int i = 0; i < PMAlign.Tool.Results.Count; i++)
        //    {
        //        Cognex.VisionPro.CogCompositeShape resultDrawing = PMAlign.Tool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.All);
        //        label.X = PMAlign.Tool.Results[i].GetPose().TranslationX;
        //        label.Y = PMAlign.Tool.Results[i].GetPose().TranslationY;
        //        cogDisplay_Source.InteractiveGraphics.Add(PMAlign.Tool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin), "main", false);
        //        cogDisplay_Source.StaticGraphics.Add(resultDrawing, "main");
        //    }

        //    CogPMAlignResult result_Best = CVisionCognex.GetBestResult_PMAlign(PMAlign.Tool);

        //    if (result_Best == null)
        //        str_Result = "0";
        //    else
        //        str_Result = result_Best.Score.ToString();
        //}
        public bool Inspection_PatternMatching(CCogTool_PMAlign PMAlign, bool useResultGrapic, out List<CogPMAlignResult> resultList)
        {
            resultList = new List<CogPMAlignResult>();
            if (PMAlign.Tool.Results == null || PMAlign.Tool.Results.Count == 0)
            {
                resultList = null;
                return false;
            }
            if (!useResultGrapic)
            {
                resultList.Add(CVisionCognex.GetBestResult_PMAlign(PMAlign.Tool));
            }
            else
            {
                for (int i = 0; i < PMAlign.Tool.Results.Count; i++)
                {
                    Cognex.VisionPro.CogCompositeShape resultDrawing = PMAlign.Tool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion);
                    //cogDisplay_Source.InteractiveGraphics.Add(PMAlign.Tool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin), "main", false);
                    DispMain.StaticGraphics.Add(resultDrawing, "main");
                    resultList.Add(PMAlign.Tool.Results[i]);
                }
            }
            return true;
        }
        public void Inspection_Color(string str_Color, CCogTool_PMAlign PMAlign, out string str_Result)
        {
            str_Result = "";

            Scalar lowerBlue = new Scalar(100, 80, 100);
            Scalar upperBlue = new Scalar(150, 255, 255);

            Scalar lowerRed1 = new Scalar(0, 80, 70);   // 빨간색 계열의 낮은 범위 (빨간색의 시작 범위)
            Scalar upperRed1 = new Scalar(20, 255, 255); // 빨간색 계열의 높은 범위 (빨간색의 끝 범위)

            Scalar lowerRed2 = new Scalar(235, 80, 70); // 빨간색 계열의 낮은 범위 (빨간색의 시작 범위, 색상 공간 반복)
            Scalar upperRed2 = new Scalar(255, 255, 255); // 빨간색 계열의 높은 범위 (빨간색의 끝 범위, 색상 공간 반복)

            Scalar lowerYellow = new Scalar(20, 80, 100); // 노란색 계열의 낮은 범위
            Scalar upperYellow = new Scalar(40, 255, 255); // 노란색 계열의 높은 범위

            Mat inImg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Color.ToBitmap()).Clone();

            // Rectangle로 정의한 영역을 추출합니다.
            Cognex.VisionPro.CogRectangle Roi = (Cognex.VisionPro.CogRectangle)PMAlign.Tool.Pattern.TrainRegion;
            Rect R = new Rect((int)Roi.X, (int)Roi.Y, (int)Roi.Width, (int)Roi.Height);

            Mat roi_image = new Mat(inImg, R);

            // 색상 검출을 위해 이미지를 HSV 색상 공간으로 변환합니다.
            Mat hsvImage = new Mat();
            Cv2.CvtColor(roi_image, hsvImage, ColorConversionCodes.BGR2HSV);

            Mat mask_blue = new Mat();
            Mat mask_red1 = new Mat();
            Mat mask_red2 = new Mat();
            Mat mask_yellow = new Mat();

            Cv2.InRange(hsvImage, lowerBlue, upperBlue, mask_blue);
            Cv2.InRange(hsvImage, lowerRed1, upperRed1, mask_red1);
            Cv2.InRange(hsvImage, lowerRed2, upperRed2, mask_red2);
            Cv2.InRange(hsvImage, lowerYellow, upperYellow, mask_yellow);

            int[] numbers = { Cv2.CountNonZero(mask_blue), Cv2.CountNonZero(mask_red1) + Cv2.CountNonZero(mask_red2), Cv2.CountNonZero(mask_yellow) };

            int max = 300; // 최솟값으로 초기화
            int maxIndex = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                    maxIndex = i;
                }
            }

            switch (maxIndex)
            {
                case 0:
                    str_Result = "blue";
                    break;
                case 1:
                    str_Result = "red";
                    break;
                case 2:
                    str_Result = "yellow";
                    break;
                default:
                    str_Result = "black";
                    break;
            }
        }

        private void chkColor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkColor.Checked)
            {
                cboPatternColorCoordinate.Enabled = true;
                cboPatternColorAlg.Enabled = true;
            }
            else
            {
                cboPatternColorCoordinate.Enabled = false;
                cboPatternColorCoordinate.SelectedIndex = 0;
                cboPatternColorAlg.Enabled = false;
                cboPatternColorAlg.SelectedIndex = 0;
            }
        }

        private void trackbarThreshold_Scroll(object sender, EventArgs e)
        {
            if (DispMain.Image == null) return;

            using (Mat imgOrg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Color.ToBitmap()).Clone())
            using (Mat imgBin = new Mat())
            {
                IF_Util.SetImageChannel1(imgOrg);

                if (chkThresholdInv.Checked) Cv2.Threshold(imgOrg, imgBin, trackbarThreshold.Value, 255, ThresholdTypes.BinaryInv);
                else Cv2.Threshold(imgOrg, imgBin, trackbarThreshold.Value, 255, ThresholdTypes.Binary);

                DispMain.Image = new CogImage24PlanarColor(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgBin));
            }
            lblThresholdValue.Text = trackbarThreshold.Value.ToString();
        }

        static bool FinBlobRoiSetting = false;

        private void OnClick_Pin(object sender, EventArgs e)
        {
            UIButton btn = (sender as UIButton);

            if (DispMain.Image == null || DispMain.Image.Allocated == false)
            {
                IF_Util.ShowMessageBox("Error", "Check the Image");
                return;
            }

            // 블랍을 검사할 위치의 ROI의 설정...
            switch (btn.Text)
            {
                case "ROI_Apply":
                case "ROI":
                case "Roi":
                    {
                        if (!FinBlobRoiSetting)
                        {
                            Blob_ROI();
                            btn.BackColor = Color.Orange;
                            btn.Text = "ROI_Apply";
                            FinBlobRoiSetting = true;
                        }
                        else
                        {
                            // Blob을 검사할 서치 영역 설정...
                            int idx = DispMain.InteractiveGraphics.FindItem("FinBlobSearch", CogDisplayZOrderConstants.Back);

                            if (idx == -1)
                            {
                                Blob_ROI();
                                idx = DispMain.InteractiveGraphics.FindItem("FinBlobSearch", CogDisplayZOrderConstants.Back);
                            }
                            else
                            {
                                btn.BackColor = System.Drawing.Color.FromArgb(44, 46, 66);
                                btn.Text = "ROI";
                                FinBlobRoiSetting = false;
                            }

                            CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);
                            m_selectedJob.Fin_InspecTool.BlobSearchRoi = CCognexUtil.CogRectangleToRectangle(roi);
                        }
                    }
                    break;

                case "Apply":
                    {
                        // 각 설정 값들 job Data에 갱신..
                        m_selectedJob.Fin_InspecTool.BlobAreaMin = int.Parse(tbAreaMin.Text);
                        m_selectedJob.Fin_InspecTool.BlobAreaMax = int.Parse(tbAreaMax.Text);
                        m_selectedJob.Fin_InspecTool.BlobThreshold = int.Parse(txtBlobThreshold.Text);
                        m_selectedJob.Fin_InspecTool.BlobThresholdInv = chkThresholdInv.Checked;
                    }
                    break;

                case "Find":
                    {
                        if (FinBlobRoiSetting)
                        {
                            IF_Util.ShowMessageBox("Check", "Blob Search ROI Setting..Apply Please!!");
                            return;
                        }
                        DispMain.InteractiveGraphics.Clear();
                        DispMain.StaticGraphics.Clear();

                        CogRectangle cogSearchRegion = CCognexUtil.RectangleToCogRectangle(m_selectedJob.Fin_InspecTool.BlobSearchRoi);
                        if (BlobPos_X != 0 && BlobPos_Y != 0 && m_selectedJob.Parameter.BlobMasterPos_X != 0 && m_selectedJob.Parameter.BlobMasterPos_Y != 0)
                        {
                            cogSearchRegion.X += BlobPos_X - m_selectedJob.Parameter.BlobMasterPos_X;
                            cogSearchRegion.Y += BlobPos_Y - m_selectedJob.Parameter.BlobMasterPos_Y;
                        }
                        cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                        cogSearchRegion.Interactive = true;
                        cogSearchRegion.Color = CogColorConstants.Red;
                        cogSearchRegion.SelectedColor = CogColorConstants.Red;

                        DispMain.InteractiveGraphics.Add(cogSearchRegion, "FinBlobSearch", false);
                        //BlobAlignCalc();
                        //BlobAlignMove();
                        // Blob Contour
                        //Blob_FindContour();
                    }
                    break;
            }
        }

        private void btn_FinInspec_Click(object sender, EventArgs e)
        {
            Fin_Inspec();
        }

        bool offset_change;

        private void BlobAlignCalc()
        {
            if (DispMain.Image == null || DispMain.Image.Allocated == false)
            {
                IF_Util.ShowMessageBox("Error", "Check the Image");
                return;
            }

            DispMain.InteractiveGraphics.Clear();
            DispMain.StaticGraphics.Clear();

            int mag_1st = 1;
            int mag_2st = 1;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.SetSourceImage(m_imgSource_Color.ToBitmap());
            m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Run(m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.m_MatchingTemplateImage, m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi, 0.1D, mag_1st, mag_2st);

            double dMaxScore = double.MinValue;
            Rect rtMaxScore = new Rect();
            Point2d pointMaxScore = new Point2d();

            if (m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results.Count > 0)
            {
                if (dMaxScore < m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Score)
                {
                    dMaxScore = m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Score;
                    rtMaxScore = m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Bounding;
                    pointMaxScore = m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Center;

                    // 매칭할 센터 기준점이 변경되었는지 확인...
                    if (m_selectedJob.Fin_InspecTool.Center_X != pointMaxScore.X || m_selectedJob.Fin_InspecTool.Center_Y != pointMaxScore.Y)
                    {
                        //적용 때는 찾은 블랍의 Center 에서 offset 만큼 + 처리 위치로
                        int offsetX = (int)(m_selectedJob.Fin_InspecTool.BlobSearchRoi.X - pointMaxScore.X);
                        int offsetY = (int)(m_selectedJob.Fin_InspecTool.BlobSearchRoi.Y - pointMaxScore.Y);

                        m_selectedJob.Fin_InspecTool.BlobAlignOffset = new System.Drawing.Point(offsetX, offsetY);

                        m_selectedJob.Fin_InspecTool.Center_X = pointMaxScore.X;
                        m_selectedJob.Fin_InspecTool.Center_Y = pointMaxScore.Y;
                        offset_change = true;
                    }
                }

                CogRectangle cogRectDetected = new CogRectangle();
                cogRectDetected.X = rtMaxScore.X;
                cogRectDetected.Y = rtMaxScore.Y;
                cogRectDetected.Width = rtMaxScore.Width;
                cogRectDetected.Height = rtMaxScore.Height;
                cogRectDetected.Color = CogColorConstants.Green;

                CCognexUtil.DrawString(DispMain, $"Score : {dMaxScore:0.00} %  ({pointMaxScore.X},{pointMaxScore.Y})", rtMaxScore.Location, CogColorConstants.Green, 10);

                CCognexUtil.DrawPosMarker(pointMaxScore, rtMaxScore.Width, rtMaxScore.Height, DispMain, CogColorConstants.Green);
                DispMain.StaticGraphics.Add(cogRectDetected, "RT");
            }
            else
            {
                IF_Util.ShowMessageBox("Error", "Can't Find the Mark");
            }
        }

        //private void BlobAlignMove()
        //{
        //    if (cogDisplay_Source.Image == null || cogDisplay_Source.Image.Allocated == false)
        //    {
        //        IF_Util.ShowMessageBox("Error", "Check the Image");
        //        return;
        //    }

        //    cogDisplay_Source.InteractiveGraphics.Clear();
        //    cogDisplay_Source.StaticGraphics.Clear();

        //    int mag_1st = 2;
        //    int mag_2st = 1;

        //    Stopwatch sw = new Stopwatch();
        //    sw.Start();

        //    m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.SetSourceImage(m_imgSource_Color.ToBitmap());
        //    m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Run(m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.m_MatchingTemplateImage, m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi, 0.1D, mag_1st, mag_2st);

        //    double dMaxScore = double.MinValue;

        //    if (m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results.Count > 0)
        //    {
        //        if (dMaxScore < m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Score)
        //        {
        //            Point2d pointMaxScore = m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Center;

        //            // 오프셋값이 변경되었으면 블랍 위치 조정..
        //            if (offset_change)
        //            {
        //                Rectangle rect = new Rectangle((int)(pointMaxScore.X + m_selectedJob.Fin_InspecTool.BlobAlignOffset.X), (int)(pointMaxScore.Y + m_selectedJob.Fin_InspecTool.BlobAlignOffset.Y), m_selectedJob.Fin_InspecTool.BlobSearchRoi.Width, m_selectedJob.Fin_InspecTool.BlobSearchRoi.Height);
        //                m_selectedJob.Fin_InspecTool.BlobSearchRoi = rect;
        //                offset_change = false;
        //            }
        //        }

        //        (bool, int) result = Blob_FindContour();
        //    }
        //    else
        //    {
        //        IF_Util.ShowMessageBox("Error", "Can't Find the Mark");
        //    }
        //}

        private void Fin_Inspec()
        {
            if (DispMain.Image == null || DispMain.Image.Allocated == false)
            {
                IF_Util.ShowMessageBox("Error", "Check the Image");
                return;
            }

            DispMain.InteractiveGraphics.Clear();
            DispMain.StaticGraphics.Clear();

            int mag_1st = 2;
            int mag_2st = 1;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.SetSourceImage(m_imgSource_Color.ToBitmap());
            m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Run(m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.m_MatchingTemplateImage, m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi, 0.1D, mag_1st, mag_2st);

            double dMaxScore = m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.m_Score_Min;
            Rect rtMaxScore = new Rect();
            Point2d pointMaxScore = new Point2d();

            if (m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results.Count > 0)
            {
                CogRectangle cogRectDetected = new CogRectangle();
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();
                if (dMaxScore < m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Score)
                {
                    pointMaxScore = m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Center;
                    rtMaxScore = m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Bounding;

                    cogRectDetected.X = rtMaxScore.X;
                    cogRectDetected.Y = rtMaxScore.Y;
                    cogRectDetected.Width = rtMaxScore.Width;
                    cogRectDetected.Height = rtMaxScore.Height;
                    cogRectDetected.Color = CogColorConstants.Green;

                }
                else
                {
                    cogRectDetected.X = m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi.X;
                    cogRectDetected.Y = m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi.Y;
                    cogRectDetected.Width = m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi.Width;
                    cogRectDetected.Height = m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi.Height;
                    cogRectDetected.Color = CogColorConstants.Red;

                    CCognexUtil.DrawString(DispMain, $"NG => No Area Result", new Point2d(cogRectDetected.X, cogRectDetected.Y), CogColorConstants.Red, 10);
                    return;

                }



                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                //CogRectangle cogSearchRegion = CCognexUtil.RectangleToCogRectangle(m_selectedJob.Fin_InspecTool.BlobSearchRoi);
                //cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                //cogSearchRegion.Interactive = true;
                //cogSearchRegion.Color = CogColorConstants.Red;
                //cogSearchRegion.SelectedColor = CogColorConstants.Red;

                //cogDisplay_Source.StaticGraphics.Add(cogSearchRegion, "Search");
                System.Drawing.Point offset = new System.Drawing.Point(0, 0);
                if (m_selectedJob.Parameter.BlobMasterPos_X != 0 && m_selectedJob.Parameter.BlobMasterPos_Y != 0)
                {
                    offset.X = (int)pointMaxScore.X - m_selectedJob.Parameter.BlobMasterPos_X;
                    offset.Y = (int)pointMaxScore.Y - m_selectedJob.Parameter.BlobMasterPos_Y;
                }
                CCognexUtil.DrawPosMarker(pointMaxScore, rtMaxScore.Width, rtMaxScore.Height, DispMain, CogColorConstants.Green);
                DispMain.StaticGraphics.Add(cogRectDetected, "RT");

                (bool, int, double, double) result = Blob_FindContour(offset);

                if (result.Item1)
                {
                    CCognexUtil.DrawString(DispMain, $"OK => Area : {result.Item2}", new Point2d(result.Item3, result.Item3), CogColorConstants.Green, 10);
                }
                else
                {
                    CCognexUtil.DrawString(DispMain, $"NG => No Area Result", new Point2d(result.Item3, result.Item3), CogColorConstants.Red, 10);
                }
            }
            else
            {
                IF_Util.ShowMessageBox("Error", "Can't Find the Mark");
            }
        }

        private void Blob_ROI()
        {
            DispMain.InteractiveGraphics.Clear();
            DispMain.StaticGraphics.Clear();

            CogRectangle cogSearchRegion = CCognexUtil.RectangleToCogRectangle(m_selectedJob.Fin_InspecTool.BlobSearchRoi);
            cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
            cogSearchRegion.Interactive = true;
            cogSearchRegion.Color = CogColorConstants.Red;
            cogSearchRegion.SelectedColor = CogColorConstants.Red;

            DispMain.InteractiveGraphics.Add(cogSearchRegion, "FinBlobSearch", false);
        }

        private (bool, int, double, double) Blob_FindContour(System.Drawing.Point offset)
        {
            (bool, int, double, double) result = (false, 0, 0.0d, 0.0d);

            DispMain.InteractiveGraphics.Clear();

            _imageSourceCV = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Mono.ToBitmap()).Clone();
            Rectangle tempRect = m_selectedJob.Fin_InspecTool.BlobSearchRoi;
            tempRect.X += offset.X;
            tempRect.Y += offset.Y;
            if (tempRect.Right > _imageSourceCV.Cols)
            {
                tempRect.X -= tempRect.Right - _imageSourceCV.Cols;
            }
            if (tempRect.Bottom > _imageSourceCV.Rows)
            {
                int a = (tempRect.Bottom - _imageSourceCV.Rows);
                tempRect.Y = tempRect.Y - a;
            }
            using (Mat imgRoi = _imageSourceCV.SubMat(CConverter.RectToCVRect(m_selectedJob.Fin_InspecTool.BlobSearchRoi)).Clone())
            {
                int ng_value;
                List<(Rect, int)> rects = CVision.Contour(imgRoi, m_selectedJob.Fin_InspecTool.BlobThreshold, m_selectedJob.Fin_InspecTool.BlobAreaMin, m_selectedJob.Fin_InspecTool.BlobAreaMax, out ng_value, m_selectedJob.Fin_InspecTool.BlobThresholdInv);
                // Threadshold를 한뒤에 동작한 부분일수 있기 때문에...원래 이미지로 변환...
                DispMain.Image = m_imgSource_Color;

                if (rects.Count > 0)
                {
                    for (int i = 0; i < rects.Count; i++)
                    {
                        CogRectangle cogRect = new CogRectangle();
                        cogRect.X = rects[i].Item1.X + m_selectedJob.Fin_InspecTool.BlobSearchRoi.X;
                        cogRect.Y = rects[i].Item1.Y + m_selectedJob.Fin_InspecTool.BlobSearchRoi.Y;

                        cogRect.Width = rects[i].Item1.Width;
                        cogRect.Height = rects[i].Item1.Height;
                        cogRect.Color = CogColorConstants.Green;

                        result.Item2 = rects[i].Item2;
                        result.Item3 = cogRect.X;
                        result.Item4 = cogRect.Y;

                        //CCognexUtil.DrawString(cogDisplay_Source, $"Area : {rects[i].Item2}", new Point2d(cogRect.X, cogRect.Y), CogColorConstants.Red, 10);
                        DispMain.StaticGraphics.Add(cogRect, "RT");
                    }

                    result.Item1 = true;
                }
            }

            return result;
        }

        // 신규 알고리즘 관련 추가..
        private void OnClickAlgorithm_Blob(object sender, EventArgs e)
        {
            try
            {
                string action = (sender as UIButton).Text;

                if (DispMain.Image == null || DispMain.Image.Allocated == false)
                {
                    IF_Util.ShowMessageBox("Error", "Check the Image");
                    return;
                }

                switch (action)
                {
                    case "ROI":
                    case "Roi":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();
                            DispMain.Fit();

                            // Search 영역
                            CogRectangle cogSearchRegion = CCognexUtil.RectangleToCogRectangle(m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi);
                            cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.Color = CogColorConstants.Red;
                            cogSearchRegion.SelectedColor = CogColorConstants.Red;

                            DispMain.InteractiveGraphics.Add(cogSearchRegion, "FinMatchingSearch", false);

                            // Train 영역
                            CogRectangle cogTrainRegion = new CogRectangle();

                            cogTrainRegion = CCognexUtil.RectangleToCogRectangle(m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.MatchingTemplateRoi);

                            cogTrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                            cogTrainRegion.Interactive = true;
                            cogTrainRegion.Color = CogColorConstants.Blue;

                            if (cogTrainRegion.Width == 0 || cogTrainRegion.Height == 0)
                            {
                                cogTrainRegion.Width = 100;
                                cogTrainRegion.Height = 100;
                            }

                            DispMain.InteractiveGraphics.Add(cogTrainRegion, "FinMatchingPattern", false);
                        }
                        break;
                    case "TRAIN":
                    case "Train":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("FinMatchingSearch", CogDisplayZOrderConstants.Back);
                            CogRectangle Search_roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi = CCognexUtil.CogRectangleToRectangle(Search_roi);

                            idx = DispMain.InteractiveGraphics.FindItem("FinMatchingPattern", CogDisplayZOrderConstants.Back);
                            CogRectangle Train_roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            using (Bitmap imgPattern = IF_Util.Crop(m_imgSource_Color.ToBitmap(), new Rectangle((int)Train_roi.X, (int)Train_roi.Y, (int)Train_roi.Width, (int)Train_roi.Height)))
                            {
                                CogDisplay_FinMatchingTemplateImg.Image = new CogImage8Grey(imgPattern);
                                CogDisplay_FinMatchingTemplateImg.Fit(true);

                                CogRectangle cogTrainRegion = new CogRectangle();
                                CogRectangle cogSearchRegion = new CogRectangle();

                                m_selectedJob.SearchRegion = CCognexUtil.CogRectangleToRectangle(Train_roi);
                                m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.MatchingTemplateRoi = CCognexUtil.CogRectangleToRectangle(Train_roi);
                                m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.m_MatchingTemplateImage = (Bitmap)imgPattern.Clone();
                                m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.m_Score_Min = double.Parse(txt_PinMatchingScoreMin.Text);

                                cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                                cogSearchRegion.Interactive = true;
                                cogSearchRegion.Color = CogColorConstants.Red;
                                cogSearchRegion.SelectedColor = CogColorConstants.Red;

                                cogTrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                                cogTrainRegion.Interactive = true;
                                cogTrainRegion.Color = CogColorConstants.Blue;


                                if (cogTrainRegion.Width == 0 || cogTrainRegion.Height == 0)
                                {
                                    cogTrainRegion.Width = 100;
                                    cogTrainRegion.Height = 100;
                                }

                                DispMain.InteractiveGraphics.Add((ICogGraphicInteractive)cogSearchRegion, "FinMatchingSearch", false);
                                DispMain.InteractiveGraphics.Add((ICogGraphicInteractive)cogTrainRegion, "FinMatchingPattern", false);
                            }
                        }
                        break;
                    case "FIND":
                    case "Find":
                        {
                            Fin_MatchingFind();

                        }
                        break;
                }
            }
            catch (Exception ex)
            {
            }


        }

        private void Fin_MatchingFind()
        {
            DispMain.InteractiveGraphics.Clear();
            DispMain.StaticGraphics.Clear();

            int mag_1st = 1;
            int mag_2st = 1;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.SetSourceImage(m_imgSource_Color.ToBitmap());
            m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Run(m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.m_MatchingTemplateImage, m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi, 0.1D, mag_1st, mag_2st);

            double dMaxScore = double.MinValue;
            Rect rtMaxScore = new Rect();
            Point2d pointMaxScore = new Point2d();

            if (m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results.Count > 0)
            {
                if (dMaxScore < m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Score)
                {
                    dMaxScore = m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Score;
                    rtMaxScore = m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Bounding;
                    pointMaxScore = m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.Results[0].Center;
                }

                DispMain.StaticGraphics.Clear();

                CogRectangle cogRectDetected = new CogRectangle();
                cogRectDetected.X = rtMaxScore.X;
                cogRectDetected.Y = rtMaxScore.Y;
                cogRectDetected.Width = rtMaxScore.Width;
                cogRectDetected.Height = rtMaxScore.Height;
                BlobPos_X = (int)pointMaxScore.X;
                BlobPos_Y = (int)pointMaxScore.Y;
                if (m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.m_Score_Min < dMaxScore)
                {
                    cogRectDetected.Color = CogColorConstants.Green;
                }
                else
                {
                    cogRectDetected.Color = CogColorConstants.Red;
                }
                CCognexUtil.DrawString(DispMain, $"Score : {dMaxScore:0.00} %  ({pointMaxScore.X},{pointMaxScore.Y})", rtMaxScore.Location, CogColorConstants.Green, 10);

                CCognexUtil.DrawPosMarker(pointMaxScore, rtMaxScore.Width, rtMaxScore.Height, DispMain, CogColorConstants.Green);
                DispMain.InteractiveGraphics.Add(cogRectDetected, "RT", true);
            }
            else
            {
                IF_Util.ShowMessageBox("Error", "Can't Find the Mark");
            }

            sw.Stop();
        }

        private void btnImageAlign_Rotate_Click(object sender, EventArgs e)
        {
            try
            {
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                int mag_1st = 1;
                int mag_2st = 1;

                Stopwatch tactTime = new Stopwatch();
                tactTime.Start();

                CTemplateMatching matchingLT = new CTemplateMatching("LT");
                CTemplateMatching matchingRB = new CTemplateMatching("RB");
                int tactTime_1st = 0;

                //2024.03.15 송현수 -> 안춘길 : 이미지 회전이 1회 완료가 X, 3번 반복
                for (int i = 0; i < 3; i++)
                {
                    using (Mat imgOrg = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Color.ToBitmap()))
                    using (Mat imgRot = new Mat())
                    {
                        matchingLT.SetSourceImage(m_imgSource_Color.ToBitmap());
                        matchingRB.SetSourceImage(m_imgSource_Color.ToBitmap());

                        matchingLT.Run(_selectedFiducialLibrary.Fiducial1);
                        matchingRB.Run(_selectedFiducialLibrary.Fiducial2);

                        Point2d posLT = new Point2d(0, 0);
                        Point2d posRB = new Point2d(0, 0);

                        Rect rectLT = new Rect();
                        Rect rectRB = new Rect();

                        if (matchingLT.Results.Count == 0) { IF_Util.ShowMessageBox("Error", "Can't Find the Mark of Fiducial (LT)"); return; }
                        if (matchingRB.Results.Count == 0) { IF_Util.ShowMessageBox("Error", "Can't Find the Mark of Fiducial (RB)"); return; }

                        posLT = matchingLT.Results[0].Center;
                        posRB = matchingRB.Results[0].Center;

                        rectLT = matchingLT.Results[0].Bounding;
                        rectRB = matchingRB.Results[0].Bounding;

                        CogLineSegment line = new CogLineSegment();
                        line.SetStartEnd(posLT.X, posLT.Y, posRB.X, posRB.Y);
                        line.Color = CogColorConstants.Red;

                        DispMain.StaticGraphics.Add(line, "LINE");
                        DispMain.StaticGraphics.Add(CConverter.CVRectToCogRect(rectLT), "LT");
                        DispMain.StaticGraphics.Add(CConverter.CVRectToCogRect(rectRB), "RB");

                        double angle = IF_Util.GetAngle(posLT, posRB);
                        lblDegreeMeasure.Text = $"{angle:F5}";

                        double angleDelta = angle - _selectedFiducialLibrary.MasterAngle;

                        if (Math.Abs(angleDelta) < 0.05)
                        {
                            break;
                        }
                        else
                        {
                            lblDegreeDelta.Text = $"{angleDelta:F5}";

                            Point2f posCenter = new Point2f(imgOrg.Width / 2, imgOrg.Height / 2);
                            // 회전을 위한 변환 행렬을 얻습니다.
                            Mat rotationMatrix = Cv2.GetRotationMatrix2D(posCenter, angleDelta, 1.0);

                            // 이미지를 변환 행렬을 사용하여 회전시킵니다.
                            Cv2.WarpAffine(imgOrg, imgRot, rotationMatrix, imgOrg.Size());

                            tactTime_1st = (int)tactTime.ElapsedMilliseconds;
                            _imageSourceCV = imgRot.Clone();
                            m_imgSource_Color = new CogImage24PlanarColor(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgRot));
                        }
                    }
                }

                DispMain.Image = m_imgSource_Color;
                lblTactTime.Text = $"T/T : {tactTime_1st}/{tactTime.ElapsedMilliseconds} ms";
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnFiducial_Measure_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboFiducialLibrary.Text == "" || _selectedFiducialLibrary == null)
                {
                    IF_Util.ShowMessageBox("Error", "Should to selecte the library of fiducial first");
                    return;
                }

                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                int mag_1st = 1;
                int mag_2st = 1;

                Stopwatch sw = new Stopwatch();
                sw.Start();

                CTemplateMatching matchingLT = new CTemplateMatching("LT");
                CTemplateMatching matchingRB = new CTemplateMatching("RB");

                matchingLT.SetSourceImage(m_imgSource_Color.ToBitmap());
                matchingRB.SetSourceImage(m_imgSource_Color.ToBitmap());

                matchingLT.Run(_selectedFiducialLibrary.Fiducial1);
                matchingRB.Run(_selectedFiducialLibrary.Fiducial2);

                Point2d posLT = new Point2d(0, 0);
                Point2d posRB = new Point2d(0, 0);

                Rect rectLT = new Rect();
                Rect rectRB = new Rect();

                if (matchingLT.Results.Count == 0) { IF_Util.ShowMessageBox("Error", "Can't Find the Mark of Fiducial (LT)"); return; }
                if (matchingRB.Results.Count == 0) { IF_Util.ShowMessageBox("Error", "Can't Find the Mark of Fiducial (RB)"); return; }

                posLT = matchingLT.Results[0].Center;
                posRB = matchingRB.Results[0].Center;

                rectLT = matchingLT.Results[0].Bounding;
                rectRB = matchingRB.Results[0].Bounding;

                CogLineSegment line = new CogLineSegment();
                line.SetStartEnd(posLT.X, posLT.Y, posRB.X, posRB.Y);
                line.Color = CogColorConstants.Red;

                DispMain.StaticGraphics.Add(line, "LINE");
                DispMain.StaticGraphics.Add(CConverter.CVRectToCogRect(rectLT), "LT");
                DispMain.StaticGraphics.Add(CConverter.CVRectToCogRect(rectRB), "RB");

                double angle = IF_Util.GetAngle(posLT, posRB);
                lblDegreeMeasure.Text = $"{angle:F5}";

                double angleDelta = angle - _selectedFiducialLibrary.MasterAngle;
                lblDegreeDelta.Text = $"{angleDelta:F5}";
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnFiducial_MeasureToMaster_Click(object sender, EventArgs e)
        {
            try
            {
                // 현재 마스터 데이터 변경 메세지 박스...
                if (IF_Util.ShowMessageBox("Fiducial", "Would you like to change the current Fiducial master value settings?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    _selectedFiducialLibrary.MasterAngle = double.Parse(lblDegreeMeasure.Text);
                    lblDegreeMaster.Text = $"{_selectedFiducialLibrary.MasterAngle:F5}";
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void timerRoiWait_Tick(object sender, EventArgs e)
        {
            try
            {
                if (string.Equals(btnJobPin_Roi.Text, "Complete"))
                {
                    int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                    if (idx == -1) btnJobPin_Roi.Text = "Roi";

                    if (btnJobPin_Roi.FillColor == DEFINE.COLOR_ORANGE)
                    {
                        btnJobPin_Roi.FillColor = Color.FromArgb(40, 40, 40);
                    }
                    else
                    {
                        btnJobPin_Roi.FillColor = DEFINE.COLOR_ORANGE;
                    }
                }
                else
                {
                    btnJobPin_Roi.FillColor = Color.FromArgb(40, 40, 40);
                }

                if (string.Equals(btnJobColorEx_Roi.Text, "Complete"))
                {
                    int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                    if (idx == -1) btnJobColorEx_Roi.Text = "Roi";

                    if (btnJobColorEx_Roi.FillColor == DEFINE.COLOR_ORANGE)
                    {
                        btnJobColorEx_Roi.FillColor = Color.FromArgb(40, 40, 40);
                    }
                    else
                    {
                        btnJobColorEx_Roi.FillColor = DEFINE.COLOR_ORANGE;
                    }
                }
                else
                {
                    btnJobColorEx_Roi.FillColor = Color.FromArgb(40, 40, 40);
                }

                if (string.Equals(btnJobDistance_Roi.Text, "Complete"))
                {
                    int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                    if (idx == -1) btnJobDistance_Roi.Text = "Roi";

                    if (btnJobDistance_Roi.FillColor == DEFINE.COLOR_ORANGE)
                    {
                        btnJobDistance_Roi.FillColor = Color.FromArgb(40, 40, 40);
                    }
                    else
                    {
                        btnJobDistance_Roi.FillColor = DEFINE.COLOR_ORANGE;
                    }
                }
                else
                {
                    btnJobDistance_Roi.FillColor = Color.FromArgb(40, 40, 40);
                }

                if (string.Equals(btnJobEyeD_Roi.Text, "Complete"))
                {
                    int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                    if (idx == -1) btnJobEyeD_Roi.Text = "Roi";

                    if (btnJobEyeD_Roi.FillColor == DEFINE.COLOR_ORANGE)
                    {
                        btnJobEyeD_Roi.FillColor = Color.FromArgb(40, 40, 40);
                    }
                    else
                    {
                        btnJobEyeD_Roi.FillColor = DEFINE.COLOR_ORANGE;
                    }
                }
                else
                {
                    btnJobEyeD_Roi.FillColor = Color.FromArgb(40, 40, 40);
                }


                if (string.Equals(btnJobCondensor_Roi.Text, "Complete"))
                {
                    int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                    if (idx == -1) btnJobCondensor_Roi.Text = "Roi";

                    if (btnJobCondensor_Roi.FillColor == DEFINE.COLOR_ORANGE)
                    {
                        btnJobCondensor_Roi.FillColor = Color.FromArgb(40, 40, 40);
                    }
                    else
                    {
                        btnJobCondensor_Roi.FillColor = DEFINE.COLOR_ORANGE;
                    }
                }
                else
                {
                    btnJobCondensor_Roi.FillColor = Color.FromArgb(40, 40, 40);
                }

                if (string.Equals(btnArrayCrop_Roi.Text, "Complete"))
                {
                    int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                    if (idx == -1) btnArrayCrop_Roi.Text = "Roi";

                    if (btnArrayCrop_Roi.FillColor == DEFINE.COLOR_ORANGE)
                    {
                        btnArrayCrop_Roi.FillColor = Color.FromArgb(40, 40, 40);
                    }
                    else
                    {
                        btnArrayCrop_Roi.FillColor = DEFINE.COLOR_ORANGE;
                    }
                }
                else
                {
                    btnArrayCrop_Roi.FillColor = Color.FromArgb(40, 40, 40);
                }

                if (string.Equals(btnQrRoi.Text, "Complete"))
                {
                    int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                    if (idx == -1) btnQrRoi.Text = "Roi";

                    if (btnQrRoi.FillColor == DEFINE.COLOR_ORANGE)
                    {
                        btnQrRoi.FillColor = Color.FromArgb(40, 40, 40);
                    }
                    else
                    {
                        btnQrRoi.FillColor = DEFINE.COLOR_ORANGE;
                    }
                }
                else
                {
                    btnQrRoi.FillColor = Color.FromArgb(40, 40, 40);
                }

            }
            catch
            {

            }
        }

        private void btnArrayCrop_Roi_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboFiducialLibrary.Text == "" || _selectedFiducialLibrary == null)
                {
                    IF_Util.ShowMessageBox("Error", "Should to selecte the library of fiducial first");
                    return;
                }

                Point2d pos = FindFiducialMark(false);

                if (pos.X == 0 && pos.Y == 0)
                {
                    IF_Util.ShowMessageBox("Error", "Can't Find the Fiducial Mark");
                    return;
                }

                if (string.Equals(btnArrayCrop_Roi.Text, "Complete"))
                {
                    int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                    CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                    if (comboArray.SelectedIndex == 0) _selectedFiducialLibrary.RegionArray1 = CCognexUtil.CogRectangleToRectangle(roi);
                    if (comboArray.SelectedIndex == 1) _selectedFiducialLibrary.RegionArray2 = CCognexUtil.CogRectangleToRectangle(roi);
                    if (comboArray.SelectedIndex == 2) _selectedFiducialLibrary.RegionArray3 = CCognexUtil.CogRectangleToRectangle(roi);
                    if (comboArray.SelectedIndex == 3) _selectedFiducialLibrary.RegionArray4 = CCognexUtil.CogRectangleToRectangle(roi);

                    if (comboArray.SelectedIndex == 0) _selectedFiducialLibrary.OffsetArray1 = new PointF((float)pos.X - _selectedFiducialLibrary.RegionArray1.X, (float)pos.Y - _selectedFiducialLibrary.RegionArray1.Y);
                    if (comboArray.SelectedIndex == 1) _selectedFiducialLibrary.OffsetArray2 = new PointF((float)pos.X - _selectedFiducialLibrary.RegionArray2.X, (float)pos.Y - _selectedFiducialLibrary.RegionArray2.Y);
                    if (comboArray.SelectedIndex == 2) _selectedFiducialLibrary.OffsetArray3 = new PointF((float)pos.X - _selectedFiducialLibrary.RegionArray3.X, (float)pos.Y - _selectedFiducialLibrary.RegionArray3.Y);
                    if (comboArray.SelectedIndex == 3) _selectedFiducialLibrary.OffsetArray4 = new PointF((float)pos.X - _selectedFiducialLibrary.RegionArray4.X, (float)pos.Y - _selectedFiducialLibrary.RegionArray4.Y);

                    btnArrayCrop_Roi.Text = "Roi";
                }
                else
                {
                    DispMain.InteractiveGraphics.Clear();
                    DispMain.StaticGraphics.Clear();

                    CogRectangle cogSearchRegion = new CogRectangle();

                    if (comboArray.SelectedIndex == 0)
                    {
                        cogSearchRegion = CCognexUtil.RectangleToCogRectangle(_selectedFiducialLibrary.RegionArray1);
                        cogSearchRegion.X = pos.X - _selectedFiducialLibrary.OffsetArray1.X;
                        cogSearchRegion.Y = pos.Y - _selectedFiducialLibrary.OffsetArray1.Y;
                    }
                    if (comboArray.SelectedIndex == 1)
                    {
                        cogSearchRegion = CCognexUtil.RectangleToCogRectangle(_selectedFiducialLibrary.RegionArray2);
                        cogSearchRegion.X = pos.X - _selectedFiducialLibrary.OffsetArray2.X;
                        cogSearchRegion.Y = pos.Y - _selectedFiducialLibrary.OffsetArray2.Y;
                    }
                    if (comboArray.SelectedIndex == 2)
                    {
                        cogSearchRegion = CCognexUtil.RectangleToCogRectangle(_selectedFiducialLibrary.RegionArray3);
                        cogSearchRegion.X = pos.X - _selectedFiducialLibrary.OffsetArray3.X;
                        cogSearchRegion.Y = pos.Y - _selectedFiducialLibrary.OffsetArray3.Y;
                    }
                    if (comboArray.SelectedIndex == 3)
                    {
                        cogSearchRegion = CCognexUtil.RectangleToCogRectangle(_selectedFiducialLibrary.RegionArray4);
                        cogSearchRegion.X = pos.X - _selectedFiducialLibrary.OffsetArray4.X;
                        cogSearchRegion.Y = pos.Y - _selectedFiducialLibrary.OffsetArray4.Y;
                    }

                    cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                    cogSearchRegion.Interactive = true;
                    cogSearchRegion.Color = CogColorConstants.Red;
                    cogSearchRegion.SelectedColor = CogColorConstants.Red;

                    DispMain.InteractiveGraphics.Add(cogSearchRegion, "Search", false);
                    btnArrayCrop_Roi.Text = "Complete";
                }
            }
            catch (Exception ex)
            {
                btnArrayCrop_Roi.Text = "Roi";
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnArrayCrop_Crop_Click(object sender, EventArgs e)
        {
            try
            {
                Point2d pos = FindFiducialMark(false);

                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                if (pos.X == 0 && pos.Y == 0)
                {
                    IF_Util.ShowMessageBox("Error", "Can't Find the Fiducial Mark");
                    return;
                }

                Rectangle region = new Rectangle();

                if (comboArray.SelectedIndex == 0) region = _selectedFiducialLibrary.RegionArray1;
                if (comboArray.SelectedIndex == 1) region = _selectedFiducialLibrary.RegionArray2;
                if (comboArray.SelectedIndex == 2) region = _selectedFiducialLibrary.RegionArray3;
                if (comboArray.SelectedIndex == 3) region = _selectedFiducialLibrary.RegionArray4;

                Rectangle cutRegion = new Rectangle(region.X + (int)pos.X, region.Y + (int)pos.Y, region.Width, region.Height);

                if (comboArray.SelectedIndex == 0) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray1.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray1.Y), region.Width, region.Height);
                if (comboArray.SelectedIndex == 1) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray2.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray2.Y), region.Width, region.Height);
                if (comboArray.SelectedIndex == 2) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray3.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray3.Y), region.Width, region.Height);
                if (comboArray.SelectedIndex == 3) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray4.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray4.Y), region.Width, region.Height);

                //m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor(IF_Util.Crop(m_imgSource_Color_FullBoard.ToBitmap(), cutRegion));
                //m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey(IF_Util.Crop(m_imgSource_Mono_FullBoard.ToBitmap(), cutRegion));
                m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor(IF_Util.Crop(m_imgSource_Color.ToBitmap(), cutRegion));
                m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey(IF_Util.Crop(m_imgSource_Color.ToBitmap(), cutRegion));


                DispMain.Image = m_imgSource_Color;
                DispMain.Fit(true);
            }
            catch (Exception ex)
            {
                btnArrayCrop_Roi.Text = "Roi";
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private Rectangle CropArray(int idx, bool getOnlyRegion = false, bool isImageUpdate = true)
        {
            try
            {
                Point2d pos = FindFiducialMark(false);

                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                if (pos.X == 0 && pos.Y == 0)
                {
                    IF_Util.ShowMessageBox("Error", "Can't Find the Fiducial Mark");
                    return new Rectangle();
                }

                Rectangle region = new Rectangle();

                if (idx == 0) region = _selectedFiducialLibrary.RegionArray1;
                if (idx == 1) region = _selectedFiducialLibrary.RegionArray2;
                if (idx == 2) region = _selectedFiducialLibrary.RegionArray3;
                if (idx == 3) region = _selectedFiducialLibrary.RegionArray4;

                Rectangle cutRegion = new Rectangle(region.X + (int)pos.X, region.Y + (int)pos.Y, region.Width, region.Height);

                if (idx == 0) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray1.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray1.Y), region.Width, region.Height);
                if (idx == 1) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray2.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray2.Y), region.Width, region.Height);
                if (idx == 2) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray3.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray3.Y), region.Width, region.Height);
                if (idx == 3) cutRegion = new Rectangle((int)(pos.X - _selectedFiducialLibrary.OffsetArray4.X), (int)(pos.Y - _selectedFiducialLibrary.OffsetArray4.Y), region.Width, region.Height);

                if (getOnlyRegion == false)
                {
                    using (Bitmap img = IF_Util.Crop(m_imgSource_Color_FullBoard.ToBitmap(), cutRegion))
                    {
                        m_imgSource_Color = new Cognex.VisionPro.CogImage24PlanarColor(img);
                        m_imgSource_Mono = new Cognex.VisionPro.CogImage8Grey(img);
                    }

                    if (isImageUpdate)
                    {
                        DispMain.Image = m_imgSource_Color;
                        DispMain.Fit(true);
                    }
                }

                return cutRegion;
            }
            catch (Exception ex)
            {
                btnArrayCrop_Roi.Text = "Roi";
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");

                return new Rectangle();
            }
        }

        private void btnImageOriginal_Click(object sender, EventArgs e)
        {
            try
            {
                if (DispMain.Image == null) return;
                DispMain.Image = m_imgSource_Color.ScaleImage(DispMain.Image.Width, DispMain.Image.Height);
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnSave_Fiducial_Click(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.ShowMessageBox("Fiducial", "Would you like to save the current Fiducial master value?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    for (int i = 0; i < Global.System.Recipe.JobManager.Length; i++)
                    {
                        //2024.03.15 송현수->안춘길 : 처음에 레시피 만들 때 할당이 안되어있음
                        if (i == 0 && Global.System.Recipe.JobManager_Array1 == null)
                        {
                            Global.System.Recipe.JobManager_Array1 = new CInspJobs();
                            Global.System.Recipe.JobManager[0] = Global.System.Recipe.JobManager_Array1;
                        }
                        else if (i == 1 && Global.System.Recipe.JobManager_Array2 == null)
                        {
                            Global.System.Recipe.JobManager_Array2 = new CInspJobs();
                            Global.System.Recipe.JobManager[1] = Global.System.Recipe.JobManager_Array2;
                        }
                        else if (i == 2 && Global.System.Recipe.JobManager_Array3 == null)
                        {
                            Global.System.Recipe.JobManager_Array3 = new CInspJobs();
                            Global.System.Recipe.JobManager[2] = Global.System.Recipe.JobManager_Array3;
                        }
                        else if (i == 3 && Global.System.Recipe.JobManager_Array4 == null)
                        {
                            Global.System.Recipe.JobManager_Array2 = new CInspJobs();
                            Global.System.Recipe.JobManager[3] = Global.System.Recipe.JobManager_Array4;
                        }
                    }
                    Global.System.Recipe.FiducialLibrary = _selectedFiducialLibrary;
                    Global.System.Recipe.FIducialLibrary_Number = lblFiducialLibrary.Text;
                    Global.System.Recipe.FiducialLibrary.FiducialGrabIndex = int.Parse(comboGrabIndex_Fiducial.Text);
                    Global.Setting.Recipe.Save(Global.Instance.System.Recipe.Name);
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void txtPartCode_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyValue == Keys.Enter)
            {
                btnJobAllApply_Click(this, new EventArgs());
            }
        }


        private void btnDeleteJobAll_Click(object sender, EventArgs e)
        {
            if (IF_Util.ShowMessageBox("Check", $"Do you want to delete All Jobs?"))
            {
                for (int i = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count - 1; i >= 0; i--)
                {
                    Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.RemoveAt(i);
                }

                InitJobs();
            }
        }

        private void btnPreProcessRun_One_Click(object sender, EventArgs e)
        {
            try
            {
                using (Bitmap bitmap = m_imgSource_Color.ToBitmap())
                {
                    Mat img = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);
                    IF_Util.SetImageChannel1(img);

                    Bitmap imgResult = m_imgSource_Color.ToBitmap();

                    if (chkUseFilter1.Checked)
                    {
                        int kernelW = int.Parse(txtFilter1_KernelW.Text);
                        int kernelH = int.Parse(txtFilter1_KernelH.Text);

                        img = CVisionTools.RunFilter(img, (CVisionTools.CV_FILTER)comboFilter1Type.SelectedIndex, kernelW, kernelH);
                    }

                    if (chkUseFilter2.Checked)
                    {
                        int kernelW = int.Parse(txtFilter2_KernelW.Text);
                        int kernelH = int.Parse(txtFilter2_KernelH.Text);

                        img = CVisionTools.RunFilter(img, (CVisionTools.CV_FILTER)comboFilter2Type.SelectedIndex, kernelW, kernelH);
                    }

                    DispMain.Image = new CogImage24PlanarColor(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img));
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void OnClickAlgorithm_Condensor(object sender, EventArgs e)
        {
            try
            {
                string strIndex = (sender as UIButton).Text;

                if (strIndex != "Complete")
                {
                    DispMain.InteractiveGraphics.Clear();
                    DispMain.StaticGraphics.Clear();
                }

                switch (strIndex)
                {
                    case "ROI":
                    case "Roi":
                        {
                            CogRectangle cogSearchRegion = new CogRectangle();

                            if (m_selectedJob.SearchRegion.Width != 0 && m_selectedJob.SearchRegion.Height != 0)
                                cogSearchRegion = CConverter.RectToCogRect(m_selectedJob.SearchRegion);
                            if (cogSearchRegion.Width == 0) cogSearchRegion.Width = 100;
                            if (cogSearchRegion.Height == 0) cogSearchRegion.Height = 100;

                            cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.Color = CogColorConstants.Red;
                            cogSearchRegion.SelectedColor = CogColorConstants.Red;

                            DispMain.InteractiveGraphics.Add(cogSearchRegion, "Search", false);

                            m_selectedJob.Find_Circle.RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;
                            m_selectedJob.Find_Circle.RunParams.NumCalipers = 8;
                            //m_selectedJob.Find_Circle.RunParams.NumToIgnore = 2;
                            //m_selectedJob.Find_Circle.RunParams.CaliperRunParams.ContrastThreshold = 5;
                            //m_selectedJob.Find_Circle.RunParams.CaliperRunParams.FilterHalfSizeInPixels = 5;

                            CogGraphicCollection cogRegions;
                            ICogRecord cogRecord;

                            m_selectedJob.Find_Circle.InputImage = new CogImage8Grey(m_imgSource_Mono);
                            m_selectedJob.Find_Circle.CurrentRecordEnable = CogFindCircleCurrentRecordConstants.All;

                            cogRecord = m_selectedJob.Find_Circle.CreateCurrentRecord();
                            CogCircularArc cogSegment = (CogCircularArc)cogRecord.SubRecords["InputImage"].SubRecords["ExpectedShapeSegment"].Content;
                            cogRegions = (CogGraphicCollection)cogRecord.SubRecords["InputImage"].SubRecords["CaliperRegions"].Content;
                            DispMain.InteractiveGraphics.Add(cogSegment, "ExpectedShapeSegment", false);

                            if (cogRegions == null) return;
                            foreach (ICogGraphic g in cogRegions) DispMain.InteractiveGraphics.Add((ICogGraphicInteractive)g, "CaliperRegions", false);
                            btnJobCondensor_Roi.Text = "Complete";
                        }
                        break;
                    case "Complete":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                            CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            m_selectedJob.SearchRegion = CConverter.CogRectToRect(roi);
                            btnJobCondensor_Roi.Text = "Roi";
                        }
                        break;
                    case "FIND":
                    case "Find":
                        {
                            using (Bitmap bitmap = m_imgSource_Color.ToBitmap())
                            {
                                Mat img = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);
                                IF_Util.SetImageChannel1(img);

                                Bitmap imgResult = m_imgSource_Color.ToBitmap();

                                if (chkUseFilter1.Checked)
                                {
                                    int kernelW = int.Parse(txtFilter1_KernelW.Text);
                                    int kernelH = int.Parse(txtFilter1_KernelH.Text);

                                    img = CVisionTools.RunFilter(img, (CVisionTools.CV_FILTER)comboFilter1Type.SelectedIndex, kernelW, kernelH);
                                }

                                if (chkUseFilter2.Checked)
                                {
                                    int kernelW = int.Parse(txtFilter2_KernelW.Text);
                                    int kernelH = int.Parse(txtFilter2_KernelH.Text);

                                    img = CVisionTools.RunFilter(img, (CVisionTools.CV_FILTER)comboFilter2Type.SelectedIndex, kernelW, kernelH);
                                }

                                m_selectedJob.Parameter.CondensorRectWidth = int.Parse(tbCircleRectW.Text);
                                m_selectedJob.Parameter.CondensorRectHeight = int.Parse(tbCircleRectH.Text);
                                m_selectedJob.Parameter.CondensorRadiusOffset = int.Parse(tbCondensorRectRadio.Text);
                                m_selectedJob.Parameter.CondensorTypeTB = radioCondensorTB.Checked;

                                Inspection_Circle(new CogImage8Grey(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img)), comboCondensorPolarity.Text);
                            }
                        }
                        break;
                    case "INSP":
                    case "Inspection":
                        {
                            using (Bitmap bitmap = m_imgSource_Color.ToBitmap())
                            {
                                Mat img = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);
                                IF_Util.SetImageChannel1(img);

                                Bitmap imgResult = m_imgSource_Color.ToBitmap();

                                if (chkUseFilter1.Checked)
                                {
                                    int kernelW = int.Parse(txtFilter1_KernelW.Text);
                                    int kernelH = int.Parse(txtFilter1_KernelH.Text);

                                    img = CVisionTools.RunFilter(img, (CVisionTools.CV_FILTER)comboFilter1Type.SelectedIndex, kernelW, kernelH);
                                }

                                if (chkUseFilter2.Checked)
                                {
                                    int kernelW = int.Parse(txtFilter2_KernelW.Text);
                                    int kernelH = int.Parse(txtFilter2_KernelH.Text);

                                    img = CVisionTools.RunFilter(img, (CVisionTools.CV_FILTER)comboFilter2Type.SelectedIndex, kernelW, kernelH);
                                }

                                m_selectedJob.Parameter.CondensorRectWidth = int.Parse(tbCircleRectW.Text);
                                m_selectedJob.Parameter.CondensorRectHeight = int.Parse(tbCircleRectH.Text);
                                m_selectedJob.Parameter.CondensorTypeTB = radioCondensorTB.Checked;
                                m_selectedJob.Parameter.CondensorRadiusOffset = int.Parse(tbCondensorRectRadio.Text);
                                Inspection_Circle(new CogImage8Grey(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img)), comboCondensorPolarity.Text);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnJobAllApply_Click(object sender, EventArgs e)
        {
            JobApply();
        }

        private void JobApply()
        {
            try
            {
                if (m_selectedJob == null)
                    return;
                //string jobName = gridLibrary[2, m_nSelectedArrayIndex].Value.ToString();
                string jobName = gridLibrary.SelectedRows[0].Cells[2].Value.ToString();
                int nSelectedCellIndex = gridLibrary.SelectedCells[0].RowIndex;
                for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                {
                    if (Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i].Name == jobName)
                    {
                        m_nSelectedIndex_Library = i;
                        break;
                    }
                }
                CJob job = m_selectedJob;
                job.HasChanged = true;

                bool bol_ChkName = false;

                for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                {
                    if (Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i].Name == txtPartCode.Text && txtPartCode.Text != m_selectedJob.Name)
                    {
                        bol_ChkName = true;
                        break;
                    }
                }

                if (bol_ChkName)
                {
                    MessageBox.Show($"{txtPartCode.Text} - 똑같은 Name을 가진 Job이 존재합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                int i_GrabIndex = cbJobGrabIndex.SelectedIndex;
                string str_Type = comboAlgorithm.Text;
                string str_JobCode = txtPartCode.Text;
                int i_Sampling = (int)nbJobSamplingCount.Value;
                bool bol_Binary = false; //chkBinary.Checked;
                bool bol_SavePart = false;  //chkSavePart.Checked;
                bool bol_ColorCheck = chkColor.Checked;

                string str_ColorMethod = "-";

                job.Name = txtPartCode.Text;
                job.Type = comboAlgorithm.Text;
                job.GrabIndex = i_GrabIndex;
                job.SamplingCount = i_Sampling;

                if (str_Type == "Pattern")
                {
                    // double dMinScore = double.Parse(tbJobPattern_MinScore.Text);
                    double dAcceptScore = double.Parse(tbJobPattern_AcceptScore.Text);


                    job.MasterCount = int.Parse(tbPatternMasterCount.Text.ToString());
                    job.MinScore = double.Parse(tbJobPattern_MinScore.Text.ToString());

                    if (bol_ColorCheck)
                    {
                        m_selectedJob.CCoordinate = (CJob.ColorCoordinate)cboPatternColorCoordinate.SelectedIndex - 1;
                        m_selectedJob.CMethod = (CJob.ColorMethod)cboPatternColorAlg.SelectedIndex - 1;
                        str_ColorMethod = $"{cboPatternColorCoordinate.SelectedItem}/{cboPatternColorAlg.SelectedItem}";
                    }
                    m_selectedJob.ChkColor = bol_ColorCheck;
                    m_selectedJob.MasterCount = int.Parse(tbPatternMasterCount.Text.ToString());
                    CCogTool_PMAlign PMAlign = null;

                    if (comboJobPattern_PatternType.Text == "Main") { PMAlign = job.Tool; job.Tool.Tool.RunParams.AcceptThreshold = dAcceptScore; }
                    else if (comboJobPattern_PatternType.Text == "Sub1") { PMAlign = job.SubTool1; job.SubTool1.Tool.RunParams.AcceptThreshold = dAcceptScore; }
                    else if (comboJobPattern_PatternType.Text == "Sub2") { PMAlign = job.SubTool2; job.SubTool2.Tool.RunParams.AcceptThreshold = dAcceptScore; }
                    else if (comboJobPattern_PatternType.Text == "Sub3") { PMAlign = job.SubTool3; job.SubTool3.Tool.RunParams.AcceptThreshold = dAcceptScore; }
                    else if (comboJobPattern_PatternType.Text == "Sub4") { PMAlign = job.SubTool4; job.SubTool4.Tool.RunParams.AcceptThreshold = dAcceptScore; }

                    job.SearchRegion = CVisionCognex.CogRectToRectangle((Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion);

                    m_selectedJob.Parameter.EyeD_UseColorInsp = chkJobPattern_ColorEx.Checked;
                    m_selectedJob.Parameter.EyeD_CorrectColor = comboCorrectColorEx.Text;
                    if (m_selectedJob.Parameter.EyeD_CorrectColor != null && comboCorrectColorEx.Items.Contains(m_selectedJob.Parameter.EyeD_CorrectColor) == false) comboCorrectColorEx.Items.Add(m_selectedJob.Parameter.EyeD_CorrectColor);
                }
                else if (str_Type == "Color")
                {
                    m_selectedJob.CCoordinate = (CJob.ColorCoordinate)cboColorCoordinate.SelectedIndex - 1;
                    m_selectedJob.CMethod = (CJob.ColorMethod)cboColorAlg.SelectedIndex - 1;
                    str_ColorMethod = $"{m_selectedJob.CCoordinate}/{m_selectedJob.CMethod}";
                    m_selectedJob.SearchRegion = CVisionCognex.CogRectToRectangle(Roi_ColorSearchRegion);
                    m_selectedJob.valueRect = CVisionCognex.CogRectToRectangle(Roi_ColorVAlues);

                    m_selectedJob.RangeAreaMax = int.Parse(lbColorMaxArea.Text);
                    m_selectedJob.RangeAreaMin = int.Parse(lbColorMinArea.Text);

                }
                else if (str_Type == "Condensor")
                {
                    m_selectedJob.Parameter.CondensorPolarity = comboCondensorPolarity.Text;
                    m_selectedJob.Parameter.CondensorTypeTB = radioCondensorTB.Checked;
                    m_selectedJob.Parameter.CondensorRectWidth = int.Parse(tbCircleRectW.Text);
                    m_selectedJob.Parameter.CondensorRectHeight = int.Parse(tbCircleRectH.Text);

                    CogCaliperScorerPositionNeg scorer = new CogCaliperScorerPositionNeg();
                    m_selectedJob.Find_Circle.RunParams.CaliperRunParams.SingleEdgeScorers.Clear();
                    scorer.Enabled = true;
                    m_selectedJob.Find_Circle.RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);

                    m_selectedJob.Find_Circle.RunParams.NumToIgnore = int.Parse(tbIgnoreCount.Text);
                    m_selectedJob.Find_Circle.RunParams.DecrementNumToIgnore = true;
                    m_selectedJob.Find_Circle.RunParams.CaliperRunParams.ContrastThreshold = int.Parse(tbCircleContrast.Text);
                    m_selectedJob.Find_Circle.RunParams.CaliperRunParams.FilterHalfSizeInPixels = int.Parse(tbCircleThickness.Text);
                    m_selectedJob.Parameter.CondensorRadiusOffset = int.Parse(tbCondensorRectRadio.Text);
                    job.Parameter.CondensorPolarity = comboCondensorPolarity.SelectedItem.ToString();

                    m_selectedJob.Parameter.DistanceAngleMax = double.Parse(string.IsNullOrEmpty(tbAngleMaxValue.Text.ToString()) ? "0" : tbAngleMaxValue.Text.ToString());
                    m_selectedJob.Parameter.DistanceAngleMin = double.Parse(string.IsNullOrEmpty(tbAngleMinValue.Text.ToString()) ? "0" : tbAngleMinValue.Text.ToString());
                    m_selectedJob.Parameter.DistanceXMax = double.Parse(string.IsNullOrEmpty(tbXMaxValue.Text.ToString()) ? "0" : tbXMaxValue.Text.ToString());
                    m_selectedJob.Parameter.DistanceYMax = double.Parse(string.IsNullOrEmpty(tbYMaxValue.Text.ToString()) ? "0" : tbYMaxValue.Text.ToString());
                    m_selectedJob.Parameter.DistanceXMin = double.Parse(string.IsNullOrEmpty(tbXMaxValue.Text.ToString()) ? "0" : tbXMinValue.Text.ToString());
                    m_selectedJob.Parameter.DistanceYMin = double.Parse(string.IsNullOrEmpty(tbYMaxValue.Text.ToString()) ? "0" : tbYMinValue.Text.ToString());

                    m_selectedJob.Parameter.UseCondensorDist = chkCondensor_UseDist.Checked;

                    m_selectedJob.Parameter.UseDistanceAngle = cbAngle.Checked;
                    m_selectedJob.Parameter.UseDistanceX = cbXValue.Checked;
                    m_selectedJob.Parameter.UseDistanceY = cbYValue.Checked;

                }
                else if (str_Type == "Distance")
                {
                    m_selectedJob.Find_Line.RunParams.CaliperRunParams.ContrastThreshold = int.Parse(tbLineEdgeContrast.Text.ToString());
                    m_selectedJob.Find_Line.RunParams.CaliperRunParams.FilterHalfSizeInPixels = (int)numericDistanceThickness.Value;
                    m_selectedJob.Find_Line.RunParams.NumCalipers = (int)numericDistanceSamplingCount.Value;

                    if (comboLineEdgePolarity.Text == "Dark → Light") m_selectedJob.Find_Line.RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight;
                    else m_selectedJob.Find_Line.RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;

                    m_selectedJob.Find_Line.RunParams.CaliperRunParams.SingleEdgeScorers.Clear();
                    if (comboLineEdgeScorer.Text == "Contrast")
                    {
                        CogCaliperScorerContrast scorer = new CogCaliperScorerContrast();
                        scorer.Enabled = true;
                        m_selectedJob.Find_Line.RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
                    }
                    else if (comboLineEdgeScorer.Text == "Position (From End)")
                    {
                        CogCaliperScorerPosition scorer = new CogCaliperScorerPosition();
                        scorer.Enabled = true;
                        m_selectedJob.Find_Line.RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
                    }
                    else if (comboLineEdgeScorer.Text == "Position (From Begin)")
                    {
                        CogCaliperScorerPositionNeg scorer = new CogCaliperScorerPositionNeg();
                        scorer.Enabled = true;
                        m_selectedJob.Find_Line.RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
                    }

                    m_selectedJob.Parameter.DistanceAngleMax = double.Parse(string.IsNullOrEmpty(tbAngleMaxValue.Text.ToString()) ? "0" : tbAngleMaxValue.Text.ToString());
                    m_selectedJob.Parameter.DistanceAngleMin = double.Parse(string.IsNullOrEmpty(tbAngleMinValue.Text.ToString()) ? "0" : tbAngleMinValue.Text.ToString());
                    m_selectedJob.Parameter.DistanceXMax = double.Parse(string.IsNullOrEmpty(tbXMaxValue.Text.ToString()) ? "0" : tbXMaxValue.Text.ToString());
                    m_selectedJob.Parameter.DistanceYMax = double.Parse(string.IsNullOrEmpty(tbYMaxValue.Text.ToString()) ? "0" : tbYMaxValue.Text.ToString());
                    m_selectedJob.Parameter.DistanceXMin = double.Parse(string.IsNullOrEmpty(tbXMaxValue.Text.ToString()) ? "0" : tbXMinValue.Text.ToString());
                    m_selectedJob.Parameter.DistanceYMin = double.Parse(string.IsNullOrEmpty(tbYMaxValue.Text.ToString()) ? "0" : tbYMinValue.Text.ToString());
                    m_selectedJob.Parameter.UseDistanceAngle = cbAngle.Checked;
                    m_selectedJob.Parameter.UseDistanceX = cbXValue.Checked;
                    m_selectedJob.Parameter.UseDistanceY = cbYValue.Checked;

                }
                else if (str_Type == "Blob")
                {
                    // 각 설정 값들 job Data에 갱신..
                    m_selectedJob.Fin_InspecTool.BlobAreaMin = int.Parse(tbAreaMin.Text);
                    m_selectedJob.Fin_InspecTool.BlobAreaMax = int.Parse(tbAreaMax.Text);
                    m_selectedJob.Fin_InspecTool.BlobThreshold = int.Parse(txtBlobThreshold.Text);
                    m_selectedJob.Fin_InspecTool.BlobThresholdInv = chkThresholdInv.Checked;
                    m_selectedJob.Fin_InspecTool.FINFIND_MatchingTool.m_Score_Min = double.Parse(txt_PinMatchingScoreMin.Text);
                    m_selectedJob.nPatternIndex = 0;
                }
                else if (str_Type == "EYE-D")
                {
                    if (m_selectedJob.Parameter.EyeD_ModelName == "")
                    {
                        IF_Util.ShowMessageBox("ERROR", "Model Name is Empty");
                    }
                    if (cbRotateImageAngle.SelectedIndex != null)
                    {
                        m_selectedJob.Parameter.EyeD_ImageRotateAngle = 90 * cbRotateImageAngle.SelectedIndex;
                    }
                    m_selectedJob.Parameter.EyeD_ModelName = comboEyeDModelName.Text;
                    m_selectedJob.Parameter.EyeD_InferType = comboEyeDInferType.Text;
                    m_selectedJob.Parameter.EyeD_MasterCount = (int)numericEyeDOkCount.Value;
                    m_selectedJob.Parameter.EyeD_MinScore = txtEyeDMinScore.DoubleValue;
                    m_selectedJob.Parameter.EyeD_MaxCount = txtEyeDMaxCount.IntValue;
                    m_selectedJob.Parameter.EyeD_CorrectAnswer = txtEyeDCorrectAnswer.Text;

                    m_selectedJob.Parameter.DistanceAngleMax = double.Parse(string.IsNullOrEmpty(tbAngleMaxValue.Text.ToString()) ? "0" : tbAngleMaxValue.Text.ToString());
                    m_selectedJob.Parameter.DistanceAngleMin = double.Parse(string.IsNullOrEmpty(tbAngleMinValue.Text.ToString()) ? "0" : tbAngleMinValue.Text.ToString());
                    m_selectedJob.Parameter.DistanceXMax = double.Parse(string.IsNullOrEmpty(tbXMaxValue.Text.ToString()) ? "0" : tbXMaxValue.Text.ToString());
                    m_selectedJob.Parameter.DistanceYMax = double.Parse(string.IsNullOrEmpty(tbYMaxValue.Text.ToString()) ? "0" : tbYMaxValue.Text.ToString());
                    m_selectedJob.Parameter.DistanceXMin = double.Parse(string.IsNullOrEmpty(tbXMaxValue.Text.ToString()) ? "0" : tbXMinValue.Text.ToString());
                    m_selectedJob.Parameter.DistanceYMin = double.Parse(string.IsNullOrEmpty(tbYMaxValue.Text.ToString()) ? "0" : tbYMinValue.Text.ToString());

                    m_selectedJob.Parameter.EyeD_UseDistance = chkEyeD_UseDist.Checked;

                    m_selectedJob.Parameter.UseDistanceAngle = cbAngle.Checked;
                    m_selectedJob.Parameter.UseDistanceX = cbXValue.Checked;
                    m_selectedJob.Parameter.UseDistanceY = cbYValue.Checked;

                    m_selectedJob.Parameter.EyeD_UseColorInsp = chkEyeD_UseColor.Checked;
                    m_selectedJob.Parameter.EyeD_CorrectColor = comboCorrectColorEx.Text;
                    m_selectedJob.Parameter.EyeD_UseSpecRegion = chkJobEyeD_UseSpecRegion.Checked;
                    if (m_selectedJob.Parameter.EyeD_CorrectColor != null && comboCorrectColorEx.Items.Contains(m_selectedJob.Parameter.EyeD_CorrectColor) == false) comboCorrectColorEx.Items.Add(m_selectedJob.Parameter.EyeD_CorrectColor);
                }
                else if (str_Type == "ColorEx")
                {
                    m_selectedJob.Parameter.ColorEx_SimpleMode = chkColorEx_SimpleMode.Checked;

                    if (radioColorEx_Range15.Checked) m_selectedJob.Parameter.ColorEx_Range = 15;
                    if (radioColorEx_Range30.Checked) m_selectedJob.Parameter.ColorEx_Range = 30;
                    if (radioColorEx_Range45.Checked) m_selectedJob.Parameter.ColorEx_Range = 45;

                    Color masterColor = Color.FromArgb(txtColorEx_R.IntValue, txtColorEx_G.IntValue, txtColorEx_B.IntValue);
                    m_selectedJob.Parameter.ColorEx_MasterColor = new ColorNode("",
                        masterColor.R - m_selectedJob.Parameter.ColorEx_Range,
                        masterColor.G - m_selectedJob.Parameter.ColorEx_Range,
                        masterColor.B - m_selectedJob.Parameter.ColorEx_Range,
                        masterColor.R + m_selectedJob.Parameter.ColorEx_Range,
                        masterColor.G + m_selectedJob.Parameter.ColorEx_Range,
                        masterColor.B + m_selectedJob.Parameter.ColorEx_Range
                        );

                    m_selectedJob.Parameter.EyeD_CorrectColor = comboCorrectColorEx.Text;
                    if (m_selectedJob.Parameter.EyeD_CorrectColor != null && comboCorrectColorEx.Items.Contains(m_selectedJob.Parameter.EyeD_CorrectColor) == false) comboCorrectColorEx.Items.Add(m_selectedJob.Parameter.EyeD_CorrectColor);
                }
                else if (str_Type == "Pin")
                {
                    m_selectedJob.Parameter.Pin_OkCount = (int)nb_Pin_OkCount.Value;
                    m_selectedJob.Parameter.Pin_AreaMax = (int)nb_Pin_AreaMax.Value;
                    m_selectedJob.Parameter.Pin_AreaMin = (int)nb_Pin_AreaMin.Value;
                    m_selectedJob.Parameter.Pin_SpecRoiWidth = (int)nb_Pin_SpecRoi_Width.Value;
                    m_selectedJob.Parameter.Pin_SpecRoiHeight = (int)nb_Pin_SpecRoi_Height.Value;
                    m_selectedJob.Parameter.Pin_Threshold = (int)nb_Pin_Threshold.Value;
                    m_selectedJob.Parameter.Pin_BinaryInv = chk_Pin_BinaryInv.Checked;
                    m_selectedJob.Parameter.Pin_ColorMatching = chkJobPin_UseColorMatching.Checked;
                }
                else if (str_Type == "Connector")
                {
                    m_selectedJob.Parameter.Connector_ScoreMin = txtJobConnector_Score.DoubleValue;
                    m_selectedJob.Parameter.Connector_Type_LR = radioJobConnector_LR.Checked;
                    m_selectedJob.Parameter.Connector_AreaMin = txtJobConnector_AreaMin.IntValue;
                    m_selectedJob.Parameter.Connector_AreaMax = txtJobConnector_AreaMax.IntValue;
                    m_selectedJob.Parameter.Connector_BoxWidth = txtJobConnector_BoxWidth.IntValue;
                    m_selectedJob.Parameter.Connector_BoxHeight = txtJobConnector_BoxHeight.IntValue;
                    m_selectedJob.Parameter.Connector_Threshold = (int)txtJobConnector_Threshold.DoubleValue;
                    m_selectedJob.Parameter.Connector_BinaryInv = chkJobConnector_BinInv.Checked;
                    m_selectedJob.Parameter.Connector_AreaOK = txtJobConnector_OKArea.IntValue;
                    m_selectedJob.Parameter.Connector_LargeFirst = radioJobConnector_AreaLT.Checked;
                }

                m_selectedJob.useBinary = bol_Binary;
                m_selectedJob.isSavePart = bol_SavePart;
                m_selectedJob.Judge_NaisNg = chkJobPattern_JudgeMode.Checked;

                string str_Mode = "";
                if (chkJobPattern_JudgeMode.Checked)
                    str_Mode = $"N/A:NG";
                else
                    str_Mode = $"N/A:OK";

                //m_selectedJob.LC_ReadUse = cb_LCReadUse.Checked;
                bool lcReaduse = m_selectedJob.LC_ReadUse;
                int lcMasterCount = m_selectedJob.MasterCount;

                gridLibrary.Rows[nSelectedCellIndex].Cells[0].Value = m_nSelectedIndex_Library + 1;
                gridLibrary.Rows[nSelectedCellIndex].Cells[1].Value = gridLibrary.Rows[nSelectedCellIndex].Cells[1].Value; //Enabled
                gridLibrary.Rows[nSelectedCellIndex].Cells[2].Value = str_JobCode;                                               //Name
                gridLibrary.Rows[nSelectedCellIndex].Cells[3].Value = i_GrabIndex;                                               //GrabIndex
                gridLibrary.Rows[nSelectedCellIndex].Cells[4].Value = str_Type;                                                  //Type
                gridLibrary.Rows[nSelectedCellIndex].Cells[5].Value = str_Mode;                                                  //Mode
                gridLibrary.Rows[nSelectedCellIndex].Cells[7].Value = str_ColorMethod;                                            //ColorMethod

                //송현수 -> 안춘길 : 정합성 체크 필요
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Enabled = bool.Parse(gridLibrary.Rows[nSelectedCellIndex].Cells[1].Value.ToString());
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Name = str_JobCode;
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].GrabIndex = i_GrabIndex;
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Type = str_Type;
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Judge_NaisNg = chkJobPattern_JudgeMode.Checked;
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].ChkColor = bol_ColorCheck;
                //Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].CCoordinate = (CJob.ColorCoordinate)cboPatternColorCoordinate.SelectedIndex - 1;
                //Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].CMethod = (CJob.ColorMethod)cboPatternColorAlg.SelectedIndex - 1;
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].useBinary = bol_Binary;
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].isSavePart = bol_SavePart;
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].LC_ReadUse = lcReaduse;
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].MasterCount = lcMasterCount;

                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.UseFilter1 = chkUseFilter1.Checked;
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.UseFilter2 = chkUseFilter2.Checked;
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.Filter1 = (CVisionTools.CV_FILTER)comboFilter1Type.SelectedIndex;
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.Filter1_Kernel_W = int.Parse(txtFilter1_KernelW.Text);
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.Filter1_Kernel_H = int.Parse(txtFilter1_KernelH.Text);
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.Filter2 = (CVisionTools.CV_FILTER)comboFilter2Type.SelectedIndex;
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.Filter2_Kernel_W = int.Parse(txtFilter2_KernelW.Text);
                Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[m_nSelectedIndex_Library].Parameter.Filter2_Kernel_H = int.Parse(txtFilter2_KernelH.Text);

                job.valueRect = CVisionCognex.CogRectToRectangle(Roi_ColorVAlues);
                string tempName = job.Name;

                string Jubdge = $"N/A:NG";
                if (!job.Judge_NaisNg) Jubdge = $"N/A:OK";
                gridLibrary.SelectedRows[0].Cells[2].Value = job.Name.ToString();
                gridLibrary.SelectedRows[0].Cells[3].Value = job.GrabIndex;
                gridLibrary.SelectedRows[0].Cells[4].Value = job.Type.ToString();
                gridLibrary.SelectedRows[0].Cells[5].Value = Jubdge;

                lbSelectFull.BackColor = DEFINE_COMMON.COLOR_BLACK30;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void radioFiducial_1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioFiducial_1.Checked)
                {
                    if (_selectedFiducialLibrary.Fiducial1.ImageTemplate != null)
                    {
                        cogDisplay_Fiducial_Pattern.Image = new CogImage8Grey(_selectedFiducialLibrary.Fiducial1.ImageTemplate);
                        cogDisplay_Fiducial_Pattern.Fit(true);
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void radioFiducial_2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioFiducial_2.Checked)
                {
                    if (_selectedFiducialLibrary != null)
                    {
                        if (_selectedFiducialLibrary.Fiducial2.ImageTemplate != null)
                        {
                            cogDisplay_Fiducial_Pattern.Image = new CogImage8Grey(_selectedFiducialLibrary.Fiducial2.ImageTemplate);
                            cogDisplay_Fiducial_Pattern.Fit(true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        //송현수 -> 안춘길 : 새로 구현
        private void OnClickAlgorithm_Distance(object sender, EventArgs e)
        {
            string strIndex = (sender as UIButton).Text;

            try
            {
                CogFindLineTool tool = m_selectedJob.Find_Line;

                switch (strIndex)
                {
                    case "Roi":
                    case "ROI":
                        {
                            CogRectangle cogSearchRegion = new CogRectangle();
                            if (m_selectedJob.SearchRegion.Width != 0 && m_selectedJob.SearchRegion.Height != 0)
                                cogSearchRegion = CConverter.RectToCogRect(m_selectedJob.SearchRegion);
                            if (cogSearchRegion.Width == 0) cogSearchRegion.Width = 100;
                            if (cogSearchRegion.Height == 0) cogSearchRegion.Height = 100;

                            cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.Color = CogColorConstants.Red;
                            cogSearchRegion.SelectedColor = CogColorConstants.Red;

                            DispMain.InteractiveGraphics.Add(cogSearchRegion, "Search", false);

                            CogGraphicCollection cogRegions;
                            ICogRecord cogRecord;

                            tool.InputImage = new CogImage8Grey(m_imgSource_Mono);
                            tool.CurrentRecordEnable = CogFindLineCurrentRecordConstants.All;

                            cogRecord = tool.CreateCurrentRecord();
                            CogLineSegment cogSegment = (CogLineSegment)cogRecord.SubRecords["InputImage"].SubRecords["ExpectedShapeSegment"].Content;
                            cogRegions = (CogGraphicCollection)cogRecord.SubRecords["InputImage"].SubRecords["CaliperRegions"].Content;
                            DispMain.InteractiveGraphics.Add(cogSegment, "ExpectedShapeSegment", false);

                            if (cogRegions == null) return;
                            foreach (ICogGraphic g in cogRegions) DispMain.InteractiveGraphics.Add((ICogGraphicInteractive)g, "CaliperRegions", false);

                            btnJobDistance_Roi.Text = "Complete";
                        }
                        break;
                    case "Complete":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                            CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            m_selectedJob.SearchRegion = CConverter.CogRectToRect(roi);
                            btnJobDistance_Roi.Text = "Roi";
                        }
                        break;
                    case "FIND":
                    case "Find":
                        {
                            tool.InputImage = new CogImage8Grey(m_imgSource_Mono);
                            tool.Run();

                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            if (tool.Results != null && tool.Results.Count > 0)
                            {
                                for (int i = 0; i < tool.Results.Count; i++)
                                {
                                    DispMain.StaticGraphics.Add(tool.Results[i].CreateResultGraphics(CogFindLineResultGraphicConstants.All), "RESULT");
                                }

                                CogLine resultGraphic = tool.Results.GetLine();

                                if (resultGraphic != null)
                                {
                                    double dDegree = IF_Util.rad2deg(resultGraphic.Rotation);
                                    DispMain.StaticGraphics.Add(resultGraphic, "Line");
                                    CCognexUtil.DrawText(DispMain, new Point2d(200, 100), $"Degree : {dDegree.ToString("F3")}º", CogColorConstants.Blue);
                                }
                                else
                                {
                                    IF_Util.ShowMessageBox("Error", "Find Line Results Empty");
                                }
                            }
                            else
                            {
                                IF_Util.ShowMessageBox("Error", "Find Line Results Empty");
                            }
                        }
                        break;
                    case "INSP":
                    case "Inspection":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            Point2d pos = FindFiducialMarkInAarry();

                            (bool, CogLine) result = CCognexUtil.FindLine(tool, m_imgSource_Mono, out CogGraphicCollection g, true);
                            Point2d lineCenter = new Point2d(result.Item2.X, result.Item2.Y);
                            //Point2d lineCenter = new Point2d();
                            CogLine resultGraphic = tool.Results.GetLine();

                            CogLineSegment lineX = new CogLineSegment();
                            lineX.StartX = pos.X;
                            lineX.StartY = pos.Y;
                            lineX.EndX = lineCenter.X;
                            lineX.EndY = pos.Y;
                            lineX.Color = CogColorConstants.Red;

                            CogLineSegment lineY = new CogLineSegment();
                            lineY.StartX = pos.X;
                            lineY.StartY = pos.Y;
                            lineY.EndX = pos.X;
                            lineY.EndY = lineCenter.Y;
                            lineY.Color = CogColorConstants.Red;


                            double distanceX = lineX.Length;
                            double distanceY = lineY.Length;

                            int posX = (int)tool.RunParams.ExpectedLineSegment.StartX;
                            int posY = (int)tool.RunParams.ExpectedLineSegment.StartY;
                            if (resultGraphic != null)
                            {
                                double dDegree = IF_Util.rad2deg(resultGraphic.Rotation);
                                //cogDisplay_Source.StaticGraphics.Add(resultGraphic, "Line");
                                //CCognexUtil.DrawText(cogDisplay_Source, new Point2d(200, 100), $"Degree : {dDegree.ToString("F3")}º", CogColorConstants.Blue);
                                if (cbAngle.Checked)
                                {
                                    if (dDegree > double.Parse(tbAngleMinValue.Text.ToString()) && dDegree < double.Parse(tbAngleMaxValue.Text.ToString()))
                                    {

                                        CCognexUtil.DrawText(DispMain, new Point2d(posX, posY), $"Degree : {dDegree.ToString("F3")}º", CogColorConstants.Blue);
                                    }
                                    else
                                    {
                                        CCognexUtil.DrawText(DispMain, new Point2d(posX, posY), $"Degree : {dDegree.ToString("F3")}º", CogColorConstants.Red);
                                    }
                                }
                                if (cbXValue.Checked)
                                {
                                    if (distanceX > int.Parse(tbXMinValue.Text.ToString()) && distanceX < int.Parse(tbXMaxValue.Text.ToString()))
                                    {
                                        CCognexUtil.DrawText(DispMain, new Point2d(posX, posY + 20), $"X : {distanceX.ToString("F3")}px", CogColorConstants.Blue);
                                        lineX.Color = CogColorConstants.Blue;
                                    }
                                    else
                                    {
                                        CCognexUtil.DrawText(DispMain, new Point2d(posX, posY + 20), $"X : {distanceX.ToString("F3")}px", CogColorConstants.Red);
                                        lineX.Color = CogColorConstants.Blue;
                                    }

                                    g.Add(lineX);
                                }
                                if (cbYValue.Checked)
                                {
                                    if (distanceY > int.Parse(tbYMinValue.Text.ToString()) && distanceY < int.Parse(tbYMaxValue.Text.ToString()))
                                    {
                                        CCognexUtil.DrawText(DispMain, new Point2d(posX, posY + 40), $"Y : {distanceY.ToString("F3")}px", CogColorConstants.Blue);
                                        lineY.Color = CogColorConstants.Blue;
                                    }
                                    else
                                    {
                                        CCognexUtil.DrawText(DispMain, new Point2d(posX, posY + 40), $"Y : {distanceY.ToString("F3")}px", CogColorConstants.Red);
                                        lineY.Color = CogColorConstants.Blue;
                                    }

                                    g.Add(lineY);
                                }



                                DispMain.StaticGraphics.AddList(g, "");

                            }
                            else
                            {
                                IF_Util.ShowMessageBox("Error", "Find Line Results Empty");
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void comboAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = comboAlgorithm.Text.ToString();

            DispMain.InteractiveGraphics.Clear();
            DispMain.StaticGraphics.Clear();

            for (int i = 0; i < tcAlgorithm.TabPages.Count; i++)
            {
                if (string.Equals(tcAlgorithm.TabPages[i].Text, index))
                {
                    tcAlgorithm.SelectedTab = tcAlgorithm.TabPages[i];
                    break;
                }
            }
        }

        private void btnSave_QR_Click(object sender, EventArgs e)
        {
            try
            {
                if (IF_Util.ShowMessageBox("QR", "Would you like to save the QR Region?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    //Global.System.Recipe.FiducialLibrary.FiducialGrabIndex = int.Parse(comboGrabIndex_Fiducial.Text);
                    Global.Setting.Recipe.Save(Global.Instance.System.Recipe.Name);
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }

        }

        private void tcAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_selectedJob == null) return;

            if (tcAlgorithm.SelectedTab.Text != m_selectedJob.Type)
            {

                UINotifier.Show("The selected type is different from the current job type.", UINotifierType.INFO, "Notifier", false);
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            DispMain.Zoom += 0.01;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            DispMain.Zoom -= 0.01;
        }

        private void btnZoomFit_Click(object sender, EventArgs e)
        {
            DispMain.Fit(false);
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            try
            {
                CJob job = m_selectedJob;

                int arrayTo = int.Parse(comboCloneTo.Text);

                if (IF_Util.ShowMessageBox("Clone", $"Do you want to Clone \nTo Array {arrayTo} Job : {job.Name}?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    Global.System.Recipe.JobManager[arrayTo - 1].Jobs.Add(job.Clone());
                    Global.System.Recipe.JobManager[arrayTo - 1].Jobs[Global.System.Recipe.JobManager[arrayTo - 1].Jobs.Count - 1].Name += $"-{DateTime.Now.ToString("yyMMdd_HHmmss")}";
                    Console.WriteLine(object.ReferenceEquals(Global.System.Recipe.JobManager[arrayTo - 1].Jobs.Last(), job));

                    InitJobs();
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnCondensorAutoRegion_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnJobCondensor_Roi.Text == "Roi")
                {
                    IF_Util.ShowMessageBox("Error", "Click first Roi Button (Condensor)");
                    return;
                }

                int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                m_selectedJob.Find_Circle.RunParams.ExpectedCircularArc.CenterX = roi.CenterX;
                m_selectedJob.Find_Circle.RunParams.ExpectedCircularArc.CenterY = roi.CenterY;
                m_selectedJob.Find_Circle.RunParams.ExpectedCircularArc.Radius = roi.Width / 4;

                string polarity = comboCondensorPolarity.Text;

                if (polarity == "T")
                {
                    m_selectedJob.Find_Circle.RunParams.ExpectedCircularArc.AngleStart = (Math.PI * -65.0D / 180.0D);
                    m_selectedJob.Find_Circle.RunParams.ExpectedCircularArc.AngleSpan = (Math.PI * 305.0D / 180.0D);
                }
                else if (polarity == "B")
                {
                    m_selectedJob.Find_Circle.RunParams.ExpectedCircularArc.AngleStart = (Math.PI * 100.0D / 180.0D);
                    m_selectedJob.Find_Circle.RunParams.ExpectedCircularArc.AngleSpan = (Math.PI * 305.0D / 180.0D);
                }
                else if (polarity == "L")
                {
                    m_selectedJob.Find_Circle.RunParams.ExpectedCircularArc.AngleStart = (Math.PI * -150.0D / 180.0D);
                    m_selectedJob.Find_Circle.RunParams.ExpectedCircularArc.AngleSpan = (Math.PI * 305.0D / 180.0D);
                }
                else if (polarity == "R")
                {
                    m_selectedJob.Find_Circle.RunParams.ExpectedCircularArc.AngleStart = (Math.PI * 30.0D / 180.0D);
                    m_selectedJob.Find_Circle.RunParams.ExpectedCircularArc.AngleSpan = (Math.PI * 305.0D / 180.0D);
                }

                m_selectedJob.Find_Circle.RunParams.CaliperSearchLength = roi.Width * 2;
                m_selectedJob.Find_Circle.RunParams.CaliperProjectionLength = 30;
                m_selectedJob.SearchRegion = CConverter.CogRectToRect(roi);
                btnJobCondensor_Roi.Text = "Roi";
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void gridRecipe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridRecipe.SelectedRows.Count > 0)
            {
                lblSelecetdRecipeName.Text = gridRecipe.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        public void InitRecipeList()
        {
            gridRecipe.Rows.Clear();

            List<string> listRecipe = new List<string>();

            string strpath = $"{Global.m_MainPJTRoot}\\RECIPE";
            DirectoryInfo di = new DirectoryInfo(strpath);
            if (di.Exists)
            {
                DirectoryInfo[] diRecipies = di.GetDirectories();

                for (int i = 0; i < diRecipies.Length; i++)
                {
                    string strRecipe = diRecipies[i].Name;
                    listRecipe.Add(strRecipe);
                }
            }

            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();

            for (int i = 0; i < listRecipe.Count; i++)
            {
                string strName = listRecipe[i];
                string strParameterPath = $"{strpath}\\{strName}\\JOBS\\Parameter.xml";
                string strCode = "";

                if (File.Exists(strParameterPath))
                {
                    XmlTextReader xmlReader = new XmlTextReader(strParameterPath);

                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType == XmlNodeType.Element)
                        {
                            switch (xmlReader.Name)
                            {
                                case "PbaCode": if (xmlReader.Read()) strCode = xmlReader.Value; break;
                            }
                        }
                    }

                    xmlReader.Close();
                }
                else
                {
                    strParameterPath = $"{strpath}\\{strName}\\Parameter.xml";

                    XmlTextReader xmlReader = new XmlTextReader(strParameterPath);

                    if (File.Exists(strParameterPath) == false) continue;

                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType == XmlNodeType.Element)
                        {
                            switch (xmlReader.Name)
                            {
                                case "PbaCode": if (xmlReader.Read()) strCode = xmlReader.Value; break;
                            }
                        }
                    }

                    xmlReader.Close();
                }

                Global.Instance.System.Recipe.LoadConfig();
                gridRecipe.Rows.Add((gridRecipe.Rows.Count + 1), strName, strCode);
            }


            CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
        }

        private void btnRecipeRefresh_Click(object sender, EventArgs e)
        {
            InitRecipeList();
        }

        private void btnGetFiducialInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string recipeName = lblSelecetdRecipeName.Text;

                if (IF_Util.ShowMessageBox("Clone", $"Do you want to Load Fiducial and QR Recipe from {recipeName}?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    string recipePath = $"{Global.m_MainPJTRoot}\\RECIPE\\{recipeName}";

                    if (File.Exists(recipePath + "\\Fiducial1.bmp")) Global.System.Recipe.FiducialLibrary.Fiducial1.ImageTemplate = IF_Util.SafetyImageLoad(recipePath + "\\Fiducial1.bmp");
                    if (File.Exists(recipePath + "\\Fiducial2.bmp")) Global.System.Recipe.FiducialLibrary.Fiducial2.ImageTemplate = IF_Util.SafetyImageLoad(recipePath + "\\Fiducial2.bmp");

                    Global.Setting.Recipe = Global.Setting.Recipe.Load(recipeName);
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }

        }

        private void btnResetMaster_Click(object sender, EventArgs e)
        {
            try
            {
                // 현재 마스터 데이터 변경 메세지 박스...
                if (IF_Util.ShowMessageBox("Master", "Would you RESET Master Degree?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    _selectedFiducialLibrary.MasterAngle = 0;
                    lblDegreeMaster.Text = $"{_selectedFiducialLibrary.MasterAngle:F5}";
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }
        private void btnAdjustALlFiducialMark_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                Bitmap fiducialImg1 = null;
                Bitmap fiducialImg2 = null;
                Setting_Recipe tempRecipe = new Setting_Recipe();
                //FBD.SelectedPath = $"{Application.StartupPath}\\PBA_Image\\";
                FBD.SelectedPath = $"D:\\01_PBA\\PBA_IMAGE\\5316H\\";

                //if (FBD.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolderPath = "C:\\exe_Vision_PBA\\RECIPE";
                    string recipePath = $"{Global.m_MainPJTRoot}\\RECIPE\\{Global.System.Recipe.Name}";
                    string[] fileEntries = Directory.GetDirectories(selectedFolderPath);
                    tempRecipe = tempRecipe.Load(Global.System.Recipe.Name);
                    foreach (var item in fileEntries)
                    {
                        if (!File.Exists(item + "\\Fiducial1.bmp") || !File.Exists(item + "\\Fiducial2.bmp"))
                        {
                            string patharray = Path.GetFileName(item);
                            tempRecipe.Save(patharray);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void btnRearrange_Click(object sender, EventArgs e)
        {
            CInspJobs[] TempJobManager = new CInspJobs[4];
            int nSelectedIndex = m_nSelectedArrayIndex - 1;
            TempJobManager[nSelectedIndex] = new CInspJobs();
            TempJobManager[nSelectedIndex].Jobs = new List<CJob>();


            for (int i = 0; i < gridLibrary.RowCount; i++)
            {
                for (int j = 0; j < Global.System.Recipe.JobManager[nSelectedIndex].Jobs.Count; j++)
                {
                    if (Global.System.Recipe.JobManager[nSelectedIndex].Jobs[j].Name == gridLibrary.Rows[i].Cells[2].Value.ToString())
                    {

                        TempJobManager[nSelectedIndex].Jobs.Add(Global.System.Recipe.JobManager[nSelectedIndex].Jobs[j]);
                        break;
                    }
                }
            }
            Global.System.Recipe.JobManager[nSelectedIndex] = TempJobManager[nSelectedIndex];
            InitJobs();
        }


        private void btnSaveRecipeEnable_Click(object sender, EventArgs e)
        {
            if (IF_Util.ShowMessageBox("SAVE", "Do you want to save this Recipe Enable") == true)
                Global.Instance.System.Recipe.RecipeEnabledSave();
        }

        private void FormMenu_Vision_KeyDown(object sender, KeyEventArgs e)
        {
            int nWild = 0;
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                btnViewJobs_Click(null, null);
                            }
                            else
                            {
                                pnlHelp.Visible = !pnlHelp.Visible;
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void btnGetEyeDModelNames_Click(object sender, EventArgs e)
        {
            try
            {
                Global.Device.EyeD.Send("[,,GET_MODELS,]\r\n", "");
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            if (btnCross.FillColor == Color.Green)
            {
                btnCross.FillColor = Color.FromArgb(40, 40, 40);
            }
            else
            {
                btnCross.FillColor = Color.Green;
            }
        }

        private void cbJobGrabIndex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnJobEyeD_DistanceInsp_Click(object sender, EventArgs e)
        {
            try
            {
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                using (Mat imgCrop = OpenCvSharp.Extensions.BitmapConverter.ToMat(IF_Util.Crop(m_imgSource_Color.ToBitmap(), m_selectedJob.SearchRegion)).Clone())
                {
                    string modelName = comboEyeDModelName.Text;
                    string inferType = comboEyeDInferType.Text;

                    string uniqueID = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");

                    string imageDir = $"{Application.StartupPath}\\EYED";
                    if (Directory.Exists(imageDir) == false) Directory.CreateDirectory(imageDir);

                    string imagePath = $"{imageDir}\\{modelName}_{inferType}_{DateTime.Now.ToString("yyyyMMdd_HHmmssfff")}.jpg";
                    imgCrop.SaveImage(imagePath);

                    Global.Device.EyeD.Send($"[{modelName},{uniqueID},{inferType},{imagePath}]\r\n", "");

                    Task.Run(() =>
                    {
                        Stopwatch tt = Stopwatch.StartNew();

                        while (tt.ElapsedMilliseconds < 20000)
                        {
                            if (Global.Device.EyeD.RecvResults.ContainsKey(uniqueID))
                            {
                                lblTactTime.Invoke((Action)(() =>
                                {
                                    lblTactTime.Text = $"T/T : {tt.ElapsedMilliseconds}ms";
                                }));

                                //{[20240405_182031471, (relay;0.92;209;44;44;45)]}
                                string resultString = Global.Device.EyeD.RecvResults[uniqueID].ResultString;

                                List<string> resultList = new List<string>();
                                MatchCollection matches = Regex.Matches(resultString, @"\([^()]*\)");

                                // 추출된 내용을 리스트에 추가
                                foreach (Match match in matches)
                                {
                                    resultList.Add(match.Value);
                                }

                                if (resultList.Count > 0)
                                {
                                    string resultInferType = resultList[0];
                                    string bestTag = "";
                                    double bestScore = 0.0D;

                                    for (int i = 1; i < resultList.Count; i++)
                                    {
                                        string value = resultList[i];
                                        double score = 0.0D;

                                        value = value.Replace("(", "");
                                        value = value.Replace(")", "");
                                        string[] values = value.Split(";");

                                        if (string.Equals(resultInferType, "(DET)"))
                                        {
                                            if (values.Length == 6)
                                            {
                                                string tag = values[0];


                                                double.TryParse(values[1], out score);

                                                bool success = true;
                                                success &= int.TryParse(values[2], out int x);
                                                success &= int.TryParse(values[3], out int y);
                                                success &= int.TryParse(values[4], out int w);
                                                success &= int.TryParse(values[5], out int h);

                                                if (success)
                                                {
                                                    Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();

                                                    cogSearchRegion.LineWidthInScreenPixels = 2;
                                                    cogSearchRegion.X = m_selectedJob.SearchRegion.X + x;
                                                    cogSearchRegion.Y = m_selectedJob.SearchRegion.Y + y;
                                                    cogSearchRegion.Width = w;
                                                    cogSearchRegion.Height = h;

                                                    if (m_selectedJob.Parameter.EyeD_MinScore <= score)
                                                    {
                                                        cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Green;
                                                        CCognexUtil.DrawString(DispMain, $"Model : {tag} Score : {score}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Green, 10);
                                                    }
                                                    else
                                                    {
                                                        cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                                                        CCognexUtil.DrawString(DispMain, $"Model : {tag} Score : {score}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Red, 10);
                                                    }

                                                    Point2d pos = FindFiducialMarkInAarry();

                                                    Point2d lineCenter = new Point2d(cogSearchRegion.X, cogSearchRegion.Y);

                                                    CogLineSegment lineX = new CogLineSegment();
                                                    lineX.StartX = pos.X;
                                                    lineX.StartY = pos.Y;
                                                    lineX.EndX = lineCenter.X;
                                                    lineX.EndY = pos.Y;
                                                    lineX.Color = CogColorConstants.Red;

                                                    CogLineSegment lineY = new CogLineSegment();
                                                    lineY.StartX = pos.X;
                                                    lineY.StartY = pos.Y;
                                                    lineY.EndX = pos.X;
                                                    lineY.EndY = lineCenter.Y;
                                                    lineY.Color = CogColorConstants.Red;

                                                    double distanceX = lineX.Length;
                                                    double distanceY = lineY.Length;

                                                    //double dDegree = IF_Util.rad2deg(resultGraphic.Rotation);
                                                    //cogDisplay_Source.StaticGraphics.Add(resultGraphic, "Line");
                                                    //CCognexUtil.DrawText(cogDisplay_Source, new Point2d(200, 100), $"Degree : {dDegree.ToString("F3")}º", CogColorConstants.Blue);
                                                    //if (cbAngle.Checked)
                                                    //{
                                                    //    if (dDegree > double.Parse(tbAngleMinValue.Text.ToString()) && dDegree < double.Parse(tbAngleMaxValue.Text.ToString()))
                                                    //    {

                                                    //        CCognexUtil.DrawText(cogDisplay_Source, new Point2d(posX, posY), $"Degree : {dDegree.ToString("F3")}º", CogColorConstants.Blue);
                                                    //    }
                                                    //    else
                                                    //    {
                                                    //        CCognexUtil.DrawText(cogDisplay_Source, new Point2d(posX, posY), $"Degree : {dDegree.ToString("F3")}º", CogColorConstants.Red);
                                                    //    }
                                                    //}
                                                    if (cbXValue.Checked)
                                                    {
                                                        if (distanceX > int.Parse(tbXMinValue.Text.ToString()) && distanceX < int.Parse(tbXMaxValue.Text.ToString()))
                                                        {
                                                            CCognexUtil.DrawText(DispMain, new Point2d(cogSearchRegion.X, cogSearchRegion.Y + 20), $"X : {distanceX.ToString("F3")}px", CogColorConstants.Blue);
                                                            lineX.Color = CogColorConstants.Blue;
                                                        }
                                                        else
                                                        {
                                                            CCognexUtil.DrawText(DispMain, new Point2d(cogSearchRegion.X, cogSearchRegion.Y + 20), $"X : {distanceX.ToString("F3")}px", CogColorConstants.Red);
                                                            lineX.Color = CogColorConstants.Blue;
                                                        }

                                                        DispMain.StaticGraphics.Add(lineX, "");
                                                    }
                                                    if (cbYValue.Checked)
                                                    {
                                                        if (distanceY > int.Parse(tbYMinValue.Text.ToString()) && distanceY < int.Parse(tbYMaxValue.Text.ToString()))
                                                        {
                                                            CCognexUtil.DrawText(DispMain, new Point2d(cogSearchRegion.X, cogSearchRegion.Y + 40), $"Y : {distanceY.ToString("F3")}px", CogColorConstants.Blue);
                                                            lineY.Color = CogColorConstants.Blue;
                                                        }
                                                        else
                                                        {
                                                            CCognexUtil.DrawText(DispMain, new Point2d(cogSearchRegion.X, cogSearchRegion.Y + 40), $"Y : {distanceY.ToString("F3")}px", CogColorConstants.Red);
                                                            lineY.Color = CogColorConstants.Blue;
                                                        }

                                                        DispMain.StaticGraphics.Add(lineY, "");
                                                    }

                                                    DispMain.InteractiveGraphics.Add(cogSearchRegion, "", false);
                                                }
                                            }
                                        }
                                    }
                                }


                                lblEyeDResult.Invoke((Action)(() =>
                                {
                                    lblEyeDResult.Text = Global.Device.EyeD.RecvResults[uniqueID].ResultString;
                                }));

                                Global.Device.EyeD.RecvResults.TryRemove(uniqueID, out EyeD_Result result);
                                break;
                            }

                            Thread.Sleep(10);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnEyeD_DistSetting_Click(object sender, EventArgs e)
        {
            string index = "Distance";

            for (int i = 0; i < tcAlgorithm.TabPages.Count; i++)
            {
                if (string.Equals(tcAlgorithm.TabPages[i].Text, index))
                {
                    tcAlgorithm.SelectedTab = tcAlgorithm.TabPages[i];
                    break;
                }
            }
        }

        private void btnEyeD_ColorSetting_Click(object sender, EventArgs e)
        {
            if ((sender as UISymbolButton).Name == "uiSymbolButton6")
            {
                FormSettings_ColorList form = new FormSettings_ColorList();
                form.Show();
            }
            else
            {
                string index = "ColorEx";

                for (int i = 0; i < tcAlgorithm.TabPages.Count; i++)
                {
                    if (string.Equals(tcAlgorithm.TabPages[i].Text, index))
                    {
                        tcAlgorithm.SelectedTab = tcAlgorithm.TabPages[i];
                        break;
                    }
                }
            }

        }

        private void btnGetColorList_Click(object sender, EventArgs e)
        {
            try
            {
                comboCorrectColorEx.Items.Clear();

                for (int i = 0; i < Global.Setting.Enviroment.ColorList.ColorNodes.Count; i++)
                {
                    comboCorrectColorEx.Items.Add(Global.Setting.Enviroment.ColorList.ColorNodes[i].Name);
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private async void btnEyeD_ResultColor_Click(object sender, EventArgs e)
        {
            try
            {
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                string modelName = comboEyeDModelName.Text;
                string inferType = comboEyeDInferType.Text;

                Task<Color> taskColor = Task.Run(() =>
                {
                    using (Mat imgCrop = OpenCvSharp.Extensions.BitmapConverter.ToMat(IF_Util.Crop(m_imgSource_Color.ToBitmap(), m_selectedJob.SearchRegion)).Clone())
                    {
                        string uniqueID = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");

                        string imageDir = $"{Application.StartupPath}\\EYED";
                        if (Directory.Exists(imageDir) == false) Directory.CreateDirectory(imageDir);

                        string imagePath = $"{imageDir}\\{modelName}_{inferType}_{DateTime.Now.ToString("yyyyMMdd_HHmmssfff")}.jpg";
                        imgCrop.SaveImage(imagePath);

                        Global.Device.EyeD.Send($"[{modelName},{uniqueID},{inferType},{imagePath}]\r\n", "");

                        Color extractColor = new Color();

                        Stopwatch tt = Stopwatch.StartNew();

                        while (tt.ElapsedMilliseconds < 20000)
                        {
                            if (Global.Device.EyeD.RecvResults.ContainsKey(uniqueID))
                            {
                                //{[20240405_182031471, (relay;0.92;209;44;44;45)]}
                                string resultString = Global.Device.EyeD.RecvResults[uniqueID].ResultString;

                                List<string> resultList = new List<string>();
                                MatchCollection matches = Regex.Matches(resultString, @"\([^()]*\)");

                                // 추출된 내용을 리스트에 추가
                                foreach (Match match in matches)
                                {
                                    resultList.Add(match.Value);
                                }

                                if (resultList.Count > 0)
                                {
                                    string resultInferType = resultList[0];
                                    string bestTag = "";
                                    double bestScore = 0.0D;

                                    for (int i = 1; i < resultList.Count; i++)
                                    {
                                        string value = resultList[i];
                                        double score = 0.0D;

                                        value = value.Replace("(", "");
                                        value = value.Replace(")", "");
                                        string[] values = value.Split(";");

                                        if (values.Length == 6)
                                        {
                                            string tag = values[0];


                                            double.TryParse(values[1], out score);



                                            bool success = true;
                                            success &= int.TryParse(values[2], out int x);
                                            success &= int.TryParse(values[3], out int y);
                                            success &= int.TryParse(values[4], out int w);
                                            success &= int.TryParse(values[5], out int h);

                                            if (success)
                                            {
                                                Scalar scalar = imgCrop.SubMat(new Rect(x, y, w, h)).Mean();

                                                // 평균 색상 값을 BGR 형식으로 각각 추출
                                                byte meanB = (byte)scalar.Val0;
                                                byte meanG = (byte)scalar.Val1;
                                                byte meanR = (byte)scalar.Val2;

                                                extractColor = Color.FromArgb(meanR, meanG, meanB);
                                                string colorStr = $"{meanR},{meanG},{meanB}";
                                                IF_Util.setLabel(lblJobColorEx_ResultColor, colorStr.ToString(), extractColor);

                                                Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();

                                                cogSearchRegion.LineWidthInScreenPixels = 2;
                                                cogSearchRegion.X = m_selectedJob.SearchRegion.X + x;
                                                cogSearchRegion.Y = m_selectedJob.SearchRegion.Y + y;
                                                cogSearchRegion.Width = w;
                                                cogSearchRegion.Height = h;

                                                if (m_selectedJob.Parameter.EyeD_MinScore <= score)
                                                {
                                                    cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Green;
                                                    CCognexUtil.DrawString(DispMain, $"Model : {tag} Score : {score} Color : {colorStr.ToString()}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Green, 10);
                                                }
                                                else
                                                {
                                                    cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                                                    CCognexUtil.DrawString(DispMain, $"Model : {tag} Score : {score} Color : {colorStr.ToString()}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Red, 10);
                                                }

                                                DispMain.InteractiveGraphics.Add(cogSearchRegion, "", false);
                                            }
                                        }
                                    }


                                }

                                Global.Device.EyeD.RecvResults.TryRemove(uniqueID, out EyeD_Result result);

                            }

                            Thread.Sleep(10);
                        }
                        return extractColor;
                    }

                });
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnJobEyeD_ColorInsp_Click(object sender, EventArgs e)
        {

        }

        private void btnJobColorEx_Get_Click(object sender, EventArgs e)
        {
            try
            {
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                Color color = GetColor_fromRoi();

                txtColorEx_R.Text = color.R.ToString();
                txtColorEx_G.Text = color.G.ToString();
                txtColorEx_B.Text = color.B.ToString();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        public Color GetColor_fromRoi()
        {
            Color extractColor;
            using (Mat imgCrop = OpenCvSharp.Extensions.BitmapConverter.ToMat(IF_Util.Crop(m_imgSource_Color.ToBitmap(), m_selectedJob.SearchRegion)).Clone())
            {
                Scalar scalar = imgCrop.Mean();

                // 평균 색상 값을 BGR 형식으로 각각 추출
                byte meanB = (byte)scalar.Val0;
                byte meanG = (byte)scalar.Val1;
                byte meanR = (byte)scalar.Val2;

                extractColor = Color.FromArgb(meanR, meanG, meanB);
                string colorStr = $"{meanR},{meanG},{meanB}";
                IF_Util.setLabel(lblJobColorEx_ResultColor, colorStr.ToString(), extractColor);

                Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();

                cogSearchRegion.LineWidthInScreenPixels = 2;
                cogSearchRegion.X = m_selectedJob.SearchRegion.X;
                cogSearchRegion.Y = m_selectedJob.SearchRegion.Y;
                cogSearchRegion.Width = m_selectedJob.SearchRegion.Width;
                cogSearchRegion.Height = m_selectedJob.SearchRegion.Height;

                string colorName = "";
                for (int colorIdx = 0; colorIdx < Global.Setting.Enviroment.ColorList.ColorNodes.Count; colorIdx++)
                {
                    if (Global.Setting.Enviroment.ColorList.ColorNodes[colorIdx].InRange(meanR, meanG, meanB))
                    {
                        colorName = Global.Setting.Enviroment.ColorList.ColorNodes[colorIdx].Name;
                        break;
                    }
                }

                if (colorName == m_selectedJob.Parameter.EyeD_CorrectColor)
                {
                    cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Green;
                    CCognexUtil.DrawString(DispMain, $"Color : {colorStr.ToString()}({colorName})", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Green, 10);
                }
                else
                {
                    cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                    CCognexUtil.DrawString(DispMain, $"Color : {colorStr.ToString()}({colorName})", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Red, 10);
                }

                DispMain.InteractiveGraphics.Add(cogSearchRegion, "", false);
            }

            return extractColor;
        }


        private void btnDistanceDetail_Click(object sender, EventArgs e)
        {
            try
            {
                FormMenu_FindLineTool form = new FormMenu_FindLineTool(m_selectedJob.Find_Line, m_imgSource_Mono);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void txtQuickFind_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string quickText = txtQuickFind.Text.ToUpper();
                comboQuickFind.Items.Clear();

                if (Global.Instance.System.Recipe.JobManager[m_nSelectedArrayIndex - 1] != null)
                {
                    for (int i = 0; i < Global.Instance.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                    {
                        CJob job = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i];

                        if (job.Name.Contains(quickText))
                        {
                            comboQuickFind.Items.Add(job.Name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void comboQuickFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string jobName = comboQuickFind.Text;

                //2024.03.15 송현수->안춘길 : 선택 불량 버그
                for (int i = 0; i < Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs.Count; i++)
                {
                    CJob job = Global.System.Recipe.JobManager[m_nSelectedArrayIndex - 1].Jobs[i];
                    if (job.Name == jobName)
                    {
                        m_selectedJob = job;
                        m_nSelectedIndex_Library = i;
                        break;
                    }
                }

                for (int i = 0; i < gridLibrary.Rows.Count; i++)
                {
                    string name = gridLibrary[2, i].Value.ToString();

                    if (m_selectedJob.Name == name)
                    {
                        gridLibrary.ClearSelection(); // 선택 해제
                        gridLibrary.Rows[i].Selected = true; // 원하는 행 선택
                        gridLibrary.FirstDisplayedScrollingRowIndex = i;

                        break;
                    }
                }

                //요기 체크
                comboJobPattern_PatternType.Text = "Main";
                SelectGridJobs(true);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }

        }

        private void btnFiducialLibraryAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int addIndex = 0;
                for (int i = 0; i < 100; i++)
                {
                    string path = $"{Application.StartupPath}\\PBA_LIBRARY\\{Global.Instance.System.Recipe.CODE}\\FIDUCIAL_LIBRARY\\FiducialLibrary_{i}.json";

                    if (File.Exists(path) == false)
                    {
                        addIndex = i;
                        break;
                    }
                }

                Library_Fiducial library = new Library_Fiducial();
                library.LibraryNumber = addIndex.ToString();
                library.Save(Global.Instance.System.Recipe.CODE, addIndex.ToString());

                InitFiducialLibraryGrid();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private List<Library_Fiducial> _fiducialLibrary = new List<Library_Fiducial>();
        private Library_Fiducial _selectedFiducialLibrary = null;
        private void InitFiducialLibraryGrid()
        {
            try
            {
                _fiducialLibrary.Clear();

                string[] files = Directory.GetFiles($"{Application.StartupPath}\\PBA_LIBRARY\\{Global.Instance.System.Recipe.CODE}\\FIDUCIAL_LIBRARY\\");

                for (int i = 0; i < 100; i++)
                {
                    string path = $"{Application.StartupPath}\\PBA_LIBRARY\\{Global.Instance.System.Recipe.CODE}\\FIDUCIAL_LIBRARY\\FiducialLibrary_{i}.json";

                    if (files.Contains(path))
                    {
                        Library_Fiducial library = new Library_Fiducial();
                        _fiducialLibrary.Add(library.Load(Global.Instance.System.Recipe.CODE, i.ToString()));
                        _selectedFiducialLibrary = _fiducialLibrary.Last();
                    }
                }

                comboFiducialLibrary.Items.Clear();
                gridFiducialLibrary.Rows.Clear();

                for (int i = 0; i < _fiducialLibrary.Count; i++)
                {
                    gridFiducialLibrary.Rows.Add(new string[] { _fiducialLibrary[i].LibraryNumber, _fiducialLibrary[i].Memo });
                    comboFiducialLibrary.Items.Add(_fiducialLibrary[i].LibraryNumber);
                }

                if (_selectedFiducialLibrary != null)
                {
                    lblDegreeMaster.Text = $"{_selectedFiducialLibrary.MasterAngle:F5}";

                    if (_selectedFiducialLibrary.Fiducial1.ImageTemplate != null)
                    {
                        cogDisplay_Fiducial_Pattern.Image = new CogImage8Grey(_selectedFiducialLibrary.Fiducial1.ImageTemplate);
                        cogDisplay_Fiducial_Pattern.Fit(true);
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void gridFiducialLibrary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridFiducialLibrary.SelectedCells.Count > 0)
                {
                    int rowIdx = gridFiducialLibrary.SelectedCells[0].RowIndex;
                    string libraryNumber = gridFiducialLibrary[0, rowIdx].Value.ToString();

                    for (int i = 0; i < _fiducialLibrary.Count; i++)
                    {
                        if (libraryNumber == _fiducialLibrary[i].LibraryNumber)
                        {
                            _selectedFiducialLibrary = _fiducialLibrary[i];
                            break;
                        }
                    }
                }

                if (_selectedFiducialLibrary != null)
                {
                    comboFiducialLibrary.Text = _selectedFiducialLibrary.LibraryNumber;
                    txtFiducialLibraryMemo.Text = _selectedFiducialLibrary.Memo;
                    lblFiducialLibrary.Text = _selectedFiducialLibrary.LibraryNumber;

                    if (_selectedFiducialLibrary.ImagePreview != null)
                    {
                        cogDisplay_FiducialNavigator.InteractiveGraphics.Clear();
                        cogDisplay_FiducialNavigator.StaticGraphics.Clear();

                        cogDisplay_FiducialNavigator.Image = new CogImage24PlanarColor(_selectedFiducialLibrary.ImagePreview);
                        cogDisplay_FiducialNavigator.Fit(false);
                        CCognexUtil.DrawPosMarker(new Point2d(_selectedFiducialLibrary.Fiducial1.SearchRoi.X + _selectedFiducialLibrary.Fiducial1.SearchRoi.Width / 2, _selectedFiducialLibrary.Fiducial1.SearchRoi.Y + _selectedFiducialLibrary.Fiducial1.SearchRoi.Height / 2), 50, 50, cogDisplay_FiducialNavigator);
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnFiducialLibraryApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboFiducialLibrary.Text == "" || _selectedFiducialLibrary == null)
                {
                    IF_Util.ShowMessageBox("Error", "Should to select the library of fiducial first");
                    return;
                }

                if (_selectedFiducialLibrary != null)
                {
                    lblFiducialLibrary.Text = _selectedFiducialLibrary.LibraryNumber = comboFiducialLibrary.Text;
                    _selectedFiducialLibrary.Memo = txtFiducialLibraryMemo.Text;

                    _selectedFiducialLibrary.ImagePreview = DispMain.Image.ToBitmap();
                    _selectedFiducialLibrary.Save(Global.Instance.System.Recipe.CODE, _selectedFiducialLibrary.LibraryNumber);

                    Global.System.Recipe.FiducialLibrary = _selectedFiducialLibrary;
                }

                InitFiducialLibraryGrid();
                UINotifier.Show("Fiducial Library Apply Complete", UINotifierType.INFO, "Notifier", false);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void comboArray_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispMain.InteractiveGraphics.Clear();
            DispMain.StaticGraphics.Clear();
            btnArrayCrop_Roi.Text = "Complete";
        }

        private void btnEyeD_ColorExInsp_Click(object sender, EventArgs e)
        {
            try
            {
                DispMain.InteractiveGraphics.Clear();
                DispMain.StaticGraphics.Clear();

                using (Mat imgCrop = OpenCvSharp.Extensions.BitmapConverter.ToMat(IF_Util.Crop(m_imgSource_Color.ToBitmap(), m_selectedJob.SearchRegion)).Clone())
                {
                    string modelName = comboEyeDModelName.Text;
                    string inferType = comboEyeDInferType.Text;

                    string uniqueID = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");

                    string imageDir = $"{Application.StartupPath}\\EYED";
                    if (Directory.Exists(imageDir) == false) Directory.CreateDirectory(imageDir);

                    string imagePath = $"{imageDir}\\{modelName}_{inferType}_{DateTime.Now.ToString("yyyyMMdd_HHmmssfff")}.jpg";
                    imgCrop.SaveImage(imagePath);

                    Global.Device.EyeD.Send($"[{modelName},{uniqueID},{inferType},{imagePath}]\r\n", "");

                    Task.Run(() =>
                    {
                        Stopwatch tt = Stopwatch.StartNew();

                        while (tt.ElapsedMilliseconds < 20000)
                        {
                            if (Global.Device.EyeD.RecvResults.ContainsKey(uniqueID))
                            {
                                lblTactTime.Invoke((Action)(() =>
                                {
                                    lblTactTime.Text = $"T/T : {tt.ElapsedMilliseconds}ms";
                                }));

                                //{[20240405_182031471, (relay;0.92;209;44;44;45)]}
                                string resultString = Global.Device.EyeD.RecvResults[uniqueID].ResultString;

                                List<string> resultList = new List<string>();
                                MatchCollection matches = Regex.Matches(resultString, @"\([^()]*\)");

                                // 추출된 내용을 리스트에 추가
                                foreach (Match match in matches)
                                {
                                    resultList.Add(match.Value);
                                }

                                if (resultList.Count > 0)
                                {
                                    string resultInferType = resultList[0];
                                    string bestTag = "";
                                    double bestScore = 0.0D;

                                    for (int i = 1; i < resultList.Count; i++)
                                    {
                                        string value = resultList[i];
                                        double score = 0.0D;

                                        value = value.Replace("(", "");
                                        value = value.Replace(")", "");
                                        string[] values = value.Split(";");

                                        if (string.Equals(resultInferType, "(DET)"))
                                        {
                                            if (values.Length == 6)
                                            {
                                                string tag = values[0];


                                                double.TryParse(values[1], out score);

                                                bool success = true;
                                                success &= int.TryParse(values[2], out int x);
                                                success &= int.TryParse(values[3], out int y);
                                                success &= int.TryParse(values[4], out int w);
                                                success &= int.TryParse(values[5], out int h);

                                                if (success)
                                                {
                                                    Cognex.VisionPro.CogRectangle cogSearchRegion = new CogRectangle();

                                                    cogSearchRegion.LineWidthInScreenPixels = 2;
                                                    cogSearchRegion.X = m_selectedJob.SearchRegion.X + x;
                                                    cogSearchRegion.Y = m_selectedJob.SearchRegion.Y + y;
                                                    cogSearchRegion.Width = w;
                                                    cogSearchRegion.Height = h;

                                                    if (m_selectedJob.Parameter.EyeD_MinScore <= score)
                                                    {
                                                        cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Green;
                                                        CCognexUtil.DrawString(DispMain, $"Model : {tag} Score : {score}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Green, 10);
                                                    }
                                                    else
                                                    {
                                                        cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                                                        CCognexUtil.DrawString(DispMain, $"Model : {tag} Score : {score}", new Point2d(cogSearchRegion.X, cogSearchRegion.Y - 10), CogColorConstants.Red, 10);
                                                    }

                                                    if (m_selectedJob.Parameter.EyeD_UseColorInsp)
                                                    {
                                                        using (Mat imgCropforColor = OpenCvSharp.Extensions.BitmapConverter.ToMat(IF_Util.Crop(m_imgSource_Color.ToBitmap(), CConverter.CogRectToRect(cogSearchRegion))).Clone())
                                                        {
                                                            Scalar scalar = imgCrop.Mean();

                                                            // 평균 색상 값을 BGR 형식으로 각각 추출
                                                            byte meanB = (byte)scalar.Val0;
                                                            byte meanG = (byte)scalar.Val1;
                                                            byte meanR = (byte)scalar.Val2;

                                                            Color extractColor = Color.FromArgb(meanR, meanG, meanB);
                                                            string colorStr = $"{meanR},{meanG},{meanB}";
                                                            IF_Util.setLabel(lblJobColorEx_ResultColor, colorStr.ToString(), extractColor);

                                                            string colorName = "";
                                                            for (int colorIdx = 0; colorIdx < Global.Setting.Enviroment.ColorList.ColorNodes.Count; colorIdx++)
                                                            {
                                                                if (Global.Setting.Enviroment.ColorList.ColorNodes[colorIdx].InRange(meanR, meanG, meanB))
                                                                {
                                                                    colorName = Global.Setting.Enviroment.ColorList.ColorNodes[colorIdx].Name;
                                                                    break;
                                                                }
                                                            }

                                                            if (colorName == m_selectedJob.Parameter.EyeD_CorrectColor)
                                                            {
                                                                cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Green;
                                                                CCognexUtil.DrawString(DispMain, $"Color : {colorStr.ToString()}({colorName})", new Point2d(cogSearchRegion.X, cogSearchRegion.Y + 10), CogColorConstants.Green, 10);
                                                            }
                                                            else
                                                            {
                                                                cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                                                                CCognexUtil.DrawString(DispMain, $"Color : {colorStr.ToString()}({colorName})", new Point2d(cogSearchRegion.X, cogSearchRegion.Y + 10), CogColorConstants.Red, 10);
                                                            }

                                                            DispMain.InteractiveGraphics.Add(cogSearchRegion, "", false);
                                                        }
                                                    }

                                                    DispMain.InteractiveGraphics.Add(cogSearchRegion, "", false);
                                                }
                                            }
                                        }
                                    }
                                }


                                lblEyeDResult.Invoke((Action)(() =>
                                {
                                    lblEyeDResult.Text = Global.Device.EyeD.RecvResults[uniqueID].ResultString;
                                }));

                                Global.Device.EyeD.RecvResults.TryRemove(uniqueID, out EyeD_Result result);
                                break;
                            }

                            Thread.Sleep(10);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }
        private void ShowEYEDRIO()
        {
            DispMain.InteractiveGraphics.Clear();
            DispMain.StaticGraphics.Clear();

            if (m_selectedJob.SearchRegion.Width == 0 || m_selectedJob.SearchRegion.Height == 0)
            {
                m_selectedJob.SearchRegion = new Rectangle(0, 0, 100, 100);
            }
            //검사 영역
            Cognex.VisionPro.CogRectangle cogSearchRegion = CConverter.RectToCogRect(m_selectedJob.SearchRegion);
            cogSearchRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
            cogSearchRegion.Interactive = true;
            cogSearchRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Red;
            cogSearchRegion.DragColor = Cognex.VisionPro.CogColorConstants.Red;
            cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
            cogSearchRegion.LineWidthInScreenPixels = 2;
            if (cogSearchRegion.Width == 0) cogSearchRegion.Width = 250;
            if (cogSearchRegion.Height == 0) cogSearchRegion.Height = 250;

            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogSearchRegion, "Search", false);
        }

        private void ShowColorEx()
        {
            DispMain.InteractiveGraphics.Clear();
            DispMain.StaticGraphics.Clear();

            if (m_selectedJob.SearchRegion.Width == 0 || m_selectedJob.SearchRegion.Height == 0)
            {
                m_selectedJob.SearchRegion = new Rectangle(0, 0, 100, 100);
            }
            //검사 영역
            Cognex.VisionPro.CogRectangle cogSearchRegion = CConverter.RectToCogRect(m_selectedJob.SearchRegion);
            cogSearchRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
            cogSearchRegion.Interactive = true;
            cogSearchRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Red;
            cogSearchRegion.DragColor = Cognex.VisionPro.CogColorConstants.Red;
            cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
            cogSearchRegion.LineWidthInScreenPixels = 2;
            if (cogSearchRegion.Width == 0) cogSearchRegion.Width = 250;
            if (cogSearchRegion.Height == 0) cogSearchRegion.Height = 250;

            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogSearchRegion, "Search", false);
        }
        private void ShowCondencerRIO()
        {

            DispMain.InteractiveGraphics.Clear();
            DispMain.StaticGraphics.Clear();

            CogRectangle cogSearchRegion = new CogRectangle();

            if (m_selectedJob.SearchRegion.Width != 0 && m_selectedJob.SearchRegion.Height != 0)
                cogSearchRegion = CConverter.RectToCogRect(m_selectedJob.SearchRegion);
            if (cogSearchRegion.Width == 0) cogSearchRegion.Width = 100;
            if (cogSearchRegion.Height == 0) cogSearchRegion.Height = 100;

            cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
            cogSearchRegion.Interactive = true;
            cogSearchRegion.Color = CogColorConstants.Red;
            cogSearchRegion.SelectedColor = CogColorConstants.Red;

            DispMain.InteractiveGraphics.Add(cogSearchRegion, "Search", false);

            m_selectedJob.Find_Circle.RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;
            m_selectedJob.Find_Circle.RunParams.NumCalipers = 8;
            //m_selectedJob.Find_Circle.RunParams.NumToIgnore = 2;
            //m_selectedJob.Find_Circle.RunParams.CaliperRunParams.ContrastThreshold = 5;
            //m_selectedJob.Find_Circle.RunParams.CaliperRunParams.FilterHalfSizeInPixels = 5;

            CogGraphicCollection cogRegions;
            ICogRecord cogRecord;

            m_selectedJob.Find_Circle.InputImage = new CogImage8Grey(m_imgSource_Mono);
            m_selectedJob.Find_Circle.CurrentRecordEnable = CogFindCircleCurrentRecordConstants.All;

            cogRecord = m_selectedJob.Find_Circle.CreateCurrentRecord();
            CogCircularArc cogSegment = (CogCircularArc)cogRecord.SubRecords["InputImage"].SubRecords["ExpectedShapeSegment"].Content;
            cogRegions = (CogGraphicCollection)cogRecord.SubRecords["InputImage"].SubRecords["CaliperRegions"].Content;
            DispMain.InteractiveGraphics.Add(cogSegment, "ExpectedShapeSegment", false);

            if (cogRegions == null) return;
            foreach (ICogGraphic g in cogRegions) DispMain.InteractiveGraphics.Add((ICogGraphicInteractive)g, "CaliperRegions", false);
        }

        private void btnGetBlobPos_Click(object sender, EventArgs e)
        {
            int idx = DispMain.InteractiveGraphics.FindItem("RT", CogDisplayZOrderConstants.Back);
            if (idx < 0)
            {
                IF_Util.ShowMessageBox("Error", $"Have no Maching Result");
                return;
            }
            m_selectedJob.Parameter.BlobMasterPos_X = BlobPos_X;
            m_selectedJob.Parameter.BlobMasterPos_Y = BlobPos_Y;
        }

        private void OnClickAlgorithm_Pin(object sender, EventArgs e)
        {
            try
            {
                string action = (sender as UIButton).Text;

                if (DispMain.Image == null || DispMain.Image.Allocated == false)
                {
                    IF_Util.ShowMessageBox("Error", "Check the Image");
                    return;
                }

                switch (action)
                {
                    case "ROI":
                    case "Roi":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();
                            DispMain.Fit();

                            // Search 영역
                            CogRectangle cogSearchRegion = CCognexUtil.RectangleToCogRectangle(m_selectedJob.SearchRegion);
                            cogSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.Color = CogColorConstants.Red;
                            cogSearchRegion.SelectedColor = CogColorConstants.Red;


                            if (cogSearchRegion.Width == 0 || cogSearchRegion.Height == 0)
                            {
                                cogSearchRegion.Width = 100;
                                cogSearchRegion.Height = 100;
                            }

                            DispMain.InteractiveGraphics.Add(cogSearchRegion, "Search", false);
                            (sender as UIButton).Text = "Complete";
                        }
                        break;
                    case "Complete":
                        {
                            int idx = DispMain.InteractiveGraphics.FindItem("Search", CogDisplayZOrderConstants.Back);
                            CogRectangle roi = (DispMain.InteractiveGraphics[idx] as CogRectangle);

                            m_selectedJob.SearchRegion = CConverter.CogRectToRect(roi);
                            (sender as UIButton).Text = "Roi";
                        }
                        break;
                    case "FIND":
                    case "Find":
                        {
                            DispMain.InteractiveGraphics.Clear();

                            _imageSourceCV = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Mono.ToBitmap()).Clone();
                            using (Mat imgRoi = _imageSourceCV.SubMat(CConverter.RectToCVRect(m_selectedJob.SearchRegion)).Clone())
                            {
                                Scalar scalar = imgRoi.Mean();

                                // 평균 색상 값을 BGR 형식으로 각각 추출
                                byte meanB = (byte)scalar.Val0;
                                byte meanG = (byte)scalar.Val1;
                                byte meanR = (byte)scalar.Val2;

                                Color extractColor = Color.FromArgb(meanR, meanG, meanB);
                                string colorStr = $"R:{meanR},G:{meanG},B:{meanB}";
                                lblJobPin_MeasColor.Text = colorStr;
                                lblJobPin_MeasColor.BackColor = Color.FromArgb(meanR, meanG, meanB);

                                List<(Rectangle, int)> rects = CVision.Contour2(imgRoi, m_selectedJob.Parameter.Pin_Threshold, m_selectedJob.Parameter.Pin_AreaMin, m_selectedJob.Parameter.Pin_AreaMax, m_selectedJob.Parameter.Pin_BinaryInv);

                                DispMain.Image = m_imgSource_Color;

                                int masterCnt = m_selectedJob.Parameter.Pin_Boundaries.Count;
                                int detectCnt = 0;

                                List<(bool, Rectangle)> masterRects = new List<(bool, Rectangle)>();
                                for (int i = 0; i < m_selectedJob.Parameter.Pin_Boundaries.Count; i++)
                                {
                                    masterRects.Add((false, m_selectedJob.Parameter.Pin_Boundaries[i]));
                                }

                                if (rects.Count > 0)
                                {
                                    for (int i = 0; i < rects.Count; i++)
                                    {
                                        for (int compareIdx = 0; compareIdx < masterRects.Count; compareIdx++)
                                        {
                                            if (masterRects[compareIdx].Item1 == true) continue;

                                            if (rects[i].Item1.IntersectsWith(masterRects[compareIdx].Item2))
                                            {
                                                masterRects[compareIdx] = (true, masterRects[compareIdx].Item2);

                                                CogRectangle cogRect = new CogRectangle();
                                                cogRect.X = rects[i].Item1.X + m_selectedJob.SearchRegion.X;
                                                cogRect.Y = rects[i].Item1.Y + m_selectedJob.SearchRegion.Y;
                                                cogRect.Width = rects[i].Item1.Width;
                                                cogRect.Height = rects[i].Item1.Height;
                                                cogRect.Color = CogColorConstants.Green;

                                                CCognexUtil.DrawString(DispMain, $"Area : {rects[i].Item2}", new Point2d(cogRect.X, cogRect.Y), cogRect.Color, 10);
                                                DispMain.StaticGraphics.Add(cogRect, "RT");

                                                break;
                                            }
                                        }
                                    }
                                }

                                for (int i = 0; i < masterRects.Count; i++)
                                {
                                    CogRectangle cogRect = new CogRectangle();
                                    cogRect.X = masterRects[i].Item2.X + m_selectedJob.SearchRegion.X;
                                    cogRect.Y = masterRects[i].Item2.Y + m_selectedJob.SearchRegion.Y;
                                    cogRect.Width = masterRects[i].Item2.Width;
                                    cogRect.Height = masterRects[i].Item2.Height;

                                    if (masterRects[i].Item1 == true)
                                    {
                                        cogRect.Color = CogColorConstants.Green;
                                    }
                                    else
                                    {
                                        cogRect.Color = CogColorConstants.Red;
                                    }

                                    DispMain.StaticGraphics.Add(cogRect, "RT");
                                }
                            }
                        }
                        break;
                    case "Master":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            _imageSourceCV = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Mono.ToBitmap()).Clone();

                            using (Mat imgRoi = _imageSourceCV.SubMat(CConverter.RectToCVRect(m_selectedJob.SearchRegion)).Clone())
                            {
                                Scalar scalar = imgRoi.Mean();

                                // 평균 색상 값을 BGR 형식으로 각각 추출
                                byte meanB = (byte)scalar.Val0;
                                byte meanG = (byte)scalar.Val1;
                                byte meanR = (byte)scalar.Val2;

                                Color extractColor = Color.FromArgb(meanR, meanG, meanB);
                                string colorStr = $"R:{meanR},G:{meanG},B:{meanB}";
                                lblJobPin_ShapeColor.Text = colorStr;
                                lblJobPin_ShapeColor.BackColor = Color.FromArgb(meanR, meanG, meanB);

                                m_selectedJob.Parameter.Pin_ColorR = meanR;
                                m_selectedJob.Parameter.Pin_ColorG = meanG;
                                m_selectedJob.Parameter.Pin_ColorB = meanB;

                                List<(Rectangle, int)> rects = CVision.Contour2(imgRoi, m_selectedJob.Parameter.Pin_Threshold, m_selectedJob.Parameter.Pin_AreaMin, m_selectedJob.Parameter.Pin_AreaMax, m_selectedJob.Parameter.Pin_BinaryInv);

                                DispMain.Image = m_imgSource_Color;

                                if (rects.Count > 0)
                                {
                                    m_selectedJob.Parameter.Pin_Boundaries.Clear();

                                    for (int i = 0; i < rects.Count; i++)
                                    {
                                        Rectangle specRect = rects[i].Item1;
                                        specRect.X = specRect.X + specRect.Width / 2 - m_selectedJob.Parameter.Pin_SpecRoiWidth / 2;
                                        specRect.Y = specRect.Y + specRect.Height / 2 - m_selectedJob.Parameter.Pin_SpecRoiHeight / 2;
                                        specRect.Width = m_selectedJob.Parameter.Pin_SpecRoiWidth;
                                        specRect.Height = m_selectedJob.Parameter.Pin_SpecRoiHeight;

                                        m_selectedJob.Parameter.Pin_Boundaries.Add(specRect);

                                        OpenCvSharp.Rect masterRect = new Rect();

                                        masterRect.X = m_selectedJob.SearchRegion.X + specRect.X;
                                        masterRect.Y = m_selectedJob.SearchRegion.Y + specRect.Y;
                                        masterRect.Width = m_selectedJob.Parameter.Pin_SpecRoiWidth;
                                        masterRect.Height = m_selectedJob.Parameter.Pin_SpecRoiHeight;

                                        CogRectangle cogMasterRect = CConverter.CVRectToCogRect(masterRect);
                                        cogMasterRect.Color = CogColorConstants.Green;

                                        CCognexUtil.DrawString(DispMain, $"Area : {rects[i].Item2}", new Point2d(cogMasterRect.X, cogMasterRect.Y), CogColorConstants.Red, 10);
                                        DispMain.StaticGraphics.Add(cogMasterRect, "RT");
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnJobCondensor_DistSetting_Click(object sender, EventArgs e)
        {
            string index = "Distance";

            for (int i = 0; i < tcAlgorithm.TabPages.Count; i++)
            {
                if (string.Equals(tcAlgorithm.TabPages[i].Text, index))
                {
                    tcAlgorithm.SelectedTab = tcAlgorithm.TabPages[i];
                    break;
                }
            }
        }

        private void btnJobCondensor_DistInsp_Click(object sender, EventArgs e)
        {
            try
            {
                using (Bitmap bitmap = m_imgSource_Color.ToBitmap())
                {
                    Mat img = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);
                    IF_Util.SetImageChannel1(img);

                    Bitmap imgResult = m_imgSource_Color.ToBitmap();

                    if (chkUseFilter1.Checked)
                    {
                        int kernelW = int.Parse(txtFilter1_KernelW.Text);
                        int kernelH = int.Parse(txtFilter1_KernelH.Text);

                        img = CVisionTools.RunFilter(img, (CVisionTools.CV_FILTER)comboFilter1Type.SelectedIndex, kernelW, kernelH);
                    }

                    if (chkUseFilter2.Checked)
                    {
                        int kernelW = int.Parse(txtFilter2_KernelW.Text);
                        int kernelH = int.Parse(txtFilter2_KernelH.Text);

                        img = CVisionTools.RunFilter(img, (CVisionTools.CV_FILTER)comboFilter2Type.SelectedIndex, kernelW, kernelH);
                    }

                    m_selectedJob.Parameter.CondensorRectWidth = int.Parse(tbCircleRectW.Text);
                    m_selectedJob.Parameter.CondensorRectHeight = int.Parse(tbCircleRectH.Text);
                    m_selectedJob.Parameter.CondensorRadiusOffset = int.Parse(tbCondensorRectRadio.Text);
                    m_selectedJob.Parameter.CondensorTypeTB = radioCondensorTB.Checked;

                    Inspection_Circle(out Point2d center, new CogImage8Grey(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img)), comboCondensorPolarity.Text);

                    Point2d pos = FindFiducialMarkInAarry();

                    Point2d lineCenter = center;

                    CogLineSegment lineX = new CogLineSegment();
                    lineX.StartX = pos.X;
                    lineX.StartY = pos.Y;
                    lineX.EndX = lineCenter.X;
                    lineX.EndY = pos.Y;
                    lineX.Color = CogColorConstants.Red;

                    CogLineSegment lineY = new CogLineSegment();
                    lineY.StartX = pos.X;
                    lineY.StartY = pos.Y;
                    lineY.EndX = pos.X;
                    lineY.EndY = lineCenter.Y;
                    lineY.Color = CogColorConstants.Red;

                    double distanceX = lineX.Length;
                    double distanceY = lineY.Length;

                    if (cbXValue.Checked)
                    {
                        if (distanceX > int.Parse(tbXMinValue.Text.ToString()) && distanceX < int.Parse(tbXMaxValue.Text.ToString()))
                        {
                            CCognexUtil.DrawText(DispMain, new Point2d(pos.X, pos.Y + 20), $"X : {distanceX.ToString("F3")}px", CogColorConstants.Blue);
                            lineX.Color = CogColorConstants.Blue;
                        }
                        else
                        {
                            CCognexUtil.DrawText(DispMain, new Point2d(pos.X, pos.Y + 20), $"X : {distanceX.ToString("F3")}px", CogColorConstants.Red);
                            lineX.Color = CogColorConstants.Blue;
                        }

                        DispMain.StaticGraphics.Add(lineX, "");
                    }
                    if (cbYValue.Checked)
                    {
                        if (distanceY > int.Parse(tbYMinValue.Text.ToString()) && distanceY < int.Parse(tbYMaxValue.Text.ToString()))
                        {
                            CCognexUtil.DrawText(DispMain, new Point2d(pos.X, pos.Y + 40), $"Y : {distanceY.ToString("F3")}px", CogColorConstants.Blue);
                            lineY.Color = CogColorConstants.Blue;
                        }
                        else
                        {
                            CCognexUtil.DrawText(DispMain, new Point2d(pos.X, pos.Y + 40), $"Y : {distanceY.ToString("F3")}px", CogColorConstants.Red);
                            lineY.Color = CogColorConstants.Blue;
                        }

                        DispMain.StaticGraphics.Add(lineY, "");
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void OnClickAlgorithm_Connector(object sender, EventArgs e)
        {
            try
            {
                string strIndex = (sender as UIButton).Text;

                int idx = -1;

                CCogTool_PMAlign PMAlign = m_selectedJob.Tool;
                if (PMAlign == null) PMAlign = new CCogTool_PMAlign();

                switch (strIndex)
                {
                    case "ROI":
                    case "Roi":
                        {
                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();

                            if (PMAlign.Tool.SearchRegion == null)
                            {
                                PMAlign.Tool.SearchRegion = new Cognex.VisionPro.CogRectangle();
                                PMAlign.Tool.SearchRegion.FitToImage(m_imgSource_Mono, 1.0D, 1.0D);
                            }

                            //검사 영역
                            Cognex.VisionPro.CogRectangle cogSearchRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion;
                            cogSearchRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                            cogSearchRegion.Interactive = true;
                            cogSearchRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.DragColor = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.Color = Cognex.VisionPro.CogColorConstants.Red;
                            cogSearchRegion.LineWidthInScreenPixels = 2;

                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogSearchRegion, "Search", false);

                            // Train 영역
                            Cognex.VisionPro.CogRectangle cogTrainRegion = new Cognex.VisionPro.CogRectangle();

                            if (PMAlign.Tool.Pattern.TrainRegion != null)
                            {
                                if (PMAlign.Tool.Pattern.TrainRegion.ToString() == "Cognex.VisionPro.CogRectangle")
                                {
                                    cogTrainRegion = (Cognex.VisionPro.CogRectangle)PMAlign.Tool.Pattern.TrainRegion;
                                }
                                else
                                {
                                    cogTrainRegion.X = 30;
                                    cogTrainRegion.Y = 30;
                                    cogTrainRegion.Width = 250;
                                    cogTrainRegion.Height = 250;
                                }

                                cogTrainRegion.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;
                                cogTrainRegion.Interactive = true;
                                cogTrainRegion.SelectedColor = Cognex.VisionPro.CogColorConstants.Blue;
                                cogTrainRegion.DragColor = Cognex.VisionPro.CogColorConstants.Blue;
                                cogTrainRegion.Color = Cognex.VisionPro.CogColorConstants.Blue;
                                cogTrainRegion.LineWidthInScreenPixels = 2;
                            }

                            if (cogTrainRegion.Width == 0) cogTrainRegion.Width = 250;
                            if (cogTrainRegion.Height == 0) cogTrainRegion.Height = 250;

                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogTrainRegion, "Pattern", false);
                        }
                        break;

                    case "TRAIN":
                    case "Train":
                        {
                            if (m_selectedJob.Type.Contains("Library") == true)
                            {
                                IF_Util.ShowMessageBox("ERROR", "Library Can't Train");
                                return;
                            }

                            int SelectArrayIndex = m_nSelectedArrayIndex - 1;

                            CogRectangle Roi_Search = new CogRectangle();
                            CogRectangle Roi_Pattern = new CogRectangle();
                            CogRectangle Roi_DeepLearning = new CogRectangle();
                            CogRectangle Roi_PatternColor = new CogRectangle();

                            idx = DispMain.InteractiveGraphics.FindItem("Search", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
                            if (idx > -1)
                            {
                                Roi_Search = (DispMain.InteractiveGraphics[idx] as CogRectangle);
                            }
                            idx = DispMain.InteractiveGraphics.FindItem("Pattern", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);
                            if (idx > -1)
                            {
                                Roi_Pattern = (DispMain.InteractiveGraphics[idx] as CogRectangle);
                            }

                            Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].SearchRegion = new Rectangle(Convert.ToInt32(Roi_Search.X), Convert.ToInt32(Roi_Search.Y), Convert.ToInt32(Roi_Search.Width), Convert.ToInt32(Roi_Search.Height));
                            PMAlign.Tool.Pattern.TrainImage = m_imgSource_Mono;

                            Cognex.VisionPro.CogRectangle CR = new CogRectangle();
                            CR.X = Roi_Pattern.X;
                            CR.Y = Roi_Pattern.Y;
                            CR.Width = Roi_Pattern.Width;
                            CR.Height = Roi_Pattern.Height;

                            Global.System.Recipe.JobManager[SelectArrayIndex].Jobs[m_nSelectedIndex_Library].Tool.Tool.Pattern.TrainRegion = CR;

                            PMAlign.Tool.Pattern.Origin.TranslationX = (PMAlign.Tool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterX;
                            PMAlign.Tool.Pattern.Origin.TranslationY = (PMAlign.Tool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterY;

                            try
                            {
                                PMAlign.Tool.Pattern.Train();
                            }
                            catch
                            {
                                IF_Util.ShowMessageBox("Train Error", "Current Image Not Train!! Grab Image Index Change Please!!");
                                return;
                            }

                            cogDisplay_Connector.InteractiveGraphics.Clear();
                            cogDisplay_Connector.StaticGraphics.Clear();
                            cogDisplay_Connector.Image = PMAlign.Tool.Pattern.GetTrainedPatternImage();
                            CVisionCognex.TrainGraphic(PMAlign.Tool, cogDisplay_Connector);
                            cogDisplay_Connector.Fit(true);
                        }
                        break;

                    case "RUN":
                    case "INSP":
                    case "Find":
                        {
                            Stopwatch tactTime = Stopwatch.StartNew();
                            Cognex.VisionPro.CogGraphicLabel label = new Cognex.VisionPro.CogGraphicLabel();
                            bool bol_Result = true;

                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();
                            Rectangle PMAlignRect = new Rectangle();
                            CogRectangle cogRectangle = new CogRectangle();

                            PMAlign.Tool.RunParams.AcceptThreshold = m_selectedJob.Parameter.Connector_ScoreMin;
                            PMAlign.Tool.InputImage = m_imgSource_Mono;

                            DispMain.StaticGraphics.Add((Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion, "main");

                            PMAlign.Tool.Run();
                            label.Font = new Font("Arial", 14);
                            label.LineWidthInScreenPixels = 5;
                            for (int i = 0; i < PMAlign.Tool.Results.Count; i++)
                            {
                                label.X = PMAlign.Tool.Results[i].GetPose().TranslationX;
                                label.Y = PMAlign.Tool.Results[i].GetPose().TranslationY - 20;
                            }

                            string str_Result = "";
                            string[] strAry_InspResult;
                            string str_InspPartName;
                            float str_Score = 0;
                            int count = int.Parse(tbPatternMasterCount.Text);
                            List<CogPMAlignResult> pMAlignResult = new List<CogPMAlignResult>();

                            Inspection_PatternMatching(PMAlign, false, out pMAlignResult);

                            double ResultAcceptedScore = double.Parse(tbJobPattern_MinScore.Text.ToString());
                            CogRectangle Roi_Search1 = PMAlign.Tool.SearchRegion as CogRectangle;
                            label.X = Roi_Search1.X;
                            label.Y = Roi_Search1.Y;

                            if (pMAlignResult != null)
                            {

                                label.Text = $"Result Score:{pMAlignResult[0].Score.ToString("F3")} Min Score: {ResultAcceptedScore}";
                                lblDetectedPatternCount.Text = $"Count :1";
                                if (pMAlignResult[0].Score < ResultAcceptedScore)
                                {
                                    bol_Result = false;
                                }
                            }
                            else
                            {

                                label.Text = $"Count NG Not Find";
                                bol_Result = false;
                            }

                            if (bol_Result)
                            {
                                label.Color = CogColorConstants.Green;
                                cogRectangle.Color = CogColorConstants.Green;
                            }
                            else
                            {
                                label.Color = CogColorConstants.Red;
                                cogRectangle.Color = CogColorConstants.Red;
                            }

                            idx = DispMain.InteractiveGraphics.FindItem("Result", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Back);

                            if (idx > 0)
                            {
                                DispMain.InteractiveGraphics.Remove(idx);
                            }

                            DispMain.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)label, "Result", false);

                            tactTime.Stop();
                        }
                        break;
                    case "Projection":
                        {
                            Stopwatch tactTime = Stopwatch.StartNew();
                            Cognex.VisionPro.CogGraphicLabel label = new Cognex.VisionPro.CogGraphicLabel();
                            bool bol_Result = true;

                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();
                            Rectangle PMAlignRect = new Rectangle();
                            CogRectangle cogRectangle = new CogRectangle();

                            PMAlign.Tool.RunParams.AcceptThreshold = m_selectedJob.Parameter.Connector_ScoreMin;
                            PMAlign.Tool.InputImage = m_imgSource_Mono;

                            DispMain.StaticGraphics.Add((Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion, "main");

                            PMAlign.Tool.Run();
                            label.Font = new Font("Arial", 14);
                            label.LineWidthInScreenPixels = 5;
                            for (int i = 0; i < PMAlign.Tool.Results.Count; i++)
                            {
                                label.X = PMAlign.Tool.Results[i].GetPose().TranslationX;
                                label.Y = PMAlign.Tool.Results[i].GetPose().TranslationY - 20;
                            }

                            int patternWidth = PMAlign.Tool.Pattern.GetTrainedPatternImage().Width;
                            int patternHeight = PMAlign.Tool.Pattern.GetTrainedPatternImage().Height;

                            using (Mat imgCV = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Mono.ToBitmap()))
                            {
                                IF_Util.SetImageChannel1(imgCV);

                                double centerX = PMAlign.Tool.Results[0].GetPose().TranslationX;
                                double centerY = PMAlign.Tool.Results[0].GetPose().TranslationY;

                                if (m_selectedJob.Parameter.Connector_Type_LR)
                                {
                                    Rect rectL = new Rect((int)centerX - m_selectedJob.Parameter.Connector_BoxWidth, (int)centerY - m_selectedJob.Parameter.Connector_BoxHeight / 2, m_selectedJob.Parameter.Connector_BoxWidth, m_selectedJob.Parameter.Connector_BoxHeight);
                                    Rect rectR = new Rect((int)centerX, (int)centerY - m_selectedJob.Parameter.Connector_BoxHeight / 2, m_selectedJob.Parameter.Connector_BoxWidth, m_selectedJob.Parameter.Connector_BoxHeight);
                                    using (Mat imgL = imgCV.SubMat(rectL).Clone())
                                    using (Mat imgR = imgCV.SubMat(rectR).Clone())
                                    {
                                        List<(Rect, int)> results_L = CVision.Contour(imgL, m_selectedJob.Parameter.Connector_Threshold, m_selectedJob.Parameter.Connector_AreaMin, m_selectedJob.Parameter.Connector_AreaMax, m_selectedJob.Parameter.Connector_BinaryInv);
                                        List<(Rect, int)> results_R = CVision.Contour(imgR, m_selectedJob.Parameter.Connector_Threshold, m_selectedJob.Parameter.Connector_AreaMin, m_selectedJob.Parameter.Connector_AreaMax, m_selectedJob.Parameter.Connector_BinaryInv);

                                        int areaL = 0;
                                        int areaR = 0;
                                        if (results_L.Count > 0)
                                        {
                                            results_L = results_L.OrderByDescending(x => x.Item2).ToList();
                                            areaL = results_L[0].Item2;
                                        }

                                        if (results_R.Count > 0)
                                        {
                                            results_R = results_R.OrderByDescending(x => x.Item2).ToList();
                                            areaR = results_R[0].Item2;
                                        }

                                        if (m_selectedJob.Parameter.Connector_LargeFirst)
                                        {
                                            if (m_selectedJob.Parameter.Connector_AreaOK < areaL)
                                            {
                                                CCognexUtil.DrawString(DispMain, $"OK-(LEFT) (Meas){areaL}>(Spec){m_selectedJob.Parameter.Connector_AreaOK}", new Point2d(rectL.X, rectL.Y), CogColorConstants.Green, 10);
                                            }
                                            else
                                            {
                                                CCognexUtil.DrawString(DispMain, $"NG-(LEFT) (Meas){areaL}>(Spec){m_selectedJob.Parameter.Connector_AreaOK}", new Point2d(rectL.X, rectL.Y), CogColorConstants.Red, 10);
                                            }

                                            CogRectangle cogRectL = CConverter.CVRectToCogRect(rectL);
                                            cogRectL.Color = CogColorConstants.Green;

                                            CogRectangle cogRectR = CConverter.CVRectToCogRect(rectR);
                                            cogRectR.Color = CogColorConstants.Orange;

                                            DispMain.StaticGraphics.Add(cogRectL, "LRT");
                                            DispMain.StaticGraphics.Add(cogRectR, "RRT");
                                        }
                                        else
                                        {
                                            if (m_selectedJob.Parameter.Connector_AreaOK < areaR)
                                            {
                                                CCognexUtil.DrawString(DispMain, $"OK-(RIGHT) (Meas){areaR}>(Spec){m_selectedJob.Parameter.Connector_AreaOK}", new Point2d(rectR.X, rectR.Y), CogColorConstants.Green, 10);
                                            }
                                            else
                                            {
                                                CCognexUtil.DrawString(DispMain, $"NG-(RIGHT) (Meas){areaR}>(Spec){m_selectedJob.Parameter.Connector_AreaOK}", new Point2d(rectR.X, rectR.Y), CogColorConstants.Red, 10);
                                            }

                                            CogRectangle cogRectL = CConverter.CVRectToCogRect(rectL);
                                            cogRectL.Color = CogColorConstants.Orange;

                                            CogRectangle cogRectR = CConverter.CVRectToCogRect(rectR);
                                            cogRectR.Color = CogColorConstants.Green;

                                            DispMain.StaticGraphics.Add(cogRectL, "LRT");
                                            DispMain.StaticGraphics.Add(cogRectR, "RRT");

                                        }
                                        //else
                                        //{
                                        //    CCognexUtil.DrawString(cogDisplay_Source, $"NG {areaL}/{areaR}", new Point2d(rectL.X, rectL.Y), CogColorConstants.Red, 10);

                                        //    CogRectangle cogRectL = CConverter.CVRectToCogRect(rectL);
                                        //    cogRectL.Color = CogColorConstants.Orange;

                                        //    CogRectangle cogRectR = CConverter.CVRectToCogRect(rectR);
                                        //    cogRectR.Color = CogColorConstants.Orange;

                                        //    CCognexUtil.DrawString(cogDisplay_Source, $"[RIGHT](RIGHT) {areaL}<{areaR}", new Point2d(rectL.X, rectL.Y), CogColorConstants.Green, 10);
                                        //}
                                    }
                                }
                                else
                                {
                                    //Rect rectT = new Rect((int)centerX - patternWidth / 2, (int)centerY - patternHeight / 2, m_selectedJob.Parameter.Connector_BoxWidth, m_selectedJob.Parameter.Connector_BoxHeight);
                                    //Rect rectB = new Rect((int)centerX, (int)centerY - patternHeight / 2, m_selectedJob.Parameter.Connector_BoxWidth, m_selectedJob.Parameter.Connector_BoxHeight);
                                    //using (Mat imgL = imgCV.SubMat(rectL).Clone())
                                    //using (Mat imgR = imgCV.SubMat(rectR).Clone())
                                    //{
                                    //    List<(Rect, int)> results_L = CVision.Contour(imgL, m_selectedJob.Parameter.Connector_Threshold, m_selectedJob.Parameter.Connector_AreaMin, m_selectedJob.Parameter.Connector_AreaMax, m_selectedJob.Parameter.Connector_BinaryInv);
                                    //    List<(Rect, int)> results_R = CVision.Contour(imgR, m_selectedJob.Parameter.Connector_Threshold, m_selectedJob.Parameter.Connector_AreaMin, m_selectedJob.Parameter.Connector_AreaMax, m_selectedJob.Parameter.Connector_BinaryInv);

                                    //    int areaL = 0;
                                    //    int areaR = 0;
                                    //    if (results_L.Count > 0)
                                    //    {
                                    //        results_L = results_L.OrderByDescending(x => x.Item2).ToList();
                                    //        areaL = results_L[0].Item2;
                                    //    }

                                    //    if (results_R.Count > 0)
                                    //    {
                                    //        results_R = results_R.OrderByDescending(x => x.Item2).ToList();
                                    //        areaR = results_R[0].Item2;
                                    //    }
                                    //}
                                }
                            }


                        }
                        break;
                    case "Master":
                        {
                            Stopwatch tactTime = Stopwatch.StartNew();
                            Cognex.VisionPro.CogGraphicLabel label = new Cognex.VisionPro.CogGraphicLabel();
                            bool bol_Result = true;

                            DispMain.InteractiveGraphics.Clear();
                            DispMain.StaticGraphics.Clear();
                            Rectangle PMAlignRect = new Rectangle();
                            CogRectangle cogRectangle = new CogRectangle();

                            PMAlign.Tool.RunParams.AcceptThreshold = m_selectedJob.Parameter.Connector_ScoreMin;
                            PMAlign.Tool.InputImage = m_imgSource_Mono;

                            DispMain.StaticGraphics.Add((Cognex.VisionPro.CogRectangle)PMAlign.Tool.SearchRegion, "main");

                            PMAlign.Tool.Run();
                            label.Font = new Font("Arial", 14);
                            label.LineWidthInScreenPixels = 5;
                            for (int i = 0; i < PMAlign.Tool.Results.Count; i++)
                            {
                                label.X = PMAlign.Tool.Results[i].GetPose().TranslationX;
                                label.Y = PMAlign.Tool.Results[i].GetPose().TranslationY - 20;
                            }

                            int patternWidth = PMAlign.Tool.Pattern.GetTrainedPatternImage().Width;
                            int patternHeight = PMAlign.Tool.Pattern.GetTrainedPatternImage().Height;

                            using (Mat imgCV = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Mono.ToBitmap()))
                            {
                                IF_Util.SetImageChannel1(imgCV);

                                double centerX = PMAlign.Tool.Results[0].GetPose().TranslationX;
                                double centerY = PMAlign.Tool.Results[0].GetPose().TranslationY;

                                if (m_selectedJob.Parameter.Connector_Type_LR)
                                {
                                    Rect rectL = new Rect((int)centerX - m_selectedJob.Parameter.Connector_BoxWidth, (int)centerY - m_selectedJob.Parameter.Connector_BoxHeight / 2, m_selectedJob.Parameter.Connector_BoxWidth, m_selectedJob.Parameter.Connector_BoxHeight);
                                    Rect rectR = new Rect((int)centerX, (int)centerY - m_selectedJob.Parameter.Connector_BoxHeight / 2, m_selectedJob.Parameter.Connector_BoxWidth, m_selectedJob.Parameter.Connector_BoxHeight);

                                    using (Mat imgL = imgCV.SubMat(rectL).Clone())
                                    using (Mat imgR = imgCV.SubMat(rectR).Clone())
                                    {
                                        List<(Rect, int)> results_L = CVision.Contour(imgL, m_selectedJob.Parameter.Connector_Threshold, m_selectedJob.Parameter.Connector_AreaMin, m_selectedJob.Parameter.Connector_AreaMax, m_selectedJob.Parameter.Connector_BinaryInv);
                                        List<(Rect, int)> results_R = CVision.Contour(imgR, m_selectedJob.Parameter.Connector_Threshold, m_selectedJob.Parameter.Connector_AreaMin, m_selectedJob.Parameter.Connector_AreaMax, m_selectedJob.Parameter.Connector_BinaryInv);

                                        int areaL = 0;
                                        int areaR = 0;
                                        if (results_L.Count > 0)
                                        {
                                            results_L = results_L.OrderByDescending(x => x.Item2).ToList();
                                            areaL = results_L[0].Item2;
                                        }

                                        if (results_R.Count > 0)
                                        {
                                            results_R = results_R.OrderByDescending(x => x.Item2).ToList();
                                            areaR = results_R[0].Item2;
                                        }

                                        if (areaL > areaR)
                                        {
                                            //m_selectedJob.Parameter.Connector_LargeFirst = true;
                                            CCognexUtil.DrawString(DispMain, $"[LEFT](LEFT) {areaL}>{areaR}", new Point2d(rectL.X, rectL.Y), CogColorConstants.Green, 10);

                                            CogRectangle cogRectL = CConverter.CVRectToCogRect(rectL);
                                            cogRectL.Color = CogColorConstants.Green;

                                            CogRectangle cogRectR = CConverter.CVRectToCogRect(rectR);
                                            cogRectR.Color = CogColorConstants.Orange;

                                            DispMain.StaticGraphics.Add(cogRectL, "LRT");
                                            DispMain.StaticGraphics.Add(cogRectR, "RRT");
                                        }
                                        else
                                        {
                                            //m_selectedJob.Parameter.Connector_LargeFirst = false;
                                            CCognexUtil.DrawString(DispMain, $"[RIGHT](RIGHT) {areaL}<{areaR}", new Point2d(rectR.X, rectR.Y), CogColorConstants.Green, 10);

                                            CogRectangle cogRectL = CConverter.CVRectToCogRect(rectL);
                                            cogRectL.Color = CogColorConstants.Orange;

                                            CogRectangle cogRectR = CConverter.CVRectToCogRect(rectR);
                                            cogRectR.Color = CogColorConstants.Green;

                                            DispMain.StaticGraphics.Add(cogRectL, "LRT");
                                            DispMain.StaticGraphics.Add(cogRectR, "RRT");
                                        }
                                    }
                                }
                                else
                                {
                                    //Rect rectT = new Rect((int)centerX - patternWidth / 2, (int)centerY - patternHeight / 2, m_selectedJob.Parameter.Connector_BoxWidth, m_selectedJob.Parameter.Connector_BoxHeight);
                                    //Rect rectB = new Rect((int)centerX, (int)centerY - patternHeight / 2, m_selectedJob.Parameter.Connector_BoxWidth, m_selectedJob.Parameter.Connector_BoxHeight);
                                    //using (Mat imgL = imgCV.SubMat(rectL).Clone())
                                    //using (Mat imgR = imgCV.SubMat(rectR).Clone())
                                    //{
                                    //    List<(Rect, int)> results_L = CVision.Contour(imgL, m_selectedJob.Parameter.Connector_Threshold, m_selectedJob.Parameter.Connector_AreaMin, m_selectedJob.Parameter.Connector_AreaMax, m_selectedJob.Parameter.Connector_BinaryInv);
                                    //    List<(Rect, int)> results_R = CVision.Contour(imgR, m_selectedJob.Parameter.Connector_Threshold, m_selectedJob.Parameter.Connector_AreaMin, m_selectedJob.Parameter.Connector_AreaMax, m_selectedJob.Parameter.Connector_BinaryInv);

                                    //    int areaL = 0;
                                    //    int areaR = 0;
                                    //    if (results_L.Count > 0)
                                    //    {
                                    //        results_L = results_L.OrderByDescending(x => x.Item2).ToList();
                                    //        areaL = results_L[0].Item2;
                                    //    }

                                    //    if (results_R.Count > 0)
                                    //    {
                                    //        results_R = results_R.OrderByDescending(x => x.Item2).ToList();
                                    //        areaR = results_R[0].Item2;
                                    //    }
                                    //}
                                }
                            }


                        }
                        break;

                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bResult_Action)
                {
                    _bResult_Action = false;
                    btnAction.BackColor = DEFINE_COMMON.COLOR_GREEN;
                    btnAction.Refresh();
                }
                else
                {
                    _bResult_Action = true;
                    btnAction.BackColor = DEFINE_COMMON.COLOR_BLACK40;
                    btnAction.Refresh();
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
            }
        }

        private void btnCloneJobAll_Click(object sender, EventArgs e)
        {
            try
            {
                CJob job = new CJob();
                if (IF_Util.ShowMessageBox("Clone", $"Do you want to Clone \nArray {1} To Array {2}?", FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    Global.System.Recipe.JobManager[1].Jobs.Clear();
                    for (int i = 0; i < Global.System.Recipe.JobManager[0].Jobs.Count; i++)
                    {

                        Global.System.Recipe.JobManager[1].Jobs.Add(Global.System.Recipe.JobManager[0].Jobs[i].Clone());

                    }

                    InitJobs();
                }
                IF_Util.ShowMessageBox("Clone Complete", $"Complete Clone \nArray {1} To Array {2}!!");
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.ToString());
            }
        }

        
    }

    public class ResultBase
    {
        public string[] class_names;
        public float[] scales;
        public float score_threshold;
        public float nms_threshold;
        public ResultBase() { }
        public void read_class_names(string path)
        {

            List<string> str = new List<string>();
            StreamReader sr = new StreamReader(path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                str.Add(line);
            }

            class_names = str.ToArray();
        }

        public void read_class_names(string[] classes)
        {
            class_names = classes;
        }
    }

    public class ClassificationParser : ResultBase
    {
        public ClassificationParser(string path)
        {
            read_class_names(path);
        }

        public KeyValuePair<string, float> process_result(float[] result)
        {
            int clas = 0;
            float score = result[0];
            for (int i = 0; i < result.Length; i++)
            {
                float temp = result[i];
                if (score <= temp)
                {
                    score = temp;
                    clas = i;
                }
            }
            return new KeyValuePair<string, float>(this.class_names[clas], score);
        }

        public Mat DrawResult(KeyValuePair<string, float> result, Mat image)
        {
            Cv2.PutText(image, result.Key + ":  " + result.Value.ToString("0.00"),
                                new OpenCvSharp.Point(25, 30), HersheyFonts.HersheySimplex, 1, new Scalar(0, 0, 255), 2);
            return image;
        }
    }
}