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
        public double TotalSquareFeet
        {
            get{ return this.Depth * this.Width; }
            set { }
        }

        public double OccupiedSquareFeet 
        {
            get { return GetOccupiedSquareFeet(); }
            set { } 
        }

        public double AvailableSquareFeet 
        {
            get { return GetAvailableSquareFeet(); }
            set { } 
        }

        public List<Plant> OccupyingPlants { get; set; }

        #region GetSquareFeet Methods
        public double GetAvailableSquareFeet() 
        {
            double availableSquareFeet = this.TotalSquareFeet - this.OccupiedSquareFeet;
            return availableSquareFeet;
        }

        public double GetOccupiedSquareFeet() 
        {
            double occupiedSquareFeet = 0;

            if (OccupyingPlants != null)
            {
                foreach (Plant plt in OccupyingPlants)
                {
                    occupiedSquareFeet += plt.TotalSquareFeet;
                }
            }

            return occupiedSquareFeet;
        }
        #endregion
    }
}
