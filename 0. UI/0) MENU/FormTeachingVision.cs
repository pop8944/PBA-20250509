using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;

using MetroFramework.Controls;
using MetroFramework.Forms;

using ImageGlass;

using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ColorMatch;
using Cognex.VisionPro.ColorExtractor;
using Cognex.VisionPro.OCRMax;
using Cognex.VisionPro.OCVMax;
using Cognex.VisionPro.PixelMap;


using WeifenLuo.WinFormsUI.Docking;
using Cognex.VisionPro.ColorSegmenter;

#if MATROX
using Matrox.MatroxImagingLibrary; 
#endif

#if DATAMATRIXNET
using DataMatrix.net;
#endif

namespace IntelligentFactory
{
    public partial class FormTeachingVision : Form
    {
        private IGlobal Global = IGlobal.Instance;

        private CogPMAlignTool PMAlignTool = new CogPMAlignTool();
        public CogImage8Grey m_imgSource_Mono = new CogImage8Grey();
        public CogImage16Grey cogImage16Grey = new CogImage16Grey();
        public CogImage24PlanarColor m_imgSource_Color = new CogImage24PlanarColor();

        public List<CogImage24PlanarColor> lst_imgSource_Color = new List<CogImage24PlanarColor>();
        public List<CogImage8Grey> lst_imgSource_Mono = new List<CogImage8Grey>();

        private CogImage8Grey m_ImageSource2 = new CogImage8Grey();
        private CogRectangle cogROI = new CogRectangle();
        private CogRectangleAffine cogPatternROI = new CogRectangleAffine();

        public CogImage8Grey FixtureSource1 = new CogImage8Grey();
        public CogImage8Grey FixtureSource2 = new CogImage8Grey();

        private DockPanel dockPanel;

        public JOB_TEMP m_SelectedJob = null;
        public JOB_BLOB m_SeletedBlob = null;

        public JOB_COLORMATCH m_SelectedColor = null;
        public JOB_OCR m_SelectedOCR = null;

        public JOB_MUTIPMALIGN m_SelectedMultiPMAlign = null;

        //public GRAB_SEQ m_SelectedGrab;
        public JOB_SEQ m_SelectedGrab;

        public CogImage8Grey m_imgSource_Equalize = new CogImage8Grey();
        public CogImage8Grey m_imgSource_Quantize = new CogImage8Grey();

        private CogDisplayStatusBarV2 m_cogDisplayStatus = new CogDisplayStatusBarV2();

        public CSQLite sqlite;

        int nSelect_Job_Index = 0;
        int nSelect_Seq_Index = 0;
        int nSelect_Blob_Index = 0;
        int nSelect_ColorMatch_Index = 0;
        int nSelect_OCR_Index = 0;
        int nSelect_MultiPMAlign_Index = 0;

        public Color ExtractColor = new Color();
        CogOCRMaxTool TrainOCR = new CogOCRMaxTool();

        public enum VisionProcessMode
        {
            Blob,
            Pattern,
            Filter
        }

        private VisionProcessMode m_VisionMode = VisionProcessMode.Blob;
        public VisionProcessMode VisionMode
        {
            get { return m_VisionMode; }
            set
            {
                m_VisionMode = value;

                int nIndex = cbCamera.SelectedIndex;
                switch (VisionMode.ToString())
                {
                    case DEFINE.Blob:
                        LoadParameterBlob(nIndex);
                        break;
                    case DEFINE.Pattern:
                        //propertygrid_Base.SelectedObject = CVisionTools.PMALIGN_Pattern.Tool.RunParams;
                        //LoadParameterPattern();
                        break;
                    case DEFINE.Filter:
                        break;
                }
            }
        }


        #region Event Register        
        public EventHandler<EventArgs> EventUpdateUi;
        #endregion

        public FormTeachingVision()
        {
            InitializeComponent();
        }

        private void FormTeachingVision_Load(object sender, EventArgs e)
        {
            InitEvent();
            InitProperty();
            InitUI();
        }

        private void FormTeachingVision_Show(object sender, EventArgs e)
        {
            //InitUI();
        }



        //protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        //{
        //    Keys key = keyData & ~(Keys.Shift | Keys.Control);

        //    switch (key)
        //    {
        //        case Keys.Escape:
        //            //if (CUtil.ShowMessageBox("Notice", "창을 닫으시겠습니까?"))
        //            //{
        //            //    this.DialogResult = DialogResult.Cancel;
        //            //    this.Close();
        //            //}
        //            return true;
        //        case Keys.Q:

        //            return true;
        //        case Keys.W:

        //            return true;
        //        case Keys.E:

        //            return true;
        //        case Keys.R:

        //            return true;
        //        case Keys.T:

        //            return true;
        //        case Keys.Y:

        //            return true;
        //        case Keys.U:

        //            return true;
        //        case Keys.I:

        //            return true;
        //        case Keys.O:

        //            return true;
        //        // Train
        //        case Keys.F1:
        //            return true;
        //        // ROI
        //        case Keys.F2:

        //            return true;
        //        // Modify
        //        case Keys.F3:

        //            return true;
        //        // RUN
        //        case Keys.F5:
        //            Test();
        //            //Global.iData.GrabQueue.Enqueue(new CGrabBuffer(m_ImageSource, 0));
        //            return true;
        //        case Keys.F7:
        //            SaveParameter();
        //            return true;
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        private object obj = new object();

        private void OnGrabEnd(object sender, IndexEventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnGrabEnd(sender, e);
                    }));
                }
                catch (Exception ex)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
            else
            {
                try
                {
                    if (Global.System.MENU.ToUpper() != "VISION")
                    {

                        return;
                    }
                    //if (Global.System.Mode == ISystem.MODE.AUTO) return;

                    lock (obj)
                    {
                       
                            switch (e.m_Index)
                            {
                                case DEFINE.CAM1:

                                    m_imgSource_Color = new CogImage24PlanarColor((CogImage24PlanarColor)CCognexUtil.FlipRotateEx(Global.Device.Cameras[DEFINE.CAM1].ImageCogGrab, (CogIPOneImageFlipRotateOperationConstants)Enum.Parse(typeof(CogIPOneImageFlipRotateOperationConstants), Global.Parameter.Cam1_ImageProcess.FlipRotate), true));
                                
                                break;
                                case DEFINE.CAM2: 
                                    m_imgSource_Color = new CogImage24PlanarColor((CogImage24PlanarColor)CCognexUtil.FlipRotateEx(Global.Device.Cameras[DEFINE.CAM2].ImageCogGrab, (CogIPOneImageFlipRotateOperationConstants)Enum.Parse(typeof(CogIPOneImageFlipRotateOperationConstants), Global.Parameter.Cam2_ImageProcess.FlipRotate), true));
                                
                                break;
                            }


                            m_imgSource_Mono = CogImageConvert.GetIntensityImage(m_imgSource_Color, 0, 0, m_imgSource_Color.Width, m_imgSource_Color.Height);
                            
                        
                    }


                    //cogDisplay_Source.Image = null;
                    cogDisplay_Source.Image = new CogImage24PlanarColor(m_imgSource_Color);
                    //cogDisplay_Source.Fit(true);
                    //lst_imgSource_Color.Add(m_imgSource_Color);


                }
                catch (Exception ex)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
        }

        private void FormTeachingMotion_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private bool InitEvent()
        {
            try
            {
                EventUpdateUi += OnUpdateUi;
                EventUpdateUi(null, null);

                Global.System.Recipe.EventChagedRecipe += OnChangedRecipe;

                for (int i = 0; i < Global.Device.Cameras.Count; i++)
                {
                    Global.Device.Cameras[i].EventGrabEnd += OnGrabEnd;
                }

                if (Global.SeqVision == null) Global.SeqVision = new CSeqVision();
                Global.SeqVision.EventInspResult += OnInspResult;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }
            return true;
        }

        private void OnInspResult(object sender, InspResultArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        OnInspResult(sender, e);
                    }));
                }
                catch (Exception Desc)
                {
                    CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, Desc.Message);
                }
            }
            else
            {

            }
        }

        public void InitGridSQL()
        {
            List<string[]> list = null;
            sqlite = Global.DB;

            list = sqlite.Select_Model_CAM("FirstInspection",Global.System.Recipe.Name, cbCamera.SelectedItem.ToString());
            grid_DATA.Rows.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                grid_DATA.Rows.Insert(0, list[i]);
            }

        }

        private bool InitUI()
        {
            try
            {
                m_cogDisplayStatus.Display = cogDisplay_Source;
                m_cogDisplayStatus.CoordinateSpaceName = "*\\#";

                cbCamFlipRotate.DataSource = Enum.GetValues(typeof(CogIPOneImageFlipRotateOperationConstants));
                cbCamFlipRotate.Text = Global.Parameter.Cam1_ImageProcess.FlipRotate;
                
                //cbCamFlipRotate.SelectedItem = Global.Parameter.Cam1_ImageProcess.FlipRotate;

                tbModelCode.Text = CVisionTools.ID_CAM1.ModelCode;
                Grid_ModelCODE.Rows.Clear();
                for(int i=0; i < Global.System.Recipe.ModelCode.Count; i++)
                {
                    Grid_ModelCODE.Rows.Add(new object[] { Global.System.Recipe.ModelCode[i] });
                }
                
                cbPatternRegionMode.SelectedIndex = 0;

                if (CVisionTools.PMALIGN_CAM1.Tool.Pattern.TrainImage != null
                   && CVisionTools.PMALIGN_CAM1.Tool.Pattern.TrainImage.Allocated)
                {

                    cogDisplay_Cam1_Fiducial.Image = CVisionTools.PMALIGN_CAM1.Tool.Pattern.GetTrainedPatternImage();

                    cogDisplay_Cam1_Fiducial.Fit(true);

                }

                if (CVisionTools.PMALIGN_CAM2.Tool.Pattern.TrainImage != null
                   && CVisionTools.PMALIGN_CAM2.Tool.Pattern.TrainImage.Allocated)
                {
                    cogDisplay_Cam2_Fiducial.Image = CVisionTools.PMALIGN_CAM2.Tool.Pattern.GetTrainedPatternImage();

                    cogDisplay_Cam2_Fiducial.Fit(true);

                }

                chk_Cam1FixtureUSE.Checked = CVisionTools.FIXTURE_CAM1.FixtureUSE;
                chk_Cam2FixtureUSE.Checked = CVisionTools.FIXTURE_CAM2.FixtureUSE;


                if (CVisionTools.Grab_seq.Count > 0)
                {
                    gridSeq.Rows[0].Selected = true;
                    m_SelectedGrab = CVisionTools.Grab_seq[0];
                    //chk_GrabSeqUSE.Checked = m_SelectedGrab.USE;
                }

                chk_GrabSeqUSE.Checked = CVisionTools.JOB_SEQ_USE_CAM1;

                if (CVisionTools.Jobs.Count > 0)
                {
                    gridJobs.Rows[0].Selected = true;
                    m_SelectedJob = CVisionTools.Jobs[0];
                    tbJobScoreMin.Text = m_SelectedJob.Matching.Tool.RunParams.AcceptThreshold.ToString();
                    chk_jobsNotOption.Checked = m_SelectedJob.NotOption;
                    chk_jobsQuantizeUSE.Checked = m_SelectedJob.QuantizeUse;
                    cbojobQuantizeLevel.SelectedIndex = m_SelectedJob.QuantizeLevel;
                    chk_jobsEqualizeUse.Checked = m_SelectedJob.EqualizeUse;
                    cbJobUse.Checked = m_SelectedJob.InspectionUse;
                    chk_jobMaskUse.Checked = m_SelectedJob.MaskingUse;
                    tbReverseMaxAngle.Text = m_SelectedJob.ANGLE.ToString();

                    cbInspType.Text = m_SelectedJob.INSP_TYPE;
                }

                if (CVisionTools.MultiPMAlign.Count > 0)
                {
                    gridMultiPMAlign.Rows[0].Selected = true;
                    m_SelectedMultiPMAlign = CVisionTools.MultiPMAlign[0];
                    tbMultiPMAlignScoreMIN.Text = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.AcceptThreshold.ToString();
                    chk_MultiPMAlignNOTOPTIONUSE.Checked = m_SelectedMultiPMAlign.NotOption;
                    chk_MultiPMAlignQuantizeUSE.Checked = m_SelectedMultiPMAlign.QuantizeUse;
                    cboMultiPMAlignLEVEL.SelectedIndex = m_SelectedMultiPMAlign.QuantizeLevel;
                    chk_MultiPMAlignEqualizeUSE.Checked = m_SelectedMultiPMAlign.EqualizeUse;
                    chk_MultiPMAlignUSE.Checked = m_SelectedMultiPMAlign.InspectionUse;
                    chk_MultiPMAlignMASKINGUSE.Checked = m_SelectedMultiPMAlign.MaskingUse;
                    tbMultiPMAlignANGLE.Text = m_SelectedMultiPMAlign.ANGLE.ToString();

                    cboMultiPMAlignInsType.Text = m_SelectedMultiPMAlign.INSP_TYPE;
                    chk_MultiPMAlignThresholdUSE.Checked = m_SelectedMultiPMAlign.ThresholdUse;

                    lbThreshold.Text = m_SelectedMultiPMAlign.ThresholdValue.ToString();
                    //trbThreshold.Value = m_SelectedMultiPMAlign.ThresholdValue;


                    cboPatternINDEX.Items.Clear();
                    for (int i = 0; i < m_SelectedMultiPMAlign.Matching.Tool.Operator.Count; i++)
                    {
                        cboPatternINDEX.Items.Add(i + 1);

                    }
                    
                    if(m_SelectedMultiPMAlign.Matching.Tool.Operator.Count > 0) { cboPatternINDEX.SelectedIndex = 0; }
                    
                }

                if (CVisionTools.Blobs.Count > 0)
                {
                    gridBlob.Rows[0].Selected = true;
                    m_SeletedBlob = CVisionTools.Blobs[0];
                    propertyGrid_Blob.SelectedObject = m_SeletedBlob.BLOB.Tool.RunParams;
                    chk_BlobUse.Checked = m_SeletedBlob.InspectionUse;
                }

                if (CVisionTools.ColorMatch.Count > 0)
                {
                    GridColor.Rows[0].Selected = true;
                    m_SelectedColor = CVisionTools.ColorMatch[0];
                    propertyGrid_ColorMatch.SelectedObject = m_SelectedColor.COLORMATCH.Tool.RunParams;
                    chk_ColorUSE.Checked = m_SelectedColor.InspectionUse;
                    
                    for(int i = 0; i < m_SelectedColor.COLORMATCH.COLOR.Count; i++)
                    {
                        cboColorINDEX.Items.Add(m_SelectedColor.COLORMATCH.COLOR[i]);
                    }
                    
                }

                if (CVisionTools.OCR.Count > 0)
                {
                    grid_OCV.Rows[0].Selected = true;
                    m_SelectedOCR = CVisionTools.OCR[0];
                    propertyGrid_OCV.SelectedObject = m_SelectedOCR.OCR.Tool.ClassifierRunParams;
                    chk_OCVUse.Checked = m_SelectedOCR.InspectionUse;
                    tbOCRSCORE.Text = m_SelectedOCR.OCR.Tool.ClassifierRunParams.AcceptThreshold.ToString();
                    //tbTRAINOCR.Text = m_SelectedOCR.TRAIN_OCR;
                    tbCOMPARESTRING.Text = m_SelectedOCR.COMPARE_STRING;

                    cboOCRINDEX.Items.Clear();
                    for (int i = 0; i < m_SelectedOCR.OCR.Tool.Classifier.Font.Count; i++)
                    {
                        cboOCRINDEX.Items.Add((i+1).ToString() + ". OCR:" + ((char)m_SelectedOCR.OCR.Tool.Classifier.Font[i].CharacterCode));
                    }
                }

                gridJobs.Rows.Clear();
                for (int i = 0; i < CVisionTools.Jobs.Count; i++)
                {
                    gridJobs.Rows.Add(new object[] { CVisionTools.Jobs[i].NAME, CVisionTools.Jobs[i].INSP_TYPE, CVisionTools.Jobs[i].MASTER_COUNT.ToString(), CVisionTools.Jobs[i].ANGLE.ToString(), CVisionTools.Jobs[i].NotOption.ToString(), CVisionTools.Jobs[i].QuantizeUse.ToString(), CVisionTools.Jobs[i].QuantizeLevel.ToString(), CVisionTools.Jobs[i].EqualizeUse.ToString(), CVisionTools.Jobs[i].InspectionUse.ToString(), CVisionTools.Jobs[i].MaskingUse.ToString() });
                }

                gridMultiPMAlign.Rows.Clear();
                for (int i = 0; i < CVisionTools.MultiPMAlign.Count; i++)
                {
                    gridMultiPMAlign.Rows.Add(new object[] { CVisionTools.MultiPMAlign[i].NAME, CVisionTools.MultiPMAlign[i].INSP_TYPE, CVisionTools.MultiPMAlign[i].MASTER_COUNT.ToString(), CVisionTools.MultiPMAlign[i].ANGLE.ToString(), CVisionTools.MultiPMAlign[i].NotOption.ToString(), CVisionTools.MultiPMAlign[i].QuantizeUse.ToString(), CVisionTools.MultiPMAlign[i].QuantizeLevel.ToString(), CVisionTools.MultiPMAlign[i].EqualizeUse.ToString(), CVisionTools.MultiPMAlign[i].InspectionUse.ToString(), CVisionTools.MultiPMAlign[i].MaskingUse.ToString(), CVisionTools.MultiPMAlign[i].ThresholdUse.ToString(), CVisionTools.MultiPMAlign[i].ThresholdValue.ToString() });
                }

                gridSeq.Rows.Clear();

                for (int i = 0; i < CVisionTools.Grab_seq.Count; i++)
                {
                    gridSeq.Rows.Add(new object[] { CVisionTools.Grab_seq[i].LightValue.ToString(), CVisionTools.Grab_seq[i].Exposure.ToString(), CVisionTools.Grab_seq[i].Gain.ToString() });
                }

                gridBlob.Rows.Clear();
                for (int i = 0; i < CVisionTools.Blobs.Count; i++)
                {
                    gridBlob.Rows.Add(new object[] { CVisionTools.Blobs[i].Defect_Name, CVisionTools.Blobs[i].Defect_MasterCount, CVisionTools.Blobs[i].Defect_Threshold, CVisionTools.Blobs[i].Defect_Min, CVisionTools.Blobs[i].Defect_Max, CVisionTools.Blobs[i].InspectionUse.ToString() });
                }

                GridColor.Rows.Clear();
                for(int i = 0; i < CVisionTools.ColorMatch.Count; i++)
                {
                    GridColor.Rows.Add(new object[] { CVisionTools.ColorMatch[i].Defect_Name, CVisionTools.ColorMatch[i].InspectionUse.ToString(), CVisionTools.ColorMatch[i].ColorCount.ToString(), CVisionTools.ColorMatch[i].SCORE.ToString() });
                }

                grid_OCV.Rows.Clear();
                for (int i = 0; i < CVisionTools.OCR.Count; i++)
                {
                    GridColor.Rows.Add(new object[] { CVisionTools.OCR[i].Defect_Name, CVisionTools.OCR[i].InspectionUse.ToString(), CVisionTools.OCR[i].COMPARE_STRING});
                }

                InitCameraItem();
                

                CUtil.InitCombobox(this.Controls);

                
                cbLightCh.SelectedIndex = 0;
                cbojobQuantizeLevel.SelectedIndex = 0;


                nbCamExposure.Value = Global.Device.Cameras[cbCamera.SelectedIndex].Property.EXPOSURETIME_US;
                nbCamGain.Value = Global.Device.Cameras[cbCamera.SelectedIndex].Property.GAIN;



                if (CVisionTools.Equalize.Equalize_USE)
                {
                    chk_EqualizeUse.Checked = true;
                }
                else
                {
                    chk_EqualizeUse.Checked = false;
                }

                if (CVisionTools.Quantize.Quantize_USE)
                {
                    chk_QuantizeUse.Checked = true;
                }
                else
                {
                    chk_QuantizeUse.Checked = false;
                }

                cbo_QuantizeLevel.SelectedIndex = CVisionTools.Quantize.Quantize_Level;

                if (Global.System.OK_IMAGE_SAVE)
                {
                    chkOKImageSAVE.Checked = true;
                }
                else
                {
                    chkOKImageSAVE.Checked = false;
                }

                if (Global.System.NG_IMAGE_SAVE)
                {
                    chkNGImageSave.Checked = true;
                }
                else
                {
                    chkNGImageSave.Checked = false;
                }

                InitGridSQL();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void UpdateSetting(int camindex)
        {
            try
            {
                if (cbCamera.SelectedIndex == 0)
                {
                    if (CVisionTools.Jobs.Count > 0)
                    {
                        gridJobs.Rows[0].Selected = true;
                        m_SelectedJob = CVisionTools.Jobs[0];
                        tbJobScoreMin.Text = m_SelectedJob.Matching.Tool.RunParams.AcceptThreshold.ToString();
                        chk_jobsNotOption.Checked = m_SelectedJob.NotOption;
                        chk_jobsQuantizeUSE.Checked = m_SelectedJob.QuantizeUse;
                        cbojobQuantizeLevel.SelectedIndex = m_SelectedJob.QuantizeLevel;
                        chk_jobsEqualizeUse.Checked = m_SelectedJob.EqualizeUse;
                        cbJobUse.Checked = m_SelectedJob.InspectionUse;
                        chk_jobMaskUse.Checked = m_SelectedJob.MaskingUse;
                        cbInspType.Text = m_SelectedJob.INSP_TYPE;
                    }

                    if (CVisionTools.MultiPMAlign.Count > 0)
                    {
                        gridMultiPMAlign.Rows[0].Selected = true;
                        m_SelectedMultiPMAlign = CVisionTools.MultiPMAlign[0];
                        tbMultiPMAlignScoreMIN.Text = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.AcceptThreshold.ToString();
                        chk_MultiPMAlignNOTOPTIONUSE.Checked = m_SelectedMultiPMAlign.NotOption;
                        chk_MultiPMAlignQuantizeUSE.Checked = m_SelectedMultiPMAlign.QuantizeUse;
                        cboMultiPMAlignLEVEL.SelectedIndex = m_SelectedMultiPMAlign.QuantizeLevel;
                        chk_MultiPMAlignEqualizeUSE.Checked = m_SelectedMultiPMAlign.EqualizeUse;
                        chk_MultiPMAlignUSE.Checked = m_SelectedMultiPMAlign.InspectionUse;
                        chk_MultiPMAlignMASKINGUSE.Checked = m_SelectedMultiPMAlign.MaskingUse;
                        tbMultiPMAlignANGLE.Text = m_SelectedMultiPMAlign.ANGLE.ToString();
                        cboMultiPMAlignInsType.Text = m_SelectedMultiPMAlign.INSP_TYPE;

                        chk_MultiPMAlignThresholdUSE.Checked = m_SelectedMultiPMAlign.ThresholdUse;
                        trbThreshold.Text = m_SelectedMultiPMAlign.ThresholdValue.ToString();

                        cboPatternINDEX.Items.Clear();
                        for (int i = 0; i < m_SelectedMultiPMAlign.Matching.Tool.Operator.Count; i++)
                        {
                            cboPatternINDEX.Items.Add(i + 1);

                        }

                        if (m_SelectedMultiPMAlign.Matching.Tool.Operator.Count > 0) { cboPatternINDEX.SelectedIndex = 0; }

                    }



                    if (CVisionTools.Blobs.Count > 0)
                    {
                        gridBlob.Rows[0].Selected = true;
                        m_SeletedBlob = CVisionTools.Blobs[0];
                        propertyGrid_Blob.SelectedObject = m_SeletedBlob.BLOB.Tool.RunParams;
                        chk_BlobUse.Checked = m_SeletedBlob.InspectionUse;


                    }

                    if (CVisionTools.ColorMatch.Count > 0)
                    {
                        GridColor.Rows[0].Selected = true;
                        m_SelectedColor = CVisionTools.ColorMatch[0];
                        propertyGrid_ColorMatch.SelectedObject = m_SelectedColor.COLORMATCH.Tool.RunParams;
                        chk_ColorUSE.Checked = m_SelectedColor.InspectionUse;

                        for (int i = 0; i < m_SelectedColor.COLORMATCH.COLOR.Count; i++)
                        {
                            cboColorINDEX.Items.Add(m_SelectedColor.COLORMATCH.COLOR[i]);
                        }


                    }

                    if (CVisionTools.OCR.Count > 0)
                    {
                        grid_OCV.Rows[0].Selected = true;
                        m_SelectedOCR = CVisionTools.OCR[0];
                        propertyGrid_OCV.SelectedObject = m_SelectedOCR.OCR.Tool.ClassifierRunParams;
                        chk_OCVUse.Checked = m_SelectedOCR.InspectionUse;

                        tbOCRSCORE.Text = m_SelectedOCR.OCR.Tool.ClassifierRunParams.AcceptThreshold.ToString();
                        //tbTRAINOCR.Text = m_SelectedOCR.TRAIN_OCR;
                        tbCOMPARESTRING.Text = m_SelectedOCR.COMPARE_STRING;

                        cboOCRINDEX.Items.Clear();
                        for (int i = 0; i < m_SelectedOCR.OCR.Tool.Classifier.Font.Count; i++)
                        {
                            //cboOCRINDEX.Items.Add(i + 1);
                            cboOCRINDEX.Items.Add((i + 1).ToString() + ". OCR:" + ((char)m_SelectedOCR.OCR.Tool.Classifier.Font[i].CharacterCode));
                        }

                    }

                    if(CVisionTools.Grab_seq.Count > 0)
                    {
                        gridSeq.Rows[0].Selected = true;
                        m_SelectedGrab = CVisionTools.Grab_seq[0];

                        //chk_GrabSeqUSE.Checked = m_SelectedGrab.USE;
                    }

                    chk_GrabSeqUSE.Checked = CVisionTools.JOB_SEQ_USE_CAM1;

                    gridJobs.Rows.Clear();
                    for (int i = 0; i < CVisionTools.Jobs.Count; i++)
                    {
                        if (CVisionTools.Jobs[i].INSP_TYPE == "REGION INSPECTION" || CVisionTools.Jobs[i].INSP_TYPE == "")
                        {
                            CVisionTools.Jobs[i].INSP_TYPE = "EXISTS/REVERSE";
                        }
                        gridJobs.Rows.Add(new object[] { CVisionTools.Jobs[i].NAME, CVisionTools.Jobs[i].INSP_TYPE, CVisionTools.Jobs[i].MASTER_COUNT.ToString(), CVisionTools.Jobs[i].ANGLE.ToString(), CVisionTools.Jobs[i].NotOption.ToString(), CVisionTools.Jobs[i].QuantizeUse.ToString(), CVisionTools.Jobs[i].QuantizeLevel.ToString(), CVisionTools.Jobs[i].EqualizeUse.ToString(), CVisionTools.Jobs[i].InspectionUse.ToString(), CVisionTools.Jobs[i].MaskingUse.ToString() }); ;
                    }

                    gridMultiPMAlign.Rows.Clear();
                    for (int i = 0; i < CVisionTools.MultiPMAlign.Count; i++)
                    {
                        gridMultiPMAlign.Rows.Add(new object[] { CVisionTools.MultiPMAlign[i].NAME, CVisionTools.MultiPMAlign[i].INSP_TYPE, CVisionTools.MultiPMAlign[i].MASTER_COUNT.ToString(), CVisionTools.MultiPMAlign[i].ANGLE.ToString(), CVisionTools.MultiPMAlign[i].NotOption.ToString(), CVisionTools.MultiPMAlign[i].QuantizeUse.ToString(), CVisionTools.MultiPMAlign[i].QuantizeLevel.ToString(), CVisionTools.MultiPMAlign[i].EqualizeUse.ToString(), CVisionTools.MultiPMAlign[i].InspectionUse.ToString(), CVisionTools.MultiPMAlign[i].MaskingUse.ToString(), CVisionTools.MultiPMAlign[i].ThresholdUse.ToString(), CVisionTools.MultiPMAlign[i].ThresholdValue.ToString() });
                    }

                    gridSeq.Rows.Clear();

                    for (int i = 0; i < CVisionTools.Grab_seq.Count; i++)
                    {
                        gridSeq.Rows.Add(new object[] { CVisionTools.Grab_seq[i].LightValue.ToString(), CVisionTools.Grab_seq[i].Exposure.ToString(), CVisionTools.Grab_seq[i].Gain.ToString() });
                    }

                    gridBlob.Rows.Clear();
                    for (int i = 0; i < CVisionTools.Blobs.Count; i++)
                    {
                        gridBlob.Rows.Add(new object[] { CVisionTools.Blobs[i].Defect_Name, CVisionTools.Blobs[i].Defect_MasterCount, CVisionTools.Blobs[i].Defect_Threshold, CVisionTools.Blobs[i].Defect_Min, CVisionTools.Blobs[i].Defect_Max, CVisionTools.Blobs[i].InspectionUse.ToString() });
                    }

                    GridColor.Rows.Clear();
                    for (int i = 0; i < CVisionTools.ColorMatch.Count; i++)
                    {
                        GridColor.Rows.Add(new object[] { CVisionTools.ColorMatch[i].Defect_Name, CVisionTools.ColorMatch[i].InspectionUse.ToString(), CVisionTools.ColorMatch[i].ColorCount.ToString(), CVisionTools.ColorMatch[i].SCORE.ToString() });
                    }

                    grid_OCV.Rows.Clear();
                    for (int i = 0; i < CVisionTools.OCR.Count; i++)
                    {
                        grid_OCV.Rows.Add(new object[] { CVisionTools.OCR[i].Defect_Name, CVisionTools.OCR[i].InspectionUse.ToString(), CVisionTools.OCR[i].COMPARE_STRING});
                    }
                }
                else
                {
                    if (CVisionTools.Jobs2.Count > 0)
                    {
                        gridJobs.Rows[0].Selected = true;
                        m_SelectedJob = CVisionTools.Jobs2[0];
                        tbJobScoreMin.Text = m_SelectedJob.Matching.Tool.RunParams.AcceptThreshold.ToString();
                        chk_jobsNotOption.Checked = m_SelectedJob.NotOption;
                        chk_jobsQuantizeUSE.Checked = m_SelectedJob.QuantizeUse;
                        cbojobQuantizeLevel.SelectedIndex = m_SelectedJob.QuantizeLevel;
                        chk_jobsEqualizeUse.Checked = m_SelectedJob.EqualizeUse;
                        cbJobUse.Checked = m_SelectedJob.InspectionUse;
                        chk_jobMaskUse.Checked = m_SelectedJob.MaskingUse;
                        cbInspType.Text = m_SelectedJob.INSP_TYPE;
                    }

                    if (CVisionTools.MultiPMAlign2.Count > 0)
                    {
                        gridMultiPMAlign.Rows[0].Selected = true;
                        m_SelectedMultiPMAlign = CVisionTools.MultiPMAlign2[0];
                        tbMultiPMAlignScoreMIN.Text = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.AcceptThreshold.ToString();
                        chk_MultiPMAlignNOTOPTIONUSE.Checked = m_SelectedMultiPMAlign.NotOption;
                        chk_MultiPMAlignQuantizeUSE.Checked = m_SelectedMultiPMAlign.QuantizeUse;
                        cboMultiPMAlignLEVEL.SelectedIndex = m_SelectedMultiPMAlign.QuantizeLevel;
                        chk_MultiPMAlignEqualizeUSE.Checked = m_SelectedMultiPMAlign.EqualizeUse;
                        chk_MultiPMAlignUSE.Checked = m_SelectedMultiPMAlign.InspectionUse;
                        chk_MultiPMAlignMASKINGUSE.Checked = m_SelectedMultiPMAlign.MaskingUse;
                        tbMultiPMAlignANGLE.Text = m_SelectedMultiPMAlign.ANGLE.ToString();
                        cboMultiPMAlignInsType.Text = m_SelectedMultiPMAlign.INSP_TYPE;

                        chk_MultiPMAlignThresholdUSE.Checked = m_SelectedMultiPMAlign.ThresholdUse;
                        trbThreshold.Text = m_SelectedMultiPMAlign.ThresholdValue.ToString();

                        cboPatternINDEX.Items.Clear();
                        for (int i = 0; i < m_SelectedMultiPMAlign.Matching.Tool.Operator.Count; i++)
                        {
                            cboPatternINDEX.Items.Add(i + 1);

                        }

                        if (m_SelectedMultiPMAlign.Matching.Tool.Operator.Count > 0) { cboPatternINDEX.SelectedIndex = 0; }

                    }


                    if (CVisionTools.Blobs2.Count > 0)
                    {
                        gridBlob.Rows[0].Selected = true;
                        m_SeletedBlob = CVisionTools.Blobs2[0];
                        propertyGrid_Blob.SelectedObject = m_SeletedBlob.BLOB.Tool.RunParams;
                        chk_BlobUse.Checked = m_SeletedBlob.InspectionUse;

                    }

                    if (CVisionTools.ColorMatch2.Count > 0)
                    {
                        GridColor.Rows[0].Selected = true;
                        m_SelectedColor = CVisionTools.ColorMatch2[0];
                        propertyGrid_ColorMatch.SelectedObject = m_SelectedColor.COLORMATCH.Tool.RunParams;
                        chk_ColorUSE.Checked = m_SelectedColor.InspectionUse;

                        for (int i = 0; i < m_SelectedColor.COLORMATCH.COLOR.Count; i++)
                        {
                            cboColorINDEX.Items.Add(m_SelectedColor.COLORMATCH.COLOR[i]);
                        }

                    }

                    if (CVisionTools.OCR2.Count > 0)
                    {
                        grid_OCV.Rows[0].Selected = true;
                        m_SelectedOCR = CVisionTools.OCR2[0];
                        propertyGrid_OCV.SelectedObject = m_SelectedOCR.OCR.Tool.ClassifierRunParams;
                        chk_OCVUse.Checked = m_SelectedOCR.InspectionUse;

                        tbOCRSCORE.Text = m_SelectedOCR.OCR.Tool.ClassifierRunParams.AcceptThreshold.ToString();
                        //tbTRAINOCR.Text = m_SelectedOCR.TRAIN_OCR;
                        tbCOMPARESTRING.Text = m_SelectedOCR.COMPARE_STRING;
                    }

                    if (CVisionTools.Grab_seq2.Count > 0)
                    {
                        gridSeq.Rows[0].Selected = true;
                        m_SelectedGrab = CVisionTools.Grab_seq2[0];

                        //chk_GrabSeqUSE.Checked = m_SelectedGrab.USE;
                    }

                    chk_GrabSeqUSE.Checked = CVisionTools.JOB_SEQ_USE_CAM2;

                    gridJobs.Rows.Clear();
                    for (int i = 0; i < CVisionTools.Jobs2.Count; i++)
                    {
                        if (CVisionTools.Jobs2[i].INSP_TYPE == "REGION INSPECTION" || CVisionTools.Jobs2[i].INSP_TYPE == "")
                        {
                            CVisionTools.Jobs2[i].INSP_TYPE = "EXISTS/REVERSE";
                        }
                        gridJobs.Rows.Add(new object[] { CVisionTools.Jobs2[i].NAME, CVisionTools.Jobs2[i].INSP_TYPE, CVisionTools.Jobs2[i].MASTER_COUNT.ToString(), CVisionTools.Jobs2[i].ANGLE.ToString(), CVisionTools.Jobs2[i].NotOption.ToString(), CVisionTools.Jobs2[i].QuantizeUse.ToString(), CVisionTools.Jobs2[i].QuantizeLevel.ToString(), CVisionTools.Jobs2[i].EqualizeUse.ToString(), CVisionTools.Jobs2[i].InspectionUse.ToString(), CVisionTools.Jobs2[i].MaskingUse.ToString() }); ;
                    }

                    gridMultiPMAlign.Rows.Clear();
                    for (int i = 0; i < CVisionTools.MultiPMAlign2.Count; i++)
                    {
                        gridMultiPMAlign.Rows.Add(new object[] { CVisionTools.MultiPMAlign2[i].NAME, CVisionTools.MultiPMAlign2[i].INSP_TYPE, CVisionTools.MultiPMAlign2[i].MASTER_COUNT.ToString(), CVisionTools.MultiPMAlign2[i].ANGLE.ToString(), CVisionTools.MultiPMAlign2[i].NotOption.ToString(), CVisionTools.MultiPMAlign2[i].QuantizeUse.ToString(), CVisionTools.MultiPMAlign2[i].QuantizeLevel.ToString(), CVisionTools.MultiPMAlign2[i].EqualizeUse.ToString(), CVisionTools.MultiPMAlign2[i].InspectionUse.ToString(), CVisionTools.MultiPMAlign2[i].MaskingUse.ToString(), CVisionTools.MultiPMAlign2[i].ThresholdUse.ToString(), CVisionTools.MultiPMAlign2[i].ThresholdValue.ToString() });
                    }

                    gridSeq.Rows.Clear();

                    for (int i = 0; i < CVisionTools.Grab_seq2.Count; i++)
                    {
                        gridSeq.Rows.Add(new object[] { CVisionTools.Grab_seq2[i].LightValue.ToString(), CVisionTools.Grab_seq2[i].Exposure.ToString(), CVisionTools.Grab_seq2[i].Gain.ToString() });
                    }

                    gridBlob.Rows.Clear();
                    for (int i = 0; i < CVisionTools.Blobs2.Count; i++)
                    {
                        gridBlob.Rows.Add(new object[] { CVisionTools.Blobs2[i].Defect_Name, CVisionTools.Blobs2[i].Defect_MasterCount, CVisionTools.Blobs2[i].Defect_Threshold, CVisionTools.Blobs2[i].Defect_Min, CVisionTools.Blobs2[i].Defect_Max, CVisionTools.Blobs2[i].InspectionUse.ToString() });
                    }

                    GridColor.Rows.Clear();
                    for (int i = 0; i < CVisionTools.ColorMatch2.Count; i++)
                    {
                        GridColor.Rows.Add(new object[] { CVisionTools.ColorMatch2[i].Defect_Name, CVisionTools.ColorMatch2[i].InspectionUse.ToString(), CVisionTools.ColorMatch2[i].ColorCount.ToString(), CVisionTools.ColorMatch2[i].SCORE.ToString() }); ;
                    }

                    grid_OCV.Rows.Clear();
                    for (int i = 0; i < CVisionTools.OCR2.Count; i++)
                    {
                        grid_OCV.Rows.Add(new object[] { CVisionTools.OCR2[i].Defect_Name, CVisionTools.OCR2[i].InspectionUse.ToString(), CVisionTools.OCR2[i].COMPARE_STRING }); ;
                    }
                }

                //if (m_SelectedJob.Matching.Tool.Pattern.Trained)
                //{
                //    cogDisplay_Pattern.Image = m_SelectedJob.Matching.Tool.Pattern.GetTrainedPatternImage();
                //}

            }
            catch (Exception exc)
            {

            }



        }




        private void InitCameraItem()
        {
            cbCamera.Items.Clear();
            for (int i = 0; i < Global.Device.CAMERA_COUNT; i++)
            {
                cbCamera.Items.Add("Camera " + (i + 1));
            }

            cbCamera.SelectedIndex = 0;
            //mainTab.SelectedIndex = 0;
        }

        private void InitRotateItem()
        {
            cbCamFlipRotate.Items.Add(CogIPOneImageFlipRotateOperationConstants.None);
            cbCamFlipRotate.Items.Add(CogIPOneImageFlipRotateOperationConstants.Flip);
            cbCamFlipRotate.Items.Add(CogIPOneImageFlipRotateOperationConstants.FlipAndRotate90Deg);
            cbCamFlipRotate.Items.Add(CogIPOneImageFlipRotateOperationConstants.FlipAndRotate180Deg);
            cbCamFlipRotate.Items.Add(CogIPOneImageFlipRotateOperationConstants.FlipAndRotate270Deg);
            cbCamFlipRotate.Items.Add(CogIPOneImageFlipRotateOperationConstants.Rotate90Deg);
            cbCamFlipRotate.Items.Add(CogIPOneImageFlipRotateOperationConstants.Rotate180Deg);
            cbCamFlipRotate.Items.Add(CogIPOneImageFlipRotateOperationConstants.Rotate270Deg);

            cbCamFlipRotate.SelectedIndex = 0;
        }

        private bool InitProperty()
        {
            try
            {
                for (int i = 0; i < Global.Device.CAMERA_COUNT; i++)
                {
                    //LoadParameterPattern(i);
                    LoadParameterBlob(i);
                    LoadParameterColorMatch(i);
                    LoadParameterOCR(i);
                    //LoadParameterMultiPattern(i);
                   
                }
                //LoadParameterPattern();

                CVisionTools.Load_ModelCode_lst(Global.System.Recipe.Name, Global.System.Recipe.SubName);

                CVisionTools.Init();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void OnUpdateUi(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnUpdateUi(sender, e);
                    }));
                }
                catch (Exception ex)
                {
                    CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
            else
            {

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
        }

        private void OnChangedRecipe(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnChangedRecipe(sender, e);
                    }));
                }
                catch (Exception ex)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
            else
            {
                try
                {
                    InitProperty();
                    InitUI();
                }
                catch (Exception ex)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
        }

        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbCamera.SelectedItem == null) return;

                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();

                cogDisplay_Pattern.InteractiveGraphics.Clear();
                cogDisplay_Pattern.StaticGraphics.Clear();

                int nIndex = cbCamera.SelectedIndex;

                nbCamExposure.Value = Global.Device.Cameras[nIndex].Property.EXPOSURETIME_US;
                nbCamGain.Value = Global.Device.Cameras[nIndex].Property.GAIN;

                cbCamFlipRotate.Text = nIndex==0? Global.Parameter.Cam1_ImageProcess.FlipRotate: Global.Parameter.Cam2_ImageProcess.FlipRotate;

                if (btnLive.Text == "LIVE STOP")
                {
                    CUtil.ShowMessageBox("NOTICE", "Please LiveStop");
                    return;
                }

                switch (VisionMode.ToString())
                {
                    case DEFINE.Blob:
                        LoadParameterBlob(nIndex);
                        break;
                    case DEFINE.Pattern:
                        break;
                    case DEFINE.Filter:
                        break;
                }

                UpdateSetting(cbCamera.SelectedIndex);

                InitGridSQL();

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
        private void LoadParameterColorMatch(int nIndex)
        {
            try
            {
                switch (nIndex)
                {
                    case 0:
                        CVisionTools.ColorMatch_CAM1.LoadConfig(Global.System.Recipe.Name);
                       
                        break;
                    case 1:
                        CVisionTools.ColorMatch_CAM2.LoadConfig(Global.System.Recipe.Name);
                        
                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void LoadParameterOCR(int nIndex)
        {
            try
            {
                switch (nIndex)
                {
                    case 0:
                        CVisionTools.OCR_CAM1.LoadConfig(Global.System.Recipe.Name);

                        break;
                    case 1:
                        CVisionTools.OCR_CAM2.LoadConfig(Global.System.Recipe.Name);

                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void LoadParameterMultiPattern(int nIndex)
        {
            try
            {
                switch (nIndex)
                {
                    case 0:
                        CVisionTools.MutilPMAlign_CAM1.LoadConfig(Global.System.Recipe.Name);

                        break;
                    case 1:
                        CVisionTools.MutilPMAlign_CAM2.LoadConfig(Global.System.Recipe.Name);

                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }


        private void LoadParameterBlob(int nIndex)
        {
            try
            {
                switch (nIndex)
                {
                    case 0:
                        CVisionTools.BLOB_CAM1.LoadConfig(Global.System.Recipe.Name);
                        //propertygrid_Base.SelectedObject = CVisionTools.FindBlob_Camera1.Tool.RunParams.SegmentationParams;
                        //tbAreaSize.Text = CVisionTools.BLOB_CAM1.MinArea.ToString();
                        break;
                    case 1:
                        CVisionTools.BLOB_CAM2.LoadConfig(Global.System.Recipe.Name);
                        //propertygrid_Base.SelectedObject = CVisionTools.FindBlob_Camera2.Tool.RunParams.SegmentationParams;
                        //tbAreaSize.Text = CVisionTools.BLOB_CAM2.MinArea.ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void LoadParameterPattern()
        {
            try
            {
                CVisionTools.PMALIGN_Pattern.LoadConfig(Global.System.Recipe.Name);
                //propertygrid_Base.SelectedObject = CVisionTools.PMALIGN_Pattern.Tool.RunParams;
                cogDisplay_Pattern.Image = CVisionTools.PMALIGN_Pattern.TrainedPatternImage;
                cogDisplay_Pattern.Fit(true);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

        }

        private void LoadParameterPattern(int nIndex)
        {
            try
            {

                switch (nIndex)
                {
                    case 0:
                        CVisionTools.PMALIGN_Pattern.LoadConfig(Global.System.Recipe.Name);
                        //propertygrid_Base.SelectedObject = CVisionTools.PMALIGN_Pattern.Tool.RunParams;
                        cogDisplay_Pattern.Image = CVisionTools.PMALIGN_Pattern.TrainedPatternImage;
                        break;
                    case 1:
                        CVisionTools.PMALIGN_Pattern2.LoadConfig(Global.System.Recipe.Name);
                        //propertygrid_Base.SelectedObject = CVisionTools.PMALIGN_Pattern.Tool.RunParams;
                        cogDisplay_Pattern.Image = CVisionTools.PMALIGN_Pattern2.TrainedPatternImage;
                        break;
                }

                cogDisplay_Pattern.Fit(true);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

        }
        private void OnClickCameraOperation(object sender, EventArgs e)
        {
            try
            {
                if (!(sender is MetroButton)) return;

                string strIndex = (sender as MetroButton).Text;


                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();
                switch (strIndex)
                {
                    case DEFINE.Grab:
                        cogDisplay_Source.Image = null;
                        if (!Global.Device.Cameras[cbCamera.SelectedIndex].IsOpen) return;
                        btnLive.Text = "LIVE";
                        Global.Device.Cameras[cbCamera.SelectedIndex].Live(false);
                        Global.Device.Cameras[cbCamera.SelectedIndex].Grab(false);
                        //Global.Device.Cameras[cbCamera.SelectedIndex].IsGrabDone.WaitOne();
                        break;
                    case DEFINE.Live:
                        cogDisplay_Source.Image = null;
                        if (!Global.Device.Cameras[cbCamera.SelectedIndex].IsOpen) return;
                        (sender as MetroButton).Text = "LIVE STOP";
                        Global.Device.Cameras[cbCamera.SelectedIndex].Live(true);
                        btnGrab.Enabled = false;
                        cbCamera.Enabled = false;
                        break;
                    case DEFINE.Live_Stop:
                        if (!Global.Device.Cameras[cbCamera.SelectedIndex].IsOpen) return;
                        (sender as MetroButton).Text = "LIVE";
                        Global.Device.Cameras[cbCamera.SelectedIndex].Live(false);
                        btnGrab.Enabled = true;
                        cbCamera.Enabled = true;
                        break;
                    case DEFINE.Cross:
                        cogDisplay_Source.InteractiveGraphics.Clear();
                        UseCross = !UseCross;
                        break;
                    case DEFINE.Image_Load:
                        try
                        {
                            //cogDisplay_Source.InteractiveGraphics.Clear();
                            cogDisplay_Source.Image = null;
                            OpenFileDialog ofd = new OpenFileDialog();
                            ofd.Title = "Image Load";
                            ofd.Filter = "Image File (*.png, *.jpg, *.gif, *.bmp) | *.png; *.jpg; *.gif; *.bmp; | 모든 파일 (*.*) | *.*";

                            if (ofd.ShowDialog() == DialogResult.OK)
                            {
                                string strFilePath = ofd.FileName;

                                //cogDisplay1.InteractiveGraphics.Add( ( ICogGraphicInteractive ) CurrentTool.Pattern.TrainRegion
                                if (File.Exists(strFilePath))
                                {
                                    CogImageFile ImageFile1 = new CogImageFile();
                                    ImageFile1.Open(strFilePath, CogImageFileModeConstants.Read);
                                    if (ImageFile1.Count > 0)
                                    {
                                        ICogImage image = ImageFile1[0];
                                        CogImageConvertTool cogImageConverter = new CogImageConvertTool();
                                        cogImageConverter.InputImage = image;
                                        cogImageConverter.Run();
                                        m_imgSource_Color = new CogImage24PlanarColor((CogImage24PlanarColor)image);
                                        m_imgSource_Mono = (CogImage8Grey)cogImageConverter.OutputImage;

                                        cogDisplay_Source.Image = m_imgSource_Color;
                                        cogDisplay_Source.Fit(true);

                                        //SetROI(nWidth, nHeight);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case DEFINE.Image_Save:
                        // 세이브하는것을 묻기전에 이미지가 있는지 확인
                        if (!m_imgSource_Color.Allocated)
                        {
                            CUtil.ShowMessageBox("NO IMAGE", "Please proceed with Grab");
                            return;
                        }

                        //string strPath = "E:\\" + "_IMG\\" + "\\TestImage\\";
                        string strPath = Application.StartupPath + "\\" + "_IMG\\" + "\\Color\\";
                        string strPath2 = Application.StartupPath + "\\" + "_IMG\\" + "\\Mono\\";
                        string filePath = "";
                        int nCamIndex = cbCamera.SelectedIndex + 1;
                        if (!System.IO.Directory.Exists(strPath))
                        {
                            System.IO.Directory.CreateDirectory(strPath);
                        }

                        if (!System.IO.Directory.Exists(strPath2))
                        {
                            System.IO.Directory.CreateDirectory(strPath2);
                        }

                        if (CUtil.ShowMessageBox("SAVE", "Do you want to save it as that path?\nPath : " + strPath, FormMessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                        {
                            if (m_imgSource_Mono.Allocated)
                            {
                                filePath = strPath2 + DateTime.Now.ToString("yyyy_MM_dd_hhmmss_") + $"MonoIMG_Cam Num_{nCamIndex}" + ".bmp";
                                Common.SaveImageFileToBMP(m_imgSource_Mono, filePath);
                            }

                            // 칼라 이미지가 있을때만 저장
                            if (m_imgSource_Color.Allocated)
                            {
                                filePath = strPath + DateTime.Now.ToString("yyyy_MM_dd_HHmmss_") + $"ColorIMG_Cam Num_{nCamIndex}" + ".bmp";
                                Common.SaveImageFileToBMP(m_imgSource_Color, filePath);
                            }

                            CUtil.ShowMessageBox("SAVE", "The image has been saved.");
                        }
                        break;
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }



        private void SetROI(int nWidth, int nHeight)
        {
            int nRoiW = nWidth;
            int nRoiH = nHeight;
            int nStartX = (nWidth / 2);
            int nStartY = (nHeight / 2);

            cogROI.SetCenterWidthHeight(nStartX, nStartY, nRoiW, nRoiH);
            cogROI.GraphicDOFEnable = CogRectangleDOFConstants.Position | CogRectangleDOFConstants.Size;
            cogROI.Interactive = true;
        }

        //private void btnBlobRun_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int nAreaSize = int.Parse(tbAreaSize.Text);
        //        Stopwatch swTime = new Stopwatch();
        //        swTime.Start();

        //        DgvBlobResult.Rows.Clear();

        //        switch (cbCamera.SelectedIndex)
        //        {
        //            case 0:
        //                { RunBlob(CVisionTools.BLOB_CAM1, nAreaSize); }
        //                break;
        //            case 1:
        //                { RunBlob(CVisionTools.BLOB_CAM2, nAreaSize); }
        //                break;
        //        }

        //        swTime.Stop();

        //        lbTackTime.Text = swTime.ElapsedMilliseconds.ToString() + "ms";
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
        //        CUtil.ShowMessageBox("FAIL", ex.Message);
        //    }
        //}

        //private void RunBlob(CCogTool_Blob FindBlob, int nAreaSize)
        //{
        //    try
        //    {
        //        ClearCogLayerDisplay("Blob");
        //        CreateCogLayerDisplay(m_imgSource_Mono, "Blob");

        //        FindBlob.Tool.RunParams.ConnectivityMinPixels = nAreaSize;
        //        FindBlob.Run(m_imgSource_Mono, cogROI);

        //        FindBlob.Draw(Global.LayerDisplayList[Global.LayerDisplayList.Count - 1].cogDisplay_Source);
        //        Global.LayerDisplayList[Global.LayerDisplayList.Count - 1].Activate();

        //        for (int i = 0; i < FindBlob.Result.GetBlobs().Count; i++)
        //        {
        //            CogRectangleAffine rt = FindBlob.CogRectangleList[i];
        //            string strRect = string.Format("X:{0},Y:{1},Width:{2},Height:{3}", rt.CornerOriginX, rt.CornerOriginY, rt.SideXLength, rt.SideYLength);
        //            DgvBlobResult.Rows.Add(DgvBlobResult.Rows.Count, FindBlob.Areas[i], FindBlob.CenterXs[i], FindBlob.CenterYs[i], strRect);
        //            //DgvBlobResult.Rows.Add(DgvBlobResult.Rows.Count, FindBlob.Areas[i], FindBlob.CenterXs[i], FindBlob.CenterYs[i]);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
        //        CUtil.ShowMessageBox("FAIL", ex.Message);
        //    }
        //}

        private CogImage8Grey RunThreshold(CCogTool_Blob FindBlob, int nThreshold)
        {
            CogImage8Grey imageThreshold = new CogImage8Grey();
            try
            {
                FindBlob.Tool.InputImage = m_imgSource_Mono;
                FindBlob.Tool.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
                FindBlob.Tool.RunParams.SegmentationParams.HardFixedThreshold = nThreshold;
                //FindBlob.Tool.RunParams.ConnectivityMode = CogBlobConnectivityModeConstants.Labeled;                
                FindBlob.Run(m_imgSource_Mono, cogROI);

                imageThreshold = FindBlob.Result.CreateBlobImage(true, true, 255);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                CUtil.ShowMessageBox("FAIL", ex.Message);

                return imageThreshold;
            }

            return imageThreshold;
        }

        private void SetBlobRegion()
        {
            try
            {
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void SetPatternRegion()
        {
            try
            {
                // SearchRegion : 검사 영역
                // Pattern.TrainRegion : 패턴 영역

                if ((CogRectangleAffine)CVisionTools.PMALIGN_Pattern.Tool.SearchRegion == null)
                {
                    CogRectangleAffine cogRoiNew = new CogRectangleAffine();
                    cogRoiNew.FitToImage(m_imgSource_Mono, 1.0D, 1.0D);
                    cogRoiNew.GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
                    cogRoiNew.Interactive = true;
                    cogRoiNew.Color = CogColorConstants.Blue;
                    CVisionTools.PMALIGN_Pattern.Tool.SearchRegion = cogRoiNew;
                }

                if (cogPatternROI != null) { cogPatternROI = (CogRectangleAffine)CVisionTools.PMALIGN_Pattern.Tool.SearchRegion; }
                else
                {
                    cogPatternROI.CenterX = m_imgSource_Mono.Width / 2;
                    cogPatternROI.CenterY = m_imgSource_Mono.Height / 2;
                    cogPatternROI.SideXLength = m_imgSource_Mono.Width;
                    cogPatternROI.SideYLength = m_imgSource_Mono.Height;
                }
                cogPatternROI.Color = CogColorConstants.Green;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnBlobROI_Click(object sender, EventArgs e)
        {
            switch (VisionMode.ToString())
            {
                case DEFINE.Blob:
                    SetROI(cogDisplay_Source.Image.Width, cogDisplay_Source.Image.Height);
                    break;
                case DEFINE.Filter:
                    SetBlobRegion();
                    break;
                case DEFINE.Pattern:
                    SetPatternRegion();
                    break;
            }
        }

        private void mainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strIndex = "";
                if (sender is MetroTabControl) strIndex = (sender as MetroTabControl).SelectedTab.Text;

                switch (strIndex)
                {
                    case DEFINE.Blob:
                        VisionMode = VisionProcessMode.Blob;
                        break;
                    case DEFINE.Pattern:
                        VisionMode = VisionProcessMode.Pattern;
                        break;
                    case DEFINE.Filter:
                        VisionMode = VisionProcessMode.Filter;
                        break;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(CUtil.ShowMessageBox("SAVE", "Do you want to save the Vision Recipe?") == true)
                {
                    int nIndex = cbCamera.SelectedIndex;
                    SaveParameter();
                    CVisionTools.Save(nIndex + 1); //Tool

                    CUtil.ShowMessageBox("SAVE", "Completed the Save");
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                CUtil.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }

        private void SaveParameter()
        {
            try
            {
                FormMessageBox SaveForm = new FormMessageBox("Save", "Do You Want to Setting Save?");
                if (SaveForm.ShowDialog() == DialogResult.OK)
                {
                    int nIndex = cbCamera.SelectedIndex;

                    if (VisionMode == VisionProcessMode.Blob)
                    {
                        //int nAreaSize = int.Parse(tbAreaSize.Text);

                        switch (nIndex)
                        {
                            case 0:
                                //CVisionTools.BLOB_CAM1.MinArea = nAreaSize;
                                CVisionTools.BLOB_CAM1.Tool.Region = cogROI;
                                break;
                            case 1:
                                //CVisionTools.BLOB_CAM2.MinArea = nAreaSize;
                                CVisionTools.BLOB_CAM2.Tool.Region = cogROI;
                                break;
                        }
                    }

                    CVisionTools.BLOB_CAM1.SaveConfig(Global.System.Recipe.Name);
                    CVisionTools.BLOB_CAM2.SaveConfig(Global.System.Recipe.Name);

                    CVisionTools.PMALIGN_Pattern.SaveConfig(Global.System.Recipe.Name);
                    CVisionTools.PMALIGN_Pattern2.SaveConfig(Global.System.Recipe.Name);

                    CVisionTools.ColorMatch_CAM1.SaveConfig(Global.System.Recipe.Name);
                    CVisionTools.ColorMatch_CAM2.SaveConfig(Global.System.Recipe.Name);

                    CVisionTools.OCR_CAM1.SaveConfig(Global.System.Recipe.Name);
                    CVisionTools.OCR_CAM2.SaveConfig(Global.System.Recipe.Name);

                    CVisionTools.PMALIGN_CAM1.SaveConfig(IGlobal.Instance.System.Recipe.Name); //픽스쳐 패턴
                    CVisionTools.PMALIGN_CAM2.SaveConfig(IGlobal.Instance.System.Recipe.Name); 

                    CVisionTools.FIXTURE_CAM1.SaveConfig(IGlobal.Instance.System.Recipe.Name); //픽스쳐
                    CVisionTools.FIXTURE_CAM2.SaveConfig(IGlobal.Instance.System.Recipe.Name);

                    CVisionTools.ID_CAM1.SaveConfig(IGlobal.Instance.System.Recipe.Name);
                    CVisionTools.ID_CAM2.SaveConfig(IGlobal.Instance.System.Recipe.Name);

                    //CVisionTools.Save_ModelCode(IGlobal.Instance.System.Recipe.Name);
                    CVisionTools.Save_ModelCode(IGlobal.Instance.System.Recipe.Name, IGlobal.Instance.System.Recipe.SubName, IGlobal.Instance.System.Recipe.ModelCode);

                    CVisionTools.Equalize.SaveConfig(IGlobal.Instance.System.Recipe.Name);
                    CVisionTools.Quantize.SaveConfig(IGlobal.Instance.System.Recipe.Name);
                    CVisionTools.Equalize.SaveConfigXML(IGlobal.Instance.System.Recipe.Name);
                    CVisionTools.Quantize.SaveConfigXML(IGlobal.Instance.System.Recipe.Name);

                    //모델 코드 비교 저장을 위해
                    if (tbModelCode.Text != null && tbModelCode.Text != "")
                    {
                        CVisionTools.ID_CAM1.ModelCode = tbModelCode.Text;
                        CVisionTools.ID_CAM2.ModelCode = tbModelCode.Text;
                    }

                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        //private void btnMorphology_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Stopwatch swTime = new Stopwatch();
        //        swTime.Start();

        //        int nW = int.Parse(tbWidth.Text);
        //        int nH = int.Parse(tbHeight.Text);

        //        if (nW % 2 == 0 || nH % 2 == 0) { CUtil.ShowMessageBox("FAIL", "짝수값을 입력할 수 없습니다."); return; }

        //        ClearCogLayerDisplay(cbMorphology.SelectedItem.ToString());

        //        Task<ICogImage> Image = CVisionTools.MorphologyNxM.Run(m_imgSource_Mono, cogROI, nW, nH, (CogIPOneImageMorphologyOperationConstants)cbMorphology.SelectedItem);

        //        CreateCogLayerDisplay((CogImage8Grey)Image.Result, cbMorphology.SelectedItem.ToString());

        //        Global.LayerDisplayList[Global.LayerDisplayList.Count - 1].Activate();

        //        //cogDisplay_Result.Image = Image.Result;

        //        swTime.Stop();

        //        lbTackTime.Text = swTime.ElapsedMilliseconds.ToString() + "ms";

        //        GC.Collect();
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
        //    }
        //}

        private void btnCameraParameterApply_Click(object sender, EventArgs e)
        {
            try
            {
                Global.Device.Cameras[cbCamera.SelectedIndex].SetExposure((int)nbCamExposure.Value);
                Global.Device.Cameras[cbCamera.SelectedIndex].SetGain((int)nbCamGain.Value);

                if (cbCamera.SelectedIndex == 0)
                {
                    Global.Parameter.Cam1_ImageProcess.FlipRotate = cbCamFlipRotate.Text;
                }
                else
                {
                    Global.Parameter.Cam2_ImageProcess.FlipRotate = cbCamFlipRotate.Text;
                }

                Global.Parameter.Save(Global.System.Recipe.Name);

                

                
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        //private void btnSubtract_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string[] strImages = CUtil.LoadImages();

        //        if (strImages == null) { return; }

        //        string strPath1 = strImages[0];
        //        string strPath2 = strImages[1];
        //        lbSource1.Text = strPath1;
        //        lbSource2.Text = strPath2;

        //        CogImageFile ImageFile1 = new CogImageFile();
        //        ImageFile1.Open(strPath1, CogImageFileModeConstants.Read);
        //        if (ImageFile1.Count > 0)
        //        {
        //            ICogImage image = ImageFile1[0];
        //            CogImageConvertTool cogImageConverter = new CogImageConvertTool();
        //            cogImageConverter.InputImage = image;
        //            cogImageConverter.Run();
        //            m_imgSource_Mono = (CogImage8Grey)cogImageConverter.OutputImage;

        //            //cogDisplay_Source.Image = m_ImageSource;
        //        }

        //        CogImageFile ImageFile2 = new CogImageFile();
        //        ImageFile2.Open(strPath2, CogImageFileModeConstants.Read);
        //        if (ImageFile2.Count > 0)
        //        {
        //            ICogImage image = ImageFile2[0];
        //            CogImageConvertTool cogImageConverter = new CogImageConvertTool();
        //            cogImageConverter.InputImage = image;
        //            cogImageConverter.Run();
        //            m_ImageSource2 = (CogImage8Grey)cogImageConverter.OutputImage;
        //            //cogDisplay_Result.Image = m_ImageSource2;
        //        }
        //        CogIPTwoImageSubtractOverflowModeConstants Operator = CogIPTwoImageSubtractOverflowModeConstants.Absolute;

        //        ClearCogLayerDisplay(Operator.ToString());

        //        Task<ICogImage> Image = CVisionTools.Subtract.Run(m_ImageSource2, m_imgSource_Mono, cogROI, cogROI, Operator);

        //        CreateCogLayerDisplay((CogImage8Grey)Image.Result, Operator.ToString());

        //        Global.LayerDisplayList[Global.LayerDisplayList.Count - 1].Activate();
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
        //    }
        //}

        //public void Test()
        //{
        //    try
        //    {
        //        string[] strImages = CUtil.LoadImages();

        //        if (strImages == null) { return; }

        //        string strPath1 = strImages[0];
        //        string strPath2 = strImages[1];
        //        lbSource1.Text = strPath1;
        //        lbSource2.Text = strPath2;

        //        CogImageFile ImageFile1 = new CogImageFile();
        //        ImageFile1.Open(strPath1, CogImageFileModeConstants.Read);
        //        if (ImageFile1.Count > 0)
        //        {
        //            ICogImage image = ImageFile1[0];
        //            CogImageConvertTool cogImageConverter = new CogImageConvertTool();
        //            cogImageConverter.InputImage = image;
        //            cogImageConverter.Run();
        //            m_imgSource_Mono = (CogImage8Grey)cogImageConverter.OutputImage;

        //            //cogDisplay_Source.Image = m_ImageSource;
        //        }

        //        CogImageFile ImageFile2 = new CogImageFile();
        //        ImageFile2.Open(strPath2, CogImageFileModeConstants.Read);
        //        if (ImageFile2.Count > 0)
        //        {
        //            ICogImage image = ImageFile2[0];
        //            CogImageConvertTool cogImageConverter = new CogImageConvertTool();
        //            cogImageConverter.InputImage = image;
        //            cogImageConverter.Run();
        //            m_ImageSource2 = (CogImage8Grey)cogImageConverter.OutputImage;
        //            //cogDisplay_Result.Image = m_ImageSource2;
        //        }
        //        ClearCogLayerDisplay("Subtract");

        //        Task<ICogImage> Image = CVisionTools.Subtract.Run(m_ImageSource2, m_imgSource_Mono, cogROI, cogROI, CogIPTwoImageSubtractOverflowModeConstants.Absolute);

        //        int nAreaSize = int.Parse(tbAreaSize.Text);

        //        Task<ICogImage> MorphologyImage = CVisionTools.MorphologyNxM.Run((CogImage8Grey)Image.Result, cogROI, 3, 3, CogIPOneImageMorphologyOperationConstants.Erode);

        //        ClearCogLayerDisplay("Blob");
        //        CreateCogLayerDisplay((CogImage8Grey)MorphologyImage.Result, "Blob");

        //        CVisionTools.BLOB_CAM1.Tool.RunParams.ConnectivityMinPixels = nAreaSize;
        //        CVisionTools.BLOB_CAM1.Run((CogImage8Grey)MorphologyImage.Result, cogROI);

        //        //CVisionTools.FindBlob_Camera1.Draw(Global.LayerDisplayList[Global.LayerDisplayList.Count - 1].cogDisplay_Source);
        //        Global.LayerDisplayList[Global.LayerDisplayList.Count - 1].Activate();

        //        for (int i = 0; i < CVisionTools.BLOB_CAM1.Result.GetBlobs().Count; i++)
        //        {
        //            CogRectangleAffine rt = CVisionTools.BLOB_CAM1.CogRectangleList[i];
        //            string strRect = string.Format("X:{0},Y:{1},Width:{2},Height:{3}", rt.CornerOriginX, rt.CornerOriginY, rt.SideXLength, rt.SideYLength);
        //            DgvBlobResult.Rows.Add(DgvBlobResult.Rows.Count, CVisionTools.BLOB_CAM1.Areas[i], CVisionTools.BLOB_CAM1.CenterXs[i], CVisionTools.BLOB_CAM1.CenterYs[i], strRect);
        //            //DgvBlobResult.Rows.Add(DgvBlobResult.Rows.Count, FindBlob.Areas[i], FindBlob.CenterXs[i], FindBlob.CenterYs[i]);
        //        }


        //        Global.LayerDisplayList[Global.LayerDisplayList.Count - 1].Activate();
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
        //    }
        //}

        private void btnPMAlignToolAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string str_Name = tbJobName.Text;
                int nThreshold = trbThreshold.Value;
                double dScoreMin = double.Parse(tbJobScoreMin.Text);
                int nMasterCount = 1;
                double dAngle = double.Parse(tbReverseMaxAngle.Text);

                bool bNotOption = chk_jobsNotOption.Checked;
                bool bEqualizeUse = chk_jobsEqualizeUse.Checked;
                bool bQuantizeUse = chk_jobsQuantizeUSE.Checked;
                int nQuantizeLevel = cbojobQuantizeLevel.SelectedIndex;
                bool bInspectionUse = cbJobUse.Checked;
                bool bMaskingUse = chk_jobMaskUse.Checked;

                cogDisplay_Pattern.StaticGraphics.Clear();


                if (cbCamera.SelectedIndex == 0)
                {
                    JOB_TEMP job = new JOB_TEMP($"JOB_{CVisionTools.Jobs.Count.ToString()}");
                    job.NAME = str_Name;
                    job.INSP_TYPE = cbInspType.Text;
                    job.MASTER_COUNT = nMasterCount;
                    job.ANGLE = dAngle;

                    job.NotOption = bNotOption;
                    job.EqualizeUse = bEqualizeUse;
                    job.QuantizeUse = bQuantizeUse;
                    job.QuantizeLevel = nQuantizeLevel;
                    job.InspectionUse = bInspectionUse;
                    job.MaskingUse = bMaskingUse;

                    job.Matching.Tool.RunParams.ScoreUsingClutter = false;
                    job.Matching.Tool.RunParams.AcceptThreshold = double.Parse(tbJobScoreMin.Text);
                    job.Matching.Tool.RunParams.ApproximateNumberToFind = 1;
                    job.Matching.Tool.RunParams.XYOverlap = 0.1;

                    // 동일한 이름이 있는지 확인
                    for (int i = 0; i < CVisionTools.Jobs.Count; i++)
                    {
                        if (string.Equals(CVisionTools.Jobs[i].NAME, job.NAME, StringComparison.OrdinalIgnoreCase))
                        {
                            CUtil.ShowMessageBox("NOTICE", "JOB NAME ALREADY EXISTS");
                            return;
                        }
                    }

                    CVisionTools.Jobs.Add(job);

                    m_SelectedJob = job;

                    propertyGrid_Param.SelectedObject = m_SelectedJob.Matching.Tool.RunParams;

                    //UpdateJob();
                    UpdateJob(cbCamera.SelectedIndex);

                    //제일 마지막 행을 선택되도록 함
                    gridJobs.Rows[CVisionTools.Jobs.Count - 1].Selected = true;
                    gridJobs.Rows[CVisionTools.Jobs.Count - 1].Cells[0].Selected = true;
                }
                else
                {
                    JOB_TEMP job = new JOB_TEMP($"JOB_{CVisionTools.Jobs2.Count.ToString()}");
                    job.NAME = str_Name;
                    job.INSP_TYPE = cbInspType.Text;
                    job.MASTER_COUNT = nMasterCount;
                    job.ANGLE = dAngle;

                    job.NotOption = bNotOption;
                    job.EqualizeUse = bEqualizeUse;
                    job.QuantizeUse = bQuantizeUse;
                    job.QuantizeLevel = nQuantizeLevel;
                    job.InspectionUse = bInspectionUse;
                    job.MaskingUse = bMaskingUse;

                    job.Matching.Tool.RunParams.AcceptThreshold = double.Parse(tbJobScoreMin.Text);
                    job.Matching.Tool.RunParams.ApproximateNumberToFind = 100;
                    job.Matching.Tool.RunParams.XYOverlap = 0.1;

                    // 동일한 이름이 있는지 확인
                    for (int i = 0; i < CVisionTools.Jobs2.Count; i++)
                    {
                        if (string.Equals(CVisionTools.Jobs2[i].NAME, job.NAME, StringComparison.OrdinalIgnoreCase))
                        {
                            CUtil.ShowMessageBox("NOTICE", "JOB NAME ALREADY EXISTS");
                            return;
                        }
                    }

                    CVisionTools.Jobs2.Add(job);

                    m_SelectedJob = job;

                    propertyGrid_Param.SelectedObject = m_SelectedJob.Matching.Tool.RunParams;

                    //UpdateJob();
                    UpdateJob(cbCamera.SelectedIndex);

                    //제일 마지막 행을 선택되도록 함
                    gridJobs.Rows[CVisionTools.Jobs2.Count - 1].Selected = true;
                    gridJobs.Rows[CVisionTools.Jobs2.Count - 1].Cells[0].Selected = true;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnSetPatternRegion_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_SelectedJob == null)
                {
                    CUtil.ShowMessageBox("Alram", "Select JOB");
                    return;
                }

                //int nindex = cbCamera.SelectedIndex;

                //CVisionTools.Run_Fixture(nindex, m_imgSource_Color, m_imgSource_Mono, out CogImage24PlanarColor imgOutput_Color, out CogImage8Grey imgOutput_Mono);

                //if (cbCamera.SelectedIndex == 0)
                //{
                //    cogDisplay_Source.Image = m_imgSource_Mono;
                //}
                //else
                //{
                //    cogDisplay_Source.Image = m_imgSource_Mono;
                //}



                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();



                if (m_SelectedJob.Matching.Tool.Pattern.TrainRegion == null) m_SelectedJob.Matching.Tool.Pattern.TrainRegion = new CogRectangle();


                CogRectangleAffine cogTrainRegion = (CogRectangleAffine)m_SelectedJob.Matching.Tool.Pattern.TrainRegion;
                if (cogTrainRegion.CenterX == 0 || cogTrainRegion.CenterY == 0)
                {
                    if (cogTrainRegion.SideXLength <= 100) cogTrainRegion.SideXLength = 250;
                    if (cogTrainRegion.SideYLength <= 100) cogTrainRegion.SideYLength = 250;
                }

                cogDisplay_Source.InteractiveGraphics.Add((ICogGraphicInteractive)cogTrainRegion, "Pattern", false);

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnPatternTrainAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_SelectedJob == null)
                {
                    CUtil.ShowMessageBox("Alram", "SELECT JOB.");
                    return;
                }

                if (m_SelectedJob.EqualizeUse)
                {
                    ICogImage image = null;
                    image = CVisionTools.Equalize.Run(m_imgSource_Mono, m_SelectedJob.Matching.Tool.Pattern.TrainRegion as CogRectangle);
                    m_imgSource_Equalize = image as CogImage8Grey;
                    m_SelectedJob.Matching.Tool.Pattern.TrainImage = m_imgSource_Equalize;
                }
                else if (m_SelectedJob.QuantizeUse)
                {
                    ICogImage image = null;
                    image = CVisionTools.Quantize.Run(m_imgSource_Mono, m_SelectedJob.Matching.Tool.Pattern.TrainRegion as CogRectangle, m_SelectedJob.QuantizeLevel);
                    m_imgSource_Quantize = image as CogImage8Grey;
                    m_SelectedJob.Matching.Tool.Pattern.TrainImage = m_imgSource_Quantize;
                }
                else
                {
                    m_SelectedJob.Matching.Tool.Pattern.TrainImage = m_imgSource_Mono;
                }

                if (m_SelectedJob.MaskingUse)
                {
                    m_SelectedJob.Matching.Tool.Pattern.TrainImageMask = IGlobal.Instance.m_FileManager.MaskingImageLoad(cbCamera.SelectedIndex + 1, IGlobal.Instance.System.Recipe.Name, m_SelectedJob.NAME, null);
                }
                else
                {
                    m_SelectedJob.Matching.Tool.Pattern.TrainImageMask = null;
                }

                m_SelectedJob.Matching.Tool.Pattern.TrainAlgorithm = CogPMAlignTrainAlgorithmConstants.PatQuick;

                if(m_SelectedJob.Matching.Tool.Pattern.TrainRegion is CogCircle)
                {
                    m_SelectedJob.Matching.Tool.Pattern.Origin.TranslationX = (m_SelectedJob.Matching.Tool.Pattern.TrainRegion as CogCircle).CenterX;
                    m_SelectedJob.Matching.Tool.Pattern.Origin.TranslationY = (m_SelectedJob.Matching.Tool.Pattern.TrainRegion as CogCircle).CenterY;

                }

                if (m_SelectedJob.Matching.Tool.Pattern.TrainRegion is CogRectangleAffine)
                {
                    m_SelectedJob.Matching.Tool.Pattern.Origin.TranslationX = (m_SelectedJob.Matching.Tool.Pattern.TrainRegion as CogRectangleAffine).CenterX;
                    m_SelectedJob.Matching.Tool.Pattern.Origin.TranslationY = (m_SelectedJob.Matching.Tool.Pattern.TrainRegion as CogRectangleAffine).CenterY;

                }

                m_SelectedJob.Matching.Tool.Pattern.Train();

                cogDisplay_Pattern.Image = m_SelectedJob.Matching.Tool.Pattern.GetTrainedPatternImage();
                cogDisplay_Pattern.StaticGraphics.AddList(TrainGraphic(cogDisplay_Pattern), "");
                cogDisplay_Pattern.Fit(true);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        //패턴 트레인 그래픽
        public CogGraphicCollection TrainGraphic(CogDisplay cogTrainDisplay)
        {
            CogCopyRegionTool CopyRegion = new CogCopyRegionTool();

            CopyRegion.InputImage = m_SelectedJob.Matching.Tool.Pattern.TrainImage;
            CopyRegion.Region = m_SelectedJob.Matching.Tool.Pattern.TrainRegion;

            CopyRegion.Run();

            cogTrainDisplay.Image = CopyRegion.OutputImage;

            cogTrainDisplay.StaticGraphics.Clear();

            return m_SelectedJob.Matching.Tool.Pattern.CreateGraphicsCoarse(CogColorConstants.Yellow);
        }

        public CogGraphicCollection TrainGraphic(CogDisplay cogTrainDisplay, CogPMAlignTool cogPMAlignTool)
        {
            CogCopyRegionTool CopyRegion = new CogCopyRegionTool();

            CopyRegion.InputImage = cogPMAlignTool.Pattern.TrainImage;
            CopyRegion.Region = cogPMAlignTool.Pattern.TrainRegion;

            CopyRegion.Run();

            cogTrainDisplay.Image = CopyRegion.OutputImage;

            cogTrainDisplay.StaticGraphics.Clear();

            return cogPMAlignTool.Pattern.CreateGraphicsCoarse(CogColorConstants.Yellow);
        }

        public CogGraphicCollection TrainGraphic(CogDisplay cogTrainDisplay, CogPMAlignMultiTool cogPMAlignMultiTool, int index)
        {
            CogCopyRegionTool CopyRegion = new CogCopyRegionTool();

            CopyRegion.InputImage = cogPMAlignMultiTool.Operator[index].Pattern.TrainImage;
            CopyRegion.Region = cogPMAlignMultiTool.Operator[index].Pattern.TrainRegion;

            CopyRegion.Run();

            cogTrainDisplay.Image = CopyRegion.OutputImage;

            cogTrainDisplay.StaticGraphics.Clear();

            return cogPMAlignMultiTool.Operator[index].Pattern.CreateGraphicsCoarse(CogColorConstants.Yellow);
        }

        public CogGraphicCollection TrainGraphic(CogDisplay cogTrainDisplay, CCogTool_PMAlign tool, ICogRegion region)
        {
            CogCopyRegionTool CopyRegion = new CogCopyRegionTool();

            CopyRegion.InputImage = tool.Tool.Pattern.TrainImage;
            CopyRegion.Region = region;

            CopyRegion.Run();

            cogTrainDisplay.Image = CopyRegion.OutputImage;

            cogTrainDisplay.StaticGraphics.Clear();

            return tool.Tool.Pattern.CreateGraphicsCoarse(CogColorConstants.Yellow);
        }

        private void btnPatternTrainDel_Click(object sender, EventArgs e)
        {
            try
            {
                //int nIndex = cbTools.SelectedIndex;

                //if(PMAlignTools.Count > 1)
                //{
                //    PMAlignTools.RemoveAt(nIndex);
                //    cbTools.Items.RemoveAt(nIndex);

                //    cbTools.SelectedIndex = 0;
                //}
                //else
                //{
                //    CUtil.ShowMessageBox("ALARM", "검사 툴은 최소 1개가 유지되어야 합니다.");
                //}
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private CogImage8Grey CAM1_Fixturing_Run()
        {
            CVisionTools.PMALIGN_CAM1.Run(m_imgSource_Mono);

            if (CVisionTools.PMALIGN_CAM1.Results.Count > 0)
            {
                CVisionTools.FIXTURE_CAM1.Run(m_imgSource_Mono, CVisionTools.PMALIGN_CAM1.Results[0].GetPose(), out CogImage8Grey outputimg);

                return outputimg;
            }
            else
            {
                CUtil.ShowMessageBox("FAIL", "CAM1 PATTERN MACHING FAIL.");
                return null;
            }
        }

        private CogImage8Grey CAM2_Fixturing_Run()
        {
            CVisionTools.PMALIGN_CAM2.Run(m_imgSource_Mono);

            if (CVisionTools.PMALIGN_CAM2.Results.Count > 0)
            {
                CVisionTools.FIXTURE_CAM2.Run(m_imgSource_Mono, CVisionTools.PMALIGN_CAM2.Results[0].GetPose(), out CogImage8Grey outputimg);

                return outputimg;
            }
            else
            {
                CUtil.ShowMessageBox("FAIL", "CAM2 PATTERN MACHING FAIL.");
                return null;
            }
        }

        private void btnPatternRunSelected_Click(object sender, EventArgs e)
        {
            try
            {
                Stopwatch sw_TactTime = new Stopwatch();
                sw_TactTime.Start();

                if (m_SelectedJob == null) return;
                CogPMAlignTool PMAlignTool = m_SelectedJob.Matching.Tool;

                if (m_SelectedJob.EqualizeUse)
                {
                    ICogImage image = null;
                    image = CVisionTools.Equalize.Run(m_imgSource_Mono, m_SelectedJob.Matching.Tool.Pattern.TrainRegion as CogRectangle);
                    m_imgSource_Equalize = image as CogImage8Grey;
                    PMAlignTool.InputImage = m_imgSource_Equalize;
                }
                else if (m_SelectedJob.QuantizeUse)
                {
                    ICogImage image = null;
                    image = CVisionTools.Quantize.Run(m_imgSource_Mono, m_SelectedJob.Matching.Tool.Pattern.TrainRegion as CogRectangle, m_SelectedJob.QuantizeLevel);
                    m_imgSource_Quantize = image as CogImage8Grey;
                    PMAlignTool.InputImage = m_imgSource_Quantize;
                }
                else
                {
                    PMAlignTool.InputImage = m_imgSource_Mono;
                }


                PMAlignTool.Run();

                if (PMAlignTool.Results != null)
                {
                    cogDisplay_Source.InteractiveGraphics.Clear();
                    cogDisplay_Source.StaticGraphics.Clear();

                    if (PMAlignTool.SearchRegion != null) cogDisplay_Source.StaticGraphics.Add((ICogGraphicInteractive)PMAlignTool.SearchRegion, "ROI");

                    for (int i = 0; i < PMAlignTool.Results.Count; i++)
                    {
                        CogRectangle Draw = new CogRectangle();
                        CogCompositeShape resultDrawing = PMAlignTool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.BoundingBox);

                        CogGraphicLabel label = new CogGraphicLabel();
                        CogGraphicLabel labelResult = new CogGraphicLabel();
                        //Set X-position to 100
                        label.X = PMAlignTool.Results[i].GetPose().TranslationX;
                        label.Y = PMAlignTool.Results[i].GetPose().TranslationY;
                        labelResult.X = PMAlignTool.Results[i].GetPose().TranslationX;
                        labelResult.Y = PMAlignTool.Results[i].GetPose().TranslationY+30;
                        labelResult.Color = CogColorConstants.Green;
                        labelResult.Font = new Font("arial", 12, FontStyle.Bold);
                        cogDisplay_Source.InteractiveGraphics.Add(PMAlignTool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin), "main", false);
                        cogDisplay_Source.InteractiveGraphics.Add(PMAlignTool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.TipText), "main", false);

                        double dRotation = PMAlignTool.Results[i].GetPose().Rotation * 180 / Math.PI;

                        labelResult.Text = $"Score : {PMAlignTool.Results[i].Score.ToString("F2")}% Angle : {dRotation.ToString("F1")}";
                        cogDisplay_Source.InteractiveGraphics.Add(labelResult, "main", false);

                        lbDetectedScore.Text = $"Detected Score : {PMAlignTool.Results[i].Score.ToString("F2")}";

                        if (Math.Abs(dRotation) > m_SelectedJob.ANGLE)
                        {
                            label.Color = CogColorConstants.Red;

                            label.Text = "REVERSE";
                            label.Font = new Font("arial", 24);

                            resultDrawing.Color = CogColorConstants.Red;

                            cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                        }
                        else
                        {
                            if (m_SelectedJob.NotOption)
                            {
                                label.Color = CogColorConstants.Red;

                                label.Text = "Not Option NG";
                                label.Font = new Font("arial", 24);

                                resultDrawing.Color = CogColorConstants.Red;

                                cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                            }
                            else
                            {
                                resultDrawing.Color = CogColorConstants.Green;
                            }

                        }

                        //cogDisplay_Source.Image = imgOutput_Color;

                        cogDisplay_Source.StaticGraphics.Add((ICogGraphic)resultDrawing, "main");

                        //cogDisplay_Source.InteractiveGraphics.Add(PMAlignTool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.TipText), "main", false);
                    }
                }
                // 미삽일때 라벨위치 지정 ROI Center로
                if (PMAlignTool.Results == null || PMAlignTool.Results.Count == 0)
                {
                    CogGraphicLabel label = new CogGraphicLabel();
                    CogRectangle rt = new CogRectangle();




                    //ICogRegion rt = PMAlignTool.SearchRegion;
                    rt = PMAlignTool.SearchRegion as CogRectangle;

                    //label.X = rt.
                    //.Y = PMAlignTool.Results[i].GetPose().TranslationY;
                    if (m_SelectedJob.NotOption)
                    {
                        label.Color = CogColorConstants.Green;
                        label.Text = "Not Option OK";
                        label.Font = new Font("arial", 24);
                        label.X = rt.CenterX;
                        label.Y = rt.CenterY;
                    }
                    else
                    {
                        label.Color = CogColorConstants.Red;
                        label.Text = "N/A";
                        label.Font = new Font("arial", 24);
                        label.X = rt.CenterX;
                        label.Y = rt.CenterY;
                    }


                    cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                }

                sw_TactTime.Stop();
                lbTackTime.Text = sw_TactTime.ElapsedMilliseconds.ToString() + "ms";

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnPatternRunAll_Click(object sender, EventArgs e)
        {
            try
            {
                Stopwatch sw_TactTime = new Stopwatch();
                sw_TactTime.Start();

                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();

                //int nindex = cbCamera.SelectedIndex;

                //CVisionTools.Run_Fixture(nindex, m_imgSource_Color, m_imgSource_Mono, out CogImage24PlanarColor imgOutput_Color, out CogImage8Grey imgOutput_Mono);

                //if (cbCamera.SelectedIndex == 0)
                //{
                //    cogDisplay_Source.Image = imgOutput_Mono;
                //    PMAlignTool.InputImage = imgOutput_Mono;
                //}
                //else
                //{
                //    cogDisplay_Source.Image = imgOutput_Mono;
                //    PMAlignTool.InputImage = imgOutput_Mono;
                //}

                CogGraphicCollection cogGraphic = new CogGraphicCollection();

                ICogImage tmpimage = null;

                if (cbCamera.SelectedIndex == 0)
                {
                    CVisionTools.tmpJobs = CVisionTools.Jobs;
                }
                else
                {
                    CVisionTools.tmpJobs = CVisionTools.Jobs2;
                }


                for (int i = 0; i < CVisionTools.tmpJobs.Count; i++)
                {
                    if (CVisionTools.tmpJobs[i].InspectionUse)
                    {
                        CogPMAlignTool PMAlignTool = CVisionTools.tmpJobs[i].Matching.Tool;

                        if (CVisionTools.tmpJobs[i].EqualizeUse)
                        {
                            tmpimage = CVisionTools.Equalize.Run(m_imgSource_Mono, CVisionTools.tmpJobs[i].Matching.Tool.Pattern.TrainRegion as CogRectangle);
                            m_imgSource_Equalize = tmpimage as CogImage8Grey;
                            PMAlignTool.InputImage = m_imgSource_Equalize;
                        }
                        else if (CVisionTools.tmpJobs[i].QuantizeUse)
                        {
                            tmpimage = CVisionTools.Quantize.Run(m_imgSource_Mono, CVisionTools.tmpJobs[i].Matching.Tool.Pattern.TrainRegion as CogRectangle, CVisionTools.tmpJobs[i].QuantizeLevel);
                            m_imgSource_Equalize = tmpimage as CogImage8Grey;
                            PMAlignTool.InputImage = m_imgSource_Equalize;
                        }
                        else
                        {
                            PMAlignTool.InputImage = m_imgSource_Mono;
                        }


                        PMAlignTool.Run();

                        if (PMAlignTool.Results != null)
                        {
                            if (PMAlignTool.SearchRegion != null) cogGraphic.Add((ICogGraphic)PMAlignTool.SearchRegion);

                            int nCount = PMAlignTool.Results.Count;
                            if (nCount > 0)
                            {
                                for (int j = 0; j < PMAlignTool.Results.Count; j++)
                                {
                                    CogRectangle Draw = new CogRectangle();
                                    CogCompositeShape resultDrawing = PMAlignTool.Results[j].CreateResultGraphics(CogPMAlignResultGraphicConstants.BoundingBox);

                                    CogGraphicLabel label = new CogGraphicLabel();
                                    CogGraphicLabel labelResult = new CogGraphicLabel();
                                    
                                    labelResult.X = PMAlignTool.Results[j].GetPose().TranslationX;
                                    labelResult.Y = PMAlignTool.Results[j].GetPose().TranslationY + 30;
                                    labelResult.Color = CogColorConstants.Green;
                                    labelResult.Font = new Font("arial", 12, FontStyle.Bold);
                                    cogDisplay_Source.InteractiveGraphics.Add(PMAlignTool.Results[j].CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin), "main", false);
                                    cogDisplay_Source.InteractiveGraphics.Add(PMAlignTool.Results[j].CreateResultGraphics(CogPMAlignResultGraphicConstants.TipText), "main", false);
                                    //Set X-position to 100
                                    label.X = PMAlignTool.Results[j].GetPose().TranslationX;
                                    label.Y = PMAlignTool.Results[j].GetPose().TranslationY;

                                    cogGraphic.Add((ICogGraphic)PMAlignTool.Results[j].CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin));

                                    double dRotation = PMAlignTool.Results[j].GetPose().Rotation * 180 / Math.PI;
                                    labelResult.Text = $"Score : {PMAlignTool.Results[j].Score.ToString("F2")}% Angle : {dRotation.ToString("F1")}";

                                    if (Math.Abs(dRotation) > CVisionTools.tmpJobs[i].ANGLE)
                                    {
                                        label.Color = CogColorConstants.Red;

                                        label.Text = "REVERSE";
                                        label.Font = new Font("arial", 24);

                                        resultDrawing.Color = CogColorConstants.Red;

                                        cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                                        
                                    }
                                    else
                                    {
                                        if (CVisionTools.tmpJobs[i].NotOption)
                                        {
                                            label.Color = CogColorConstants.Red;

                                            label.Text = "Not Option NG";
                                            label.Font = new Font("arial", 24);

                                            resultDrawing.Color = CogColorConstants.Red;

                                            cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                                        }
                                        else
                                        {
                                            resultDrawing.Color = CogColorConstants.Green;
                                        }

                                    }



                                    cogGraphic.Add((ICogGraphic)resultDrawing);

                                    //if (cbCamera.SelectedIndex == 0)
                                    //{
                                    //    CogCompositeShape FixtureResult = CVisionTools.PMALIGN_CAM1.Tool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.All);

                                    //    cogDisplay_Source.InteractiveGraphics.Add(CVisionTools.PMALIGN_CAM1.Tool.Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin), "main", false);
                                    //    cogDisplay_Source.StaticGraphics.Add(FixtureResult, "main");
                                    //}
                                    //else
                                    //{
                                    //    CogCompositeShape FixtureResult = CVisionTools.PMALIGN_CAM2.Tool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.All);

                                    //    cogDisplay_Source.InteractiveGraphics.Add(CVisionTools.PMALIGN_CAM2.Tool.Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin), "main", false);
                                    //    cogDisplay_Source.StaticGraphics.Add(FixtureResult, "main");
                                    //}

                                }
                            }
                            else
                            {
                                CogGraphicLabel label = new CogGraphicLabel();
                                CogRectangle rt = new CogRectangle();
                                rt = PMAlignTool.SearchRegion as CogRectangle;

                                label.X = rt.CenterX;
                                label.Y = rt.CenterY;

                                if (CVisionTools.tmpJobs[i].NotOption)
                                {

                                    label.Color = CogColorConstants.Green;
                                    label.Text = "Not Option OK";
                                    label.Font = new Font("arial", 24);
                                    cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                                }
                                else
                                {

                                    label.Color = CogColorConstants.Red;
                                    label.Text = "N/A";
                                    label.Font = new Font("arial", 24);
                                    cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                                }

                            }

                        }
                        else //패턴 result null
                        {
                            CogGraphicLabel label = new CogGraphicLabel();
                            CogRectangle rt = new CogRectangle();
                            rt = PMAlignTool.SearchRegion as CogRectangle;

                            label.X = rt.CenterX;
                            label.Y = rt.CenterY;



                            label.Color = CogColorConstants.Red;
                            label.Text = "N/A";
                            label.Font = new Font("arial", 24);
                            cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");

                        }
                    }
                    else
                    {
                        //검사 미사용
                    }


                }

                //cogDisplay_Source.Image = imgOutput_Color;

                cogDisplay_Source.StaticGraphics.AddList(cogGraphic, "RESULTS");



                sw_TactTime.Stop();
                lbTackTime.Text = sw_TactTime.ElapsedMilliseconds.ToString() + "ms";

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnMasterCalibration_Click(object sender, EventArgs e)
        {
            try
            {
                Stopwatch sw_TactTime = new Stopwatch();
                sw_TactTime.Start();

                CogPMAlignTool PMAlignTool = m_SelectedJob.Matching.Tool;
                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();

                //int nindex = cbCamera.SelectedIndex;

                //CVisionTools.Run_Fixture(nindex, m_imgSource_Color, m_imgSource_Mono, out CogImage24PlanarColor imgOutput_Color, out CogImage8Grey imgOutput_Mono);

                //if (cbCamera.SelectedIndex == 0)
                //{
                //    cogDisplay_Source.Image = imgOutput_Mono;
                //    PMAlignTool.InputImage = imgOutput_Mono;
                //}
                //else
                //{
                //    cogDisplay_Source.Image = imgOutput_Mono;
                //    PMAlignTool.InputImage = imgOutput_Mono;
                //}

                CogRectangle ROI = new CogRectangle();
                ROI.X = 0;
                ROI.Y = 0;
                ROI.Width = cogDisplay_Source.Image.Width;
                ROI.Height = cogDisplay_Source.Image.Height;

                if (cbCamera.SelectedIndex == 0)
                {
                    CVisionTools.tmpJobs = CVisionTools.Jobs;
                }
                else
                {
                    CVisionTools.tmpJobs = CVisionTools.Jobs2;
                }

                for (int i = 0; i < CVisionTools.tmpJobs.Count; i++)
                {
                    CVisionTools.tmpJobs[i].Matching.Tool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
                    CVisionTools.tmpJobs[i].Matching.Tool.RunParams.ZoneAngle.Low = -359;
                    CVisionTools.tmpJobs[i].Matching.Tool.RunParams.ZoneAngle.High = 359;

                    if (CVisionTools.tmpJobs[i].EqualizeUse)
                    {
                        CVisionTools.tmpJobs[i].Matching.Tool.InputImage = CVisionTools.Equalize.Run(m_imgSource_Mono, CVisionTools.tmpJobs[i].Matching.Tool.Pattern.TrainRegion as CogRectangle);

                    }
                    else if (CVisionTools.tmpJobs[i].QuantizeUse)
                    {
                        CVisionTools.tmpJobs[i].Matching.Tool.InputImage = CVisionTools.Quantize.Run(m_imgSource_Mono, CVisionTools.tmpJobs[i].Matching.Tool.Pattern.TrainRegion as CogRectangle, CVisionTools.tmpJobs[i].QuantizeLevel);

                    }
                    else
                    {
                        CVisionTools.tmpJobs[i].Matching.Tool.InputImage = m_imgSource_Mono;
                    }
                    CVisionTools.tmpJobs[i].Matching.Tool.Run();

                    if (CVisionTools.tmpJobs[i].Matching.Tool.Results != null)
                    {

                        if (CVisionTools.tmpJobs[i].Matching.Tool.SearchRegion != null) cogDisplay_Source.StaticGraphics.Add((ICogGraphicInteractive)CVisionTools.tmpJobs[i].Matching.Tool.SearchRegion, "ROI");

                        CVisionTools.tmpJobs[i].SubJobs.Clear();

                        for (int j = 0; j < CVisionTools.tmpJobs[i].Matching.Tool.Results.Count; j++)
                        {

                            double dRotation = CVisionTools.tmpJobs[i].Matching.Tool.Results[j].GetPose().Rotation * 180 / Math.PI;

                            CogRectangle Draw = new CogRectangle();
                            CogCompositeShape resultDrawing = CVisionTools.tmpJobs[i].Matching.Tool.Results[j].CreateResultGraphics(CogPMAlignResultGraphicConstants.All);

                            CogGraphicLabel label = new CogGraphicLabel();

                            //Set X-position to 100
                            label.X = CVisionTools.tmpJobs[i].Matching.Tool.Results[j].GetPose().TranslationX;
                            label.Y = CVisionTools.tmpJobs[i].Matching.Tool.Results[j].GetPose().TranslationY;

                            int nX = (int)(CVisionTools.tmpJobs[i].Matching.Tool.Results[j].GetPose().TranslationX - CVisionTools.tmpJobs[i].Matching.Tool.Pattern.GetTrainedPatternImage().Width);
                            int nY = (int)(CVisionTools.tmpJobs[i].Matching.Tool.Results[j].GetPose().TranslationY - CVisionTools.tmpJobs[i].Matching.Tool.Pattern.GetTrainedPatternImage().Height);
                            int nW = (int)(2D * CVisionTools.tmpJobs[i].Matching.Tool.Pattern.GetTrainedPatternImage().Width);
                            int nH = (int)(2D * CVisionTools.tmpJobs[i].Matching.Tool.Pattern.GetTrainedPatternImage().Height);

                            JOB_PART_MASTER_POSITION job = new JOB_PART_MASTER_POSITION();
                            job.Index = i;
                            job.ROI = new Rectangle(nX, nY, nW, nH);
                            job.MasterAngle = dRotation;

                            if (cbCamera.SelectedIndex == 0)
                            {
                                CVisionTools.Jobs[i].SubJobs.Add(job);
                            }
                            else
                            {
                                CVisionTools.Jobs2[i].SubJobs.Add(job);
                            }

                            Draw.Color = CogColorConstants.Magenta;
                            Draw.X = nX;
                            Draw.Y = nY;
                            Draw.Width = nW;
                            Draw.Height = nH;

                            cogDisplay_Source.StaticGraphics.Add((ICogGraphic)Draw, "ROI");

                            cogDisplay_Source.InteractiveGraphics.Add(CVisionTools.tmpJobs[i].Matching.Tool.Results[j].CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin), "main", false);
                            //cogDisplay_Source.InteractiveGraphics.Add(CVisionTools.Jobs[i].Matching.Tool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.All), "main", false);

                            label.Color = CogColorConstants.Green;

                            label.Text = dRotation.ToString("F2");
                            label.Font = new Font("arial", 20);



                            cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");

                            cogDisplay_Source.StaticGraphics.Add((ICogGraphic)resultDrawing, "main");

                            cogDisplay_Source.InteractiveGraphics.Add(CVisionTools.tmpJobs[i].Matching.Tool.Results[j].CreateResultGraphics(CogPMAlignResultGraphicConstants.TipText), "main", false);

                        }


                    }
                    else
                    {
                        if (cbCamera.SelectedIndex == 0)
                        {
                            CVisionTools.Jobs[i].InspectionUse = false;
                        }
                        else
                        {
                            CVisionTools.Jobs2[i].InspectionUse = false;
                        }
                        CUtil.ShowMessageBox("FAIL", "PATTERN NOT FIND");
                    }
                }

                //cogDisplay_Source.Image = imgOutput_Color;

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnCameraOperator_Click(object sender, EventArgs e)
        {
            pnCameraControl.Visible = !pnCameraControl.Visible;
        }

        private void gridJobs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cogDisplay_Source.StaticGraphics.Clear();
                cogDisplay_Pattern.StaticGraphics.Clear();
                nSelect_Job_Index = e.RowIndex;

                if (gridJobs.SelectedRows.Count > 0)
                {
                    int nIndex = gridJobs.SelectedRows[0].Index;

                    if (cbCamera.SelectedIndex == 0)
                    {
                        m_SelectedJob = CVisionTools.Jobs[nIndex];
                    }
                    else
                    {
                        m_SelectedJob = CVisionTools.Jobs2[nIndex];
                    }

                    UpdateSelectedJob();
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

            //propertyGrid_Param.SelectedObject = m_SeletedJob.Matching.Tool.RunParams;
        }



        private void UpdateSelectedJob()
        {
            try
            {
                tbJobName.Text = m_SelectedJob.NAME;
                tbJobScoreMin.Text = m_SelectedJob.Matching.Tool.RunParams.AcceptThreshold.ToString();
                tbContrast.Text = m_SelectedJob.Matching.Tool.RunParams.ContrastThreshold.ToString();
                chk_jobsNotOption.Checked = m_SelectedJob.NotOption;

                cbInspType.Text = m_SelectedJob.INSP_TYPE;

                chk_jobsEqualizeUse.Checked = m_SelectedJob.EqualizeUse;
                chk_jobsQuantizeUSE.Checked = m_SelectedJob.QuantizeUse;
                cbojobQuantizeLevel.SelectedIndex = m_SelectedJob.QuantizeLevel;

                cbJobUse.Checked = m_SelectedJob.InspectionUse;

                tbScaleHigh.Text = m_SelectedJob.Matching.Tool.RunParams.ZoneScale.High.ToString();
                tbScaleLow.Text = m_SelectedJob.Matching.Tool.RunParams.ZoneScale.Low.ToString();

                tbReverseMaxAngle.Text = m_SelectedJob.ANGLE.ToString();

                if (cogDisplay_Pattern.Image == null)
                {
                    CUtil.ShowMessageBox("not image", "there is no pattern matching image");
                    return;
                }

                if (m_SelectedJob.Matching.Tool.Pattern.TrainRegion is CogRectangleAffine) cbPatternRegionMode.Text = "Rectangle";
                if (m_SelectedJob.Matching.Tool.Pattern.TrainRegion is CogCircle) cbPatternRegionMode.Text = "Circle";

                cogDisplay_Pattern.Image = m_SelectedJob.Matching.Tool.Pattern.GetTrainedPatternImage();
                cogDisplay_Pattern.StaticGraphics.AddList(TrainGraphic(cogDisplay_Pattern), "");
                cogDisplay_Pattern.Fit(true);

                propertyGrid_Param.SelectedObject = m_SelectedJob.Matching.Tool.RunParams;

                cogDisplay_Source.InteractiveGraphics.Clear();

                if (m_SelectedJob == null) return;
                if (m_SelectedJob.Matching.Tool.SearchRegion == null) return;

                cogDisplay_Source.InteractiveGraphics.Add((CogRectangle)m_SelectedJob.Matching.Tool.SearchRegion, "Search", false);

            }
            catch(Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void UpdateSelectedMultiPMAlign()
        {
            try
            {
                tbMutiPMAlignName.Text = m_SelectedMultiPMAlign.NAME;
                tbMultiPMAlignScoreMIN.Text = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.AcceptThreshold.ToString();
                tbMultiPMAlignContrast.Text = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.ContrastThreshold.ToString();
                chk_MultiPMAlignNOTOPTIONUSE.Checked = m_SelectedMultiPMAlign.NotOption;

                cboMultiPMAlignInsType.Text = m_SelectedMultiPMAlign.INSP_TYPE;

                chk_MultiPMAlignEqualizeUSE.Checked = m_SelectedMultiPMAlign.EqualizeUse;
                chk_MultiPMAlignQuantizeUSE.Checked = m_SelectedMultiPMAlign.QuantizeUse;
                cboMultiPMAlignLEVEL.SelectedIndex = m_SelectedMultiPMAlign.QuantizeLevel;

                chk_MultiPMAlignUSE.Checked = m_SelectedMultiPMAlign.InspectionUse;

                tbMultiPMAlignScaleHIGH.Text = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.ZoneScale.High.ToString();
                tbMultiPMAlignScaleLOW.Text = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.ZoneScale.Low.ToString();

                tbMultiPMAlignANGLE.Text = m_SelectedMultiPMAlign.ANGLE.ToString();

                chk_MultiPMAlignThresholdUSE.Checked = m_SelectedMultiPMAlign.ThresholdUse;
                lbThreshold.Text = m_SelectedMultiPMAlign.ThresholdValue.ToString();
                //trbThreshold.Value = m_SelectedMultiPMAlign.ThresholdValue;
                //if (cogDisply_MultiPattern.Image == null)
                //{
                //    CUtil.ShowMessageBox("not image", "there is no pattern matching image");
                //    return;
                //}
                cboPatternINDEX.Items.Clear();
                for (int i = 0; i < m_SelectedMultiPMAlign.Matching.Tool.Operator.Count; i++)
                {
                    cboPatternINDEX.Items.Add(i + 1);

                }

                if (m_SelectedMultiPMAlign.Matching.Tool.Operator.Count > 0) { cboPatternINDEX.SelectedIndex = 0; }


                if (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion is CogRectangleAffine) cboMultiPatternRegionMode.Text = "Rectangle";
                if (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion is CogCircle) cboMultiPatternRegionMode.Text = "Circle";

                cogDisply_MultiPattern.Image = m_SelectedMultiPMAlign.Matching.Tool.Operator[0].Pattern.GetTrainedPatternImage();
                cogDisply_MultiPattern.StaticGraphics.AddList(TrainGraphic(cogDisply_MultiPattern, m_SelectedMultiPMAlign.Matching.Tool ,0), "");
                cogDisply_MultiPattern.Fit(true);

                propertyGrid_MultiPMAlign.SelectedObject = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams;

                cogDisplay_Source.InteractiveGraphics.Clear();

                if (m_SelectedMultiPMAlign == null) return;
                if (m_SelectedMultiPMAlign.Matching.Tool.SearchRegion == null) return;

                cogDisplay_Source.InteractiveGraphics.Add((CogRectangle)m_SelectedMultiPMAlign.Matching.Tool.SearchRegion, "Search", false);

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void UpdateJob()
        {
            try
            {
                gridJobs.Rows.Clear();

                for (int i = 0; i < CVisionTools.Jobs.Count; i++)
                {
                    tbJobName.Text = m_SelectedJob.NAME;
                    tbJobScoreMin.Text = m_SelectedJob.Matching.Tool.RunParams.AcceptThreshold.ToString();
                    //trbThreshold.Text = m_SeletedJob.THRESHOLD.ToString();

                    chk_jobsNotOption.Checked = m_SelectedJob.NotOption;

                    chk_jobsEqualizeUse.Checked = m_SelectedJob.EqualizeUse;
                    chk_jobsQuantizeUSE.Checked = m_SelectedJob.QuantizeUse;
                    cbojobQuantizeLevel.SelectedIndex = m_SelectedJob.QuantizeLevel;


                    gridJobs.Rows.Add(new object[] { CVisionTools.Jobs[i].NAME, CVisionTools.Jobs[i].INSP_TYPE, CVisionTools.Jobs[i].MASTER_COUNT.ToString(), CVisionTools.Jobs[i].ANGLE.ToString(), CVisionTools.Jobs[i].NotOption.ToString(), CVisionTools.Jobs[i].QuantizeUse.ToString(), CVisionTools.Jobs[i].QuantizeLevel.ToString(), CVisionTools.Jobs[i].EqualizeUse.ToString() });
                }

                if (m_SelectedJob == null) return;

                if (m_SelectedJob.Matching.Tool.Pattern.Trained)
                {
                    cogDisplay_Pattern.Image = m_SelectedJob.Matching.Tool.Pattern.GetTrainedPatternImage();
                }

                //PM Align
                propertyGrid_Param.SelectedObject = m_SelectedJob.Matching.Tool.RunParams;


                //gridJobs.Rows.Clear();
                //for (int i = 0; i < CVisionTools.Jobs.Count; i++)
                //{
                //    gridJobs.Rows.Add(new string[] { CVisionTools.Jobs[i].NAME, CVisionTools.Jobs[i].TYPE, CVisionTools.Jobs[i].MASTER_COUNT.ToString() });
                //}
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void UpdateModelCode()
        {
            try
            {
                Grid_ModelCODE.Rows.Clear();
                for (int i = 0; i < Global.System.Recipe.ModelCode.Count; i++)
                {

                    Grid_ModelCODE.Rows.Add(new object[] { Global.System.Recipe.ModelCode[i] });
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            
        }


        private void UpdateJob(int camindex)
        {
            try
            {
                gridJobs.Rows.Clear();

                if (camindex == 0)
                {
                    for (int i = 0; i < CVisionTools.Jobs.Count; i++)
                    {
                        tbJobName.Text = m_SelectedJob.NAME;
                        tbJobScoreMin.Text = m_SelectedJob.Matching.Tool.RunParams.AcceptThreshold.ToString();
                        //trbThreshold.Text = m_SeletedJob.THRESHOLD.ToString();

                        chk_jobsNotOption.Checked = m_SelectedJob.NotOption;

                        chk_jobsEqualizeUse.Checked = m_SelectedJob.EqualizeUse;
                        chk_jobsQuantizeUSE.Checked = m_SelectedJob.QuantizeUse;
                        cbojobQuantizeLevel.SelectedIndex = m_SelectedJob.QuantizeLevel;
                        cbJobUse.Checked = m_SelectedJob.InspectionUse;
                        chk_jobMaskUse.Checked = m_SelectedJob.MaskingUse;


                        gridJobs.Rows.Add(new object[] { CVisionTools.Jobs[i].NAME, CVisionTools.Jobs[i].INSP_TYPE, CVisionTools.Jobs[i].MASTER_COUNT.ToString(), CVisionTools.Jobs[i].ANGLE.ToString(), CVisionTools.Jobs[i].NotOption.ToString(), CVisionTools.Jobs[i].QuantizeUse.ToString(), CVisionTools.Jobs[i].QuantizeLevel.ToString(), CVisionTools.Jobs[i].EqualizeUse.ToString(), CVisionTools.Jobs[i].InspectionUse.ToString(), CVisionTools.Jobs[i].MaskingUse.ToString() });
                    }
                }
                else
                {
                    for (int i = 0; i < CVisionTools.Jobs2.Count; i++)
                    {
                        tbJobName.Text = m_SelectedJob.NAME;
                        tbJobScoreMin.Text = m_SelectedJob.Matching.Tool.RunParams.AcceptThreshold.ToString();
                        //trbThreshold.Text = m_SeletedJob.THRESHOLD.ToString();

                        chk_jobsNotOption.Checked = m_SelectedJob.NotOption;

                        chk_jobsEqualizeUse.Checked = m_SelectedJob.EqualizeUse;
                        chk_jobsQuantizeUSE.Checked = m_SelectedJob.QuantizeUse;
                        cbojobQuantizeLevel.SelectedIndex = m_SelectedJob.QuantizeLevel;
                        cbJobUse.Checked = m_SelectedJob.InspectionUse;
                        chk_jobMaskUse.Checked = m_SelectedJob.MaskingUse;


                        gridJobs.Rows.Add(new object[] { CVisionTools.Jobs2[i].NAME, CVisionTools.Jobs2[i].INSP_TYPE, CVisionTools.Jobs2[i].MASTER_COUNT.ToString(), CVisionTools.Jobs2[i].ANGLE.ToString(), CVisionTools.Jobs2[i].NotOption.ToString(), CVisionTools.Jobs2[i].QuantizeUse.ToString(), CVisionTools.Jobs2[i].QuantizeLevel.ToString(), CVisionTools.Jobs2[i].EqualizeUse.ToString(), CVisionTools.Jobs2[i].InspectionUse.ToString(), CVisionTools.Jobs2[i].MaskingUse.ToString() });
                    }
                }



                if (m_SelectedJob == null) return;

                if (m_SelectedJob.Matching.Tool.Pattern.Trained)
                {
                    cogDisplay_Pattern.Image = m_SelectedJob.Matching.Tool.Pattern.GetTrainedPatternImage();
                }

                //PM Align
                propertyGrid_Param.SelectedObject = m_SelectedJob.Matching.Tool.RunParams;


                
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void UpdateMultiPMAlign(int camindex)
        {
            try
            {
                gridMultiPMAlign.Rows.Clear();

                if (camindex == 0)
                {
                    for (int i = 0; i < CVisionTools.MultiPMAlign.Count; i++)
                    {
                        tbMutiPMAlignName.Text = m_SelectedMultiPMAlign.NAME;
                        tbMultiPMAlignScoreMIN.Text = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.AcceptThreshold.ToString();
                        //trbThreshold.Text = m_SeletedJob.THRESHOLD.ToString();

                        chk_MultiPMAlignNOTOPTIONUSE.Checked = m_SelectedMultiPMAlign.NotOption;

                        chk_MultiPMAlignEqualizeUSE.Checked = m_SelectedMultiPMAlign.EqualizeUse;
                        chk_MultiPMAlignQuantizeUSE.Checked = m_SelectedMultiPMAlign.QuantizeUse;
                        cboMultiPMAlignLEVEL.SelectedIndex = m_SelectedMultiPMAlign.QuantizeLevel;
                        chk_MultiPMAlignUSE.Checked = m_SelectedMultiPMAlign.InspectionUse;
                        chk_MultiPMAlignMASKINGUSE.Checked = m_SelectedMultiPMAlign.MaskingUse;
                        chk_MultiPMAlignThresholdUSE.Checked = m_SelectedMultiPMAlign.ThresholdUse;
                        trbThreshold.Text = m_SelectedMultiPMAlign.ThresholdValue.ToString();
                        //trbThreshold.Value = m_SelectedMultiPMAlign.ThresholdValue;

                        cboMultiPMAlignInsType.Text = m_SelectedMultiPMAlign.INSP_TYPE;


                        gridMultiPMAlign.Rows.Add(new object[] { CVisionTools.MultiPMAlign[i].NAME, CVisionTools.MultiPMAlign[i].INSP_TYPE, CVisionTools.MultiPMAlign[i].MASTER_COUNT.ToString(), CVisionTools.MultiPMAlign[i].ANGLE.ToString(), CVisionTools.MultiPMAlign[i].NotOption.ToString(), CVisionTools.MultiPMAlign[i].QuantizeUse.ToString(), CVisionTools.MultiPMAlign[i].QuantizeLevel.ToString(), CVisionTools.MultiPMAlign[i].EqualizeUse.ToString(), CVisionTools.MultiPMAlign[i].InspectionUse.ToString(), CVisionTools.MultiPMAlign[i].MaskingUse.ToString(), CVisionTools.MultiPMAlign[i].ThresholdUse.ToString(), CVisionTools.MultiPMAlign[i].ThresholdValue.ToString() });
                    }
                }
                else
                {
                    for (int i = 0; i < CVisionTools.MultiPMAlign2.Count; i++)
                    {
                        tbMutiPMAlignName.Text = m_SelectedMultiPMAlign.NAME;
                        tbMultiPMAlignScoreMIN.Text = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.AcceptThreshold.ToString();
                        //trbThreshold.Text = m_SeletedJob.THRESHOLD.ToString();

                        chk_MultiPMAlignNOTOPTIONUSE.Checked = m_SelectedMultiPMAlign.NotOption;

                        chk_MultiPMAlignEqualizeUSE.Checked = m_SelectedMultiPMAlign.EqualizeUse;
                        chk_MultiPMAlignQuantizeUSE.Checked = m_SelectedMultiPMAlign.QuantizeUse;
                        cboMultiPMAlignLEVEL.SelectedIndex = m_SelectedMultiPMAlign.QuantizeLevel;
                        chk_MultiPMAlignUSE.Checked = m_SelectedMultiPMAlign.InspectionUse;
                        chk_MultiPMAlignMASKINGUSE.Checked = m_SelectedMultiPMAlign.MaskingUse;
                        chk_MultiPMAlignThresholdUSE.Checked = m_SelectedMultiPMAlign.ThresholdUse;
                        trbThreshold.Text = m_SelectedMultiPMAlign.ThresholdValue.ToString();
                        //trbThreshold.Value = m_SelectedMultiPMAlign.ThresholdValue;

                        cboMultiPMAlignInsType.Text = m_SelectedMultiPMAlign.INSP_TYPE;


                        gridMultiPMAlign.Rows.Add(new object[] { CVisionTools.MultiPMAlign2[i].NAME, CVisionTools.MultiPMAlign2[i].INSP_TYPE, CVisionTools.MultiPMAlign2[i].MASTER_COUNT.ToString(), CVisionTools.MultiPMAlign2[i].ANGLE.ToString(), CVisionTools.MultiPMAlign2[i].NotOption.ToString(), CVisionTools.MultiPMAlign2[i].QuantizeUse.ToString(), CVisionTools.MultiPMAlign2[i].QuantizeLevel.ToString(), CVisionTools.MultiPMAlign2[i].EqualizeUse.ToString(), CVisionTools.MultiPMAlign2[i].InspectionUse.ToString(), CVisionTools.MultiPMAlign2[i].MaskingUse.ToString(), CVisionTools.MultiPMAlign2[i].ThresholdUse.ToString(), CVisionTools.MultiPMAlign2[i].ThresholdValue.ToString() });
                    }
                }



                if (m_SelectedMultiPMAlign == null) return;

                if (m_SelectedMultiPMAlign.Matching.Tool.Operator[0].Pattern.Trained)
                {
                    cogDisply_MultiPattern.Image = m_SelectedMultiPMAlign.Matching.Tool.Operator[0].Pattern.GetTrainedPatternImage();
                }

                //PM Align
                propertyGrid_MultiPMAlign.SelectedObject = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams;


                
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void UpdateBlob()
        {
            try
            {
                gridBlob.Rows.Clear();

                for (int i = 0; i < CVisionTools.Blobs.Count; i++)
                {
                    tbBlobName.Text = m_SeletedBlob.Defect_Name;
                    tbAreaMax.Text = m_SeletedBlob.Defect_Max.ToString();
                    tbBlobMasterCount.Text = m_SeletedBlob.Defect_MasterCount.ToString();
                    tbAreaMin.Text = m_SeletedBlob.BLOB.Tool.RunParams.ConnectivityMinPixels.ToString();
                    trbThreshold.Text = m_SeletedBlob.Defect_Threshold.ToString();

                    gridBlob.Rows.Add(new object[] { CVisionTools.Blobs[i].Defect_Name, CVisionTools.Blobs[i].Defect_MasterCount, CVisionTools.Blobs[i].Defect_Threshold, CVisionTools.Blobs[i].Defect_Min, CVisionTools.Blobs[i].Defect_Max });
                }

                if (m_SeletedBlob == null) return;

                propertyGrid_Blob.SelectedObject = m_SeletedBlob.BLOB.Tool.RunParams;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void UpdateBlob(int camindex)
        {
            try
            {
                gridBlob.Rows.Clear();

                if (camindex == 0)
                {
                    for (int i = 0; i < CVisionTools.Blobs.Count; i++)
                    {
                        tbBlobName.Text = m_SeletedBlob.Defect_Name;
                        tbAreaMax.Text = m_SeletedBlob.Defect_Max.ToString();
                        tbBlobMasterCount.Text = m_SeletedBlob.Defect_MasterCount.ToString();
                        tbAreaMin.Text = m_SeletedBlob.BLOB.Tool.RunParams.ConnectivityMinPixels.ToString();
                        trbThreshold.Text = m_SeletedBlob.Defect_Threshold.ToString();

                        chk_BlobUse.Checked = m_SeletedBlob.InspectionUse;

                        gridBlob.Rows.Add(new object[] { CVisionTools.Blobs[i].Defect_Name, CVisionTools.Blobs[i].Defect_MasterCount, CVisionTools.Blobs[i].Defect_Threshold, CVisionTools.Blobs[i].Defect_Min, CVisionTools.Blobs[i].Defect_Max, CVisionTools.Blobs[i].InspectionUse.ToString() });
                    }
                }
                else
                {
                    for (int i = 0; i < CVisionTools.Blobs2.Count; i++)
                    {
                        tbBlobName.Text = m_SeletedBlob.Defect_Name;
                        tbAreaMax.Text = m_SeletedBlob.Defect_Max.ToString();
                        tbBlobMasterCount.Text = m_SeletedBlob.Defect_MasterCount.ToString();
                        tbAreaMin.Text = m_SeletedBlob.BLOB.Tool.RunParams.ConnectivityMinPixels.ToString();
                        trbThreshold.Text = m_SeletedBlob.Defect_Threshold.ToString();

                        chk_BlobUse.Checked = m_SeletedBlob.InspectionUse;

                        gridBlob.Rows.Add(new object[] { CVisionTools.Blobs2[i].Defect_Name, CVisionTools.Blobs2[i].Defect_MasterCount, CVisionTools.Blobs2[i].Defect_Threshold, CVisionTools.Blobs2[i].Defect_Min, CVisionTools.Blobs2[i].Defect_Max, CVisionTools.Blobs2[i].InspectionUse.ToString() });
                    }
                }




                if (m_SeletedBlob == null) return;

                propertyGrid_Blob.SelectedObject = m_SeletedBlob.BLOB.Tool.RunParams;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void UpdateColor(int camindex)
        {
            try
            {
                GridColor.Rows.Clear();

                if (camindex == 0)
                {
                    for (int i = 0; i < CVisionTools.ColorMatch.Count; i++)
                    {
                        tbColorName.Text = m_SelectedColor.Defect_Name;
                        
                        chk_ColorUSE.Checked = m_SelectedColor.InspectionUse;
                        tbColorSCORE.Text = m_SelectedColor.SCORE.ToString();
                        

                        GridColor.Rows.Add(new object[] { CVisionTools.ColorMatch[i].Defect_Name, CVisionTools.ColorMatch[i].InspectionUse.ToString(), CVisionTools.ColorMatch[i].ColorCount.ToString(),CVisionTools.ColorMatch[i].SCORE.ToString() });
                    }
                }
                else
                {
                    for (int i = 0; i < CVisionTools.ColorMatch2.Count; i++)
                    {
                        tbColorName.Text = m_SelectedColor.Defect_Name;

                        chk_ColorUSE.Checked = m_SelectedColor.InspectionUse;
                        tbColorSCORE.Text = m_SelectedColor.SCORE.ToString();

                        GridColor.Rows.Add(new object[] { CVisionTools.ColorMatch2[i].Defect_Name, CVisionTools.ColorMatch2[i].InspectionUse.ToString(), CVisionTools.ColorMatch2[i].ColorCount.ToString(), CVisionTools.ColorMatch2[i].SCORE.ToString() });
                    }
                }




                if (m_SelectedColor == null) return;

                propertyGrid_ColorMatch.SelectedObject = m_SelectedColor.COLORMATCH.Tool.RunParams;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void UpdateOCV(int camindex)
        {
            try
            {
                grid_OCV.Rows.Clear();

                if (camindex == 0)
                {
                    for (int i = 0; i < CVisionTools.OCR.Count; i++)
                    {
                        tbOCVName.Text = m_SelectedOCR.Defect_Name;

                        chk_OCVUse.Checked = m_SelectedOCR.InspectionUse;
                        tbCOMPARESTRING.Text = m_SelectedOCR.COMPARE_STRING;
                        tbOCRSCORE.Text = m_SelectedOCR.OCR.Tool.ClassifierRunParams.AcceptThreshold.ToString();
                        //tbTRAINOCR.Text = m_SelectedOCR.TRAIN_OCR;

                        grid_OCV.Rows.Add(new object[] { CVisionTools.OCR[i].Defect_Name, CVisionTools.OCR[i].InspectionUse.ToString(), CVisionTools.OCR[i].COMPARE_STRING });
                    }
                }
                else
                {
                    for (int i = 0; i < CVisionTools.OCR2.Count; i++)
                    {
                        tbOCVName.Text = m_SelectedOCR.Defect_Name;

                        chk_OCVUse.Checked = m_SelectedColor.InspectionUse;
                        tbCOMPARESTRING.Text = m_SelectedOCR.COMPARE_STRING;
                        tbOCRSCORE.Text = m_SelectedOCR.OCR.Tool.ClassifierRunParams.AcceptThreshold.ToString();
                        //tbTRAINOCR.Text = m_SelectedOCR.TRAIN_OCR;

                        grid_OCV.Rows.Add(new object[] { CVisionTools.OCR2[i].Defect_Name, CVisionTools.OCR2[i].InspectionUse.ToString(), CVisionTools.OCR2[i].COMPARE_STRING });
                    }
                }




                if (m_SelectedOCR == null) return;

                propertyGrid_OCV.SelectedObject = m_SelectedOCR.OCR.Tool.ClassifierRunParams;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void UpdateGrabSeq()
        {
            try
            {
                gridSeq.Rows.Clear();

                for (int i = 0; i < CVisionTools.Grab_seq.Count; i++)
                {
                    //GRAB_SEQ SeqParam = CVisionTools.Grab_seq[i];
                    JOB_SEQ SeqParam = CVisionTools.Grab_seq[i];


                    int nLightValue = SeqParam.LightValue;

                    gridSeq.Rows.Add(new object[] { nLightValue });
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void UpdateGrabSeq(int Camindex)
        {
            try
            {
                gridSeq.Rows.Clear();

                if (Camindex == 0)
                {
                    for (int i = 0; i < CVisionTools.Grab_seq.Count; i++)
                    {
                        //GRAB_SEQ SeqParam = CVisionTools.Grab_seq[i];
                        JOB_SEQ SeqParam = CVisionTools.Grab_seq[i];

                        int nLightValue = SeqParam.LightValue;

                        int Exposure = SeqParam.Exposure;
                        int Gain = SeqParam.Gain;
                        //bool USE = SeqParam.USE;

                        gridSeq.Rows.Add(new object[] { nLightValue, Exposure, Gain }); ;
                    }
                }
                else
                {
                    for (int i = 0; i < CVisionTools.Grab_seq2.Count; i++)
                    {
                        //GRAB_SEQ SeqParam = CVisionTools.Grab_seq2[i];
                        JOB_SEQ SeqParam = CVisionTools.Grab_seq[i];

                        int nLightValue = SeqParam.LightValue;

                        int Exposure = SeqParam.Exposure;
                        int Gain = SeqParam.Gain;
                        //bool USE = SeqParam.USE;

                        gridSeq.Rows.Add(new object[] { nLightValue, Exposure, Gain });
                    }
                }



            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnJobApply_Click(object sender, EventArgs e)
        {
            try
            {
                string str_Name = tbJobName.Text;
                int nMasterCount = 1;
                int nThreshold = trbThreshold.Value;
                double dScoreMin = double.Parse(tbJobScoreMin.Text);
                double dAngle = double.Parse(tbReverseMaxAngle.Text);
                //string str_NotOption = chk_jobsNotOption.Checked.ToString();
                //string str_Quantize = chk_QuantizeUse.Checked.ToString();
                int dQuantizeLevel = cbojobQuantizeLevel.SelectedIndex;


                int nCamIndex = cbCamera.SelectedIndex;
                int nIndex = nSelect_Job_Index;

                if (m_SelectedJob == null)
                {
                    CUtil.ShowMessageBox("ALRAM", "SELECT JOB.");
                    return;
                }

                if (gridJobs.SelectedRows.Count > 0)
                {
                    m_SelectedJob.NAME = str_Name;
                    m_SelectedJob.MASTER_COUNT = nMasterCount;
                    m_SelectedJob.Matching.Tool.RunParams.AcceptThreshold = dScoreMin;
                    m_SelectedJob.ANGLE = dAngle;
                    m_SelectedJob.NotOption = chk_jobsNotOption.Checked;
                    m_SelectedJob.QuantizeUse = chk_jobsQuantizeUSE.Checked;
                    m_SelectedJob.QuantizeLevel = dQuantizeLevel;
                    m_SelectedJob.EqualizeUse = chk_jobsEqualizeUse.Checked;
                    m_SelectedJob.InspectionUse = cbJobUse.Checked;
                    m_SelectedJob.MaskingUse = chk_jobMaskUse.Checked;
                    m_SelectedJob.INSP_TYPE = cbInspType.Text;

                    if (cbCamera.SelectedIndex == 0)
                    {
                        CVisionTools.Jobs.RemoveAt(nIndex);
                        CVisionTools.Jobs.Insert(nIndex, m_SelectedJob);
                    }
                    else
                    {
                        CVisionTools.Jobs2.RemoveAt(nIndex);
                        CVisionTools.Jobs2.Insert(nIndex, m_SelectedJob);
                    }


                    gridJobs.SelectedRows[0].SetValues(new object[] { m_SelectedJob.NAME, m_SelectedJob.INSP_TYPE, m_SelectedJob.MASTER_COUNT, m_SelectedJob.ANGLE, m_SelectedJob.NotOption.ToString(), m_SelectedJob.QuantizeUse.ToString(), m_SelectedJob.QuantizeLevel.ToString(), m_SelectedJob.EqualizeUse.ToString(), m_SelectedJob.InspectionUse.ToString(), m_SelectedJob.MaskingUse.ToString() });
                }

                try
                {
                    m_SelectedJob.Matching.Tool.RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.LowHigh;
                    m_SelectedJob.Matching.Tool.RunParams.ZoneScale.High = double.Parse(tbScaleHigh.Text);
                    m_SelectedJob.Matching.Tool.RunParams.ZoneScale.Low = double.Parse(tbScaleLow.Text);
                    m_SelectedJob.Matching.Tool.RunParams.AcceptThreshold = double.Parse(tbJobScoreMin.Text);
                    m_SelectedJob.Matching.Tool.RunParams.ContrastThreshold = double.Parse(tbContrast.Text);

                    propertyGrid_Param.SelectedObject = m_SelectedJob.Matching.Tool.RunParams;
                    propertyGrid_Param.Invalidate();
                }
                catch (Exception ex)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void OnKeyPressOnlyNumber(object sender, KeyPressEventArgs e)
        {
            CUtil.InputOnlyNumber(sender, e, false, false);
        }

        private void btnPatternSetting_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_SelectedJob == null)
                {
                    CUtil.ShowMessageBox("NOTICE", "SELECT THE JOB.");
                    return;
                }

                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();

                propertyGrid_Param.SelectedObject = m_SelectedJob.Matching.Tool.RunParams;

                ViewPatternRegion(m_SelectedJob.Matching.Tool, cogDisplay_Source);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void ViewPatternRegion(CogPMAlignTool tool, CogDisplay display)
        {
            if (tool.SearchRegion == null) tool.SearchRegion = new CogRectangle();

            CogRectangle cogSerachRegion = (CogRectangle)tool.SearchRegion;
            cogSerachRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
            cogSerachRegion.Interactive = true;
            cogSerachRegion.Color = CogColorConstants.Red;
            if (cogSerachRegion.Width == 0) cogSerachRegion.Width = 300;
            if (cogSerachRegion.Height == 0) cogSerachRegion.Height = 300;

            tool.Pattern.TrainRegionMode = CogRegionModeConstants.PixelAlignedBoundingBoxAdjustMask;

            switch (cbPatternRegionMode.Text)
            {
                case "Rectangle":
                    {
                        if (tool.Pattern.TrainRegion == null) tool.Pattern.TrainRegion = new CogRectangleAffine();
                        if (tool.Pattern.TrainRegion is CogRectangleAffine == false) tool.Pattern.TrainRegion = new CogRectangleAffine();

                        CogRectangleAffine cogTrainRegion = (CogRectangleAffine)tool.Pattern.TrainRegion;
                        cogTrainRegion.GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
                        cogTrainRegion.Interactive = true;
                        cogTrainRegion.Color = CogColorConstants.Blue;
                        if (cogTrainRegion.CenterX == 0 || cogTrainRegion.CenterY == 0)
                        {
                            cogTrainRegion.CenterX = 100;
                            cogTrainRegion.CenterY = 100;
                        }

                        display.InteractiveGraphics.Add((ICogGraphicInteractive)tool.Pattern.TrainRegion, "Pattern", false);
                    }
                    break;
                case "Circle":
                    {
                        if (m_SelectedJob.Matching.Tool.Pattern.TrainRegion == null) m_SelectedJob.Matching.Tool.Pattern.TrainRegion = new CogCircle();
                        if (tool.Pattern.TrainRegion is CogCircle == false) tool.Pattern.TrainRegion = new CogCircle();
                        CogCircle cogTrainCircleRegion = (CogCircle)m_SelectedJob.Matching.Tool.Pattern.TrainRegion;

                        if(cogTrainCircleRegion.Radius == 0) cogTrainCircleRegion.Radius = 45;
                        cogTrainCircleRegion.GraphicDOFEnable = CogCircleDOFConstants.All;
                        cogTrainCircleRegion.Interactive = true;

                        cogDisplay_Source.InteractiveGraphics.Add((ICogGraphicInteractive)cogTrainCircleRegion, "CirclePattern", false);
                    }
                    break;
            }

            display.InteractiveGraphics.Add((ICogGraphicInteractive)cogSerachRegion, "Search", false);
        }

        private void ViewMultiPatternRegion(CogPMAlignMultiTool tool, CogDisplay display)
        {
            if (tool.SearchRegion == null) tool.SearchRegion = new CogRectangle();

            CogRectangle cogMultiPMSerachRegion = (CogRectangle)tool.SearchRegion;
            cogMultiPMSerachRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
            cogMultiPMSerachRegion.Interactive = true;
            cogMultiPMSerachRegion.Color = CogColorConstants.Red;
            if (cogMultiPMSerachRegion.Width == 0) cogMultiPMSerachRegion.Width = 300;
            if (cogMultiPMSerachRegion.Height == 0) cogMultiPMSerachRegion.Height = 300;

            m_SelectedMultiPMAlign.Matching.PMAlign = new CogPMAlignTool();

            //if (m_SelectedMultiPMAlign.Matching.PMAlign.SearchRegion == null) m_SelectedMultiPMAlign.Matching.PMAlign.SearchRegion = new CogRectangle();
            //if (m_SelectedMultiPMAlign.Matching.PMAlign.SearchRegion is CogRectangle == false) m_SelectedMultiPMAlign.Matching.PMAlign.SearchRegion = new CogRectangle();
            //CogRectangle cogPMAlignSearchRegion = (CogRectangle)m_SelectedMultiPMAlign.Matching.PMAlign.SearchRegion;
            //cogPMAlignSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
            //cogPMAlignSearchRegion.Interactive = true;
            //cogPMAlignSearchRegion.Color = CogColorConstants.Yellow;
            //if (cogPMAlignSearchRegion.Width == 0) cogMultiPMSerachRegion.Width = 200;
            //if (cogPMAlignSearchRegion.Height == 0) cogMultiPMSerachRegion.Height = 200;

            //display.InteractiveGraphics.Add((ICogGraphicInteractive)cogPMAlignSearchRegion, "Search", false);

            switch (cbPatternRegionMode.Text)
            {
                case "Rectangle":
                    {
                        if (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion == null) m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion = new CogRectangleAffine();
                        if (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion is CogRectangleAffine == false) m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion = new CogRectangleAffine();

                        CogRectangleAffine cogTrainRegion = (CogRectangleAffine)m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion;
                        cogTrainRegion.GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
                        cogTrainRegion.Interactive = true;
                        cogTrainRegion.Color = CogColorConstants.Blue;
                        if (cogTrainRegion.CenterX == 0 || cogTrainRegion.CenterY == 0)
                        {
                            cogTrainRegion.CenterX = 100;
                            cogTrainRegion.CenterY = 100;
                        }

                        display.InteractiveGraphics.Add((ICogGraphicInteractive)m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion, "Pattern", false);
                    }
                    break;
                case "Circle":
                    {
                        if (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion == null) m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion = new CogCircle();
                        if (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion is CogCircle == false) m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion = new CogCircle();
                        CogCircle cogTrainCircleRegion = (CogCircle)m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion;

                        if (cogTrainCircleRegion.Radius == 0) cogTrainCircleRegion.Radius = 45;
                        cogTrainCircleRegion.GraphicDOFEnable = CogCircleDOFConstants.All;
                        cogTrainCircleRegion.Interactive = true;

                        cogDisplay_Source.InteractiveGraphics.Add((ICogGraphicInteractive)cogTrainCircleRegion, "CirclePattern", false);
                    }
                    break;
            }

            display.InteractiveGraphics.Add((ICogGraphicInteractive)cogMultiPMSerachRegion, "MultiSearch", false);
        }


        private void OnClickFiducial(object sender, EventArgs e)
        {
            try
            {
                string strCamIndex = (sender as MetroButton).Tag.ToString();
                string strIndex = (sender as MetroButton).Text;

                CogDisplay display = strCamIndex == "1" ? cogDisplay_Cam1_Fiducial : cogDisplay_Cam2_Fiducial;
                CCogTool_PMAlign PMAlign = strCamIndex == "1" ? CVisionTools.PMALIGN_CAM1 : CVisionTools.PMALIGN_CAM2;
                CCogTool_Fixture Fixture = strCamIndex == "1" ? CVisionTools.FIXTURE_CAM1 : CVisionTools.FIXTURE_CAM2;

                switch (strIndex)
                {
                    case "SEARCH ROI":
                        {
                            cogDisplay_Source.InteractiveGraphics.Clear();
                            cogDisplay_Source.StaticGraphics.Clear();

                            if (PMAlign.Tool.SearchRegion == null) PMAlign.Tool.SearchRegion = new CogRectangle();

                            CogRectangle cogTrainRegion = (CogRectangle)PMAlign.Tool.SearchRegion;
                            cogTrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                            cogTrainRegion.Interactive = true;
                            cogDisplay_Source.InteractiveGraphics.Add((ICogGraphicInteractive)cogTrainRegion, "Search", false);
                        }
                        break;
                    case "PATTERN ROI":
                        {
                            cogDisplay_Source.InteractiveGraphics.Clear();
                            cogDisplay_Source.StaticGraphics.Clear();

                            if (PMAlign.Tool.Pattern.TrainRegion == null) PMAlign.Tool.Pattern.TrainRegion = new CogRectangle();


                            CogRectangleAffine cogTrainRegion = (CogRectangleAffine)PMAlign.Tool.Pattern.TrainRegion;
                            if (cogTrainRegion.CenterX == 0 || cogTrainRegion.CenterY == 0)
                            {
                                if (cogTrainRegion.SideXLength <= 100) cogTrainRegion.SideXLength = 250;
                                if (cogTrainRegion.SideYLength <= 100) cogTrainRegion.SideYLength = 250;
                            }


                            cogDisplay_Source.InteractiveGraphics.Add((ICogGraphicInteractive)cogTrainRegion, "Pattern", false);
                        }
                        break;
                    case "TRAIN":
                        {
                            PMAlign.Tool.Pattern.TrainImage = m_imgSource_Mono;
                            PMAlign.Tool.Pattern.Origin.TranslationX = (PMAlign.Tool.Pattern.TrainRegion as CogRectangleAffine).CenterX;
                            PMAlign.Tool.Pattern.Origin.TranslationY = (PMAlign.Tool.Pattern.TrainRegion as CogRectangleAffine).CenterY;

                            PMAlign.Tool.Pattern.Train();

                            display.Image = PMAlign.Tool.Pattern.GetTrainedPatternImage();
                            display.StaticGraphics.AddList(TrainGraphic(display, PMAlign, PMAlign.Tool.Pattern.TrainRegion), "");
                            display.Fit(true);
                        }
                        break;
                    case "RUN":
                        {
                            cogDisplay_Source.InteractiveGraphics.Clear();
                            cogDisplay_Source.StaticGraphics.Clear();

                            PMAlign.Tool.InputImage = m_imgSource_Mono;
                            PMAlign.Tool.Run();

                            for (int i = 0; i < PMAlign.Tool.Results.Count; i++)

                            {
                                CogRectangle Draw = new CogRectangle();
                                CogCompositeShape resultDrawing = PMAlign.Tool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.All);

                                CogGraphicLabel label = new CogGraphicLabel();

                                label.X = PMAlign.Tool.Results[i].GetPose().TranslationX;
                                label.Y = PMAlign.Tool.Results[i].GetPose().TranslationY;
                                

                                cogDisplay_Source.InteractiveGraphics.Add(PMAlign.Tool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin), "main", false);
                                cogDisplay_Source.StaticGraphics.Add(resultDrawing, "main");



                                if (Fixture.NAME == "FIXTURE_CAM1")
                                {
                                    //CogImage8Grey cam1_fixtureimg = new CogImage8Grey();
                                    //cam1_fixtureimg = CAM1_Fixturing_Run();
                                    Fixture.Run(m_imgSource_Mono, PMAlign.Tool.Results[0].GetPose(), out FixtureSource1);

                                    
                                    CVisionTools.FIXTURE_CAM1.Origin_Translation_X = PMAlign.Tool.Results[i].GetPose().TranslationX;
                                    CVisionTools.FIXTURE_CAM1.Origin_Translation_Y = PMAlign.Tool.Results[i].GetPose().TranslationY;
                                    

                                }
                                else
                                {
                                    //CogImage8Grey cam2_fixtureimg = new CogImage8Grey();
                                    //cam2_fixtureimg = CAM2_Fixturing_Run();
                                    Fixture.Run(m_imgSource_Mono, PMAlign.Tool.Results[0].GetPose(), out FixtureSource2);

                                    
                                    CVisionTools.FIXTURE_CAM2.Origin_Translation_X = PMAlign.Tool.Results[i].GetPose().TranslationX;
                                    CVisionTools.FIXTURE_CAM2.Origin_Translation_Y = PMAlign.Tool.Results[i].GetPose().TranslationY;
                                }
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnCam1_QrCode_SearchRoi_Click(object sender, EventArgs e)
        {
            try
            {
                CCogTool_ID ID = CVisionTools.ID_CAM1;
                ID.Tool.RunParams.ProcessingMode = Cognex.VisionPro.ID.CogIDProcessingModeConstants.IDQuick;
                ID.Tool.RunParams.DisableAllCodes();
                ID.Tool.RunParams.QRCode.Enabled = true;

                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();

                if (ID.Tool.Region == null) ID.Tool.Region = new CogRectangle();

                CogRectangle cogTrainRegion = (CogRectangle)ID.Tool.Region;
                cogTrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                cogTrainRegion.Interactive = true;
                cogDisplay_Source.InteractiveGraphics.Add(cogTrainRegion, "Search", false);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnCam2_QrCode_SearchRoi_Click(object sender, EventArgs e)
        {
            try
            {
                CCogTool_ID ID = CVisionTools.ID_CAM2;

                ID.Tool.RunParams.ProcessingMode = Cognex.VisionPro.ID.CogIDProcessingModeConstants.IDQuick;
                ID.Tool.RunParams.DisableAllCodes();
                ID.Tool.RunParams.QRCode.Enabled = true;

                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();

                if (ID.Tool.Region == null) ID.Tool.Region = new CogRectangle();

                CogRectangle cogTrainRegion = (CogRectangle)ID.Tool.Region;
                cogTrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                cogTrainRegion.Interactive = true;
                cogDisplay_Source.InteractiveGraphics.Add(cogTrainRegion, "Search", false);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnCam1_QrCode_Read_Click(object sender, EventArgs e)
        {
            try
            {
                CCogTool_ID ID = CVisionTools.ID_CAM1;

                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();

                ID.Tool.RunParams.QRCode.Enabled = true;
                //ID.Tool.RunParams.DataMatrix.Enabled = true;
                ID.Tool.InputImage = m_imgSource_Mono;
                ID.Tool.Run();

                if (ID.Tool.Results == null) return;

                if (ID.Tool.Results.Count > 0)
                {
                    lbCam1_QrCode.Text = ID.Tool.Results[0].DecodedData.DecodedString;
                    cogDisplay_Source.StaticGraphics.Add(ID.Tool.Results[0].CreateResultGraphics(Cognex.VisionPro.ID.CogIDResultGraphicConstants.All), "RESULT");
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnCam2_QrCode_Read_Click(object sender, EventArgs e)
        {
            try
            {
                CCogTool_ID ID = CVisionTools.ID_CAM2;

                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();

                ID.Tool.InputImage = m_imgSource_Mono;
                ID.Tool.Run();

                if (ID.Tool.Results == null) return;

                if (ID.Tool.Results.Count > 0)
                {
                    lbCam2_QrCode.Text = ID.Tool.Results[0].DecodedData.DecodedString;
                    cogDisplay_Source.StaticGraphics.Add(ID.Tool.Results[0].CreateResultGraphics(Cognex.VisionPro.ID.CogIDResultGraphicConstants.All), "RESULT");
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                CVisionTools.Pattern_Run_All(cbCamera.SelectedIndex, m_imgSource_Color, m_imgSource_Mono, cogDisplay_Source);
                CVisionTools.Blob_Run_All(cbCamera.SelectedIndex, m_imgSource_Color, m_imgSource_Mono, cogDisplay_Source);
                GC.Collect();

            }
            catch
            {

            }
        }

        private void btnPMAlignToolDel_Click(object sender, EventArgs e)
        {
            try
            {
                int camindex = cbCamera.SelectedIndex;
                if (gridJobs.SelectedRows.Count > 0)
                {
                    int nRowIndex = gridJobs.SelectedRows[0].Index;


                    if (camindex == 0)
                    {
                        CVisionTools.Jobs.RemoveAt(nRowIndex);
                    }
                    else
                    {
                        CVisionTools.Jobs2.RemoveAt(nRowIndex);
                    }

                }

                //UpdateJob();
                UpdateJob(camindex);

                if (gridJobs.SelectedRows.Count == 0)
                {
                    return;
                }

                gridJobs.Rows[gridJobs.SelectedRows[0].Index + 1].Selected = true;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

        }

        private void btnON_Click(object sender, EventArgs e)
        {
            Global.Device.IMAGEFOCUS_LIGHT.AllOn();

            for (int i = 0; i < Global.Device.IMAGEFOCUS_LIGHT.ChannelCount; i++)
            {
                Global.Device.IMAGEFOCUS_LIGHT.SetValue(i, 254);
            }

        }

        private bool UseCross = false;

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            // 크로스라인 드로우
            try
            {
                if (Global.Device.Cameras.Count > 0)
                {
                    if (UseCross)
                    {
                        if (cogDisplay_Source.Image == null) return;
                        CogLineSegment Hori = new CogLineSegment();
                        Hori.Color = CogColorConstants.Yellow;
                        Hori.StartX = 0;
                        Hori.StartY = cogDisplay_Source.Image.Height / 2;
                        Hori.EndX = cogDisplay_Source.Image.Width;
                        Hori.EndY = cogDisplay_Source.Image.Height / 2;

                        CogLineSegment Verti = new CogLineSegment();
                        Verti.Color = CogColorConstants.Yellow;
                        Verti.StartX = cogDisplay_Source.Image.Width / 2;
                        Verti.StartY = 0;
                        Verti.EndX = cogDisplay_Source.Image.Width / 2;
                        Verti.EndY = cogDisplay_Source.Image.Height;

                        cogDisplay_Source.InteractiveGraphics.Add(Hori, "Hori", false);
                        cogDisplay_Source.InteractiveGraphics.Add(Verti, "Verti", false);
                    }
                    else
                    {
                        //cogDisplay_Source.InteractiveGraphics.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnOFF_Click(object sender, EventArgs e)
        {
            Global.Device.IMAGEFOCUS_LIGHT.AllOff();
        }

        private void btnGrabSeqAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string str_Name = tbJobName.Text;
                int nLightValue = int.Parse(lbLightValue.Text);
                int nIndex = int.Parse(cbImageIndex.Text);
                int Camindex = cbCamera.SelectedIndex;

                int Exposure = (int)nbCamExposure.Value;
                int Gain = (int)nbCamGain.Value;

                //GRAB_SEQ grab_seq = new GRAB_SEQ();

                JOB_SEQ grab_seq = new JOB_SEQ();

                grab_seq.LightValue = nLightValue;
                grab_seq.Exposure = Exposure;
                grab_seq.Gain = Gain;
                //grab_seq.m_imgSource_Color = m_imgSource_Color; 이미지는 그랩 하고나서 리스트에 하나씩 추가


                if (Camindex == 0)
                {
                    //// 동일한 이름이 있는지 확인
                    //for (int i = 0; i < CVisionTools.Grab_seq.Count; i++)
                    //{
                    //    if (string.Equals(CVisionTools.Grab_seq[i].Name, grab_seq.Name, StringComparison.OrdinalIgnoreCase))
                    //    {
                    //        CUtil.ShowMessageBox("NOTICE", "SEQ NAME ALREADY EXISTS");
                    //        return;
                    //    }
                    //}

                    CVisionTools.Grab_seq.Add(grab_seq);

                    UpdateGrabSeq(Camindex);

                    //제일 마지막 행을 선택되도록 함
                    gridSeq.Rows[CVisionTools.Grab_seq.Count - 1].Selected = true;
                    gridSeq.Rows[CVisionTools.Grab_seq.Count - 1].Cells[0].Selected = true;
                }
                else
                {
                    //// 동일한 이름이 있는지 확인
                    //for (int i = 0; i < CVisionTools.Grab_seq2.Count; i++)
                    //{
                    //    if (string.Equals(CVisionTools.Grab_seq2[i].Name, grab_seq.Name, StringComparison.OrdinalIgnoreCase))
                    //    {
                    //        CUtil.ShowMessageBox("NOTICE", "SEQ NAME ALREADY EXISTS");
                    //        return;
                    //    }
                    //}

                    CVisionTools.Grab_seq2.Add(grab_seq);

                    UpdateGrabSeq(Camindex);

                    //제일 마지막 행을 선택되도록 함
                    gridSeq.Rows[CVisionTools.Grab_seq2.Count - 1].Selected = true;
                    gridSeq.Rows[CVisionTools.Grab_seq2.Count - 1].Cells[0].Selected = true;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btmGrabSeqApply_Click(object sender, EventArgs e)
        {
            try
            {
                string str_Name = tbJobName.Text;
                int nLightValue = int.Parse(lbLightValue.Text);
                int nIndex = int.Parse(cbImageIndex.Text);

                int Exposure = (int)nbCamExposure.Value;
                int Gain = (int)nbCamGain.Value;

                int nRowIndex = nSelect_Seq_Index;
                int Camindex = cbCamera.SelectedIndex;


                if (gridSeq.SelectedRows.Count > 0)
                {


                    //GRAB_SEQ grab = new GRAB_SEQ();
                    JOB_SEQ grab = new JOB_SEQ();

                    grab.LightValue = nLightValue;
                   
                    grab.Exposure = Exposure;
                    grab.Gain = Gain;

                    if (cbCamera.SelectedIndex == 0)
                    {
                        if (CVisionTools.Grab_seq.Count == 0) return;

                        CVisionTools.Grab_seq.RemoveAt(nRowIndex);
                        CVisionTools.Grab_seq.Insert(nRowIndex, grab);
                    }
                    else
                    {
                        if (CVisionTools.Grab_seq2.Count == 0) return;
                        CVisionTools.Grab_seq2.RemoveAt(nRowIndex);
                        CVisionTools.Grab_seq2.Insert(nRowIndex, grab);
                    }

                    gridSeq.SelectedRows[0].SetValues(new object[] { nLightValue, Exposure, Gain });



                }

                //int nCamIndex = 
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnGrabSeqDelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridSeq.SelectedRows.Count > 0)
                {
                    int nRowIndex = gridSeq.SelectedRows[0].Index;

                    if (cbCamera.SelectedIndex == 0)
                    {
                        CVisionTools.Grab_seq.RemoveAt(nRowIndex); //
                    }
                    else
                    {
                        CVisionTools.Grab_seq2.RemoveAt(nRowIndex); //
                    }

                }

                //UpdateGrabSeq();
                UpdateGrabSeq(cbCamera.SelectedIndex);

                if (gridSeq.SelectedRows.Count == 0) return;

                gridSeq.Rows[gridSeq.SelectedRows[0].Index + 1].Selected = true;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

        }

        private void gridSeq_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                nSelect_Seq_Index = e.RowIndex;
                //string str_No = gridSeq.Rows[e.RowIndex].Cells[0].Value.ToString();
                //string str_Name = gridSeq.Rows[e.RowIndex].Cells[1].Value.ToString();
                string str_LightValue = gridSeq.Rows[e.RowIndex].Cells[0].Value.ToString();
                string str_Exposure = gridSeq.Rows[e.RowIndex].Cells[1].Value.ToString();
                string str_Gain = gridSeq.Rows[e.RowIndex].Cells[2].Value.ToString();
                string USE = gridSeq.Rows[e.RowIndex].Cells[3].Value.ToString();
                //cbImageIndex.Text = str_No;
                //tbGrabSeqName.Text = str_Name;
                lbLightValue.Text = str_LightValue;
                if(str_LightValue == "0")
                {
                    str_LightValue = "1";
                }
                trbLightValue.Value = int.Parse(str_LightValue);
                chk_GrabSeqUSE.Checked = bool.Parse(USE);

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
                Global.Device.IMAGEFOCUS_LIGHT.SetValue(nChannel, nLightValue);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

        }

        private void btnGrabSeq_Click(object sender, EventArgs e)
        {
            try
            {
                cogDisplay_Source.Image = null;
                lst_imgSource_Color.Clear();
                lst_imgSource_Mono.Clear();

                Global.Device.Cameras[cbCamera.SelectedIndex].SetExposure(Global.Device.Cameras[cbCamera.SelectedIndex].Property.EXPOSURETIME_US);
                Global.Device.Cameras[cbCamera.SelectedIndex].SetGain(Global.Device.Cameras[cbCamera.SelectedIndex].Property.GAIN);

                //if (cbCamera.SelectedIndex == 0)
                //{
                //    CVisionTools.tmp_seq = CVisionTools.Grab_seq;
                //}
                //else
                //{
                //    CVisionTools.tmp_seq = CVisionTools.Grab_seq2;
                //}

                //for (int i = 0; i < CVisionTools.tmp_seq.Count; i++)
                //{
                //    for (int j = 0; j < Global.iDevice.IMAGEFOCUS_LIGHT.ChannelCount; j++)
                //    {
                //        Global.iDevice.IMAGEFOCUS_LIGHT.SetValue(j+1, CVisionTools.tmp_seq[i].LightValue);
                //    }
                //    Global.iDevice.Cameras[cbCamera.SelectedIndex].SetExposure(CVisionTools.tmp_seq[i].Exposure);
                //    Global.iDevice.Cameras[cbCamera.SelectedIndex].SetGain(CVisionTools.tmp_seq[i].Gain);
                //    //Global.iDevice.Cameras[cbCamera.SelectedIndex].Live(false);
                //    Global.iDevice.Cameras[cbCamera.SelectedIndex].Grab(false);
                //    Global.iDevice.Cameras[cbCamera.SelectedIndex].IsGrabDone.WaitOne();


                Task.Run(() => Global.Device.Cameras[0].CycleGrab());

                bool bGrabDone = Global.Device.Cameras[0].IsGrabDone.WaitOne(100);
                bGrabDone &= Global.Device.Cameras[1].IsGrabDone.WaitOne(100);

                if (bGrabDone)
                {

                }
                else
                {
                    //continue;
                }


                //}


                //cogDisplay_Source.Image = lst_imgSource_Color[0];
                //cogDisplay1.Image = lst_imgSource_Color[1];
                //cogDisplay2.Image = lst_imgSource_Color[2];
                //////for(int j = 0; j < lst_imgSource_Color.Count; j++)
                ////{
                ////    cogDisplay_Source.Image = lst_imgSource_Color[j];
                ////}
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

        }

        private void btnCameraParameterSave_Click(object sender, EventArgs e)
        {
            Global.Device.Cameras[cbCamera.SelectedIndex].Property.EXPOSURETIME_US = (int)nbCamExposure.Value;
            Global.Device.Cameras[cbCamera.SelectedIndex].Property.GAIN = (int)nbCamGain.Value;

            Global.Device.Cameras[cbCamera.SelectedIndex].Property.SaveConfig();
        }

        private void btnOriginalImage_Click(object sender, EventArgs e)
        {
            if (cogDisplay_Source.Image == null) return;
            cogDisplay_Source.Image = m_imgSource_Color.ScaleImage(cogDisplay_Source.Image.Width, cogDisplay_Source.Image.Height);

            cogDisplay_Source.InteractiveGraphics.Clear();
            cogDisplay_Source.StaticGraphics.Clear();
        }

        private void btnBlobAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int nThreshold = trbThreshold.Value;
                string str_Name = tbBlobName.Text;
                int nAreaMin = int.Parse(tbAreaMin.Text);
                int nAreaMax = int.Parse(tbAreaMax.Text);
                int nMasterCount = int.Parse(tbBlobMasterCount.Text);
                int nIndex = cbCamera.SelectedIndex;
                bool bInspectionUse = chk_BlobUse.Checked;

                if (!m_imgSource_Mono.Allocated) { MessageBox.Show("NEED IMAGE"); return; }

                if (nIndex == 0)
                {

                    JOB_BLOB job_blob = new JOB_BLOB($"JOB_{CVisionTools.Blobs.Count.ToString()}");
                    job_blob.Defect_Name = str_Name;
                    job_blob.Defect_Threshold = nThreshold;
                    job_blob.Defect_Min = nAreaMin;
                    job_blob.Defect_Max = nAreaMax;
                    job_blob.Defect_MasterCount = nMasterCount;

                    job_blob.InspectionUse = bInspectionUse;

                    job_blob.BLOB.Tool.RunParams.ConnectivityMinPixels = nAreaMin;
                    job_blob.BLOB.Tool.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
                    job_blob.BLOB.Tool.RunParams.SegmentationParams.HardFixedThreshold = nThreshold;



                    //동일한 이름이 있는지 확인
                    for (int i = 0; i < CVisionTools.Blobs.Count; i++)
                    {
                        if (string.Equals(CVisionTools.Blobs[i].Defect_Name, job_blob.Defect_Name, StringComparison.OrdinalIgnoreCase))
                        {
                            CUtil.ShowMessageBox("NOTICE", "BLOB NAME ALREADY EXISTS");
                            return;
                        }
                    }

                    CVisionTools.Blobs.Add(job_blob);

                    m_SeletedBlob = job_blob;

                    CCogTool_Blob cCogTool_Blob = CVisionTools.BLOB_CAM1;

                    propertyGrid_Blob.SelectedObject = m_SeletedBlob.BLOB.Tool.RunParams;

                    //UpdateBlob();
                    UpdateBlob(cbCamera.SelectedIndex);

                    //제일 마지막 행을 선택되도록 함
                    gridBlob.Rows[CVisionTools.Blobs.Count - 1].Selected = true;
                    gridBlob.Rows[CVisionTools.Blobs.Count - 1].Cells[0].Selected = true;
                }
                else
                {
                    JOB_BLOB job_blob = new JOB_BLOB($"JOB_{CVisionTools.Blobs2.Count.ToString()}");
                    job_blob.Defect_Name = str_Name;
                    job_blob.Defect_Threshold = nThreshold;
                    job_blob.Defect_Min = nAreaMin;
                    job_blob.Defect_Max = nAreaMax;
                    job_blob.Defect_MasterCount = nMasterCount;

                    job_blob.InspectionUse = bInspectionUse;

                    job_blob.BLOB.Tool.RunParams.ConnectivityMinPixels = nAreaMin;
                    job_blob.BLOB.Tool.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
                    job_blob.BLOB.Tool.RunParams.SegmentationParams.HardFixedThreshold = nThreshold;

                    //동일한 이름이 있는지 확인
                    for (int i = 0; i < CVisionTools.Blobs2.Count; i++)
                    {
                        if (string.Equals(CVisionTools.Blobs2[i].Defect_Name, job_blob.Defect_Name, StringComparison.OrdinalIgnoreCase))
                        {
                            CUtil.ShowMessageBox("NOTICE", "BLOB NAME ALREADY EXISTS");
                            return;
                        }
                    }

                    CVisionTools.Blobs2.Add(job_blob);

                    m_SeletedBlob = job_blob;

                    CCogTool_Blob cCogTool_Blob = CVisionTools.BLOB_CAM2;

                    propertyGrid_Blob.SelectedObject = m_SeletedBlob.BLOB.Tool.RunParams;

                    // UpdateBlob();
                    UpdateBlob(cbCamera.SelectedIndex);

                    //제일 마지막 행을 선택되도록 함
                    gridBlob.Rows[CVisionTools.Blobs2.Count - 1].Selected = true;
                    gridBlob.Rows[CVisionTools.Blobs2.Count - 1].Cells[0].Selected = true;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnBlobApply_Click(object sender, EventArgs e)
        {
            try
            {
                int nThreshold = trbThreshold.Value;
                string str_Name = tbBlobName.Text;
                int nAreaMin = int.Parse(tbAreaMin.Text);
                int nAreaMax = int.Parse(tbAreaMax.Text);
                int nMasterCount = int.Parse(tbBlobMasterCount.Text);

                bool bInspectionUse = chk_BlobUse.Checked;

                int nCamIndex = cbCamera.SelectedIndex;
                int nIndex = nSelect_Blob_Index;

                if (m_SeletedBlob == null)
                {
                    CUtil.ShowMessageBox("Alram", "Select INSPECTION");
                    return;
                }

                if (gridBlob.SelectedRows.Count > 0)
                {
                    m_SeletedBlob.Defect_Name = str_Name;
                    m_SeletedBlob.Defect_Min = nAreaMin;
                    m_SeletedBlob.Defect_MasterCount = nMasterCount;
                    m_SeletedBlob.BLOB.Tool.RunParams.ConnectivityMinPixels = nAreaMin;
                    m_SeletedBlob.Defect_Max = nAreaMax;
                    m_SeletedBlob.Defect_Threshold = nThreshold;
                    m_SeletedBlob.InspectionUse = bInspectionUse;

                    if (cbCamera.SelectedIndex == 0)
                    {
                        CVisionTools.Blobs.RemoveAt(nIndex);
                        CVisionTools.Blobs.Insert(nIndex, m_SeletedBlob);
                    }
                    else
                    {
                        CVisionTools.Blobs2.RemoveAt(nIndex);
                        CVisionTools.Blobs2.Insert(nIndex, m_SeletedBlob);
                    }



                    gridBlob.SelectedRows[0].SetValues(new object[] { m_SeletedBlob.Defect_Name, m_SeletedBlob.Defect_MasterCount, m_SeletedBlob.Defect_Threshold, m_SeletedBlob.Defect_Min, m_SeletedBlob.Defect_Max, m_SeletedBlob.InspectionUse.ToString() });
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

        }

        private void btnBlobDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int camindex = cbCamera.SelectedIndex;
                if (gridBlob.SelectedRows.Count > 0)
                {
                    int nRowIndex = gridBlob.SelectedRows[0].Index;

                    if (camindex == 0)
                    {
                        CVisionTools.Blobs.RemoveAt(nRowIndex);
                    }
                    else
                    {
                        CVisionTools.Blobs2.RemoveAt(nRowIndex);
                    }

                }

                //UpdateBlob();
                UpdateBlob(camindex);

                if (gridBlob.SelectedRows.Count == 0)
                {
                    return;
                }

                gridBlob.Rows[gridBlob.SelectedRows[0].Index + 1].Selected = true;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnBlobRoi_Click_1(object sender, EventArgs e)
        {

            try
            {
                int nIndex = nSelect_Blob_Index;

                if (!m_imgSource_Mono.Allocated)
                {
                    MessageBox.Show("Nothing Image, Please Grab");
                    return;
                }

                if (cbCamera.SelectedIndex == 0)
                {
                    CVisionTools.Blobs[nIndex].BLOB.New_RectangleROI(cogDisplay_Source, m_imgSource_Mono);
                }
                else
                {
                    CVisionTools.Blobs2[nIndex].BLOB.New_RectangleROI(cogDisplay_Source, m_imgSource_Mono);
                }



            }
            catch (Exception ex)
            {

                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }



        }

        private void gridBlob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();

                nSelect_Blob_Index = e.RowIndex;

                if (gridBlob.SelectedRows.Count > 0)
                {
                    int nIndex = gridBlob.SelectedRows[0].Index;

                    if (cbCamera.SelectedIndex == 0)
                    {
                        m_SeletedBlob = CVisionTools.Blobs[nIndex];
                    }
                    else
                    {
                        m_SeletedBlob = CVisionTools.Blobs2[nIndex];
                    }


                    tbBlobName.Text = m_SeletedBlob.Defect_Name;
                    tbBlobMasterCount.Text = m_SeletedBlob.Defect_MasterCount.ToString();
                    
                    tbAreaMin.Text = m_SeletedBlob.Defect_Min.ToString();
                    tbAreaMax.Text = m_SeletedBlob.Defect_Max.ToString();

                    trbThreshold.Text = m_SeletedBlob.Defect_Threshold.ToString();
                    trbThreshold.Value = m_SeletedBlob.Defect_Threshold;
                    lbThreshold.Text = m_SeletedBlob.Defect_Threshold.ToString();

                    chk_BlobUse.Checked = m_SeletedBlob.InspectionUse;


                    //if(propertyGrid_Blob.SelectedObject == null) return;
                    propertyGrid_Blob.SelectedObject = m_SeletedBlob.BLOB.Tool.RunParams;
                }

                // UI 디스플레이
                if (cogDisplay_Source.Image == null || cogDisplay_Source.Image.Allocated == false) return; // 이미지가 없으면 ROI를 그려주지않음

                if (cbCamera.SelectedIndex == 0)
                {
                    if (CVisionTools.Blobs.Count == 0) return;
                    if (CVisionTools.Blobs[nSelect_Blob_Index].BLOB.Tool.Region == null) return;

                    cogDisplay_Source.InteractiveGraphics.Add((CogRectangle)CVisionTools.Blobs[nSelect_Blob_Index].BLOB.Tool.Region, "ROI", false);
                }
                else
                {
                    if (CVisionTools.Blobs2.Count == 0) return;
                    if (CVisionTools.Blobs2[nSelect_Blob_Index].BLOB.Tool.Region == null) return;

                    cogDisplay_Source.InteractiveGraphics.Add((CogRectangle)CVisionTools.Blobs2[nSelect_Blob_Index].BLOB.Tool.Region, "ROI", false);
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnInsp_Click(object sender, EventArgs e)
        {
            cogDisplay_Source.StaticGraphics.Clear();
            cogDisplay_Source.InteractiveGraphics.Clear();

            CogRectangle OriginRectangle = new CogRectangle();
            CogRectangle MoveRectangle = new CogRectangle();
            double tmpX = new double();
            double tmpY = new double();

            int nIndex = nSelect_Blob_Index;

            try
            {
                int START_TIME = Environment.TickCount;

                int nCamIndex = cbCamera.SelectedIndex;
                

                CCogTool_Blob job_blob = null;
                CogGraphicCollection cogList = new CogGraphicCollection();

                

                if (nCamIndex == 0)
                {
                    if (CVisionTools.Blobs.Count == 0) return;
                    CVisionTools.tmpblob = CVisionTools.Blobs;
                    job_blob = CVisionTools.Blobs[nIndex].BLOB;
                    //job_blob.Tool.RunParams.SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.LightBlobs;
                    //job_blob.Run(m_imgSource_Mono, (int)CVisionTools.Blobs[nIndex].Defect_Threshold, CVisionTools.Blobs[nIndex].Defect_Min, CVisionTools.Blobs[nIndex].Defect_Max);
                }
                else
                {
                    if (CVisionTools.Blobs2.Count == 0) return;
                    CVisionTools.tmpblob = CVisionTools.Blobs2;
                    job_blob = CVisionTools.Blobs2[nIndex].BLOB;
                    //job_blob.Tool.RunParams.SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.LightBlobs;
                    //job_blob.Run(m_imgSource_Mono, (int)CVisionTools.Blobs2[nIndex].Defect_Threshold, CVisionTools.Blobs2[nIndex].Defect_Min, CVisionTools.Blobs2[nIndex].Defect_Max);
                }


                //Region Offset
                (tmpX, tmpY) = CVisionTools.RegionOffSet(cbCamera.SelectedIndex, cogDisplay_Source, m_imgSource_Mono);
                (OriginRectangle, MoveRectangle) = CVisionTools.RegionRect(CVisionTools.tmpblob[nIndex].BLOB.Tool.Region, tmpX, tmpY);
                CVisionTools.tmpblob[nIndex].BLOB.Tool.Region = MoveRectangle;


                job_blob.Tool.RunParams.SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.LightBlobs;
                job_blob.Run(m_imgSource_Mono, (int)CVisionTools.tmpblob[nIndex].Defect_Threshold, CVisionTools.tmpblob[nIndex].Defect_Min, CVisionTools.tmpblob[nIndex].Defect_Max);

                CogBlobResults Result = job_blob.Tool.Results;

                int nCount = Result.GetBlobs().Count;

                //찾은 블랍
                if (nCount > 0)
                {
                    // 찾은영역 결과 텍스트 표시
                    CogBlobResult result = Result.GetBlobs()[0];
                    tbReusltfArea.Text = result.Area.ToString();

                    for (int i = 0; i < nCount; i++)
                    {
                        CogBlobResult blob = Result.GetBlobs()[i];


                        if (blob.Area > CVisionTools.tmpblob[nIndex].Defect_Min && blob.Area < CVisionTools.tmpblob[nIndex].Defect_Max)
                        {
                            cogList.Add(blob.GetBoundingBox(CogBlobAxisConstants.PixelAligned));
                            cogList.Add(blob.CreateResultGraphics(CogBlobResultGraphicConstants.Boundary));

                            CogGraphicLabel lbBlob_Area = new CogGraphicLabel();
                            CogGraphicLabel lbBlob_Width = new CogGraphicLabel();
                            CogGraphicLabel lbBlob_Height = new CogGraphicLabel();

                            lbBlob_Area.Color = CogColorConstants.Green;
                            lbBlob_Width.Color = CogColorConstants.Green;
                            lbBlob_Height.Color = CogColorConstants.Green;

                            ////Set X-position to 100
                            lbBlob_Area.X = blob.CenterOfMassX;
                            lbBlob_Area.Y = blob.CenterOfMassY;

                            lbBlob_Width.X = blob.CenterOfMassX;
                            lbBlob_Width.Y = blob.CenterOfMassY + 2;

                            lbBlob_Height.X = blob.CenterOfMassX;
                            lbBlob_Height.Y = blob.CenterOfMassY + 4;

                            CogRectangle rtBounding = blob.GetBoundingBox(CogBlobAxisConstants.Principal).EnclosingRectangle(CogCopyShapeConstants.All);

                            double dWidth = rtBounding.Width * 0.0093D;
                            double dHeight = rtBounding.Height * 0.0093D;

                            string str_Area = string.Format("AREA(PX) : {0}", blob.Area.ToString("F1"));
                            string str_Width = string.Format("WIDTH : {0}mm", dWidth.ToString("F2"));
                            string str_Height = string.Format("HEIGHT : {0}mm", dHeight.ToString("F2"));

                            lbBlob_Area.Text = str_Area;
                            lbBlob_Width.Text = str_Width;
                            lbBlob_Height.Text = str_Height;

                            lbBlob_Area.Font = new Font("arial", 11);
                            lbBlob_Width.Font = new Font("arial", 11);
                            lbBlob_Height.Font = new Font("arial", 11);
                            cogList.Add(lbBlob_Area);
                            cogList.Add(lbBlob_Width);
                            cogList.Add(lbBlob_Height);
                        }
                        else
                        {
                            CogGraphicLabel lbBlob = new CogGraphicLabel();
                            CogRectangle rt = new CogRectangle();
                            //rt =  as CogRectangleAffine;
                            rt = job_blob.Tool.Region as CogRectangle;

                            lbBlob.Color = CogColorConstants.Red;
                            lbBlob.X = rt.CenterX;
                            lbBlob.Y = rt.CenterY;
                            lbBlob.Text = "N/A";
                            lbBlob.Font = new Font("arial", 24);
                            cogList.Add(lbBlob);
                        }

                    }

                }
                else
                {

                    CogGraphicLabel lbBlob = new CogGraphicLabel();
                    CogRectangle rt = new CogRectangle();
                    //rt =  as CogRectangleAffine;
                    rt = job_blob.Tool.Region as CogRectangle;

                    lbBlob.Color = CogColorConstants.Red;
                    lbBlob.X = rt.CenterX;
                    lbBlob.Y = rt.CenterY;
                    lbBlob.Text = "N/A";
                    lbBlob.Font = new Font("arial", 10);
                    cogList.Add(lbBlob);

                }

                cogDisplay_Source.StaticGraphics.AddList(cogList, "RESULT");
                int END_TIME = Environment.TickCount - START_TIME;
                lbTaktTimems.Text = $"Tack Time : {END_TIME}ms";


                CVisionTools.tmpblob[nIndex].BLOB.Tool.Region = OriginRectangle;
               
            }
            catch (Exception ex)
            {
                CVisionTools.tmpblob[nIndex].BLOB.Tool.Region = OriginRectangle;
                
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnBlobRunAll_Click(object sender, EventArgs e)
        {
            CogRectangle OriginRectangle = new CogRectangle();
            CogRectangle MoveRectangle = new CogRectangle();
            double tmpX = new double();
            double tmpY = new double();

            try
            {
                int START_TIME = Environment.TickCount;

                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();
                CogGraphicCollection cogList = new CogGraphicCollection();

                if (cbCamera.SelectedIndex == 0)
                {
                    CVisionTools.tmpblob = CVisionTools.Blobs;
                }
                else
                {
                    CVisionTools.tmpblob = CVisionTools.Blobs2;
                }



                for (int i = 0; i < CVisionTools.tmpblob.Count; i++)
                {
                    CogBlobTool BlobTool = CVisionTools.tmpblob[i].BLOB.Tool;

                    if (CVisionTools.tmpblob[i].InspectionUse)
                    {

                        if (cbCamera.SelectedIndex == 0)
                        {
                            BlobTool.InputImage = m_imgSource_Mono;
                        }
                        else
                        {
                            BlobTool.InputImage = m_imgSource_Mono;
                        }

                        //Region Offset
                        (tmpX, tmpY) = CVisionTools.RegionOffSet(cbCamera.SelectedIndex, cogDisplay_Source, m_imgSource_Mono);
                        (OriginRectangle, MoveRectangle) = CVisionTools.RegionRect(BlobTool.Region, tmpX, tmpY);
                        BlobTool.Region = MoveRectangle;


                        BlobTool.Run();

                        if (BlobTool.Results != null)
                        {
                            if (BlobTool.Region != null) cogList.Add((ICogGraphic)BlobTool.Region);

                            CogBlobResults Result = BlobTool.Results;

                            int nCount = Result.GetBlobs().Count;

                            tbBlobCount.Text = nCount.ToString();

                            if (nCount > 0)
                            {
                                for (int j = 0; j < nCount; j++)
                                {
                                    CogBlobResult blob = Result.GetBlobs()[j];


                                    if (blob.Area > CVisionTools.tmpblob[i].Defect_Min && blob.Area < CVisionTools.tmpblob[i].Defect_Max)
                                    {
                                        cogList.Add(blob.GetBoundingBox(CogBlobAxisConstants.PixelAligned));
                                        cogList.Add(blob.CreateResultGraphics(CogBlobResultGraphicConstants.Boundary));

                                        CogGraphicLabel lbBlob_Area = new CogGraphicLabel();
                                        CogGraphicLabel lbBlob_Width = new CogGraphicLabel();
                                        CogGraphicLabel lbBlob_Height = new CogGraphicLabel();

                                        lbBlob_Area.Color = CogColorConstants.Green;
                                        lbBlob_Width.Color = CogColorConstants.Green;
                                        lbBlob_Height.Color = CogColorConstants.Green;

                                        ////Set X-position to 100
                                        lbBlob_Area.X = blob.CenterOfMassX;
                                        lbBlob_Area.Y = blob.CenterOfMassY;

                                        lbBlob_Width.X = blob.CenterOfMassX;
                                        lbBlob_Width.Y = blob.CenterOfMassY + 2;

                                        lbBlob_Height.X = blob.CenterOfMassX;
                                        lbBlob_Height.Y = blob.CenterOfMassY + 4;

                                        CogRectangle rtBounding = blob.GetBoundingBox(CogBlobAxisConstants.Principal).EnclosingRectangle(CogCopyShapeConstants.All);

                                        double dWidth = rtBounding.Width * 0.0093D;
                                        double dHeight = rtBounding.Height * 0.0093D;

                                        string str_Area = string.Format("AREA(PX) : {0}", blob.Area.ToString("F1"));
                                        string str_Width = string.Format("WIDTH : {0}mm", dWidth.ToString("F2"));
                                        string str_Height = string.Format("HEIGHT : {0}mm", dHeight.ToString("F2"));

                                        lbBlob_Area.Text = str_Area;
                                        lbBlob_Width.Text = str_Width;
                                        lbBlob_Height.Text = str_Height;

                                        lbBlob_Area.Font = new Font("arial", 11);
                                        lbBlob_Width.Font = new Font("arial", 11);
                                        lbBlob_Height.Font = new Font("arial", 11);
                                        cogList.Add(lbBlob_Area);
                                        cogList.Add(lbBlob_Width);
                                        cogList.Add(lbBlob_Height);
                                    }
                                    else
                                    {
                                        CogGraphicLabel lbBlob = new CogGraphicLabel();
                                        CogRectangle rt = new CogRectangle();
                                        //rt =  as CogRectangleAffine;
                                        rt = BlobTool.Region as CogRectangle;

                                        lbBlob.Color = CogColorConstants.Red;
                                        lbBlob.X = rt.CenterX;
                                        lbBlob.Y = rt.CenterY;
                                        lbBlob.Text = "N/A";
                                        lbBlob.Font = new Font("arial", 24);
                                        cogList.Add(lbBlob);
                                        //cogDisplay_Source.StaticGraphics.Add(lbBlob, "RESULT");
                                    }

                                }
                            }
                            else
                            {
                                CogGraphicLabel lbBlob = new CogGraphicLabel();
                                CogRectangle rt = new CogRectangle();
                                //rt =  as CogRectangleAffine;
                                rt = BlobTool.Region as CogRectangle;

                                lbBlob.Color = CogColorConstants.Red;
                                lbBlob.X = rt.CenterX;
                                lbBlob.Y = rt.CenterY;
                                lbBlob.Text = "N/A";
                                lbBlob.Font = new Font("arial", 24);
                                cogList.Add(lbBlob);
                                //cogDisplay_Source.StaticGraphics.Add(lbBlob, "RESULT");
                            }

                        }
                        else
                        {
                            CogGraphicLabel lbBlob = new CogGraphicLabel();
                            CogRectangle rt = new CogRectangle();
                            //rt =  as CogRectangleAffine;
                            rt = BlobTool.Region as CogRectangle;

                            lbBlob.Color = CogColorConstants.Red;
                            lbBlob.X = rt.CenterX;
                            lbBlob.Y = rt.CenterY;
                            lbBlob.Text = "N/A";
                            lbBlob.Font = new Font("arial", 24);
                            cogList.Add(lbBlob);
                        }
                    }
                    else //검사 미사용
                    {

                    }

                    BlobTool.Region = OriginRectangle;

                }

                cogDisplay_Source.StaticGraphics.AddList(cogList, "RESULT");

                int END_TIME = Environment.TickCount - START_TIME;
                lbTaktTimems.Text = $"Tack Time : {END_TIME}ms";

               

            }
            catch (Exception ex)
            {
                
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void gridSeq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMasterImageSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strRecipe = IGlobal.Instance.System.Recipe.Name;
                string strSubRecipe = IGlobal.Instance.System.Recipe.SubName;

                if (!m_imgSource_Color.Allocated)
                {
                    CUtil.ShowMessageBox("NO IMAGE", "Please proceed with Grab");
                    return;
                }

                string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipe}\\SubRECIPE\\{strSubRecipe}\\";

                string filePath = "";
                int nCamIndex = cbCamera.SelectedIndex + 1;
                if (!System.IO.Directory.Exists(strPath))
                {
                    System.IO.Directory.CreateDirectory(strPath);
                }

                if (CUtil.ShowMessageBox("SAVE", "Do you want to Master Image save?", FormMessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {


                    if (m_imgSource_Color.Allocated)
                    {
                        filePath = strPath + $"MasterImage_CamNum_{nCamIndex}" + ".bmp";
                        Common.SaveImageFileToBMP(m_imgSource_Color, filePath);
                    }

                    CUtil.ShowMessageBox("SAVE", "The Master image has been saved.");
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

        }

        private void btnMasterImageLoad_Click(object sender, EventArgs e)
        {
            cogDisplay_Source.StaticGraphics.Clear();
            cogDisplay_Source.InteractiveGraphics.Clear();

            try
            {
                string strRecipe = IGlobal.Instance.System.Recipe.Name;
                string strSubRecipe = IGlobal.Instance.System.Recipe.SubName;

                int nCamIndex = cbCamera.SelectedIndex + 1;
                string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipe}\\SubRECIPE\\{strSubRecipe}\\";
                string filePath = strPath + $"MasterImage_CamNum_{nCamIndex}" + ".bmp";

               


                CogImageFile ImageFile1 = new CogImageFile();
                ImageFile1.Open(filePath, CogImageFileModeConstants.Read);
                if (ImageFile1.Count > 0)
                {
                    ICogImage image = ImageFile1[0];
                    CogImageConvertTool cogImageConverter = new CogImageConvertTool();
                    cogImageConverter.InputImage = image;
                    cogImageConverter.Run();
                    m_imgSource_Color = new CogImage24PlanarColor((CogImage24PlanarColor)image);
                    m_imgSource_Mono = (CogImage8Grey)cogImageConverter.OutputImage;
                    //cogImage16Grey = image as CogImage16Grey;



                    cogDisplay_Source.Image = m_imgSource_Color;
                    cogDisplay_Source.Fit(true);

                    //SetROI(nWidth, nHeight);
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

        }

        private void btnEqualizeRun_Click(object sender, EventArgs e)
        {
            //CogIPOneImageEqualize CogEqualizeTool = new CogIPOneImageEqualize();
            //Image = CogEqualizeTool.Execute(m_imgSource_Mono, CogRegionModeConstants.PixelAlignedBoundingBox, null);

            if (cogDisplay_Source.Image != null && m_imgSource_Mono != null)
            {
                cogDisplay_Source.StaticGraphics.Clear();

                ICogImage Image = null;

                Image = (ICogImage)CVisionTools.Equalize.Run(m_imgSource_Mono, null);
                cogDisplay_Source.Image = Image;
                cogDisplay_Source.Fit(true);
            }


        }

        private void chk_EqualizeUse_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_EqualizeUse.Checked)
            {
                CVisionTools.Equalize.Equalize_USE = true;
            }
            else
            {
                CVisionTools.Equalize.Equalize_USE = false;
            }
        }

        private void btn_trainImgSave_Click(object sender, EventArgs e)
        {

            try
            {
                string strRecipe = IGlobal.Instance.System.Recipe.Name;
                string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipe}\\TrainMaster";
                string filePath = "";
                int nCamIndex = cbCamera.SelectedIndex + 1;
                int selectJobIndex = gridJobs.SelectedRows[0].Index;
                string selectJobName = m_SelectedJob.NAME;
                if (cogDisplay_Pattern.Image == null)
                {
                    CUtil.ShowMessageBox("NO IMAGE", "Please proceed with Train");
                    return;
                }
                else
                {


                    if (!System.IO.Directory.Exists(strPath))
                    {
                        System.IO.Directory.CreateDirectory(strPath);
                    }

                    if (CUtil.ShowMessageBox("SAVE", "Do you want to Master Train Image save?", FormMessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                    {

                        //ICogImage image = Copy_PMalign_Train(m_imgSource_Color, m_SeletedJob.Matching.Tool.SearchRegion as CogRectangle);

                        //ICogImage image = CVisionTools.Run_CopyRegion(m_imgSource_Color, m_SelectedJob.Matching.Tool.SearchRegion as CogRectangle);
                        ////filePath = strPath + $"TrainImage_{selectJobIndex}" + ".bmp";
                        //filePath = strPath + "\\Pattern_" + selectJobName + ".png";
                        ////Common.SaveImageFileToBMP(image, filePath);
                        //Common.SaveImageFileToPNG(image, filePath);



                        for (int i = 0; i < CVisionTools.Jobs.Count; i++)
                        {
                            ICogImage img = CVisionTools.Run_CopyRegion(m_imgSource_Color, CVisionTools.Jobs[i].Matching.Tool.SearchRegion as CogRectangle);
                            //filePath = strPath + $"TrainImage_{selectJobIndex}" + ".bmp";
                            filePath = strPath + "\\Pattern_" + CVisionTools.Jobs[i].NAME + ".png";
                            //Common.SaveImageFileToBMP(image, filePath);
                            Common.SaveImageFileToPNG(img, filePath);
                        }


                        CUtil.ShowMessageBox("SAVE", "The Master Train image has been saved.");
                    }


                }
            }
            catch(Exception ex)
            {

            }
            

        }

        public void RegionImageSave()
        {

        }



        private void btnBlobImageSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strRecipe = IGlobal.Instance.System.Recipe.Name;
                string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipe}\\TrainMaster";
                string filePath = "";
                int nCamIndex = cbCamera.SelectedIndex + 1;
                int selectBlobIndex = gridBlob.SelectedRows[0].Index;
                string selectBlobName = m_SeletedBlob.Defect_Name;
                if (cogDisplay_Pattern.Image == null)
                {
                    CUtil.ShowMessageBox("NO IMAGE", "Please proceed with Train");
                    return;
                }
                else
                {


                    if (!System.IO.Directory.Exists(strPath))
                    {
                        System.IO.Directory.CreateDirectory(strPath);
                    }

                    if (CUtil.ShowMessageBox("SAVE", "Do you want to Master Train Image save?", FormMessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                    {

                        ////ICogImage image = Copy_PMalign_Train(m_imgSource_Color, m_SeletedJob.Matching.Tool.SearchRegion as CogRectangle);

                        //ICogImage image = CVisionTools.Run_CopyRegion(m_imgSource_Color, m_SeletedBlob.BLOB.Tool.Region as CogRectangle);
                        ////filePath = strPath + $"TrainImage_{selectJobIndex}" + ".bmp";
                        //filePath = strPath + "\\Blob_" + selectBlobName + ".png";
                        ////Common.SaveImageFileToBMP(image, filePath);
                        //Common.SaveImageFileToPNG(image, filePath);
                        for (int i = 0; i < CVisionTools.Blobs.Count; i++)
                        {
                            ICogImage img = CVisionTools.Run_CopyRegion(m_imgSource_Color, CVisionTools.Blobs[i].BLOB.Tool.Region as CogRectangle);
                            //filePath = strPath + $"TrainImage_{selectJobIndex}" + ".bmp";
                            filePath = strPath + "\\Blob_" + CVisionTools.Blobs[i].Defect_Name + ".png";
                            //Common.SaveImageFileToBMP(image, filePath);
                            Common.SaveImageFileToPNG(img, filePath);
                        }


                        CUtil.ShowMessageBox("SAVE", "The Master Train image has been saved.");
                    }


                }
            }
            catch(Exception ex)
            {

            }
            
        }

        private void btn_QuantizeRun_Click(object sender, EventArgs e)
        {
            try
            {
                int nindex = cbo_QuantizeLevel.SelectedIndex;
                if (cogDisplay_Source.Image != null && m_imgSource_Mono != null)
                {
                    cogDisplay_Source.StaticGraphics.Clear();

                    ICogImage Image = null;

                    Image = (ICogImage)CVisionTools.Quantize.Run(m_imgSource_Mono, null, nindex);
                    cogDisplay_Source.Image = Image;
                    cogDisplay_Source.Fit(true);
                }
            }

            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }


        }

        private void chk_QuantizeUse_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_QuantizeUse.Checked)
            {
                CVisionTools.Quantize.Quantize_USE = true;
            }
            else
            {
                CVisionTools.Quantize.Quantize_USE = false;
            }
        }

        private void cbo_QuantizeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CVisionTools.Quantize.Quantize_Level = cbo_QuantizeLevel.SelectedIndex;
        }

        private void cbojobQuantizeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chk_jobsQuantizeUSE_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_jobsQuantizeUSE.Checked)
            {
                chk_jobsEqualizeUse.Checked = false;
            }
        }

        private void chk_jobsEqualizeUse_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_jobsEqualizeUse.Checked)
            {
                chk_jobsQuantizeUSE.Checked = false;
            }
        }

        private void btnBoardImageSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strRecipe = IGlobal.Instance.System.Recipe.Name;
                string strSubRecipe = IGlobal.Instance.System.Recipe.SubName;

                if (!m_imgSource_Color.Allocated)
                {
                    CUtil.ShowMessageBox("NO IMAGE", "Please proceed with Grab");
                    return;
                }

                string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipe}\\SubRECIPE\\{strSubRecipe}\\";
                string filePath = "";
                int nCamIndex = cbCamera.SelectedIndex + 1;
                if (!System.IO.Directory.Exists(strPath))
                {
                    System.IO.Directory.CreateDirectory(strPath);
                }

                if (CUtil.ShowMessageBox("SAVE", "Do you want to Board Image save?", FormMessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    if (m_imgSource_Color.Allocated)
                    {
                        filePath = strPath + $"BoardImage_CamNum_{nCamIndex}" + ".bmp";
                        Common.SaveImageFileToBMP(m_imgSource_Color, filePath);
                    }

                    CUtil.ShowMessageBox("SAVE", "The Board image has been saved.");
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnBoardImageLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string strRecipe = IGlobal.Instance.System.Recipe.Name;
                string strSubRecipe = IGlobal.Instance.System.Recipe.SubName;
                int nCamIndex = cbCamera.SelectedIndex + 1;
                string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipe}\\SubRECIPE\\{strSubRecipe}\\";
                string filePath = strPath + $"BoardImage_CamNum_{nCamIndex}" + ".bmp";

                cogDisplay_Source.StaticGraphics.Clear();


                CogImageFile ImageFile1 = new CogImageFile();
                ImageFile1.Open(filePath, CogImageFileModeConstants.Read);
                if (ImageFile1.Count > 0)
                {
                    ICogImage image = ImageFile1[0];
                    CogImageConvertTool cogImageConverter = new CogImageConvertTool();
                    cogImageConverter.InputImage = image;
                    cogImageConverter.Run();
                    m_imgSource_Color = new CogImage24PlanarColor((CogImage24PlanarColor)image);
                    m_imgSource_Mono = (CogImage8Grey)cogImageConverter.OutputImage;

                    cogDisplay_Source.Image = m_imgSource_Color;
                    cogDisplay_Source.Fit(true);

                    //SetROI(nWidth, nHeight);
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnPatternMask_Click(object sender, EventArgs e)
        {
            FormMask frmmask = new FormMask(this);

            try
            {
                frmmask.Show();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void cbImageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbImageIndex_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                int camindex = cbCamera.SelectedIndex;
                int index = cbImageIndex.SelectedIndex;
                cogDisplay_Source.StaticGraphics.Clear();
                cogDisplay_Source.InteractiveGraphics.Clear();

                switch(camindex)
                {
                    case 0:
                        CVisionTools.tmp_seq = CVisionTools.Grab_seq;
                        break;

                    case 1:
                        CVisionTools.tmp_seq = CVisionTools.Grab_seq2;
                        break;
                }

                //if(CVisionTools.tmp_seq[index].m_imgSource_Color != null)
                //{
                //    cogDisplay_Source.Image = CVisionTools.tmp_seq[index].m_imgSource_Color;
                //}
                if(lst_imgSource_Color.Count > 0)
                {
                    cogDisplay_Source.Image = lst_imgSource_Color[index];
                }

                
                


            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

        }



        private void btnNotOptionImageSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strRecipe = IGlobal.Instance.System.Recipe.Name;
                string strSubRecipe = IGlobal.Instance.System.Recipe.SubName;

                if (!m_imgSource_Color.Allocated)
                {
                    CUtil.ShowMessageBox("NO IMAGE", "Please proceed with Grab");
                    return;
                }

                string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipe}\\SubRECIPE\\{strSubRecipe}\\";
                string filePath = "";
                int nCamIndex = cbCamera.SelectedIndex + 1;
                if (!System.IO.Directory.Exists(strPath))
                {
                    System.IO.Directory.CreateDirectory(strPath);
                }

                if (CUtil.ShowMessageBox("SAVE", "Do you want to Not Option Master Image save?", FormMessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    if (m_imgSource_Color.Allocated)
                    {
                        filePath = strPath + $"NotOptionMasterImage_CamNum_{nCamIndex}" + ".bmp";
                        Common.SaveImageFileToBMP(m_imgSource_Color, filePath);
                    }

                    CUtil.ShowMessageBox("SAVE", "The Not Option Master Image image has been saved.");
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnNotOptionImageLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string strRecipe = IGlobal.Instance.System.Recipe.Name;
                string strSubRecipe = IGlobal.Instance.System.Recipe.SubName;
                int nCamIndex = cbCamera.SelectedIndex + 1;
                string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipe}\\SubRECIPE\\{strSubRecipe}\\";
                string filePath = strPath + $"NotOptionMasterImage_CamNum_{nCamIndex}" + ".bmp";

                cogDisplay_Source.StaticGraphics.Clear();


                CogImageFile ImageFile1 = new CogImageFile();
                ImageFile1.Open(filePath, CogImageFileModeConstants.Read);
                if (ImageFile1.Count > 0)
                {
                    ICogImage image = ImageFile1[0];
                    CogImageConvertTool cogImageConverter = new CogImageConvertTool();
                    cogImageConverter.InputImage = image;
                    cogImageConverter.Run();
                    m_imgSource_Color = new CogImage24PlanarColor((CogImage24PlanarColor)image);
                    m_imgSource_Mono = (CogImage8Grey)cogImageConverter.OutputImage;

                    cogDisplay_Source.Image = m_imgSource_Color;
                    cogDisplay_Source.Fit(true);

                    //SetROI(nWidth, nHeight);
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnColorTest_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {

            }

        }

        private void btnColorMatchROI_Click(object sender, EventArgs e)
        {
            try
            {
                int nIndex = nSelect_ColorMatch_Index;

                if (!m_imgSource_Mono.Allocated)
                {
                    MessageBox.Show("Need IMAGE");
                    return;
                }

                if (cbCamera.SelectedIndex == 0)
                {
                    CVisionTools.ColorMatch[nIndex].COLORMATCH.New_RectangleROI(cogDisplay_Source, m_imgSource_Color);
                }
                else
                {
                    CVisionTools.ColorMatch2[nIndex].COLORMATCH.New_RectangleROI(cogDisplay_Source, m_imgSource_Color);
                }



            }
            catch (Exception ex)
            {

                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }



        private void btnColorExtract_Click(object sender, EventArgs e)
        {
            
            try
            {
                int nIndex = nSelect_ColorMatch_Index;
                Color tmpColor = new Color();
                
                CogRectangle tmpRect = new CogRectangle();
                Bitmap bitmap = m_imgSource_Color.ToBitmap();
                tmpRect = m_SelectedColor.COLORMATCH.Tool.Region as CogRectangle;

                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();

                if (cbCamera.SelectedIndex == 0)
                {
                    tmpColor = CVisionTools.ColorMatch[nIndex].COLORMATCH.Color_Extract(bitmap, CVisionTools.ColorMatch[nIndex].COLORMATCH.Rect_Extrac_Roi);
                }
                else
                {
                    tmpColor = CVisionTools.ColorMatch2[nIndex].COLORMATCH.Color_Extract(bitmap, CVisionTools.ColorMatch2[nIndex].COLORMATCH.Rect_Extrac_Roi);
                }

                tbExtractRED.Text = tmpColor.R.ToString();
                tbExtractGREEN.Text = tmpColor.G.ToString();
                tbExtractBLUE.Text = tmpColor.B.ToString();
                lbExtractColor.BackColor = tmpColor;

                ExtractColor = tmpColor;



            }
            catch (Exception ex)
            {

                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            

        }

        public static string RgbConverter(Color c)
        {
            return String.Format("RGB({0},{1},{2})", c.R, c.G, c.B);
        }

        private void cbRotateMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbCamera.SelectedIndex == 0) Global.Parameter.Cam1_ImageProcess.FlipRotate = cbCamFlipRotate.Text;
                if (cbCamera.SelectedIndex == 1) Global.Parameter.Cam2_ImageProcess.FlipRotate = cbCamFlipRotate.Text;
            }
            catch
            {

            }
        }

        private void btnGrabSeqAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                //string str_Name = tbGrabSeqName.Text;
                int nLightValue = int.Parse(lbLightValue.Text);
                //int nIndex = int.Parse(cbImageIndex.Text);
                int Camindex = cbCamera.SelectedIndex;

                int Exposure = (int)nbCamExposure.Value;
                int Gain = (int)nbCamGain.Value;
                bool USE = chk_GrabSeqUSE.Checked;

                //GRAB_SEQ grab_seq = new GRAB_SEQ();
                JOB_SEQ grab_seq = new JOB_SEQ();

                grab_seq.LightValue = nLightValue;
                grab_seq.Exposure = Exposure;
                grab_seq.Gain = Gain;
                //grab_seq.USE = USE;
                //grab_seq.m_imgSource_Color = m_imgSource_Color; 이미지는 그랩 하고나서 리스트에 하나씩 추가


                if (Camindex == 0)
                {
                    //// 동일한 이름이 있는지 확인
                    //for (int i = 0; i < CVisionTools.Grab_seq.Count; i++)
                    //{
                    //    if (string.Equals(CVisionTools.Grab_seq[i].Name, grab_seq.Name, StringComparison.OrdinalIgnoreCase))
                    //    {
                    //        CUtil.ShowMessageBox("NOTICE", "SEQ NAME ALREADY EXISTS");
                    //        return;
                    //    }
                    //}

                    CVisionTools.Grab_seq.Add(grab_seq);

                    UpdateGrabSeq(Camindex);

                    //제일 마지막 행을 선택되도록 함
                    gridSeq.Rows[CVisionTools.Grab_seq.Count - 1].Selected = true;
                    gridSeq.Rows[CVisionTools.Grab_seq.Count - 1].Cells[0].Selected = true;
                }
                else
                {
                    //// 동일한 이름이 있는지 확인
                    //for (int i = 0; i < CVisionTools.Grab_seq2.Count; i++)
                    //{
                    //    if (string.Equals(CVisionTools.Grab_seq2[i].Name, grab_seq.Name, StringComparison.OrdinalIgnoreCase))
                    //    {
                    //        CUtil.ShowMessageBox("NOTICE", "SEQ NAME ALREADY EXISTS");
                    //        return;
                    //    }
                    //}

                    CVisionTools.Grab_seq2.Add(grab_seq);

                    UpdateGrabSeq(Camindex);

                    //제일 마지막 행을 선택되도록 함
                    gridSeq.Rows[CVisionTools.Grab_seq2.Count - 1].Selected = true;
                    gridSeq.Rows[CVisionTools.Grab_seq2.Count - 1].Cells[0].Selected = true;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btmGrabSeqApply_Click_1(object sender, EventArgs e)
        {
            try
            {
                //string str_Name = tbGrabSeqName.Text;
                int nLightValue = int.Parse(lbLightValue.Text);
                //int nIndex = int.Parse(cbImageIndex.Text);

                int Exposure = (int)nbCamExposure.Value;
                int Gain = (int)nbCamGain.Value;

                int nRowIndex = nSelect_Seq_Index;
                int Camindex = cbCamera.SelectedIndex;
                bool USE = chk_GrabSeqUSE.Checked;


                if (gridSeq.SelectedRows.Count > 0)
                {


                    JOB_SEQ grab = new JOB_SEQ();



                    grab.LightValue = nLightValue;
                    
                    grab.Exposure = Exposure;
                    grab.Gain = Gain;
                    //grab.USE = USE;

                    if (cbCamera.SelectedIndex == 0)
                    {
                        if (CVisionTools.Grab_seq.Count == 0) return;

                        CVisionTools.Grab_seq.RemoveAt(nRowIndex);
                        CVisionTools.Grab_seq.Insert(nRowIndex, grab);
                    }
                    else
                    {
                        if (CVisionTools.Grab_seq2.Count == 0) return;
                        CVisionTools.Grab_seq2.RemoveAt(nRowIndex);
                        CVisionTools.Grab_seq2.Insert(nRowIndex, grab);
                    }

                    gridSeq.SelectedRows[0].SetValues(new object[] { nLightValue, Exposure, Gain, USE.ToString() });



                }

                //int nCamIndex = 
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnGrabSeqDelect_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (gridSeq.SelectedRows.Count > 0)
                {
                    int nRowIndex = gridSeq.SelectedRows[0].Index;

                    if (cbCamera.SelectedIndex == 0)
                    {
                        CVisionTools.Grab_seq.RemoveAt(nRowIndex); //
                    }
                    else
                    {
                        CVisionTools.Grab_seq2.RemoveAt(nRowIndex); //
                    }

                }

                //UpdateGrabSeq();
                UpdateGrabSeq(cbCamera.SelectedIndex);

                if (gridSeq.SelectedRows.Count == 0) return;

                gridSeq.Rows[gridSeq.SelectedRows[0].Index + 1].Selected = true;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnSubPatternSearchROI_Click(object sender, EventArgs e)
        {
            try
            {
                //if (m_SeletedJob == null)
                //{
                //    CUtil.ShowMessageBox("알림", "JOB 을 선택해주세요.");
                //    return;
                //}

                //string strIndex = cbJobTYpe.Text;
                //switch (strIndex)
                //{
                //    case "전체 영역 검사":
                //        break;
                //    case "REGION INSPECTION":
                //        cogDisplay_Source.InteractiveGraphics.Clear();
                //        cogDisplay_Source.StaticGraphics.Clear();

                //        if (m_SeletedJob.Matching.Tool.SearchRegion == null) m_SeletedJob.Matching.Tool.SearchRegion = new CogRectangle();


                //        CogRectangle cogTrainRegion = (CogRectangle)m_SeletedJob.Matching.Tool.SearchRegion;
                //        cogTrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;
                //        cogTrainRegion.Interactive = true;
                //        cogDisplay_Source.InteractiveGraphics.Add((ICogGraphicInteractive)cogTrainRegion, "Search", false);

                //        break;
                //}
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnSubPatternROI_Click(object sender, EventArgs e)
        {
            try
            {
                //if (m_SeletedJob == null)
                //{
                //    CUtil.ShowMessageBox("알림", "JOB 을 선택해주세요.");
                //    return;
                //}

                //cogDisplay_Source.InteractiveGraphics.Clear();
                //cogDisplay_Source.StaticGraphics.Clear();



                //if (m_SeletedJob.Matching.Tool.Pattern.TrainRegion == null) m_SeletedJob.Matching.Tool.Pattern.TrainRegion = new CogRectangle();


                //CogRectangleAffine cogTrainRegion = (CogRectangleAffine)m_SeletedJob.Matching.Tool.Pattern.TrainRegion;
                //if (cogTrainRegion.CenterX == 0 || cogTrainRegion.CenterY == 0)
                //{
                //    if (cogTrainRegion.SideXLength <= 100) cogTrainRegion.SideXLength = 250;
                //    if (cogTrainRegion.SideYLength <= 100) cogTrainRegion.SideYLength = 250;
                //}

                //cogDisplay_Source.InteractiveGraphics.Add((ICogGraphicInteractive)cogTrainRegion, "Pattern", false);

                
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnSubPatternTrain_Click(object sender, EventArgs e)
        {

        }

        private void chkOKImageSAVE_CheckedChanged(object sender, EventArgs e)
        {
            if(chkOKImageSAVE.Checked)
            {
                Global.System.OK_IMAGE_SAVE = true;
            }
            else
            {
                Global.System.OK_IMAGE_SAVE = false;
            }
        }

        private void chkNGImageSave_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNGImageSave.Checked)
            {
                Global.System.NG_IMAGE_SAVE = true;
            }
            else
            {
                Global.System.NG_IMAGE_SAVE = false;
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnIMAGE_SAVE_TYPE_Click(object sender, EventArgs e)
        {
            try
            {
                Global.FileManager.IMAGESAVETYPE_SAVE();
            }
            catch(Exception ex)
            {

            }
            
        }

        private void cbPatternRegionMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }

        private void trbThreshold_Cam_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                string strTag = cbCamera.Text;
                int nThreshold = trbThreshold.Value;

                using (Mat imgSource = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Mono.ToBitmap()))
                using (Mat imgBin = new Mat())
                {
                    Cv2.Threshold(imgSource, imgBin, nThreshold, 255, ThresholdTypes.Binary);

                    CogImage8Grey imgCogSource = new CogImage8Grey(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgBin));
                    cogDisplay_Source.Image = imgCogSource;
                }

                lbThreshold.Text = nThreshold.ToString();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnPatternParameterApply_Click(object sender, EventArgs e)
        {
            try
            {
                m_SelectedJob.Matching.Tool.RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.LowHigh;
                m_SelectedJob.Matching.Tool.RunParams.ZoneScale.High = double.Parse(tbScaleHigh.Text);
                m_SelectedJob.Matching.Tool.RunParams.ZoneScale.Low = double.Parse(tbScaleLow.Text);
                m_SelectedJob.Matching.Tool.RunParams.AcceptThreshold = double.Parse(tbJobScoreMin.Text);
                m_SelectedJob.Matching.Tool.RunParams.ContrastThreshold = double.Parse(tbContrast.Text);

                propertyGrid_Param.SelectedObject = m_SelectedJob.Matching.Tool.RunParams;
                propertyGrid_Param.Invalidate();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
        CogColorSegmenterTool tool = new CogColorSegmenterTool();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {

                tool.InputImage = m_imgSource_Color;
                cogDisplay_Source.InteractiveGraphics.Clear();
                tool.Region = new CogRectangle();
                (tool.Region as CogRectangle).GraphicDOFEnable = CogRectangleDOFConstants.All;
                (tool.Region as CogRectangle).Interactive = true;
                cogDisplay_Source.InteractiveGraphics.Add((CogRectangle)tool.Region, "TT", false);
            }


            catch
            {

            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            try
            {
               // CogColorExtractorTool tool2 = new CogColorExtractorTool();
               // CogColorExtractorRunParams param = new CogColorExtractorRunParams();
               // param.GroupColorImagesEnabled = true;
                

               // CogColorExtractorColor tool1 = new CogColorExtractorColor(m_imgSource_Color, tool.Regidon);
               // CogColorExtractorColorGroup gr = new CogColorExtractorColorGroup();
               // gr.Insert(0, tool1);

               // tool2.Pattern.ColorModel.Insert(0, gr);
               //CogColorExtractorResults result = tool2.Pattern.Execute(m_imgSource_Color, tool.Region, param);

               // tool1.Enabled = true;
            }
            catch(Exception ex)
            {

            }
        }

        private void gridJobs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private bool m_bViewPartsName = false;
        private void btnViewPartsName_Click(object sender, EventArgs e)
        {
            try
            {
                m_bViewPartsName = !m_bViewPartsName;

                if(m_bViewPartsName)
                {
                    btnViewPartsName.BackColor = DEFINE.COLOR_TEAL;

                    List<JOB_TEMP> jobList = new List<JOB_TEMP>();

                    if (cbCamera.SelectedIndex == 0) jobList = CVisionTools.Jobs;
                    else jobList = CVisionTools.Jobs2;

                    CogGraphicCollection graphics = new CogGraphicCollection();
                    for (int i = 0; i < jobList.Count; i++)
                    {
                        CogGraphicLabel label = new CogGraphicLabel();
                        CogRectangle rt = new CogRectangle();
                        rt = PMAlignTool.SearchRegion as CogRectangle;

                        label.Color = CogColorConstants.Red;
                        label.Text = jobList[i].NAME;
                        label.Font = new Font("arial", 12, FontStyle.Bold);
                        label.X = (jobList[i].Matching.Tool.SearchRegion as CogRectangle).X;
                        label.Y = (jobList[i].Matching.Tool.SearchRegion as CogRectangle).Y - 20;

                        graphics.Add((ICogGraphic)jobList[i].Matching.Tool.SearchRegion);
                        graphics.Add((ICogGraphic)jobList[i].Matching.Tool.Pattern.TrainRegion);
                        graphics.Add((ICogGraphic)label);
                    }

                    cogDisplay_Source.StaticGraphics.AddList(graphics, "NAME");
                }
                else
                {
                    btnViewPartsName.BackColor = Color.DimGray;
                    cogDisplay_Source.StaticGraphics.Clear();
                }
            }
            catch(Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                CUtil.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
         
        }

        private void cogDisplay_Source_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void cogDisplay_Source_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CogTransform2DLinear xForm;
                xForm = cogDisplay_Source.GetTransform("*\\#", "*") as CogTransform2DLinear;
                xForm.MapPoint(e.X, e.Y, out double dPosX, out double dPosY);

                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    if(m_SelectedJob != null)
                    {
                        (m_SelectedJob.Matching.Tool.SearchRegion as CogRectangle).SetCenterWidthHeight(dPosX, dPosY, (m_SelectedJob.Matching.Tool.SearchRegion as CogRectangle).Width, (m_SelectedJob.Matching.Tool.SearchRegion as CogRectangle).Height);

                        if (m_SelectedJob.Matching.Tool.Pattern.TrainRegion is CogRectangleAffine)
                        {
                            (m_SelectedJob.Matching.Tool.Pattern.TrainRegion as CogRectangleAffine).CenterX = dPosX;
                            (m_SelectedJob.Matching.Tool.Pattern.TrainRegion as CogRectangleAffine).CenterY = dPosY;
                        }

                        if (m_SelectedJob.Matching.Tool.Pattern.TrainRegion is CogCircle)
                        {
                            (m_SelectedJob.Matching.Tool.Pattern.TrainRegion as CogCircle).CenterX = dPosX;
                            (m_SelectedJob.Matching.Tool.Pattern.TrainRegion as CogCircle).CenterY = dPosY;
                        }
                    }

                    if(m_SelectedMultiPMAlign != null)
                    {
                        (m_SelectedMultiPMAlign.Matching.Tool.SearchRegion as CogRectangle).SetCenterWidthHeight(dPosX, dPosY, (m_SelectedMultiPMAlign.Matching.Tool.SearchRegion as CogRectangle).Width, (m_SelectedMultiPMAlign.Matching.Tool.SearchRegion as CogRectangle).Height);

                        //(m_SelectedMultiPMAlign.Matching.PMAlign.SearchRegion as CogRectangle).SetCenterWidthHeight(dPosX, dPosY, (m_SelectedMultiPMAlign.Matching.PMAlign.SearchRegion as CogRectangle).Width, (m_SelectedMultiPMAlign.Matching.PMAlign.SearchRegion as CogRectangle).Height);

                        if (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion is CogRectangleAffine)
                        {
                            (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion as CogRectangleAffine).CenterX = dPosX;
                            (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion as CogRectangleAffine).CenterY = dPosY;
                        }

                        if (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion is CogCircle)
                        {
                            (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion as CogCircle).CenterX = dPosX;
                            (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion as CogCircle).CenterY = dPosY;
                        }
                    }
                    return;
                }

                if(m_bViewPartsName)
                {
                    List<JOB_TEMP> jobList = new List<JOB_TEMP>();

                    if (cbCamera.SelectedIndex == 0) jobList = CVisionTools.Jobs;
                    else jobList = CVisionTools.Jobs2;

                    for (int i = 0; i < jobList.Count; i++)
                    {
                        RectangleF rtRegion = new RectangleF();
                        rtRegion.X = (float)(jobList[i].Matching.Tool.SearchRegion as CogRectangle).X;
                        rtRegion.Y = (float)(jobList[i].Matching.Tool.SearchRegion as CogRectangle).Y;
                        rtRegion.Width = (float)(jobList[i].Matching.Tool.SearchRegion as CogRectangle).Width;
                        rtRegion.Height = (float)(jobList[i].Matching.Tool.SearchRegion as CogRectangle).Height;

                        if(rtRegion.Contains(new PointF((float)dPosX, (float)dPosY)))
                        {
                            m_SelectedJob = jobList[i];
                            break;
                        }
                    }

                    UpdateSelectedJob();
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                CUtil.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }

        private void btnColorADD_Click(object sender, EventArgs e)
        {
            try
            {
                string str_Name = tbColorName.Text;
                bool bInspectionUse = chk_ColorUSE.Checked;
                int nIndex = cbCamera.SelectedIndex;

                int ColorCount = cboColorINDEX.Items.Count;
                string score = tbColorSCORE.Text;
                

                if (!m_imgSource_Mono.Allocated) { MessageBox.Show("NEED IMAGE"); return; }

                if (nIndex == 0)
                {
                    JOB_COLORMATCH job_COLORMATCH = new JOB_COLORMATCH($"JOB_{CVisionTools.ColorMatch.Count.ToString()}");
                    job_COLORMATCH.Defect_Name = str_Name;
                    job_COLORMATCH.InspectionUse = bInspectionUse;
                    job_COLORMATCH.SCORE = double.Parse(score);
                    job_COLORMATCH.ColorCount = ColorCount;

                    //동일한 이름이 있는지 확인
                    for (int i = 0; i < CVisionTools.ColorMatch.Count; i++)
                    {
                        if (string.Equals(CVisionTools.ColorMatch[i].Defect_Name, job_COLORMATCH.Defect_Name, StringComparison.OrdinalIgnoreCase))
                        {
                            CUtil.ShowMessageBox("NOTICE", "COLOR NAME ALREADY EXISTS");
                            return;
                        }
                    }

                    CVisionTools.ColorMatch.Add(job_COLORMATCH);

                    m_SelectedColor = job_COLORMATCH;

                   
                    CCogTool_ColorMatch cCogTool_ColorMatch = CVisionTools.ColorMatch_CAM1;

                    propertyGrid_ColorMatch.SelectedObject = m_SelectedColor.COLORMATCH.Tool.RunParams;


                    UpdateColor(cbCamera.SelectedIndex);
                    

                    //제일 마지막 행을 선택되도록 함
                    GridColor.Rows[CVisionTools.ColorMatch.Count - 1].Selected = true;
                    GridColor.Rows[CVisionTools.ColorMatch.Count - 1].Cells[0].Selected = true;
                }
                else
                {
                    JOB_COLORMATCH job_COLORMATCH = new JOB_COLORMATCH($"JOB_{CVisionTools.ColorMatch2.Count.ToString()}");
                    job_COLORMATCH.Defect_Name = str_Name;
                    job_COLORMATCH.InspectionUse = bInspectionUse;
                    job_COLORMATCH.SCORE = double.Parse(score);
                    job_COLORMATCH.ColorCount = ColorCount;

                    //동일한 이름이 있는지 확인
                    for (int i = 0; i < CVisionTools.ColorMatch2.Count; i++)
                    {
                        if (string.Equals(CVisionTools.ColorMatch2[i].Defect_Name, job_COLORMATCH.Defect_Name, StringComparison.OrdinalIgnoreCase))
                        {
                            CUtil.ShowMessageBox("NOTICE", "COLOR NAME ALREADY EXISTS");
                            return;
                        }
                    }

                    CVisionTools.ColorMatch2.Add(job_COLORMATCH);

                    m_SelectedColor = job_COLORMATCH;

                    CCogTool_ColorMatch cCogTool_ColorMatch = CVisionTools.ColorMatch_CAM1;

                    propertyGrid_ColorMatch.SelectedObject = m_SelectedColor.COLORMATCH.Tool.RunParams;


                    UpdateColor(cbCamera.SelectedIndex);

                    //제일 마지막 행을 선택되도록 함
                    GridColor.Rows[CVisionTools.ColorMatch2.Count - 1].Selected = true;
                    GridColor.Rows[CVisionTools.ColorMatch2.Count - 1].Cells[0].Selected = true;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                CUtil.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }

        private void btnColorDELETE_Click(object sender, EventArgs e)
        {
            try
            {
                int camindex = cbCamera.SelectedIndex;
                if (GridColor.SelectedRows.Count > 0)
                {
                    int nRowIndex = GridColor.SelectedRows[0].Index;

                    if (camindex == 0)
                    {
                        CVisionTools.ColorMatch.RemoveAt(nRowIndex);
                    }
                    else
                    {
                        CVisionTools.ColorMatch2.RemoveAt(nRowIndex);
                    }

                }

                
                UpdateColor(camindex);

                if (GridColor.SelectedRows.Count == 0)
                {
                    return;
                }

                GridColor.Rows[GridColor.SelectedRows[0].Index + 1].Selected = true;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnColorAPPLY_Click(object sender, EventArgs e)
        {
            try
            {
                
                string str_Name = tbColorName.Text;
                bool bInspectionUse = chk_ColorUSE.Checked;

                int nCamIndex = cbCamera.SelectedIndex;
                int nIndex = nSelect_ColorMatch_Index;
                int ColorCount = cboColorINDEX.Items.Count;
                double Score = double.Parse(tbColorSCORE.Text);

                if (m_SelectedColor == null)
                {
                    CUtil.ShowMessageBox("ALRAM", "INSPECTION LIST CREATE.");
                    return;
                }

                if (GridColor.SelectedRows.Count > 0)
                {
                    m_SelectedColor.Defect_Name = str_Name;
                    m_SelectedColor.InspectionUse = bInspectionUse;
                    m_SelectedColor.ColorCount = ColorCount;
                    m_SelectedColor.SCORE = Score;

                    if (cbCamera.SelectedIndex == 0)
                    {
                        CVisionTools.ColorMatch.RemoveAt(nIndex);
                        CVisionTools.ColorMatch.Insert(nIndex, m_SelectedColor);
                    }
                    else
                    {
                        CVisionTools.ColorMatch2.RemoveAt(nIndex);
                        CVisionTools.ColorMatch2.Insert(nIndex, m_SelectedColor);
                    }



                    GridColor.SelectedRows[0].SetValues(new object[] { m_SelectedColor.Defect_Name, m_SelectedColor.InspectionUse.ToString(), m_SelectedColor.ColorCount.ToString(), m_SelectedColor.SCORE.ToString() });
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        

        private void GridColor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();

                nSelect_ColorMatch_Index = e.RowIndex;

                if (GridColor.SelectedRows.Count > 0)
                {
                    int nIndex = GridColor.SelectedRows[0].Index;

                    if (cbCamera.SelectedIndex == 0)
                    {
                        m_SelectedColor = CVisionTools.ColorMatch[nIndex];
                    }
                    else
                    {
                        m_SelectedColor = CVisionTools.ColorMatch2[nIndex];
                    }

                    tbColorName.Text = m_SelectedColor.Defect_Name;
                    chk_ColorUSE.Checked = m_SelectedColor.InspectionUse;
                    cboColorINDEX.Items.Clear();
                    for (int i = 0; i< m_SelectedColor.COLORMATCH.COLOR.Count; i++)
                    {
                        cboColorINDEX.Items.Add(m_SelectedColor.COLORMATCH.COLOR[i]);
                    }
                    tbColorSCORE.Text = m_SelectedColor.SCORE.ToString();

                    propertyGrid_ColorMatch.SelectedObject = m_SelectedColor.COLORMATCH.Tool.RunParams;
                }

                // UI 디스플레이
                if (cogDisplay_Source.Image == null || cogDisplay_Source.Image.Allocated == false) return; // 이미지가 없으면 ROI를 그려주지않음

                if (cbCamera.SelectedIndex == 0)
                {
                    if (CVisionTools.ColorMatch.Count == 0) return;
                    if (CVisionTools.ColorMatch[nSelect_ColorMatch_Index].COLORMATCH.Tool.Region == null) return;

                    cogDisplay_Source.InteractiveGraphics.Add((CogRectangle)CVisionTools.ColorMatch[nSelect_ColorMatch_Index].COLORMATCH.Tool.Region, "ROI", false);
                }
                else
                {
                    if (CVisionTools.ColorMatch2.Count == 0) return;
                    if (CVisionTools.ColorMatch2[nSelect_ColorMatch_Index].COLORMATCH.Tool.Region == null) return;

                    cogDisplay_Source.InteractiveGraphics.Add((CogRectangle)CVisionTools.ColorMatch2[nSelect_ColorMatch_Index].COLORMATCH.Tool.Region, "ROI", false);
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void gridBlob_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnColorExtractROI_Click(object sender, EventArgs e)
        {
            try
            {
                int nIndex = nSelect_ColorMatch_Index;

                if (!m_imgSource_Mono.Allocated)
                {
                    MessageBox.Show("Need IMAGE");
                    return;
                }

                if (cbCamera.SelectedIndex == 0)
                {
                    CVisionTools.ColorMatch[nIndex].COLORMATCH.New_ExtractROI(cogDisplay_Source, m_imgSource_Color);
                }
                else
                {
                    CVisionTools.ColorMatch2[nIndex].COLORMATCH.New_ExtractROI(cogDisplay_Source, m_imgSource_Color);
                }



            }
            catch (Exception ex)
            {

                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnRGBADD_Click(object sender, EventArgs e)
        {
            try
            {
                //t nIndex = nSelect_ColorMatch_Index;
                if(!m_SelectedColor.COLORMATCH.COLOR.Contains(ExtractColor))
                {
                    m_SelectedColor.COLORMATCH.COLOR.Add(ExtractColor);
                    cboColorUpdate(m_SelectedColor.COLORMATCH.COLOR);
                    
                }
                
            }
            catch (Exception ex)
            {

                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnRGBDELETE_Click(object sender, EventArgs e)
        {
            try
            {
               
                m_SelectedColor.COLORMATCH.COLOR.RemoveAt(cboColorINDEX.SelectedIndex);
                cboColorUpdate(m_SelectedColor.COLORMATCH.COLOR);

            }
            catch (Exception ex)
            {

                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void cboColorUpdate(List<Color> lstColor)
        {
            try
            {
                cboColorINDEX.Items.Clear();
                for (int i = 0; i < lstColor.Count; i++)
                {
                    cboColorINDEX.Items.Add(lstColor[i]);
                    
                }
                
            }
            catch (Exception ex)
            {

                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void cboColorINDEX_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbExtractColor.BackColor = m_SelectedColor.COLORMATCH.COLOR[cboColorINDEX.SelectedIndex];

                tbExtractRED.Text = m_SelectedColor.COLORMATCH.COLOR[cboColorINDEX.SelectedIndex].R.ToString();
                tbExtractGREEN.Text = m_SelectedColor.COLORMATCH.COLOR[cboColorINDEX.SelectedIndex].G.ToString();
                tbExtractBLUE.Text = m_SelectedColor.COLORMATCH.COLOR[cboColorINDEX.SelectedIndex].B.ToString();

            }
            catch (Exception ex)
            {

                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnColorSelectIns_Click(object sender, EventArgs e)
        {
            CogRectangle OriginRectangle = new CogRectangle();
            CogRectangle MoveRectangle = new CogRectangle();
            double tmpX = new double();
            double tmpY = new double();

            try
            {
                int nCamIndex = cbCamera.SelectedIndex;
                int nIndex = nSelect_ColorMatch_Index;

                CCogTool_ColorMatch job_ColorMatch = null;
                CogGraphicCollection cogList = new CogGraphicCollection();

                CogSimpleColorCollection cogSimpleColorCollection = new CogSimpleColorCollection();
                
                List<CogSimpleColorItem> cogSimpleColorItems = new List<CogSimpleColorItem>();

                cogDisplay_Source.StaticGraphics.Clear();
                cogDisplay_Source.InteractiveGraphics.Clear();

                if (nCamIndex == 0)
                {
                    if (CVisionTools.ColorMatch.Count == 0) return;
                    CVisionTools.tmpColorMatch = CVisionTools.ColorMatch;
                    job_ColorMatch = CVisionTools.ColorMatch[nIndex].COLORMATCH;
                    
                }
                else
                {
                    if (CVisionTools.ColorMatch2.Count == 0) return;
                    CVisionTools.tmpColorMatch = CVisionTools.ColorMatch2;
                    job_ColorMatch = CVisionTools.ColorMatch2[nIndex].COLORMATCH;
                   
                }

                for (int i = 0; i < job_ColorMatch.COLOR.Count; i++)
                {
                    CogSimpleColorItem simpleColorItem = new CogSimpleColorItem(CogImageColorSpaceConstants.RGB);
                    simpleColorItem.Plane0 = job_ColorMatch.COLOR[i].R;
                    simpleColorItem.Plane1 = job_ColorMatch.COLOR[i].G;
                    simpleColorItem.Plane2 = job_ColorMatch.COLOR[i].B;
                    cogSimpleColorItems.Add(simpleColorItem);
                    cogSimpleColorCollection.Add(cogSimpleColorItems[i]);
                    

                }

                //Region Offset
                (tmpX, tmpY) = CVisionTools.RegionOffSet(cbCamera.SelectedIndex, cogDisplay_Source, m_imgSource_Mono);
                (OriginRectangle, MoveRectangle) = CVisionTools.RegionRect(job_ColorMatch.Tool.Region, tmpX, tmpY);
                job_ColorMatch.Tool.Region = MoveRectangle;


                CogColorMatchResultSet resultSet = new CogColorMatchResultSet(job_ColorMatch.Run(m_imgSource_Color, job_ColorMatch.Tool.Region, cogSimpleColorCollection));

                //베스트 스코어
                tbColorMatchResultSCORE.Text = resultSet.ResultOfBestMatch.MatchScore.ToString("F2");
                lbResultColor.BackColor = resultSet.RunColor.SystemColorValue;
                tbFINDR.Text = Convert.ToInt32(resultSet.RunColor.Plane0).ToString();
                tbFINDG.Text = Convert.ToInt32(resultSet.RunColor.Plane1).ToString();
                tbFINDB.Text = Convert.ToInt32(resultSet.RunColor.Plane2).ToString();

                CogGraphicLabel label = new CogGraphicLabel();
                CogRectangle rect = new CogRectangle();
                rect = job_ColorMatch.Tool.Region as CogRectangle;
                if (resultSet.ResultOfBestMatch.MatchScore > m_SelectedColor.SCORE) //OK
                {
                    
                    label.Color = CogColorConstants.Green;
                    label.Text = "COLOR OK";
                    label.Font = new Font("arial", 10);
                    label.X = rect.CenterX;
                    label.Y = rect.CenterY;

                    cogDisplay_Source.StaticGraphics.Add(rect, "");
                    cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                }
                else //NG
                {
                    label.Color = CogColorConstants.Red;
                    label.Text = "COLOR NG";
                    label.Font = new Font("arial", 10);
                    label.X = rect.CenterX;
                    label.Y = rect.CenterY;

                    cogDisplay_Source.StaticGraphics.Add(rect, "");
                    cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                }

                job_ColorMatch.Tool.Region = OriginRectangle;



            }
            catch (Exception ex)
            {
                
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            
        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void btnColorAllIns_Click(object sender, EventArgs e)
        {
            CogRectangle OriginRectangle = new CogRectangle();
            CogRectangle MoveRectangle = new CogRectangle();
            double tmpX = new double();
            double tmpY = new double();

            try
            {
                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();
                CogGraphicCollection cogList = new CogGraphicCollection();

                if (cbCamera.SelectedIndex == 0)
                {
                    CVisionTools.tmpColorMatch = CVisionTools.ColorMatch;
                }
                else
                {
                    CVisionTools.tmpColorMatch = CVisionTools.ColorMatch2;
                }

                for (int i = 0; i < CVisionTools.tmpColorMatch.Count; i++)
                {
                    CogColorMatchTool colorMatchTool = CVisionTools.tmpColorMatch[i].COLORMATCH.Tool;
                    CogSimpleColorCollection cogSimpleColorCollection = new CogSimpleColorCollection();
                    List<CogSimpleColorItem> cogSimpleColorItems = new List<CogSimpleColorItem>();

                    if (CVisionTools.tmpColorMatch[i].InspectionUse)
                    {

                        for (int j = 0; j < CVisionTools.tmpColorMatch[i].COLORMATCH.COLOR.Count; j++)
                        {
                            CogSimpleColorItem simpleColorItem = new CogSimpleColorItem(CogImageColorSpaceConstants.RGB);
                            simpleColorItem.Plane0 = CVisionTools.tmpColorMatch[i].COLORMATCH.COLOR[j].R;
                            simpleColorItem.Plane1 = CVisionTools.tmpColorMatch[i].COLORMATCH.COLOR[j].G;
                            simpleColorItem.Plane2 = CVisionTools.tmpColorMatch[i].COLORMATCH.COLOR[j].B;
                            cogSimpleColorItems.Add(simpleColorItem);
                            cogSimpleColorCollection.Add(cogSimpleColorItems[j]);
                        }

                        //Region Offset
                        (tmpX, tmpY) = CVisionTools.RegionOffSet(cbCamera.SelectedIndex, cogDisplay_Source, m_imgSource_Mono);
                        (OriginRectangle, MoveRectangle) = CVisionTools.RegionRect(CVisionTools.tmpColorMatch[i].COLORMATCH.Tool.Region, tmpX, tmpY);
                        CVisionTools.tmpColorMatch[i].COLORMATCH.Tool.Region = MoveRectangle;

                        CogColorMatchResultSet resultSet = new CogColorMatchResultSet(CVisionTools.tmpColorMatch[i].COLORMATCH.Run(m_imgSource_Color, CVisionTools.tmpColorMatch[i].COLORMATCH.Tool.Region, cogSimpleColorCollection));

                        CogGraphicLabel label = new CogGraphicLabel();
                        CogRectangle rect = new CogRectangle();
                        rect = CVisionTools.tmpColorMatch[i].COLORMATCH.Tool.Region as CogRectangle;
                        if (resultSet.ResultOfBestMatch.MatchScore > CVisionTools.tmpColorMatch[i].SCORE) //OK
                        {

                            label.Color = CogColorConstants.Green;
                            label.Text = "COLOR OK";
                            label.Font = new Font("arial", 10);
                            label.X = rect.CenterX;
                            label.Y = rect.CenterY;

                            
                            cogList.Add(rect);
                            cogList.Add(label);
                        }
                        else //NG
                        {
                            label.Color = CogColorConstants.Red;
                            label.Text = "COLOR NG";
                            label.Font = new Font("arial", 10);
                            label.X = rect.CenterX;
                            label.Y = rect.CenterY;


                            cogList.Add(rect);
                            cogList.Add(label);
                            
                        }
                        cogDisplay_Source.StaticGraphics.AddList(cogList, "");


                    }
                    else
                    {
                        //미사용
                    }

                    CVisionTools.tmpColorMatch[i].COLORMATCH.Tool.Region = OriginRectangle;
                }
            }
            catch (Exception ex)
            {

                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            
        }

        private void GridColor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModelCodeADD_Click(object sender, EventArgs e)
        {
            try
            {
                string str_ModelCode = tbModelCode.Text;

                // 동일한 이름이 있는지 확인
                for (int i = 0; i < Global.System.Recipe.ModelCode.Count; i++)
                {
                    if (string.Equals(Global.System.Recipe.ModelCode[i], str_ModelCode, StringComparison.OrdinalIgnoreCase))
                    {
                        CUtil.ShowMessageBox("NOTICE", "MODEL CODE ALREADY EXISTS");
                        return;
                    }
                }
                Global.System.Recipe.ModelCode.Add(str_ModelCode);

                UpdateModelCode();

                //제일 마지막 행을 선택되도록 함
                Grid_ModelCODE.Rows[Global.System.Recipe.ModelCode.Count - 1].Selected = true;
                Grid_ModelCODE.Rows[Global.System.Recipe.ModelCode.Count - 1].Cells[0].Selected = true;


            }
            catch (Exception ex)
            {

                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnModelCodeDelete_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (Grid_ModelCODE.SelectedRows.Count > 0)
                {
                    int nRowIndex = Grid_ModelCODE.SelectedRows[0].Index;
                    Global.System.Recipe.ModelCode.RemoveAt(nRowIndex);
                    //CVisionTools.DELETE_ModelCode(Global.System.Recipe.Name, Global.System.Recipe.ModelCode, nRowIndex);
                    CVisionTools.DELETE_ModelCode(Global.System.Recipe.Name, Global.System.Recipe.SubName, Global.System.Recipe.ModelCode, nRowIndex);
                }

                
                UpdateModelCode();

                if (Grid_ModelCODE.SelectedRows.Count == 0)
                {
                    return;
                }

                Grid_ModelCODE.Rows[Grid_ModelCODE.SelectedRows[0].Index + 1].Selected = true;
            }
            catch (Exception ex)
            {

                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
        private void grid_DATA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cogDisplay_Source.StaticGraphics.Clear();
                cogDisplay_Source.InteractiveGraphics.Clear();

                //SelectGridRow = e.RowIndex;
                int nSelect_Index = e.RowIndex;
                List<string> RowData = new List<string>();
                List<string> selectRow_Data = new List<string>();

                if (grid_DATA.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = grid_DATA.Rows[nSelect_Index];

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        RowData.Add(row.Cells[i].Value.ToString());
                    }

                    selectRow_Data = RowData;

                }

                CogImageFile cogImageFile = new CogImageFile();
                
                string imagePath = selectRow_Data[8];

                cogImageFile.Open(imagePath, CogImageFileModeConstants.Read);
                if (cogImageFile.Count > 0)
                {
                    ICogImage image = cogImageFile[0];
                    CogImageConvertTool cogImageConverter = new CogImageConvertTool();
                    cogImageConverter.InputImage = image;
                    cogImageConverter.Run();
                    CogImage24PlanarColor cogColorImage = new CogImage24PlanarColor((CogImage24PlanarColor)image);

                    m_imgSource_Color = new CogImage24PlanarColor((CogImage24PlanarColor)image);
                    m_imgSource_Mono = (CogImage8Grey)cogImageConverter.OutputImage;

                    cogDisplay_Source.Image = m_imgSource_Color;
                    cogDisplay_Source.Fit(true);
                }

            }
            catch (Exception ex)
            {

                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void grid_DATA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOCVROI_Click(object sender, EventArgs e)
        {

            try
            {
                int nIndex = nSelect_OCR_Index;

                if (!m_imgSource_Mono.Allocated)
                {
                    MessageBox.Show("IMAGE NOTHING");
                    return;
                }
                

                if (cbCamera.SelectedIndex == 0)
                {
                    CVisionTools.OCR[nIndex].OCR.New_RectangleROI(cogDisplay_Source, m_imgSource_Mono);
                }
                else
                {
                    CVisionTools.OCR2[nIndex].OCR.New_RectangleROI(cogDisplay_Source, m_imgSource_Mono);
                }



            }
            catch (Exception ex)
            {

                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

        }

        private void btnOCVadd_Click(object sender, EventArgs e)
        {
            try
            {
                string str_Name = tbOCVName.Text;
                bool bInspectionUse = chk_OCVUse.Checked;
                int nIndex = cbCamera.SelectedIndex;
                double dScoreMin = double.Parse(tbOCRSCORE.Text);

                string str_Compare = tbCOMPARESTRING.Text;
                string str_TrainOCR = tbTRAINOCR.Text;


                if (!m_imgSource_Mono.Allocated) { MessageBox.Show("NEED IMAGE"); return; }

                if (nIndex == 0)
                {
                    JOB_OCR job_OCR = new JOB_OCR($"JOB_{CVisionTools.OCR.Count.ToString()}");
                    job_OCR.Defect_Name = str_Name;
                    job_OCR.InspectionUse = bInspectionUse;
                    
                    job_OCR.COMPARE_STRING = str_Compare;
                    job_OCR.OCR.Tool.ClassifierRunParams.AcceptThreshold = dScoreMin;
                    //job_OCR.TRAIN_OCR = str_TrainOCR;

                    //동일한 이름이 있는지 확인
                    for (int i = 0; i < CVisionTools.OCR.Count; i++)
                    {
                        if (string.Equals(CVisionTools.OCR[i].Defect_Name, job_OCR.Defect_Name, StringComparison.OrdinalIgnoreCase))
                        {
                            CUtil.ShowMessageBox("NOTICE", "OCV NAME ALREADY EXISTS");
                            return;
                        }
                    }

                    CVisionTools.OCR.Add(job_OCR);

                    m_SelectedOCR = job_OCR;


                    CCogTool_OCR cCogTool_OCR = CVisionTools.OCR_CAM1;

                    propertyGrid_OCV.SelectedObject = m_SelectedOCR.OCR.Tool.ClassifierRunParams;


                    UpdateOCV(cbCamera.SelectedIndex);


                    //제일 마지막 행을 선택되도록 함
                    grid_OCV.Rows[CVisionTools.OCR.Count - 1].Selected = true;
                    grid_OCV.Rows[CVisionTools.OCR.Count - 1].Cells[0].Selected = true;
                }
                else
                {
                    JOB_OCR job_OCR = new JOB_OCR($"JOB_{CVisionTools.OCR2.Count.ToString()}");
                    job_OCR.Defect_Name = str_Name;
                    job_OCR.InspectionUse = bInspectionUse;

                    job_OCR.COMPARE_STRING = str_Compare;
                    job_OCR.OCR.Tool.ClassifierRunParams.AcceptThreshold = dScoreMin;
                    //job_OCR.TRAIN_OCR = str_TrainOCR;

                    //동일한 이름이 있는지 확인
                    for (int i = 0; i < CVisionTools.OCR2.Count; i++)
                    {
                        if (string.Equals(CVisionTools.OCR2[i].Defect_Name, job_OCR.Defect_Name, StringComparison.OrdinalIgnoreCase))
                        {
                            CUtil.ShowMessageBox("NOTICE", "OCV NAME ALREADY EXISTS");
                            return;
                        }
                    }

                    CVisionTools.OCR2.Add(job_OCR);

                    m_SelectedOCR = job_OCR;

                    CCogTool_OCR cCogTool_OCR = CVisionTools.OCR_CAM2;

                    propertyGrid_OCV.SelectedObject = m_SelectedOCR.OCR.Tool.ClassifierRunParams;


                    UpdateOCV(cbCamera.SelectedIndex);

                    //제일 마지막 행을 선택되도록 함
                    grid_OCV.Rows[CVisionTools.OCR2.Count - 1].Selected = true;
                    grid_OCV.Rows[CVisionTools.OCR2.Count - 1].Cells[0].Selected = true;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                CUtil.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }

        private void btnOCVapply_Click(object sender, EventArgs e)
        {
            try
            {

                string str_Name = tbOCVName.Text;
                bool bInspectionUse = chk_OCVUse.Checked;

                int nCamIndex = cbCamera.SelectedIndex;
                int nIndex = nSelect_OCR_Index;

                double dScoreMin = double.Parse(tbOCRSCORE.Text);
                string str_Compare = tbCOMPARESTRING.Text;
                string str_TrainOCR = tbTRAINOCR.Text;
                //double Score = double.Parse(tbColorSCORE.Text);

                if (m_SelectedOCR == null)
                {
                    CUtil.ShowMessageBox("ALRAM", "INSPECTION LIST CREATE.");
                    return;
                }

                if (grid_OCV.SelectedRows.Count > 0)
                {
                    m_SelectedOCR.Defect_Name = str_Name;
                    m_SelectedOCR.InspectionUse = bInspectionUse;
                    m_SelectedOCR.COMPARE_STRING = str_Compare;
                    //m_SelectedOCR.TRAIN_OCR = str_TrainOCR;
                    m_SelectedOCR.OCR.Tool.ClassifierRunParams.AcceptThreshold = dScoreMin;

                    if (cbCamera.SelectedIndex == 0)
                    {
                        CVisionTools.OCR.RemoveAt(nIndex);
                        CVisionTools.OCR.Insert(nIndex, m_SelectedOCR);
                    }
                    else
                    {
                        CVisionTools.OCR2.RemoveAt(nIndex);
                        CVisionTools.OCR2.Insert(nIndex, m_SelectedOCR);
                    }



                    grid_OCV.SelectedRows[0].SetValues(new object[] { m_SelectedOCR.Defect_Name, m_SelectedOCR.InspectionUse.ToString(), m_SelectedOCR.COMPARE_STRING });
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnOCVdelete_Click(object sender, EventArgs e)
        {
            try
            {
                int camindex = cbCamera.SelectedIndex;
                if (grid_OCV.SelectedRows.Count > 0)
                {
                    int nRowIndex = grid_OCV.SelectedRows[0].Index;

                    if (camindex == 0)
                    {
                        CVisionTools.OCR.RemoveAt(nRowIndex);
                    }
                    else
                    {
                        CVisionTools.OCR2.RemoveAt(nRowIndex);
                    }

                }

               
                UpdateOCV(camindex);

                if (grid_OCV.SelectedRows.Count == 0)
                {
                    return;
                }

                grid_OCV.Rows[grid_OCV.SelectedRows[0].Index + 1].Selected = true;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnOCVSelectRead_Click(object sender, EventArgs e)
        {
            CogRectangleAffine OriginRectangle = new CogRectangleAffine();
            CogRectangleAffine MoveRectangle = new CogRectangleAffine();
            double tmpX = new double();
            double tmpY = new double();

            try
            {
                int nCamIndex = cbCamera.SelectedIndex;
                int nIndex = nSelect_OCR_Index;

                CCogTool_OCR job_OCR = null;
                CogGraphicLabel label = new CogGraphicLabel();

                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();

                if (nCamIndex == 0)
                {
                    if (CVisionTools.OCR.Count == 0) return;
                    CVisionTools.tmpOCR = CVisionTools.OCR;
                    job_OCR = CVisionTools.OCR[nIndex].OCR;

                }
                else
                {
                    if (CVisionTools.OCR2.Count == 0) return;
                    CVisionTools.tmpOCR = CVisionTools.OCR2;
                    job_OCR = CVisionTools.OCR2[nIndex].OCR;

                }

                //Region Offset
                (tmpX, tmpY) = CVisionTools.RegionOffSet(cbCamera.SelectedIndex, cogDisplay_Source, m_imgSource_Mono);
                (OriginRectangle, MoveRectangle) = CVisionTools.AffineRegionRect(job_OCR.Tool.Region, tmpX, tmpY);
                job_OCR.Tool.Region = MoveRectangle;


                //string strPath = $"{Application.StartupPath}\\font1.ocr";
                //job_OCR.Tool.Classifier.Font.Import(strPath);
                if (job_OCR.Tool.Classifier.Font.Count > 0)
                {
                    //job_OCR.Tool.Segmenter.Polarity = CogOCRMaxPolarityConstants.Unknown;
                    job_OCR.Tool.InputImage = m_imgSource_Mono;
                    job_OCR.Tool.Run();
                    CogOCRMaxLineResult cogOCRMaxPositionResults = job_OCR.Tool.LineResult;

                    string result = cogOCRMaxPositionResults.ResultString;
                    lbREADINGOCR.Text = result;

                    string ReverseCompare = CUtil.String_Reverse(CVisionTools.tmpOCR[nIndex].COMPARE_STRING);

                    if (result.Contains(CVisionTools.tmpOCR[nIndex].COMPARE_STRING) || result.Contains(ReverseCompare)) //OK
                    {

                        label.Color = CogColorConstants.Green;
                        label.Text = "OCR OK";
                        label.Font = new Font("arial", 10);
                        label.X = m_SelectedOCR.OCR.Tool.Region.CenterX;
                        label.Y = m_SelectedOCR.OCR.Tool.Region.CenterY;

                        cogDisplay_Source.StaticGraphics.Add(m_SelectedOCR.OCR.Tool.Region, "");
                        cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                    }
                    else //NG
                    {
                        label.Color = CogColorConstants.Red;
                        label.Text = "OCR NG";
                        label.Font = new Font("arial", 10);
                        label.X = m_SelectedOCR.OCR.Tool.Region.CenterX;
                        label.Y = m_SelectedOCR.OCR.Tool.Region.CenterY;

                        cogDisplay_Source.StaticGraphics.Add(m_SelectedOCR.OCR.Tool.Region, "");
                        cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                    }
                }
                else
                {
                    label.Color = CogColorConstants.Red;
                    label.Text = "FONT NOTHING NG";
                    label.Font = new Font("arial", 10);
                    label.X = m_SelectedOCR.OCR.Tool.Region.CenterX;
                    label.Y = m_SelectedOCR.OCR.Tool.Region.CenterY;

                    cogDisplay_Source.StaticGraphics.Add(m_SelectedOCR.OCR.Tool.Region, "");
                    cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                }



                job_OCR.Tool.Region = OriginRectangle;


            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void grid_OCV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();

                nSelect_OCR_Index = e.RowIndex;

                if (grid_OCV.SelectedRows.Count > 0)
                {
                    int nIndex = grid_OCV.SelectedRows[0].Index;

                    if (cbCamera.SelectedIndex == 0)
                    {
                        m_SelectedOCR = CVisionTools.OCR[nIndex];
                    }
                    else
                    {
                        m_SelectedOCR = CVisionTools.OCR2[nIndex];
                    }


                    tbOCVName.Text = m_SelectedOCR.Defect_Name;
                   

                    chk_OCVUse.Checked = m_SelectedOCR.InspectionUse;
                    tbOCRSCORE.Text = m_SelectedOCR.OCR.Tool.ClassifierRunParams.AcceptThreshold.ToString();
                    tbCOMPARESTRING.Text = m_SelectedOCR.COMPARE_STRING;
                    //tbTRAINOCR.Text = m_SelectedOCR.TRAIN_OCR;

                    
                    cboOCRINDEX.Items.Clear();
                    for (int i = 0; i < m_SelectedOCR.OCR.Tool.Classifier.Font.Count; i++)
                    {
                        //cboOCRINDEX.Items.Add(i + 1);
                        cboOCRINDEX.Items.Add((i + 1).ToString() + ". OCR:" + ((char)m_SelectedOCR.OCR.Tool.Classifier.Font[i].CharacterCode));
                    }


                    propertyGrid_OCV.SelectedObject = m_SelectedOCR.OCR.Tool.ClassifierRunParams;
                }

                // UI 디스플레이
                if (cogDisplay_Source.Image == null || cogDisplay_Source.Image.Allocated == false) return; // 이미지가 없으면 ROI를 그려주지않음

                if (cbCamera.SelectedIndex == 0)
                {
                    if (CVisionTools.OCR.Count == 0) return;
                    if (CVisionTools.OCR[nSelect_OCR_Index].OCR.Tool.Region == null) return;



                    cogDisplay_Source.InteractiveGraphics.Add(CVisionTools.OCR[nSelect_OCR_Index].OCR.Tool.Region, "Roi", false);
                }
                else
                {
                    if (CVisionTools.OCR2.Count == 0) return;
                    if (CVisionTools.OCR2[nSelect_OCR_Index].OCR.Tool.Region == null) return;

                    cogDisplay_Source.InteractiveGraphics.Add(CVisionTools.OCR2[nSelect_OCR_Index].OCR.Tool.Region, "Roi", false);
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void grid_OCV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOCRTrainRegion_Click(object sender, EventArgs e)
        {
            try
            {
                int nIndex = nSelect_OCR_Index;

                if (m_SelectedOCR == null)
                {
                    CUtil.ShowMessageBox("NOTICE", "SELECT OCR.");
                    return;
                }

                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();


                if (cbCamera.SelectedIndex == 0)
                {
                    CVisionTools.OCR[nIndex].OCR.New_TrainRegion(cogDisplay_Source, m_imgSource_Mono);
                }
                else
                {
                    CVisionTools.OCR2[nIndex].OCR.New_TrainRegion(cogDisplay_Source, m_imgSource_Mono);
                }

                ////propertyGrid_OCV.SelectedObject = m_SelectedOCR.OCR.Tool.ClassifierRunParams;

                //TrainOCR = new CogOCRMaxTool();

                //ViewOCRTrainRegion(TrainOCR, cogDisplay_Source);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        CogRectangleAffine[] aRoi = null;
        private void ViewOCRTrainRegion(CogOCRMaxTool tool, CogDisplay display)
        {
            try
            {
                if (tool.Region == null) tool.Region = new CogRectangleAffine();

                

                aRoi = new CogRectangleAffine[2];

                for(int i = 0; i< aRoi.Length; i++)
                {
                    aRoi[i] = tool.Region;
                }

                tool.Region.Interactive = true;

                display.InteractiveGraphics.Add((ICogGraphicInteractive)tool.Region, "", false);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

        }

        private void btnOCRTRAIN_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_SelectedOCR.OCR.Rect_Train_Region != null)
                {
                    string TrainOCR = tbTRAINOCR.Text;
                    bool train = false;

                    train = m_SelectedOCR.OCR.Font_Train(m_imgSource_Mono, TrainOCR);

                    if(train)
                    {
                        cboOCRINDEX.Items.Clear();
                        for(int i = 0; i < m_SelectedOCR.OCR.Tool.Classifier.Font.Count; i++)
                        {
                            //cboOCRINDEX.Items.Add(i + 1);
                            cboOCRINDEX.Items.Add((i + 1).ToString() + ". OCR:" + ((char)m_SelectedOCR.OCR.Tool.Classifier.Font[i].CharacterCode));
                        }
                        
                    }



                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void cboOCRINDEX_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = cboOCRINDEX.SelectedIndex;

                if (m_SelectedOCR == null) return;

                if(m_SelectedOCR.OCR.Tool.Classifier.Font.Count > 0)
                {
                    cogdisplay_TrainOCR.Image = m_SelectedOCR.OCR.Tool.Classifier.Font[index].Image;
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnTRAINDELETE_Click(object sender, EventArgs e)
        {
            try
            {
                int index = cboOCRINDEX.SelectedIndex;

                if (m_SelectedOCR == null) return;

                m_SelectedOCR.OCR.Tool.Classifier.Font.RemoveAt(index);

                cboOCRINDEX.Items.Clear();
                for (int i = 0; i < m_SelectedOCR.OCR.Tool.Classifier.Font.Count; i++)
                {
                    //cboOCRINDEX.Items.Add(i + 1);
                    cboOCRINDEX.Items.Add((i + 1).ToString() + ". OCR:" + ((char)m_SelectedOCR.OCR.Tool.Classifier.Font[i].CharacterCode));
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnOCVAllRead_Click(object sender, EventArgs e)
        {
            CogRectangleAffine OriginRectangle = new CogRectangleAffine();
            CogRectangleAffine MoveRectangle = new CogRectangleAffine();
            double tmpX = new double();
            double tmpY = new double();

            try
            {
                int nCamIndex = cbCamera.SelectedIndex;
                int nIndex = nSelect_OCR_Index;

                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();

                CogGraphicCollection cogList = new CogGraphicCollection();
                CogGraphicLabel label = new CogGraphicLabel();

                if (nCamIndex == 0)
                {
                    if (CVisionTools.OCR.Count == 0) return;
                    CVisionTools.tmpOCR = CVisionTools.OCR;
                    
                }
                else
                {
                    if (CVisionTools.OCR2.Count == 0) return;
                    CVisionTools.tmpOCR = CVisionTools.OCR2;
                    
                }

                for(int i = 0; i < CVisionTools.tmpOCR.Count; i++)
                {
                    if(CVisionTools.tmpOCR[i].InspectionUse)
                    {
                        if(CVisionTools.tmpOCR[i].OCR.Tool.Classifier.Font.Count > 0)
                        {
                            //Region Offset
                            (tmpX, tmpY) = CVisionTools.RegionOffSet(cbCamera.SelectedIndex, cogDisplay_Source, m_imgSource_Mono);
                            (OriginRectangle, MoveRectangle) = CVisionTools.AffineRegionRect(CVisionTools.tmpOCR[i].OCR.Tool.Region, tmpX, tmpY);
                            CVisionTools.tmpOCR[i].OCR.Tool.Region = MoveRectangle;


                            string result = CVisionTools.tmpOCR[i].OCR.Run(m_imgSource_Mono);
                            string ReverseCompare = CUtil.String_Reverse(CVisionTools.tmpOCR[i].COMPARE_STRING);

                            if (result.Contains(CVisionTools.tmpOCR[i].COMPARE_STRING) || result.Contains(ReverseCompare)) //OK
                            {
                                label.Color = CogColorConstants.Green;
                                label.Text = "OCR OK";
                                label.Font = new Font("arial", 10);
                                label.X = CVisionTools.tmpOCR[i].OCR.Tool.Region.CenterX;
                                label.Y = CVisionTools.tmpOCR[i].OCR.Tool.Region.CenterY;


                                cogList.Add(CVisionTools.tmpOCR[i].OCR.Tool.Region);
                                cogList.Add(label);
                                //cogDisplay_Source.StaticGraphics.Add(m_SelectedOCR.OCR.Tool.Region, "");
                                //cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                            }// NG
                            else
                            {
                                label.Color = CogColorConstants.Red;
                                label.Text = "OCR NG";
                                label.Font = new Font("arial", 10);
                                label.X = CVisionTools.tmpOCR[i].OCR.Tool.Region.CenterX;
                                label.Y = CVisionTools.tmpOCR[i].OCR.Tool.Region.CenterY;


                                cogList.Add(CVisionTools.tmpOCR[i].OCR.Tool.Region);
                                cogList.Add(label);
                            }

                        }
                        else
                        {
                            //ng Font nothing
                            label.Color = CogColorConstants.Red;
                            label.Text = "FONT NOTHING";
                            label.Font = new Font("arial", 10);
                            label.X = CVisionTools.tmpOCR[i].OCR.Tool.Region.CenterX;
                            label.Y = CVisionTools.tmpOCR[i].OCR.Tool.Region.CenterY;

                            cogList.Add(CVisionTools.tmpOCR[i].OCR.Tool.Region);
                            cogList.Add(label);
                        }

                        cogDisplay_Source.StaticGraphics.AddList(cogList, "");
                    }
                    else
                    {
                        //pass
                    }

                    CVisionTools.tmpOCR[i].OCR.Tool.Region = OriginRectangle;
                }



            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnOCRAllDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int nCamIndex = cbCamera.SelectedIndex;
                int nIndex = nSelect_OCR_Index;

                if (m_SelectedOCR == null) return;

                if(m_SelectedOCR.OCR.Tool.Classifier.Font.Count > 0)
                {
                    m_SelectedOCR.OCR.Tool.Classifier.Font.Clear();

                    cboOCRINDEX.Items.Clear();
                }

                

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnColorMatchRegionSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strRecipe = IGlobal.Instance.System.Recipe.Name;
                string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipe}\\TrainMaster";
                string filePath = "";
                int nCamIndex = cbCamera.SelectedIndex + 1;
                int selectColorIndex = GridColor.SelectedRows[0].Index;
                string selectColorName = m_SelectedColor.Defect_Name;
                if (cogDisplay_Pattern.Image == null)
                {
                    CUtil.ShowMessageBox("NO IMAGE", "Please proceed with Train");
                    return;
                }
                else
                {
                    if (!System.IO.Directory.Exists(strPath))
                    {
                        System.IO.Directory.CreateDirectory(strPath);
                    }

                    if (CUtil.ShowMessageBox("SAVE", "Do you want to Master Train Image save?", FormMessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                    {

                        for (int i = 0; i < CVisionTools.ColorMatch.Count; i++)
                        {
                            ICogImage img = CVisionTools.Run_CopyRegion(m_imgSource_Color, CVisionTools.ColorMatch[i].COLORMATCH.Tool.Region as CogRectangle);
                            //filePath = strPath + $"TrainImage_{selectJobIndex}" + ".bmp";
                            filePath = strPath + "\\COLORMATCH_" + CVisionTools.ColorMatch[i].Defect_Name + ".png";
                            //Common.SaveImageFileToBMP(image, filePath);
                            Common.SaveImageFileToPNG(img, filePath);

                        }


                        CUtil.ShowMessageBox("SAVE", "The Master Train image has been saved.");
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnOCRREGIONIMAGESAVE_Click(object sender, EventArgs e)
        {
            try
            {
                string strRecipe = IGlobal.Instance.System.Recipe.Name;
                string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipe}\\TrainMaster";
                string filePath = "";
                int nCamIndex = cbCamera.SelectedIndex + 1;
                int selectOCRIndex = grid_OCV.SelectedRows[0].Index;
                string selectOCRName = m_SelectedOCR.Defect_Name;
                if (cogDisplay_Pattern.Image == null)
                {
                    CUtil.ShowMessageBox("NO IMAGE", "Please proceed with Train");
                    return;
                }
                else
                {
                    if (!System.IO.Directory.Exists(strPath))
                    {
                        System.IO.Directory.CreateDirectory(strPath);
                    }

                    if (CUtil.ShowMessageBox("SAVE", "Do you want to Master Train Image save?", FormMessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                    {

                        for (int i = 0; i < CVisionTools.OCR.Count; i++)
                        {
                            ICogImage img = CVisionTools.Run_CopyRegion(m_imgSource_Color, CVisionTools.OCR[i].OCR.Tool.Region as CogRectangleAffine);
                            //filePath = strPath + $"TrainImage_{selectJobIndex}" + ".bmp";
                            filePath = strPath + "\\OCR_" + CVisionTools.OCR[i].Defect_Name + ".png";
                            //Common.SaveImageFileToBMP(image, filePath);
                            Common.SaveImageFileToPNG(img, filePath);
                        }


                        CUtil.ShowMessageBox("SAVE", "The Master Train image has been saved.");
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnMultiPMAlignToolAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string str_Name = tbMutiPMAlignName.Text;
                int nThreshold = trbThreshold.Value;
                double dScoreMin = double.Parse(tbMultiPMAlignScoreMIN.Text);
                int nMasterCount = 1;
                double dAngle = double.Parse(tbMultiPMAlignANGLE.Text);

                bool bNotOption = chk_MultiPMAlignNOTOPTIONUSE.Checked;
                bool bEqualizeUse = chk_MultiPMAlignEqualizeUSE.Checked;
                bool bQuantizeUse = chk_MultiPMAlignQuantizeUSE.Checked;
                int nQuantizeLevel = cboMultiPMAlignLEVEL.SelectedIndex;
                bool bInspectionUse = chk_MultiPMAlignUSE.Checked;
                bool bMaskingUse = chk_MultiPMAlignMASKINGUSE.Checked;
                bool bThresholdUse = chk_MultiPMAlignThresholdUSE.Checked;

                cogDisply_MultiPattern.StaticGraphics.Clear();


                if (cbCamera.SelectedIndex == 0)
                {
                    JOB_MUTIPMALIGN multiPM = new JOB_MUTIPMALIGN($"JOB_{CVisionTools.MultiPMAlign.Count.ToString()}");
                    multiPM.NAME = str_Name;
                    multiPM.INSP_TYPE = cboMultiPMAlignInsType.Text;
                    multiPM.MASTER_COUNT = nMasterCount;
                    multiPM.ANGLE = dAngle;

                    multiPM.NotOption = bNotOption;
                    multiPM.EqualizeUse = bEqualizeUse;
                    multiPM.QuantizeUse = bQuantizeUse;
                    multiPM.QuantizeLevel = nQuantizeLevel;
                    multiPM.InspectionUse = bInspectionUse;
                    multiPM.MaskingUse = bMaskingUse;
                    multiPM.ThresholdUse = bThresholdUse;
                    multiPM.ThresholdValue = nThreshold;

                    multiPM.Matching.Tool.RunParams.PMAlignRunParams.ScoreUsingClutter = false;
                    multiPM.Matching.Tool.RunParams.PMAlignRunParams.AcceptThreshold = double.Parse(tbMultiPMAlignScoreMIN.Text);
                    multiPM.Matching.Tool.RunParams.PMAlignRunParams.ApproximateNumberToFind = 1;
                    multiPM.Matching.Tool.RunParams.PMAlignRunParams.XYOverlap = 0.1;
                    multiPM.Matching.Tool.RunParams.PMAlignRunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatQuick;

                    multiPM.Matching.Tool.RunParams.RuntimeMode = CogPMAlignMultiRuntimeModeConstants.SequentialMostSuccessful;
                    // 동일한 이름이 있는지 확인
                    for (int i = 0; i < CVisionTools.MultiPMAlign.Count; i++)
                    {
                        if (string.Equals(CVisionTools.MultiPMAlign[i].NAME, multiPM.NAME, StringComparison.OrdinalIgnoreCase))
                        {
                            CUtil.ShowMessageBox("NOTICE", "MULTI PATTERN NAME ALREADY EXISTS");
                            return;
                        }
                    }

                    CVisionTools.MultiPMAlign.Add(multiPM);

                    m_SelectedMultiPMAlign = multiPM;

                    propertyGrid_MultiPMAlign.SelectedObject = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams;

                    
                    UpdateMultiPMAlign(cbCamera.SelectedIndex);

                    //제일 마지막 행을 선택되도록 함
                    gridMultiPMAlign.Rows[CVisionTools.MultiPMAlign.Count - 1].Selected = true;
                    gridMultiPMAlign.Rows[CVisionTools.MultiPMAlign.Count - 1].Cells[0].Selected = true;
                }
                else
                {
                    JOB_MUTIPMALIGN multiPM = new JOB_MUTIPMALIGN($"JOB_{CVisionTools.MultiPMAlign2.Count.ToString()}");
                    multiPM.NAME = str_Name;
                    multiPM.INSP_TYPE = cboMultiPMAlignInsType.Text;
                    multiPM.MASTER_COUNT = nMasterCount;
                    multiPM.ANGLE = dAngle;

                    multiPM.NotOption = bNotOption;
                    multiPM.EqualizeUse = bEqualizeUse;
                    multiPM.QuantizeUse = bQuantizeUse;
                    multiPM.QuantizeLevel = nQuantizeLevel;
                    multiPM.InspectionUse = bInspectionUse;
                    multiPM.MaskingUse = bMaskingUse;
                    multiPM.ThresholdUse = bThresholdUse;
                    multiPM.ThresholdValue = nThreshold;

                    multiPM.Matching.Tool.RunParams.PMAlignRunParams.AcceptThreshold = double.Parse(tbMultiPMAlignScoreMIN.Text);
                    multiPM.Matching.Tool.RunParams.PMAlignRunParams.ApproximateNumberToFind = 100;
                    multiPM.Matching.Tool.RunParams.PMAlignRunParams.XYOverlap = 0.1;
                    multiPM.Matching.Tool.RunParams.PMAlignRunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatQuick;

                    multiPM.Matching.Tool.RunParams.RuntimeMode = CogPMAlignMultiRuntimeModeConstants.SequentialMostSuccessful;
                    // 동일한 이름이 있는지 확인
                    for (int i = 0; i < CVisionTools.MultiPMAlign2.Count; i++)
                    {
                        if (string.Equals(CVisionTools.MultiPMAlign2[i].NAME, multiPM.NAME, StringComparison.OrdinalIgnoreCase))
                        {
                            CUtil.ShowMessageBox("NOTICE", "MULTI PATTERN ALREADY EXISTS");
                            return;
                        }
                    }

                    CVisionTools.MultiPMAlign2.Add(multiPM);

                    m_SelectedMultiPMAlign = multiPM;

                    propertyGrid_MultiPMAlign.SelectedObject = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams;


                    UpdateMultiPMAlign(cbCamera.SelectedIndex);

                    //제일 마지막 행을 선택되도록 함
                    gridMultiPMAlign.Rows[CVisionTools.MultiPMAlign2.Count - 1].Selected = true;
                    gridMultiPMAlign.Rows[CVisionTools.MultiPMAlign2.Count - 1].Cells[0].Selected = true;
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnMultiPMAlignToolAPLLY_Click(object sender, EventArgs e)
        {
            try
            {
                string str_Name = tbMutiPMAlignName.Text;
                int nMasterCount = 1;
                int nThreshold = trbThreshold.Value;
                double dScoreMin = double.Parse(tbMultiPMAlignScoreMIN.Text);
                double dAngle = double.Parse(tbMultiPMAlignANGLE.Text);
                
                int dQuantizeLevel = cboMultiPMAlignLEVEL.SelectedIndex;


                int nCamIndex = cbCamera.SelectedIndex;
                int nIndex = nSelect_MultiPMAlign_Index;

                if (m_SelectedMultiPMAlign == null)
                {
                    CUtil.ShowMessageBox("ALRAM", "SELECT PATTERN.");
                    return;
                }

                if (gridMultiPMAlign.SelectedRows.Count > 0)
                {
                    m_SelectedMultiPMAlign.NAME = str_Name;
                    m_SelectedMultiPMAlign.MASTER_COUNT = nMasterCount;
                    m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.AcceptThreshold = dScoreMin;
                    m_SelectedMultiPMAlign.ANGLE = dAngle;
                    m_SelectedMultiPMAlign.NotOption = chk_MultiPMAlignNOTOPTIONUSE.Checked;
                    m_SelectedMultiPMAlign.QuantizeUse = chk_MultiPMAlignQuantizeUSE.Checked;
                    m_SelectedMultiPMAlign.QuantizeLevel = dQuantizeLevel;
                    m_SelectedMultiPMAlign.EqualizeUse = chk_MultiPMAlignEqualizeUSE.Checked;
                    m_SelectedMultiPMAlign.InspectionUse = chk_MultiPMAlignUSE.Checked;
                    m_SelectedMultiPMAlign.MaskingUse = chk_MultiPMAlignMASKINGUSE.Checked;
                    m_SelectedMultiPMAlign.INSP_TYPE = cboMultiPMAlignInsType.Text;

                    m_SelectedMultiPMAlign.ThresholdUse = chk_MultiPMAlignThresholdUSE.Checked;
                    m_SelectedMultiPMAlign.ThresholdValue = nThreshold;

                    if (cbCamera.SelectedIndex == 0)
                    {
                        CVisionTools.MultiPMAlign.RemoveAt(nIndex);
                        CVisionTools.MultiPMAlign.Insert(nIndex, m_SelectedMultiPMAlign);
                    }
                    else
                    {
                        CVisionTools.MultiPMAlign2.RemoveAt(nIndex);
                        CVisionTools.MultiPMAlign2.Insert(nIndex, m_SelectedMultiPMAlign);
                    }


                    gridMultiPMAlign.SelectedRows[0].SetValues(new object[] { m_SelectedMultiPMAlign.NAME, m_SelectedMultiPMAlign.INSP_TYPE, m_SelectedMultiPMAlign.MASTER_COUNT, m_SelectedMultiPMAlign.ANGLE, m_SelectedMultiPMAlign.NotOption.ToString(), m_SelectedMultiPMAlign.QuantizeUse.ToString(), m_SelectedMultiPMAlign.QuantizeLevel.ToString(), m_SelectedMultiPMAlign.EqualizeUse.ToString(), m_SelectedMultiPMAlign.InspectionUse.ToString(), m_SelectedMultiPMAlign.MaskingUse.ToString(), m_SelectedMultiPMAlign.ThresholdUse.ToString(), m_SelectedMultiPMAlign.ThresholdValue.ToString() });
                }

                try
                {
                    m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.LowHigh;
                    m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.ZoneScale.High = double.Parse(tbMultiPMAlignScaleHIGH.Text);
                    m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.ZoneScale.Low = double.Parse(tbMultiPMAlignScaleLOW.Text);
                    m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.AcceptThreshold = double.Parse(tbMultiPMAlignScoreMIN.Text);
                    m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.ContrastThreshold = double.Parse(tbMultiPMAlignContrast.Text);

                    propertyGrid_MultiPMAlign.SelectedObject = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams;
                    propertyGrid_MultiPMAlign.Invalidate();
                }
                catch (Exception ex)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnMultiPMAlignToolDELETE_Click(object sender, EventArgs e)
        {
            try
            {
                int camindex = cbCamera.SelectedIndex;
                if (gridMultiPMAlign.SelectedRows.Count > 0)
                {
                    int nRowIndex = gridMultiPMAlign.SelectedRows[0].Index;


                    if (camindex == 0)
                    {
                        CVisionTools.MultiPMAlign.RemoveAt(nRowIndex);
                    }
                    else
                    {
                        CVisionTools.MultiPMAlign2.RemoveAt(nRowIndex);
                    }

                }

                
                UpdateMultiPMAlign(camindex);

                if (gridMultiPMAlign.SelectedRows.Count == 0)
                {
                    return;
                }

                gridMultiPMAlign.Rows[gridMultiPMAlign.SelectedRows[0].Index + 1].Selected = true;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnMultiPMAlignSetting_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_SelectedMultiPMAlign == null)
                {
                    CUtil.ShowMessageBox("NOTICE", "SELECT THE PATTERN.");
                    return;
                }

                cogDisplay_Source.InteractiveGraphics.Clear();
                cogDisplay_Source.StaticGraphics.Clear();

                propertyGrid_MultiPMAlign.SelectedObject = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams;

                ViewMultiPatternRegion(m_SelectedMultiPMAlign.Matching.Tool, cogDisplay_Source);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
        private void gridMultiPMAlign_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cogDisplay_Source.StaticGraphics.Clear();
                cogDisplay_Pattern.StaticGraphics.Clear();
                nSelect_MultiPMAlign_Index = e.RowIndex;

                if (gridMultiPMAlign.SelectedRows.Count > 0)
                {
                    int nIndex = gridMultiPMAlign.SelectedRows[0].Index;

                    if (cbCamera.SelectedIndex == 0)
                    {
                        m_SelectedMultiPMAlign = CVisionTools.MultiPMAlign[nIndex];
                    }
                    else
                    {
                        m_SelectedMultiPMAlign = CVisionTools.MultiPMAlign2[nIndex];
                    }

                    UpdateSelectedMultiPMAlign();
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void gridMultiPMAlign_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMultiPMAlignTRAIN_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_SelectedMultiPMAlign == null)
                {
                    CUtil.ShowMessageBox("Alram", "SELECT JOB.");
                    return;
                }

                if (m_SelectedMultiPMAlign.EqualizeUse)
                {
                    ICogImage image = null;
                    image = CVisionTools.Equalize.Run(m_imgSource_Mono, null);
                    m_imgSource_Equalize = image as CogImage8Grey;
                    m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainImage = m_imgSource_Equalize;
                }
                else if (m_SelectedMultiPMAlign.QuantizeUse)
                {
                    ICogImage image = null;
                    image = CVisionTools.Quantize.Run(m_imgSource_Mono, null, m_SelectedMultiPMAlign.QuantizeLevel);
                    m_imgSource_Quantize = image as CogImage8Grey;
                    m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainImage = m_imgSource_Quantize;
                }
                else if (m_SelectedMultiPMAlign.ThresholdUse)
                {
                    using (Mat imgSource = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Mono.ToBitmap()))
                    using (Mat imgBin = new Mat())
                    {
                        Cv2.Threshold(imgSource, imgBin, m_SelectedMultiPMAlign.ThresholdValue, 255, ThresholdTypes.Binary);

                        CogImage8Grey imgCogSource = new CogImage8Grey(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgBin));
                        m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainImage = imgCogSource;
                    }
                }
                else
                {
                    m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainImage = m_imgSource_Mono;
                }

                if (m_SelectedMultiPMAlign.MaskingUse)
                {
                    m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainImageMask = IGlobal.Instance.m_FileManager.MaskingImageLoad(cbCamera.SelectedIndex + 1, IGlobal.Instance.System.Recipe.Name, m_SelectedMultiPMAlign.NAME, m_SelectedMultiPMAlign.Matching.Tool);
                }
                else
                {
                    m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainImageMask = null;
                }

                

                if (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion is CogCircle)
                {
                    m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.Origin.TranslationX = (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion as CogCircle).CenterX;
                    m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.Origin.TranslationY = (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion as CogCircle).CenterY;

                }

                if (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion is CogRectangleAffine)
                {
                    m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.Origin.TranslationX = (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion as CogRectangleAffine).CenterX;
                    m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.Origin.TranslationY = (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainRegion as CogRectangleAffine).CenterY;

                }

                

                m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.RunMode = CogPMAlignRunModeConstants.SearchImage;
                m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatQuick;
                m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.GrainLimitsUsePattern = true;
                m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams.ScoreUsingClutter = false;

                m_SelectedMultiPMAlign.Matching.PMAlign.SearchRegion = m_SelectedMultiPMAlign.Matching.Tool.SearchRegion;
                m_SelectedMultiPMAlign.Matching.PMAlign.RunParams = m_SelectedMultiPMAlign.Matching.Tool.RunParams.PMAlignRunParams;
                m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.TrainAlgorithm = CogPMAlignTrainAlgorithmConstants.PatQuick;
                m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.Train();

                if (m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.Trained)
                {
                    cogDisply_MultiPattern.Image = m_SelectedMultiPMAlign.Matching.PMAlign.Pattern.GetTrainedPatternImage();
                    cogDisply_MultiPattern.StaticGraphics.AddList(TrainGraphic(cogDisply_MultiPattern, m_SelectedMultiPMAlign.Matching.PMAlign), "");
                    cogDisply_MultiPattern.Fit(true);

                    CogPMAlignPatternItem cogPMAlignPatternItem = new CogPMAlignPatternItem();
                    cogPMAlignPatternItem.Name = (m_SelectedMultiPMAlign.Matching.Tool.Operator.Count + 1).ToString();
                    cogPMAlignPatternItem.Pattern = m_SelectedMultiPMAlign.Matching.PMAlign.Pattern;
                    
                    m_SelectedMultiPMAlign.Matching.Tool.Operator.Add(cogPMAlignPatternItem);
                    m_SelectedMultiPMAlign.Matching.Tool.Operator.TrainAlgorithm = CogPMAlignTrainAlgorithmConstants.PatQuick;

                    m_SelectedMultiPMAlign.Matching.Tool.Operator.Train();

                    cboPatternINDEX.Items.Clear();
                    List<bool> run = new List<bool>();
                    for (int i = 0; i < m_SelectedMultiPMAlign.Matching.Tool.Operator.Count; i++)
                    {
                        cboPatternINDEX.Items.Add(i + 1);
                        
                    }
                    

                    

                }

               

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnMultiPMAlignRunSelected_Click(object sender, EventArgs e)
        {
            cogDisplay_Source.InteractiveGraphics.Clear();
            cogDisplay_Source.StaticGraphics.Clear();

            CogRectangle OriginRectangle = new CogRectangle();
            CogRectangle MoveRectangle = new CogRectangle();
            double tmpX = new double();
            double tmpY = new double();

            try
            {
               

                Stopwatch sw_TactTime = new Stopwatch();
                sw_TactTime.Start();

                if (m_SelectedMultiPMAlign == null) return;

                //Region Offset
                (tmpX, tmpY) = CVisionTools.RegionOffSet(cbCamera.SelectedIndex,cogDisplay_Source,m_imgSource_Mono);
                (OriginRectangle, MoveRectangle) = CVisionTools.RegionRect(m_SelectedMultiPMAlign.Matching.Tool.SearchRegion, tmpX, tmpY);
                m_SelectedMultiPMAlign.Matching.Tool.SearchRegion = MoveRectangle;

                


                if (m_SelectedMultiPMAlign.EqualizeUse)
                {
                    ICogImage image = null;
                    image = CVisionTools.Equalize.Run(m_imgSource_Mono, null);
                    m_imgSource_Equalize = image as CogImage8Grey;
                    
                    m_SelectedMultiPMAlign.Matching.Tool.InputImage = m_imgSource_Equalize;
                }
                else if (m_SelectedMultiPMAlign.QuantizeUse)
                {
                    ICogImage image = null;
                    image = CVisionTools.Quantize.Run(m_imgSource_Mono, null, m_SelectedMultiPMAlign.QuantizeLevel);
                    m_imgSource_Quantize = image as CogImage8Grey;
                    
                    m_SelectedMultiPMAlign.Matching.Tool.InputImage = m_imgSource_Quantize;
                }
                else if (m_SelectedMultiPMAlign.ThresholdUse)
                {
                    using (Mat imgSource = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Mono.ToBitmap()))
                    using (Mat imgBin = new Mat())
                    {
                        Cv2.Threshold(imgSource, imgBin, m_SelectedMultiPMAlign.ThresholdValue, 255, ThresholdTypes.Binary);

                        CogImage8Grey imgCogSource = new CogImage8Grey(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgBin));
                        m_SelectedMultiPMAlign.Matching.Tool.InputImage = imgCogSource;
                    }
                }
                else
                {
                    
                    m_SelectedMultiPMAlign.Matching.Tool.InputImage = m_imgSource_Mono;
                }

                CogPMAlignResults cogPMAlignResults = new CogPMAlignResults();

                cogPMAlignResults = m_SelectedMultiPMAlign.Matching.MultiPattern_Run(m_SelectedMultiPMAlign.Matching.Tool, m_SelectedMultiPMAlign.Matching.Tool.InputImage);


                if (cogPMAlignResults != null)
                {
                    

                    if (m_SelectedMultiPMAlign.Matching.Tool.SearchRegion != null) cogDisplay_Source.StaticGraphics.Add((ICogGraphicInteractive)m_SelectedMultiPMAlign.Matching.Tool.SearchRegion, "ROI");



                    for (int i = 0; i < cogPMAlignResults.Count; i++)
                    {
                        CogRectangle Draw = new CogRectangle();
                        CogCompositeShape resultDrawing = cogPMAlignResults[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.BoundingBox);

                        CogGraphicLabel label = new CogGraphicLabel();
                        CogGraphicLabel labelResult = new CogGraphicLabel();
                        //Set X-position to 100
                        label.X = cogPMAlignResults[i].GetPose().TranslationX;
                        label.Y = cogPMAlignResults[i].GetPose().TranslationY;
                        labelResult.X = cogPMAlignResults[i].GetPose().TranslationX;
                        labelResult.Y = cogPMAlignResults[i].GetPose().TranslationY + 30;
                        labelResult.Color = CogColorConstants.Green;
                        labelResult.Font = new Font("arial", 12, FontStyle.Bold);
                        cogDisplay_Source.InteractiveGraphics.Add(cogPMAlignResults[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin), "main", false);
                        cogDisplay_Source.InteractiveGraphics.Add(cogPMAlignResults[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.TipText), "main", false);

                        double dRotation = cogPMAlignResults[i].GetPose().Rotation * 180 / Math.PI;

                        labelResult.Text = $"Score : {cogPMAlignResults[i].Score.ToString("F2")}% Angle : {dRotation.ToString("F1")}";
                        cogDisplay_Source.InteractiveGraphics.Add(labelResult, "main", false);

                        lbMutiPMAlignSCORE.Text = $"Detected Score : {cogPMAlignResults[i].Score.ToString("F2")}";

                        if (Math.Abs(dRotation) > m_SelectedMultiPMAlign.ANGLE)
                        {
                            if(m_SelectedMultiPMAlign.INSP_TYPE.Contains("REVERSE"))
                            {
                                label.Color = CogColorConstants.Red;

                                label.Text = "REVERSE";
                                label.Font = new Font("arial", 24);

                                resultDrawing.Color = CogColorConstants.Red;

                                cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                            }
                            
                        }
                        else
                        {
                            if (m_SelectedMultiPMAlign.NotOption)
                            {
                                label.Color = CogColorConstants.Red;

                                label.Text = "Not Option NG";
                                label.Font = new Font("arial", 24);

                                resultDrawing.Color = CogColorConstants.Red;

                                cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                            }
                            else
                            {
                                resultDrawing.Color = CogColorConstants.Green;
                            }

                        }

                        //cogDisplay_Source.Image = imgOutput_Color;

                        cogDisplay_Source.StaticGraphics.Add((ICogGraphic)resultDrawing, "main");

                        //cogDisplay_Source.InteractiveGraphics.Add(PMAlignTool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.TipText), "main", false);
                    }
                }
                // 미삽일때 라벨위치 지정 ROI Center로
                if (cogPMAlignResults == null || cogPMAlignResults.Count == 0)
                {
                    CogGraphicLabel label = new CogGraphicLabel();
                    CogRectangle rt = new CogRectangle();
                    
                    rt = m_SelectedMultiPMAlign.Matching.Tool.SearchRegion as CogRectangle;

                    
                    if (m_SelectedMultiPMAlign.NotOption)
                    {
                        label.Color = CogColorConstants.Green;
                        label.Text = "Not Option OK";
                        label.Font = new Font("arial", 24);
                        label.X = rt.CenterX;
                        label.Y = rt.CenterY;
                    }
                    else
                    {
                        label.Color = CogColorConstants.Red;
                        label.Text = "N/A";
                        label.Font = new Font("arial", 24);
                        label.X = rt.CenterX;
                        label.Y = rt.CenterY;
                    }


                    cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                }

                m_SelectedMultiPMAlign.Matching.Tool.SearchRegion = OriginRectangle;

                sw_TactTime.Stop();
                lbTackTime.Text = sw_TactTime.ElapsedMilliseconds.ToString() + "ms";

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                m_SelectedMultiPMAlign.Matching.Tool.SearchRegion = OriginRectangle;
            }
        }

        private void btn_MultiPMAlignTrainImage_Click(object sender, EventArgs e)
        {
            try
            {
                string strRecipe = IGlobal.Instance.System.Recipe.Name;
                string strPath = $"{Application.StartupPath}\\RECIPE\\{strRecipe}\\TrainMaster";
                string filePath = "";
                int nCamIndex = cbCamera.SelectedIndex + 1;
                int selectJobIndex = gridMultiPMAlign.SelectedRows[0].Index;
                string selectJobName = m_SelectedMultiPMAlign.NAME;
                if (cogDisply_MultiPattern.Image == null)
                {
                    CUtil.ShowMessageBox("NO IMAGE", "Please proceed with Train");
                    return;
                }
                else
                {


                    if (!System.IO.Directory.Exists(strPath))
                    {
                        System.IO.Directory.CreateDirectory(strPath);
                    }

                    if (CUtil.ShowMessageBox("SAVE", "Do you want to Master Train Image save?", FormMessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                    {

                        



                        for (int i = 0; i < CVisionTools.MultiPMAlign.Count; i++)
                        {
                            ICogImage img = CVisionTools.Run_CopyRegion(m_imgSource_Color, CVisionTools.MultiPMAlign[i].Matching.Tool.SearchRegion as CogRectangle);
                            //filePath = strPath + $"TrainImage_{selectJobIndex}" + ".bmp";
                            filePath = strPath + "\\Pattern_" + CVisionTools.MultiPMAlign[i].NAME + ".png";
                            //Common.SaveImageFileToBMP(image, filePath);
                            Common.SaveImageFileToPNG(img, filePath);
                        }


                        CUtil.ShowMessageBox("SAVE", "The Master Train image has been saved.");
                    }


                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private bool m_bViewParts = false;

        private void btnMultiPMAlignViewPartsName_Click(object sender, EventArgs e)
        {
            try
            {
                m_bViewParts = !m_bViewParts;

                if (m_bViewParts)
                {
                    btnMultiPMAlignViewPartsName.BackColor = DEFINE.COLOR_TEAL;

                    List<JOB_MUTIPMALIGN> jobList = new List<JOB_MUTIPMALIGN>();

                    if (cbCamera.SelectedIndex == 0) jobList = CVisionTools.MultiPMAlign;
                    else jobList = CVisionTools.MultiPMAlign2;

                    CogGraphicCollection graphics = new CogGraphicCollection();
                    for (int i = 0; i < jobList.Count; i++)
                    {
                        CogGraphicLabel label = new CogGraphicLabel();
                        CogRectangle rt = new CogRectangle();
                        rt = PMAlignTool.SearchRegion as CogRectangle;

                        label.Color = CogColorConstants.Red;
                        label.Text = jobList[i].NAME;
                        label.Font = new Font("arial", 12, FontStyle.Bold);
                        label.X = (jobList[i].Matching.Tool.SearchRegion as CogRectangle).X;
                        label.Y = (jobList[i].Matching.Tool.SearchRegion as CogRectangle).Y - 20;

                        graphics.Add((ICogGraphic)jobList[i].Matching.Tool.SearchRegion);
                        //graphics.Add((ICogGraphic)jobList[i].Matching.Tool.Pattern.TrainRegion);
                        graphics.Add((ICogGraphic)label);
                    }

                    cogDisplay_Source.StaticGraphics.AddList(graphics, "NAME");
                }
                else
                {
                    btnMultiPMAlignViewPartsName.BackColor = Color.DimGray;
                    cogDisplay_Source.StaticGraphics.Clear();
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                CUtil.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }

        private void btnMultiPMAlignRunAll_Click(object sender, EventArgs e)
        {
            cogDisplay_Source.InteractiveGraphics.Clear();
            cogDisplay_Source.StaticGraphics.Clear();

            CogRectangle OriginRectangle = new CogRectangle();
            CogRectangle MoveRectangle = new CogRectangle();
            double tmpX = new double();
            double tmpY = new double();

            try
            {
                Stopwatch sw_TactTime = new Stopwatch();
                sw_TactTime.Start();

                CogGraphicCollection cogGraphic = new CogGraphicCollection();

                ICogImage tmpimage = null;

                

                if (cbCamera.SelectedIndex == 0)
                {
                    CVisionTools.tmpMultiPMAlign = CVisionTools.MultiPMAlign;
                }
                else
                {
                    CVisionTools.tmpMultiPMAlign = CVisionTools.MultiPMAlign2;
                }


                for (int i = 0; i < CVisionTools.tmpMultiPMAlign.Count; i++)
                {
                    if (CVisionTools.tmpMultiPMAlign[i].InspectionUse)
                    {
                        

                        if (CVisionTools.tmpMultiPMAlign[i].EqualizeUse)
                        {
                            tmpimage = CVisionTools.Equalize.Run(m_imgSource_Mono, null);
                            m_imgSource_Equalize = tmpimage as CogImage8Grey;
                            CVisionTools.tmpMultiPMAlign[i].Matching.Tool.InputImage = m_imgSource_Equalize;
                        }
                        else if (CVisionTools.tmpMultiPMAlign[i].QuantizeUse)
                        {
                            tmpimage = CVisionTools.Quantize.Run(m_imgSource_Mono, null, CVisionTools.tmpMultiPMAlign[i].QuantizeLevel);
                            m_imgSource_Equalize = tmpimage as CogImage8Grey;
                            CVisionTools.tmpMultiPMAlign[i].Matching.Tool.InputImage = m_imgSource_Equalize;
                        }
                        else if (CVisionTools.tmpMultiPMAlign[i].ThresholdUse)
                        {
                            using (Mat imgSource = OpenCvSharp.Extensions.BitmapConverter.ToMat(m_imgSource_Mono.ToBitmap()))
                            using (Mat imgBin = new Mat())
                            {
                                Cv2.Threshold(imgSource, imgBin, CVisionTools.tmpMultiPMAlign[i].ThresholdValue, 255, ThresholdTypes.Binary);

                                CogImage8Grey imgCogSource = new CogImage8Grey(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imgBin));
                                CVisionTools.tmpMultiPMAlign[i].Matching.Tool.InputImage = imgCogSource;
                            }
                        }
                        else
                        {
                            CVisionTools.tmpMultiPMAlign[i].Matching.Tool.InputImage = m_imgSource_Mono;
                        }


                        (tmpX, tmpY) = CVisionTools.RegionOffSet(cbCamera.SelectedIndex, cogDisplay_Source, m_imgSource_Mono);
                        (OriginRectangle, MoveRectangle) = CVisionTools.RegionRect(CVisionTools.tmpMultiPMAlign[i].Matching.Tool.SearchRegion, tmpX, tmpY);
                        CVisionTools.tmpMultiPMAlign[i].Matching.Tool.SearchRegion = MoveRectangle;

                        CogPMAlignResults cogPMAlignResults = new CogPMAlignResults();

                        cogPMAlignResults = CVisionTools.tmpMultiPMAlign[i].Matching.MultiPattern_Run(CVisionTools.tmpMultiPMAlign[i].Matching.Tool, CVisionTools.tmpMultiPMAlign[i].Matching.Tool.InputImage);


                        if (cogPMAlignResults != null)
                        {
                            if (CVisionTools.tmpMultiPMAlign[i].Matching.Tool.SearchRegion != null) cogGraphic.Add((ICogGraphic)CVisionTools.tmpMultiPMAlign[i].Matching.Tool.SearchRegion);

                            int nCount = cogPMAlignResults.Count;
                            if (nCount > 0)
                            {
                                for (int j = 0; j < cogPMAlignResults.Count; j++)
                                {
                                    CogRectangle Draw = new CogRectangle();
                                    CogCompositeShape resultDrawing = cogPMAlignResults[j].CreateResultGraphics(CogPMAlignResultGraphicConstants.BoundingBox);

                                    CogGraphicLabel label = new CogGraphicLabel();
                                    CogGraphicLabel labelResult = new CogGraphicLabel();

                                    labelResult.X = cogPMAlignResults[j].GetPose().TranslationX;
                                    labelResult.Y = cogPMAlignResults[j].GetPose().TranslationY + 30;
                                    labelResult.Color = CogColorConstants.Green;
                                    labelResult.Font = new Font("arial", 12, FontStyle.Bold);
                                    cogDisplay_Source.InteractiveGraphics.Add(cogPMAlignResults[j].CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin), "main", false);
                                    cogDisplay_Source.InteractiveGraphics.Add(cogPMAlignResults[j].CreateResultGraphics(CogPMAlignResultGraphicConstants.TipText), "main", false);
                                    //Set X-position to 100
                                    label.X = cogPMAlignResults[j].GetPose().TranslationX;
                                    label.Y = cogPMAlignResults[j].GetPose().TranslationY;

                                    cogGraphic.Add((ICogGraphic)cogPMAlignResults[j].CreateResultGraphics(CogPMAlignResultGraphicConstants.Origin));

                                    double dRotation = cogPMAlignResults[j].GetPose().Rotation * 180 / Math.PI;
                                    labelResult.Text = $"Score : {cogPMAlignResults[j].Score.ToString("F2")}% Angle : {dRotation.ToString("F1")}";

                                    if (Math.Abs(dRotation) > CVisionTools.tmpMultiPMAlign[i].ANGLE)
                                    {
                                        if (CVisionTools.tmpMultiPMAlign[i].INSP_TYPE.Contains("REVERSE"))
                                        {
                                            label.Color = CogColorConstants.Red;

                                            label.Text = "REVERSE";
                                            label.Font = new Font("arial", 24);

                                            resultDrawing.Color = CogColorConstants.Red;

                                            cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                                        }
                                    }
                                    else
                                    {
                                        if (CVisionTools.tmpMultiPMAlign[i].NotOption)
                                        {
                                            label.Color = CogColorConstants.Red;

                                            label.Text = "Not Option NG";
                                            label.Font = new Font("arial", 24);

                                            resultDrawing.Color = CogColorConstants.Red;

                                            cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                                        }
                                        else
                                        {
                                            resultDrawing.Color = CogColorConstants.Green;
                                        }

                                    }



                                    cogGraphic.Add((ICogGraphic)resultDrawing);

                                   
                                }
                            }
                            else
                            {
                                CogGraphicLabel label = new CogGraphicLabel();
                                CogRectangle rt = new CogRectangle();
                                rt = CVisionTools.tmpMultiPMAlign[i].Matching.Tool.SearchRegion as CogRectangle;

                                label.X = rt.CenterX;
                                label.Y = rt.CenterY;

                                if (CVisionTools.tmpMultiPMAlign[i].NotOption)
                                {

                                    label.Color = CogColorConstants.Green;
                                    label.Text = "Not Option OK";
                                    label.Font = new Font("arial", 24);
                                    cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                                }
                                else
                                {

                                    label.Color = CogColorConstants.Red;
                                    label.Text = "N/A";
                                    label.Font = new Font("arial", 24);
                                    cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");
                                }

                            }

                        }
                        else //패턴 result null
                        {
                            CogGraphicLabel label = new CogGraphicLabel();
                            CogRectangle rt = new CogRectangle();
                            rt = CVisionTools.tmpMultiPMAlign[i].Matching.Tool.SearchRegion as CogRectangle;

                            label.X = rt.CenterX;
                            label.Y = rt.CenterY;



                            label.Color = CogColorConstants.Red;
                            label.Text = "N/A";
                            label.Font = new Font("arial", 24);
                            cogDisplay_Source.StaticGraphics.Add((ICogGraphic)label, "main");

                        }

                        //원점 복귀
                        CVisionTools.tmpMultiPMAlign[i].Matching.Tool.SearchRegion = OriginRectangle;
                    }
                    else
                    {
                        //검사 미사용
                    }

                    

                }

                
                cogDisplay_Source.StaticGraphics.AddList(cogGraphic, "RESULTS");



                sw_TactTime.Stop();
                lbTackTime.Text = sw_TactTime.ElapsedMilliseconds.ToString() + "ms";

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void cboPatternINDEX_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = cboPatternINDEX.SelectedIndex;

                if (m_SelectedMultiPMAlign == null) return;

                if (m_SelectedMultiPMAlign.Matching.Tool.Operator.Count > 0)
                {
                    cogDisply_MultiPattern.Image = m_SelectedMultiPMAlign.Matching.Tool.Operator[index].Pattern.GetTrainedPatternImage();
                    cogDisply_MultiPattern.StaticGraphics.AddList(TrainGraphic(cogDisply_MultiPattern, m_SelectedMultiPMAlign.Matching.Tool, index), "");
                    cogDisply_MultiPattern.Fit(true);
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnMultiPMAlignPatternDELETE_Click(object sender, EventArgs e)
        {
            try
            {
                int index = cboPatternINDEX.SelectedIndex;

                if (m_SelectedMultiPMAlign == null) return;

                if(m_SelectedMultiPMAlign.Matching.Tool.Operator.Count > 0)
                {
                    m_SelectedMultiPMAlign.Matching.Tool.Operator.RemoveAt(index);

                    cboPatternINDEX.Items.Clear();
                    for (int i = 0; i < m_SelectedMultiPMAlign.Matching.Tool.Operator.Count; i++)
                    {
                        cboPatternINDEX.Items.Add(i + 1);

                    }
                }
                

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnMultiPMAlignMASKING_Click(object sender, EventArgs e)
        {
            FormMask frmmask = new FormMask(this);

            try
            {
                frmmask.Show();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnPatternAllDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (m_SelectedMultiPMAlign == null) return;

                if (m_SelectedMultiPMAlign.Matching.Tool.Operator.Count > 0)
                {
                    m_SelectedMultiPMAlign.Matching.Tool.Operator.Clear();

                    cboPatternINDEX.Items.Clear();
                    
                }


            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void chk_MultiPMAlignEqualizeUSE_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_MultiPMAlignEqualizeUSE.Checked)
            {
                chk_MultiPMAlignQuantizeUSE.Checked = false;
                chk_MultiPMAlignThresholdUSE.Checked = false;
            }
        }

        private void chk_MultiPMAlignQuantizeUSE_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_MultiPMAlignQuantizeUSE.Checked)
            {
                chk_MultiPMAlignEqualizeUSE.Checked = false;
                chk_MultiPMAlignThresholdUSE.Checked = false;
            }
        }

        private void chk_MultiPMAlignThresholdUSE_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_MultiPMAlignThresholdUSE.Checked)
            {
                chk_MultiPMAlignQuantizeUSE.Checked = false;
                chk_MultiPMAlignEqualizeUSE.Checked = false;
            }
        }

        private void chk_Cam1FixtureUSE_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_Cam1FixtureUSE.Checked)
            {
                CVisionTools.FIXTURE_CAM1.FixtureUSE = true;
            }
            else
            {
                CVisionTools.FIXTURE_CAM1.FixtureUSE = false;
            }
        }

        private void chk_Cam2FixtureUSE_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Cam2FixtureUSE.Checked)
            {
                CVisionTools.FIXTURE_CAM2.FixtureUSE = true;
            }
            else
            {
                CVisionTools.FIXTURE_CAM2.FixtureUSE = false;
            }
        }

        private void chk_GrabSeqUSE_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int camindex = cbCamera.SelectedIndex;

                if(chk_GrabSeqUSE.Checked)
                {
                    if(camindex == 0)
                    {
                        CVisionTools.JOB_SEQ_USE_CAM1 = true;
                    }
                    else
                    {
                        CVisionTools.JOB_SEQ_USE_CAM2 = true;
                    }
                }
                else
                {
                    if (camindex == 0)
                    {
                        CVisionTools.JOB_SEQ_USE_CAM1 = false;
                    }
                    else
                    {
                        CVisionTools.JOB_SEQ_USE_CAM2 = false;
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        
    }
}