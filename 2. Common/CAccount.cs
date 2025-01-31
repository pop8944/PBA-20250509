//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Windows.Forms;
//using System.Xml;

//namespace IntelligentFactory
//{
//    public class CAccountManager
//    {
//        public Dictionary<string, CAccount> Accounts = new Dictionary<string, CAccount>();

//        public CAccountManager()
//        {
//        }

//        #region CONFIG BY XML

//        private string m_XMLName = "ACCOUNT";

//        public bool LoadConfig()
//        {
//            try
//            {
//                string strPath = $"{IGlobal.m_MainPJTRoot}\\CONFIG\\ACCOUNT\\" + m_XMLName + ".xml";

//                if (File.Exists(strPath))
//                {
//                    XmlTextReader xmlReader = new XmlTextReader(strPath);

//                    try
//                    {
//                        Accounts.Clear();

//                        CAccount account1 = new CAccount();
//                        account1.ID = "IF";
//                        account1.PASSWORD = "0001";
//                        account1.AUTHORIZATION = "MASTER";

//                        CAccount account2 = new CAccount();
//                        account2.ID = "CNI";
//                        account2.PASSWORD = "0001";
//                        account2.AUTHORIZATION = "MASTER";

//                        Accounts.Add(account1.ID, account1);
//                        Accounts.Add(account2.ID, account2);

//                        while (xmlReader.Read())
//                        {
//                            if (xmlReader.NodeType == XmlNodeType.Element)
//                            {
//                                switch (xmlReader.Name)
//                                {
//                                    case "ACCOUNT_INFO":
//                                        if (xmlReader.Read())
//                                        {
//                                            string strAccountInfo = xmlReader.Value;
//                                            string[] strSplit1 = strAccountInfo.Split(';');

//                                            for (int i = 0; i < strSplit1.Length; i++)
//                                            {
//                                                string[] strSplit2 = strSplit1[i].Split(',');

//                                                if (strSplit2.Length == 3)
//                                                {
//                                                    CAccount account = new CAccount();
//                                                    account.ID = strSplit2[0];
//                                                    account.PASSWORD = strSplit2[1];
//                                                    account.AUTHORIZATION = strSplit2[2];

//                                                    Accounts.Add(account.ID, account);
//                                                }
//                                            }
//                                        }
//                                        break;
//                                }
//                            }
//                            else
//                            {
//                                if (xmlReader.NodeType == XmlNodeType.EndElement)
//                                {
//                                    if (xmlReader.Name == m_XMLName) break;
//                                }
//                            }
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1} Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
//                        xmlReader.Close();
//                    }

//                    xmlReader.Close();
//                }
//                else
//                {
//                    SaveConfig();
//                    return false;
//                }
//            }
//            catch (Exception ex)
//            {
//                CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1} Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
//                return false;
//            }
//            return true;
//        }

//        public bool SaveConfig()
//        {
//            CUtil.InitDirectory("CONFIG");
//            CUtil.InitDirectory("CONFIG\\ACCOUNT\\");

//            string strPath = $"{IGlobal.m_MainPJTRoot}\\CONFIG\\ACCOUNT\\" + m_XMLName + ".xml";

//            XmlWriterSettings settings = new XmlWriterSettings();
//            settings.Indent = true;
//            settings.NewLineOnAttributes = true;
//            settings.IndentChars = "\t";
//            settings.NewLineChars = "\r\n";
//            XmlWriter xmlWriter = XmlWriter.Create(strPath, settings);
//            try
//            {
//                xmlWriter.WriteStartDocument();
//                xmlWriter.WriteStartElement("PROPERTY");

//                string strAccountInfo = "";
//                for (int i = 0; i < Accounts.Count; i++)
//                {
//                    CAccount account = Accounts.ElementAt(i).Value;
//                    strAccountInfo += $"{account.ID},{account.PASSWORD},{account.AUTHORIZATION};";
//                }

//                xmlWriter.WriteElementString("ACCOUNT_INFO", strAccountInfo);

//                xmlWriter.WriteEndElement();
//                xmlWriter.WriteEndDocument();
//            }
//            catch (Exception ex)
//            {
//                CLogger.Add(LOG_TYPE.ABNORMAL, "[FAILED] {0}==>{1} Ex ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
//            }
//            finally
//            {
//                xmlWriter.Flush();
//                xmlWriter.Close();
//            }

//            return true;
//        }

//        #endregion CONFIG BY XML
//    }

//    public class CAccount
//    {
//        public string ID { get; set; } = "";
//        public string PASSWORD { get; set; } = "";
//        public string AUTHORIZATION { get; set; } = "OPERATOR";

//        public CAccount()
//        {
//        }
//    }
//}