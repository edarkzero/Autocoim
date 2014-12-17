using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Autocoim
{
    class ExcelTransform
    {
        private string path;
        Application _excelApp;

        public ExcelTransform()
        {
            _excelApp = new Application();
            path = "";
        }

        public ExcelTransform(string path)
        {
            _excelApp = new Application();
        }

        public string getExcelArray(string path)
        {
            this.path = path;

            try
            {
                Workbook workBook = _excelApp.Workbooks.Open(path,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
                ExcelScanIntenal(workBook);
                workBook.Close(false, path, null);
                Marshal.ReleaseComObject(workBook);
            }

            catch
            {
                System.Console.WriteLine("Can't open the file");
            }

            /*string result;
            FileManager fileManager = new FileManager(path);
            result = System.IO.File.ReadAllText(path);
            System.Console.WriteLine("Contents of file = {0}", result);
            return result;*/
            return "R";
        }

        private void ExcelScanIntenal(Workbook workBookIn)
        {
            int numSheets = workBookIn.Sheets.Count;

            //
            // Iterate through the sheets. They are indexed starting at 1.
            //
            for (int sheetNum = 1; sheetNum < numSheets + 1; sheetNum++)
            {
                Worksheet sheet = (Worksheet)workBookIn.Sheets[sheetNum];
                Range excelRange = sheet.UsedRange;
                object[,] valueArray = (object[,])excelRange.get_Value(
                    XlRangeValueDataType.xlRangeValueDefault);

                ProcessObjects(valueArray,sheet.Name);
            }
        }

        private void ProcessObjects(object[,] valueArray,string sheetName)
        {
            Voucher voucher = new Voucher(sheetName);

            // Get upper bounds for the array.
            int n = valueArray.GetUpperBound(0);
            int m = valueArray.GetUpperBound(1);

            // Use for-loops to iterate over the array elements.
            // Begins on i = 2 because we want to ignore de 1st row (column name)
            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    switch(j)
                    {
                        case 1:
                            voucher.RazonSocial = (string)valueArray[i, j];
                            break;
                        case 2:
                            voucher.VendorDocNum = (string)valueArray[i, j];
                            break;
                        case 3:
                            voucher.txtField = (string)valueArray[i, j];
                            break;
                        case 4:
                            voucher.DocNum = (string)valueArray[i, j];
                            break;
                        case 10:
                            voucher.taxDetPerc = (double)valueArray[i, j];
                            break;
                        case 12:
                            voucher.documentDate = (DateTime)valueArray[i, j];
                            break;
                        case 14:
                            voucher.postingDate = (DateTime)valueArray[i, j];
                            break;
                        case 15:
                            voucher.taxAmount = (double)valueArray[i, j];
                            break;
                        case 17:
                            voucher.taxableAmount = (double)valueArray[i, j];
                            break;
                    }

                    /*
                    if ((j >= 1 & j <= 3) | j == 10 | j == 12 | j == 14 | j == 15 | j == 17)
                    {
                        System.Type type = valueArray[i, j].GetType();

                        if (type == typeof(string))
                        {
                            string value = (string)valueArray[i, j];
                            Console.WriteLine(value);
                        }
                        else if(type == typeof(DateTime))
                        {
                            DateTime value = (DateTime)valueArray[i, j];
                            Console.WriteLine(value.ToShortDateString());
                        }
                        else if (type == typeof(double))
                        {
                            double value = (double)valueArray[i, j];
                            Console.WriteLine(value);
                        }
                    }*/
                }
            }

            voucher.print();
        }
    }
}
