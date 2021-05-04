using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //[Key]
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Planteskole.Domain.Models
{
    
    public class Plant : DomainObject
    {
        public enum FootType { NA, Pot, BareRoot, Lump }
        public enum WateringNeeds { NA, BottomWatering, AboveWatering }
        public enum TemperatureNeeds { NA, Cold, Moderate, Warmth }

        //[Key] also - Having empty lines here fucks up the data table creation in database
        public string Name { get; set; }
        public int Amount { get; set; }
        public bool Sellable { get; set; } = true;
        public bool NeedsLight { get; set; }
        public bool Vulnerable { get; set; }
        public bool NeedsTreeSupport { get; set; }
        public int WeightPerPlant { get; set; }
        public int DepthPerPlant { get; set; }
        public int WidthPerPlant { get; set; }
        public string LocationName { get; set; }
        public string AreaName { get; set; }
        public FootType FootEnum { get; set; } = FootType.NA;
        public WateringNeeds WNeeds { get; set; } = WateringNeeds.NA;
        public TemperatureNeeds PTemperature { get; set; } = TemperatureNeeds.NA;

        public string noGroup
        {
            get{ return "Total"; }
        }

        public double TotalSquareFeet
        {
            get { return (this.DepthPerPlant * this.WidthPerPlant) * this.Amount; }
            set { }
        }


    }
}

