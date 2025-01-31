using Microsoft.Win32;

namespace IntelligentFactory
{
    public static class CRegistry
    {
        // 레지스트리 쓰기 처리
        // Name, key, value(값)
        public static void Registry_Data_Write(string Name, string key, string Value)
        {
            RegistryKey regkey = Registry.LocalMachine.CreateSubKey($"SOFTWARE\\{Name}", RegistryKeyPermissionCheck.ReadWriteSubTree);

            if (regkey.ValueCount > 0)
            {
                RegistryKey sub_regkey = regkey.OpenSubKey(key);

                if (sub_regkey != null)
                {
                    // 값 저장
                    regkey.SetValue(key, Value);
                }
                else
                {
                    regkey.CreateSubKey(key);
                    regkey.SetValue(key, Value);
                }
                regkey.Close();
            }
            else
            {
                regkey.CreateSubKey(key);
                regkey.SetValue(key, Value);
                regkey.Close();
            }
        }

        // 레지스트리 읽기 처리
        // 하나의 name에 하나의 하위키일경우의 레지스트리..
        public static string Registry_Data_Read(string Name, string key)
        {
            string ret;
            RegistryKey regkey = Registry.LocalMachine.CreateSubKey($"SOFTWARE\\{Name}", RegistryKeyPermissionCheck.ReadWriteSubTree);

            // 레지스트러가 있을때 가져옴
            if (regkey.ValueCount > 0)
            {
                // 하위 키값이 있는지 확인함..
                RegistryKey sub_regkey = regkey.OpenSubKey(key);

                if (sub_regkey != null)
                {
                    ret = regkey.GetValue(key).ToString();
                }
                else
                {
                    ret = null;
                }

                regkey.Close();
            }
            else
            {
                ret = null;
            }

            return ret;
        }

        // 해당된 이름을 기준으로 모두 삭제...
        public static void Registry_Data_Del(string Name)
        {
            RegistryKey regkey_IN = Registry.LocalMachine.CreateSubKey($"SOFTWARE\\{Name}", RegistryKeyPermissionCheck.ReadWriteSubTree);
            //====================================
            // 기록된 레지스터리 모두 삭제시 사용
            string[] ret_str = regkey_IN.GetValueNames();
            for (int i = 0; i < ret_str.Length; i++)
            {
                regkey_IN.DeleteValue(ret_str[i], false);
                regkey_IN.DeleteSubKey(ret_str[i], false);
            }

            regkey_IN.Close();
        }
    }
}
