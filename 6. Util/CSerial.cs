using System;
using System.IO.Ports;

namespace IntelligentFactory
{
    public static class CSerial_Registry
    {
        // ==========================================
        // COM PORT 관련...
        // COMPORT 선언
        public static COM_PORT_Value[] m_Com;

        // COM PORT 시리얼 연결 처리 레지스트리 관리
        // Serial_COM : COM을 연결할 H/W이름으로 구성하면됨..
        // 시리얼 연결할 하드웨어 COM
        public static string[] m_Registry_COM_name;
        // COMP PORT 연결할 레지스트리 저장 키값..
        public const string m_Registry_COM_Parity_key = "Parity";
        public const string m_Registry_COM_Stopbit_key = "StopBits";
        public const string m_Registry_COM_Baudrate_key = "BaudRate";
        public const string m_Registry_COM_Databits_key = "Databits";
        public const string m_Registry_COM_PORT_key = "COM_PORT";

        public struct COM_PORT_Value
        {
            // 현재 읽어오는 COM PORT 값이 초기값인지 확인
            // true : 초기값, false : 초기값 아님..
            public bool m_LoadInitValue;            // 데이터 읽어올때 해당값이 초기값인지..기존 저장되어있는 값인지 확인..
            public string m_Name;
            public Parity m_com_parity;
            public StopBits m_com_stopbits;
            public int m_com_baudrate;
            public int m_com_databits;
            public string m_com_port;
        }

        // 추가 되는 시리얼 통신 하드웨어 이름 추가
        public enum COM_PORT_Name
        {
            LightController = 0,
            NG_Buffer,

            MAX
        }

        // 레지스트리 이름 설정
        private static void Serial_Registry_Name_Set()
        {
            // 시리얼 컴포트가 추가될 경우...저장할 레지스트리의 이름을 설정필요.
            m_Registry_COM_name = new string[]
            {
                // 추가 필요한 레지스트리 이름을 추가해주면됨..
                "LightController", "NG_Buffer"
            };
        }

        public static void COM_Port_Config_Read()
        {
            // 컴포트 레지스트리...
            Serial_Registry_Name_Set();

            // 시리얼 컴포트 관련 리드
            int ComPortMax_Cnt = (int)COM_PORT_Name.MAX;
            m_Com = new COM_PORT_Value[ComPortMax_Cnt];
            for (int i = 0; i < ComPortMax_Cnt; i++)
            {
                m_Com[i] = new COM_PORT_Value();
                Serial_ComPort_Read(m_Registry_COM_name[i], out m_Com[i]);
            }
        }

        // 레지스트리에 저장된 컴포트 리드..
        // _Init_flg : 초기값인지 현재 저장된 값인지 확인
        public static void Serial_ComPort_Read(string COM_NAME, out COM_PORT_Value _com)
        {
            bool _Init_flg = false;

            // 시리얼 컴포트 관련 키값들 모두 리드..
            string parity = CRegistry.Registry_Data_Read(COM_NAME, m_Registry_COM_Parity_key);
            string databits = CRegistry.Registry_Data_Read(COM_NAME, m_Registry_COM_Databits_key);
            string stopbits = CRegistry.Registry_Data_Read(COM_NAME, m_Registry_COM_Stopbit_key);
            string baudrate = CRegistry.Registry_Data_Read(COM_NAME, m_Registry_COM_Baudrate_key);
            string comport = CRegistry.Registry_Data_Read(COM_NAME, m_Registry_COM_PORT_key);

            if (parity == null) { parity = "0"; _Init_flg = true; }
            if (databits == null) { databits = "0"; _Init_flg = true; }
            if (stopbits == null) { stopbits = "0"; _Init_flg = true; }
            if (baudrate == null) { baudrate = "1000"; _Init_flg = true; }
            if (comport == null) { comport = "COM1"; _Init_flg = true; }

            _com.m_LoadInitValue = _Init_flg;
            _com.m_Name = COM_NAME;
            _com.m_com_parity = (Parity)Enum.Parse(typeof(Parity), parity);
            _com.m_com_databits = int.Parse(databits);
            _com.m_com_stopbits = (StopBits)Enum.Parse(typeof(StopBits), stopbits);
            _com.m_com_baudrate = int.Parse(baudrate);
            _com.m_com_port = comport;
        }

        // Name : m_Registry_COM_name 변수값 할당
        // _COM : 저장할 COM값..
        public static void Serial_ComPort_Write(string Name, COM_PORT_Value _COM)
        {
            CRegistry.Registry_Data_Write(Name, m_Registry_COM_Parity_key, _COM.m_com_parity.ToString());
            CRegistry.Registry_Data_Write(Name, m_Registry_COM_Databits_key, _COM.m_com_databits.ToString());
            CRegistry.Registry_Data_Write(Name, m_Registry_COM_Stopbit_key, _COM.m_com_stopbits.ToString());
            CRegistry.Registry_Data_Write(Name, m_Registry_COM_Baudrate_key, _COM.m_com_baudrate.ToString());
            CRegistry.Registry_Data_Write(Name, m_Registry_COM_PORT_key, _COM.m_com_port.ToString());
        }

        public static void Serial_Comport_All_Write()
        {
            for (int i = 0; i < m_Registry_COM_name.Length; i++)
            {
                CRegistry.Registry_Data_Write(m_Registry_COM_name[i], m_Registry_COM_Parity_key, m_Com[i].m_com_parity.ToString());
                CRegistry.Registry_Data_Write(m_Registry_COM_name[i], m_Registry_COM_Databits_key, m_Com[i].m_com_databits.ToString());
                CRegistry.Registry_Data_Write(m_Registry_COM_name[i], m_Registry_COM_Stopbit_key, m_Com[i].m_com_stopbits.ToString());
                CRegistry.Registry_Data_Write(m_Registry_COM_name[i], m_Registry_COM_Baudrate_key, m_Com[i].m_com_baudrate.ToString());
                CRegistry.Registry_Data_Write(m_Registry_COM_name[i], m_Registry_COM_PORT_key, m_Com[i].m_com_port.ToString());
            }
        }
        //===================================================================

    }
}
