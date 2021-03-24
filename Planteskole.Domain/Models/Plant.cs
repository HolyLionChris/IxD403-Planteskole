using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //[Key]
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planteskole.Domain.Models
{
    public class Plant
    {
        [Key]
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
