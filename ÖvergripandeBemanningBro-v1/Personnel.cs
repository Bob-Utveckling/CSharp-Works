using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖvergripandeBemanningBro_v1
{
    public class Personnel
    {
        private string name { get; set; }
        private string email { get; set; }
        private string emailAlias { get; set; }
        public Personnel(string name, string email, string emailAlias)
        {
            this.name = name;
            this.email = email;
            this.emailAlias = emailAlias;
        }

        //https://www.w3schools.com/cs/cs_properties.php
        public string Name { 
            get { return name; }
            set { name = value; }
        }
        public string Email { 
            get { return email; }
            set { email = value; } }
        public string EmailAlias { 
            get { return emailAlias; } 
            set { emailAlias = value; }
        }

    }
}

