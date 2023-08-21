using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ÖvergripandeBemanningBro_v3._0._2.Model;

namespace ÖvergripandeBemanningBro_v3._0._2
{
    public class excel_ReadTheCsvFileAndPrepareToCreateTheExcelFile
    {
        public static Tuple<List<DateTime>,List<Personnel>,List<Personnel>, List<SchedItem>, List<SchedItem>, List<Note>> prepare(string fromFile, ToolStripStatusLabel toolStripStatusLabel1, ToolStripProgressBar toolStripProgressBar)
        {
            toolStripStatusLabel1.Text = "Filen läses...";    
            List<DateTime> datesInTheFile = new List<DateTime>();
            List<SchedItem> okSchedItems = new List<SchedItem>();
            List<SchedItem> notOkSchedItems = new List<SchedItem>();

            List<string> listOfEnheter = new List<string>();
            listOfEnheter.Add("Björklövsvägen");
            listOfEnheter.Add("Surtehöjd");
            listOfEnheter.Add("Klöverstigen");
            listOfEnheter.Add("Björklövsvägen NATT");
            listOfEnheter.Add("Klöverstigen NATT");
            listOfEnheter.Add("Jour bilaga J");

            List<string> listOfNightShiftTypes = new List<string>();
            listOfNightShiftTypes.Add("Björklövsvägen NATT");
            listOfNightShiftTypes.Add("Klöverstigen NATT");
            listOfNightShiftTypes.Add("Jour bilaga J"); //not really used. has its own function
            
            List<Note> notes = new List<Note>();

            var file = File.ReadAllLines(fromFile);
            int fileLength = file.Length;

            toolStripProgressBar.Minimum = 0;
            toolStripProgressBar.Maximum = 100;

            //MessageBox.Show("fileLength: " + fileLength);
            using (var reader = new StreamReader(fromFile))
            {
                int i = 0;
                while(!reader.EndOfStream)
                {
                    //###########   making following 4 lines appear in every ReadLine
                    i++;
                    int percentageComplete = (int)((i / (double)fileLength) * 100);
                    if (percentageComplete>100) { percentageComplete = 100; } //a hack to avoid error in toolStripProgressBar value being more than 100??
                    toolStripProgressBar.Value = percentageComplete;
                    //MessageBox.Show("i: " + i + ", %: " + percentageComplete.ToString());


                    var line = reader.ReadLine();


                    //start finding the new date
                    if (line=="\"")
                    {
                        //this next line is a space, the next holds the date detail
                        var spaceLine = reader.ReadLine();
                        //now comes the date line, i.e.:
                        //                    Onsdag, 2023-07-19                ";;;;;;;;;
                        var thisDateDetail = reader.ReadLine();


                        //###########   making following 4 lines appear in every ReadLine
                        i++;
                        percentageComplete = (int)((i / (double)fileLength) * 100);
                        toolStripProgressBar.Value = percentageComplete;
                        //MessageBox.Show("i: " + i + ", %: " + percentageComplete.ToString());



                        var indexOfAfterComma = thisDateDetail.IndexOf(",")+1;
                        var indexOfQuote = thisDateDetail.IndexOf("\"");
                        int numChars = indexOfQuote - indexOfAfterComma;
                        thisDateDetail = thisDateDetail.Substring(indexOfAfterComma, numChars).Trim();
                        datesInTheFile.Add(DateTime.Parse(thisDateDetail));
                        //start the scanning for the schedule:
                        bool shouldLoopForThisDate = true;
                        //now comes about 7 to 10 lines, the 8th of which is the beginning of a set of "Schematid"s
                        while(shouldLoopForThisDate)
                        {
                            //###########   making following 4 lines appear in every ReadLine
                            i++;
                            percentageComplete = (int)((i / (double)fileLength) * 100);
                            toolStripProgressBar.Value = percentageComplete;
                            //MessageBox.Show("i: " + i + ", %: " + percentageComplete.ToString());


                            line = reader.ReadLine();
                            if (line == "Schematid;;;;;;;;;") //this in the file, means a set of schedule items will now start from the next line
                            {
                                bool okToReadSched = true;
                                var headerLine = reader.ReadLine();
                                // Förnamn; Efternamn; Signatur; Från; Till; Aktivitet; Rast; Passtid; Uppgifter; Anteckning
                                
                                List<string> schedLines = new List<string>();
                                var possibleSchedLine = "";
                                
                                while (okToReadSched) //this means we are in, in a list of sched items line by line that is being read
                                {

                                    //###########   making following 4 lines appear in every ReadLine
                                    i++;
                                    percentageComplete = (int)((i / (double)fileLength) * 100);
                                    toolStripProgressBar.Value = percentageComplete;
                                    //MessageBox.Show("i: " + i + ", %: " + percentageComplete.ToString());


                                    var considerPreviousLine = possibleSchedLine; //this is needed for JourBilaga recognition since the line depends on the previous line. See next lines for its use.
                                    possibleSchedLine = reader.ReadLine()!; //You can use the "Null forgiving operator" at the end of Your line. (the exclamation mark), in order to remove the warning. https://stackoverflow.com/questions/59306751/why-does-this-code-give-a-possible-null-reference-return-compiler-warning
                                    if (possibleSchedLine != ";;;;;;;;;") //because it is the end line for this date
                                    {
                                        // Bob; Lotfabadi; Surte; 08:00; 16:30; Surtehöjd;30; 08:00; ; 
                                        // Bobby; Sommarvikarie3; Klö; 07:30; 15:00; Klöverstigen; 30; 07:00; ;
                                        // Bob; Lotf; B; 06:55; 11:55; Björklövsvägen;0; 05:00; ; 
                                        // etc.
                                        //should extract from possibleSchedLine
                                        //call the right constructor
                                        //schedItems.Add(new SchedItem(possibleSchedLine));

                                        string possibleFirstNameInSched = possibleSchedLine.Split(';')[0].Trim();
                                        string possibleLastNameInSched = possibleSchedLine.Split(';')[1].Trim();
                                        //MessageBox.Show("possible first name: " + possibleFirstNameInSched + ", last name: " + possibleLastNameInSched);
                                        string possibleAleId = Personnel.getMemberAleIdIfInDatabase(possibleFirstNameInSched, possibleLastNameInSched);
                                        if (SchedItem.isThePossibleSchedLineJourBilagaJ(possibleSchedLine))
                                        {
                                            notes.Add(new Note(thisDateDetail, SchedItem.createANighJourBilagaDetail(possibleSchedLine, considerPreviousLine)));
                                            //add as a note and not as a sched line but need the previous line's person since it is him/her who has the Jour Bilaga J
                                        } else
                                        {
                                            if (possibleAleId != "NA")
                                            {
                                                if (SchedItem.isThePossibleSchedLineCleanAndWhatWeWant(listOfEnheter, possibleSchedLine))
                                                {
                                                    if (SchedItem.isThePossibleSchedLineANightShift(listOfNightShiftTypes, possibleSchedLine))
                                                    {
                                                        notes.Add(new Note(thisDateDetail, SchedItem.createANightShiftDetail(possibleSchedLine)));
                                                    } else
                                                    {
                                                        okSchedItems.Add(SchedItem.createSchedItemFromString(possibleSchedLine, possibleAleId, thisDateDetail));
                                                    }
                                                }
                                                else
                                                {
                                                    notOkSchedItems.Add(SchedItem.createSchedItemFromString(possibleSchedLine, possibleAleId, thisDateDetail));
                                                }
                                            }
                                            else
                                            {
                                                notOkSchedItems.Add(SchedItem.createSchedItemFromString(possibleSchedLine, possibleAleId, thisDateDetail));
                                                notOkSchedItems = notOkSchedItems.OrderBy(o => o.activity).ToList();
                                            }

                                        }

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
                } //while loop of every single line in the file
            } //the using statement
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Visible = false;

            //MessageBox.Show($"Det finns {okSchedItems.Count} stycken arbetspass på din fil.");
            for (int i=0; i<okSchedItems.Count; i++)
            {
                //MessageBox.Show(i + ": " + schedItems[i].toString());
            }
            //formToInteract needs the following data

            //List<Personnel> okListsOfPersonnelInSchedItems = new List<Personnel>();
            //okListsOfPersonnelInSchedItems.Add(new Personnel("Bob", "L", "bob@ale.se"));
            List<Personnel> okListsOfPersonnelInSchedItems = SchedItem.collectDistinctPersonnelFromSchedItemsWithoutContactingDatabase(okSchedItems);
            
            //notOkListsOfPersonnelInSchedItems.Add(new Personnel("Absent1", "absi", "NA"));
            //SchedItem.collectDistinctPersonnelFromSchedItems(notOkSchedItems);
            List<Personnel> notOkListsOfPersonnelInSchedItems = SchedItem.collectDistinctNotOkPersonnelFromSchedItems(notOkSchedItems);

            return (Tuple.Create(
                        datesInTheFile,
                        //listsOfPersonnelInSchedItems.Item1,
                        okListsOfPersonnelInSchedItems,
                        //listsOfPersonnelInSchedItems.Item2,
                        notOkListsOfPersonnelInSchedItems,
                        okSchedItems,
                        notOkSchedItems,
                        notes)
                    );

        }
    }

}

