using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ÖvergripandeBemanningBro_v1
{
    public class ReadTheCsvFileAndPrepareToCreateTheExcelFile
    {
        public static SchedItem createSchedItemFromString(string possibleSchedItemString, string dateDetail)
        {
            string firstName = possibleSchedItemString.Split(';')[0];
            string lastName = possibleSchedItemString.Split(';')[1];
            string signature = possibleSchedItemString.Split(';')[2];
            string from = possibleSchedItemString.Split(';')[3];
            string to = possibleSchedItemString.Split(';')[4];
            string activity = possibleSchedItemString.Split(';')[5];
            string off = possibleSchedItemString.Split(';')[6];
            string shiftHours = possibleSchedItemString.Split(';')[7];
            string tasks = possibleSchedItemString.Split(';')[8];
            string note = possibleSchedItemString.Split(';')[9];
            return new SchedItem(firstName, lastName, activity, dateDetail, from, to, off, note);
                    
        }
        public static void prepare(string fromFile)
        {
            
            List<SchedItem> schedItems = new List<SchedItem>();
            using (var reader = new StreamReader(fromFile))
            {
                int i = 0;
                while(!reader.EndOfStream)
                {
                    i++;
                    var line = reader.ReadLine();
                    //start finding the new date
                    if (line=="\"")
                    {
                        //this next line is a space, the next holds the date detail
                        var spaceLine = reader.ReadLine();
                        //now comes the date line, i.e.:
                        //                    Onsdag, 2023-07-19                ";;;;;;;;;
                        var dateDetail = reader.ReadLine();
                        var indexOfAfterComma = dateDetail.IndexOf(",")+1;
                        var indexOfQuote = dateDetail.IndexOf("\"");
                        int numChars = indexOfQuote - indexOfAfterComma;
                        dateDetail = dateDetail.Substring(indexOfAfterComma, numChars).Trim();

                        //start the scanning for the schedule:
                        bool shouldLoopForThisDate = true;
                        while(shouldLoopForThisDate)
                        {
                            line = reader.ReadLine();
                            if (line == "Schematid;;;;;;;;;")
                            {
                                bool okToReadSched = true;
                                var headerLine = reader.ReadLine(); // Förnamn; Efternamn; Signatur; Från; Till; Aktivitet; Rast; Passtid; Uppgifter; Anteckning
                                List<string> schedLines = new List<string>();
                                var possibleSchedLine = "";
                                
                                while (okToReadSched)
                                {
                                    possibleSchedLine = reader.ReadLine()!; //You can use the "Null forgiving operator" at the end of Your line. (the exclamation mark), in order to remove the warning. https://stackoverflow.com/questions/59306751/why-does-this-code-give-a-possible-null-reference-return-compiler-warning
                                    if (possibleSchedLine != ";;;;;;;;;")
                                    {
                                        //should extract from possibleSchedLine
                                        //call the right constructor
                                        //schedItems.Add(new SchedItem(possibleSchedLine));
                                        schedItems.Add(createSchedItemFromString(possibleSchedLine,dateDetail));


                                    }
                                    else
                                    {
                                        //has reached the end of the schedule for this date
                                        okToReadSched = false;
                                        shouldLoopForThisDate = false;
                                    }

                                }
                            }
                        }
                    }
                    //var values = line.Split(';');
                    //MessageBox.Show(i+", "+", line:" + line+ ", value 1: " + values[0]);
                    //if (i==10) { break; }
                }
            }

            MessageBox.Show($"There are {schedItems.Count} sched items");
            for (int i=0; i<schedItems.Count; i++)
            {
                MessageBox.Show(schedItems[i].toString());
            }
            //formToInteract
            CreateTheExcelFile.generate(schedItems);

        }
    }

}

