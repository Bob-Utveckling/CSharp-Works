using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WinForms_EntityFramework_Sqlite_CRUD.Model;

namespace WinForms_EntityFramework_Sqlite_CRUD
{
    internal class PersonnelContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\bamsh\Desktop\ASP.Net\C#\ÖvergripandeBemanningBro-v3.0.0\Database\database.db");
        }
        public DbSet<Personnel> Personnels { get; set; }
        //to be considered as alternative: public BindingList<Personnel>? Personnels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personnel>()
                .ToTable("personnel")
                ;
            //base.OnModelCreating(modelBuilder);
        }

    }
}
