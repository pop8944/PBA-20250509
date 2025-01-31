using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace IntelligentFactory.Excel
{
    /// <summary>
    /// Excel Manage Tool
    /// </summary>
    public class InteropExcel
    {
        //public void toDocuments(string path)
        //{
        //    BinaryFormatter binFmt = new BinaryFormatter();
        //    using (FileStream fs = new FileStream(path, FileMode.Create))
        //    {
        //        binFmt.Serialize(fs, this);
        //    }
        //}

        //public bool ToXmlFile(string path)
        //{
        //    try
        //    {
        //        string PrjPath = System.Environment.GetEnvironmentVariable("ProjectDir");
        //        string subPath = this.GetType().FullName;

        //        using (Stream savestream = new FileStream(path, FileMode.Create))
        //        {
        //            XmlSerializer writer = new XmlSerializer(this.GetType());
        //            writer.Serialize(savestream, this);

        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return false;
        //}

        /// <summary>
        /// Excel Application
        /// </summary>
        private Microsoft.Office.Interop.Excel.Application excelApp = null;

        private Workbook excelWB = null;
        private List<Worksheet> excelWSs = new List<Worksheet>();

        public InteropExcel()
        {
            excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelWB = excelApp.Workbooks.Add();
        }

        /// <summary>
        /// Sheet를 추가한다.
        /// </summary>
        /// <param name="Title">Sheet이름</param>
        public void AddSheet(string Title)
        {
            Worksheet ws = null;
            if (excelWSs.Count > 0)
                ws = excelWB.Worksheets.Add(After: excelWSs[excelWSs.Count - 1]);
            else
                ws = excelWB.Worksheets.Add();
            ws.Name = Title;
            excelWSs.Add(ws);
        }

        // 영역의 수와 Object의 수가 같지 않으면 예외로 리턴
        // formats의 수는 0이거나 영역의 수와 같아야 실행가능
        /// <summary>
        /// Sheet에 데이터 그룹을 넣는다.
        /// </summary>
        /// <param name="sheetNo">Sheet번호</param>
        /// <param name="objects">데이터들</param>
        /// <param name="numFormats">숫자포맷들</param>
        /// <param name="rect">영역(Rect)</param>
        /// <param name="isHorizontal">좌우방향여부</param>
        /// <returns>성공여부</returns>
        public bool AddDataes(int sheetNo, List<object> objects, List<object> numFormats, System.Drawing.Rectangle rect, bool isHorizontal = true)
        {
            if (excelWSs.Count <= sheetNo)
                return false;

            if (rect.Width * rect.Height != objects.Count)
                return false;
            if (numFormats.Count > 0 && rect.Width * rect.Height != numFormats.Count)
                return false;

            int itemIndex = 0;

            System.Drawing.Point pt = new System.Drawing.Point();

            if (isHorizontal)
            {
                for (int y = rect.Y; y < rect.Y + rect.Height; y++)
                {
                    for (int x = rect.X; x < rect.X + rect.Width; x++)
                    {
                        pt = new System.Drawing.Point(x, y);
                        object numFormat = null;
                        if (numFormats.Count > 0)
                            numFormat = numFormats[itemIndex];
                        AddData(sheetNo, objects[itemIndex++], numFormat, pt);
                    }
                }
            }
            else
            {
                for (int x = rect.X; x < rect.X + rect.Width; x++)
                {
                    for (int y = rect.Y; y < rect.Y + rect.Height; y++)
                    {
                        pt = new System.Drawing.Point(x, y);
                        object numFormat = null;
                        if (numFormats.Count > 0)
                            numFormat = numFormats[itemIndex];
                        AddData(sheetNo, objects[itemIndex++], numFormat, pt);
                    }
                }
            }

            return true;
        }

        public bool AddData(int sheetNo, object _object, int x, int y)
        {
            if (excelWSs.Count <= sheetNo)
                return false;

            Range cell = GetCell(sheetNo, new System.Drawing.Point(x, y));
            cell.Value = _object;
            return true;
        }

        public bool AddData(int sheetNo, object _object, object numFormat, System.Drawing.Point pt)
        {
            if (excelWSs.Count <= sheetNo)
                return false;

            Range cell = GetCell(sheetNo, pt);
            cell.Value = _object;
            if (numFormat != null)
                cell.NumberFormat = numFormat;
            return true;
        }

        public bool AddChart(int sheetNo, System.Drawing.Rectangle rect, XlChartType chartType, object _Title, object _xTitle, object _yTitle)
        {
            if (excelWSs.Count <= sheetNo)
                return false;
            Worksheet ws = excelWSs[sheetNo];

            //Add chart.
            Chart charts = null;
            if (excelWSs.Count > 0)
                charts = excelWB.Charts.Add(Before: excelWSs[0]);
            else
                charts = excelWB.Charts.Add();

            //var charts = excelWB.Charts.Add();
            // Set chart range.
            Microsoft.Office.Interop.Excel.Range topLeft = ws.Cells[rect.Y, rect.X];
            Microsoft.Office.Interop.Excel.Range bottomRight = ws.Cells[rect.Bottom, rect.Right];
            var range = ws.get_Range(topLeft, bottomRight);
            charts.SetSourceData(range);

            // Set chart properties.
            //charts.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLine;
            charts.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xl3DColumnClustered;
            charts.ChartWizard(Source: range,
                Title: _Title,
                CategoryTitle: _xTitle,
                ValueTitle: _yTitle);
            return true;
        }

        public bool AddHyperLink(int sheetNo, string path, object Name, System.Drawing.Point pt)
        {
            if (excelWSs.Count <= sheetNo)
                return false;
            Worksheet ws = excelWSs[sheetNo];
            Range cell = GetCell(sheetNo, pt);

            ws.Hyperlinks.Add(cell, path, Type.Missing, Name, Name);
            return true;
        }

        public bool DataValidation(int sheetNo, object _formula, System.Drawing.Point pt)
        {
            if (excelWSs.Count <= sheetNo)
                return false;
            Range cell = GetCell(sheetNo, pt);

            cell.Validation.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertInformation, XlFormatConditionOperator.xlBetween, _formula, null);
            return true;
        }

        public Range GetCell(int sheetNo, System.Drawing.Point pt)
        {
            Worksheet ws = excelWSs[sheetNo];

            Range cell = ws.Cells[pt.Y, pt.X];
            return cell;
        }

        public object GetCellValue(int sheetNo, System.Drawing.Point pt)
        {
            return GetCell(sheetNo, pt).Value;
        }

        public object GetCellValue(int sheetNo, int x, int y)
        {
            return GetCell(sheetNo, new System.Drawing.Point(x, y)).Value;
        }

        public string GetSheetName(int sheetNo)
        {
            return excelWSs[sheetNo].Name;
        }

        public int GetSheetNo(string sheetName)
        {
            int retNo = -1;
            for (int i = 0; i < excelWSs.Count; i++)
            {
                if (sheetName == excelWSs[i].Name)
                    retNo = i;
            }
            return retNo;
        }

        public void Save(string fileName)
        {
            if (!System.IO.File.Exists(fileName)) excelWB.SaveCopyAs(fileName);
            else excelWB.Save();
        }

        public void Open(string fileName)
        {
            excelWB = excelApp.Workbooks.Open(fileName);
            for (int i = 1; i < excelWB.Worksheets.Count + 1; i++)
            {
                excelWSs.Add(excelWB.Worksheets[i]);
            }
        }

        public bool CopyCell(InteropExcel source, int sheetNo, System.Drawing.Point pt)
        {
            if (excelWSs.Count <= sheetNo)
                return false;

            Range cell = GetCell(sheetNo, pt);

            Range sourceCell = source.GetCell(sheetNo, pt);
            //cell = sourceCell;
            cell.Value = sourceCell.Value;
            cell.NumberFormat = sourceCell.NumberFormat;
            cell.Interior.Color = sourceCell.Interior.Color;
            cell.Borders.LineStyle = sourceCell.Borders.LineStyle;
            cell.Font.Color = sourceCell.Font.Color;
            excelWSs[sheetNo].Columns.AutoFit();
            excelWSs[sheetNo].Rows.AutoFit();
            return true;
        }

        public bool CopyCells(InteropExcel source, int sheetNo, System.Drawing.Rectangle rect, bool isHorizontal = true)
        {
            if (excelWSs.Count <= sheetNo)
                return false;

            System.Drawing.Point pt = new System.Drawing.Point();

            if (isHorizontal)
            {
                for (int y = rect.Y; y < rect.Y + rect.Height; y++)
                {
                    for (int x = rect.X; x < rect.X + rect.Width; x++)
                    {
                        pt = new System.Drawing.Point(x, y);
                        CopyCell(source, sheetNo, pt);
                    }
                }
            }
            else
            {
                for (int x = rect.X; x < rect.X + rect.Width; x++)
                {
                    for (int y = rect.Y; y < rect.Y + rect.Height; y++)
                    {
                        pt = new System.Drawing.Point(x, y);
                        CopyCell(source, sheetNo, pt);
                    }
                }
            }
            return true; ;
        }

        public void Close(string _path)
        {
            excelWB.Close(false, _path);
            excelApp.Quit();
        }

        public void ReleaseExcel()
        {
            for (int i = 0; i < excelWSs.Count; i++)
            {
                ReleaseExcelObject(excelWSs[i]);
            }
            ReleaseExcelObject(excelWB);
            ReleaseExcelObject(excelApp);
        }

        //public void Close(string path)
        //{
        //    excelWB.Close(path);
        //    excelApp.Quit();
        //}

        private void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}