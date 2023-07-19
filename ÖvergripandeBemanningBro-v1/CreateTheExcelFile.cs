using ClosedXML.Excel;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ÖvergripandeBemanningBro_v1
{
    public class CreateTheExcelFile
    {
        public static void generate(List<SchedItem> schedItems)
        {
            string filePath = "c:\\temp\\";
            string fileName = "bob7.xlsx";
            string combinepath = filePath + fileName;

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!");
            }
            createTheSheet_Arbetspass(schedItems, xlWorkbook);
            createTheSheet_Dagsanteckningar(xlWorkbook);
            createTheSheet_Medlemmar(xlWorkbook);

            xlWorkbook.SaveCopyAs(combinepath);
            //xlWorkbook.Close();
            //xlApp.Quit();

        }

        public static void createTheSheet_Medlemmar(Excel.Workbook xlWorkbook)
        {
            var xlWorksheet3 = xlWorkbook.Sheets.Add();
            xlWorksheet3.Name = "Medlemmar";
            xlWorksheet3.Cells[1, 1] = "Namn";
            xlWorksheet3.Cells[1, 2] = "E-post";
            xlWorksheet3.Cells[1, 3] = "E-postalias";

            Personnel p1 = new Personnel("Bob", "bob.lotfabadi@ale.se", "bamlot001");
            Personnel p2 = new Personnel("Mia", "mia.drottz@ale.se", "bamlot001");
            List<Personnel> list1 = new List<Personnel>();
            list1.Add(p1);
            list1.Add(p2);

            for (int i=0; i<list1.Count; i++)
            {
                xlWorksheet3.Cells[i + 2, 1] = list1[i].Name;
                xlWorksheet3.Cells[i + 2, 2] = list1[i].Email;
                xlWorksheet3.Cells[i + 2, 3] = list1[i].EmailAlias;
            }
        }

        public static void createTheSheet_Dagsanteckningar(Excel.Workbook xlWorkbook)
        {
            //wrong - this will create "Sheet2" then save the sheet1 ie arbetspass to Dagsanteckningar!
            //xlWorkbook.Sheets.Add();
            //var xlWorksheet2 = xlWorkbook.Sheets[2];

            var xlWorksheet2 = xlWorkbook.Sheets.Add();
            xlWorksheet2.Name = "Dagsanteckningar";
            xlWorksheet2.Cells[1, 1] = "Datum";
            xlWorksheet2.Cells[1, 2] = "Anteckning";
        }
        public static void createTheSheet_Arbetspass(List<SchedItem>schedItems, Excel.Workbook xlWorkbook)
        {
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];

            xlWorksheet.Name = "Arbetspass";

            xlWorksheet.Cells[1, 1] = "Medlem";
            xlWorksheet.Cells[1, 2] = "E-postadress, arbete";
            xlWorksheet.Cells[1, 3] = "Grupp";
            xlWorksheet.Cells[1, 4] = "Startdatum för arbetspass";
            xlWorksheet.Cells[1, 5] = "Starttid för arbetspass";
            xlWorksheet.Cells[1, 6] = "Slutdatum för arbetspass";
            xlWorksheet.Cells[1, 7] = "Sluttid för arbetspass";
            xlWorksheet.Cells[1, 8] = "Temafärg";
            xlWorksheet.Cells[1, 9] = "Anpassad etikett";
            xlWorksheet.Cells[1, 10] = "Obetald rast (minuter)";
            xlWorksheet.Cells[1, 11] = "Anteckningar";
            xlWorksheet.Cells[1, 12] = "Delat";

            for (int iRecord = 0; iRecord < schedItems.Count; iRecord++)
            {
                xlWorksheet.Cells[iRecord + 2, 1] = schedItems[iRecord].memberName;
                xlWorksheet.Cells[iRecord + 2, 2] = schedItems[iRecord].emailId;
                xlWorksheet.Cells[iRecord + 2, 3] = schedItems[iRecord].groupName;
                xlWorksheet.Cells[iRecord + 2, 4] = schedItems[iRecord].dateFrom;
                xlWorksheet.Cells[iRecord + 2, 5] = schedItems[iRecord].timeFrom;
                xlWorksheet.Cells[iRecord + 2, 6] = schedItems[iRecord].dateTo;
                xlWorksheet.Cells[iRecord + 2, 7] = schedItems[iRecord].timeTo;
                xlWorksheet.Cells[iRecord + 2, 8] = schedItems[iRecord].themeColor;
                xlWorksheet.Cells[iRecord + 2, 9] = schedItems[iRecord].etikett;
                xlWorksheet.Cells[iRecord + 2, 10] = schedItems[iRecord].off;
                xlWorksheet.Cells[iRecord + 2, 11] = schedItems[iRecord].note;
                xlWorksheet.Cells[iRecord + 2, 12] = schedItems[iRecord].shared;
            }
        }
    }
}
