using System;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace AgreementOpener.Utils
{
    public class ExcelFormer
    {
		public DataTable Data { get; }
		public string FileName { get; }

		public ExcelFormer(DataTable data, string fileName)
		{
			Data = data;
			FileName = fileName;
		}

		public void ToExcel()
        {
			var excelApp = new Excel.Application();
			excelApp.Workbooks.Add();
			Excel._Worksheet workSheet = excelApp.ActiveSheet;
			for (var i = 0; i < Data.Columns.Count; i++)
			{
				workSheet.Cells[1, i + 1] = Data.Columns[i].ColumnName;
			}
			for (var i = 0; i < Data.Rows.Count; i++)
			{
				// to do: format datetime values before printing
				for (var j = 0; j < Data.Columns.Count; j++)
				{
					workSheet.Cells[i + 2, j + 1] = Data.Rows[i][j];
				}
			}
			try
			{
				workSheet.SaveAs(FileName);
				excelApp.Quit();
			}
			catch (Exception ex)
			{
				throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
									+ ex.Message);
			}
		}
    }
}
