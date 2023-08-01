using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_EntityFramework_Sqlite_CRUD.Model
{
    public class Personnel
    {
        public Personnel() { 
            
        }

        //if enabling, the Id field will not be visible in the grid data view, apparently. My interactions need knowing id.
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? AleId { get; set; }
        public string? Phone { get; set; }
        public DateTime? LastUpdated { get; set; }

    }
}
