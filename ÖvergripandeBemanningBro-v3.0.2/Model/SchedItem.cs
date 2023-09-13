using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ÖvergripandeBemanningBro_v3._0._2.Model;
using System.Threading.Tasks;

namespace ÖvergripandeBemanningBro_v3._0._2

{
    public class SchedItem
    {
        [DisplayName("Member Name")]
        public string memberName {  get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }

        [DisplayName("Email ID")]
        public string emailId { get; set; }
        public string signature { get; set; }

        [DisplayName("Activity")]
        public string activity { get; set; }
        [DisplayName("Date From")]
        public string dateFrom { get; set; }
        [DisplayName("Time From")]
        public string timeFrom { get; set; }
        [DisplayName("Date To")]
        public string dateTo { get; set; }
        [DisplayName("Time To")]
        public string timeTo { get; set; }
        [DisplayName("Theme Color")]
        public string themeColor { get; set; }
        [DisplayName("Etikett")]
        public string etikett { get; set; }
        [DisplayName("Rast (Off)")]
        public string off { get; set; }
        [DisplayName("Notes (Anteckningar)")]
        public string note { get; set; }
        [DisplayName("Shared")]
        public string shared { get; set; }

        public SchedItem (string firstName, string lastName, string signature, string possibleAleId, string activity, string dateFrom, string timeFrom, string dateTo, string timeTo, string off, string note)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.memberName = firstName + " " + lastName;
            this.emailId = possibleAleId; //getEmailIdFor(firstName, lastName);
            this.signature = signature;
            this.activity = activity;
            this.dateFrom = dateFrom;
            this.timeFrom = timeFrom;
            this.dateTo = dateTo;
            this.timeTo = timeTo;
            this.themeColor = getThemeColorFor(activity, "sv");
            this.etikett = "";
            this.off = off;
            this.note = note;
            this.shared = "1. Delat";
        }

        //used for recognizing and making tomorrow's date for these types of activities
        public static List<string> returnListOfNightShiftTypes()
        {
            List<string> listOfNightShiftTypes = new List<string>();
            listOfNightShiftTypes.Add("Björklövsvägen NATT");
            listOfNightShiftTypes.Add("Klöverstigen NATT");
            listOfNightShiftTypes.Add("Jour bilaga J");
            return listOfNightShiftTypes;
        }

        public static List<string> returnListOfActivityEnheter()
        {
            List<string> listOfEnheter = new List<string>();
            listOfEnheter.Add("Björklövsvägen");
            listOfEnheter.Add("Surtehöjd");
            listOfEnheter.Add("Klöverstigen");
            listOfEnheter.Add("Björklövsvägen NATT");
            listOfEnheter.Add("Klöverstigen NATT");
            //listOfEnheter.Add("Jour bilaga J"); //treated separately
            return listOfEnheter;
        }

        public static Dictionary<string,HashSet<string>> returnEnhetWithAnyOfTheseSignatures()
        {
            Dictionary<string, HashSet<string>> enhetWithAnyOfTheseSignatures = new Dictionary<string, HashSet<string>>();
            enhetWithAnyOfTheseSignatures.Add("Björklövsvägen", new HashSet<string> { "B" });
            enhetWithAnyOfTheseSignatures.Add("Björklövsvägen NATT", new HashSet<string> { "BN" });
            enhetWithAnyOfTheseSignatures.Add("Klöverstigen", new HashSet<string> { "KLÖ" });
            enhetWithAnyOfTheseSignatures.Add("Klöverstigen NATT", new HashSet<string> { "Natt klöver", "NKLÖ" });
            enhetWithAnyOfTheseSignatures.Add("Surtehöjd", new HashSet<string> { "surte", "Surte" });
            return enhetWithAnyOfTheseSignatures;
        }

        public static Dictionary<string, HashSet<string>> returnVariousFormsOfActivityEnheter()
        {
            Dictionary<string, HashSet<string>> variousFormsOfActivityEnheter = new Dictionary<string, HashSet<string>>();
            variousFormsOfActivityEnheter.Add("Resurser",
                                new HashSet<string> { "Bokat resurspass", "Resurspass Bemanning" });
            return variousFormsOfActivityEnheter;
        }
        public static List<string> returnListOfOkSignatures()
        {
            List<string> listOfOkSignatures = new List<string>();
            listOfOkSignatures.Add("B".ToLower());
            listOfOkSignatures.Add("Björklövsvägen".ToLower());
            listOfOkSignatures.Add("BN".ToLower());
            listOfOkSignatures.Add("Jour bilaga J".ToLower());
            listOfOkSignatures.Add("KLÖ".ToLower());
            listOfOkSignatures.Add("Natt klöver".ToLower());
            listOfOkSignatures.Add("NKLÖ".ToLower());
            listOfOkSignatures.Add("Surte".ToLower());
            listOfOkSignatures.Add("Surtehöjd".ToLower());
            return listOfOkSignatures;
        }

        public static List<String> returnListOfStillOkActivitiesForFindingOkSchedAsNote()
        {
            List<string> listOfStillOkActivitiesForFindingOkSchedAsNote = new List<string>();
            listOfStillOkActivitiesForFindingOkSchedAsNote.Add("");
            listOfStillOkActivitiesForFindingOkSchedAsNote.Add(" ");
            listOfStillOkActivitiesForFindingOkSchedAsNote.Add("*");
            listOfStillOkActivitiesForFindingOkSchedAsNote.Add("Bokat resurspass".ToLower());
            listOfStillOkActivitiesForFindingOkSchedAsNote.Add("Resurspass Bemanning".ToLower());
            return listOfStillOkActivitiesForFindingOkSchedAsNote;
        }

        //if notes belong to same day, they should become one note
        //since Microsoft Shifts takes only one note for each date.
        public static List<Note> returnCondensedNotes(List<Note> clearNotes, List<Note> unclearNotes)
        {
            List<Note> notes = new List<Note>();
            notes.AddRange(clearNotes);
            notes.AddRange(unclearNotes);
            List<string> listOfAllDates = new List<string>();
            for (int i=0; i<notes.Count; i++)
            {
                //MessageBox.Show("note: " + notes[i].note + ", date: " + notes[i].date);
                listOfAllDates.Add(notes[i].date);
            }
            var uniqueDates = listOfAllDates.Distinct().ToList(); //ToList otherwise  Cannot apply indexing with [] to an expression of type 'System.Collections.Generic.ICollection<string>
            //MessageBox.Show("I have " + uniqueDates.Count + " uniqueDates in notes");
            //uniqueDates.ForEach(i => MessageBox.Show(i));

            List<Note> newCondensedNotes = new List<Note>();
            //make new list of newCondensedNotes, only its date is set:
            for (int i=0; i<uniqueDates.Count; i++)
            {
                newCondensedNotes.Add(new Note(uniqueDates[i],""));
            }
            //update the list of newCondensedNotes s at the places it should be updated
            for (int i = 0; i < notes.Count; i++)
            {
                var curDate = notes[i].date;
                var curNote = notes[i].note;
                //doesn't work? var locationToAddInCondensedNotes = newCondensedNotes.IndexOf(n => n.date.Equals(curDate, StringComparison.Ordinal));
                var locationToAddInCondensedNotes = newCondensedNotes.FindIndex(delegate(Note note) {
                    return note.date.Equals(curDate, StringComparison.Ordinal); });
                    newCondensedNotes[locationToAddInCondensedNotes].note += " /// \n \n" + curNote;
            }
            return newCondensedNotes;
        }


        public static string getTheJourBilagaAleId(string previousLine)
        {
            string firstName = previousLine.Split(';')[0].Replace("\"", "").Trim();
            string lastName = previousLine.Split(';')[1].Replace("\"", "").Trim();
            string possibleAleId = Personnel.getMemberAleIdIfInDatabase(firstName, lastName);
            return possibleAleId;
        }

        public static bool isThePossibleSchedLineJourBilagaJ(string possibleSchedItemString)
        {
            string activity = possibleSchedItemString.Split(';')[5].Replace("\"",""). Trim();            
            if (activity == "Jour bilaga J")  {
                //MessageBox.Show("Jour bilaga J found!");
                return true;
            }
            return false;
        }

        public static string getDateOfTomorrow(string todaysDate)
        {
            DateTime today = DateTime.Parse(todaysDate);
            DateTime tomorrow = today.AddDays(1);
            string string_tomorrow = tomorrow.ToString("yyyy-MM-dd").Split(" ")[0]; //=> 2023-07-02 for July second 2023

            //MessageBox.Show("today's date: " + todaysDate + ", tomorrow's date: " + string_tomorrow);
            //MessageBox.Show("string_tomorrow: " + string_tomorrow);

            return string_tomorrow;
        }

        public static bool canWeStillMakeSenseOfThePossibleSchedLineActivityAndSignatureInOrderToAddItAsUnclearNote(string possibleSchedItemString)
        {
            string firstName = possibleSchedItemString.Split(';')[0].Replace("\"", "").Trim();
            string lastName = possibleSchedItemString.Split(';')[1].Replace("\"", "").Trim();
            string signature = possibleSchedItemString.Split(';')[2].Replace("\"", "").Trim();
            string from = possibleSchedItemString.Split(';')[3].Replace("\"", "").Trim();
            string to = possibleSchedItemString.Split(';')[4].Replace("\"", "").Trim();
            string activity = "";
            if (possibleSchedItemString.Split(';')[5]==" ")
            {
                activity = " ";
            } else
            {
                activity = possibleSchedItemString.Split(';')[5].Replace("\"", "").Trim();
            }
            string off = possibleSchedItemString.Split(';')[6].Replace("\"", "").Trim();
            string shiftHours = possibleSchedItemString.Split(';')[7].Replace("\"", "").Trim();

            string tasks = "";
            try
            {
                tasks = possibleSchedItemString.Split(';')[8].Replace("\"", "").Trim();
            }
            catch (IndexOutOfRangeException iore)
            {
                tasks = "";
            }
            string note = "";
            try
            {
                note = possibleSchedItemString.Split(';')[9].Replace("\"", "").Trim();
            }
            catch (IndexOutOfRangeException iore)
            {
                note = "";
            }
            
            if (returnListOfOkSignatures().Contains(signature.ToLower())
                &&
                returnListOfStillOkActivitiesForFindingOkSchedAsNote().Contains(activity.ToLower())
                )
            {
                //this sched line/item can be added as a note because signature is recognized yet activity is in our list of exceptions (i.e. not for example 'Föräldraledigt hel vecka')
                return true;
            }
            return false;
        }
        public static bool isThePossibleSchedLineUnclearInFirstNameAndLastName(string getSchedLine)
        {
            string firstName = getSchedLine.Split(';')[0].Replace("\"", "").Trim();
            string lastName = getSchedLine.Split(';')[1].Replace("\"", "").Trim();
            if (firstName=="" && lastName=="") { return true; }
            else { return false; }
        }
        public static SchedItem createSchedItemOfANighJourBilagaDetail(string possibleSchedItemString, string possibleAleId, string dateDetail, string previousLine)
        {
            string firstName = previousLine.Split(';')[0].Replace("\"", "").Trim();
            string lastName = previousLine.Split(';')[1].Replace("\"", "").Trim();

            string signature = possibleSchedItemString.Split(';')[2].Replace("\"", "").Trim();
            string from = possibleSchedItemString.Split(';')[3].Replace("\"", "").Trim();
            string to = possibleSchedItemString.Split(';')[4].Replace("\"", "").Trim();
            
            //can turn off getting activity since it is "Jour bilaga J" but we want a "Surtehöjd" and add it in Surtehöjd group, i.e. not as a Jour Bilaga enhet
            string activity = possibleSchedItemString.Split(';')[5].Replace("\"", "").Trim();
            //string activity = "Surtehöjd";
            //signature = "Jour Bilaga J";

            string off = possibleSchedItemString.Split(';')[6].Replace("\"", "").Trim();
            string shiftHours = possibleSchedItemString.Split(';')[7].Replace("\"", "").Trim();
            //below for the cases like encountering this line: " 13:00";" 16:00";" APT";" 0";" 03:00";" ";" ";""
            string tasks = "";
            try
            {
                tasks = possibleSchedItemString.Split(';')[8].Replace("\"", "").Trim();
            }
            catch (IndexOutOfRangeException iore)
            {
                tasks = "";
            }
            string note = "";
            try
            {
                note = possibleSchedItemString.Split(';')[9].Replace("\"", "").Trim();
            }
            catch (IndexOutOfRangeException iore)
            {
                note = "";
            }
            string dateFrom = dateDetail;
            string dateTo = getDateOfTomorrow(dateFrom);
            //MessageBox.Show("JourBilaga with dateFrom and dateTo:" + dateFrom + ", " + dateTo);
            return new SchedItem(firstName, lastName, signature, possibleAleId, activity, dateFrom, from, dateTo, to, off, note);
        }

        //if Surte's night doesn't have a correct Ale Id personnel, we make use of this function to add sched as note
        public static string createNoteOfANighJourBilagaDetail(string actualLine, string previousLine)
        {
            string firstName = previousLine.Split(';')[0].Replace("\"", "").Trim();
            string lastName = previousLine.Split(';')[1].Replace("\"", "").Trim();
            string signature = actualLine.Split(';')[2].Replace("\"", "").Trim();
            string from = actualLine.Split(';')[3].Replace("\"", "").Trim();
            string to = actualLine.Split(';')[4].Replace("\"", "").Trim();

            string activity = actualLine.Split(';')[5].Replace("\"", "").Trim();

            return (firstName + " " + lastName +
                ": " + from + "-" + to + ", " + signature + " " + activity);
        }

        public static string createNote(string possibleSchedItemString)
        {
            string firstName = possibleSchedItemString.Split(';')[0].Replace("\"", "").Trim();
            string lastName = possibleSchedItemString.Split(';')[1].Replace("\"", "").Trim();
            string signature = possibleSchedItemString.Split(';')[2].Replace("\"", "").Trim();
            string from = possibleSchedItemString.Split(';')[3].Replace("\"", "").Trim();
            string to = possibleSchedItemString.Split(';')[4].Replace("\"", "").Trim();
            string activity = possibleSchedItemString.Split(';')[5].Replace("\"", "").Trim();
            return (firstName + " " + lastName +
                ": " + from + "-" + to + ", " + signature + ", " + activity) ;
        }
        
        //not used
        public static bool isThePossibleSchedLineANightShift(List<string> listOfNightShiftTypes, string possibleSchedItemString)
        {
            string activity = possibleSchedItemString.Split(';')[5].Replace("\"", "").Trim();

            if (listOfNightShiftTypes.Contains(activity))
            {
                //this sched line/item is a night shift and should be added as a note, not as a shift since Microsoft Shifts won't accept overnight shifts, i.e. after midnight up to the morning
                return true;
            }
            return false;

        }

        public static string getTheActivityEnhetNameThatWeHaveInTeamsForThisSignature(string signature)
        {
            string? containKey = returnEnhetWithAnyOfTheseSignatures().Keys
                                             .Where(key => returnEnhetWithAnyOfTheseSignatures()[key].Contains(signature))
                                             .FirstOrDefault();
            if (containKey==null) { return "NA Enhet"; }
            return containKey;
        }

        public static bool isThereAStarAlongSideASignatureThatMakesThisSchedLineOk(string possibleSchedItemString)
        {
            string signature = possibleSchedItemString.Split(';')[2].Replace("\"", "").Trim();
            string activity = possibleSchedItemString.Split(';')[5].Replace("\"", "").Trim();
            if (activity=="*" && returnListOfActivityEnheter().Contains(
                getTheActivityEnhetNameThatWeHaveInTeamsForThisSignature(signature))) {
                return true;
            } else
            {
                return false;
            }
        }

        public static string getTheActivityEnhetNameThatWeHaveInTeamsForThisVariation(string activity)
        {
            string? containKey = returnVariousFormsOfActivityEnheter().Keys
                                             .Where(key => returnVariousFormsOfActivityEnheter()[key].Contains(activity))
                                             .FirstOrDefault();
            return containKey;
        }

        public static bool isThisActivityAVariationOfAKnownActivityEnhet(string activity)
        {
            //something wrong: Dictionary<string,HashSet<string>> result = returnVariousFormsOfActivityEnheter().Where(x => returnVariousFormsOfActivityEnheter().Values.Any(d => d.Contains(activity))).ToList();
            bool isInDict = returnVariousFormsOfActivityEnheter().Values
                                            .SelectMany(lst=> lst)
                                            .Any(variation => variation==activity);
            return isInDict;
        }
        //a filter-like function to checked details we must have before considering the sched item ok to be added to our new outcoming file        
        public static bool isThePossibleSchedLineForAnActivityEnhetThatWeWant(string possibleSchedItemString)
        {
            string firstName = possibleSchedItemString.Split(';')[0].Replace("\"", "").Trim();
            string lastName = possibleSchedItemString.Split(';')[1].Replace("\"", "").Trim();
            string signature = possibleSchedItemString.Split(';')[2].Replace("\"", "").Trim();
            string from = possibleSchedItemString.Split(';')[3].Replace("\"", "").Trim();
            string to = possibleSchedItemString.Split(';')[4].Replace("\"", "").Trim();
            string activity = possibleSchedItemString.Split(';')[5].Replace("\"", "").Trim();
            string off = possibleSchedItemString.Split(';')[6].Replace("\"", "").Trim();
            string shiftHours = possibleSchedItemString.Split(';')[7].Replace("\"", "").Trim();

            string tasks = "";
            try
            {
                tasks = possibleSchedItemString.Split(';')[8].Replace("\"", "").Trim();
            }
            catch (IndexOutOfRangeException iore)
            {
                tasks = "";
            }
            string note = "";
            try
            {
                note = possibleSchedItemString.Split(';')[9].Replace("\"", "").Trim();
            }
            catch (IndexOutOfRangeException iore)
            {
                note = "";
            }

            //CAN: can add more conditions for example various signatures meaning some activity if the activty itself is absent or set to " " or * etc
            if (returnListOfActivityEnheter().Contains(activity) || isThisActivityAVariationOfAKnownActivityEnhet(activity)) {
                //this sched line/item can be added to the file
                return true;
            }
            return false;
        }

        public static SchedItem createSchedItemFromString(string possibleSchedItemString, string possibleAleId, string dateDetail,string shouldUpgradeActivityFromStarToEnhetWithGivenSignature="no")
        {
            string firstName = possibleSchedItemString.Split(';')[0].Replace("\"", "").Trim();
            string lastName = possibleSchedItemString.Split(';')[1].Replace("\"", "").Trim();
            string signature = possibleSchedItemString.Split(';')[2].Replace("\"", "").Trim();
            string from = possibleSchedItemString.Split(';')[3].Replace("\"", "").Trim() ;
            string to = possibleSchedItemString.Split(';')[4].Replace("\"", "").Trim();
            
            string activity = possibleSchedItemString.Split(';')[5].Replace("\"", "").Trim();
            if (shouldUpgradeActivityFromStarToEnhetWithGivenSignature == "yes" && activity=="*")
            {
                activity = getTheActivityEnhetNameThatWeHaveInTeamsForThisSignature(signature);
                signature = "* " + signature; //add a * so that we keep the original activty value somewhere ie. *
            }

            bool activityVariationFound = false;
            if (isThisActivityAVariationOfAKnownActivityEnhet(activity))
            {
                activity = getTheActivityEnhetNameThatWeHaveInTeamsForThisVariation(activity);
                activityVariationFound = true;
            }
            string off = possibleSchedItemString.Split(';')[6].Replace("\"", "").Trim();
            string shiftHours = possibleSchedItemString.Split(';')[7].Replace("\"", "").Trim();
            //below for the cases like encountering this line: " 13:00";" 16:00";" APT";" 0";" 03:00";" ";" ";""
            string tasks = "";
            try
            {
                tasks = possibleSchedItemString.Split(';')[8].Replace("\"", "").Trim();
            } catch (IndexOutOfRangeException iore)
            {
                tasks = "";
            }
            string note = "";
            try
            {
                note = possibleSchedItemString.Split(';')[9].Replace("\"", "").Trim();
                if (activityVariationFound) {
                    //MessageBox.Show("this activity is variation. activity:" + activity + ", note: " + note + ", signature:" + signature);
                    note = signature + " " + note; }
            }
            catch (IndexOutOfRangeException iore)
            {
                note = "";
            }
            //MessageBox.Show("creating sched item: " + (firstName, lastName, possibleAleId, activity, dateDetail, from, to, off, note));
            List<string> nightShiftTypes = returnListOfNightShiftTypes();
            string dateFrom = "";
            string dateTo = "";
            if (nightShiftTypes.Contains(activity))
            {
                dateFrom = dateDetail;
                dateTo = getDateOfTomorrow(dateFrom);
                //MessageBox.Show("Night shift found -- dateFrom, dateTo: " + dateFrom + ", " + dateTo);
            } else
            {
                dateFrom = dateDetail;
                dateTo = dateDetail;
            }

            return new SchedItem(firstName, lastName, signature, possibleAleId, activity, dateFrom, from, dateTo, to, off, note);
        }

        public static List<Personnel> collectDistinctNotOkPersonnelFromSchedItems(List<SchedItem> schedItems)
        {
            var listOfPersonnelFromSchedItems = new List<Personnel>();
            //make a list of "anything written as" personnel from "not ok sched items"
            for (int i = 0; i < schedItems.Count; i++)
            {
                Personnel? found = listOfPersonnelFromSchedItems.Find(x => (x.FirstName == schedItems[i].firstName));
                if (found == null)
                {
                    listOfPersonnelFromSchedItems.Add(
                        new Personnel(
                            schedItems[i].firstName,
                            schedItems[i].lastName,
                            schedItems[i].emailId
                            //Personnel.createTempAleIdFromName(schedItems[i].firstName, schedItems[i].lastName)
                            )
                    );
                }
            }
            var listOfNotOkPersonnel = new List<Personnel>();
            for (int i = 0; i < listOfPersonnelFromSchedItems.Count; i++)
            { 
                if (listOfPersonnelFromSchedItems[i].AleId == "NA")
                {
                    listOfNotOkPersonnel.Add(listOfPersonnelFromSchedItems[i]);
                }
                //listOfNotOkPersonnel = listOfPersonnelFromSchedItems.Distinct().ToList();
            }
            return listOfNotOkPersonnel;
        }

        public static List<Personnel> collectDistinctPersonnelFromSchedItemsWithoutContactingDatabase(List<SchedItem> schedItems)
        {
            var listOfPersonnelFromSchedItems = new List<Personnel>();
            for (int i = 0; i < schedItems.Count; i++)
            {
                Personnel? found = listOfPersonnelFromSchedItems.Find(x => (x.FirstName == schedItems[i].firstName));
                if (found == null)
                {
                    listOfPersonnelFromSchedItems.Add(
                        new Personnel(
                            schedItems[i].firstName,
                            schedItems[i].lastName,
                            schedItems[i].emailId
                            //Personnel.createTempAleIdFromName(schedItems[i].firstName, schedItems[i].lastName)
                            )
                    );
                }
            }
            var allPersonnelSet = listOfPersonnelFromSchedItems.Distinct().ToList();
            return allPersonnelSet;
        }


        //obsolete function since we not collect distinc personnel without needing to check in database for ale Id
        public static List<Personnel> collectDistinctPersonnelFromSchedItems(List<SchedItem> schedItems)
        {
            using (var context = new PersonnelContext())
            {
                var allPersonnel = context.Personnels;
                var listOfPersonnelFromSchedItems = new List<Personnel>();
                //go through sched items, get the first name and last name, then get its ale id from database allPersonnel, then make a set
                for (int i = 0; i < schedItems.Count; i++)
                {
                    try
                    {
                        string? thisAleId = allPersonnel
                            .Where(personnel => (personnel.FirstName == schedItems[i].firstName && personnel.LastName == schedItems[i].lastName))
                            .Select(personnel => personnel.AleId).Single();
                        listOfPersonnelFromSchedItems.Add(
                            new Personnel(
                                schedItems[i].firstName,
                                schedItems[i].lastName,
                                thisAleId
                             //Personnel.createTempAleIdFromName(schedItems[i].firstName, schedItems[i].lastName)
                             )
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("BL err: " + ex);
                    }
                }
                var allPersonnelSet = listOfPersonnelFromSchedItems.Distinct().ToList();
                return allPersonnelSet;
            }
        }


        //obsolete since we get list of personnel now from given ok/not ok sched items and not from the entire sched items
        public static Tuple<List<Personnel>,List<Personnel>> collectDistinctPersonnelFromAllSchedItems(List<SchedItem> schedItems)
        {
            var numOfPersonnelNotFoundInDatabaseButMentionedInSchedItem = 0;
            using (var context = new PersonnelContext())
            {
                var allPersonnel = context.Personnels;
                var listOfOkPersonnelFromSchedItems = new List<Personnel>();
                var listOfNotOkPersonnelFromSchedItems = new List<Personnel>();
                //go through sched items, get the first name and last name, then get its ale id from database allPersonnel, then make a set
                for (int i = 0; i < schedItems.Count; i++)
                {
                    try {
                        string? thisAleId = allPersonnel
                            .Where(personnel => (personnel.FirstName == schedItems[i].firstName && personnel.LastName == schedItems[i].lastName))
                            .Select(personnel => personnel.AleId).Single();
                        listOfOkPersonnelFromSchedItems.Add(
                            new Personnel(
                                schedItems[i].firstName,
                                schedItems[i].lastName,
                                thisAleId
                             //Personnel.createTempAleIdFromName(schedItems[i].firstName, schedItems[i].lastName)
                             )
                        );
                    }
                    catch (Exception ex)
                    {
                        numOfPersonnelNotFoundInDatabaseButMentionedInSchedItem++;
                        listOfNotOkPersonnelFromSchedItems.Add(
                            new Personnel(
                                schedItems[i].firstName,
                                schedItems[i].lastName,
                                "NA"
                             //Personnel.createTempAleIdFromName(schedItems[i].firstName, schedItems[i].lastName)
                             )
                        ) ;
                    }
                }
                var uniqueOkPersonnel = listOfOkPersonnelFromSchedItems.Distinct().ToList();
                var uniqueNotOkPersonnel = listOfNotOkPersonnelFromSchedItems.Distinct().ToList();
                
                if (numOfPersonnelNotFoundInDatabaseButMentionedInSchedItem>0) {
                    MessageBox.Show(numOfPersonnelNotFoundInDatabaseButMentionedInSchedItem + " personnel that were given in schedule items were not mentioned in database. Setting their Ale Id to 'NA'");
                }
                return Tuple.Create(uniqueOkPersonnel,uniqueNotOkPersonnel);
            }
        }

        public string getThemeColorFor(string groupName, string language)
        {
            //based on group name return the right color (Temfärg)
            switch ((groupName, language))
            {
                //Surtehöjd, Klöverstigen,
                //Björklövsvägen NATT
                //Jour bilaga J
                //Klöverstigen NATT
                case ("Björklövsvägen", "en"):
                    return "3. Green";
                //not used:
                case ("Björklövsvägen NATT", "en"):
                    return "9. DarkGreen";
                case ("Surtehöjd", "en"):
                    return "6. Yellow";
                //not used:
                case ("Jour bilaga J", "en"):
                    return "1. White";
                case ("Klöverstigen", "en"):
                    return "5. Pink";
                //not used:
                case ("Klöverstigen NATT", "en"):
                    return "11. DarkPink";

                case ("Björklövsvägen", "sv"):
                    return "3. Grön";
                //not used:
                case ("Björklövsvägen NATT", "sv"):
                    return "9. DarkGreen";
                case ("Surtehöjd", "sv"):
                    return "6. Gul";
                //not used:
                case ("Jour bilaga J", "sv"):
                    return "1. Vit";
                case ("Klöverstigen", "sv"):
                    return "5. Rosa";
                //not used:
                case ("Klöverstigen NATT", "sv"):
                    return "11. DarkPink";
            }
            return "8. DarkBlue";

        }
        public string getEmailIdFor(string firstName, string lastName)
        {
            //should read the repo of first name last names and get the correct email id associated with it.
            //temporarily do bamlot001@ale.se
            return "bamlot001@ale.se";
        }
        public string toString()
        {
            return "firstName: "+this.firstName+", lastName: " + this.lastName + ", memberName: " + this.memberName + ", email: " + this.emailId + ", activity: " + this.activity + ", dateFrom: " + this.dateFrom +
            ", timeFrom: " + this.timeFrom + ", dateTo: " + this.dateTo + ", timeTo: " + this.timeTo + ", themeColor: " + this.themeColor +
            ", etikett: " + this.etikett + ", off: " +  this.off + ", note: " + this.note + ", shared: " + this.shared;
        }
    }
}
