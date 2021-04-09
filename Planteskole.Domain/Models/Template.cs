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
        public string Name { get; set; }
        public bool Light { get; set; }
        public bool Bottomwatering { get; set; }
        public bool NormalWatering { get; set; }
        public bool Warm { get; set; }
        public bool Cold { get; set; }
        public bool Stackable { get; set; }
        public bool BareRoot { get; set;}
        public bool Lump { get; set; }
    }
}
