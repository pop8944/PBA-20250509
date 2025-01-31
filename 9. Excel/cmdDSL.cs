using IntelligentFactory.Excel;
using System.Collections.Generic;
using System.Xml;

namespace IntelligentFactory
{
    public class cmdDSL
    {
        public class SWDocStruct
        {
            public string name = "";
            public string summary = "";
            public List<string> paramList = new List<string>();
            public string rerValue = "";
        }

        public static void MSxmlDoc2MSExcel(string xmlFile, string excelFile, string refFile)
        {
            int maxParamList = 0;
            InteropExcel excelRef = new InteropExcel();
            excelRef.Open(refFile);
            InteropExcel excel = new InteropExcel();

            string LibName = "";
            List<SWDocStruct> swDocs = new List<SWDocStruct>();

            XmlDocument xdoc = new XmlDocument();

            // XML 데이타를 파일에서 로드
            xdoc.Load(xmlFile);

            // 특정 노드들을 필터링
            XmlNodeList nodes = xdoc.SelectNodes("/doc/assembly");
            //XmlNodeList nodes = xdoc.SelectNodes("/doc");

            foreach (XmlNode doc in nodes)
            {
                // 자식 노드들에 대해 Loop를 도는 예
                foreach (XmlNode child in doc.ChildNodes)
                {
                    string name = child.Name;
                    LibName = child.InnerText.Trim();
                    //Console.WriteLine("{0}: {1}", child.Name, child.InnerText);
                }
            }
            XmlNodeList nodes2 = xdoc.SelectNodes("/doc/members");
            foreach (XmlNode doc in nodes2)
            {
                // 자식 노드들에 대해 Loop를 도는 예
                foreach (XmlNode child in doc.ChildNodes)
                {
                    SWDocStruct swDoc = new SWDocStruct();
                    string inStr;
                    string name = child.Name;
                    if (name == "member")
                    {
                        inStr = child.OuterXml.ToString();
                        swDoc.name = Util.GetsBetweenItem(ref inStr, "=", ">", false, true);
                        foreach (XmlNode ch2 in child)
                        {
                            string name2 = ch2.Name;
                            if (name2 == "summary")
                                swDoc.summary = ch2.InnerText.Trim();
                            else if (name2 == "param")
                            {
                                inStr = ch2.OuterXml.ToString();
                                string param = Util.GetsBetweenItem(ref inStr, "=", "</", false, true);
                                swDoc.paramList.Add(param);
                                if (swDoc.paramList.Count > maxParamList)
                                    maxParamList = swDoc.paramList.Count;
                            }
                            else if (name2 == "returns")
                            {
                                swDoc.rerValue = ch2.InnerText.Trim();
                            }
                        }
                        swDocs.Add(swDoc);
                    }
                }
            }

            // 여기 Excel 양식을 넣는다.
            excel.AddSheet(LibName);
            // 진행변수 선언
            List<object> dataes = new List<object>();
            List<object> Formats = new List<object>();
            System.Drawing.Rectangle areas, areaCopy;

            // Reference 항목을 넣는다.
            dataes.Clear();
            dataes.Add("Name");
            dataes.Add("Summary");
            dataes.Add("retValue");
            for (int i = 0; i < maxParamList; i++)
                dataes.Add($"Param{i}");
            areas = new System.Drawing.Rectangle(1, 1, dataes.Count, 1);
            areaCopy = new System.Drawing.Rectangle(1, 1, maxParamList + 3, 1);
            excel.CopyCells(excelRef, 0, areaCopy, true);
            Formats.Clear();
            excel.AddDataes(0, dataes, Formats, areas, true);

            for (int i = 0; i < swDocs.Count; i++)
            {
                dataes.Clear();
                dataes.Add(swDocs[i].name);
                dataes.Add(swDocs[i].summary);
                dataes.Add(swDocs[i].rerValue);
                for (int j = 0; j < swDocs[i].paramList.Count; j++)
                    dataes.Add(swDocs[i].paramList[j]);
                areaCopy = new System.Drawing.Rectangle(1, 2 + i, maxParamList + 3, 1);
                areas = new System.Drawing.Rectangle(1, 2 + i, dataes.Count, 1);
                Formats.Clear();
                excel.CopyCells(excelRef, 0, areaCopy, true);
                Formats.Clear();
                excel.AddDataes(0, dataes, Formats, areas, true);
            }
            excel.Save(excelFile);
            excel.Close(excelFile);
            excelRef.Close(excelFile);
        }
    }
}