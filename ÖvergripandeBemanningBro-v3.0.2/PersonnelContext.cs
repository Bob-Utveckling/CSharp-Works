using Microsoft.EntityFrameworkCore;
using ÖvergripandeBemanningBro_v3._0._2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖvergripandeBemanningBro_v3._0._2
{
    internal class PersonnelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\bamsh\Desktop\ASP.Net\C#\WinForms-EntityFramework-Sqlite-CRUD\database1.db");
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
