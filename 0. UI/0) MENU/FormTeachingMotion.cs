using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Net;
using System.Net.Sockets;

using OpenCvSharp;
using OpenCvSharp.UserInterface;
using OpenCvSharp.Blob;

using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

using ImageGlass;

#if MATROX
using Matrox.MatroxImagingLibrary; 
#endif

#if DATAMATRIXNET
using DataMatrix.net;
#endif

namespace IntelligentFactory
{
    public partial class FormTeachingMotion : MetroForm
    {
        private IGlobal Global = IGlobal.Instance;
        private CStatusMotion Status = null;
        private CStatusMotionHome Home = null;
        private CAXIS_AJIN Axis = null;
        

        //private MIL_ID ImageSource = new MIL_ID();
        private Mat    ImageSource = new Mat();

#if MATROX
        private MIL_ID ImageMSource = MIL.M_NULL;
#endif
        private Bitmap ImageDisplay = new Bitmap(1024, 768);

        private float m_fScaleFactorX = 1.0F;
        private float m_fScaleFactorY = 1.0F;

        private const int DGV_NO = 0;
        private const int DGV_NAME = 1;
        private const int DGV_STATUS = 2;

        private List<string> ListPreImageProcess = new List<string>();

        public float m_fImageScale { get; set; } = 1;

        private string m_strSelectedTab = "UPPER LIFT";

        private Dictionary<string, List<CSignal>> Inputs_Reference = new Dictionary<string, List<CSignal>>();
        private Dictionary<string, List<CSignal>> Outputs_Reference = new Dictionary<string, List<CSignal>>();

        #region Event Register        
        public EventHandler<EventArgs> EventUpdateUi;
#endregion
                      
        public FormTeachingMotion()
        { 
            InitializeComponent();

            //ex) Inputs_Reference["UPPER_LIFT"].Add(Global.iDevice.DIO_BD.DI_101_Z_MOVE_INTERLOCK_DETECT_LOADING_SIDE);
            //위 예제와 같이 각 포지션에 맞게 참고해야하는 IO 들을 Inputs, Outputs 분리하여 dictionary 에 추가해주세요.

            Inputs_Reference.Add("UPPER_LIFT", new List<CSignal>());

            //Inputs_Reference["UPPER_LIFT"].Add(Global.iDevice.DIO_BD.DI_UPPER_LIFT_SHUTTLE_WORK_PRESENCE_DETECT);
            //Inputs_Reference["UPPER_LIFT"].Add(Global.iDevice.DIO_BD.DI_UPPER_LIFT_SHUTTLE_WORK_POS_DETECT);
            //Inputs_Reference["UPPER_LIFT"].Add(Global.iDevice.DIO_BD.DI_UPPER_LIFT_SHUTTLE_RFID_MOVING_CYL_FW);
            //Inputs_Reference["UPPER_LIFT"].Add(Global.iDevice.DIO_BD.DI_UPPER_LIFT_SHUTTLE_RFID_MOVING_CYL_BW);

            Outputs_Reference.Add("UPPER_LIFT", new List<CSignal>());
            //Outputs_Reference["UPPER_LIFT"].Add(Global.iDevice.DIO_BD.DO_UPPER_LIFT_SHUTTLE_RFID_MOVING_CYL_FW);
            //Outputs_Reference["UPPER_LIFT"].Add(Global.iDevice.DIO_BD.DO_UPPER_LIFT_SHUTTLE_RFID_MOVING_CYL_BW);
            //Outputs_Reference["UPPER_LIFT"].Add(Global.iDevice.DIO_BD.DO_UPPER_LIFT_SHUTTLE_FEEDER_ON_OFF_INPUT_DIRECTION);
            //Outputs_Reference["UPPER_LIFT"].Add(Global.iDevice.DIO_BD.DO_UPPER_LIFT_SHUTTLE_FEEDER_ON_OFF_OUTPUT_DIRECTION);


            Inputs_Reference.Add("LOT_TRANSFER", new List<CSignal>());
            //Inputs_Reference["LOT_TRANSFER"].Add(Global.iDevice.DIO_BD.DI_LOT_TRANSFER_WORK_COUNT_SENSOR);
            //Inputs_Reference["LOT_TRANSFER"].Add(Global.iDevice.DIO_BD.DI_LOT_TRANSFER_WORK_GRIP_DETECT_LEFT_FRONT);
            //Inputs_Reference["LOT_TRANSFER"].Add(Global.iDevice.DIO_BD.DI_LOT_TRANSFER_WORK_GRIP_DETECT_LEFT_REAR);
            //Inputs_Reference["LOT_TRANSFER"].Add(Global.iDevice.DIO_BD.DI_LOT_TRANSFER_WORK_GRIP_DETECT_RIGHT_FRONT);
            //Inputs_Reference["LOT_TRANSFER"].Add(Global.iDevice.DIO_BD.DI_LOT_TRANSFER_WORK_GRIP_DETECT_RIGHT_REAR);
            //Inputs_Reference["LOT_TRANSFER"].Add(Global.iDevice.DIO_BD.DI_LOT_TRANSFER_GRIPPER_ON);
            //Inputs_Reference["LOT_TRANSFER"].Add(Global.iDevice.DIO_BD.DI_LOT_TRANSFER_GRIPPER_OFF);
            

            Outputs_Reference.Add("LOT_TRANSFER", new List<CSignal>());
            //Outputs_Reference["LOT_TRANSFER"].Add(Global.iDevice.DIO_BD.DO_LOT_TRANSFER_GRIPPER_ON);
            //Outputs_Reference["LOT_TRANSFER"].Add(Global.iDevice.DIO_BD.DO_LOT_TRANSFER_GRIPPER_OFF);
           
            Inputs_Reference.Add("WORK_PICKER #1", new List<CSignal>());
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_WORK_PICKER_GRIPPER_ON);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_WORK_PICKER_GRIPPER_OFF);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_WORK_PICKER_WORK_GRIP_DETECT_LEFT_FRONT);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_WORK_PICKER_WORK_GRIP_DETECT_LEFT_REAR);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_WORK_PICKER_WORK_GRIP_DETECT_RIGHT_FRONT);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_WORK_PICKER_WORK_GRIP_DETECT_RIGHT_REAR);

            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_1ST_WORK_DETECT_BOTTOM);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_1ST_WORK_DETECT_TOP);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_1ST_RELAY_LIFT_CYL_UP);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_1ST_RELAY_LIFT_CYL_DOWN);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_1ST_CLAMP_MOVING_CYL_NARROW);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_1ST_CLAMP_MOVING_CYL_WIDE);

            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_1ST_CLAMP_ON_LEFT);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_1ST_CLAMP_OFF_LEFT);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_1ST_CLAMP_ON_RIGHT);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_1ST_CLAMP_OFF_RIGHT);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_1ST_ROTATE_CYL_0);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_1ST_ROTATE_CYL_180);


            Outputs_Reference.Add("WORK_PICKER #1", new List<CSignal>());

            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_WORK_PICKER_GRIPPER_ON);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_WORK_PICKER_GRIPPER_OFF);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_1ST_RELAY_LIFT_CYL_UP);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_1ST_RELAY_LIFT_CYL_DOWN);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_1ST_CLAMP_MOVING_CYL_NARROW);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_1ST_CLAMP_MOVING_CYL_WIDE);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_1ST_CLAMP_ON_RIGHT);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_1ST_CLAMP_OFF_RIGHT);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_1ST_ROTATE_CYL_0);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_1ST_ROTATE_CYL_180);

            Inputs_Reference.Add("WORK_PICKER #2", new List<CSignal>());
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_2ND_WORK_DETECT_BOTTOM);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_2ND_WORK_DETECT_TOP);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_2ND_RELAY_LIFT_CYL_UP);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_2ND_RELAY_LIFT_CYL_DOWN);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_2ND_CLAMP_MOVING_CYL_NARROW);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_2ND_CLAMP_MOVING_CYL_WIDE);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_2ND_CLAMP_ON_LEFT);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_2ND_CLAMP_OFF_LEFT);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_2ND_CLAMP_ON_RIGHT);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_2ND_CLAMP_OFF_RIGHT);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_2ND_ROTATE_CYL_0);
            //Inputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DI_FLIPPER_2ND_ROTATE_CYL_180);



            Outputs_Reference.Add("WORK_PICKER #2", new List<CSignal>());
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_2ND_RELAY_LIFT_CYL_UP);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_2ND_RELAY_LIFT_CYl_DOWN);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_2ND_CLAMP_MOVING_CYL_NARROW);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_2ND_CLAMP_MOVING_CYL_WIDE);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_2ND_CLAMP_ON_LEFT);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_2ND_CLAMP_OFF_LEFT);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_2ND_CLAMP_ON_RIGHT);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_2ND_CLAMP_OFF_RIGHT);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_2ND_ROTATE_CYL_0);
            //Outputs_Reference["WORK_PICKER"].Add(Global.iDevice.DIO_BD.DO_FLIPPER_2ND_ROTATE_CYL_180);


            Inputs_Reference.Add("BUFFER", new List<CSignal>());
            //Inputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DI_WORK_DONE_INPUT_RAIL_INPUT_DETECT_BUFFER);
            //Inputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DI_WORK_DONE_INPUT_RAIL_OUTPUT_DETECT_BUFFER);
            //Inputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DI_WORK_DONE_INPUT_RAIL_EMPTY_CHECK_BUFFER);
            //Inputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DI_WORK_DONE_INPUT_RAIL_FEEDER_MOVING_CYL_FW_BUFFER);
            //Inputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DI_WORK_DONE_INPUT_RAIL_FEEDER_MOVING_CYL_BW_BUFFER);
            //Inputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DI_WORK_DONE_INPUT_RAIL_INPUT_DETECT);
            //Inputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DI_WORK_DONE_INPUT_RAIL_RELAY_LIFT_POS_DETECT);
            //Inputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DI_WORK_DONE_INPUT_RAIL_RELAY_LIFT_TRAY_DETECT);
            //Inputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DI_WORK_DONE_INPUT_RAIL_RELAY_LIFT_CYL_UP);
            //Inputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DI_WORK_DONE_INPUT_RAIL_RELAY_LIFT_CYL_DOWN);
            //Inputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DI_WORK_DONE_INPUT_RAIL_METAL_TRAY_LOCK_CYL_FW);
            //Inputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DI_WORK_DONE_INPUT_RAIL_METAL_TRAY_LOCK_CYL_BW);


            Outputs_Reference.Add("BUFFER", new List<CSignal>());
            //Outputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DO_WORK_DONE_INPUT_RAIL_BUFFER_FEEDER_MOVING_CYL_FW);
            //Outputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DO_WORK_DONE_INPUT_RAIL_BUFFER_FEEDER_MOVING_CYL_BW);
            //Outputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DO_WORK_DONE_INPUT_RAIL_RELAY_LIFT_CYl_UP);
            //Outputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DO_WORK_DONE_INPUT_RAIL_RELAY_LIFT_CYl_DOWN);
            //Outputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DO_WORK_DONE_INPUT_RAIL_FEEDER_ON_OFF);
            //Outputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DO_WORK_DONE_INPUT_RAIL_METAL_TRAY_LOCK_CYL_FW);
            //Outputs_Reference["BUFFER"].Add(Global.iDevice.DIO_BD.DO_WORK_DONE_INPUT_RAIL_METAL_TRAY_LOCK_CYL_BW);

        }
        private void InittabControl()
        {
            this.tcSequecne.Controls.Remove(metroTabPage11);

        }
        private void FormTeachingMotion_Load(object sender, EventArgs e)
        {
            EventUpdateUi += OnUpdateUi;

            if (EventUpdateUi != null)
            {
                EventUpdateUi(null, null);
            }

            Global.System.Recipe.EventChagedRecipe += OnChangedRecipe;

            InitUI();
            InitControl();
            InitProperty();
        }

        private void InitControl()
        {
            try
            {

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void FormTeachingMotion_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
            }
            catch(Exception Desc)
            {
                
            }
        }

        private bool InitUI()
        {
            try
            {
                this.tcSequecne.Controls.Remove(metroTabPage11);
                this.tcSequecne.Controls.Remove(metroTabPage15);
                this.tcSequecne.Controls.Remove(metroTabPage17);
                this.tcSequecne.Controls.Remove(metroTabPage14);
                this.tcSequecne.Controls.Remove(metroTabPage16);
                this.tcSequecne.Controls.Remove(metroTabPage6);

                ucCylWorkDoneRailLift.Init(Global.iDevice.DIO_BD.CYL_WORK_DONE_RAIL_LIFT);
                ucCylWorkPickerGrip.Init(Global.iDevice.DIO_BD.CYL_WORK_PICKER_GRIPPER);
                ucCylStackLift.Init(Global.iDevice.DIO_BD.CYL_STACK_LIFT);
                ucCylLoadingSeparation.Init(Global.iDevice.DIO_BD.CYL_LOADING_SEPARATOION);
                ucCylLoadingRailLift.Init(Global.iDevice.DIO_BD.CYL_LOADING_RAIL_LIFT);
                ucCylUnloadingRailLift.Init(Global.iDevice.DIO_BD.CYL_UNLOADING_RAIL_LIFT);
                ucCylMetalRailLift.Init(Global.iDevice.DIO_BD.CYL_METAL_TRAY_RAIL_LIFT);
                ucCylTopCoverRailLift.Init(Global.iDevice.DIO_BD.CYL_TOP_COVER_RAIL_LIFT);
                ucCylWokDoneBufferF.Init(Global.iDevice.DIO_BD.CYL_WORK_DONE_BUFFER_F);
                ucCylWorkDoneMetalLock.Init(Global.iDevice.DIO_BD.CYL_WORK_DONE_METAL_TRAY_LOCK);
                ucCylTopCoverIDreadStopper.Init(Global.iDevice.DIO_BD.CYL_TOP_COVER_ID_Stopper);
                ucCylMetalTrayIDreadStopper.Init(Global.iDevice.DIO_BD.CYL_METAL_TRAY_ID_Stopper);
                ucCylMetalTrayUnloadingUpdown.Init(Global.iDevice.DIO_BD.CYL_METAL_TRAY_ULD_PUSHER_UPDOWN);
                ucCylTopCoverUnloadingUpdown.Init(Global.iDevice.DIO_BD.CYL_METAL_TRAY_ULD_PUSHER_UPDOWN);
                ucCylTopCoverUnloadingFWBW.Init(Global.iDevice.DIO_BD.CYL_METAL_TRAY_ULD_PUSHER);
                ucCylMetalTrayUnloadingFWBW.Init(Global.iDevice.DIO_BD.CYL_TOP_COVER_ULD_PUSHER);

                ucCylTopCoverloadingFWBW.Init(Global.iDevice.DIO_BD.CYL_METAL_TRAY_LD_PUSHER);
                ucCylMetalTrayloadingFWBW.Init(Global.iDevice.DIO_BD.CYL_TOP_COVER_LD_PUSHER);


                CMotionManager manager = Global.iDevice.MOTION_AJIN;
                 
                //Work Picker #1
                ucPosition1.Init(manager.POS_WP_DEFAULT_WAIT_Y);
                ucPosition2.Init(manager.POS_WP_MT_MT_PICK_WORK_Y);
                ucPosition3.Init(manager.POS_WP_MT_LD_PLACE_WORK_Y);
                ucPosition4.Init(manager.POS_WP_OL_LDV_PLACE_WORK_Y);
                ucPosition5.Init(manager.POS_WP_CT_CT_PICK_WORK_Y);
                ucPosition6.Init(manager.POS_WP_OL_LD_PLCAE_WAIT_Y);
                //Work Picker #2
                ucPosition7.Init(manager.POS_WDB_PICK_WORK_Y);
                ucPosition8.Init(manager.POS_WP_OL_ULDV_PLACE_WORK_Y);
                ucPosition9.Init(manager.POS_WP_OL_ULOR_PLACE_WORK_Y);
                //Work Picker #3
                ucPosition13.Init(manager.POS_WP_DEFAULT_WAIT_Z); 
                ucPosition14.Init(manager.POS_WP_MT_MT_PICK_WORK_Z);
                ucPosition15.Init(manager.POS_WP_MT_LD_PLACE_WORK_Z);
                ucPosition16.Init(manager.POS_WP_OL_LD_PICK_WORK_Z);
                ucPosition17.Init(manager.POS_WP_OL_LDV_PLACE_WORK_Z);
                ucPosition18.Init(manager.POS_WP_MT_LDV_PICK_WORK_Z);
                //Work Picker #4
                ucPosition19.Init(manager.POS_WP_MT_LDV_PLACE_WORK_Z);
                ucPosition20.Init(manager.POS_WP_JT_LDV_PICK_WORK_Z);                
                ucPosition21.Init(manager.POS_WP_JT_MT_PLACE_WAIT_Z);
                ucPosition22.Init(manager.POS_WP_JT_MT_PLACE_WORK_Z);
                ucPosition23.Init(manager.POS_WP_CT_CT_PICK_WAIT_Z);
                ucPosition24.Init(manager.POS_WP_CT_CT_PICK_WORK_Z);
                //Work Picker #5
                ucPosition25.Init(manager.POS_WP_CT_LDV_PLCAE_WAIT_Z);
                ucPosition26.Init(manager.POS_WP_CT_LDV_PLCAE_WORK_Z);
                ucPosition27.Init(manager.POS_WP_OL_LDV_PICK_WORK_Z);
                ucPosition28.Init(manager.POS_WP_OL_LD_PLCAE_WORK_Z);
                ucPosition29.Init(manager.POS_WDB_PICK_WORK_Z);
                ucPosition30.Init(manager.POS_WDB_PICK_WAIT_Z);
                //Work Picker #6
                ucPosition31.Init(manager.POS_WP_OL_ULDV_PLACE_WORK_Z);
                ucPosition32.Init(manager.POS_WP_JT_ULDV_PLACE_PICK_Z);
                ucPosition33.Init(manager.POS_TC_ULDV_PICK_WORK_Z);
                ucPosition10.Init(manager.POS_TEMP10);
                ucPosition11.Init(manager.POS_WP_OL_ULOR_PLACE_WORK_Z);
                ucPosition12.Init(manager.POS_WP_MT_ULDR_PICK_WORK_Z);

                //Lot Transfer #1
                ucPosition40.Init(manager.POS_LOT_TRANSFER_AVOID_Y);
                ucPosition41.Init(manager.POS_LOT_TRANSFER_PICK_WAIT_X);
                ucPosition42.Init(manager.POS_LOT_TRANSFER_PICK_WAIT_Y);
                ucPosition43.Init(manager.POS_LOT_TRANSFER_SENSOR_START_Z);
                ucPosition44.Init(manager.POS_LOT_TRANSFER_PICK_WORK_X);
                ucPosition45.Init(manager.POS_LOT_TRANSFER_PICK_WAIT_Z);
                //Lot Transfer #2
                ucPosition46.Init(manager.POS_LOT_TRANSFER_PLACE_WAIT_X);
                ucPosition47.Init(manager.POS_LOT_TRANSFER_PLACE_WAIT_Y);
                ucPosition48.Init(manager.POS_LOT_TRANSFER_PLACE_WAIT_Z);
                ucPosition49.Init(manager.POS_LOT_TRANSFER_PLACE_WORK_X);
                ucPosition50.Init(manager.POS_LOT_TRANSFER_PLACE_WORK_Y);
                ucPosition51.Init(manager.POS_LOT_TRANSFER_PLACE_WORK_Z);
                //Lot Transfer #3
                ucPosition52.Init(manager.POS_LOT_TRANSFER_ULD_PLACE_WAIT_X);
                ucPosition53.Init(manager.POS_LOT_TRANSFER_ULD_PLACE_WAIT_Y);
                ucPosition54.Init(manager.POS_LOT_TRANSFER_ULD_PLACE_WORK_Z);

                //Buffer #1
                ucPosition55.Init(manager.POS_ZIG_ELAVATOR_INIT_Z);
                ucPosition56.Init(manager.POS_WORK_DONE_BUFFER_Z);
                ucPosition67.Init(manager.POS_JIG_ELAVATOR_INIT_WAIT_Z);
                ucPosition68.Init(manager.POS_WORK_DONE_BUFFER_F);

                //Upper Lift
                ucPosition57.Init(manager.POS_UPPER_LIFT_TOP_WAIT_Z);
                ucPosition58.Init(manager.POS_UPPER_LIFT_TOP_WORK_Z);
                ucPosition59.Init(manager.POS_UPPER_LIFT_BTM_WAIT_Z);
                ucPosition60.Init(manager.POS_UPPER_LIFT_BTM_WORK_Z);

                //Upper Shuttle #1
                ucPosition61.Init(manager.POS_UPPER_LD_X);
                ucPosition62.Init(manager.POS_UPPER_ULD_X);
                ucPosition63.Init(manager.POS_UPPER_AVOID_X);
                ucPosition64.Init(manager.POS_UPPER_AVOID_Y);
                ucPosition65.Init(manager.POS_UPPER_AVOID_Z);
                ucPosition66.Init(manager.POS_UPPER_RECV_Y);
                //Upper Shuttle #2
                ucPosition34.Init(manager.POS_UPPER_LOAD_Y);
                ucPosition35.Init(manager.POS_UPPER_RECV_R);
                ucPosition36.Init(manager.POS_UPPER_LOAD_R);

                //Work Loading Rail Lift Z 
                ucPosition37.Init(manager.POS_WORK_LD_LIFT_WORK_Z);
                ucPosition38.Init(manager.POS_WORK_LD_LIFT_WAIT_Z);
                ucPosition39.Init(manager.POS_WORK_LD_LIFT_SEPERATION);

                //Vision X,Y
                ucPosition69.Init(manager.POS_LOADER_VISION_X);
                ucPosition70.Init(manager.POS_LOADER_VISION_Y);
                ucPosition71.Init(manager.POS_UNLOADER_VISION_X);
                ucPosition72.Init(manager.POS_UNLOADER_VISION_X);



                #region 확인 후 삭제
                //tbUpperLift_Top_Wait_Z.Text           = manager.POS_UPPER_LIFT_TOP_WAIT_Z.POSITION.ToString();
                //tbUpperLift_Top_Wait_FastSpeed_Z.Text = manager.POS_UPPER_LIFT_TOP_WAIT_Z.SPEED_FAST.ToString();
                //tbUpperLift_Top_Wait_SlowSpeed_Z.Text = manager.POS_UPPER_LIFT_TOP_WAIT_Z.SPEED_SLOW.ToString();

                //tbUpperLift_Top_Work_Z.Text           = manager.POS_UPPER_LIFT_TOP_WORK_Z.POSITION.ToString();
                //tbUpperLift_Top_Work_FastSpeed_Z.Text = manager.POS_UPPER_LIFT_TOP_WORK_Z.SPEED_FAST.ToString();
                //tbUpperLift_Top_Work_SlowSpeed_Z.Text = manager.POS_UPPER_LIFT_TOP_WORK_Z.SPEED_SLOW.ToString();

                //tbUpperLift_Btm_Wait_Z.Text           = manager.POS_UPPER_LIFT_BTM_WAIT_Z.POSITION.ToString();
                //tbUpperLift_Btm_Wait_FastSpeed_Z.Text = manager.POS_UPPER_LIFT_BTM_WAIT_Z.SPEED_FAST.ToString();
                //tbUpperLift_Btm_Wait_SlowSpeed_Z.Text = manager.POS_UPPER_LIFT_BTM_WAIT_Z.SPEED_SLOW.ToString();

                //tbUpperLift_Btm_Work_Z.Text              = manager.POS_UPPER_LIFT_BTM_WORK_Z.POSITION.ToString();
                //tbUpperLift_Btm_Work_FastSpeed_Z.Text    = manager.POS_UPPER_LIFT_BTM_WORK_Z.SPEED_FAST.ToString();
                //tbUpperLift_Btm_Work_SlowSpeed_Z.Text    = manager.POS_UPPER_LIFT_BTM_WORK_Z.SPEED_SLOW.ToString();

                //tbLotTransfer_Pick_Wait_X.Text           = manager.POS_LOT_TRANSFER_PICK_WAIT_X.POSITION.ToString();
                //tbLotTransfer_Pick_Wait_FastSpeed_X.Text = manager.POS_LOT_TRANSFER_PICK_WAIT_X.SPEED_FAST.ToString();
                //tbLotTransfer_Pick_Wait_SlowSpeed_X.Text = manager.POS_LOT_TRANSFER_PICK_WAIT_X.SPEED_SLOW.ToString();

                //tbLotTransfer_Pick_Wait_Y.Text           = manager.POS_LOT_TRANSFER_PICK_WAIT_Y.POSITION.ToString();
                //tbLotTransfer_Pick_Wait_FastSpeed_Y.Text = manager.POS_LOT_TRANSFER_PICK_WAIT_Y.SPEED_FAST.ToString();
                //tbLotTransfer_Pick_Wait_SlowSpeed_Y.Text = manager.POS_LOT_TRANSFER_PICK_WAIT_Y.SPEED_SLOW.ToString();

                //tbLotTransfer_Pick_Wait_Z.Text           = manager.POS_LOT_TRANSFER_PICK_WAIT_Z.POSITION.ToString();
                //tbLotTransfer_Pick_Wait_FastSpeed_Z.Text = manager.POS_LOT_TRANSFER_PICK_WAIT_Z.SPEED_FAST.ToString();
                //tbLotTransfer_Pick_Wait_SlowSpeed_Z.Text = manager.POS_LOT_TRANSFER_PICK_WAIT_Z.SPEED_SLOW.ToString();

                //tbLotTransfer_Pick_Work_X.Text = manager.POS_LOT_TRANSFER_PICK_WORK_X.POSITION.ToString();
                //tbLotTransfer_Pick_Work_FastSpeed_X.Text = manager.POS_LOT_TRANSFER_PICK_WORK_X.SPEED_FAST.ToString();
                //tbLotTransfer_Pick_Work_SlowSpeed_X.Text = manager.POS_LOT_TRANSFER_PICK_WORK_X.SPEED_SLOW.ToString();

                //tbLotTransfer_SensorStart_Z.Text = manager.POS_LOT_TRANSFER_SENSOR_START_Z.POSITION.ToString();
                //tbLotTransfer_SensorStart_Z_FastSpeed.Text = manager.POS_LOT_TRANSFER_SENSOR_START_Z.SPEED_FAST.ToString();
                //tbLotTransfer_SensorStart_Z_SlowSpeed.Text = manager.POS_LOT_TRANSFER_SENSOR_START_Z.SPEED_SLOW.ToString();

                //tbLotTransfer_Pick_Work_Z.Text = manager.POS_LOT_TRANSFER_PICK_WORK_Z.POSITION.ToString();
                //tbLotTransfer_Pick_Work_FastSpeed_Z.Text = manager.POS_LOT_TRANSFER_PICK_WORK_Z.SPEED_FAST.ToString();
                //tbLotTransfer_Pick_Work_SlowSpeed_Z.Text = manager.POS_LOT_TRANSFER_PICK_WORK_Z.SPEED_SLOW.ToString();

                //tbLotTransfer_Place_Wait_X.Text = manager.POS_LOT_TRANSFER_PLACE_WAIT_X.POSITION.ToString();
                //tbLotTransfer_Place_Wait_FastSpeed_X.Text = manager.POS_LOT_TRANSFER_PLACE_WAIT_X.SPEED_FAST.ToString();
                //tbLotTransfer_Place_Wait_SlowSpeed_X.Text = manager.POS_LOT_TRANSFER_PLACE_WAIT_X.SPEED_SLOW.ToString();

                //tbLotTransfer_Place_Wait_Y.Text = manager.POS_LOT_TRANSFER_PLACE_WAIT_Y.POSITION.ToString();
                //tbLotTransfer_Place_Wait_FastSpeed_Y.Text = manager.POS_LOT_TRANSFER_PLACE_WAIT_Y.SPEED_FAST.ToString();
                //tbLotTransfer_Place_Wait_SlowSpeed_Y.Text = manager.POS_LOT_TRANSFER_PLACE_WAIT_Y.SPEED_SLOW.ToString();

                //tbLotTransfer_Place_Wait_Z.Text = manager.POS_LOT_TRANSFER_PLACE_WAIT_Z.POSITION.ToString();
                //tbLotTransfer_Place_Wait_FastSpeed_Z.Text = manager.POS_LOT_TRANSFER_PLACE_WAIT_Z.SPEED_FAST.ToString();
                //tbLotTransfer_Place_Wait_SlowSpeed_Z.Text = manager.POS_LOT_TRANSFER_PLACE_WAIT_Z.SPEED_SLOW.ToString();

                //tbLotTransfer_Place_Work_X.Text = manager.POS_LOT_TRANSFER_PLACE_WORK_X.POSITION.ToString();
                //tbLotTransfer_Place_Work_FastSpeed_X.Text = manager.POS_LOT_TRANSFER_PLACE_WORK_X.SPEED_FAST.ToString();
                //tbLotTransfer_Place_Work_SlowSpeed_X.Text = manager.POS_LOT_TRANSFER_PLACE_WORK_X.SPEED_SLOW.ToString();

                //tbLotTransfer_Place_Work_Y.Text = manager.POS_LOT_TRANSFER_PLACE_WORK_Y.POSITION.ToString();
                //tbLotTransfer_Place_Work_FastSpeed_Y.Text = manager.POS_LOT_TRANSFER_PLACE_WORK_Y.SPEED_FAST.ToString();
                //tbLotTransfer_Place_Work_SlowSpeed_Y.Text = manager.POS_LOT_TRANSFER_PLACE_WORK_Y.SPEED_SLOW.ToString();

                //tbLotTransfer_Place_Work_Z.Text = manager.POS_LOT_TRANSFER_PLACE_WORK_Z.POSITION.ToString();
                //tbLotTransfer_Place_Work_FastSpeed_Z.Text = manager.POS_LOT_TRANSFER_PLACE_WORK_Z.SPEED_FAST.ToString();
                //tbLotTransfer_Place_Work_SlowSpeed_Z.Text = manager.POS_LOT_TRANSFER_PLACE_WORK_Z.SPEED_SLOW.ToString();
                #endregion

                #region BUFFER PITCH 
                //tbWorkLoadingBufferPitch.Text = Global.iData.PropertyBufferPitch.LOADING_BUFFER_PITCH.ToString();
                //tbZigElevatorBufferPitch.Text = Global.iData.PropertyBufferPitch.ZIG_ELEVATOR_PITCH.ToString();
                //tbWorkDoneBufferPitch.Text = Global.iData.PropertyBufferPitch.WORK_DONE_BUFFER_PITCH.ToString();
                #endregion


                cbPositions.Items.Clear();


                for (int i = 0; i < Global.iDevice.MOTION_AJIN.Positions.Count; i++)
                {
                    string strKey = Global.iDevice.MOTION_AJIN.Positions.ElementAt(i).Key;

                    string strName = Global.iDevice.MOTION_AJIN.Positions.ElementAt(i).Value.NAME;
                    string strPosition = Global.iDevice.MOTION_AJIN.Positions.ElementAt(i).Value.POSITION.ToString();

                    cbPositions.Items.Add(strKey);
                }

                cbPositions.SelectedIndex = 0;

                this.Invalidate();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool InitProperty()
        {
            try
            {
                Global.iData.PropertyVisionInsp.LoadConfig(Global.System.Recipe.Name);
                Global.iData.PropertyBufferPitch.LoadConfig(Global.System.Recipe.Name);

                this.Invalidate();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ImageBox_MouseWheelEvent(object sender, MouseEventArgs e)
        {
            try
            {
                if (!(sender is ImageBoxEx)) return;
                ImageBoxEx ib = (sender as ImageBoxEx);

                if (e.Delta > 0) ib.ZoomIn();
                else ib.ZoomOut();
            }
            catch (Exception ex)
            {

            }
        }

        private void ImageBox_MouseDoubleClickEvent(object sender, MouseEventArgs e)
        {
            try
            {
                if (!(sender is ImageBoxEx)) return;
                ImageBoxEx ib = (sender as ImageBoxEx);

                FormImageEditView FrmImageView = new FormImageEditView((Bitmap)ib.Image);
                if (FrmImageView.ShowDialog() == DialogResult.OK)
                {
                    //SetImageData("SOURCE", FrmImageView.ImageProcess);
                }
            }
            catch (Exception ex)
            {

            }
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
                    InitUI();
                }
                catch (Exception ex)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
        }

#region IMAGEBOX WHEEL

        private void MouseWheelEventSource(object sender, MouseEventArgs e)
        {
            if ((e.Delta / 120) > 0)
            {
                // up
                if (m_fImageScale > 1)
                    m_fImageScale--;

                ZoomInImageSource();
            }
            else
            {
                // down
                m_fImageScale++;

                ZoomOutImageSource();
            }
        }

        private void ZoomInImageSource()
        {
        }

        private void ZoomOutImageSource()
        {
        }

        private void MouseWheelEventResult(object sender, MouseEventArgs e)
        {
            if ((e.Delta / 120) > 0)
            {
                // up
                if (m_fImageScale > 1)
                    m_fImageScale--;

                ZoomInImageResult();
            }
            else
            {
                // down
                m_fImageScale++;

                ZoomOutImageResult();
            }
        }

        private void ZoomInImageResult()
        {
        }

        private void ZoomOutImageResult()
        {
        }

        private void MouseWheelEventProcess(object sender, MouseEventArgs e)
        {
            if ((e.Delta / 120) > 0)
            {
                // up
                if (m_fImageScale > 1)
                    m_fImageScale--;

                ZoomInImageProcess();
            }
            else
            {
                // down
                m_fImageScale++;

                ZoomOutImageProcess();
            }
        }

        private void ZoomInImageProcess()
        {
        }

        private void ZoomOutImageProcess()
        {
        }

#endregion
        private bool InitFilter()
        {
            try
            {
              
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

#if MATROX

        private bool PreImageProcess(string strFilter, MIL_ID imageSource, MIL_ID imageDest, params object[] args)
        {
            try
            {
                if (imageSource == null) return false;

                switch (strFilter)
                {
                    case "Threshold":             // Param 1 : Threshold
                        if (args.Length != 1) return false;
                        ////EasyImage.Threshold(imageSource, imageDest, (uint)args[0]);                        
                        break;
                    case "Threshold_Inv":         // Param 1 : Threshold
                        if (args.Length != 1) return false;
                        ////EasyImage.Threshold(imageSource, imageDest, (uint)args[0]);
                        ////EasyImage.Oper(EArithmeticLogicOperation.Invert, imageDest, imageDest);
                        break;
                    case "Threshold_Adaptive":    // Param 1 : Kernel Size   Param 2 : Threshold Offset
                        if (args.Length != 2) return false;
                        ////EasyImage.AdaptiveThreshold(imageSource, imageDest, EAdaptiveThresholdMethod.Mean, (int)args[0], (int)args[1]);
                        break;
                    case "Morp_Open":             // Param 1 : Kernel Size
                        if (args.Length != 1) return false;
                        ////EasyImage.OpenBox(imageSource, imageDest, (uint)args[0]);
                        break;
                    case "Morp_Close":            // Param 1 : Kernel Size
                        if (args.Length != 1) return false;
                        //EasyImage.CloseBox(imageSource, imageDest, (uint)args[0]);
                        break;
                    case "Morp_Erode":            // Param 1 : Kernel Size
                        if (args.Length != 1) return false;
                        //EasyImage.ErodeBox(imageSource, imageDest, (uint)args[0]);
                        break;
                    case "Morp_Dilate":           // Param 1 : Kernel Size
                        if (args.Length != 1) return false;
                        //EasyImage.DilateBox(imageSource, imageDest, (uint)args[0]);
                        break;
                    case "Uniform":               // Param 1 : Kernel Size Width   Param 2 : Kernel Size Height
                        if (args.Length != 2) return false;
                        //EasyImage.ConvolUniform(imageSource, imageDest, (uint)args[0], (uint)args[1]);
                        break;
                    case "Gaussian":
                        if (args.Length != 2) return false;
                        //EasyImage.ConvolGaussian(imageSource, imageDest, (uint)args[0], (uint)args[1]);
                        break;
                    case "LowPass":
                        //EasyImage.ConvolLowpass3(imageSource, imageDest);
                        break;
                    case "HighPass":
                        //EasyImage.ConvolHighpass2(imageSource, imageDest);
                        break;
                    case "Gradient":
                        //EasyImage.ConvolGradient(imageSource, imageDest);
                        break;
                    case "GradientX":
                        //EasyImage.ConvolGradientX(imageSource, imageDest);
                        break;
                    case "GradientY":
                        //EasyImage.ConvolGradientY(imageSource, imageDest);
                        break;
                    case "Sobel":
                        //EasyImage.ConvolSobel(imageSource, imageDest);
                        break;
                    case "SobelX":
                        //EasyImage.ConvolSobelX(imageSource, imageDest);
                        break;
                    case "SobelY":
                        //EasyImage.ConvolSobelY(imageSource, imageDest);
                        break;
                    case "Laplacian":
                        //EasyImage.ConvolLaplacian8(imageSource, imageDest);
                        break;
                    case "LaplacianX":
                        //EasyImage.ConvolLaplacianX(imageSource, imageDest);
                        break;
                    case "LaplacianY":
                        //EasyImage.ConvolLaplacianY(imageSource, imageDest);
                        break;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;

        }

#endif
        private void pblImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int nPosX = e.X;
                int nPosY = e.Y;

                try
                {
                    
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateDisplay(List<System.Drawing.Point> points = null)
        {
            //if (ImageSource.IsVoid) return;

            //using (Graphics g = Graphics.FromImage(ImageDisplay))
            //{
            //    m_fScaleFactorX = (float)pblImage.Width / (float)ImageSource.Width;
            //    m_fScaleFactorY = (float)pblImage.Height / (float)ImageSource.Height;

            //    ImageSource.Draw(g, m_fScaleFactorX, m_fScaleFactorY, g.Transform.OffsetX, g.Transform.OffsetY);
            //    eLineGuage.Draw(g);
            //    eLineGuage.Draw(g, EDrawingMode.Nominal);
            //    //eLineGuage.Draw(g, EDrawingMode.Actual);
            //    //eLineGuage.Draw(g, EDrawingMode.InvalidSampledPoints);
            //    eLineGuage.Draw(g, EDrawingMode.SampledPoints);

            //    int nMeasCount = (int)eLineGuage.NumValidSamples;
            //    ELine eLine = eLineGuage.MeasuredLine;

            //    int nSpecOutMin = int.MaxValue;
            //    int nSpecOutMax = int.MinValue;

            //    for (int i = 0; i < nMeasCount; i++)
            //    {
            //        using (EPoint ptMeas = new EPoint())
            //        {
            //            eLineGuage.GetSample(ptMeas, (uint)i);

            //            if (ptMeas.X == 0 || ptMeas.Y == 0) continue;

            //            double dDistance = IMath.GetDistanceLineToPoint(ptMeas, eLine);

            //            nSpecOutMin = nSpecOutMin > dDistance ? (int)dDistance : nSpecOutMin;
            //            nSpecOutMax = nSpecOutMax < dDistance ? (int)dDistance : nSpecOutMax;
            //        }
            //    }

            //    string strSpecOutMin = $"SPEC OUT 최소 픽셀 거리 [기준선 <-> 불량]: {nSpecOutMin}";
            //    string strSpecOutMax = $"SPEC OUT 최대 픽셀 거리 [기준선 <-> 불량]: {nSpecOutMax}";

            //    g.DrawString(strSpecOutMin, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Red), new PointF(10, ImageSource.Height * 0.85F * m_fScaleFactorY));
            //    g.DrawString(strSpecOutMax, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Red), new PointF(10, ImageSource.Height * 0.90F * m_fScaleFactorY));

            //    pblImage.Image = ImageDisplay;
            //}
        }

        private void pblImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int nPosX = e.X;
                int nPosY = e.Y;

                try
                {
                    
                    UpdateDisplay();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                GC.Collect();
            }
        }

        private void pblImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int nPosX = e.X;
                int nPosY = e.Y;

                try
                {
                  
                    
                    UpdateDisplay();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void trbThreshold_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
           
        }

   

        private void btnGrab_Click(object sender, EventArgs e)
        {
            //Global.CamManager.Cameras[m_nCameraIndex].Grab();

            //Thread.Sleep(250);

            //int nThreshold = trbThreshold.Value;
            //lbThreshold.Text = nThreshold.ToString();

            //using (EImageBW8 ImageGrab = new EImageBW8())
            //using (Graphics g = Graphics.FromImage(ImageDisplay))
            //{
            //    ImageGrab.SetSize(Global.CamManager.Cameras[m_nCameraIndex].ImageGrab);
            //    //EasyImage.Oper(EArithmeticLogicOperation.Copy, Global.CamManager.Cameras[m_nCameraIndex].ImageGrab, ImageSource);

            //    ImageGrab.Draw(g, m_fScaleFactorX, m_fScaleFactorY, g.Transform.OffsetX, g.Transform.OffsetY);

            //    eLineGuage.Measure(ImageSource);
            //    eLineGuage.Draw(g);
            //    eLineGuage.Draw(g, EDrawingMode.Nominal);
            //    eLineGuage.Draw(g, EDrawingMode.SampledPoints);

            //    pblImage.Image = ImageDisplay;
            //}

            //UpdateDisplay();
        }



        private void btnApply_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Global.System.Recipe.SaveConfig();                
            }
            catch (Exception ex)
            {

            }
        }

        private void pblImage_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //if(e.Button == MouseButtons.Right)
                //{
                //    if (!ImageSource.IsVoid)
                //    {
                //        ImageDisplay = new Bitmap(ImageSource.Width, ImageSource.Height);
                //        ImageSource.SetSize(ImageSource);
                //        //EasyImage.Oper(EArithmeticLogicOperation.Copy, ImageSource, ImageSource);

                //        m_fScaleFactorX = (float)pblImage.Width / (float)ImageSource.Width;
                //        m_fScaleFactorY = (float)pblImage.Height / (float)ImageSource.Height;

                //        int nCenterX = ImageSource.Width / 2;
                //        int nCenterY = ImageSource.Height / 2;

                //        int nTolerance = ImageSource.Width / 10;
                //        int nLength = ImageSource.Width / 4;

                //        eLineGuage.SetCenterXY(nCenterX, nCenterY);
                //        eLineGuage.SetZoom(m_fScaleFactorX, m_fScaleFactorY);
                //        eLineGuage.Tolerance = nTolerance;
                //        eLineGuage.Length = nLength;
                //        eLineGuage.Thickness = 1;
                //        eLineGuage.Smoothing = 1;
                //        eLineGuage.Threshold = 20;
                //        eLineGuage.Angle = 180;

                //        eLineGuage.TransitionType = ETransitionType.Wb;
                //        eLineGuage.TransitionChoice = ETransitionChoice.NthFromBegin;
                //        eLineGuage.SamplingStep = 5;

                //        eLineGuage.Dragable = true;
                //        eLineGuage.Resizable = true;
                //        eLineGuage.Rotatable = true;
                //    }

                //    UpdateDisplay();
                //}
            }
            catch(Exception Desc)
            {
                //Logger.WriteLog(LOG.AbNormal, )
            }
        }

        private void btnImageLoad_Click(object sender, EventArgs e)
        {
            try
            {
                //string strImagePath = CUtil.LoadImage();

                //if (strImagePath != "") ImageSource.Load(strImagePath);
                //UpdateDisplay();
            }
            catch (Exception ex)
            {
                //Logger.WriteLog(LOG.AbNormal, )
            }
        }

        private void btnImageSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ImageSource.IsVoid) return;

                //CUtil.InitDirectory(DEFINE.CAPTURE);
                //string strImagePath = Application.StartupPath + "\\" + DEFINE.CAPTURE + "\\Image_" + DateTime.Now.ToString("yyyyMMdd-HHmmssfff") + ".jpg";

                //int[] sizes = new int[2] { (int)ImageSource.Height, (int)ImageSource.Width };
                //IntPtr intPtr = ImageSource.GetImagePtr();
                //OpenCvSharp.Mat MatGrab = new OpenCvSharp.Mat(sizes, OpenCvSharp.MatType.CV_8UC1, intPtr);
                //OpenCvSharp.Cv2.ImShow("TEST", MatGrab);
                ////MatGrab = MatGrab.Resize(new OpenCvSharp.Size(pblMain.Width, pblMain.Height));
                ////pblMain.ImageIpl = MatGrab;

                //if (strImagePath != "") ImageSource.Save(strImagePath);
            }
            catch (Exception ex)
            {
                //Logger.WriteLog(LOG.AbNormal, )
            }
        }

        private void pblImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                //if (ImageSource.IsVoid) return;

                //int[] sizes = new int[2] { (int)ImageSource.Height, (int)ImageSource.Width };
                //IntPtr intPtr = ImageSource.GetImagePtr();
                //OpenCvSharp.Mat imageConvert = new OpenCvSharp.Mat(sizes, OpenCvSharp.MatType.CV_8UC1, intPtr);
                //OpenCvSharp.Cv2.ImShow("TEST", imageConvert);

                //FormImageView FrmImageViewer = new FormImageView(imageConvert);
                //FrmImageViewer.Show();
            }
            catch (Exception ex)
            {
                //Logger.WriteLog(LOG.AbNormal, )
            }
            
        }

        private void lbUseInsp_Click(object sender, EventArgs e)
        {
            try
            {
                //Global.iSystem.Recipe.Tools[m_SeletedToolIndex].UseInsp = !Global.iSystem.Recipe.Tools[m_SeletedToolIndex].UseInsp;

                //lbUseInsp.Style = Global.iSystem.Recipe.Tools[m_SeletedToolIndex].UseInsp ? MetroColorStyle.Lime : MetroColorStyle.Silver;
                //lbUseInsp.Text = Global.iSystem.Recipe.Tools[m_SeletedToolIndex].UseInsp ? "검사 사용" : "검사 패스";
            }
            catch (Exception ex)
            {
                //Logger.WriteLog(LOG.AbNormal, )
            }
        }

        private void OnClickCameraOperation(object sender, EventArgs e)
        {
            try
            {
                string strIndex = (sender as MetroButton).Text;

                switch(strIndex)
                {
                    case "SETTING":                       
                        break;
                    case "GRAB":
                        //Global.iDevice.CAMERA.GrabStart();
                        break;
                    case "LIVE":
                        //Global.iDevice.CAMERA.Live(true);
                        (sender as MetroTile).Text = "LIVE STOP";
                        break;
                    case "LIVE STOP":
                        //Global.iDevice.CAMERA.Live(false);
                        (sender as MetroTile).Text = "LIVE";
                        break;
                    case "IMAGE LOAD":
                        string strImagePath = CUtil.LoadImage();
                        //Bitmap imageload = new Bitmap(strImagePath);
                        ImageSource = Cv2.ImRead(strImagePath);

                        //Bitmap imageLoad = Global.iDevice.CAMERA.LoadImage(strImagePath, ref ImageMSource);
                        //ibSource.Image = imageLoad;
                        //MIL.MdispSelectWindow(Global.iDevice.CAMERA.MIL_Display, ImageMSource, pnDisplay.Handle);
                        InitInteractivity();

                        break;
                    case "IMAGE SAVE":
                        strImagePath = CUtil.SaveImage();
                        Cv2.ImWrite(strImagePath, ImageSource);
                        break;
                    case "TRIG (SW)":
                        Global.iDevice.CAMERA_LD.SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW);
                        Global.iDevice.CAMERA_ULD.SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_SW);
                        break;
                    case "TRIG (HW)":
                        Global.iDevice.CAMERA_LD.SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_HW);
                        Global.iDevice.CAMERA_ULD.SetTriggerMode(CPropertyCamera.TRIGGER_MODE_TYPE.ON_HW);
                        break;
                    case "보기 (전체)":
                        break;
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }


        private void InitInteractivity()
        {

        }


        private void btnLightSetting_Click(object sender, EventArgs e)
        {
            try
            {
                FormSettings_Illumination FrmSetting_Illumination = new FormSettings_Illumination();
                FrmSetting_Illumination.ShowDialog();

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void trbLightValue_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                CUtil.ShowMessageBox("EXCEPTION", ex.Message, FormMessageBox.MESSAGEBOX_TYPE.OK);
            }
        }

        private void btnCameraSetting_Click(object sender, EventArgs e)
        {
            try
            {
                FormSettings_Grabber FrmSetting_Grabber = new FormSettings_Grabber();
                FrmSetting_Grabber.ShowDialog();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnFindContour_Click(object sender, EventArgs e)
        {
        }

        private void btnROI_BCR_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {

            }
        }

        private void btnRun_BCR_Click(object sender, EventArgs e)
        {
        }

        private void btnDistRoiInsp1_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnDistRoiInsp2_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnDistanceRun_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {

            }
        }

        private void btnDistRoiAlign_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void rdbMin_CheckedChanged(object sender, EventArgs e)
        {
            Global.System.Recipe.Insp_Min_Use = true;
            Global.System.Recipe.Insp_Max_Use = false;
            Global.System.Recipe.Insp_Avg_Use = false;
        }

        private void rdbMax_CheckedChanged(object sender, EventArgs e)
        {
            Global.System.Recipe.Insp_Min_Use = false;
            Global.System.Recipe.Insp_Max_Use = true;
            Global.System.Recipe.Insp_Avg_Use = false;
        }

        private void rdbAvg_CheckedChanged(object sender, EventArgs e)
        {
            Global.System.Recipe.Insp_Min_Use = false;
            Global.System.Recipe.Insp_Max_Use = false;
            Global.System.Recipe.Insp_Avg_Use = true;
        }

        private void btnTeaching_Click(object sender, EventArgs e)
        {
#if MATROX
            FormSettings_CVEdge FrmTest = new FormSettings_CVEdge();
            FrmTest.Show(); 
#endif
        }
        private void timerStatus_Tick(object sender, EventArgs e)
        {        
        }

        private void OnChangeTabPage( object sender, EventArgs e )
        {
            try
            {
                string strIndex = tcParameter.TabPages[tcParameter.SelectedIndex].Text;

                switch(strIndex)
                {
                    case "Parameter (S/W)":
                    case "Parameter (H/W)":
                        timerIO.Enabled = false;
                        break;

                    case "INPUT":
                    case "OUTPUT":
                        timerIO.Enabled = true;
                        break;
                }
            }
            catch ( Exception ex )
            {
                CLogger.Add( LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod( ).ReflectedType.Name, MethodBase.GetCurrentMethod( ).Name, ex.Message );
            }
        }

        private void timerIO_Tick( object sender, EventArgs e )
        {
            try
              {
                CDIO_AJIN DIO = Global.iDevice.DIO_BD;
                //Test
                  if(DIO != null)
                  {
                    CUtil.UpdateLabelOnOff(lbInWorkCountSensor, DIO.DI_SYSTEM_MAIN_AIR_CHECK.IsOn);
                  
                  }
                
                if(Global.SeqScanTray != null)
                {
                    lbTrayCount.Text = Global.SeqScanTray.SCAN_TRAY_COUNT.ToString();
                }
            }
            catch ( Exception ex )
            {
                CLogger.Add( LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod( ).ReflectedType.Name, MethodBase.GetCurrentMethod( ).Name, ex.Message );
            }
        }

        private void dgvDO_CellContentClick( object sender, DataGridViewCellEventArgs e )
        {
            try
            {
            }
            catch ( Exception ex )
            {
                CLogger.Add( LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod( ).ReflectedType.Name, MethodBase.GetCurrentMethod( ).Name, ex.Message );
            }
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            CUtil.InputOnlyNumber(sender, e, true, true);
        }


        public const string UpperLift_Top_Wait_Get_Z = "btnUpperLift_Top_Wait_Get_Z";
        public const string UpperLift_Top_Work_Get_Z = "btnUpperLift_Top_Work_Get_Z";
        public const string UpperLift_Bottom_Wait_Get_Z = "btnUpperLift_Bottom_Wait_Get_Z";
        public const string UpperLift_Bottom_Work_Get_Z = "btnUpperLift_Bottom_Work_Get_Z";

#region Picker1
        public const string WorkPicker1_Default_WaitZ_Get_Z = "btnWorkPicker1_Default_WaitZ_Get_Z";
        public const string WorkPicker1_Loader_Conv_Wait_Get_Y = "btnWorkPicker1_Loader_Conv_Wait_Get_Y";
        public const string WorkPicker1_Loader_Conv_Work_Get_Y = "btnWorkPicker1_Loader_Conv_Work_Get_Y";
        public const string WorkPicker1_Loader_Conv_Work_Get_Z = "btnWorkPicker1_Loader_Conv_Work_Get_Z";

        public const string WorkPicker1_UnLoader_Conv_Wait_Get_Y = "btnWorkPicker1_UnLoader_Conv_Wait_Get_Y";
        public const string WorkPicker1_UnLoader_Conv_Work_Get_Y = "btnWorkPicker1_UnLoader_Conv_Work_Get_Y";
        public const string WorkPicker1_UnLoader_Conv_Work_Get_Z = "btnWorkPicker1_UnLoader_Conv_Work_Get_Z";

        public const string WorkPicker1_Work_Done_Conv_Wait_Get_Y = "btnWorkPicker1_Work_Done_Conv_Wait_Get_Y";        
        public const string WorkPicker1_Work_Done_Conv_Work_Get_Y = "btnWorkPicker1_Work_Done_Conv_Work_Get_Y";
        public const string WorkPicker1_Work_Done_Conv_Work_Get_Z = "btnWorkPicker1_Work_Done_Conv_Work_Get_Z";
#endregion

#region Picker2
        public const string WorkPicker2_Tray_Conv_Wait_Get_Y = "btnWorkPicker2_Tray_Conv_Wait_Get_Y";
        public const string WorkPicker2_Tray_Conv_Work_Get_Y = "btnWorkPicker2_Tray_Conv_Work_Get_Y";
        public const string WorkPicker2_Tray_Conv_Work_Get_Z = "btnWorkPicker2_Tray_Conv_Work_Get_Z";

        public const string WorkPicker2_Conver_Conv_Wait_Get_Y = "btnWorkPicker2_Conver_Conv_Wait_Get_Y";
        public const string WorkPicker2_Conver_Conv_Work_Get_Y = "btnWorkPicker2_Conver_Conv_Work_Get_Y";
        public const string WorkPicker2_Conver_Conv_Work_Get_Z = "btnWorkPicker2_Conver_Conv_Work_Get_Z";

        public const string WorkPicker2_Vision_Loader_Wait_Get_Y = "btnWorkPicker2_Vision_Loader_Wait_Get_Y";
        public const string WorkPicker2_Vision_Loader_Wait_Get_X = "btnWorkPicker2_Vision_Loader_Wait_Get_X";
        public const string WorkPicker2_Vision_Loader_Work_Get_Y = "btnWorkPicker2_Vision_Loader_Work_Get_Y";
        public const string WorkPicker2_Vision_Loader_Work_Get_X = "btnWorkPicker2_Vision_Loader_Work_Get_X";

        public const string WorkPicker2_Vision_UnLoader_Wait_Get_Y = "btnWorkPicker2_Vision_UnLoader_Wait_Get_Y";
        public const string WorkPicker2_Vision_UnLoader_Wait_Get_X = "btnWorkPicker2_Vision_UnLoader_Wait_Get_X";
        public const string WorkPicker2_Vision_UnLoader_Work_Get_Y = "btnWorkPicker2_Vision_UnLoader_Work_Get_Y";
        public const string WorkPicker2_Vision_UnLoader_Work_Get_X = "btnWorkPicker2_Vision_UnLoader_Work_Get_X";

#endregion

#region Buffer
        public const string Buffer_Loader_Buffer_Init_Get_Z = "btnBuffer_Loader_Buffer_Init_Get_Z";
        public const string Buffer_Metal_Tray_Or_Conver_Buffer_Init_Get_Z = "btnBuffer_Metal_Tray_Or_Conver_Buffer_Init_Get_Z";
        public const string Buffer_UnLoader_Buffer_Init_Get_Z = "btnBuffer_UnLoader_Buffer_Init_Get_Z";
        public const string Buffer_Work_Done_Buffer_Init_Get_Z = "btnBuffer_Work_Done_Buffer_Init_Get_Z";
        public const string Buffer_Work_Done_Buffer_Init_Get_F = "btnBuffer_Work_Done_Buffer_Init_Get_F";
        public const string Buffer_Work_Loading_Rail_Z = "btnBuffer_Work_Loading_Rail_Lift_Z";

#endregion

#region Lot Tansfer
        public const string LotTransfer_Pick_Wait_Get_X = "btnLotTransfer_Pick_Wait_Get_X";
        public const string LotTransfer_Pick_Wait_Get_Y = "btnLotTransfer_Pick_Wait_Get_Y";
        public const string LotTransfer_Pick_Wait_Get_Z = "btnLotTransfer_Pick_Wait_Get_Z";

        public const string LotTransfer_Pick_Work_Get_X = "btnLotTransfer_Pick_Work_Get_X";
        public const string LotTransfer_Pick_Work_Get_Y = "btnLotTransfer_Pick_Work_Get_Y";
        public const string LotTransfer_Pick_Work_Get_Z = "btnLotTransfer_Pick_Work_Get_Z";

        public const string LotTransfer_ScanStart_Z = "btnLotTransfer_SensorStart_Get_Z";
        

        public const string LotTransfer_Place_Wait_Get_X = "btnLotTransfer_Place_Wait_Get_X";
        public const string LotTransfer_Place_Wait_Get_Y = "btnLotTransfer_Place_Wait_Get_Y";
        public const string LotTransfer_Place_Wait_Get_Z = "btnLotTransfer_Place_Wait_Get_Z";

        public const string LotTransfer_Place_Work_Get_X = "btnLotTransfer_Place_Work_Get_X";
        public const string LotTransfer_Place_Work_Get_Y = "btnLotTransfer_Place_Work_Get_Y";
        public const string LotTransfer_Place_Work_Get_Z = "btnLotTransfer_Place_Work_Get_Z";
#endregion

#region Tray Left
        public const string Tray_Tray_Left_Top_Get_X = "btnTray_Tray_Left_Top_Get_X";
        public const string Tray_Tray_Left_Top_Get_Y = "btnTray_Tray_Left_Top_Get_Y";
#endregion

        private void OnGetAxisDistance_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (sender is MetroTile)
            //    {
            //        UpdateSelectedAxis((string)((sender as MetroTile).Tag));

            //        string strName = (string)((sender as MetroTile).Name);

            //        switch (strName)
            //        {
            //            #region Upeer Top
            //            case UpperLift_Top_Wait_Get_Z:
            //                tbUpperLift_Top_Wait_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            case UpperLift_Top_Work_Get_Z:
            //                tbUpperLift_Top_Work_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            #endregion
            //            #region Upeer Bottom
            //            case UpperLift_Bottom_Wait_Get_Z:
            //                tbUpperLift_Btm_Wait_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            case UpperLift_Bottom_Work_Get_Z:
            //                tbUpperLift_Btm_Work_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            #endregion

            //            #region Picker1 Loader

            //            case WorkPicker1_Default_WaitZ_Get_Z:
            //                tbWorkPicker1_Default_WaitZ_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker1_Loader_Conv_Wait_Get_Y:
            //                tbWorkPicker1_Loader_Conv_Wait_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker1_Loader_Conv_Work_Get_Y:
            //                tbWorkPicker1_Loader_Conv_Work_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker1_Loader_Conv_Work_Get_Z:
            //                tbWorkPicker1_Loader_Conv_Work_Z.Text = GetPulsePermm(Axis);
            //                break;

            //            #endregion

            //            #region Picker1 UnLoader  

            //            case WorkPicker1_UnLoader_Conv_Wait_Get_Y:
            //                tbWorkPicker1_UnLoader_Conv_Wait_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker1_UnLoader_Conv_Work_Get_Y:
            //                tbWorkPicker1_UnLoader_Conv_Work_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker1_UnLoader_Conv_Work_Get_Z:
            //                tbWorkPicker1_UnLoader_Conv_Work_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            #endregion

            //            #region Picker1 Work Done Conv
            //            case WorkPicker1_Work_Done_Conv_Wait_Get_Y:
            //                tbWorkPicker1_Work_Done_Conv_Wait_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker1_Work_Done_Conv_Work_Get_Y:
            //                tbWorkPicker1_Work_Done_Conv_Work_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker1_Work_Done_Conv_Work_Get_Z:
            //                tbWorkPicker1_Work_Done_Conv_Work_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            #endregion

            //            #region Picker2 Tray
            //            case WorkPicker2_Tray_Conv_Wait_Get_Y:
            //                tbWorkPicker2_Tray_Conv_Wait_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker2_Tray_Conv_Work_Get_Y:
            //                tbWorkPicker2_Tray_Conv_Work_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker2_Tray_Conv_Work_Get_Z:
            //                tbWorkPicker2_Tray_Conv_Work_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            #endregion
            //            //확인필요
            //            #region Picker2 Conver Conv
            //            case WorkPicker2_Conver_Conv_Wait_Get_Y:
            //                tbWorkPicker2_Conver_Conv_Wait_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker2_Conver_Conv_Work_Get_Y:
            //                tbWorkPicker2_Conver_Conv_Work_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker2_Conver_Conv_Work_Get_Z:
            //                tbWorkPicker2_Conver_Conv_Work_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            #endregion

            //            #region Picker2 Loader
            //            case WorkPicker2_Vision_Loader_Wait_Get_Y:
            //                tbWorkPicker2_Vision_Loader_Wait_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker2_Vision_Loader_Wait_Get_X:
            //                tbWorkPicker2_Vision_Loader_Wait_X.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker2_Vision_Loader_Work_Get_Y:
            //                tbWorkPicker2_Vision_Loader_Work_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker2_Vision_Loader_Work_Get_X:
            //                tbWorkPicker2_Vision_Loader_Work_X.Text = GetPulsePermm(Axis);
            //                break;
            //            #endregion

            //            #region Picker2 UnLoader
            //            case WorkPicker2_Vision_UnLoader_Wait_Get_Y:
            //                tbWorkPicker2_Vision_UnLoader_Wait_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker2_Vision_UnLoader_Wait_Get_X:
            //                tbWorkPicker2_Vision_UnLoader_Wait_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker2_Vision_UnLoader_Work_Get_Y:
            //                tbWorkPicker2_Vision_UnLoader_Work_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case WorkPicker2_Vision_UnLoader_Work_Get_X:
            //                tbWorkPicker2_Vision_UnLoader_Work_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            #endregion
            //            //확인필요
            //            #region Buffer
            //            case Buffer_Loader_Buffer_Init_Get_Z:
            //                tbBuffer_Loader_Buffer_Init_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            case Buffer_Metal_Tray_Or_Conver_Buffer_Init_Get_Z:
            //                tbBuffer_Metal_Tray_Or_Conver_Buffer_Init_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            case Buffer_UnLoader_Buffer_Init_Get_Z:
            //                tbBuffer_UnLoader_Buffer_Init_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            //////
            //            case Buffer_Work_Done_Buffer_Init_Get_Z:
            //                break;
            //            case Buffer_Work_Loading_Rail_Z:
            //                break;

            //            #endregion

            //            #region Lot Transfer Pick_Wait
            //            case LotTransfer_Pick_Wait_Get_X:
            //                tbLotTransfer_Pick_Wait_X.Text = GetPulsePermm(Axis);
            //                break;
            //            case LotTransfer_Pick_Wait_Get_Y:
            //                tbLotTransfer_Pick_Wait_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case LotTransfer_Pick_Wait_Get_Z:
            //                tbLotTransfer_Pick_Wait_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            #endregion

            //            case "btnLotTransfer_Avoid_Y":
            //                tbLotTransfer_Avoid_Y.Text = GetPulsePermm(Axis);
            //                break;

            //            #region Lot Transfer Pick_Work
            //            case LotTransfer_Pick_Work_Get_X:
            //                tbLotTransfer_Pick_Work_X.Text = GetPulsePermm(Axis);
            //                break;
            //            case LotTransfer_Pick_Work_Get_Y:
            //                //tb.Text = GetPulsePermm(Axis);
            //                break;
            //            case LotTransfer_Pick_Work_Get_Z:
            //                tbLotTransfer_Pick_Work_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            #endregion

            //            #region Lot Transfer Place_Wait
            //            case LotTransfer_Place_Wait_Get_X:
            //                tbLotTransfer_Place_Wait_X.Text = GetPulsePermm(Axis);
            //                break;
            //            case LotTransfer_Place_Wait_Get_Y:
            //                tbLotTransfer_Place_Wait_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case LotTransfer_Place_Wait_Get_Z:
            //                tbLotTransfer_Place_Wait_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            #endregion

            //            #region Lot Transfer Place_Work
            //            case LotTransfer_Place_Work_Get_X:
            //                tbLotTransfer_Place_Work_X.Text = GetPulsePermm(Axis);
            //                break;
            //            case LotTransfer_Place_Work_Get_Y:
            //                tbLotTransfer_Place_Work_Y.Text = GetPulsePermm(Axis);
            //                break;
            //            case LotTransfer_Place_Work_Get_Z:
            //                tbLotTransfer_Place_Work_Z.Text = GetPulsePermm(Axis);
            //                break;
            //            #endregion


            //                #region Tray Loader Insp
            //                //case Tray_Tray_Left_Top_Get_X:
            //                //    tbTray_Tray_Left_Top_X.Text = GetPulsePermm(Axis);
            //                //    break;
            //                //case Tray_Tray_Left_Top_Get_Y:
            //                //    tbTray_Tray_Left_Top_Y.Text = GetPulsePermm(Axis);
            //                //    break;
            //                #endregion

            //                #region Tray UnLoader Insp
            //                //case Tray_Tray_Left_Top_Get_X:
            //                //    tbTray_Tray_Left_Top_X.Text = GetPulsePermm(Axis);
            //                //    break;
            //                //case Tray_Tray_Left_Top_Get_Y:
            //                //    tbTray_Tray_Left_Top_Y.Text = GetPulsePermm(Axis);
            //                //    break;
            //                #endregion

            //        }
            //    }

            //    CLogger.Add(LOG.TEACHING, $"GET POSITION ==> NO : {Axis.AxisNo} NAME : {Axis.AxisName} POSITION : {GetPulsePermm(Axis)}");

            //    CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            //}
            //catch (Exception ex)
            //{
            //    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            //}
        }

        private string GetPulsePermm(CAXIS_AJIN Axis)
        {
            return (Axis.Status.ActualPos).ToString();
        }

        private void btnStartHome_Click(object sender, EventArgs e)
        {
            try
            {
                if (Axis == null) CUtil.ShowMessageBox("ALARM", "SELECT THE AXIS");
                else
                {
                    if(CUtil.ShowMessageBox("CHECK", "DO YOU WANT TO SET THE HOME?", FormMessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                    {
                        Axis.StartThreadHome();
                    }                    
                }
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnJogMinus_Click(object sender, EventArgs e)
        {

        }

        private void OnClickControlAxis(object sender, EventArgs e)
        {
            try
            {
                if(sender is MetroTile)
                {
                    string strIndex = (string)((sender as MetroTile).Tag);

                    //UpdateSelectedAxis(strIndex);                    
                }
                
                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnAxisStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (Axis == null) return;

                Axis.JogStop();
                Axis.EStop();

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

#region POSITION SAVE
        private void btnUpperLift_Top_Wait_Save_Z_Click(object sender, EventArgs e)
        {
            try
            {
                //CMotionManager manager = Global.iDevice.MOTION_AJIN;

                //double dPos = double.Parse(tbUpperLift_Top_Wait_Z.Text);
                //double dSpeedFast = double.Parse(tbUpperLift_Top_Wait_FastSpeed_Z.Text);
                //double dSpeedSlow = double.Parse(tbUpperLift_Top_Wait_SlowSpeed_Z.Text);

                //if (CUtil.ShowMessageBox("SAVE", "DO YOU WANT TO SAVE?", FormMessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                //{
                //    manager.POS_UPPER_LIFT_TOP_WAIT_Z.POSITION = dPos;
                //    manager.POS_UPPER_LIFT_TOP_WAIT_Z.SPEED_FAST = dSpeedFast;
                //    manager.POS_UPPER_LIFT_TOP_WAIT_Z.SPEED_SLOW = dSpeedSlow;
                //    manager.POS_UPPER_LIFT_TOP_WAIT_Z.SaveConfig(Global.System.Recipe.Name);


                //    CLogger.Add(LOG.TEACHING, $"POSITION SAVE ==> POS_UPPER_LIFT_TOP_WAIT_Z  POS : {dPos} SPEED FAST : {dSpeedFast} SPEED SLOW : {dSpeedSlow}");
                //}
                //else
                //{
                //    CLogger.Add(LOG.TEACHING, $"POSITION SAVE CANCEL ==> POS_UPPER_LIFT_TOP_WAIT_Z  POS : {dPos} SPEED FAST : {dSpeedFast} SPEED SLOW : {dSpeedSlow}");
                //}

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnUpperLift_Top_Work_Save_Z_Click(object sender, EventArgs e)
        {
            try
            {
                //CMotionManager manager = Global.iDevice.MOTION_AJIN;

                //double dPos = double.Parse(tbUpperLift_Top_Work_Z.Text);
                //double dSpeedFast = double.Parse(tbUpperLift_Top_Work_FastSpeed_Z.Text);
                //double dSpeedSlow = double.Parse(tbUpperLift_Top_Work_SlowSpeed_Z.Text);

                //if (CUtil.ShowMessageBox("SAVE", "DO YOU WANT TO SAVE?", FormMessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                //{
                //    manager.POS_UPPER_LIFT_TOP_WORK_Z.POSITION = dPos;
                //    manager.POS_UPPER_LIFT_TOP_WORK_Z.SPEED_FAST = dSpeedFast;
                //    manager.POS_UPPER_LIFT_TOP_WORK_Z.SPEED_SLOW = dSpeedSlow;
                //    manager.POS_UPPER_LIFT_TOP_WORK_Z.SaveConfig(Global.System.Recipe.Name);


                //    CLogger.Add(LOG.TEACHING, $"POSITION SAVE ==> POS_UPPER_LIFT_TOP_WORK_Z  POS : {dPos} SPEED FAST : {dSpeedFast} SPEED SLOW : {dSpeedSlow}");
                //}
                //else
                //{
                //    CLogger.Add(LOG.TEACHING, $"POSITION SAVE CANCEL ==> POS_UPPER_LIFT_TOP_WORK_Z  POS : {dPos} SPEED FAST : {dSpeedFast} SPEED SLOW : {dSpeedSlow}");
                //}

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnUpperLift_Bottom_Wait_Save_Z_Click(object sender, EventArgs e)
        {
            try
            {
                //CMotionManager manager = Global.iDevice.MOTION_AJIN;

                //double dPos = double.Parse(tbUpperLift_Btm_Wait_Z.Text);
                //double dSpeedFast = double.Parse(tbUpperLift_Btm_Wait_FastSpeed_Z.Text);
                //double dSpeedSlow = double.Parse(tbUpperLift_Btm_Wait_SlowSpeed_Z.Text);

                //if (CUtil.ShowMessageBox("SAVE", "DO YOU WANT TO SAVE?", FormMessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                //{
                //    manager.POS_UPPER_LIFT_BTM_WAIT_Z.POSITION = dPos;
                //    manager.POS_UPPER_LIFT_BTM_WAIT_Z.SPEED_FAST = dSpeedFast;
                //    manager.POS_UPPER_LIFT_BTM_WAIT_Z.SPEED_SLOW = dSpeedSlow;
                //    manager.POS_UPPER_LIFT_BTM_WAIT_Z.SaveConfig(Global.System.Recipe.Name);

                //    CLogger.Add(LOG.TEACHING, $"POSITION SAVE ==> POS_UPPER_LIFT_BTM_WAIT_Z  POS : {dPos} SPEED FAST : {dSpeedFast} SPEED SLOW : {dSpeedSlow}");
                //}
                //else
                //{
                //    CLogger.Add(LOG.TEACHING, $"POSITION SAVE CANCEL ==> POS_UPPER_LIFT_BTM_WAIT_Z  POS : {dPos} SPEED FAST : {dSpeedFast} SPEED SLOW : {dSpeedSlow}");
                //}

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnUpperLift_Bottom_Work_Save_Z_Click(object sender, EventArgs e)
        {
            try
            {
                //CMotionManager manager = Global.iDevice.MOTION_AJIN;

                //double dPos = double.Parse(tbUpperLift_Btm_Work_Z.Text);
                //double dSpeedFast = double.Parse(tbUpperLift_Btm_Work_FastSpeed_Z.Text);
                //double dSpeedSlow = double.Parse(tbUpperLift_Btm_Work_SlowSpeed_Z.Text);

                //if (CUtil.ShowMessageBox("SAVE", "DO YOU WANT TO SAVE?", FormMessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                //{
                //    manager.POS_UPPER_LIFT_BTM_WORK_Z.POSITION = dPos;
                //    manager.POS_UPPER_LIFT_BTM_WORK_Z.SPEED_FAST = dSpeedFast;
                //    manager.POS_UPPER_LIFT_BTM_WORK_Z.SPEED_SLOW = dSpeedSlow;
                //    manager.POS_UPPER_LIFT_BTM_WORK_Z.SaveConfig(Global.System.Recipe.Name);

                //    CLogger.Add(LOG.TEACHING, $"POSITION SAVE ==> POS_UPPER_LIFT_BTM_WORK_Z  POS : {dPos} SPEED FAST : {dSpeedFast} SPEED SLOW : {dSpeedSlow}");
                //}
                //else
                //{
                //    CLogger.Add(LOG.TEACHING, $"POSITION SAVE CANCEL ==> POS_UPPER_LIFT_BTM_WORK_Z  POS : {dPos} SPEED FAST : {dSpeedFast} SPEED SLOW : {dSpeedSlow}");
                //}

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
#endregion

        private void btnLotTransfer_Pick_Wait_Save_Click(object sender, EventArgs e)
        {
            try
            {
               

           
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnLotTransfer_Pick_Work_Save_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnLotTransfer_Place_Wait_Save_Click(object sender, EventArgs e)
        {
            try
            {


                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnLotTransfer_Place_Work_Save_Click(object sender, EventArgs e)
        {
            try
            {
             
                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void lbInWorkCountSensor_Click(object sender, EventArgs e)
        {
            Global.SeqScanTray.StartThreadSeq();
            
        }

        private void btnTrayIndexMove_Click(object sender, EventArgs e)
        {
            try
            {
                //int nIndex = int.Parse(tbTrayIndex.Text);

                //Dictionary<int, CAXIS_AJIN> Axises = Global.iDevice.MOTION_AJIN.Axises;
                //CMotionManager manager = Global.iDevice.MOTION_AJIN;

                //if (!Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_X].InpositionEx(manager.POS_LOT_TRANSFER_PICK_WORK_X))
                //{
                //    CUtil.ShowMessageBox("INTERLOCK", "FIRST MOVE THE POS_LOT_TRANSFER_PICK_WORK_X");
                //    return;
                //}

                //if (!Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_Y].InpositionEx(manager.POS_LOT_TRANSFER_PICK_WAIT_Y))
                //{
                //    CUtil.ShowMessageBox("INTERLOCK", "FIRST MOVE THE POS_LOT_TRANSFER_PICK_WAIT_Y");
                //    return;
                //}

                //double dPitch = Global.iData.PropertyTrayLoading.TRAY_HEIGHT;
                //double dTargetIndexPos = manager.POS_LOT_TRANSFER_PICK_WORK_Z.POSITION - (dPitch * nIndex);
                //Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_Z].Move(dTargetIndexPos, manager.POS_LOT_TRANSFER_PICK_WORK_Z.SPEED_SLOW);                

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnTrayInfoSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Global.iData.PropertyTrayLoading.TRAY_HEIGHT = double.Parse(tbTrayPitch.Text);
                //Global.iData.PropertyTrayLoading.MAX_TRAY_COUNT = int.Parse(tbTrayMaxCount.Text);

                //Global.iData.PropertyTrayLoading.SaveConfig(Global.System.Recipe.Name);

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnSaveLotTrasnferPos_Click(object sender, EventArgs e)
        {
            try
            {
              

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void OnClickSeqMove(object sender, EventArgs e)
        {
            try
            {
                if (sender is MetroTile)
                {
                    string strIndex = (string)((sender as MetroTile).Tag);

                    Dictionary<int, CAXIS_AJIN> Axises = Global.iDevice.MOTION_AJIN.Axises;
                    CMotionManager manager = Global.iDevice.MOTION_AJIN;

                    switch (strIndex)
                    {
                        case "UPPER_Z_BOTTOM_WORK":
                            if (!Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_Y].InpositionEx(manager.POS_LOT_TRANSFER_AVOID_Y))
                            {
                                CUtil.ShowMessageBox("INTERLOCK", "FIRST MOVE THE POS_LOT_TRANSFER_AVOID_Y");
                                return;
                            }

                            Axises[(int)DEFINE.MOTOR.UPPER_Z].Move(manager.POS_UPPER_LIFT_BTM_WORK_Z);
                            break;
                        case "LOT_TRANSFER_PICK_WAIT":
                            if (!Axises[(int)DEFINE.MOTOR.UPPER_Z].InpositionEx(manager.POS_UPPER_LIFT_BTM_WORK_Z))
                            {
                                CUtil.ShowMessageBox("INTERLOCK", "FIRST MOVE THE POS_UPPER_LIFT_BTM_WORK_Z");
                                return;
                            }

                            if (!Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_Z].InpositionEx(manager.POS_LOT_TRANSFER_PICK_WAIT_Z))
                            {
                                CUtil.ShowMessageBox("INTERLOCK", "FIRST MOVE THE POS_LOT_TRANSFER_PICK_WAIT_Z");
                                return;
                            }

                            Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_Z].Move(manager.POS_LOT_TRANSFER_PICK_WAIT_Z);
                            Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_X].Move(manager.POS_LOT_TRANSFER_PICK_WAIT_X);
                            Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_Y].Move(manager.POS_LOT_TRANSFER_PICK_WAIT_Y);
                            break;
                        case "LOT_TRANSFER_PICK_WORK":
                            if (!Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_X].InpositionEx(manager.POS_LOT_TRANSFER_PICK_WAIT_X))
                            {
                                CUtil.ShowMessageBox("INTERLOCK", "FIRST MOVE THE POS_LOT_TRANSFER_PICK_WAIT_X");
                                return;
                            }

                            if (!Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_Y].InpositionEx(manager.POS_LOT_TRANSFER_PICK_WAIT_Y))
                            {
                                CUtil.ShowMessageBox("INTERLOCK", "FIRST MOVE THE POS_LOT_TRANSFER_PICK_WAIT_Y");
                                return;
                            }

                            Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_Z].Move(manager.POS_LOT_TRANSFER_PICK_WORK_Z);
                            break;
                        case "LOT_TRANSFER_PICK_WORK_ALIGN":
                            if (!Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_Z].InpositionEx(manager.POS_LOT_TRANSFER_PICK_WORK_Z))
                            {
                                CUtil.ShowMessageBox("INTERLOCK", "FIRST MOVE THE POS_LOT_TRANSFER_PICK_WORK_Z");
                                return;
                            }

                            if (!Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_Y].InpositionEx(manager.POS_LOT_TRANSFER_PICK_WAIT_Y))
                            {
                                CUtil.ShowMessageBox("INTERLOCK", "FIRST MOVE THE POS_LOT_TRANSFER_PICK_WAIT_Y");
                                return;
                            }

                            Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_X].Move(manager.POS_LOT_TRANSFER_PICK_WORK_X);
                            break;
                        case "LOT_TRANSFER_SENSOR_START":
                            if (!Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_X].InpositionEx(manager.POS_LOT_TRANSFER_PICK_WORK_X))
                            {
                                CUtil.ShowMessageBox("INTERLOCK", "FIRST MOVE THE POS_LOT_TRANSFER_PICK_WAIT_X");
                                return;
                            }

                            if (!Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_Y].InpositionEx(manager.POS_LOT_TRANSFER_PICK_WAIT_Y))
                            {
                                CUtil.ShowMessageBox("INTERLOCK", "FIRST MOVE THE POS_LOT_TRANSFER_PICK_WAIT_Y");
                                return;
                            }

                            Axises[(int)DEFINE.MOTOR.LOT_TRANSFER_Z].Move(manager.POS_LOT_TRANSFER_SENSOR_START_Z);
                            break;
                    }

                    CLogger.Add(LOG.TEACHING, $"POSITION MOVE ==> {strIndex}");
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void cbPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strKey = cbPositions.Text;
                propertyGrid_Position.SelectedObject = Global.iDevice.MOTION_AJIN.Positions[strKey];
                propertyGrid_Position.Invalidate();

                int nAxisNo = Global.iDevice.MOTION_AJIN.Positions[strKey].AXIS_NO;

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnSaveAllPosition_Click(object sender, EventArgs e)
        {
            try
            {
                string strNow = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                CUtil.InitDirectory($"RECIPE\\{Global.System.Recipe.Name}\\{strNow}_SAVE_BEFORE");
                CUtil.InitDirectory($"RECIPE\\{Global.System.Recipe.Name}\\{strNow}_SAVE_AFTER");
                SynchFolder(new DirectoryInfo($"{Application.StartupPath}\\RECIPE\\{Global.System.Recipe.Name}\\MOTION"), new DirectoryInfo($"{Application.StartupPath}\\RECIPE\\{Global.System.Recipe.Name}\\{strNow}_SAVE_BEFORE"));
                for (int i = 0; i < Global.iDevice.MOTION_AJIN.Positions.Count; i++)
                {
                    Global.iDevice.MOTION_AJIN.Positions.ElementAt(i).Value.SaveConfig(Global.System.Recipe.Name);
                }

                SynchFolder(new DirectoryInfo($"{Application.StartupPath}\\RECIPE\\{Global.System.Recipe.Name}\\MOTION"), new DirectoryInfo($"{Application.StartupPath}\\RECIPE\\{Global.System.Recipe.Name}\\{strNow}_SAVE_AFTER"));

                CUtil.ShowMessageBox("NOTICE", "COMPLETE THE SAVE");

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void SynchFolder(DirectoryInfo existingDir, DirectoryInfo copyDir)
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
#endregion

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
#endregion
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }



        private void btnPrevPosition_Click(object sender, EventArgs e)
        {
            if (cbPositions.SelectedIndex > 0) cbPositions.SelectedIndex = (cbPositions.SelectedIndex - 1);
        }

        private void btnNextPosition_Click(object sender, EventArgs e)
        {
            if (cbPositions.SelectedIndex < cbPositions.Items.Count) cbPositions.SelectedIndex = (cbPositions.SelectedIndex + 1);
        }

        private void btnStartLotTransferSeq_Click(object sender, EventArgs e)
        {
            Global.SeqLotTransfer.StartThreadSeq();
        }

        private void btnBufferPitchSave_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnStartLoadingBuffer_Click(object sender, EventArgs e)
        {
        }

        private void btnStartZigElevator_Click(object sender, EventArgs e)
        {
            IGlobal.Instance.iData.SEQ_DATA.REQ_ID_MAPPING = true;
            Global.SeqZigElevator.StartThreadSeq();
        }

        private void btnID_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < IGlobal.Instance.iData.SEQ_DATA.BUFFER_METAL_TRAY_ID.Length; i++)
                {
                    CLogger.Add(LOG.NORMAL, $"METAL TRAY ID BUFFER #{i} ==> {IGlobal.Instance.iData.SEQ_DATA.BUFFER_METAL_TRAY_ID[i]}");
                    CLogger.Add(LOG.NORMAL, $"COVER TRAY ID BUFFER #{i} ==> {IGlobal.Instance.iData.SEQ_DATA.BUFFER_TOP_COVER_ID[i]}");
                }  

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void metroTile14_Click(object sender, EventArgs e)
        {
            try
            {
                Global.SeqWorkPicker.StartThreadSeq();
                Global.SeqCoverTrayFeed.StartThreadSeq();

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnGetCurrentPosition_Click(object sender, EventArgs e)
        {
            tbCurrentPosition.Text = (Status.ActualPos).ToString();
        }

        private void btnSetCurrentPosition_Click(object sender, EventArgs e)
        {
            try
            {
                string strKey = cbPositions.Text;
                Global.iDevice.MOTION_AJIN.Positions[strKey].POSITION = double.Parse(tbCurrentPosition.Text);
                propertyGrid_Position.SelectedObject = Global.iDevice.MOTION_AJIN.Positions[strKey];
                propertyGrid_Position.Invalidate();
            }
            catch
            {

            }
        }

        private void btnMotionCotrol_Click(object sender, EventArgs e)
        {
            try
            {
                string strKey = cbPositions.Text;
                propertyGrid_Position.SelectedObject = Global.iDevice.MOTION_AJIN.Positions[strKey];

                CMotionManager manager = Global.iDevice.MOTION_AJIN;
                FormViewer_MotionControl Frm = new FormViewer_MotionControl(Global.iDevice.MOTION_AJIN.Positions[strKey]);
                Frm.ShowDialog();

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }            
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            tcParameter.Visible = !tcParameter.Visible;
        }

        private void btnWorkDoneBufferIndexMove_Click(object sender, EventArgs e)
        {
            try
            {
                int nIndex = int.Parse(tbWorkDoneBufferIndex.Text);

                if(nIndex > 14)
                {
                    CUtil.ShowMessageBox("INTERLOCK", "최대 이동 가능 인덱스는 14입니다.");
                    return;
                }

                double dTargetIndex = Global.iDevice.MOTION_AJIN.POS_WORK_DONE_BUFFER_Z.POSITION - (nIndex * 30);

                if(Global.iDevice.DIO_BD.DI_WORK_DONE_INPUT_RAIL_INPUT_DETECT_BUFFER.IsOn
                    || Global.iDevice.DIO_BD.DI_WORK_DONE_INPUT_RAIL_OUTPUT_DETECT_BUFFER.IsOn)
                {
                    CUtil.ShowMessageBox("INTERLOCK", "CHECK THE WORK DONE BUFFER IN/OUT INTERLOCK");
                    return;
                }

                if (!Global.iDevice.MOTION_AJIN.Axises[(int)DEFINE.MOTOR.WORK_DONE_BUFFER_Z].InpositionEx(dTargetIndex))
                {
                    Global.iDevice.MOTION_AJIN.Axises[(int)DEFINE.MOTOR.WORK_DONE_BUFFER_Z].Move(dTargetIndex, 50);
                }


                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnJigElevatorIndexMove_Click(object sender, EventArgs e)
        {
            try
            {
                CDIO_AJIN DIO = Global.iDevice.DIO_BD;
                CMotionManager manager = Global.iDevice.MOTION_AJIN;
              
                int nIndex = int.Parse(tbJigElevatorIndex.Text);

                if (nIndex > 39)
                {
                    CUtil.ShowMessageBox("INTERLOCK", "최대 이동 가능 인덱스는 39입니다.");
                    return;
                }

                if (DIO.DI_METAL_TRAY_RAIL_Z_MOVE_INTERLOCK_DETECT_LOADING_SIDE.IsOn ||
                             DIO.DI_METAL_TRAY_RAIL_Z_MOVE_INTERLOCK_DETECT_UNLOADING_SIDE.IsOn ||
                             DIO.DI_TOP_COVER_RAIL_Z_MOVE_INTERLOCK_DETECT_LOADING_SIDE.IsOn ||
                             DIO.DI_TOP_COVER_RAIL_Z_MOVE_INTERLOCK_DETECT_UNLOADING_SIDE.IsOn)
                {
                    CUtil.ShowMessageBox("INTERLOCK", "CHECK THE JIG ELEVATOR INTERLOCK SENSOR");
                    return;
                }


                double dIndexPos = manager.POS_ZIG_ELAVATOR_INIT_Z.POSITION + (nIndex * Global.iData.PropertyBufferPitch.ZIG_ELEVATOR_PITCH);

                if (!manager.Axises[(int)DEFINE.MOTOR.JIG_ELEVATOR_Z].InpositionEx(dIndexPos))
                {
                    if (!manager.Axises[(int)DEFINE.MOTOR.JIG_ELEVATOR_Z].Status.InMotion)
                    {
                        if (manager.Axises[(int)DEFINE.MOTOR.JIG_ELEVATOR_Z].Move(dIndexPos, manager.POS_ZIG_ELAVATOR_INIT_Z.SPEED_SLOW))
                        {
                            if (DIO.DI_METAL_TRAY_RAIL_Z_MOVE_INTERLOCK_DETECT_LOADING_SIDE.IsOn ||
                                DIO.DI_METAL_TRAY_RAIL_Z_MOVE_INTERLOCK_DETECT_UNLOADING_SIDE.IsOn)
                            {
                                CAlarm.Add(new CNodeAlarm(DEFINE.Alarm_JIG_ELEVATOR_METAL_TRAY_INTERLOCK, "Please Check the Metal Tray Sensor"));
                            }
                            if (DIO.DI_TOP_COVER_RAIL_Z_MOVE_INTERLOCK_DETECT_LOADING_SIDE.IsOn ||
                               DIO.DI_TOP_COVER_RAIL_Z_MOVE_INTERLOCK_DETECT_UNLOADING_SIDE.IsOn)
                            {
                                CAlarm.Add(new CNodeAlarm(DEFINE.Alarm_JIG_ELEVATOR_TOP_COVER_INTERLOCK, "Please Check the Top Cover Sensor"));
                            }
                        }
                    }
                }


                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnWorkDoneBufferFeederPlus_Click(object sender, EventArgs e)
        {
            try
            {
                CDIO_AJIN DIO = Global.iDevice.DIO_BD;
                CMotionManager manager = Global.iDevice.MOTION_AJIN;

                DIO.On(DIO.DO_WORK_DONE_INPUT_RAIL_BUFFER_FEEDER_MOVING_CYL_FW);
                DIO.Off(DIO.DO_WORK_DONE_INPUT_RAIL_BUFFER_FEEDER_MOVING_CYL_BW);
                manager.Axises[(int)DEFINE.MOTOR.WORK_DONE_BUFFER_F].JogStart(+20);


                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnWorkDoneBufferFeederMinus_Click(object sender, EventArgs e)
        {
            try
            {
                CDIO_AJIN DIO = Global.iDevice.DIO_BD;
                CMotionManager manager = Global.iDevice.MOTION_AJIN;

                DIO.On(DIO.DO_WORK_DONE_INPUT_RAIL_BUFFER_FEEDER_MOVING_CYL_FW);
                DIO.Off(DIO.DO_WORK_DONE_INPUT_RAIL_BUFFER_FEEDER_MOVING_CYL_BW);
                manager.Axises[(int)DEFINE.MOTOR.WORK_DONE_BUFFER_F].JogStart(-20);


                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnWorkDoneBufferFeederStop_Click(object sender, EventArgs e)
        {
            try
            {
                CDIO_AJIN DIO = Global.iDevice.DIO_BD;
                CMotionManager manager = Global.iDevice.MOTION_AJIN;

                manager.Axises[(int)DEFINE.MOTOR.WORK_DONE_BUFFER_F].EStop();

                DIO.Off(DIO.DO_WORK_DONE_INPUT_RAIL_BUFFER_FEEDER_MOVING_CYL_FW);
                DIO.On(DIO.DO_WORK_DONE_INPUT_RAIL_BUFFER_FEEDER_MOVING_CYL_BW);

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
 }