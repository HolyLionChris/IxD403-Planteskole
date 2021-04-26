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
        //[Key] also - Having empty lines here fucks up the data table creation in database
        public string Name { get; set; }
        public int Amount { get; set; }
        public bool Sellable { get; set; }
        public int Weight { get; set; }
        public int Depth { get; set; }
        public int Width { get; set; }
        public int TemplateId { get; set; }
        public int LocationId { get; set; }
        public string Location { get; set; }
        public string noGroup
        {
            get
            {
                return "Total";
            }
        }
    }

    public class Plants: ObservableCollection<Plant>
    {
		public Plants()
		{
			this.Add(new Plant
			{
				Name = "Rhododendron",
				Id = 1,
				Amount = 250,
                Location = "Bord 1",
			});
            this.Add(new Plant
            {
                Name = "BushRose",
                Id = 2,
                Amount = 25,
                Location = "Bord 2",
            }); this.Add(new Plant
            {
                Name = "Treeglaze",
                Id = 3,
                Amount = 250,
                Location = "Bord 3",
            }); this.Add(new Plant
            {
                Name = "VioletRose",
                Id = 4,
                Amount = 255,
                Location = "Bord 3",
            }); this.Add(new Plant
            {
                Name = "Viogretta",
                Id = 5,
                Amount = 250,
                Location = "Bord 2",
            }); this.Add(new Plant
            {
                Name = "Raps",
                Id = 6,
                Amount = 550,
                Location = "Bord 1",
            });

        }
	}
}

