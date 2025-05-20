using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace IntelligentFactory
{
    public class MetaData
    {
        public string Model { get; set; } = "";
        public string Status { get; set; } = "";
        public string StopReason { get; set; } = "";
        public int TotalCount { get; set; } = 0;
        public int OKCount { get; set; } = 0;
        public int NGCount { get; set; } = 0;
        public double PerOK { get; set; } = 0;
        public long TackTime { get; set; } = 0;

        public bool getResult()
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }
        public MetaData LoadFromCSV()
        {
            string filePath = $"{Global.m_MainPJTRoot}\\Recent.csv";
            try
            {
                if (!File.Exists(filePath))
                {
                    // 如果不存在，保存当前对象到CSV
                    MetaData newData = new MetaData();
                    newData.SaveToCSV();
                    return newData;
                }
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    // 由于文件只包含一行数据，我们可以直接读取第一条记录
                    csv.Read();
                    var record = csv.GetRecord<MetaData>();
                    return record;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }
        public void SaveToCSV()
        {
            string filePath = $"{Global.m_MainPJTRoot}\\Recent.csv";
            try
            {
                // 不管文件是否存在，都设置append为false，这样每次都会覆盖原有文件
                bool append = false; // 修改这里

                using (var writer = new StreamWriter(filePath, append))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    // 写入CSV头部和当前对象数据
                    csv.WriteHeader<MetaData>();
                    csv.NextRecord();
                    csv.WriteRecord(this);
                    csv.NextRecord();
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
