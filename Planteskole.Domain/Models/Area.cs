using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planteskole.Domain.Models
{
    public class Area : DomainObject
    {
        public string AreaName { get; set; }
        public string LocationName
        {
            get
            {
                return "Ghost Item";
            }
        }
    }
}
