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
        [DisplayName("Group Name")]
        public string groupName { get; set; }
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

        public SchedItem (string firstName, string lastName, string possibleAleId, string groupName, string dateDetail, string timeFrom, string timeTo, string off, string note)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.memberName = firstName + " " + lastName;
            this.emailId = possibleAleId; //getEmailIdFor(firstName, lastName);
            this.groupName = groupName;
            this.dateFrom = dateDetail;
            this.timeFrom = timeFrom;
            this.dateTo = dateDetail;
            this.timeTo = timeTo;
            this.themeColor = getThemeColorFor(groupName);
            this.etikett = "";
            this.off = off;
            this.note = note;
            this.shared = "1. Delat";
        }

        public static SchedItem createSchedItemFromString(string possibleSchedItemString, string possibleAleId, string dateDetail)
        {
            string firstName = possibleSchedItemString.Split(';')[0].Trim();
            string lastName = possibleSchedItemString.Split(';')[1].Trim();
            string signature = possibleSchedItemString.Split(';')[2].Trim();
            string from = possibleSchedItemString.Split(';')[3].Trim() ;
            string to = possibleSchedItemString.Split(';')[4].Trim();
            string activity = possibleSchedItemString.Split(';')[5].Trim();
            string off = possibleSchedItemString.Split(';')[6].Trim();
            string shiftHours = possibleSchedItemString.Split(';')[7].Trim();
            string tasks = possibleSchedItemString.Split(';')[8].Trim();
            string note = possibleSchedItemString.Split(';')[9].Trim();
            return new SchedItem(firstName, lastName, possibleAleId, activity, dateDetail, from, to, off, note);
        }

        public static List<Personnel> collectDistincPersonnelFromSchedItemsWithoutContactingDatabase(List<SchedItem> schedItems)
        {
            var listOfPersonnelFromSchedItems = new List<Personnel>();
            for (int i = 0; i < schedItems.Count; i++)
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

        public string getThemeColorFor(string groupName)
        {
            //based on group name return the right color (Temfärg)
            return "6. Gul";
        }
        public string getEmailIdFor(string firstName, string lastName)
        {
            //should read the repo of first name last names and get the correct email id associated with it.
            //temporarily do bamlot001@ale.se
            return "bamlot001@ale.se";
        }
        public string toString()
        {
            return "firstName: "+this.firstName+", lastName: " + this.lastName + ", memberName: " + this.memberName + ", email: " + this.emailId + ", groupName: " + this.groupName + ", dateFrom: " + this.dateFrom +
            ", timeFrom: " + this.timeFrom + ", dateTo: " + this.dateTo + ", timeTo: " + this.timeTo + ", themeColor: " + this.themeColor +
            ", etikett: " + this.etikett + ", off: " +  this.off + ", note: " + this.note + ", shared: " + this.shared;
        }
    }
}
