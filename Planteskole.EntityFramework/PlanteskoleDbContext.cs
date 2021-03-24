using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planteskole.Domain.Models; //reference to other folder 

namespace Planteskole.EntityFramework
{
    public class PlanteskoleDbContext : DbContext //manage interaction with database 
    {


        public DbSet<Plant> Plants { get; set; }
        public DbSet<Template> Templates { get; set; }
        public PlanteskoleDbContext(DbContextOptions options) : base(options) //empty because base class takes care of it
        {
        }

    }
}
