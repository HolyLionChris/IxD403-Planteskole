using Planteskole.Domain.Models;
using Planteskole.Domain.Services;
using Planteskole.EntityFramework;
using Planteskole.EntityFramework.Services;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<Plant> userService = new GenericDataService<Plant>(new PlanteskoleDbContextFactory());
        }
    }
}
