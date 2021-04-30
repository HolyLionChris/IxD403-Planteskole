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
        public int Depth { get; set; }
        public int Width { get; set; }
        public string AreaName { get; set; }
        public bool TreeSupport { get; set; }
    }
}
