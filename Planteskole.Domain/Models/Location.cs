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
        public bool IsCompatible { get; set; }

        #region SquareMeter Properties
        public double TotalSquareMeters
        {
            get{ return this.Depth * this.Width; }
            set { }
        }

        //Be advised: These do NOT update square feet, only gets the last version
        private double _occupiedSquareMeters;
        public double OccupiedSquareMeters
        { 
            get { return _occupiedSquareMeters; } 
            set { } 
        }

        private double _availableSquareMeters;
        public double AvailableSquareMeters
        {
            get { return _availableSquareMeters; }
            set { }
        }
        #endregion

        #region UpdateInfo Methods
        public void UpdateSpace(DbSet<Plant> plantDbSet) 
        {
            this.UpdateOccupiedSquareMeters(plantDbSet);
            this.UpdateAvailableSquareMeters(plantDbSet);
        }

        public void UpdateAvailableSquareMeters(DbSet<Plant> plantDbSet) 
        {
            this.UpdateOccupiedSquareMeters(plantDbSet);
            _availableSquareMeters = TotalSquareMeters - _occupiedSquareMeters;
        }

        public void UpdateOccupiedSquareMeters(DbSet<Plant> plantDbSet) 
        {
            if (plantDbSet != null)
            {
                _occupiedSquareMeters = 0;
                List<Plant> OccupyingPlants = plantDbSet.Where(b => b.LocationName == this.LocationName).ToList();

                foreach (Plant plt in OccupyingPlants)
                {
                    _occupiedSquareMeters += plt.TotalSquareMeters;
                }
            }
        }
        #endregion
    }
}
