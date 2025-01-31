using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentFactory
{
    public static class CSEQ_Main
    {
        public enum SEQ_Num
        {
            // 시퀀스 추가시...아래 시퀀스 스텝 넘버 추가..
            Inspector_Run = 1,
        }

        //===========================================================
        // 시퀀스 스텝 만들기...
        public enum AutoInspec_Run_SEQ_Step
        {
            // Auto Run 제어 시퀀스 스텝 구성
            SEQ_Init = 0,
            SEQ_IDLE,
            SEQ_GRAB,
            SEQ_WAIT_GRAB,
            SEQ_RESULT,
            SEQ_END,
        }

        // 시퀀스 번호
        public const int SEQ_Auto_Insepc_Run = (int)SEQ_Num.Inspector_Run;

        public const int m_STEP_NUM_MAX = 200;
        public static int[] m_STEP_No = new int[m_STEP_NUM_MAX];
        public static int[] m_SEQ_Set_TimeOut = new int[m_STEP_NUM_MAX];
        public static int[] m_SEQ_Get_TimeOut = new int[m_STEP_NUM_MAX];
        public static DateTime m_SeqStartTime = new DateTime();
        public static DateTime[] m_Unit1_Start_Time = new DateTime[m_STEP_NUM_MAX];
        public static DateTime[] m_Unit2_Start_Time = new DateTime[m_STEP_NUM_MAX];
        public static double[] m_Unit1_Check_Sec = new double[m_STEP_NUM_MAX];
        public static double[] m_Unit2_Check_Sec = new double[m_STEP_NUM_MAX];
        public static double[] m_SeqCheckMilliSec = new double[m_STEP_NUM_MAX];

        public static DateTime m_Check_Start_Get_Time;
        public static TimeSpan m_TimeOut_Check_TimeSpan;

        // 시퀀스 구동 체크 타임아웃 시간
        //===============================================================
        public const int SEQ_TIMEOUT_CHECK_5_SEC = 5000;
        public const int SEQ_TIMEOUT_CHECK_10_SEC = 10000;
        public const int SEQ_TIMEOUT_CHECK_15_SEC = 15000;
        public const int SEQ_TIMEOUT_CHECK_20_SEC = 20000;
        public const int SEQ_TIMEOUT_CHECK_25_SEC = 25000;
        public const int SEQ_TIMEOUT_CHECK_30_SEC = 30000;
        public const int SEQ_TIMEOUT_CHECK_35_SEC = 35000;
        public const int SEQ_TIMEOUT_CHECK_60_SEC = 60000;      // 1분
        public const int SEQ_TIMEOUT_CHECK_120_SEC = 120000;    // 2분
        public const int SEQ_TIMEOUT_CHECK_180_SEC = 180000;    // 3분
        public const int SEQ_TIMEOUT_CHECK_300_SEC = 300000;    // 5분
        public const int SEQ_TIMEOUT_CHECK_600_SEC = 600000;    // 10분
        //================================================================

        private const double SEC_TO_MILLISEC = 1000;

        // 다음 시퀀스로 이동
        public static void SetNextSeq(int _seqNo, double _setTimeoutSec)
        {
            SetNextSeq(_seqNo, m_STEP_No[_seqNo] + 1, _setTimeoutSec);
        }

        // 해당되는 시퀀스 스텝으로 이동
        public static void SetNextSeq(int _seqNo, int _stepNum, double _setTimeoutSec)
        {
            m_STEP_No[_seqNo] = _stepNum; // 다음 단계로 이동 
            m_SeqCheckMilliSec[_seqNo] = _setTimeoutSec;
            m_SeqStartTime = DateTime.Now;
        }

        // 시퀀스 구동 타임아웃 체크
        public static bool CheckTime(int _seqNo)
        {
            //(검사 시간)이 (현재 시간 - 시작 시간) 이상이 되는 경우 타임아웃 true
            double checkTime = (DateTime.Now - m_SeqStartTime).TotalMilliseconds;
            if (checkTime >= m_SeqCheckMilliSec[_seqNo])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SET_Next_Seq(int m_SeqNo, int m_StepNum, int m_SetSecCount) // Time Out 설정  및 다음 스템으로 진행 한다. 
        {
            m_Check_Start_Get_Time = DateTime.Now;          // 시퀀스 타임아웃 체크를 위해 체크 시작 시간 확인

            m_STEP_No[m_SeqNo] = m_StepNum;
            m_SEQ_Set_TimeOut[m_SeqNo] = m_SetSecCount;
            m_SEQ_Get_TimeOut[m_SeqNo] = 0;
        }

        public static void SET_Next_Seq(int m_SeqNo, int m_SetSecCount) // Time Out 설정  및 다음 스템으로 진행 한다. 
        {
            m_Check_Start_Get_Time = DateTime.Now;          // 시퀀스 타임아웃 체크를 위해 체크 시작 시간 확인

            m_STEP_No[m_SeqNo] = m_STEP_No[m_SeqNo] + 1; // 다음 단계로 이동 
            m_SEQ_Set_TimeOut[m_SeqNo] = m_SetSecCount;
            m_SEQ_Get_TimeOut[m_SeqNo] = 0;         // Get Time 초기화
        }

        public static void INC_Time_Out(int m_SeqNo) // Time Out 설정 
        {
            m_SEQ_Get_TimeOut[m_SeqNo]++;
        }

        public static bool CHECK_Time_Out(int m_SeqNo) // Time Out 설정 
        {
            m_TimeOut_Check_TimeSpan = DateTime.Now - m_Check_Start_Get_Time;
            double total_time = m_TimeOut_Check_TimeSpan.TotalSeconds;
            m_SEQ_Get_TimeOut[m_SeqNo] = Convert.ToInt32(total_time * SEC_TO_MILLISEC);            // 밀리 세컨드 단위 체크를 위해 1000을 곱해줌

            if (m_SEQ_Get_TimeOut[m_SeqNo] >= m_SEQ_Set_TimeOut[m_SeqNo])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
