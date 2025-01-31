namespace IntelligentFactory
{
    public static class DEFINE_COMMON
    {
        public static System.Drawing.Color COLOR_TEAL = System.Drawing.Color.FromArgb(96, 125, 139);
        public static System.Drawing.Color COLOR_GREEN = System.Drawing.Color.FromArgb(55, 159, 113);
        public static System.Drawing.Color COLOR_DARKGRAY = System.Drawing.Color.FromArgb(30, 30, 30);
        public static System.Drawing.Color COLOR_RED = System.Drawing.Color.FromArgb(234, 79, 82);
        public static System.Drawing.Color COLOR_NAVY = System.Drawing.Color.FromArgb(44, 46, 66);
        public static System.Drawing.Color COLOR_SKY_BLUE = System.Drawing.Color.FromArgb(140, 170, 210);
        //public static System.Drawing.Color COLOR_ORANGE = System.Drawing.Color.FromArgb(255, 128, 0);
        public static System.Drawing.Color COLOR_BLUEBLACK = System.Drawing.Color.FromArgb(68, 77, 86);
        public static System.Drawing.Color COLOR_ORANGE = System.Drawing.Color.FromArgb(243, 119, 53);
        public static System.Drawing.Color COLOR_BLACK30 = System.Drawing.Color.FromArgb(30, 30, 30);
        public static System.Drawing.Color COLOR_BLACK40 = System.Drawing.Color.FromArgb(40, 40, 40);
    }

    public static class DEFINE
    {
        #region 카메라 인덱스

        public const int CAM1 = 0;

        #endregion 카메라 인덱스

        public enum TYPE_NG : int
        {
            BCR = 0,
            MARK = 1,
            NA = 2,
            REVERSE = 3,
            PIN = 4,
            NA_MLCC = 5,
            NA_LEAD = 6,
            IDLE = 7,
            OK = 8,
            QR_MACHING = 9,
        }

        public const string ALARM_CODE_METAL_TRAY_LOADING_PUSHER = "-20";
        public const string ALARM_CODE_TOP_COVER_LOADING_PUSHER = "-21";

        public const string ALARM_COVER_TRAY_NA = "31000";

        public const string ALARM_CODE_DEVICE_LOST = "-30";

        public const string ALARM_TIME_OUT = "120";
        public const string ALARM_TIME_OUT_AXIS_MOVE = "121";
        public const string ALARM_TIME_OUT_AXIS_HOME = "122";

        public const string ALARM_INTERLOCK_SYSTEM = "219";
        public const string ALARM_INTERLOCK = "220";
        public const string ALARM_INTERLOCK_DOOR_OPEN_TOP = "221";
        public const string ALARM_INTERLOCK_DOOR_OPEN_BTM = "222";
        public const string ALARM_RESET_TIME_OUT = "320";

        public const string ALARM_VISION_REJECT = "32000";
        public const string ALARM_VISION_RETRY = "32010";

        public const string ALARM_CODE_VISION_SOURCE_EMPTY = "-1010";
        public const string ALARM_CODE_VISION_TEMPLATE_EMPTY = "-1020";

        public const string ALARM_DEVICE_CONNECTION = "1010";
        public const string ALARM_MODE_MANAUL = "1110";

        //SYSTEM 5000
        public const string ALARM_SYSTEM = "5000";

        public const string ALARM_REGIST_NULL = "6000";

        public const string ALARM_CODESYS_ERROR = "90000";

        public const string ALARM_BCR_READ_FAIL = "22000";
        public const string ALARM_TOP_COVER_BCR_READ_FAIL = "22010";
        public const string ALARM_METALTRAY_BCR_READ_FAIL = "22020";

        //SERVO STATUS 12000 ~
        public const string ALARM_SERVO_ALARM = "12001";

        public const string ALARM_SERVO_ABNORMAL_STATUS = "12002";

        //SERVO STATUS 12000 ~
        public const string ALARM_SERVO = "12000";

        public const string ALARM_SERVO_HOME_NOT_COMPLETE = "12003";

        //Work Done Buffer
        public const string ALARM_WORK_DONE_BUFFER = "15000";

        //Work Picker
        public const string ALARM_WORK_PICKER = "16000";

        //Flipper 1
        public const string ALARM_FLIPPER_1ST = "17000";

        //Flipper 2
        public const string ALARM_FLIPPER_2ND = "17050";

        //JIG ELEVATOR 22000 ~
        public const string ALARM_JIG_ELEVATOR_INTERLOCK = "22000";

        public const string Alarm_JIG_ELEVATOR_METAL_TRAY_INTERLOCK = "220010";
        public const string Alarm_JIG_ELEVATOR_TOP_COVER_INTERLOCK = "220020";

        public const string ALARM_TRAY_NA_LOADING_INPUT = "30010";
        public const string ALARM_TRAY_NA_LOADING_OUTPUT = "30020";
        public const string ALARM_TRAY_NA_UNLOADING = "30030";
        public const string ALARM_TRAY_NA_METAL_TRAY = "30040";
        public const string ALARM_TRAY_NA_TOP_COVER = "30050";
        public const string ALARM_TRAY_NA_WORK_DONE_BUFFER = "30060";

        public const string ALARM_TRAY_ALREADY_LOADING_INPUT = "31010";
        public const string ALARM_TRAY_ALREADY_LOADING_OUTPUT = "31020";
        public const string ALARM_TRAY_ALREADY_UNLOADING = "31030";
        public const string ALARM_TRAY_ALREADY_METAL_TRAY = "31040";
        public const string ALARM_TRAY_ALREADY_TOP_COVER = "31050";
        public const string ALARM_TRAY_ALREADY_WORK_DONE_BUFFER = "31060";

        public enum FLIP_TYPE : int
        { X, Y, XY };

        public enum FORM_RESULT : int
        { IDLE, SKIP, RETRY, REJECT };

        public enum RESULT : int
        {
            NA = 0,
            OK = 1,
            NG = 2,
            RVS = 3,
            CODE_NG = 4,
            CODE_COMPARE_NG = 5,
        }

        public enum AUTHORIZATION : uint
        { OPERATOR = 1, ENGINEER, MASTER };

        public const double PIXEL_RESOLUTION_UM = 4.3125;
        public const double PIXEL_RESOLUTION_MM = 0.0043125;

        public static System.Drawing.Color COLOR_TEAL = System.Drawing.Color.FromArgb(96, 125, 139);
        public static System.Drawing.Color COLOR_GREEN = System.Drawing.Color.FromArgb(55, 159, 113);
        public static System.Drawing.Color COLOR_DARKGRAY = System.Drawing.Color.FromArgb(30, 30, 30);
        public static System.Drawing.Color COLOR_RED = System.Drawing.Color.FromArgb(234, 79, 82);
        public static System.Drawing.Color COLOR_NAVY = System.Drawing.Color.FromArgb(44, 46, 66);
        public static System.Drawing.Color COLOR_SKY_BLUE = System.Drawing.Color.FromArgb(140, 170, 210);
        //public static System.Drawing.Color COLOR_ORANGE = System.Drawing.Color.FromArgb(255, 128, 0);
        public static System.Drawing.Color COLOR_BLUEBLACK = System.Drawing.Color.FromArgb(68, 77, 86);
        public static System.Drawing.Color COLOR_ORANGE = System.Drawing.Color.FromArgb(243, 119, 53);

        public const string PATH_RECIPE = "RECIPE";

        public const int ROI_RB = 0;
        public const int ROI_LB = 1;
        public const int ROI_RT = 2;
        public const int ROI_LT = 3;

        public const string Grab = "GRAB";
        public const string Live = "LIVE";
        public const string Live_Stop = "LIVE STOP";
        public const string Image_Load = "IMAGE LOAD";
        public const string Image_Save = "IMAGE SAVE";
        public const string Cross = "CROSS";
        public const string GrabSeq = "GRAB SEQ";

        public const string Blob = "Blob";
        public const string Pattern = "Pattern";
        public const string Filter = "Filter";

        public const int ImageW = 8192;
        public const int ImageH = 4000;

        public const int Main = 0;
        public const int Result = 1;
    }
}