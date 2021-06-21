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
        public double Depth { get; set; }
        public double Width { get; set; }
        public bool IsCompatible { get; set; }

        #region SquareMeter Properties
        public double TotalSquareCentimeters
        {
            get{ return this.Depth * this.Width; }
            set { }
        }

        //Be advised: These do NOT update square feet, only gets the last version
        private double _occupiedSquareCentimeters;
        public double OccupiedSquareCentimeters
        { 
            get { return _occupiedSquareCentimeters; } 
            set { } 
        }

        private double _availableSquareCentimeters;
        public double AvailableSquareCentimeters
        {
            get { return _availableSquareCentimeters; }
            set { }
        }
        #endregion

        #region UpdateInfo Methods
        public void UpdateSpace(DbSet<Plant> plantDbSet) 
        {
            this.UpdateOccupiedSquareCentimeters(plantDbSet);
            this.UpdateAvailableSquareCentimeters(plantDbSet);
        }

        public void UpdateAvailableSquareCentimeters(DbSet<Plant> plantDbSet) 
        {
            this.UpdateOccupiedSquareCentimeters(plantDbSet);
            _availableSquareCentimeters = TotalSquareCentimeters - _occupiedSquareCentimeters;
        }

        public void UpdateOccupiedSquareCentimeters(DbSet<Plant> plantDbSet) 
        {
            if (plantDbSet != null)
            {
                _occupiedSquareCentimeters = 0;
                List<Plant> OccupyingPlants = plantDbSet.Where(b => b.LocationName == this.LocationName).ToList();

                foreach (Plant plt in OccupyingPlants)
                {
                    _occupiedSquareCentimeters += plt.TotalSquareCentimeters;
                }
            }
        }
        #endregion
    }
}
