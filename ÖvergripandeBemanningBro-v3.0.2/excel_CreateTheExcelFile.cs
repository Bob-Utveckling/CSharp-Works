using ÖvergripandeBemanningBro_v3._0._2.Model;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ÖvergripandeBemanningBro_v3._0._2

{
    public class excel_CreateTheExcelFile
    {
        public static Tuple<string, string, string> generate(
                        List<SchedItem> schedItems, 
                        List<Personnel> okPersonnel,
                        List<Note> notes,
                        string fileLocation,
                        string fileName,
                        string language)
        {

            //write commands to check schedItems once more now
            //because if language is "en", its "activity" should be in en. either transfer from sv to en, or leave as en if recognized that it is in en
            //but if the language is "sv", either change from en to sv, or leave as sv if recognized that it is sv

            string combinepath = fileLocation + "\\" + fileName;

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!");
            }
            createTheSheet_Arbetspass(schedItems, xlWorkbook, language);
            createTheSheet_Dagsanteckningar(xlWorkbook, notes, language);
            createTheSheet_Medlemmar(xlWorkbook, okPersonnel, language);

            try
            {
                xlWorkbook.SaveCopyAs(combinepath);
                //xlWorkbook.Close();
                //xlApp.Quit();
                return (Tuple.Create(
                    "ok",
                    "Sparade nya schemat till filen: " + combinepath + "\nNu kan du importera den till Microsoft Shifts/Arbetspass!",
                    combinepath));
            } catch (System.Runtime.InteropServices.COMException e)
            {
                MessageBox.Show(e.Message);
                return (Tuple.Create(
                    "not ok",
                    "Sparade 'inte' nya schemat till filen: " + combinepath ,
                    combinepath));

            }
        }

        public static void createTheSheet_Medlemmar(Excel.Workbook xlWorkbook, List<Personnel> okPersonnel, string language)
        {
            var xlWorksheet3 = xlWorkbook.Sheets.Add();
            switch (language)
            {
                case "sv":
                    xlWorksheet3.Name = "Medlemmar";
                    xlWorksheet3.Cells[1, 1] = "Namn";
                    xlWorksheet3.Cells[1, 2] = "E-post";
                    xlWorksheet3.Cells[1, 3] = "E-postalias";
                    break;
                case "en":
                    xlWorksheet3.Name = "Members";
                    xlWorksheet3.Cells[1, 1] = "Name";
                    xlWorksheet3.Cells[1, 2] = "Email";
                    xlWorksheet3.Cells[1, 3] = "Alias Email";
                    break;
            }

            /*old_Personnel p1 = new old_Personnel("Bob", "Lotfabadi", "bob.lotfabadi@ale.se", "bamlot001", "123");
            old_Personnel p2 = new old_Personnel("Mia", "Drottz", "mia.drottz@ale.se", "bamlot001", "123");
            List<old_Personnel> list1 = new List<old_Personnel>();
            list1.Add(p1);
            list1.Add(p2);*/

            for (int i=0; i<okPersonnel.Count; i++)
            {
                xlWorksheet3.Cells[i + 2, 1] = okPersonnel[i].FirstName + " " + okPersonnel[i].FirstName; //list1[i].FirstName;
                xlWorksheet3.Cells[i + 2, 2] = okPersonnel[i].Email; //list1[i].Email;
                xlWorksheet3.Cells[i + 2, 3] = okPersonnel[i].AleId; //list1[i].AleId;
            }
        }

        public static void createTheSheet_Dagsanteckningar(Excel.Workbook xlWorkbook, List<Note> notes, string language)
        {
            //wrong - this will create "Sheet2" then save the sheet1 ie arbetspass to Dagsanteckningar!
            //xlWorkbook.Sheets.Add();
            //var xlWorksheet2 = xlWorkbook.Sheets[2];

            var xlWorksheet2 = xlWorkbook.Sheets.Add();
            switch (language)
            {
                case "en":
                    xlWorksheet2.Name = "Day Notes";
                    xlWorksheet2.Cells[1, 1] = "Date";
                    xlWorksheet2.Cells[1, 2] = "Note";
                    break;
                case "sv":
                    xlWorksheet2.Name = "Dagsanteckningar";
                    xlWorksheet2.Cells[1, 1] = "Datum";
                    xlWorksheet2.Cells[1, 2] = "Anteckning";
                    break;
            }

            //if notes belong to same day, they should become one note
            //since Microsoft Shifts takes only one note for each date.
            //PROVIDE THIS SOLUTION:
            notes = SchedItem.returnCondensedNotes(notes);

            for (int iRecord = 0; iRecord < notes.Count; iRecord++)
            {
                xlWorksheet2.Cells[iRecord + 2, 1] = notes[iRecord].date;
                xlWorksheet2.Cells[iRecord + 2, 2] = notes[iRecord].note;

            }
        }
            public static void createTheSheet_Arbetspass(List<SchedItem>schedItems, Excel.Workbook xlWorkbook, string language)
        {
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            switch (language)
            {
                case "en":
                    xlWorksheet.Name = "Shifts";

                    xlWorksheet.Cells[1, 1] = "Member";
                    xlWorksheet.Cells[1, 2] = "Work Email";
                    xlWorksheet.Cells[1, 3] = "Group";
                    xlWorksheet.Cells[1, 4] = "Shift Start Date";
                    xlWorksheet.Cells[1, 5] = "Shift Start Time";
                    xlWorksheet.Cells[1, 6] = "Shift End Date";
                    xlWorksheet.Cells[1, 7] = "Shift End Time";
                    xlWorksheet.Cells[1, 8] = "Theme Color";
                    xlWorksheet.Cells[1, 9] = "Custom Label";
                    xlWorksheet.Cells[1, 10] = "Unpaid Break (minutes)";
                    xlWorksheet.Cells[1, 11] = "Notes";
                    xlWorksheet.Cells[1, 12] = "Shared";

                    break;
                case "sv":
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
                    break;
            }


            for (int iRecord = 0; iRecord < schedItems.Count; iRecord++)
            {
                xlWorksheet.Cells[iRecord + 2, 1] = schedItems[iRecord].memberName;
                xlWorksheet.Cells[iRecord + 2, 2] = schedItems[iRecord].emailId;
                xlWorksheet.Cells[iRecord + 2, 3] = schedItems[iRecord].activity;
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
