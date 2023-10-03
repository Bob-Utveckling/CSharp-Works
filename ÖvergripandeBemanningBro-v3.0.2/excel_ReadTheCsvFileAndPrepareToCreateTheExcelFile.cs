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
        public static Tuple<List<DateTime>,List<Personnel>,List<Personnel>, List<SchedItem>, List<SchedItem>, List<Note>, List<Note>> prepare(string fromFile, ToolStripStatusLabel toolStripStatusLabel1, ToolStripProgressBar toolStripProgressBar)
        {
            toolStripStatusLabel1.Text = "Läser filen...";    
            List<DateTime> datesInTheFile = new List<DateTime>();
            List<SchedItem> okSchedItems = new List<SchedItem>();
            List<SchedItem> notOkSchedItems = new List<SchedItem>();
            
            List<Note> notes = new List<Note>();
            List<Note> unclearNotes = new List<Note>();

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
                        if (percentageComplete>100) { percentageComplete = 100; } //a hack to avoid error in toolStripProgressBar value being more than 100??
                        toolStripProgressBar.Value = percentageComplete;
                        //MessageBox.Show("i: " + i + ", %: " + percentageComplete.ToString());



                        var indexOfAfterComma = thisDateDetail.IndexOf(",")+1;
                        var indexOfQuote = thisDateDetail.IndexOf("\"");
                        int numChars = indexOfQuote - indexOfAfterComma;
                        thisDateDetail = thisDateDetail.Substring(indexOfAfterComma, numChars).Trim();
                        if (thisDateDetail.IndexOf(",")>0)
                        {
                            //if comma found we should still process the date detail
                            MessageBox.Show("date was: " + thisDateDetail);
                            var thisDateDetailCommaFoundIndex = thisDateDetail.IndexOf(",");
                            thisDateDetail = thisDateDetail.Substring(0, thisDateDetailCommaFoundIndex).Trim();
                            MessageBox.Show("date now is: " + thisDateDetail);
                        }
                        //ok MessageBox.Show("I have date: " + thisDateDetail);
                        datesInTheFile.Add(DateTime.Parse(thisDateDetail));
                        //start the scanning for the schedule:
                        bool shouldLoopForThisDate = true;
                        //now comes about 7 to 10 lines, the 8th of which is the beginning of a set of "Schematid"s
                        while(shouldLoopForThisDate)
                        {
                            //###########   making following 4 lines appear in every ReadLine
                            i++;
                            percentageComplete = (int)((i / (double)fileLength) * 100);
                            if (percentageComplete>100) { percentageComplete = 100; } //a hack to avoid error in toolStripProgressBar value being more than 100??
                            toolStripProgressBar.Value = percentageComplete;
                            //MessageBox.Show("i: " + i + ", %: " + percentageComplete.ToString());


                            line = reader.ReadLine();
                            if (line == "Schematid;;;;;;;;;" || line == "\"Schematid\"") //this in the file, means a set of schedule items will now start from the next line
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
                                    if (percentageComplete>100) { percentageComplete = 100; } //a hack to avoid error in toolStripProgressBar value being more than 100??
                                    toolStripProgressBar.Value = percentageComplete;
                                    //MessageBox.Show("i: " + i + ", %: " + percentageComplete.ToString());


                                    var considerPreviousLine = possibleSchedLine; //this is needed for JourBilaga recognition since the line depends on the previous line. See next lines for its use.
                                    possibleSchedLine = reader.ReadLine()!; //You can use the "Null forgiving operator" at the end of Your line. (the exclamation mark), in order to remove the warning. https://stackoverflow.com/questions/59306751/why-does-this-code-give-a-possible-null-reference-return-compiler-warning
                                    
                                    //MessageBox.Show("possibleSchedLine: " + possibleSchedLine);
                                    //err -- doesn't read ""?   if (possibleSchedLine != ";;;;;;;;;" || possibleSchedLine != "\"\"") //because it is the end line for this date
                                    
                                    if (possibleSchedLine != "\"\"") //because it is the end line for this date
                                    {
                                        // Bob; Lotfabadi; Surte; 08:00; 16:30; Surtehöjd;30; 08:00; ; 
                                        // Bobby; Sommarvikarie3; Klö; 07:30; 15:00; Klöverstigen; 30; 07:00; ;
                                        // Bob; Lotf; B; 06:55; 11:55; Björklövsvägen;0; 05:00; ; 
                                        // etc.
                                        //should extract from possibleSchedLine
                                        //call the right constructor
                                        //schedItems.Add(new SchedItem(possibleSchedLine));

                                        string possibleFirstNameInSched = possibleSchedLine.Split(';')[0].Replace("\"", "").Trim();
                                        string possibleLastNameInSched = possibleSchedLine.Split(';')[1].Replace("\"", "").Trim();
                                        //MessageBox.Show("for AleId, possible first name: " + possibleFirstNameInSched + ", last name: " + possibleLastNameInSched);
                                        string possibleAleId = Personnel.getMemberAleIdIfInDatabase(possibleFirstNameInSched, possibleLastNameInSched);


                                        if (SchedItem.isThePossibleSchedLineJourBilagaJ(possibleSchedLine))
                                        {
                                            //the previous line should have a valid personal AleId:
                                            possibleAleId = SchedItem.getTheJourBilagaAleId(considerPreviousLine);
                                            if (possibleAleId != "NA")
                                            {
                                                //as note: notes.Add(new Note(thisDateDetail, SchedItem.createNoteOfANighJourBilagaDetail(possibleSchedLine, considerPreviousLine)));
                                                okSchedItems.Add(SchedItem.createSchedItemOfANighJourBilagaDetail(possibleSchedLine, possibleAleId, thisDateDetail, considerPreviousLine));
                                            } else
                                            {
                                                //add jour bilaga as a note
                                                //The Jour Bilaga has an AleId that is NA meaning the person is not in database, meaning he is probably a vikarie and should be added as a note
                                                notes.Add(new Note(thisDateDetail, SchedItem.createNoteOfANighJourBilagaDetail(possibleSchedLine, considerPreviousLine)));
                                            }
                                        } else if (SchedItem.isThePossibleSchedLineForAnActivityEnhetThatWeWant(possibleSchedLine))
                                        {
                                            if (possibleAleId != "NA")
                                            {
                                                /* not needed, added as usual sched line:
                                                if (SchedItem.isThePossibleSchedLineANightShift(listOfNightShiftTypes, possibleSchedLine))
                                                {
                                                    notes.Add(new Note(thisDateDetail, SchedItem.createANightShiftDetail(possibleSchedLine)));
                                                } else
                                                {*/
                                                //MessageBox.Show("adding as ok");
                                                okSchedItems.Add(SchedItem.createSchedItemFromString(possibleSchedLine, possibleAleId, thisDateDetail));
                                            } else
                                            {
                                                if (SchedItem.isThePossibleSchedLineUnclearInFirstNameAndLastName(possibleSchedLine))
                                                {
                                                    unclearNotes.Add(new Note(thisDateDetail, SchedItem.createNote(possibleSchedLine)));
                                                } else
                                                {
                                                    notes.Add(new Note(thisDateDetail, SchedItem.createNote(possibleSchedLine)));
                                                }

                                            }
                                        } else if (SchedItem.isThereAStarAlongSideASignatureThatMakesThisSchedLineOk(possibleSchedLine)) {                                            
                                            okSchedItems.Add(SchedItem.createSchedItemFromString(possibleSchedLine, possibleAleId, thisDateDetail, "yes"));
                                        }
                                        else if (SchedItem.canWeStillMakeSenseOfThePossibleSchedLineActivityAndSignatureInOrderToAddItAsUnclearNote(possibleSchedLine))
                                        {
                                            unclearNotes.Add(new Note(thisDateDetail, SchedItem.createNote(possibleSchedLine)));
                                        }
                                        else
                                        {
                                            //MessageBox.Show("adding as NOT ok. AleId NA");

                                            notOkSchedItems.Add(SchedItem.createSchedItemFromString(possibleSchedLine, possibleAleId, thisDateDetail));
                                            notOkSchedItems = notOkSchedItems.OrderBy(o => o.activity).ToList();
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
                        } i = 0;
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
                        notes,
                        unclearNotes)
                    );

        }
    }

}

