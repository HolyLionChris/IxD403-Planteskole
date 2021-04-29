using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planteskole.Domain.Models
{
    public class Location : DomainObject
    {
        public string LocationName { get; set; }
        public bool BottomWater { get; set; }
        public bool NormalWatering { get; set; }
        public bool Warm { get; set; }
        public bool Light { get; set; }
        public bool Cold { get; set; }
        public string AreaName { get; set; }
    }
}
