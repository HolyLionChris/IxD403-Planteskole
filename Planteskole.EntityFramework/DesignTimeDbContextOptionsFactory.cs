using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planteskole.EntityFramework
{
    public class DesignTimeDbContextOptionsFactory : IDesignTimeDbContextFactory<PlanteskoleDbContext>
    {
        public PlanteskoleDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<PlanteskoleDbContext>();
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PlanteskoleDB;Trusted_Connection=True");

            return new PlanteskoleDbContext(options.Options);
        }
    }
}
