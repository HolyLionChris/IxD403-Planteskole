using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //[Key]
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planteskole.Domain.Models
{
    public class Plant : DomainObject
    {
        //[Key] also - Having empty lines here fucks up the data table creation in database
        public string Name { get; set; }
        public int Amount { get; set; }
        public bool Sellable { get; set; }
        public int Weight { get; set; }
        public int Dimensions { get; set; }
        private string _footType;
        public string FootType
        {
            get 
            {
                return _footType;
            }
            set 
            {
                switch (value)
                {
                    case ("BareRoot"):
                        _footType = value;
                        break;
                    case ("Pot"):
                        _footType = value;
                        break;
                    case ("Lump"):
                        _footType = value;
                        break;
                    default:
                    break;
                }
            }
        }
    }
}
