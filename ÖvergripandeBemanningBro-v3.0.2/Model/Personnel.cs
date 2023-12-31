﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖvergripandeBemanningBro_v3._0._2.Model
{
    public class Personnel
    {
        //if enabling, the Id field will not be visible in the grid data view, apparently. My interactions need knowing id.
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string? FirstName { get; set; }

        public string? AlternativeFirstName1 { get; set; }
        public string? LastName { get; set; }
        public string? AlternativeLastName1 { get; set; }
        public string? Email { get; set; }
        public string? AleId { get; set; }
        public string? Phone { get; set; }
        public DateTime? LastUpdated { get; set; }

        public Personnel()
        {}

        public Personnel(string firstName, string lastName, string aleId)
        {
            FirstName = firstName;
            LastName = lastName;
            AleId = aleId;
        }

        public static string getMemberAleIdIfInDatabase(string possibleFirstName, string possibleLastName)
        {
            if (possibleFirstName != "" & possibleLastName != "") //this was needed after the error popping up close to the end of the project
            {
                //MessageBox.Show("get Personnel AleId for: first:" + possibleFirstName + ", last:" + possibleLastName);
                using (var context = new PersonnelContext())
                {
                    try
                    {
                        Personnel result = context.Personnels.SingleOrDefault(p => ((p.FirstName == possibleFirstName || p.AlternativeFirstName1 == possibleFirstName) && (p.LastName == possibleLastName || p.AlternativeLastName1 == possibleLastName)));
                        if (result?.AleId != null)
                        {
                            return result.AleId;
                        }
                        else
                        {
                            return "NA";
                        }
                        //return "bamlot001@ale.se";
                    }
                    catch (Exception ex) { MessageBox.Show("BL2 error for possibleFirstName: " + possibleFirstName + "possibleLastName: " + possibleLastName + "\n" + ex); }
                }
                return "NA";
            } else { return "NA"; }
        }

        public static string createTempAleIdFromName(string firstName, string lastName)
        {
            //There is an space at the beginning of first name and last name
            firstName = firstName.Trim();
            lastName = lastName.Trim();
            //MessageBox.Show("first name: " + firstName + ", length: " + firstName.Length + ", first 3 chars: " + firstName.Substring(0, 4));

            var part1 = firstName == null ? "" :
                        firstName.Length == 1 ? firstName.Substring(0, 1) :
                            firstName.Length == 2 ? firstName.Substring(0, 2) :
                                firstName.Substring(0, 3);
            var part2 = lastName == null ? "" :
                        lastName.Length == 1 ? lastName.Substring(0, 1) :
                            lastName.Length == 2 ? lastName.Substring(0, 2) :
                                lastName.Substring(0, 3);
            var part3 = "001@ale.se";
                  
            MessageBox.Show(part1+part2+part3);
            return part1+part2+part3;
        }

    }

}
