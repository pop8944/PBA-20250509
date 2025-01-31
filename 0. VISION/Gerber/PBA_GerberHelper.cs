using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OfficeOpenXml;

namespace IntelligentFactory
{
    public static class PBA_GerberHelper
    {
        public static List<PBA_GerberInfo> GetGerberInfo(string filePath)
        {
            List<PBA_GerberInfo> gerberInfo = new List<PBA_GerberInfo>(); 

            FileInfo fileInfo = new FileInfo(filePath);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; 

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"]; // 첫 번째 시트 선택


                int rowCount = worksheet.Dimension.Rows; // 전체 행 개수

                // 데이터 파싱 (2행부터 시작)
                for (int row = 2; row <= rowCount; row++)
                {
                    PBA_GerberInfo data = new PBA_GerberInfo
                    {
                        LocationNo = worksheet.Cells[row, 2].Text, // B 열 (2번 컬럼)
                        PosX = worksheet.Cells[row, 3].Text, // C 열 (3번 컬럼)
                        PosY = worksheet.Cells[row, 4].Text, // D 열 (4번 컬럼)
                        PosAngle = worksheet.Cells[row, 5].Text, // E 열 (5번 컬럼)
                        ArrayIndex = int.Parse(worksheet.Cells[row, 6].Text), // H 열 (8번 컬럼)
                        PartCode = worksheet.Cells[row, 8].Text, // H 열 (8번 컬럼)
                        Enabled = bool.Parse(worksheet.Cells[row, 12].Text) // L 열 (12번 컬럼)
                    };

                    gerberInfo.Add(data);
                }
            }

            return gerberInfo;
        }
    }
}
