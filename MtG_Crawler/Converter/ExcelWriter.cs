using MtG_Crawler.Data;
using MtG_Crawler.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace MtG_Crawler.Converter
{
    public class ExcelWriter
    {
        private const int COLUMN_INDEX_NAME = 1;
        private const int COLUMN_INDEX_TRANSLATION = 2;
        private const int COLUMN_INDEX_COLLECTORSNUMBER = 3;
        private const int COLUMN_INDEX_PRICE = 4;

        private const int FIRST_COLUMN_INDEX = 1;
        private const int LAST_COLUMN_INDEX = 4;

        private const string COLLECTORSNUMBER_FORMAT = "@";
        private const string PRICE_FORMAT = "#.##0,00 €";

        public void Write(string filepath, params CardSet[] data)
        {
            if (data == null || data.Length <= 0)
                return;

            Excel.Application app = new Excel.Application();
            app.Visible = false;

            Excel.Workbook workbook = GetWorkbookAndDeleteIfExists(filepath, app);
            ClearWorkbook(workbook);

            while (workbook.Sheets.Count < data.Length)
                workbook.Sheets.Add();

            workbook.Sheets[1].Name = data[0].Name;
            WriteCardSet(workbook.Sheets[1], data[0]);

            int worksheetIndex;
            for (int index = 1; index < data.Length; ++index)
            {
                worksheetIndex = index + 1;
                workbook.Sheets[worksheetIndex].Name = data[index].Name;
                WriteCardSet(workbook.Sheets[worksheetIndex], data[index]);
            }

            workbook.Save();
            workbook.Close();
            app.Quit();
        }

        private Excel.Workbook GetWorkbookAndDeleteIfExists(string filepath, Excel.Application app)
        {
            string directory = Path.GetDirectoryName(filepath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (File.Exists(filepath))
                File.Delete(filepath);

            Excel.Workbook workbook = app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            workbook.SaveAs(filepath);
            return workbook;
        }

        private void ClearWorkbook(Excel.Workbook workbook)
        {
            if (workbook.Sheets.Count > 0)
            {
                workbook.Sheets[1].Cells.Clear();
                while (workbook.Sheets.Count > 1)
                    workbook.Sheets[1].Delete();
            }
        }

        private void WriteCardSet(Excel.Worksheet sheet, CardSet set)
        {
            sheet.Cells[1, 1] = string.Format("Set: {0}", set.Name.ToUpper());
            sheet.Range[sheet.Cells[1, FIRST_COLUMN_INDEX], sheet.Cells[1, LAST_COLUMN_INDEX]].Merge();
            sheet.Rows[1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            sheet.Cells[2, 1] = set.GetSetOverview();
            sheet.Range[sheet.Cells[2, FIRST_COLUMN_INDEX], sheet.Cells[2, LAST_COLUMN_INDEX]].Merge();
            sheet.Rows[2].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            int currentRow = 4;
            foreach (string rarity in set.GetDistinctRarities())
            {
                sheet.Cells[currentRow, 1] = rarity;
                sheet.Range[sheet.Cells[currentRow, FIRST_COLUMN_INDEX], sheet.Cells[currentRow, LAST_COLUMN_INDEX]].Merge();
                sheet.Rows[currentRow].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ++currentRow;

                foreach (Card card in set.GetCards().Where(card => string.Equals(card.Rarity, rarity)))
                {
                    sheet.Cells[currentRow, COLUMN_INDEX_NAME] = card.Name;
                    sheet.Cells[currentRow, COLUMN_INDEX_TRANSLATION] = card.GermanTranslation;

                    sheet.Cells[currentRow, COLUMN_INDEX_COLLECTORSNUMBER].NumberFormat = COLLECTORSNUMBER_FORMAT;
                    sheet.Cells[currentRow, COLUMN_INDEX_COLLECTORSNUMBER].Value = card.CollectorsNumber;

                    sheet.Cells[currentRow, COLUMN_INDEX_PRICE].NumberFormat = PRICE_FORMAT;
                    sheet.Cells[currentRow, COLUMN_INDEX_PRICE].Value = card.Price;
                    ++currentRow;
                }

                ++currentRow;
            }

            FormatSheet(sheet);
        }

        private void FormatSheet(Excel.Worksheet sheet)
        {
            int lastColumn = sheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column;

            for (int index = 1; index <= lastColumn; ++index)
            {
                sheet.Columns[index].AutoFit();
                sheet.Columns[index].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                if (index == COLUMN_INDEX_COLLECTORSNUMBER || index == COLUMN_INDEX_PRICE)
                    sheet.Columns[index].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }
        }
    }
}
