using Planteskole.Domain.Models;
using Planteskole.EntityFramework;
using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<Plant> userService = new GenericDataService<Plant>(new PlanteskoleDbContextFactory());
        }
    }
}
