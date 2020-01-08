using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ClosedXML.Excel;
using System.Data;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            //getexcelfile();
            GetDataTabletFromCSVFile();
        }

        public static void getexcelfile()
        {
          
        }

        public static void  GetDataTabletFromCSVFile()
        {
            using (XLWorkbook workBook = new XLWorkbook(@"C:/Import/ProductTypes.xlsx"))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Create a new DataTable.
              System.Data.DataTable dt = new System.Data.DataTable();

                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        //Add rows to DataTable.
                        dt.Rows.Add();
                        int i = 0;
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
                        }
                    }
                }
            }
        }
    }
}
