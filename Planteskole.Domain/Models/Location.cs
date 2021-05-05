using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planteskole.Domain.Models
{
    public class Location : DomainObject
    {
        public enum WateringMethod { NA, BottomWatering, AboveWatering }
        public enum Temperatures { NA, Cold, Moderate, Warmth }


        public string LocationName { get; set; }
        public WateringMethod WMethod { get; set; }
        public Temperatures LTemperatures { get; set; }
        public bool Light { get; set; }
        public string AreaName { get; set; }
        public bool TreeSupport { get; set; }
        public int Depth { get; set; }
        public int Width { get; set; }

        #region SquareFeet Properties
        public double TotalSquareFeet
        {
            get{ return this.Depth * this.Width; }
            set { }
        }

        //Be advised: These do NOT update square feet, only gets the last version
        private double _occupiedSquareFeet;
        public double OccupiedSquareFeet 
        { 
            get { return _occupiedSquareFeet; } 
            set { } 
        }

        private double _availableSquareFeet;
        public double AvailableSquareFeet
        {
            get { return _availableSquareFeet; }
            set { }
        }
        #endregion

        #region UpdateInfo Methods
        public void UpdateInfo(DbSet<Plant> plantDbSet) 
        {
            this.UpdateOccupiedSquareFeet(plantDbSet);
            this.UpdateAvailableSquareFeet(plantDbSet);
        }

        public void UpdateAvailableSquareFeet(DbSet<Plant> plantDbSet) 
        {
            this.UpdateOccupiedSquareFeet(plantDbSet);
            _availableSquareFeet = TotalSquareFeet - _occupiedSquareFeet;
        }

        public void UpdateOccupiedSquareFeet(DbSet<Plant> plantDbSet) 
        {
            if (plantDbSet != null)
            {
                _occupiedSquareFeet = 0;
                List<Plant> OccupyingPlants = plantDbSet.Where(b => b.LocationName == this.LocationName).ToList();

                foreach (Plant plt in OccupyingPlants)
                {
                    _occupiedSquareFeet += plt.TotalSquareFeet;
                }
            }
        }
        #endregion
    }
}
