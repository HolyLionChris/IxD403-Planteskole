using Microsoft.EntityFrameworkCore;
using Planteskole.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planteskole.WPF.Temporary
{
    public class PlantContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Template> Templates { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=PlanteskoleDB.db");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
