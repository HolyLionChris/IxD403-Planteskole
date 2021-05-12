using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planteskole.Domain.Models
{
    public class DomainObject //used to give objects ID's in the database
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
