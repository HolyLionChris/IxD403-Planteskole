using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planteskole.EntityFramework
{
    //We use this "Factory" in order for it to be thread save, meaning that there won't be an error
    //if multiple threads try to access the Database at the same time
    public class PlanteskoleDbContextFactory : IDesignTimeDbContextFactory<PlanteskoleDbContext>
    {
        public PlanteskoleDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<PlanteskoleDbContext>();
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PlanteskoleDB;Trusted_Connection=True");

            return new PlanteskoleDbContext(options.Options);
        }
    }
}
