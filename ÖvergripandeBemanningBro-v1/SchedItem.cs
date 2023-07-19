using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖvergripandeBemanningBro_v1
{
    public class SchedItem
    {
        [DisplayName("Member Name")]
        public string memberName {  get; set; }
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

        public SchedItem(string firstName, string lastName, string groupName, string dateDetail, string timeFrom, string timeTo, string off, string note)
        {
            this.memberName = firstName + lastName;
            this.emailId = getEmailIdFor(firstName, lastName);
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
            return "memberName: " + this.memberName + ", email: " + this.emailId + ", groupName: " + this.groupName + ", dateFrom: " + this.dateFrom +
            ", timeFrom: " + this.timeFrom + ", dateTo: " + this.dateTo + ", timeTo: " + this.timeTo + ", themeColor: " + this.themeColor +
            ", etikett: " + this.etikett + ", off: " +  this.off + ", note: " + this.note + ", shared: " + this.shared;
        }
    }
}
