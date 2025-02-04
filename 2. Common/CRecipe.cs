using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
//using Newtonsoft.Json;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace IntelligentFactory
{
    public class CRecipe
    {
        // 레시피의 파일 이름 정적변수..
        private const string Recipe_ROI_Region_FileJson = "TrainRegion.json";
        private const string Recipe_Library_FileJson = "Recipe_Library.json";
        private const string Recipe_Find_FileJson = "FindRegion.json";
        private const string Recipe_Fin_FileJson = "FinRegion.json";

        private const string RECIPE_DIRECTORY = "RECIPE";
        private string m_strName = "SETUP";
        // 현재 레시피의 이름을 가져옴...
        public string Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }

        // 이전코드 기억하기..
        public string Prev_Code;
        private string PbaCode { get; set; } = "DA41-00867C_R";
        // 현재 레시피의 PBACODE를 가져옴
        public string CODE
        {
            get { return PbaCode; }
            set { PbaCode = value; }
        }

        public string FIducialLibrary_Number { get; set; } = "0";

        public int QRBufferNo { get; set; } = 0;

        public CInspJobs JobManager_Array1/* = new CInspJobs()*/;
        public CInspJobs JobManager_Array2/* = new CInspJobs()*/;
        public CInspJobs JobManager_Array3/* = new CInspJobs()*/;
        public CInspJobs JobManager_Array4/* = new CInspJobs()*/;

        public Library_Fiducial FiducialLibrary { get; set; } = new Library_Fiducial();
        public LibraryManager LibraryManager { get; set; } = new LibraryManager("DEFAULT");
        public LibraryManager LoadedGerber { get; set; }

        public CInspJobs[] JobManager = new CInspJobs[4];
        public CGrabManager GrabManager { get; set; } = new CGrabManager();
        #region PARAMETER



        #region DISTANCE

        //public int    OverCount_Min = 5;
        public int Insp1_Thickness = 5;

        public int Insp1_PitchPixel = 5;
        public int Insp1_Polarity_Left = 0;
        public int Insp1_Polarity_Right = 1;
        public double Insp1_MinDistancemm = 6.5D;
        public double Insp1_MaxDistancemm = 9.5D;
        public bool Insp1_Use = true;

        public int Insp2_Thickness = 5;
        public int Insp2_PitchPixel = 5;
        public int Insp2_Polarity_Left = 0;
        public int Insp2_Polarity_Right = 1;
        public double Insp2_MinDistancemm = 6.5D;
        public double Insp2_MaxDistancemm = 9.5D;
        public bool Insp2_Use = true;

        public double Insp_Offset = 0.51D;

        #endregion DISTANCE

        #region Flag

        public bool Insp_Min_Use = false;
        public bool Insp_Max_Use = false;
        public bool Insp_Avg_Use = false;

        #endregion Flag

        #region DISTANCE

        public int Timeoutms = 5000;
        public int DataLength = 17;
        public Rectangle ROI = new Rectangle();

        #endregion DISTANCE

        #endregion PARAMETER

        // 현재 레시피에 저장되어있는 어레이 카운터값 가져오기
        public int ArrayCount = 2;


        public void LoadTools()
        {
            LoadConfig();
            // 메인 풀보드 패칭하는 어레이값 가져오기..
            SettingJob();
        }

        public void SettingJob()
        {
            bool ret = false;

            // Json 파일의 데이터를 우선 읽고나서...트레인 이미지 로드하기...
            string strFolderPath = $"{Global.m_MainPJTRoot}\\PBA_LIBRARY\\{CODE}";
            string str_EnabledFolderPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{Name}\\PBA_LIBRARY\\{CODE}";

            try
            {
                FiducialLibrary = FiducialLibrary.Load(CODE, FIducialLibrary_Number);
            }
            catch (Exception ex)
            {

            }
            try
            {
                // 해당 레시피 폴더가 없어졌을 경우...캐치로 빠지도록함...
                string[] directories = Directory.GetDirectories(strFolderPath);

                // 신규 레시피 폴더가 있는지 확인...없으면 구 레시피로 동작..
                for (int i = 0; i < directories.Length; i++)
                {
                    // 해당되는 이름이 있는지 확인..
                    if (directories[i].Contains("Array"))
                    {
                        // 파일 이름 검색...
                        string[] files = Directory.GetFiles(directories[i]);

                        // json파일이 있는지 확인...
                        if (files.Length > 0)
                        {
                            for (int j = 0; j < files.Length; j++)
                            {
                                // Json파일이 있는지 검색...
                                if (files[j].Contains(".json"))
                                {
                                    ret = true;
                                    break;
                                }
                            }
                        }

                        break;
                    }
                }

                if (ret)
                {
                    GrabManager = GrabManager.LoadConfig();
                    GrabManager.SaveConfig();

                    //                    PBALIBRARY_LoadTools(CODE, true);

                    if (JobManager_Array1 == null) JobManager_Array1 = new CInspJobs();
                    if (JobManager_Array2 == null) JobManager_Array2 = new CInspJobs();
                    if (JobManager_Array3 == null) JobManager_Array3 = new CInspJobs();
                    if (JobManager_Array4 == null) JobManager_Array4 = new CInspJobs();

                    JobManager = new CInspJobs[4] { JobManager_Array1, JobManager_Array2, JobManager_Array3, JobManager_Array4 };

                    bool[] ret_value = new bool[ArrayCount];

                    for (int array = 0; array < ArrayCount; array++)
                    {
                        JsonLoad(array, strFolderPath);
                        ret_value[array] = Enabled_JsonLoad(array, str_EnabledFolderPath);

                        // 이네이블 제이슨 파일이 없을 경우...아래 기존 파일 읽기..
                        if (!ret_value[array])
                        {
                            // Enabled 파일이 없을 경우...
                            // 해당 파일이 별도 없을 경우...기존 xml읽어서 뿌려줘야함...
                            EnableXML_LoadConfig();
                            // Enabled저장
                            // 읽어온 이네이블 값을 갱신해줘야함...
                            for (int j = 0; j < Global.Instance.System.Recipe.JobManager[array].Jobs.Count; j++)
                            {
                                // 동일한 이름의 레시피 목록에 이네이블 갱신해줌..
                                if (m_List_Enable_Name.Contains(Global.Instance.System.Recipe.JobManager[array].Jobs[j].Name))
                                {
                                    Global.Instance.System.Recipe.JobManager[array].Jobs[j].Enabled = true;
                                }
                                else
                                {
                                    Global.Instance.System.Recipe.JobManager[array].Jobs[j].Enabled = false;
                                }
                            }

                            EnabledJsonFile_Save(str_EnabledFolderPath, array);
                        }
                    }
                }
                else
                {
                    PBALIBRARY_LoadTools(CODE, true);

                    if (JobManager_Array1 == null) JobManager_Array1 = new CInspJobs();
                    if (JobManager_Array2 == null) JobManager_Array2 = new CInspJobs();
                    if (JobManager_Array3 == null) JobManager_Array3 = new CInspJobs();
                    if (JobManager_Array4 == null) JobManager_Array4 = new CInspJobs();

                    // 해당 파일이 별도 없을 경우...기존 xml읽어서 뿌려줘야함...
                    EnableXML_LoadConfig();

                    // 데이터 자동으로 저장...처리
                    if (!Directory.Exists(strFolderPath)) Directory.CreateDirectory(strFolderPath);

                    for (int i = 0; i < ArrayCount; i++)
                    {
                        JsonFile_Save(i, strFolderPath);
                    }

                    // Enabled저장

                    // xml에서 읽어오는 ArrayCount를 기준으로 처리..
                    for (int array = 0; array < ArrayCount; array++)
                    {
                        // 읽어온 이네이블 값을 갱신해줘야함...
                        for (int i = 0; i < Global.Instance.System.Recipe.JobManager[array].Jobs.Count; i++)
                        {
                            // 동일한 이름의 레시피 목록에 이네이블 갱신해줌..
                            if (m_List_Enable_Name.Contains(Global.Instance.System.Recipe.JobManager[array].Jobs[i].Name))
                            {
                                Global.Instance.System.Recipe.JobManager[array].Jobs[i].Enabled = true;
                            }
                            else
                            {
                                Global.Instance.System.Recipe.JobManager[array].Jobs[i].Enabled = false;
                            }
                        }

                        EnabledJsonFile_Save(str_EnabledFolderPath, array);
                    }
                }

                for (int i = 0; i < JobManager.Length; i++)
                {
                    for (int j = 0; j < JobManager[i].Jobs.Count; j++)
                    {
                        if (JobManager[i].Jobs[j].Parameter == null) JobManager[i].Jobs[j].Parameter = new JobParameter();
                        JobManager[i].Jobs[j].Parameter = JobManager[i].Jobs[j].Parameter.Load(CODE, i, JobManager[i].Jobs[j].Name);


                        if (JobManager[i].Jobs[j].Type.Contains("Condensor"))
                        {
                            string path = $"{Global.m_MainPJTRoot}\\PBA_LIBRARY\\{CODE}\\Array_{i}\\{JobManager[i].Jobs[j].Name}_FindCircle.vpp";
                            CCognexUtil.LoadCogTool(path, JobManager[i].Jobs[j].Find_Circle);
                        }

                        if (JobManager[i].Jobs[j].Type.Contains("Distance"))
                        {
                            string path = $"{Global.m_MainPJTRoot}\\PBA_LIBRARY\\{CODE}\\Array_{i}\\{JobManager[i].Jobs[j].Name}_FindLine.vpp";
                            CCognexUtil.LoadCogTool(path, JobManager[i].Jobs[j].Find_Line);
                        }
                    }
                }

                Task_TrainImage = Task.Run(() =>
                {
                    SetTrainImage(strFolderPath);
                });
            }
            catch
            {
                // 해당되는 라이브러리 폴더가 없을 경우 로그 기록...
                string str = $"PBA_LIBRARY Recipe No File Error : Model => {Name}, PBA Library => {CODE}";
                CLogger.Add(LOG.EXCEPTION, str);
            }
        }

        public bool bol_ChkTrainImage;
        public Task Task_TrainImage;
        public int TrainFullCount = 0;
        public int TrainCount = 0;
        public int TrainArrayIndex = 0;
        public void SetTrainImage(string strFolderPath)
        {
            bol_ChkTrainImage = true;
            // 해당되는 값에 맞는것들을 설정 해주기..
            // Main ~ SUB4까지의 툴에 데이터 셋해주기...
            // 트레인 이미지 및 Region값 셋하기..

            List<Task> tasksWait = new List<Task>();
            for (int Arrayindex = 0; Arrayindex < ArrayCount; Arrayindex++)
            {
                TrainArrayIndex = Arrayindex;
                string _Path = $"{strFolderPath}\\Array_{Arrayindex}";
                // Array Count에 맞춰서 Array Index의 값을 가져와야함..
                string filepath = $"{_Path}\\{Recipe_ROI_Region_FileJson}";
                // 트레인 이미지 셋하기...
                string strTrainImagPath = $"{_Path}\\TrainImage";

                if (File.Exists(filepath))
                {
                    string ContentTrain = System.IO.File.ReadAllText(filepath);
                    List<Json_Library_TrainRegion> L_Train = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Json_Library_TrainRegion>>(ContentTrain);
                    TrainFullCount = Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs.Count;

                    foreach (var l_Train in L_Train)
                    {
                        Cognex.VisionPro.CogRectangle CR = new CogRectangle();
                        Cognex.VisionPro.CogRectangle Serch = new CogRectangle();

                        double _x = double.Parse(l_Train.Roi_TrainRegion_X);
                        double _y = double.Parse(l_Train.Roi_TrainRegion_Y);
                        double _w = double.Parse(l_Train.Roi_TrainRegion_W);
                        double _h = double.Parse(l_Train.Roi_TrainRegion_H);

                        // 해당 리전값이 0 크지 않을경우에는 트레인 값이 없음..
                        if (_x > 0 && _y > 0 && _w > 0 && _h > 0)
                        {
                            CR.X = double.Parse(l_Train.Roi_TrainRegion_X);
                            CR.Y = double.Parse(l_Train.Roi_TrainRegion_Y);
                            CR.Width = double.Parse(l_Train.Roi_TrainRegion_W);
                            CR.Height = double.Parse(l_Train.Roi_TrainRegion_H);

                            // 검사영역 로드..
                            Serch.X = double.Parse(l_Train.Roi_SerchRegion_X);
                            Serch.Y = double.Parse(l_Train.Roi_SerchRegion_Y);

                            if (l_Train.Roi_SerchRegion_W == "0") l_Train.Roi_SerchRegion_W = "100";
                            if (l_Train.Roi_SerchRegion_H == "0") l_Train.Roi_SerchRegion_H = "100";
                            Serch.Width = double.Parse(l_Train.Roi_SerchRegion_W);
                            Serch.Height = double.Parse(l_Train.Roi_SerchRegion_H);

                            // 해당되는 값에 맞는것들을 설정 해주기..
                            // Main ~ SUB4까지의 툴에 데이터 셋해주기...
                            // 트레인 이미지 및 Region값 셋하기..
                            for (int i = 0; i < Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs.Count; i++)
                            {
                                if (l_Train.Roi_TrainName == Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Name)
                                {
                                    // Main
                                    //================================================================================================================
                                    if (l_Train.Roi_TrainType == "Main")
                                    {
                                        CogPMAlignTool nTool = Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Tool.Tool;

                                        // LC READ인 레시피는 마스터 카운트 셋해주기
                                        if (Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].LC_ReadUse)
                                        {
                                            nTool.RunParams.ApproximateNumberToFind = Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].MasterCount;
                                        }

                                        string Train_filepath = $"{strTrainImagPath}\\{Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Name}_Main.jpg";
                                        // 해당 파일이 있을경우...읽기..
                                        if (File.Exists(Train_filepath))
                                        {
                                            nTool.Pattern.TrainImage = new Cognex.VisionPro.CogImage8Grey(new Bitmap(Train_filepath));

                                            nTool.Pattern.TrainRegion = CR;
                                            nTool.Pattern.Origin.TranslationX = (nTool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterX;
                                            nTool.Pattern.Origin.TranslationY = (nTool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterY;
                                            // Serch 값 설정..
                                            nTool.SearchRegion = Serch;

                                            // 별도 리턴값이 없어서...해당 try ~ catch 처리..
                                            try
                                            {
                                                nTool.Pattern.Train();
                                            }
                                            catch
                                            {
                                                // 트레인 이미지가 정상적으로 로드되지 않을시 로그 기록..
                                                CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Load Error : Recipe Name => {Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Name}_Main");
                                            }
                                        }
                                    }
                                    //=================================================================================================================
                                    // Sub1
                                    //================================================================================================================
                                    else if (l_Train.Roi_TrainType == "Sub1")
                                    {
                                        CogPMAlignTool nTool = Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].SubTool1.Tool;

                                        string Train_filepath = $"{strTrainImagPath}\\{Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Name}_Sub1.jpg";
                                        if (File.Exists(Train_filepath))
                                        {
                                            nTool.Pattern.TrainImage = new Cognex.VisionPro.CogImage8Grey(new Bitmap(Train_filepath));

                                            nTool.Pattern.TrainRegion = CR;
                                            nTool.Pattern.Origin.TranslationX = (nTool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterX;
                                            nTool.Pattern.Origin.TranslationY = (nTool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterY;
                                            // Serch 값 설정..
                                            nTool.SearchRegion = Serch;

                                            try
                                            {
                                                nTool.Pattern.Train();
                                            }
                                            catch
                                            {
                                                // 트레인 이미지가 정상적으로 로드되지 않을시 로그 기록..
                                                CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Load Error : Recipe Name => {Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Name}_Sub1");
                                            }
                                        }
                                    }
                                    //=================================================================================================================
                                    // sub2
                                    else if (l_Train.Roi_TrainType == "Sub2")
                                    {
                                        CogPMAlignTool nTool = Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].SubTool2.Tool;

                                        string Train_filepath = $"{strTrainImagPath}\\{Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Name}_Sub2.jpg";
                                        if (File.Exists(Train_filepath))
                                        {
                                            nTool.Pattern.TrainImage = new Cognex.VisionPro.CogImage8Grey(new Bitmap(Train_filepath));

                                            nTool.Pattern.TrainRegion = CR;
                                            nTool.Pattern.Origin.TranslationX = (nTool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterX;
                                            nTool.Pattern.Origin.TranslationY = (nTool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterY;
                                            // Serch 값 설정..
                                            nTool.SearchRegion = Serch;

                                            try
                                            {
                                                nTool.Pattern.Train();
                                            }
                                            catch
                                            {
                                                // 트레인 이미지가 정상적으로 로드되지 않을시 로그 기록..
                                                CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Load Error : Recipe Name => {Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Name}_Sub2");
                                            }
                                        }
                                    }
                                    // sub3
                                    else if (l_Train.Roi_TrainType == "Sub3")
                                    {
                                        CogPMAlignTool nTool = Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].SubTool3.Tool;

                                        string Train_filepath = $"{strTrainImagPath}\\{Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Name}_Sub3.jpg";
                                        if (File.Exists(Train_filepath))
                                        {
                                            nTool.Pattern.TrainImage = new Cognex.VisionPro.CogImage8Grey(new Bitmap(Train_filepath));

                                            nTool.Pattern.TrainRegion = CR;
                                            nTool.Pattern.Origin.TranslationX = (nTool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterX;
                                            nTool.Pattern.Origin.TranslationY = (nTool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterY;
                                            // Serch 값 설정..
                                            nTool.SearchRegion = Serch;

                                            try
                                            {
                                                nTool.Pattern.Train();
                                            }
                                            catch
                                            {
                                                // 트레인 이미지가 정상적으로 로드되지 않을시 로그 기록..
                                                CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Load Error : Recipe Name => {Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Name}_Sub3");
                                            }
                                        }
                                    }
                                    // sub4
                                    else
                                    {
                                        CogPMAlignTool nTool = Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].SubTool4.Tool;

                                        string Train_filepath = $"{strTrainImagPath}\\{Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Name}_Sub4.jpg";
                                        if (File.Exists(Train_filepath))
                                        {
                                            nTool.Pattern.TrainImage = new Cognex.VisionPro.CogImage8Grey(new Bitmap(Train_filepath));

                                            nTool.Pattern.TrainRegion = CR;
                                            nTool.Pattern.Origin.TranslationX = (nTool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterX;
                                            nTool.Pattern.Origin.TranslationY = (nTool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).CenterY;
                                            // Serch 값 설정..
                                            nTool.SearchRegion = Serch;

                                            try
                                            {
                                                nTool.Pattern.Train();
                                            }
                                            catch
                                            {
                                                // 트레인 이미지가 정상적으로 로드되지 않을시 로그 기록..
                                                CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Load Error : Recipe Name => {Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Name}_Sub4");
                                            }
                                        }
                                    }

                                    TrainCount = i;
                                    break;
                                }
                            }
                        }
                    }

                }

                Task taskTrain = Task.Run(() =>
                {

                });

                tasksWait.Add(taskTrain);
            }

            Task.WaitAll(tasksWait.ToArray(), 30000);

            bol_ChkTrainImage = false;
        }

        public void MasterArray_JsonLoad(CCogTool_PMAlign Array, int Array_index)
        {
            // 해당 폴더가 있는지 검색..
            string strFolderPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{Name}\\Master";

            // 해당 폴더가 있을경우에 json찾기..
            if (Directory.Exists(strFolderPath))
            {
                string filepath = $"{strFolderPath}\\Array{Array_index}.json";
                if (File.Exists(filepath))
                {
                    // Json의 데이터 읽기..
                    string jsonContent = System.IO.File.ReadAllText(filepath);
                    List<Json_Master_TrainRegion> L_Train = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Json_Master_TrainRegion>>(jsonContent);

                    if (Array == null) Array = new CCogTool_PMAlign($"PMALIGN_ARRAY{Array_index}");

                    foreach (var R_Train in L_Train)
                    {
                        Cognex.VisionPro.CogRectangle Train_Rect = new CogRectangle();
                        Cognex.VisionPro.CogRectangle Serch_Rect = new CogRectangle();

                        if (double.Parse(R_Train.Roi_TrainRegion_X) > 0 && double.Parse(R_Train.Roi_TrainRegion_Y) > 0 && double.Parse(R_Train.Roi_TrainRegion_W) > 0 && double.Parse(R_Train.Roi_TrainRegion_H) > 0)
                        {
                            Train_Rect.X = double.Parse(R_Train.Roi_TrainRegion_X);
                            Train_Rect.Y = double.Parse(R_Train.Roi_TrainRegion_Y);
                            Train_Rect.Width = double.Parse(R_Train.Roi_TrainRegion_W);
                            Train_Rect.Height = double.Parse(R_Train.Roi_TrainRegion_H);
                        }

                        if (double.Parse(R_Train.Roi_SerchRegion_X) > 0 && double.Parse(R_Train.Roi_SerchRegion_Y) > 0 && double.Parse(R_Train.Roi_SerchRegion_W) > 0 && double.Parse(R_Train.Roi_SerchRegion_H) > 0)
                        {
                            Serch_Rect.X = double.Parse(R_Train.Roi_SerchRegion_X);
                            Serch_Rect.Y = double.Parse(R_Train.Roi_SerchRegion_Y);
                            Serch_Rect.Width = double.Parse(R_Train.Roi_SerchRegion_W);
                            Serch_Rect.Height = double.Parse(R_Train.Roi_SerchRegion_H);
                        }

                        Array.NAME = R_Train.Roi_TrainName;
                        Array.Tool.Pattern.TrainRegionMode = (CogRegionModeConstants)Enum.Parse(typeof(CogRegionModeConstants), R_Train.Roi_TrainMode);
                        Array.Tool.Pattern.TrainRegion = Train_Rect;
                        Array.Tool.SearchRegion = Serch_Rect;
                    }

                    string TrainPath = $"{strFolderPath}\\TrainImage";
                    if (Directory.Exists(TrainPath))
                    {
                        string Train_filepath = $"{TrainPath}\\Array{Array_index}.jpg";
                        // 해당 파일이 있을경우...읽기..
                        if (File.Exists(Train_filepath))
                        {
                            // 위에서 트레인 ROI와 서치 ROI 값을 가져오기 때문에 바로 이미지 넣어줌...
                            Array.Tool.Pattern.TrainImage = new Cognex.VisionPro.CogImage8Grey(new Bitmap(Train_filepath));
                            Array.Tool.Pattern.Origin.TranslationX = (Array.Tool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).X;
                            Array.Tool.Pattern.Origin.TranslationY = (Array.Tool.Pattern.TrainRegion as Cognex.VisionPro.CogRectangle).Y;

                            // 별도 리턴값이 없어서...해당 try ~ catch 처리..
                            try
                            {
                                Array.Tool.Pattern.Train();
                            }
                            catch
                            {
                                // 트레인 이미지가 정상적으로 로드되지 않을시 로그 기록..
                                CLogger.Add(LOG.EXCEPTION, $"Master Train Image Load Error : Master Name => Master_Array{Array_index}");
                            }
                        }
                    }
                }

            }
        }

        public bool Enabled_JsonLoad(int Arrayindex, string path)
        {
            bool nRet = false;

            if (Directory.Exists(path))
            {
                string strJsonFile = Path.Combine(path, $"Array{Arrayindex}_Enabled.json");
                // 해당 폴더가 있을경우...파일 로드..
                if (File.Exists(strJsonFile))
                {
                    // Json의 데이터 읽기..
                    string jsonContent = System.IO.File.ReadAllText(strJsonFile);
                    List<Json_Library_Enabled> L = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Json_Library_Enabled>>(jsonContent);

                    foreach (var l in L)
                    {
                        CJob newJob = new CJob();
                        newJob.Enabled = bool.Parse(l.Enabled);
                        newJob.Name = l.Name;

                        for (int i = 0; i < Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs.Count; i++)
                        {
                            // 동일한 이름의 레시피 목록에 이네이블 갱신해줌..
                            if (Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Name == newJob.Name)
                            {
                                Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Enabled = newJob.Enabled;

                                break;
                            }
                        }
                    }

                    nRet = true;
                }
                string strJsonCount = Path.Combine(path, $"Array{Arrayindex}_Enabled_Count.json");
                if (File.Exists(strJsonCount))
                {
                    string jsonContent = System.IO.File.ReadAllText(strJsonCount);
                    Json_Enabled_Count C = Newtonsoft.Json.JsonConvert.DeserializeObject<Json_Enabled_Count>(jsonContent);
                    nRet = true;
                }

            }
            return nRet;
        }

        public void JsonLoad(int Arrayindex, string path)
        {
            try
            {
                string strFolderPath = $"{path}\\Array_{Arrayindex}";

                if (Directory.Exists(strFolderPath))
                {
                    string filepath = $"{strFolderPath}\\{Recipe_Library_FileJson}";
                    // 해당 폴더가 있을경우...파일 로드..
                    if (File.Exists(filepath))
                    {
                        // Json의 데이터 읽기..
                        string jsonContent = System.IO.File.ReadAllText(filepath);
                        List<Json_Library> L = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Json_Library>>(jsonContent);

                        Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs.Clear();

                        foreach (var l in L)
                        {
                            CJob newJob = new CJob();
                            if (l == null) continue;
                            newJob.Tool.Tool.RunParams.AcceptThreshold = 0.01;
                            newJob.SubTool1.Tool.RunParams.AcceptThreshold = 0.01;
                            newJob.SubTool2.Tool.RunParams.AcceptThreshold = 0.01;
                            newJob.SubTool3.Tool.RunParams.AcceptThreshold = 0.01;
                            newJob.SubTool4.Tool.RunParams.AcceptThreshold = 0.01;
                            newJob.Enabled = bool.Parse(l.Enabled);
                            newJob.Type = l.Type;
                            newJob.GrabIndex = int.Parse(l.GrabIndex);
                            newJob.Name = l.Name;
                            newJob.SamplingCount = int.Parse(l.SamplingCount);
                            newJob.Judge_NaisNg = bool.Parse(l.Judge_NaisNg);
                            newJob.ChkColor = bool.Parse(l.ChkColor);
                            newJob.CCoordinate = (CJob.ColorCoordinate)Enum.Parse(typeof(CJob.ColorCoordinate), l.CCoordinate);
                            // 0보다 작을경우에는 -1이라는값으로 들어오므로...모두 디폴트값으로 적용..
                            if ((int)newJob.CCoordinate < 0) newJob.CCoordinate = CJob.ColorCoordinate.CC_GRAY;
                            newJob.CMethod = (CJob.ColorMethod)Enum.Parse(typeof(CJob.ColorMethod), l.CMethod);
                            // 0보다 작을경우에는 -1이라는값으로 들어오므로...모두 디폴트값으로 적용..
                            if ((int)newJob.CMethod < 0) newJob.CMethod = CJob.ColorMethod.CA_ConvertGray;
                            newJob.useBinary = bool.Parse(l.useBinary);
                            newJob.isSavePart = bool.Parse(l.isSavePart);
                            if (l.LC_ReadUse != null) newJob.LC_ReadUse = bool.Parse(l.LC_ReadUse);
                            if (l.MasterCount != null) newJob.MasterCount = int.Parse(l.MasterCount);
                            // 추가
                            if (l.MinFoundCount != null) newJob.MinFoundCount = int.Parse(l.MinFoundCount);
                            if (l.MinScore != null) newJob.MinScore = double.Parse(l.MinScore);
                            if (l.UseColorRange != null) newJob.UseColorRange = bool.Parse(l.UseColorRange);
                            if (l.RangeAreaMin != null) newJob.RangeAreaMin = int.Parse(l.RangeAreaMin);
                            if (l.RangeAreaMax != null) newJob.RangeAreaMax = int.Parse(l.RangeAreaMax);
                            if (l.Threshold != null) newJob.Threshold = int.Parse(l.Threshold);
                            if (l.Min0 != null) newJob.Min0 = int.Parse(l.Min0);
                            if (l.Min1 != null) newJob.Min1 = int.Parse(l.Min1);
                            if (l.Min2 != null) newJob.Min2 = int.Parse(l.Min2);
                            if (l.Max0 != null) newJob.Max0 = int.Parse(l.Max0);
                            if (l.Max1 != null) newJob.Max1 = int.Parse(l.Max1);
                            if (l.Max2 != null) newJob.Max2 = int.Parse(l.Max2);

                            newJob.SearchRegion = new Rectangle(int.Parse(l.Roi_SearchRegion_X.ToString()), int.Parse(l.Roi_SearchRegion_Y.ToString()), int.Parse(l.Roi_SearchRegion_W.ToString()), int.Parse(l.Roi_SearchRegion_H.ToString()));
                            newJob.valueRect = new Rectangle(int.Parse(l.Roi_ColorRegion_X.ToString()), int.Parse(l.Roi_ColorRegion_Y.ToString()), int.Parse(l.Roi_ColorRegion_W.ToString()), int.Parse(l.Roi_ColorRegion_H.ToString()));
                            Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs.Add(newJob);
                        }
                    }

                    filepath = $"{strFolderPath}\\{Recipe_Find_FileJson}";
                    if (File.Exists(filepath))
                    {
                        string Find_Ret = System.IO.File.ReadAllText(filepath);
                        List<Json_Find> L_Find = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Json_Find>>(Find_Ret);

                        foreach (var l_Find in L_Find)
                        {
                            string str_Name = l_Find.Find_Name;
                            string str_Type = l_Find.Find_Type;
                            string str_CircularArc_AngleSpan = l_Find.CircularArc_AngleSpan;
                            string str_CircularArc_AngleStart = l_Find.CircularArc_AngleStart;
                            string str_CircularArc_CenterX = l_Find.CircularArc_CenterX;
                            string str_CircularArc_CenterY = l_Find.CircularArc_CenterY;
                            string str_CircularArc_Radius = l_Find.CircularArc_Radius;
                            string ContrastThreshold = l_Find.ContrastThreshold;
                            string Edge0Polarity = l_Find.Edge0Polarity;
                            string FilterThickness = l_Find.FilterThickness;
                            string NumCalipers = l_Find.NumCalipers;
                            string NumToIgnore = l_Find.NumToIgnore;
                            string RectWidth = l_Find.RectWidth;
                            string RectHeight = l_Find.RectHeight;

                            string CaliperProjectionLength = l_Find.CaliperProjectionLength;
                            string CaliperSearchLength = l_Find.CaliperSearchLength;

                            bool Condensor_Type = true;
                            if (l_Find.Condensor_Type != null) Condensor_Type = bool.Parse(l_Find.Condensor_Type);

                            for (int i = 0; i < Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs.Count; i++)
                            {
                                CJob job = Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i];

                                if (job.Name == str_Name)
                                {
                                    if (job.Type.Contains("Condensor"))
                                    {
                                        CCognexUtil.LoadCogTool($"", job.Find_Circle);
                                    }

                                    if (job.Type.Contains("Distance"))
                                    {
                                        CCognexUtil.LoadCogTool($"", job.Find_Line);
                                    }
                                    break;
                                }
                            }
                        }
                    }

                    // Fin Data Load
                    filepath = $"{strFolderPath}\\{Recipe_Fin_FileJson}";
                    if (File.Exists(filepath))
                    {
                        string Fin_Ret = System.IO.File.ReadAllText(filepath);
                        List<Json_Fin> Fin_data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Json_Fin>>(Fin_Ret);

                        foreach (var l_Fin in Fin_data)
                        {
                            string str_Name = l_Fin.Fin_Name;
                            string str_Type = l_Fin.Fin_Type;

                            // 트레인 및 서치 ROI 값 저장..
                            string TrainRoi_X = l_Fin.Fin_MatchingTemplateRoi_X;
                            string TrainRoi_Y = l_Fin.Fin_MatchingTemplateRoi_Y;
                            string TrainRoi_W = l_Fin.Fin_MatchingTemplateRoi_W;
                            string TrainRoi_H = l_Fin.Fin_MatchingTemplateRoi_H;

                            string SearchRoi_X = l_Fin.Fin_MatchingSearchRoi_X;
                            string SearchRoi_Y = l_Fin.Fin_MatchingSearchRoi_Y;
                            string SearchRoi_W = l_Fin.Fin_MatchingSearchRoi_W;
                            string SearchRoi_H = l_Fin.Fin_MatchingSearchRoi_H;

                            string BlobSearchRoi_X = l_Fin.Fin_BlobSearchRoi_X;
                            string BlobSearchRoi_Y = l_Fin.Fin_BlobSearchRoi_Y;
                            string BlobSearchRoi_W = l_Fin.Fin_BlobSearchRoi_W;
                            string BlobSearchRoi_H = l_Fin.Fin_BlobSearchRoi_H;

                            string BlobOffset_X = l_Fin.Fin_BlobAlignOffset_X;
                            string BlobOffset_Y = l_Fin.Fin_BlobAlignOffset_Y;

                            for (int i = 0; i < Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs.Count; i++)
                            {
                                if (Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Name == str_Name)
                                {
                                    Rectangle rect = new Rectangle();
                                    rect.X = int.Parse(TrainRoi_X);
                                    rect.Y = int.Parse(TrainRoi_Y);
                                    rect.Width = int.Parse(TrainRoi_W);
                                    rect.Height = int.Parse(TrainRoi_H);
                                    Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Fin_InspecTool.FINFIND_MatchingTool.MatchingTemplateRoi = rect;

                                    Rectangle s_rect = new Rectangle();
                                    s_rect.X = int.Parse(SearchRoi_X);
                                    s_rect.Y = int.Parse(SearchRoi_Y);
                                    s_rect.Width = int.Parse(SearchRoi_W);
                                    s_rect.Height = int.Parse(SearchRoi_H);
                                    Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi = s_rect;

                                    Rectangle b_rect = new Rectangle();
                                    b_rect.X = int.Parse(BlobSearchRoi_X);
                                    b_rect.Y = int.Parse(BlobSearchRoi_Y);
                                    b_rect.Width = int.Parse(BlobSearchRoi_W);
                                    b_rect.Height = int.Parse(BlobSearchRoi_H);
                                    Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Fin_InspecTool.BlobSearchRoi = b_rect;

                                    System.Drawing.Point _point = new System.Drawing.Point();
                                    _point.X = int.Parse(BlobOffset_X);
                                    _point.Y = int.Parse(BlobOffset_Y);
                                    Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Fin_InspecTool.BlobAlignOffset = _point;

                                    Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Fin_InspecTool.BlobAreaMin = int.Parse(l_Fin.Fin_BlobAreaMin);
                                    Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Fin_InspecTool.BlobAreaMax = int.Parse(l_Fin.Fin_BlobAreaMax);
                                    Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Fin_InspecTool.BlobThreshold = int.Parse(l_Fin.Fin_BlobThreshold);
                                    Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Fin_InspecTool.BlobThresholdInv = bool.Parse(l_Fin.Fin_BlobThresholdInv);

                                    // 추가
                                    if (l_Fin.Fin_Center_X != null) Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Fin_InspecTool.Center_X = double.Parse(l_Fin.Fin_Center_X);
                                    if (l_Fin.Fin_Center_Y != null) Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Fin_InspecTool.Center_Y = double.Parse(l_Fin.Fin_Center_Y);

                                    // 트레인 이미지 로드...
                                    string TrainPath = $"{strFolderPath}\\TrainImage\\FinTarinImage";
                                    if (Directory.Exists(TrainPath))
                                    {
                                        string _file = $"{TrainPath}\\{Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Name}.jpg";
                                        // 해당 파일이 있을경우...읽기..
                                        if (File.Exists(_file))
                                        {
                                            // 위에서 트레인 ROI와 서치 ROI 값을 가져오기 때문에 바로 이미지 넣어줌...
                                            Mat img_read = Cv2.ImRead(_file);

                                            if (img_read != null)
                                            {
                                                Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Fin_InspecTool.FINFIND_MatchingTool.m_MatchingTemplateImage = (Bitmap)OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img_read).Clone();
                                            }
                                            else
                                            {
                                                // 트레인 이미지 정상적으로 있는지 확인...
                                                CLogger.Add(LOG.EXCEPTION, $"Fin Recipe Train Image Not Load : Train Image Name => {Global.Instance.System.Recipe.JobManager[Arrayindex].Jobs[i].Name}");
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
        }


        public void JsonFile_Save(int ArrayIndex, string Path, bool AddFlag = false)
        {
            try
            {
                if (AddFlag)
                {
                    if (JobManager_Array1 == null) JobManager_Array1 = new CInspJobs();
                    if (JobManager_Array2 == null) JobManager_Array2 = new CInspJobs();
                    if (JobManager_Array3 == null) JobManager_Array3 = new CInspJobs();
                    if (JobManager_Array4 == null) JobManager_Array4 = new CInspJobs();
                    JobManager = new CInspJobs[4] { JobManager_Array1, JobManager_Array2, JobManager_Array3, JobManager_Array4 };
                }

                List<Json_Library> L_Library = new List<Json_Library>();
                List<Json_Library_TrainRegion> L_Library_TrainRegion = new List<Json_Library_TrainRegion>();
                // Find Region 관련 내용 저장...
                // 써클 라인에 대한 JSON 파일 저장
                List<Json_Find> Find_Library = new List<Json_Find>();
                // Fin 검출 내용 저장
                List<Json_Fin> Fin_Library = new List<Json_Fin>();

                // 어레이 인덱스별로 폴더 생성...
                string strLibraryPath = $"{Path}\\Array_{ArrayIndex}";
                if (!Directory.Exists(strLibraryPath)) Directory.CreateDirectory(strLibraryPath);
                // 트레인 이미지는 레시피 이름별로 저장이 필요..
                string strTrainImagPath = $"{strLibraryPath}\\TrainImage";
                if (!Directory.Exists(strTrainImagPath)) Directory.CreateDirectory(strTrainImagPath);

                if (Global.Instance.System.Recipe.JobManager[ArrayIndex] == null) return;

                //   Parallel.For(0, Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs.Count,
                //i =>
                for (int i = 0; i < Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs.Count; i++)
                {
                    double dbl_Roi_SearchRegion_X = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SearchRegion.X;
                    double dbl_Roi_SearchRegion_Y = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SearchRegion.Y;
                    double dbl_Roi_SearchRegion_W = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SearchRegion.Width;
                    double dbl_Roi_SearchRegion_H = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SearchRegion.Height;

                    double dbl_Roi_ColorRegion_X = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].valueRect.X;
                    double dbl_Roi_ColorRegion_Y = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].valueRect.Y;
                    double dbl_Roi_ColorRegion_W = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].valueRect.Width;
                    double dbl_Roi_ColorRegion_H = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].valueRect.Height;

                    string strType = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Type.ToString();

                    if (strType == "00) Pattern")
                    {
                        strType = "Pattern";

                    }
                    else if (strType == "01) Color")
                    {
                        strType = "Color";
                    }
                    else if (strType == "02) IC Lead")
                    {
                        strType = "IC Lead";
                    }

                    Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Type = strType;
                    string MasterCount = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].MasterCount.ToString();


                    L_Library.Add(new Json_Library()
                    {
                        Enabled = false.ToString(),
                        Type = strType,
                        GrabIndex = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].GrabIndex.ToString(),
                        Name = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name.ToString(),
                        SamplingCount = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SamplingCount.ToString(),
                        Judge_NaisNg = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Judge_NaisNg.ToString(),
                        ChkColor = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].ChkColor.ToString(),
                        CCoordinate = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].CCoordinate.ToString(),
                        CMethod = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].CMethod.ToString(),
                        useBinary = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].useBinary.ToString(),
                        isSavePart = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].isSavePart.ToString(),
                        // 추가..
                        MinFoundCount = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].MinFoundCount.ToString(),
                        LC_ReadUse = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].LC_ReadUse.ToString(),
                        MasterCount = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].MasterCount.ToString(),
                        //LC_Read_MasterCount = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].MasterCount.ToString(),
                        // 추가
                        MinScore = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].MinScore.ToString(),
                        UseColorRange = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].UseColorRange.ToString(),
                        Threshold = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Threshold.ToString(),
                        RangeAreaMin = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].RangeAreaMin.ToString(),
                        RangeAreaMax = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].RangeAreaMax.ToString(),
                        Min0 = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Min0.ToString(),
                        Min1 = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Min1.ToString(),
                        Min2 = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Min2.ToString(),
                        Max0 = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Max0.ToString(),
                        Max1 = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Max1.ToString(),
                        Max2 = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Max2.ToString(),
                        Roi_SearchRegion_X = dbl_Roi_SearchRegion_X,
                        Roi_SearchRegion_Y = dbl_Roi_SearchRegion_Y,
                        Roi_SearchRegion_W = dbl_Roi_SearchRegion_W,
                        Roi_SearchRegion_H = dbl_Roi_SearchRegion_H,
                        Roi_ColorRegion_X = dbl_Roi_ColorRegion_X,
                        Roi_ColorRegion_Y = dbl_Roi_ColorRegion_Y,
                        Roi_ColorRegion_W = dbl_Roi_ColorRegion_W,
                        Roi_ColorRegion_H = dbl_Roi_ColorRegion_H,
                        //
                        UseFilter1 = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Parameter.UseFilter1.ToString(),
                        UseFilter2 = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Parameter.UseFilter2.ToString(),
                        //
                    });

                    #region Image
                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Tool.Tool.Pattern.TrainImage != null)
                    {
                        using (Bitmap B = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Tool.Tool.Pattern.TrainImage.ToBitmap())
                        {
                            string filepath = $"{strTrainImagPath}\\{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Main.jpg";
                            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(B).Clone();
                            bool ret = Cv2.ImWrite(filepath, mat);
                            // 트레인 이미지가 정상적으로 저장되지 않을시 로그 기록..
                            if (!ret) CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Not Save : Train Image Name => {Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Main");
                        }
                    }

                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Tool.TrainedPatternImage != null)
                    {
                        using (Bitmap B = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Tool.TrainedPatternImage.ToBitmap())
                        {
                            string patternpath = $"{strTrainImagPath}\\PatternImage";
                            if (!Directory.Exists(patternpath)) Directory.CreateDirectory(patternpath);

                            string filepath = $"{patternpath}\\{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Main.jpg";
                            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(B).Clone();
                            bool ret = Cv2.ImWrite(filepath, mat);
                            // 트레인 이미지가 정상적으로 저장되지 않을시 로그 기록..
                            if (!ret) CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Not Save : Train Image Name => {Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Main");
                        }
                    }

                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool1.Tool.Pattern.TrainImage != null)
                    {
                        using (Bitmap B = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool1.Tool.Pattern.TrainImage.ToBitmap())
                        {
                            string filepath = $"{strTrainImagPath}\\{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Sub1.jpg";
                            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(B).Clone();
                            bool ret = Cv2.ImWrite(filepath, mat);
                            // 트레인 이미지가 정상적으로 저장되지 않을시 로그 기록..
                            if (!ret) CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Not Save : Train Image Name => {Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Main");
                        }
                    }

                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool1.TrainedPatternImage != null)
                    {
                        using (Bitmap B = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool1.TrainedPatternImage.ToBitmap())
                        {
                            string patternpath = $"{strTrainImagPath}\\PatternImage";
                            if (!Directory.Exists(patternpath)) Directory.CreateDirectory(patternpath);

                            string filepath = $"{strTrainImagPath}\\PatternImage\\{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Sub1.jpg";
                            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(B).Clone();
                            bool ret = Cv2.ImWrite(filepath, mat);
                            // 트레인 이미지가 정상적으로 저장되지 않을시 로그 기록..
                            if (!ret) CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Not Save : Train Image Name => {Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Sub1");
                        }
                    }

                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool2.Tool.Pattern.TrainImage != null)
                    {
                        using (Bitmap B = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool2.Tool.Pattern.TrainImage.ToBitmap())
                        {
                            string filepath = $"{strTrainImagPath}\\{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Sub2.jpg";
                            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(B).Clone();
                            bool ret = Cv2.ImWrite(filepath, mat);
                            // 트레인 이미지가 정상적으로 저장되지 않을시 로그 기록..
                            if (!ret) CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Not Save : Train Image Name => {Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Main");
                        }
                    }

                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool2.TrainedPatternImage != null)
                    {
                        using (Bitmap B = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool2.TrainedPatternImage.ToBitmap())
                        {
                            string patternpath = $"{strTrainImagPath}\\PatternImage";
                            if (!Directory.Exists(patternpath)) Directory.CreateDirectory(patternpath);

                            string filepath = $"{strTrainImagPath}\\PatternImage\\{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Sub2.jpg";
                            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(B).Clone();
                            bool ret = Cv2.ImWrite(filepath, mat);
                            // 트레인 이미지가 정상적으로 저장되지 않을시 로그 기록..
                            if (!ret) CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Not Save : Train Image Name => {Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Sub2");
                        }
                    }

                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool3.Tool.Pattern.TrainImage != null)
                    {
                        using (Bitmap B = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool3.Tool.Pattern.TrainImage.ToBitmap())
                        {
                            string filepath = $"{strTrainImagPath}\\{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Sub3.jpg";
                            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(B).Clone();
                            bool ret = Cv2.ImWrite(filepath, mat);
                            // 트레인 이미지가 정상적으로 저장되지 않을시 로그 기록..
                            if (!ret) CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Not Save : Train Image Name => {Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Main");
                        }
                    }

                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool3.TrainedPatternImage != null)
                    {
                        using (Bitmap B = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool3.TrainedPatternImage.ToBitmap())
                        {
                            string patternpath = $"{strTrainImagPath}\\PatternImage";
                            if (!Directory.Exists(patternpath)) Directory.CreateDirectory(patternpath);

                            string filepath = $"{strTrainImagPath}\\PatternImage\\{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Sub3.jpg";
                            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(B).Clone();
                            bool ret = Cv2.ImWrite(filepath, mat);
                            // 트레인 이미지가 정상적으로 저장되지 않을시 로그 기록..
                            if (!ret) CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Not Save : Train Image Name => {Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Sub3");
                        }
                    }

                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool4.Tool.Pattern.TrainImage != null)
                    {
                        using (Bitmap B = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool4.Tool.Pattern.TrainImage.ToBitmap())
                        {
                            string filepath = $"{strTrainImagPath}\\{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Sub4.jpg";
                            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(B).Clone();
                            bool ret = Cv2.ImWrite(filepath, mat);
                            // 트레인 이미지가 정상적으로 저장되지 않을시 로그 기록..
                            if (!ret) CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Not Save : Train Image Name => {Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Main");
                        }
                    }

                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool4.TrainedPatternImage != null)
                    {
                        using (Bitmap B = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool4.TrainedPatternImage.ToBitmap())
                        {
                            string patternpath = $"{strTrainImagPath}\\PatternImage";
                            if (!Directory.Exists(patternpath)) Directory.CreateDirectory(patternpath);

                            string filepath = $"{strTrainImagPath}\\PatternImage\\{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Sub4.jpg";
                            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(B).Clone();
                            bool ret = Cv2.ImWrite(filepath, mat);
                            // 트레인 이미지가 정상적으로 저장되지 않을시 로그 기록..
                            if (!ret) CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Not Save : Train Image Name => {Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}_Sub4");
                        }
                    }
                    #endregion
                    #region Rect
                    // 트레인 ROI 셋팅 저장..
                    // SerchRegion값도 별도로 가져감..
                    string str_Roi_Name;
                    string str_Roi_Type;
                    string str_Roi_TrainRegion_X;
                    string str_Roi_TrainRegion_Y;
                    string str_Roi_TrainRegion_W;
                    string str_Roi_TrainRegion_H;
                    string str_Roi_SerchRegion_X;
                    string str_Roi_SerchRegion_Y;
                    string str_Roi_SerchRegion_W;
                    string str_Roi_SerchRegion_H;

                    // Main
                    //================================================================================================
                    // Train
                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Tool.Tool.Pattern.TrainRegion.ToString() == "Cognex.VisionPro.CogRectangle")
                    {
                        CogRectangle Region = (CogRectangle)Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Tool.Tool.Pattern.TrainRegion;
                        str_Roi_TrainRegion_X = Region.X.ToString();
                        str_Roi_TrainRegion_Y = Region.Y.ToString();
                        str_Roi_TrainRegion_W = Region.Width.ToString();
                        str_Roi_TrainRegion_H = Region.Height.ToString();
                    }
                    else
                    {
                        str_Roi_TrainRegion_X = "0";
                        str_Roi_TrainRegion_Y = "0";
                        str_Roi_TrainRegion_W = "0";
                        str_Roi_TrainRegion_H = "0";
                    }

                    // Serch
                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Tool.Tool.SearchRegion != null)
                    {
                        CogRectangle Region = (CogRectangle)Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Tool.Tool.SearchRegion;
                        str_Roi_SerchRegion_X = Region.X.ToString();
                        str_Roi_SerchRegion_Y = Region.Y.ToString();
                        str_Roi_SerchRegion_W = Region.Width.ToString();
                        str_Roi_SerchRegion_H = Region.Height.ToString();
                    }
                    else
                    {
                        str_Roi_SerchRegion_X = "0";
                        str_Roi_SerchRegion_Y = "0";
                        str_Roi_SerchRegion_W = "0";
                        str_Roi_SerchRegion_H = "0";
                    }

                    str_Roi_Name = $"{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}";
                    str_Roi_Type = "Main";

                    L_Library_TrainRegion.Add(new Json_Library_TrainRegion()
                    {
                        Roi_TrainName = str_Roi_Name,
                        Roi_TrainType = str_Roi_Type,
                        Roi_TrainRegion_X = str_Roi_TrainRegion_X,
                        Roi_TrainRegion_Y = str_Roi_TrainRegion_Y,
                        Roi_TrainRegion_W = str_Roi_TrainRegion_W,
                        Roi_TrainRegion_H = str_Roi_TrainRegion_H,
                        Roi_SerchRegion_X = str_Roi_SerchRegion_X,
                        Roi_SerchRegion_Y = str_Roi_SerchRegion_Y,
                        Roi_SerchRegion_W = str_Roi_SerchRegion_W,
                        Roi_SerchRegion_H = str_Roi_SerchRegion_H
                    });

                    //Sub1
                    //================================================================================================
                    //Train
                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool1.Tool.Pattern.TrainRegion.ToString() == "Cognex.VisionPro.CogRectangle")
                    {
                        CogRectangle Region = (CogRectangle)Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool1.Tool.Pattern.TrainRegion;
                        str_Roi_TrainRegion_X = Region.X.ToString();
                        str_Roi_TrainRegion_Y = Region.Y.ToString();
                        str_Roi_TrainRegion_W = Region.Width.ToString();
                        str_Roi_TrainRegion_H = Region.Height.ToString();
                    }
                    else
                    {
                        str_Roi_TrainRegion_X = "0";
                        str_Roi_TrainRegion_Y = "0";
                        str_Roi_TrainRegion_W = "0";
                        str_Roi_TrainRegion_H = "0";
                    }

                    // Serch
                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool1.Tool.SearchRegion != null)
                    {
                        CogRectangle Region = (CogRectangle)Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool1.Tool.SearchRegion;
                        str_Roi_SerchRegion_X = Region.X.ToString();
                        str_Roi_SerchRegion_Y = Region.Y.ToString();
                        str_Roi_SerchRegion_W = Region.Width.ToString();
                        str_Roi_SerchRegion_H = Region.Height.ToString();
                    }
                    else
                    {
                        str_Roi_SerchRegion_X = "0";
                        str_Roi_SerchRegion_Y = "0";
                        str_Roi_SerchRegion_W = "0";
                        str_Roi_SerchRegion_H = "0";
                    }

                    str_Roi_Name = $"{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}";
                    str_Roi_Type = "Sub1";

                    L_Library_TrainRegion.Add(new Json_Library_TrainRegion()
                    {
                        Roi_TrainName = str_Roi_Name,
                        Roi_TrainType = str_Roi_Type,
                        Roi_TrainRegion_X = str_Roi_TrainRegion_X,
                        Roi_TrainRegion_Y = str_Roi_TrainRegion_Y,
                        Roi_TrainRegion_W = str_Roi_TrainRegion_W,
                        Roi_TrainRegion_H = str_Roi_TrainRegion_H,
                        Roi_SerchRegion_X = str_Roi_SerchRegion_X,
                        Roi_SerchRegion_Y = str_Roi_SerchRegion_Y,
                        Roi_SerchRegion_W = str_Roi_SerchRegion_W,
                        Roi_SerchRegion_H = str_Roi_SerchRegion_H
                    });

                    //Sub2
                    //================================================================================================
                    //Train
                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool2.Tool.Pattern.TrainRegion.ToString() == "Cognex.VisionPro.CogRectangle")
                    {
                        CogRectangle Region = (CogRectangle)Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool2.Tool.Pattern.TrainRegion;
                        str_Roi_TrainRegion_X = Region.X.ToString();
                        str_Roi_TrainRegion_Y = Region.Y.ToString();
                        str_Roi_TrainRegion_W = Region.Width.ToString();
                        str_Roi_TrainRegion_H = Region.Height.ToString();
                    }
                    else
                    {
                        str_Roi_TrainRegion_X = "0";
                        str_Roi_TrainRegion_Y = "0";
                        str_Roi_TrainRegion_W = "0";
                        str_Roi_TrainRegion_H = "0";
                    }

                    // Serch
                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool2.Tool.SearchRegion != null)
                    {
                        CogRectangle Region = (CogRectangle)Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool2.Tool.SearchRegion;
                        str_Roi_SerchRegion_X = Region.X.ToString();
                        str_Roi_SerchRegion_Y = Region.Y.ToString();
                        str_Roi_SerchRegion_W = Region.Width.ToString();
                        str_Roi_SerchRegion_H = Region.Height.ToString();
                    }
                    else
                    {
                        str_Roi_SerchRegion_X = "0";
                        str_Roi_SerchRegion_Y = "0";
                        str_Roi_SerchRegion_W = "0";
                        str_Roi_SerchRegion_H = "0";
                    }

                    str_Roi_Name = $"{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}";
                    str_Roi_Type = "Sub2";

                    L_Library_TrainRegion.Add(new Json_Library_TrainRegion()
                    {
                        Roi_TrainName = str_Roi_Name,
                        Roi_TrainType = str_Roi_Type,
                        Roi_TrainRegion_X = str_Roi_TrainRegion_X,
                        Roi_TrainRegion_Y = str_Roi_TrainRegion_Y,
                        Roi_TrainRegion_W = str_Roi_TrainRegion_W,
                        Roi_TrainRegion_H = str_Roi_TrainRegion_H,
                        Roi_SerchRegion_X = str_Roi_SerchRegion_X,
                        Roi_SerchRegion_Y = str_Roi_SerchRegion_Y,
                        Roi_SerchRegion_W = str_Roi_SerchRegion_W,
                        Roi_SerchRegion_H = str_Roi_SerchRegion_H
                    });

                    //Sub3
                    //================================================================================================
                    //Train
                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool3.Tool.Pattern.TrainRegion.ToString() == "Cognex.VisionPro.CogRectangle")
                    {
                        CogRectangle Region = (CogRectangle)Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool3.Tool.Pattern.TrainRegion;
                        str_Roi_TrainRegion_X = Region.X.ToString();
                        str_Roi_TrainRegion_Y = Region.Y.ToString();
                        str_Roi_TrainRegion_W = Region.Width.ToString();
                        str_Roi_TrainRegion_H = Region.Height.ToString();
                    }
                    else
                    {
                        str_Roi_TrainRegion_X = "0";
                        str_Roi_TrainRegion_Y = "0";
                        str_Roi_TrainRegion_W = "0";
                        str_Roi_TrainRegion_H = "0";
                    }

                    // Serch
                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool3.Tool.SearchRegion != null)
                    {
                        CogRectangle Region = (CogRectangle)Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool3.Tool.SearchRegion;
                        str_Roi_SerchRegion_X = Region.X.ToString();
                        str_Roi_SerchRegion_Y = Region.Y.ToString();
                        str_Roi_SerchRegion_W = Region.Width.ToString();
                        str_Roi_SerchRegion_H = Region.Height.ToString();
                    }
                    else
                    {
                        str_Roi_SerchRegion_X = "0";
                        str_Roi_SerchRegion_Y = "0";
                        str_Roi_SerchRegion_W = "0";
                        str_Roi_SerchRegion_H = "0";
                    }

                    str_Roi_Name = $"{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}";
                    str_Roi_Type = "Sub3";

                    L_Library_TrainRegion.Add(new Json_Library_TrainRegion()
                    {
                        Roi_TrainName = str_Roi_Name,
                        Roi_TrainType = str_Roi_Type,
                        Roi_TrainRegion_X = str_Roi_TrainRegion_X,
                        Roi_TrainRegion_Y = str_Roi_TrainRegion_Y,
                        Roi_TrainRegion_W = str_Roi_TrainRegion_W,
                        Roi_TrainRegion_H = str_Roi_TrainRegion_H,
                        Roi_SerchRegion_X = str_Roi_SerchRegion_X,
                        Roi_SerchRegion_Y = str_Roi_SerchRegion_Y,
                        Roi_SerchRegion_W = str_Roi_SerchRegion_W,
                        Roi_SerchRegion_H = str_Roi_SerchRegion_H
                    });

                    //Sub4
                    //================================================================================================
                    //Train
                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool4.Tool.Pattern.TrainRegion.ToString() == "Cognex.VisionPro.CogRectangle")
                    {
                        CogRectangle Region = (CogRectangle)Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool4.Tool.Pattern.TrainRegion;
                        str_Roi_TrainRegion_X = Region.X.ToString();
                        str_Roi_TrainRegion_Y = Region.Y.ToString();
                        str_Roi_TrainRegion_W = Region.Width.ToString();
                        str_Roi_TrainRegion_H = Region.Height.ToString();
                    }
                    else
                    {
                        str_Roi_TrainRegion_X = "0";
                        str_Roi_TrainRegion_Y = "0";
                        str_Roi_TrainRegion_W = "0";
                        str_Roi_TrainRegion_H = "0";
                    }

                    // Serch
                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool4.Tool.SearchRegion != null)
                    {
                        CogRectangle Region = (CogRectangle)Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].SubTool4.Tool.SearchRegion;
                        str_Roi_SerchRegion_X = Region.X.ToString();
                        str_Roi_SerchRegion_Y = Region.Y.ToString();
                        str_Roi_SerchRegion_W = Region.Width.ToString();
                        str_Roi_SerchRegion_H = Region.Height.ToString();
                    }
                    else
                    {
                        str_Roi_SerchRegion_X = "0";
                        str_Roi_SerchRegion_Y = "0";
                        str_Roi_SerchRegion_W = "0";
                        str_Roi_SerchRegion_H = "0";
                    }

                    str_Roi_Name = $"{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}";
                    str_Roi_Type = "Sub4";

                    L_Library_TrainRegion.Add(new Json_Library_TrainRegion()
                    {
                        Roi_TrainName = str_Roi_Name,
                        Roi_TrainType = str_Roi_Type,
                        Roi_TrainRegion_X = str_Roi_TrainRegion_X,
                        Roi_TrainRegion_Y = str_Roi_TrainRegion_Y,
                        Roi_TrainRegion_W = str_Roi_TrainRegion_W,
                        Roi_TrainRegion_H = str_Roi_TrainRegion_H,
                        Roi_SerchRegion_X = str_Roi_SerchRegion_X,
                        Roi_SerchRegion_Y = str_Roi_SerchRegion_Y,
                        Roi_SerchRegion_W = str_Roi_SerchRegion_W,
                        Roi_SerchRegion_H = str_Roi_SerchRegion_H
                    });

                    #endregion
                    // 파인드일때 레시피 저장...
                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Type == "Find" ||
                        Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Type == "Distance" ||
                        Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Type == "Condensor")
                    {
                        // 트레인 ROI 셋팅 저장..
                        // SerchRegion값도 별도로 가져감..
                        string str_Name;
                        string str_Type;
                        string str_CircularArc_AngleSpan;
                        string str_CircularArc_AngleStart;
                        string str_CircularArc_CenterX;
                        string str_CircularArc_CenterY;
                        string str_CircularArc_Radius;

                        str_Name = $"{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}";
                    }

                    // Fin 일때 레시피 저장..
                    if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Type == "Blob")
                    {
                        // 트레인 및 서치 ROI 값 저장..
                        string TrainRoi_X = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.FINFIND_MatchingTool.MatchingTemplateRoi.X.ToString();
                        string TrainRoi_Y = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.FINFIND_MatchingTool.MatchingTemplateRoi.Y.ToString();
                        string TrainRoi_W = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.FINFIND_MatchingTool.MatchingTemplateRoi.Width.ToString();
                        string TrainRoi_H = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.FINFIND_MatchingTool.MatchingTemplateRoi.Height.ToString();

                        string SearchRoi_X = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi.X.ToString();
                        string SearchRoi_Y = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi.Y.ToString();
                        string SearchRoi_W = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi.Width.ToString();
                        string SearchRoi_H = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.FINFIND_MatchingTool.MatchingSearchRoi.Height.ToString();

                        string BlobSearchRoi_X = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.BlobSearchRoi.X.ToString();
                        string BlobSearchRoi_Y = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.BlobSearchRoi.Y.ToString();
                        string BlobSearchRoi_W = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.BlobSearchRoi.Width.ToString();
                        string BlobSearchRoi_H = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.BlobSearchRoi.Height.ToString();

                        Fin_Library.Add(new Json_Fin()
                        {
                            Fin_Name = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name,
                            Fin_Type = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Type,
                            Fin_MatchingTemplateRoi_X = TrainRoi_X,
                            Fin_MatchingTemplateRoi_Y = TrainRoi_Y,
                            Fin_MatchingTemplateRoi_H = TrainRoi_H,
                            Fin_MatchingTemplateRoi_W = TrainRoi_W,
                            Fin_MatchingSearchRoi_X = SearchRoi_X,
                            Fin_MatchingSearchRoi_Y = SearchRoi_Y,
                            Fin_MatchingSearchRoi_H = SearchRoi_H,
                            Fin_MatchingSearchRoi_W = SearchRoi_W,
                            Fin_BlobSearchRoi_X = BlobSearchRoi_X,
                            Fin_BlobSearchRoi_Y = BlobSearchRoi_Y,
                            Fin_BlobSearchRoi_H = BlobSearchRoi_H,
                            Fin_BlobSearchRoi_W = BlobSearchRoi_W,
                            Fin_BlobAlignOffset_X = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.BlobAlignOffset.X.ToString(),
                            Fin_BlobAlignOffset_Y = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.BlobAlignOffset.Y.ToString(),
                            Fin_BlobAreaMin = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.BlobAreaMin.ToString(),
                            Fin_BlobAreaMax = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.BlobAreaMax.ToString(),
                            Fin_BlobThreshold = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.BlobThreshold.ToString(),
                            Fin_BlobThresholdInv = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.BlobThresholdInv.ToString(),
                            // 추가
                            Fin_Center_X = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.Center_X.ToString(),
                            Fin_Center_Y = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.Center_Y.ToString(),
                        });

                        // 트레인 이미지 저장...
                        if (Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.FINFIND_MatchingTool.m_MatchingTemplateImage != null)
                        {
                            string patternpath = $"{strTrainImagPath}\\FinTarinImage";
                            if (!Directory.Exists(patternpath)) Directory.CreateDirectory(patternpath);

                            string filepath = $"{strTrainImagPath}\\FinTarinImage\\{Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}.jpg";
                            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Fin_InspecTool.FINFIND_MatchingTool.m_MatchingTemplateImage).Clone();
                            bool ret = Cv2.ImWrite(filepath, mat);
                            // 트레인 이미지가 정상적으로 저장되지 않을시 로그 기록..
                            if (!ret) CLogger.Add(LOG.EXCEPTION, $"Recipe Train Image Not Save : Train Image Name => {Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name}");
                        }
                    }
                }//);
                 //for (int i = 0; i < Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs.Count; i++)
                 //{

                //}

                string strLibraryTrainRegionJsonFileName = $"{strLibraryPath}\\{Recipe_ROI_Region_FileJson}";
                string str_Library_TrainRegion = Newtonsoft.Json.JsonConvert.SerializeObject(L_Library_TrainRegion, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(strLibraryTrainRegionJsonFileName, str_Library_TrainRegion);

                string strLibraryJsonFileName = $"{strLibraryPath}\\{Recipe_Library_FileJson}";
                string str_Library = Newtonsoft.Json.JsonConvert.SerializeObject(L_Library, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(strLibraryJsonFileName, str_Library);

                string strLibraryFindRegionJsonFileName = $"{strLibraryPath}\\{Recipe_Find_FileJson}";
                string str_Library_FindRegion = Newtonsoft.Json.JsonConvert.SerializeObject(Find_Library, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(strLibraryFindRegionJsonFileName, str_Library_FindRegion);

                string strLibraryFinRegionJsonFileName = $"{strLibraryPath}\\{Recipe_Fin_FileJson}";
                string str_Library_FinRegion = Newtonsoft.Json.JsonConvert.SerializeObject(Fin_Library, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(strLibraryFinRegionJsonFileName, str_Library_FinRegion);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        // 현재 레시피 저장...

        public static int RecipeSaving_CheckCnt = 0;
        public static bool RecipeSaving_Flg = false;
        public void RecipeSave()
        {
            // Enabled저장 최우선 순위로 변경

            RecipeEnabledSave();
            // xml 내용 저장..
            // 파라메터 내용 저장...
            SaveConfig();
            try
            {
                FiducialLibrary.Save(CODE, FIducialLibrary_Number);
            }
            catch
            {

            }

            string strFolderPath = $"{Global.m_MainPJTRoot}\\PBA_LIBRARY\\{CODE}";

            if (!Directory.Exists(strFolderPath)) Directory.CreateDirectory(strFolderPath);



            for (int i = 0; i < ArrayCount; i++)
            {
                RecipeSaving_CheckCnt++;
                JsonFile_Save(i, strFolderPath);

                for (int jobIdx = 0; jobIdx < JobManager[i].Jobs.Count; jobIdx++)
                {
                    try
                    {
                        JobManager[i].Jobs[jobIdx].Parameter.Save(CODE, i, JobManager[i].Jobs[jobIdx].Name);
                        JobManager[i].Jobs[jobIdx].HasChanged = false;
                    }
                    catch (Exception ex)
                    {

                    }

                    try
                    {
                        if (JobManager[i].Jobs[jobIdx].Type.Contains("Condensor"))
                        {
                            string path = $"{Global.m_MainPJTRoot}\\PBA_LIBRARY\\{CODE}\\Array_{i}\\{JobManager[i].Jobs[jobIdx].Name}_FindCircle.vpp";
                            CCognexUtil.SaveCogTool(path, JobManager[i].Jobs[jobIdx].Find_Circle);
                        }

                        if (JobManager[i].Jobs[jobIdx].Type.Contains("Distance"))
                        {
                            string path = $"{Global.m_MainPJTRoot}\\PBA_LIBRARY\\{CODE}\\Array_{i}\\{JobManager[i].Jobs[jobIdx].Name}_FindLine.vpp";
                            CCognexUtil.SaveCogTool(path, JobManager[i].Jobs[jobIdx].Find_Line);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }


        }

        // 별도 이네이블값 저장해주기..
        public void RecipeEnabledSave()
        {
            string strFolderPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{Name}\\PBA_LIBRARY\\{CODE}";

            if (!Directory.Exists(strFolderPath)) Directory.CreateDirectory(strFolderPath);

            for (int i = 0; i < ArrayCount; i++)
            {
                EnabledJsonFile_Save(strFolderPath, i);
            }
        }

        public void EnabledJsonFile_Save(string strFolderpath, int ArrayIndex)
        {
            List<Json_Library_Enabled> L_Library = new List<Json_Library_Enabled>();
            Json_Enabled_Count _Enabled_Count = new Json_Enabled_Count();
            // 어레이 인덱스별로 폴더 생성...
            if (!Directory.Exists(strFolderpath)) Directory.CreateDirectory(strFolderpath);

            for (int i = 0; i < Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs.Count; i++)
            {
                L_Library.Add(new Json_Library_Enabled()
                {
                    Enabled = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Enabled.ToString(),
                    Name = Global.Instance.System.Recipe.JobManager[ArrayIndex].Jobs[i].Name.ToString(),
                });
            }

            string strLibraryJsonFileName = Path.Combine(strFolderpath, $"Array{ArrayIndex}_Enabled.json");
            string strLibraryJsonCount = Path.Combine(strFolderpath, $"Array{ArrayIndex}_Enabled_Count.json");
            string str_Enabled_Count = Newtonsoft.Json.JsonConvert.SerializeObject(_Enabled_Count, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(strLibraryJsonCount, str_Enabled_Count);
            string str_Library = Newtonsoft.Json.JsonConvert.SerializeObject(L_Library, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(strLibraryJsonFileName, str_Library);

        }

        public bool InitDirectory(string strRecipeName)
        {
            try
            {
                string strRecipePath = $"{Global.m_MainPJTRoot}\\{RECIPE_DIRECTORY}";
                DirectoryInfo dirRecipe = new DirectoryInfo(strRecipePath);
                if (dirRecipe.Exists == false) dirRecipe.Create();

                string strRecipeNamePath = $"{strRecipePath}\\{strRecipeName}";
                DirectoryInfo dirRecipeName = new DirectoryInfo(strRecipeNamePath);
                if (dirRecipeName.Exists == false) dirRecipeName.Create();

                return true;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        //public bool InitDirectory(string strMainRecipeName, string strSubRecipeName)
        //{
        //    string strRecipePath = IGlobal.m_MainPJTRoot + "\\" + RECIPE_DIRECTORY + "\\";
        //    DirectoryInfo dirRecipe = new DirectoryInfo(strRecipePath);
        //    if (dirRecipe.Exists == false) dirRecipe.Create();

        //    string strMainRecipeNamePath = IGlobal.m_MainPJTRoot + "\\" + RECIPE_DIRECTORY + "\\" + strMainRecipeName;
        //    DirectoryInfo dirMainRecipeName = new DirectoryInfo(strMainRecipeNamePath);
        //    if (dirMainRecipeName.Exists == false) dirMainRecipeName.Create();

        //    string strSubPath = IGlobal.m_MainPJTRoot + "\\" + RECIPE_DIRECTORY + "\\" + strMainRecipeName + "\\SubRECIPE";
        //    DirectoryInfo dirMainRecipeName1 = new DirectoryInfo(strSubPath);
        //    if (dirMainRecipeName1.Exists == false) dirMainRecipeName1.Create();

        //    string strSubRecipeNamePath = IGlobal.m_MainPJTRoot + "\\" + RECIPE_DIRECTORY + "\\" + strMainRecipeName + "\\SubRECIPE" + "\\" + strSubRecipeName;
        //    DirectoryInfo dirSubRecipeName = new DirectoryInfo(strSubRecipeNamePath);
        //    if (dirSubRecipeName.Exists == false) dirSubRecipeName.Create();
        //}

        #region CONFIG BY XML

        private string m_XMLName = "Parameter";
        private string m_XMLEnable = "EnabledJobs_Library";
        // json이 없고 xml이 있을 경우...해당 이네이블 이름 담기..
        List<string> m_List_Enable_Name = new List<string>();

        public void EnableXML_LoadConfig()
        {
            string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{Name}\\JOBS\\jobs1.xml";

            m_List_Enable_Name.Clear();

            if (File.Exists(strPath))
            {
                XmlTextReader xmlReader = new XmlTextReader(strPath);

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.Name)
                        {
                            case "string":
                                {
                                    if (xmlReader.Read())
                                    {
                                        string name = xmlReader.Value;
                                        m_List_Enable_Name.Add(name);
                                    }
                                }
                                break;
                            case "ArrayCount":
                                {
                                    if (xmlReader.Read())
                                    {
                                        ArrayCount = int.Parse(xmlReader.Value.ToString());
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        if (xmlReader.NodeType == XmlNodeType.EndElement)
                        {
                            if (xmlReader.Name == m_XMLEnable) break;
                        }
                    }
                }

                xmlReader.Close();
            }
        }

        public void LoadConfig()
        {
            string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{Name}\\JOBS\\Parameter.xml";
            // 파일스트림을 사용했으므로 파일닫기를 항시 해줘야함(닫기를 하지 않을시 다른쪽에서 파일 접근 불가)
            //FileStream _file;

            if (File.Exists(strPath))
            {
                XmlTextReader xmlReader = new XmlTextReader(strPath);

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.Name)
                        {
                            case "FIducialLibrary_Number": if (xmlReader.Read()) FIducialLibrary_Number = xmlReader.Value; break;
                            case "PbaCode": if (xmlReader.Read()) CODE = xmlReader.Value; break;
                            case "QRBufferNo": if (xmlReader.Read()) QRBufferNo = int.Parse(xmlReader.Value); break;
                            case "ArrayCount": if (xmlReader.Read()) ArrayCount = int.Parse(xmlReader.Value); break;
                        }
                    }
                    else
                    {
                        if (xmlReader.NodeType == XmlNodeType.EndElement)
                        {
                            if (xmlReader.Name == m_XMLName) break;
                        }
                    }
                }

                xmlReader.Close();
            }
            else
            {
                SaveConfig();

            }
        }

        //public void LoadConfig_Manual(string strName)
        //{
        //    string strPath = $"{IGlobal.m_MainPJTRoot}\\RECIPE\\{strName}\\Parameter.xml";

        //    if (File.Exists(strPath))
        //    {
        //        XmlTextReader xmlReader = new XmlTextReader(strPath);

        //        while (xmlReader.Read())
        //        {
        //            if (xmlReader.NodeType == XmlNodeType.Element)
        //            {
        //                switch (xmlReader.Name)
        //                {
        //                    case "Ch1_LightValue": if (xmlReader.Read()) Ch1_LightValue = int.Parse(xmlReader.Value); break;
        //                    case "Ch2_LightValue": if (xmlReader.Read()) Ch2_LightValue = int.Parse(xmlReader.Value); break;

        //                    case "DrivePath": if (!xmlReader.Read()) return false; DrivePath = xmlReader.Value; break;
        //                    case "DriveVolum": if (!xmlReader.Read()) return false; DriveVolum = int.Parse(xmlReader.Value); break;
        //                    case "DeleteImageDay": if (!xmlReader.Read()) return false; DeleteImageDay = int.Parse(xmlReader.Value); break;

        //                    case "PbaCode": if (xmlReader.Read()) PbaCode = xmlReader.Value; break;
        //                }
        //            }
        //            else
        //            {
        //                if (xmlReader.NodeType == XmlNodeType.EndElement)
        //                {
        //                    if (xmlReader.Name == m_XMLName) break;
        //                }
        //            }
        //        }

        //        xmlReader.Close();
        //    }
        //    else
        //    {
        //        SaveConfig();
        //    }
        //}

        public bool SaveConfig()
        {
            string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{Name}\\JOBS\\Parameter.xml";

            //2024.03.15 송현수 -> 안춘길 : 처음 셋업 시 경로 에외 처리
            string baseDir = Path.GetDirectoryName(strPath);
            if (Directory.Exists(baseDir) == false) Directory.CreateDirectory(baseDir);

            string strArrayCountPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{Name}\\JOBS\\Jobs1.xml";
            // 파일스트림을 사용했으므로 파일닫기를 항시 해줘야함(닫기를 하지 않을시 다른쪽에서 파일 접근 불가)
            //FileStream _file;

            if (File.Exists(strArrayCountPath))
            {
                XmlTextReader xmlReader = new XmlTextReader(strArrayCountPath);

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.Name)
                        {
                            case "ArrayCount": if (xmlReader.Read()) ArrayCount = int.Parse(xmlReader.Value); break;
                        }
                    }
                }

                xmlReader.Close();
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\r\n";
            XmlWriter xmlWriter = XmlWriter.Create(strPath, settings);
            try
            {
                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement("Parameter");

                //xmlWriter.WriteElementString("OverCount_Min", OverCount_Min.ToString());
                //xmlWriter.WriteElementString("Ch1_LightValue", Ch1_LightValue.ToString());
                //xmlWriter.WriteElementString("Ch2_LightValue", Ch2_LightValue.ToString());

                //xmlWriter.WriteElementString("DrivePath", DrivePath.ToString());
                //xmlWriter.WriteElementString("DriveVolum", DriveVolum.ToString());
                //xmlWriter.WriteElementString("DeleteImageDay", DeleteImageDay.ToString());

                xmlWriter.WriteElementString("PbaCode", CODE.ToString());
                xmlWriter.WriteElementString("QRBufferNo", QRBufferNo.ToString());
                xmlWriter.WriteElementString("ArrayCount", ArrayCount.ToString());
                xmlWriter.WriteElementString("FIducialLibrary_Number", FIducialLibrary_Number.ToString());


                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                xmlWriter.Flush();
                xmlWriter.Close();
            }
            return true;
        }

        public bool PBALIBRARY_LoadTools(string strCode, bool pos = false)
        {
            CODE = strCode;

            string RecipePath = $"{Global.m_MainPJTRoot}";
            string code_path = $"{RecipePath}\\PBA_LIBRARY\\{CODE}";
            if (!Directory.Exists(code_path)) Directory.CreateDirectory(code_path);

            if (Prev_Code != CODE)
            {
                CLogger.Add(LOG.SEQ, $"MODEL CODE Changed : {Prev_Code}=>{CODE}");

                GrabManager = GrabManager.LoadConfig();

                if (JobManager_Array1 == null) JobManager_Array1 = new CInspJobs();
                JobManager_Array1 = JobManager_Array1.LoadNUpdateConfig(code_path, 1);

                if (JobManager_Array2 == null) JobManager_Array2 = new CInspJobs();
                JobManager_Array2 = JobManager_Array2.LoadNUpdateConfig(code_path, 2);

                if (JobManager_Array3 == null) JobManager_Array3 = new CInspJobs();
                JobManager_Array3 = JobManager_Array3.LoadNUpdateConfig(code_path, 3);

                if (JobManager_Array4 == null) JobManager_Array4 = new CInspJobs();
                JobManager_Array4 = JobManager_Array4.LoadNUpdateConfig(code_path, 4);

                JobManager = new CInspJobs[4] { JobManager_Array1, JobManager_Array2, JobManager_Array3, JobManager_Array4 };

                for (int i = 0; i < JobManager.Length; i++)
                {
                    if (JobManager[i] != null)
                    {
                        for (int j = 0; j < JobManager[i].Jobs.Count; j++)
                        {
                            List<CJob> jobs = JobManager[i].Jobs;

                            jobs[j].Tool.LoadConfig_Manual($"{code_path}\\{i}_{jobs[j].Name}_MAIN.vpp");
                            jobs[j].SubTool1.LoadConfig_Manual($"{code_path}\\{i}_{jobs[j].Name}_SUB1.vpp");
                            jobs[j].SubTool2.LoadConfig_Manual($"{code_path}\\{i}_{jobs[j].Name}_SUB2.vpp");
                            jobs[j].SubTool3.LoadConfig_Manual($"{code_path}\\{i}_{jobs[j].Name}_SUB3.vpp");
                            jobs[j].SubTool4.LoadConfig_Manual($"{code_path}\\{i}_{jobs[j].Name}_SUB4.vpp");

                            jobs[j].Tool.Tool.RunParams.ApproximateNumberToFind = jobs[j].MasterCount;
                            jobs[j].SubTool1.Tool.RunParams.ApproximateNumberToFind = jobs[j].MasterCount;
                            jobs[j].SubTool2.Tool.RunParams.ApproximateNumberToFind = jobs[j].MasterCount;
                            jobs[j].SubTool3.Tool.RunParams.ApproximateNumberToFind = jobs[j].MasterCount;
                            jobs[j].SubTool4.Tool.RunParams.ApproximateNumberToFind = jobs[j].MasterCount;

                            //JobManager[i].SaveConfig(JOBSPath, i + 1);
                        }
                    }
                }
            }

            return true;
        }
        #endregion CONFIG BY XML
    }
}