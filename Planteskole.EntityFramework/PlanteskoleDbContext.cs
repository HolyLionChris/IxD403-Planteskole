using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planteskole.Domain.Models; //reference to other folder 

namespace Planteskole.EntityFramework
{
    public class PlanteskoleDbContext : DbContext //manage interaction with database 
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Template> Templates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PlanteskoleDB;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
