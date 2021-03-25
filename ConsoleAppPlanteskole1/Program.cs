using Planteskole.Domain.Models;
using Planteskole.Domain.Services;
using Planteskole.EntityFramework;
using Planteskole.EntityFramework.Services;
using System;

namespace ConsoleAppPlanteskole1
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDataService<Plant> userService = new GenericDataService<Plant>(new PlanteskoleDbContextFactory());
        }
    }
}
