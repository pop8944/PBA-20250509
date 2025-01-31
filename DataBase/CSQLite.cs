using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    //송현수
    //사용 시, Nuget Manager 에서 System.Data.SQLite 를 설치해야하며, Entity Framework 호환되는 버전을 확인해야합니다.
    //만약 버전이 안맞을 시, Entity Framework 을 제거한 후 최신 버전으로 새로 설치해주세요.
    public class CSQLite
    {
        private string m_strConnectPath;

        public CSQLite(string strPath)
        {
            m_strConnectPath = strPath;
        }

        public void Create()
        {
            try
            {
                SQLiteConnection.CreateFile(m_strConnectPath);

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private string GetTableCreationCommand(bool onlyNotExist, string name, KeyValuePair<string, string>[] elements)
        {
            //string strTableCreate = "CREATE TABLE T_HISTORY (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, time TEXT NOT NULL, code TEXT, desc TEXT, model TEXT, tray_type TEXT, barcode TEXT);";

            string strQuery = $"CREATE TABLE IF NOT EXISTS '{name}'(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL";

            for (int i = 0; i < elements.Length; i++)
                strQuery += $", '{elements[i].Key}' {elements[i].Value}";

            strQuery += ");";
            return strQuery;
        }

        private KeyValuePair<string, string> tableElement(string name, string typenetc)
        {
            return new KeyValuePair<string, string>(name, typenetc);
        }

        //직접 connection을 열지 않는다.
        //connection을 매개변수로 받아와서 진행한다.
        public void CreateTable(string strTableName, KeyValuePair<string, string>[] tables)
        {
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={m_strConnectPath};Version=3;"))
            using (var command = new SQLiteCommand(conn))
            {
                conn.Open();

                command.CommandText = GetTableCreationCommand(true, strTableName, tables);
                command.ExecuteNonQuery();
            }
        }

        public void Connect(string strPath = "")
        {
            try
            {
                m_strConnectPath = strPath;

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void BeginTran(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("Begin", conn);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        private void CommitTran(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("Commit", conn);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void Select(string strTable, string strWhereCol, string strWhereValue)
        {
            try
            {
                string strQuery = $"SELECT * FROM {strTable} WHERE {strWhereCol} = {strWhereValue}";

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB_ALARM.sqlite;Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string id = rdr["id"].ToString();
                        string name = rdr["name"].ToString();
                        string[] strs = new string[] { id, name };
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        public void Insert_Result(string strTable, string[] strFields, string[] strValues)
        {
            try
            {
                string strValue = "";
                string strField = "";

                // 추가되는 DB 컬럼의 목록을 검색함..
                List<string> list = DB_Column_Check(strTable);

                for (int i = 0; i < strFields.Length; i++)
                {
                    // 해당 컬럼에 없으면 컬럼 추가..
                    if (!list[0].Contains(strFields[i]))
                    {
                        DATA_Column_Add(strTable, strFields[i]);
                    }

                    if (i == strFields.Length - 1)
                    {
                        strField += strFields[i];
                    }
                    else
                    {
                        strField += strFields[i] + ",";
                    }
                }

                for (int i = 0; i < strValues.Length; i++)
                {
                    if (i == strValues.Length - 1)
                    {
                        strValue += strValues[i];
                    }
                    else
                    {
                        strValue += strValues[i] + ",";
                    }
                }

                string strQuery = $"INSERT INTO {strTable}({strField}) VALUES ({strValue})";
                Query("DB", strQuery);

                //CLogger.Add(LOG_TYPE.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        // DB 컬럼 유무 조회..
        public List<string> DB_Column_Check(string strTable)
        {
            List<string> list = new List<string>();

            try
            {
                if (string.IsNullOrEmpty(m_strConnectPath)) return list;

                string str_query = $"SELECT sql FROM sqlite_master WHERE tbl_name='{strTable}'";

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB.sqlite;Version=3;"))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(str_query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                list.Add(reader.GetString(i));
                                i++;
                            }
                        }

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch
            {
                CLogger.Add(LOG.EXCEPTION, "DB_Column_Check Query ERROR!!");
            }

            return list;
        }

        // 컬럼 추가..
        // 추가할 컬럼 이름..
        public void DATA_Column_Add(string strTable, string str_column)
        {
            try
            {
                if (string.IsNullOrEmpty(m_strConnectPath)) return;

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB.sqlite;Version=3;"))
                {
                    conn.Open();
                    string sql = $"ALTER TABLE {strTable} ADD COLUMN '{str_column}' TEXT";

                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    int result = command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch
            {
                CLogger.Add(LOG.EXCEPTION, "DATA_Column_Add Query ERROR!!");
            }
        }


        public List<string[]> NG_QRCODE(string strTable, string strCode1 = "", string strCode2 = "")
        {
            List<string[]> list = new List<string[]>();
            try
            {
                string strQuery = $"SELECT * FROM {strTable}";

                if (!string.IsNullOrEmpty(strCode1) && !string.IsNullOrEmpty(strCode2))
                {
                    if (!strQuery.Contains("WHERE")) strQuery += " WHERE ";
                    strQuery += $"qrcode = '{strCode1}' OR qrcode = '{strCode2}'";
                }
                else if (!string.IsNullOrEmpty(strCode1) && string.IsNullOrEmpty(strCode2))
                {
                    if (!strQuery.Contains("WHERE")) strQuery += " WHERE ";
                    strQuery += $"qrcode = '{strCode1}'";
                }
                else if (string.IsNullOrEmpty(strCode1) && !string.IsNullOrEmpty(strCode2))
                {
                    if (!strQuery.Contains("WHERE")) strQuery += " WHERE ";
                    strQuery += $"qrcode = '{strCode2}'";
                }

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB_PBA.sqlite;Version=3;"))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;
                    while (rdr.Read())
                    {
                        string str1 = rdr["time"].ToString().Replace("T", " ");
                        string str2 = rdr["model"].ToString();
                        string str3 = rdr["camera"].ToString();
                        string str4 = rdr["qrcode"].ToString();
                        string str5 = rdr["firstresult"].ToString();
                        string str6 = rdr["secondresult"].ToString();
                        string str7 = rdr["masterimagepath"].ToString();
                        string str8 = rdr["ngimagepath"].ToString();
                        string str9 = rdr["ngtype"].ToString();
                        string str10 = rdr["ngpoint"].ToString();
                        string str11 = rdr["ng_reason"].ToString();
                        string str12 = rdr["ng_rect"].ToString();

                        list.Add(new string[] { nIndex.ToString(), str1, str2, str3, str4, str5, str6, str7, str8, str9, str10, str11, str12 });
                        nIndex++;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return list;
            }

            return list;
        }

        public List<string[]> NG_BUFFERCODE(string strTable, string strCode1 = "", string strCode2 = "")
        {
            List<string[]> list = new List<string[]>();
            try
            {
                string strQuery = $"SELECT * FROM {strTable}";

                if (!string.IsNullOrEmpty(strCode1) && !string.IsNullOrEmpty(strCode2))
                {
                    if (!strQuery.Contains("WHERE")) strQuery += " WHERE ";
                    strQuery += $"qrcode LIKE '%{strCode1}%' OR qrcode LIKE '%{strCode2}%'";
                }
                else if (!string.IsNullOrEmpty(strCode1) && string.IsNullOrEmpty(strCode2))
                {
                    if (!strQuery.Contains("WHERE")) strQuery += " WHERE ";
                    strQuery += $"qrcode = '%{strCode1}%'";
                }
                else if (string.IsNullOrEmpty(strCode1) && !string.IsNullOrEmpty(strCode2))
                {
                    if (!strQuery.Contains("WHERE")) strQuery += " WHERE ";
                    strQuery += $"qrcode = '%{strCode2}%'";
                }

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB_PBA.sqlite;Version=3;"))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;
                    while (rdr.Read())
                    {
                        string str1 = rdr["time"].ToString().Replace("T", " ");
                        string str2 = rdr["model"].ToString();
                        string str3 = rdr["camera"].ToString();
                        string str4 = rdr["qrcode"].ToString();
                        string str5 = rdr["firstresult"].ToString();
                        string str6 = rdr["secondresult"].ToString();
                        string str7 = rdr["masterimagepath"].ToString();
                        string str8 = rdr["ngimagepath"].ToString();
                        string str9 = rdr["ngtype"].ToString();
                        string str10 = rdr["ngpoint"].ToString();
                        string str11 = rdr["ng_reason"].ToString();
                        string str12 = rdr["ng_rect"].ToString();

                        list.Add(new string[] { nIndex.ToString(), str1, str2, str3, str4, str5, str6, str7, str8, str9, str10, str11, str12 });
                        nIndex++;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return list;
            }

            return list;
        }

        public int Select_TotalCount(string strTable, string strModel, string strStartTime)
        {
            int cnt = 0;
            try
            {
                //SELECT DISTINCT qrcode FROM HISTORY WHERE model LIKE 'DA9405311G' AND time > '20240101:000000' AND insp_judge = 'OK'
                string strQuery = $"SELECT DISTINCT qrcode FROM {strTable} WHERE time > '{strStartTime}' AND model = '{strModel}'";


                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB.sqlite;Version=3;"))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read()) cnt++;


                }

                return cnt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return cnt;
            }
        }

        public int Select_OKCount(string strTable, string strModel, string strStartTime)
        {
            int cnt = 0;
            try
            {
                //SELECT DISTINCT qrcode FROM HISTORY WHERE model LIKE 'DA9405311G' AND time > '20240101:000000' AND insp_judge = 'OK'
                string strQuery = $"SELECT DISTINCT qrcode FROM {strTable} WHERE time > '{strStartTime}' AND model = '{strModel}' AND insp_judge = 'OK'";


                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB.sqlite;Version=3;"))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read()) cnt++;


                }

                return cnt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return cnt;
            }
        }

        public int Select_NGCount(string strTable, string strModel, string strStartTime)
        {
            int cnt = 0;
            try
            {
                //SELECT DISTINCT qrcode FROM HISTORY WHERE model LIKE 'DA9405311G' AND time > '20240101:000000' AND insp_judge = 'OK'
                string strQuery = $"SELECT DISTINCT qrcode FROM {strTable} WHERE time > '{strStartTime}' AND model = '{strModel}' AND insp_judge = 'NG'";


                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB.sqlite;Version=3;"))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read()) cnt++;
                }

                return cnt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return cnt;
            }
        }

        public List<string[]> SelectAll_DateAndJUDGE(string strTable, string strQr, string strModel, string strStartTime, string strEndTime)
        {
            List<string[]> list = new List<string[]>();
            //string strJudge = "";
            try
            {
                string strQuery = $"SELECT * FROM {strTable} WHERE time BETWEEN '{strStartTime}' AND '{strEndTime}'";

                //if (!string.IsNullOrEmpty(strQr))
                if (strQr != "All")
                {
                    if (!strQuery.Contains("WHERE"))
                    {
                        strQuery += $" WHERE qrcode = '{strQr}'";
                    }
                    else
                    {
                        strQuery += $" AND qrcode = '{strQr}'";
                    }
                }

                if (strModel != "All")
                {
                    if (!strQuery.Contains("WHERE"))
                    {
                        strQuery += $" WHERE model = '{strModel}'";
                    }
                    else
                    {
                        strQuery += $" AND model = '{strModel}'";
                    }
                }

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB.sqlite;Version=3;"))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;
                    while (rdr.Read())
                    {
                        string str1 = rdr["time"].ToString().Replace("T", " ");
                        string str2 = rdr["model"].ToString();
                        string str3 = rdr["qrcode"].ToString();
                        string str4 = rdr["insp_judge"].ToString();
                        string str5 = rdr["rms_judge"].ToString();
                        string str6 = rdr["master_img_path"].ToString();
                        string str7 = rdr["ng_img_path"].ToString();
                        string str8 = rdr["crop_img_path"].ToString();
                        string str9 = rdr["master_crop_img_path"].ToString();
                        string str10 = rdr["ng_part_code"].ToString();
                        string str11 = rdr["ng_reason"].ToString();
                        string str12 = rdr["ng_rect"].ToString();
                        string str13 = rdr["tacktime"].ToString();

                        list.Add(new string[] { str1, str2, str3, str4, str5, str6, str7, str8, str9, str10, str11, str12, str13 });
                        nIndex++;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return list;
            }

            return list;
        }

        public class HistoryNode
        {
            public string Time = "";
            public string Model = "";
            public string QrCode = "";
            public string InspJudge = "OK";
            public string RmsJudge = "OK";
            public string MasterImagePath = "";
            public string NgImagePath = "";
            public int NgCount = 0;
            public string TactTime = "";
        }

        public List<string[]> Select_History(int nTypeJudge, string strQr, string model, string startDateTime, string endDateTime, string rms_filter)
        {
            List<string[]> list = new List<string[]>();

            string strJudge = "";
            if (nTypeJudge == 0)
                strJudge = "rms_judge";
            else
                strJudge = "insp_judge";

            try
            {
                string query = "";


                query = $"SELECT * FROM HISTORY WHERE time BETWEEN '{startDateTime}' AND '{endDateTime}' AND {strJudge} = '{rms_filter}'";

                if (strQr != "All")
                {
                    if (!query.Contains("WHERE"))
                    {
                        query += $" WHERE qrcode = '{strQr}'";
                    }
                    else
                    {
                        query += $" AND qrcode = '{strQr}'";
                    }
                }

                if (model != "All")
                {
                    if (!query.Contains("WHERE"))
                    {
                        query += $" WHERE model = '{model}'";
                    }
                    else
                    {
                        query += $" AND model = '{model}'";
                    }
                }
                Dictionary<string, HistoryNode> history = new Dictionary<string, HistoryNode>();

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB.sqlite;Version=3;"))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string read_QrCode = rdr["qrcode"].ToString();
                        string read_InspJudge = rdr["insp_judge"].ToString();
                        string read_Time = rdr["time"].ToString().Replace("T", " ");
                        string key = $"{read_QrCode}:{read_Time}";
                        string read_Model = rdr["model"].ToString();
                        string read_RmsJudge = rdr["rms_judge"].ToString();
                        string read_MasterImagePath = rdr["master_img_path"].ToString();
                        string read_NgImagePath = rdr["ng_img_path"].ToString();
                        string read_TactTime = rdr["tacktime"].ToString();

                        //재검 했을 경우를 구분할 필요가 있습니다.

                        if (history.ContainsKey(key) == false)
                        {
                            history.Add(key, new HistoryNode());

                            history[key].QrCode = read_QrCode;
                            history[key].Time = read_Time;
                            history[key].Model = read_Model;
                            history[key].MasterImagePath = read_MasterImagePath;
                            history[key].NgImagePath = read_NgImagePath;
                            history[key].TactTime = read_TactTime;
                        }

                        if (history[key].RmsJudge != "NG")
                        {
                            if (read_RmsJudge == "IDLE") history[key].RmsJudge = "IDLE";
                            if (read_RmsJudge == "NG") history[key].RmsJudge = "NG";
                        }

                        if (read_InspJudge == "NG")
                        {
                            history[key].InspJudge = "NG";
                            history[key].NgCount++;
                        }
                    }

                    foreach (var item in history)
                    {
                        HistoryNode node = item.Value;

                        list.Add(new string[] { node.Time, node.Model, node.QrCode, node.InspJudge, node.RmsJudge, node.MasterImagePath, node.NgImagePath, node.NgCount.ToString(), node.TactTime });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return list;
            }

            return list;
        }
        public List<string[]> SelectAll_History(string strQr, string model, string startDateTime, string endDateTime)
        {
            List<string[]> list = new List<string[]>();

            try
            {
                string query = "";


                query = $"SELECT * FROM HISTORY WHERE time BETWEEN '{startDateTime}' AND '{endDateTime}'";

                if (strQr != "All")
                {
                    if (!query.Contains("WHERE"))
                    {
                        query += $" WHERE qrcode = '{strQr}'";
                    }
                    else
                    {
                        query += $" AND qrcode = '{strQr}'";
                    }
                }

                if (model != "All")
                {
                    if (!query.Contains("WHERE"))
                    {
                        query += $" WHERE model = '{model}'";
                    }
                    else
                    {
                        query += $" AND model = '{model}'";
                    }
                }
                Dictionary<string, HistoryNode> history = new Dictionary<string, HistoryNode>();

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB.sqlite;Version=3;"))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string read_QrCode = rdr["qrcode"].ToString();
                        string read_InspJudge = rdr["insp_judge"].ToString();
                        string read_Time = rdr["time"].ToString().Replace("T", " ");
                        string key = $"{read_QrCode}:{read_Time}";
                        string read_Model = rdr["model"].ToString();
                        string read_RmsJudge = rdr["rms_judge"].ToString();
                        string read_MasterImagePath = rdr["master_img_path"].ToString();
                        string read_NgImagePath = rdr["ng_img_path"].ToString();
                        string read_TactTime = rdr["tacktime"].ToString();

                        //재검 했을 경우를 구분할 필요가 있습니다.

                        if (history.ContainsKey(key) == false)
                        {
                            history.Add(key, new HistoryNode());

                            history[key].QrCode = read_QrCode;
                            history[key].Time = read_Time;
                            history[key].Model = read_Model;
                            history[key].MasterImagePath = read_MasterImagePath;
                            history[key].NgImagePath = read_NgImagePath;
                            history[key].TactTime = read_TactTime;
                        }

                        if (history[key].RmsJudge != "NG")
                        {
                            if (read_RmsJudge == "IDLE") history[key].RmsJudge = "IDLE";
                            if (read_RmsJudge == "NG") history[key].RmsJudge = "NG";
                        }

                        if (read_InspJudge == "NG")
                        {
                            history[key].InspJudge = "NG";
                            history[key].NgCount++;
                        }
                    }

                    foreach (var item in history)
                    {
                        HistoryNode node = item.Value;

                        list.Add(new string[] { node.Time, node.Model, node.QrCode, node.InspJudge, node.RmsJudge, node.MasterImagePath, node.NgImagePath, node.NgCount.ToString(), node.TactTime });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return list;
            }

            return list;
        }
        public List<string[]> Select_DateAndJUDGE(int nTypeJudge, string strTable, string strQr, string strModel, string strStartTime, string strEndTime, string rms_filter)
        {
            List<string[]> list = new List<string[]>();
            string strJudge = "";
            if (nTypeJudge == 0)
                strJudge = "rms_judge";
            else
                strJudge = "insp_judge";
            try
            {
                string strQuery = $"SELECT * FROM {strTable} WHERE time BETWEEN '{strStartTime}' AND '{strEndTime}' AND {strJudge} = '{rms_filter}'";

                if (strQr != "All")
                {
                    if (!strQuery.Contains("WHERE"))
                    {
                        strQuery += $" WHERE qrcode = '{strQr}'";
                    }
                    else
                    {
                        strQuery += $" AND qrcode = '{strQr}'";
                    }
                }

                if (strModel != "All")
                {
                    if (!strQuery.Contains("WHERE"))
                    {
                        strQuery += $" WHERE model = '{strModel}'";
                    }
                    else
                    {
                        strQuery += $" AND model = '{strModel}'";
                    }
                }

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB.sqlite;Version=3;"))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;
                    while (rdr.Read())
                    {
                        string str1 = rdr["time"].ToString().Replace("T", " ");
                        string str2 = rdr["model"].ToString();
                        string str3 = rdr["qrcode"].ToString();
                        string str4 = rdr["insp_judge"].ToString();
                        string str5 = rdr["rms_judge"].ToString();
                        string str6 = rdr["master_img_path"].ToString();
                        string str7 = rdr["ng_img_path"].ToString();
                        string str8 = rdr["crop_img_path"].ToString();
                        string str9 = rdr["master_crop_img_path"].ToString();
                        string str10 = rdr["ng_part_code"].ToString();
                        string str11 = rdr["ng_reason"].ToString();
                        string str12 = rdr["ng_rect"].ToString();
                        string str13 = rdr["tacktime"].ToString();

                        list.Add(new string[] { str1, str2, str3, str4, str5, str6, str7, str8, str9, str10, str11, str12, str13 });
                        nIndex++;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return list;
            }

            return list;
        }

        public List<string[]> SelectAll_DATE(string strTable, string date = "")
        {
            List<string[]> list = new List<string[]>();
            try
            {
                string strQuery = $"SELECT * FROM {strTable}";

                if (!string.IsNullOrEmpty(date))
                {
                    if (!strQuery.Contains("WHERE")) strQuery += " WHERE ";
                    strQuery += $"time LIKE '%{date}%'";
                }

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB.sqlite;Version=3;"))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;
                    while (rdr.Read())
                    {
                        //new KeyValuePair<string, string>("time", "TEXT NOT NULL"),
                        //new KeyValuePair<string, string>("model", "TEXT"),
                        //new KeyValuePair<string, string>("qrcode", "TEXT"),
                        //new KeyValuePair<string, string>("insp_judge", "TEXT"),
                        //new KeyValuePair<string, string>("rms_judge", "TEXT"),
                        //new KeyValuePair<string, string>("master_img_path", "TEXT"),
                        //new KeyValuePair<string, string>("ng_img_path", "TEXT"),
                        //new KeyValuePair<string, string>("crop_img_path", "TEXT"),
                        //new KeyValuePair<string, string>("ng_part_code", "TEXT"),
                        string str1 = rdr["time"].ToString().Replace("T", " ");
                        string str2 = rdr["model"].ToString();
                        string str3 = rdr["qrcode"].ToString();
                        string str4 = rdr["insp_judge"].ToString();
                        string str5 = rdr["rms_judge"].ToString();
                        string str6 = rdr["master_img_path"].ToString();
                        string str7 = rdr["ng_img_path"].ToString();
                        string str8 = rdr["crop_img_path"].ToString();
                        string str9 = rdr["master_crop_img_path"].ToString();
                        string str10 = rdr["ng_part_code"].ToString();
                        string str11 = rdr["ng_reason"].ToString();
                        string str12 = rdr["ng_rect"].ToString();

                        list.Add(new string[] { str1, str2, str3, str4, str5, str6, str7, str8, str9, str10, str11, str12 });
                        nIndex++;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return list;
            }

            return list;
        }

        public class HistoryData
        {
            public string DateTime;
            public string Model;
            public string QrCode;
            public string InspJudge = "OK";
            public string RmsJudge = "OK";
            public string NgReason;
            public string TactTime;
            public string MasterImagePath = "";
            public string NgImagePath = "";
            public int NgCount = 0;
        }
        public Dictionary<string, HistoryData> SelectAll_DATE_HISTORY(string strTable, string date = "")
        {
            Dictionary<string, HistoryData> History = new Dictionary<string, HistoryData>();

            try
            {
                string strQuery = $"SELECT * FROM {strTable}";

                if (!string.IsNullOrEmpty(date))
                {
                    if (!strQuery.Contains("WHERE")) strQuery += " WHERE ";
                    strQuery += $"time LIKE '%{date}%'";
                }



                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB.sqlite;Version=3;"))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string str1 = rdr["time"].ToString().Replace("T", " ");
                        string str2 = rdr["model"].ToString();
                        string qrCode = rdr["qrcode"].ToString();
                        string str4 = rdr["insp_judge"].ToString();
                        string str5 = rdr["rms_judge"].ToString();
                        string str6 = rdr["master_img_path"].ToString();
                        string str7 = rdr["ng_img_path"].ToString();
                        string str8 = rdr["crop_img_path"].ToString();
                        string str11 = rdr["ng_reason"].ToString();

                        if (History.ContainsKey(qrCode) == false) History.Add(qrCode, new HistoryData());

                        History[qrCode].DateTime = str1;
                        History[qrCode].Model = str2;
                        History[qrCode].QrCode = qrCode;

                        if (History[qrCode].InspJudge == "OK" && str4 == "OK")
                        {

                        }
                        else
                        {
                            History[qrCode].InspJudge = "NG";
                        }

                        if (History[qrCode].RmsJudge == "OK" && str4 == "OK")
                        {

                        }
                        else
                        {
                            History[qrCode].RmsJudge = "NG";
                            History[qrCode].NgCount++;
                        }

                        History[qrCode].MasterImagePath = str6;
                        History[qrCode].NgImagePath = str7;
                        History[qrCode].NgReason += $"{str11},";
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return History;
            }

            return History;
        }

        // Model , SerialNo조합으로 추적가능하도록 보완 필요
        public List<string[]> SelectAll_NGBuffer(string strTable, List<string> Barcodes)
        {
            List<string[]> list = new List<string[]>();
            string strModel = Global.Instance.System.Recipe.Name;
            string strSerial = "";
            string strStart = DateTime.Now.AddHours(-12).ToString("yyyyMMdd:HHmmss");
            string strEnd = DateTime.Now.ToString("yyyyMMdd:HHmmss");
            try
            {
                string strQuery = $"SELECT * FROM {strTable} WHERE";

                for (int i = 0; i < Barcodes.Count; i++)
                {
                    if (Barcodes[i].Length == 4)
                    {
                        if (i == 0) strQuery += $" time BETWEEN '{strStart}' AND '{strEnd}' AND";
                        if (i > 0)
                        {
                            strQuery += $" OR";
                            strQuery += $" time BETWEEN '{strStart}' AND '{strEnd}' AND";
                        }
                        strQuery += $" qrcode LIKE '%{Barcodes[i]}%' AND qrcode LIKE '%{strModel}%' ";
                    }
                    else
                    {
                        QRParser qr = new QRParser(Barcodes[i], true);
                        strModel = qr.GetModel();
                        strSerial = qr.GetSerialNo();
                        if (i > 0)
                            strQuery += $" OR";
                        //strQuery += $" qrcode LIKE '%{Barcodes[i]}%'";

                        strQuery += $" qrcode LIKE '%{strModel}%' AND qrcode LIKE '%{strSerial}%' AND time BETWEEN '{strStart}' AND '{strEnd}' ";
                        //.//rg test
                        //strQuery += $" qrcode LIKE '%{strModel}%' AND qrcode LIKE '%{strSerial}%' ";
                        //.//
                    }
                }


                bool bRead = false;
                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB.sqlite;Version=3;"))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;
                    while (bRead = rdr.Read())
                    {
                        string str1 = rdr["time"].ToString().Replace("T", " ");
                        string str2 = rdr["model"].ToString();
                        string str3 = rdr["qrcode"].ToString();
                        string str4 = rdr["insp_judge"].ToString();
                        string str5 = rdr["rms_judge"].ToString();
                        string str6 = rdr["master_img_path"].ToString();
                        string str7 = rdr["ng_img_path"].ToString();
                        string str8 = rdr["crop_img_path"].ToString();
                        string str9 = rdr["master_crop_img_path"].ToString();
                        string str10 = rdr["ng_part_code"].ToString();
                        string str11 = rdr["ng_reason"].ToString();
                        string str12 = rdr["ng_rect"].ToString();

                        list.Add(new string[] { str1, str2, str3, str4, str5, str6, str7, str8, str9, str10, str11, str12 });
                        nIndex++;
                    }
                }
            }
            catch /*(Exception e)*/
            {
                //MessageBox.Show(e.ToString());
                return list;
            }

            return list;
        }

        public List<string[]> SelectAll_NGBuffer_RMS_IDLE(string strTable, List<string> Barcodes)
        {
            List<string[]> list = new List<string[]>();
            try
            {
                string strQuery = $"SELECT * FROM {strTable} WHERE";

                for (int i = 0; i < Barcodes.Count; i++)
                {
                    if (i > 0)
                        strQuery += $" OR";
                    strQuery += $" qrcode LIKE '%{Barcodes[i]}%'";
                }

                //if (Barcodes.Count > 0)
                //{
                //    strQuery += $" WHERE qrcode LIKE ('%{Barcodes[0]}%')";
                //}

                //복수개 사용시
                //strQuery += $" WHERE qrcode LIKE ('%{Barcodes[0]}%' OR '%{Barcodes[1]}%' OR '%{Barcodes[2]}%')";
                //for (int i = 0; i < Barcodes.Count; i++)
                //{
                //    if (i != Barcodes.Count - 1)
                //    {
                //        strQuery += $"qrcode LIKE ('%{Barcodes[i]}%' OR ";
                //    }
                //    else
                //    {
                //    }
                //}

                strQuery += $" AND rms_judge = 'IDLE'";
                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB.sqlite;Version=3;"))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;
                    while (rdr.Read())
                    {
                        //new KeyValuePair<string, string>("time", "TEXT NOT NULL"),
                        //new KeyValuePair<string, string>("model", "TEXT"),
                        //new KeyValuePair<string, string>("qrcode", "TEXT"),
                        //new KeyValuePair<string, string>("insp_judge", "TEXT"),
                        //new KeyValuePair<string, string>("rms_judge", "TEXT"),
                        //new KeyValuePair<string, string>("master_img_path", "TEXT"),
                        //new KeyValuePair<string, string>("ng_img_path", "TEXT"),
                        //new KeyValuePair<string, string>("crop_img_path", "TEXT"),
                        //new KeyValuePair<string, string>("ng_part_code", "TEXT"),
                        string str1 = rdr["time"].ToString().Replace("T", " ");
                        string str2 = rdr["model"].ToString();
                        string str3 = rdr["qrcode"].ToString();
                        string str4 = rdr["insp_judge"].ToString();
                        string str5 = rdr["rms_judge"].ToString();
                        string str6 = rdr["master_img_path"].ToString();
                        string str7 = rdr["ng_img_path"].ToString();
                        string str8 = rdr["crop_img_path"].ToString();
                        string str9 = rdr["master_crop_img_path"].ToString();
                        string str10 = rdr["ng_part_code"].ToString();
                        string str11 = rdr["ng_reason"].ToString();
                        string str12 = rdr["ng_rect"].ToString();

                        if (str5 == "IDLE")
                        {
                            list.Add(new string[] { str1, str2, str3, str4, str5, str6, str7, str8, str9, str10, str11, str12 });
                            nIndex++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return list;
            }

            return list;
        }

        public List<string[]> Select_NGBuffer(string strTable, string qrCode)
        {
            List<string[]> list = new List<string[]>();
            string strModel = "";
            string strSerial = "";
            string strToday = DateTime.Today.ToString("yyyyMMdd");
            try
            {
                string strQuery = $"SELECT * FROM {strTable} WHERE time LIKE '{strToday}%' AND qrcode LIKE '%{qrCode}%'";

                bool bRead = false;
                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB.sqlite;Version=3;"))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;
                    while (bRead = rdr.Read())
                    {
                        string str1 = rdr["time"].ToString().Replace("T", " ");
                        string str2 = rdr["model"].ToString();
                        string str3 = rdr["qrcode"].ToString();
                        string str4 = rdr["insp_judge"].ToString();
                        string str5 = rdr["rms_judge"].ToString();
                        string str6 = rdr["master_img_path"].ToString();
                        string str7 = rdr["ng_img_path"].ToString();
                        string str8 = rdr["crop_img_path"].ToString();
                        string str9 = rdr["master_crop_img_path"].ToString();
                        string str10 = rdr["ng_part_code"].ToString();
                        string str11 = rdr["ng_reason"].ToString();
                        string str12 = rdr["ng_rect"].ToString();

                        list.Add(new string[] { str1, str2, str3, str4, str5, str6, str7, str8, str9, str10, str11, str12 });
                        nIndex++;
                    }
                }
            }
            catch /*(Exception e)*/
            {
                //MessageBox.Show(e.ToString());
                return list;
            }

            return list;
        }

        public List<string[]> SelectAll_Model(string strTable, string strModel = "ALL", string strCode = "")
        {
            List<string[]> list = new List<string[]>();
            try
            {
                string strQuery = $"SELECT * FROM {strTable}";

                if (!String.Equals(strModel, "ALL", StringComparison.OrdinalIgnoreCase))
                {
                    if (strQuery.Contains("WHERE"))
                    {
                        strQuery += $" AND model = '{strModel}'";
                    }
                    else
                    {
                        strQuery += $" WHERE model = '{strModel}'";
                    }
                }

                if (!String.Equals(strCode, "", StringComparison.OrdinalIgnoreCase))
                {
                    if (strQuery.Contains("WHERE"))
                    {
                        strQuery += $" AND code = '{strCode}'";
                    }
                    else
                    {
                        strQuery += $" WHERE code = '{strCode}'";
                    }
                }

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB_ALARM.sqlite;Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;
                    while (rdr.Read())
                    {
                        string str1 = rdr["time"].ToString().Replace("T", " ");
                        string str2 = rdr["code"].ToString();
                        string str3 = rdr["desc"].ToString();
                        string str4 = rdr["model"].ToString();
                        string str5 = rdr["tray_type"].ToString();
                        string str6 = rdr["barcode"].ToString();
                        string str7 = rdr["is_count"].ToString();
                        string str8 = rdr["position"].ToString();

                        list.Add(new string[] { nIndex.ToString(), str1, str2, str3, str4, str5, str6, str8 });
                        nIndex++;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return list;
            }

            return list;
        }

        public List<string[]> SelectAllLot_Model(string strModel = "ALL")
        {
            List<string[]> list = new List<string[]>();
            try
            {
                string strQuery = $"SELECT * FROM LOT";

                if (!String.Equals(strModel, "ALL", StringComparison.OrdinalIgnoreCase))
                {
                    if (strQuery.Contains("WHERE"))
                    {
                        strQuery += $" AND model = '{strModel}'";
                    }
                    else
                    {
                        strQuery += $" WHERE model = '{strModel}'";
                    }
                }

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\DB_LOT.sqlite;Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;
                    while (rdr.Read())
                    {
                        string str1 = rdr["time"].ToString().Replace("T", " ");
                        string str2 = rdr["jam_rate"].ToString() + $"({rdr["jam_count"].ToString()})";
                        string str3 = rdr["lot_no"].ToString();
                        string str4 = rdr["model"].ToString();
                        string str5 = rdr["device_count"].ToString();
                        string str6 = rdr["tray_count"].ToString();
                        string str7 = rdr["barcodes"].ToString();

                        list.Add(new string[] { nIndex.ToString(), str1, str2, str3, str4, str5, str6, str7 });
                        nIndex++;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return list;
            }

            return list;
        }

        public void Insert_Alarm(string strTable, string[] strFields, string[] strValues)
        {
            try
            {
                string strValue = "";
                string strField = "";

                for (int i = 0; i < strFields.Length; i++)
                {
                    if (i == strFields.Length - 1)
                    {
                        strField += strFields[i];
                    }
                    else
                    {
                        strField += strFields[i] + ",";
                    }
                }

                for (int i = 0; i < strValues.Length; i++)
                {
                    if (i == strValues.Length - 1)
                    {
                        strValue += strValues[i];
                    }
                    else
                    {
                        strValue += strValues[i] + ",";
                    }
                }

                string strQuery = $"INSERT INTO {strTable}({strField}) VALUES ({strValue})";
                Query("DB_ALARM", strQuery);

                //CLogger.Add(LOG_TYPE.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        public void Insert_FristInspection(string strTable, string[] strFields, string[] strValues)
        {
            try
            {
                string strValue = "";
                string strField = "";

                for (int i = 0; i < strFields.Length; i++)
                {
                    if (i == strFields.Length - 1)
                    {
                        strField += strFields[i];
                    }
                    else
                    {
                        strField += strFields[i] + ",";
                    }
                }

                for (int i = 0; i < strValues.Length; i++)
                {
                    if (i == strValues.Length - 1)
                    {
                        strValue += strValues[i];
                    }
                    else
                    {
                        strValue += strValues[i] + ",";
                    }
                }

                string strQuery = $"INSERT INTO {strTable}({strField}) VALUES ({strValue})";
                Query("DB_PBA", strQuery);

                //CLogger.Add(LOG_TYPE.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        public void Update(string strTable, string[] strValues, string strWhere)
        {
            try
            {
                string strValue = "";

                for (int i = 0; i < strValues.Length; i++)
                {
                    if (i == strValues.Length - 1)
                    {
                        strValue += strValues[i];
                    }
                    else
                    {
                        strValue += strValues[i] + ",";
                    }
                }

                string strQuery = $"UPDATE {strTable} SET {strValue} WHERE {strWhere}";
                Query("DB_PBA", strQuery);

                //CLogger.Add(LOG_TYPE.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        //public void UpdateOK(string strTable, string code)
        //public void UpdateOK(string strTable, string time, string part, string Reason, bool bAll)
        //{
        //    try
        //    {
        //        //string strQuery = $"UPDATE {strTable} SET rms_judge = 'OK' WHERE qrcode LIKE '%{code}%'";
        //        string strQuery = $"UPDATE {strTable} SET rms_judge = 'OK' WHERE ng_part_code LIKE '%{part}%' AND time LIKE '%{time}%'";
        //        Query("DB", strQuery);
        //        strQuery = $"UPDATE {strTable} SET ng_reason = '{Reason}' WHERE ng_part_code LIKE '%{part}%' AND time LIKE '%{time}%'";
        //        Query("DB", strQuery);

        //        CLogger.Add(LOG_TYPE.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
        //    }
        //}

        public void UpdateJudgeNReason(string strTable, string strJudge, bool isRMS, string time, string part, string Reason, bool bQRAll, string strQR, string strModel = "")
        {
            string strJudgeTarget = "";
            string strWhere = "";
            if (isRMS)
                strJudgeTarget = "rms_judge";
            else
                strJudgeTarget = "insp_judge";
            if (part.Length > 0)
                strWhere = $"WHERE ng_part_code LIKE '%{part}%' AND time LIKE '%{time}%'";
            else
                strWhere = $"WHERE time LIKE '%{time}%'";

            try
            {
                //string strQuery = $"UPDATE {strTable} SET rms_judge = 'NG' WHERE qrcode LIKE '%{code}%'";
                string strQuery = "";
                if (bQRAll == false)
                {
                    strQuery = $"UPDATE {strTable} SET {strJudgeTarget} = '{strJudge}' WHERE ng_part_code LIKE '%{part}%' AND time LIKE '%{time}%' AND qrcode LIKE '%{strQR}%'";
                    Query("DB", strQuery);
                    strQuery = $"UPDATE {strTable} SET ng_reason = '{Reason}' WHERE ng_part_code LIKE '%{part}%' AND time LIKE '%{time}%' AND qrcode LIKE '%{strQR}%'";
                    Query("DB", strQuery);
                }
                else if (bQRAll)
                {
                    strQuery = $"UPDATE {strTable} SET {strJudgeTarget} = '{strJudge}' WHERE qrcode LIKE '%{strQR}%'";
                    Query("DB", strQuery);
                    strQuery = $"UPDATE {strTable} SET ng_reason = '{Reason}' WHERE qrcode LIKE '%{strQR}%'";
                    Query("DB", strQuery);
                }
                else if (strModel.Length > 0)
                {
                    strQuery = $"UPDATE {strTable} SET {strJudgeTarget} = '{strJudge}' WHERE model LIKE '%{strModel}%' AND qrcode LIKE '%{strQR}%'";
                    Query("DB", strQuery);
                    strQuery = $"UPDATE {strTable} SET ng_reason = '{Reason}' WHERE model LIKE '%{strModel}%' AND qrcode LIKE '%{strQR}%'";
                    Query("DB", strQuery);
                }



                //CLogger.Add(LOG_TYPE.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        //public void UpdateNG(string strTable, string code)
        //public void UpdateNG(string strTable, string time, string part, string Reason, bool bAll)
        //{
        //    try
        //    {
        //        //string strQuery = $"UPDATE {strTable} SET rms_judge = 'NG' WHERE qrcode LIKE '%{code}%'";
        //        string strQuery = "";
        //        if (bAll)
        //        {
        //            strQuery = $"UPDATE {strTable} SET rms_judge = 'NG' WHERE ng_part_code LIKE '%{part}%' AND time LIKE '%{time}%'";
        //            Query("DB", strQuery);
        //            strQuery = $"UPDATE {strTable} SET ng_reason = '{Reason}' WHERE ng_part_code LIKE '%{part}%' AND time LIKE '%{time}%'";
        //            Query("DB", strQuery);
        //        }
        //        else
        //        {
        //            strQuery = $"UPDATE {strTable} SET rms_judge = 'NG' WHERE ng_part_code LIKE '%{part}%' AND time LIKE '%{time}%'";
        //            Query("DB", strQuery);
        //            strQuery = $"UPDATE {strTable} SET ng_reason = '{Reason}' WHERE ng_part_code LIKE '%{part}%' AND time LIKE '%{time}%'";
        //            Query("DB", strQuery);
        //        }

        //        CLogger.Add(LOG_TYPE.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
        //    }
        //}
        //public void UpdateReason(string strTable, string time, string part, string Reason)
        //{
        //    try
        //    {
        //        string strQuery = $"UPDATE {strTable} SET ng_reason = '{Reason}' WHERE ng_part_code LIKE '%{part}%' AND time LIKE '%{time}%'";
        //        Query("DB", strQuery);

        //        CLogger.Add(LOG_TYPE.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
        //    }
        //}

        public void DeleteAll(string strTable)
        {
            try
            {
                string strQuery = $"DELETE FROM {strTable}";
                Query("DB_ALARM", strQuery);

                //CLogger.Add(LOG_TYPE.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        public void Delete(string strTable, string strWhereCol, string strWhereValue)
        {
            try
            {
                string strQuery = $"DELETE FROM {strTable} WHERE {strWhereCol}='{strWhereValue}'";
                Query("DB_ALARM", strQuery);

                //CLogger.Add(LOG_TYPE.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        public void Query(string strPath, string strQuery)
        {
            try
            {
                if (string.IsNullOrEmpty(m_strConnectPath)) return;

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Global.m_MainPJTRoot}\\{strPath}.sqlite;Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                //CLogger.Add(LOG.DB, $"[QUERY] ==> {strQuery}");
                //CLogger.Add(LOG_TYPE.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}