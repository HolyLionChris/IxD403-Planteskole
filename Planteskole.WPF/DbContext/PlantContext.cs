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
        public DbSet<Location> Locations 
        {
            get 
            {
                DbSet<Location> locs = Set<Location>();
                PopulateLocations(locs);
                return locs; 
            }
            set { } 
        }
        public DbSet<Area> Areas { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=PlanteskoleDB.db");
            //optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        #region PopulateLocation
        public void PopulateLocations(DbSet<Location> set) 
        {
            foreach (Location loc in set) 
            {
                loc.OccupyingPlants = Plants.Where(b => b.LocationName == loc.LocationName).ToList();
            }
        }
        #endregion

    }
}
