using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖvergripandeBemanningBro_v3._0._2

{
    public class old_Personnel
    {
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string email { get; set; }
        private string aleId { get; set; }
        private string phone { get; set; }
        public old_Personnel(string firstName, string lastName, string email, string aleId, string phone)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.aleId = aleId;
            this.phone = phone;
        }

        //https://www.w3schools.com/cs/cs_properties.php
        public string FirstName { 
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string AleId
        {
            get { return aleId; }
            set { aleId = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

    }
}

