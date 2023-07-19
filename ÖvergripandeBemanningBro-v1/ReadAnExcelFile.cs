using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ÖvergripandeBemanningBro_v1
{
    public class ReadAnExcelFile
    {
        public static void createTheFile(string fileName)
        {
            //doesn't work:
            //Form1 form = new Form1();
            //form.updateLabel("Förbereder Excel fil...");
            
            MessageBox.Show("Read Excel File");
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fileName);
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;


            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!

            int rowCount = 3;
            //int colCount = xlWorksheet.Columns.Count;
            int colCount = 3;
            MessageBox.Show("rowCount=" + rowCount + ", colCount=" + colCount);
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    //new line
                    if (j == 1)
                        //Console.Write("\r\n");
                        MessageBox.Show("New Row");
                    //write the value to the console
                    if (xlRange.Cells[i, j] != null & xlRange.Cells[i, j].Value2 != null)
                        //Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
                        MessageBox.Show(xlRange.Cells[i, j].Value2.ToString() + "\t");

                    //add useful things here!
                }
            }

        }
    }
}
