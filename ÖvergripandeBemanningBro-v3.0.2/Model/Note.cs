using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖvergripandeBemanningBro_v3._0._2.Model
{
    public class Note
    {
        public int id { get; set; }
        public string date { get; set; }
        public string note { get; set; }

        public Note(string date, string note)
        {
            this.date = date;
            this.note = note;
        }

        public Note() { }

    }
}
