using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //[Key]
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planteskole.Domain.Models
{
    public class Template : DomainObject
    {
        public enum FootType { NA, Pot, BareRoot, Lump }
        public enum WateringNeeds { NA, BottomWatering, AboveWatering }
        public enum TemperatureNeeds { NA, Cold, Moderate, Warmth }

        public string Name { get; set; }
        public bool Light { get; set; }
        public FootType FootEnum { get; set; } = FootType.NA;
        public WateringNeeds WNeeds { get; set; } = WateringNeeds.NA;
        public TemperatureNeeds PTemperature { get; set; } = TemperatureNeeds.NA;
    }
}
