//using ClosedXML.Excel;
using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanHungHa.Tabs.ManualTab;
using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO.Ports;
using TanHungHa.Tabs;
using DevExpress.Security;
using ZedGraph;
//using DocumentFormat.OpenXml.Drawing.Charts;

namespace TanHungHa.Common
{
    public class MyExcel
    {
        private static MyExcel _instance;
        private static readonly object _lock = new object();

        public static SpreadsheetControl spreadsheet;

        public IWorkbook wb;
        public Worksheet ws;

        public int Cols;
        public int Row;
        private int Mode;
        private string CellAdress;

        private string _filePath { get; set; }


        void EventChangeRow()
        {
            if (spreadsheet == null) return;
            wb = spreadsheet.Document;

            if (workSheet < wb.Worksheets.Count)
                ws = wb.Worksheets[workSheet];
            else
            {
                workSheet = 0;
                ws = wb.Worksheets[workSheet];
            }

            Cell cellTemp = ws.Cells[row, column];

            if (cellAdress != cellTemp.GetReferenceA1())
                cellAdress = cellTemp.GetReferenceA1();
        }

        void EventChangeColumn()
        {
            if (spreadsheet == null) return;
            wb = spreadsheet.Document;

            if (workSheet < wb.Worksheets.Count)
                ws = wb.Worksheets[workSheet];
            else
            {
                workSheet = 0;
                ws = wb.Worksheets[workSheet];
            }

            Cell cellTemp = ws.Cells[row, column];

            if (cellAdress != cellTemp.GetReferenceA1())
                cellAdress = cellTemp.GetReferenceA1();
        }

        void EventChangeCell()
        {

            if (spreadsheet == null) return;
            wb = spreadsheet.Document;

            if (workSheet < wb.Worksheets.Count)
                ws = wb.Worksheets[workSheet];
            else
            {
                workSheet = 0;
                ws = wb.Worksheets[workSheet];
            }


            Cell cellTemp = ws.Cells[cellAdress];
            if (row != ws.Cells[cellAdress].RowIndex)
                row = ws.Cells[cellAdress].RowIndex;

            if (column != ws.Cells[cellAdress].ColumnIndex)
                column = ws.Cells[cellAdress].ColumnIndex;
        }
       

        public static MyExcel GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MyExcel();
                    }
                }
            }
            return _instance;
        }

        public void SetSpreadSheet(SpreadsheetControl spr)
        {
            spreadsheet = spr;
        }

        char[] columnName = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        [Category("Main"), DescriptionAttribute("Index của sheet cần ghi data bắt đầu từ 0")]
        public int workSheet { get; set; }

        public int mode
        {
            get { return Mode; }
            set
            {
                if (Mode != value && value > 0 && value <= 4)
                {
                    Mode = value;
                  
                }
            }
        }

        public string cellAdress
        {
            get { return CellAdress; }
            set
            {
                if (CellAdress != value)
                {
                    if (value == null || (value.Length == 2 && value.Contains("0"))) return;
                    CellAdress = value;
                  
                }
                EventChangeCell();
            }
        }
       
        private int row
        {
            get { return Row; }
            set
            {
                if (Row != value)
                {
                    Row = value;
                    
                }
            }
        }

        private int column
        {
            get { return Cols; }
            set
            {
                if (Cols != value)
                {
                    Cols = value;
                   
                }
            }
        }

        [Category("Main"), DescriptionAttribute("Đường dẫn đến file excel cần ghi data")]
        public string filePath
        {
            get { return _filePath; }
            set
            {
                if (value == _filePath)
                    return;
                _filePath = value;
                if (!File.Exists(_filePath))
                {
                    MyLib.ShowInfo($"{_filePath} not exists!");
                }
                else
                {
                    MyLib.ShowInfo($"{_filePath} OK!", "Notify");
                }
            }
        }

        MyExcel()
        {
            filePath = "Kefico.xlsx";
            workSheet = 0;
            column = 1;
            row = 2;
            cellAdress = "D2";
            mode = 1;
        }

        public enum dataType
        {
            STRING,
            DOUBLE
        }

        public string getCurCellAdress()
        {
            cellAdress = string.Format($"{columnName[column]}{row}");
            return cellAdress;
        }

        public string getNextCellAdress()
        {
            var nextRow = row + 1;
            return string.Format($"{columnName[column]}{nextRow}");
        }

        public string setNextRowAdress()
        {
            row++;
            wb = spreadsheet.Document;

            if (workSheet < wb.Worksheets.Count)
                ws = wb.Worksheets[workSheet];
            else
            {
                workSheet = 0;
                ws = wb.Worksheets[workSheet];
            }

            Cell cellTemp = ws.Cells[row, column];

            cellAdress = cellTemp.GetReferenceA1();


            return cellAdress;
        }
        public string setNextColAdress()
        {
            column++;
            wb = spreadsheet.Document;

            if (workSheet < wb.Worksheets.Count)
                ws = wb.Worksheets[workSheet];
            else
            {
                workSheet = 0;
                ws = wb.Worksheets[workSheet];
            }

            Cell cellTemp = ws.Cells[row, column];

            cellAdress = cellTemp.GetReferenceA1();

            return cellAdress;
        }

        public string setNextCellAdress(int iMode)
        {
            int maxRows = spreadsheet.ActiveWorksheet.GetUsedRange().RowCount;
            int maxColumns = spreadsheet.ActiveWorksheet.GetUsedRange().ColumnCount;
            switch (iMode)
            {
                case 1:  //Up
                    if (row > 0)
                        row--;
                    break;

                case 2: //Down
                    if (row < maxRows)
                        row++;
                    break;

                case 3: // Left
                    if (column > 0 )
                        column--;
                    break;

                case 4: // Right
                    if (column < maxColumns)
                        column++;
                    break;

            }

            wb = spreadsheet.Document;

            if (workSheet < wb.Worksheets.Count)
                ws = wb.Worksheets[workSheet];
            else
            {
                workSheet = 0;
                ws = wb.Worksheets[workSheet];
            }

            Cell cellTemp = ws.Cells[row, column];

            cellAdress = cellTemp.GetReferenceA1();

            return cellAdress;

        }
        public string SetFirstRow()
        {
            wb = spreadsheet.Document;

            if (workSheet < wb.Worksheets.Count)
                ws = wb.Worksheets[workSheet];
            else
            {
                workSheet = 0;
                ws = wb.Worksheets[workSheet];
            }

            CellRange usedRange = ws.GetUsedRange();

            // Kiểm tra từng hàng trong vùng dữ liệu đã sử dụng
            for (int rowIndex = 0; rowIndex < usedRange.RowCount; rowIndex++)
            {
                {
                    if (ws.Cells[rowIndex, 3].Value.IsEmpty)
                    {
                        row = rowIndex;
                        break;
                    }
                }

            }
            Cell cellTemp = ws.Cells[row, column];

            cellAdress = cellTemp.GetReferenceA1();

            return cellAdress;
        }

        public void scrollView(int Row_)
        {
            wb = spreadsheet.Document;
            if (workSheet < wb.Worksheets.Count)
                ws = wb.Worksheets[workSheet];
            else
            {
                workSheet = 0;
                ws = wb.Worksheets[workSheet];
            }

            int lastVisibleRowIndex = spreadsheet.VisibleRange.BottomRowIndex - 1;
            int targetRowIndex = lastVisibleRowIndex - 3;
            if (Row_ == lastVisibleRowIndex)
            {
                spreadsheet.ActiveWorksheet.ScrollToRow(targetRowIndex);
            }
        }

        #region excel with devExpress

        void UpdateSpreadSheet(string cell, double data, string mode = "Save")
        {
            wb = spreadsheet.Document;

            if (workSheet < wb.Worksheets.Count)
                ws = wb.Worksheets[workSheet];
            else
            {
                workSheet = 0;
                ws = wb.Worksheets[workSheet];
            }


            if (spreadsheet.InvokeRequired)
            {
                spreadsheet.Invoke(new Action(() =>
                {
                    int row, col;
                    row = ws.Cells[cell].RowIndex;
                    col = ws.Cells[cell].ColumnIndex;
                    scrollView(row);
                    DateTime now = DateTime.Now;
                    string Date = now.ToString("dd/MM/yyyy");
                    string Time = now.ToString("HH:mm:ss:ff");
                    ws.Cells[row, 1].Value = Date;
                    ws.Cells[row, 2].Value = Time;
                    ws.Cells[cell].Value = data;
                    ws.Cells[row, 1].AutoFitColumns();
                    ws.Cells[row, 2].AutoFitColumns();
                    ws.Cells[cell].AutoFitColumns();                  
                    ws.SelectedCell = ws.Cells[cell];


                    wb.Worksheets.ActiveWorksheet = ws;
                    spreadsheet.SelectedCell = ws.Cells[cell];
  
                    if (col > 10)
                    {
                        spreadsheet.ActiveWorksheet.ScrollTo(ws.Cells[cell].RowIndex - 5, ws.Cells[cell].ColumnIndex);
                    }

                }));

                if (mode == "Save")
                {
                    
                    wb.SaveDocument(filePath);
                    
                }
            }
            else
            {
                int row, col;

                row = ws.Cells[cell].RowIndex;
                col = ws.Cells[cell].ColumnIndex;

                scrollView(row);
                DateTime now = DateTime.Now;
                string Date = now.ToString("dd/MM/yyyy");
                string Time = now.ToString("HH:mm:ss:ff");
                ws.Cells[row, 1].Value = Date;
                ws.Cells[row, 2].Value = Time;
                ws.Cells[cell].Value = data;
                ws.Cells[row, 1].AutoFitColumns();
                ws.Cells[row, 2].AutoFitColumns();
                ws.Cells[cell].AutoFitColumns();
                ws.SelectedCell = ws.Cells[cell];

                wb.Worksheets.ActiveWorksheet = ws;
                spreadsheet.SelectedCell = ws.Cells[cell];
                
                if (col > 10)
                {
                    spreadsheet.ActiveWorksheet.ScrollTo(ws.Cells[cell].RowIndex - 5, ws.Cells[cell].ColumnIndex);
                }

                if (mode == "Save")
                {
                    
                    wb.SaveDocument(filePath);
                    
                }
            }
        }

        void UpdateSpreadSheet(string cell, string data, string mode = "Save")
        {
            wb = spreadsheet.Document;

            if (workSheet < wb.Worksheets.Count)
                ws = wb.Worksheets[workSheet];
            else
            {
                workSheet = 0;
                ws = wb.Worksheets[workSheet];
            }


            if (spreadsheet.InvokeRequired)
            {
                spreadsheet.Invoke(new Action(() =>
                {
                    int row, col;

                    row = ws.Cells[cell].RowIndex;
                    col = ws.Cells[cell].ColumnIndex;

                    scrollView(row);
                    DateTime now = DateTime.Now;
                    string Date = now.ToString("dd/MM/yyyy");
                    string Time = now.ToString("HH:mm:ss:ff");
                    ws.Cells[row, 1].Value = Date;
                    ws.Cells[row, 2].Value = Time;
                    ws.Cells[cell].Value = data;
                    ws.Cells[row, 1].AutoFitColumns();
                    ws.Cells[row, 2].AutoFitColumns();
                    ws.Cells[cell].AutoFitColumns();
                    ws.SelectedCell = ws.Cells[cell];

                    wb.Worksheets.ActiveWorksheet = ws;
                    spreadsheet.SelectedCell = ws.Cells[cell];


                    if (row > 10)
                    {
                        spreadsheet.ActiveWorksheet.ScrollTo(ws.Cells[cell].RowIndex - 7, 0);
                    }

                }));

                if (mode == "Save")
                {
                    
                    wb.SaveDocument(filePath);
                    
                }
            }
            else
            {
                int lastRow = ws.GetUsedRange().BottomRowIndex + 1;
                int row, col;

                row = ws.Cells[cell].RowIndex;
                col = ws.Cells[cell].ColumnIndex;
                scrollView(row);
                DateTime now = DateTime.Now;
                string Date = now.ToString("dd/MM/yyyy");
                string Time = now.ToString("HH:mm:ss:ff");
                ws.Cells[row, 1].Value = Date;
                ws.Cells[row, 2].Value = Time;
                ws.Cells[cell].Value = data;
                ws.Cells[row, 1].AutoFitColumns();
                ws.Cells[row, 2].AutoFitColumns();
                ws.Cells[cell].AutoFitColumns();
                ws.Cells[cell].Value = data;
                ws.SelectedCell = ws.Cells[cell];

                wb.Worksheets.ActiveWorksheet = ws;
                spreadsheet.SelectedCell = ws.Cells[cell];

                if (col > 10)
                {
                    spreadsheet.ActiveWorksheet.ScrollTo(ws.Cells[cell].RowIndex - 5, ws.Cells[cell].ColumnIndex);
                }

                if (mode == "Save")
                {
                    
                    wb.SaveDocument(filePath);
                    
                }
            }
        }

        public string readCell(string cell)
        {
            if (spreadsheet == null) return "NULL";

            return ws.Cells[cell].Value.ToString();
        }

        public void writeCell(string cell, string data, dataType dtType = dataType.STRING)
        {
            if (spreadsheet == null) return;
            switch (dtType)
            {
                case dataType.DOUBLE:
                    UpdateSpreadSheet(cell, double.Parse(data));
                    break;
                default:
                    UpdateSpreadSheet(cell, data);
                    break;
            }
        }

        public void writeCellSequence(string data, dataType dtType = dataType.STRING)
        {

            //string cell = cellAdress;
            string cell = SetFirstRow();
            //var cell = spreadsheet.ActiveCell.GetReferenceA1() ;

            switch (dtType)
            {
                case dataType.DOUBLE:
                    UpdateSpreadSheet(cell, double.Parse(data));
                    break;
                default:
                    UpdateSpreadSheet(cell, data);
                    break;
            }

            cellAdress = setNextRowAdress();
        }

        public bool openExcell()
        {
            if (spreadsheet == null) return false;
            try 
            {
                spreadsheet.LoadDocument(filePath);
                return true;
            }
            catch { return false; }
            
        }
        #endregion

    }
}
