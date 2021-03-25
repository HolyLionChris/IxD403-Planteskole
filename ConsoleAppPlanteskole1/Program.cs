using Planteskole.Domain.Models;
using Planteskole.Domain.Services;
using Planteskole.EntityFramework;
using Planteskole.EntityFramework.Services;
using System;
using System.Linq; //.Count

namespace ConsoleAppPlanteskole1
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDataService<Template> templateService = new GenericDataService<Template>(new PlanteskoleDbContextFactory());
            //templateService.Create(new Template { Name = "Acapella" }).Wait();



            //Console.WriteLine(templateService.GetAll().Result.Count());
            //Console.ReadLine();

            //Console.WriteLine(templateService.Get(1).Result); //mangler .ToString
            //Console.ReadLine();

            //Console.WriteLine(templateService.Update(1, new Template() { Name = " Anden Rhododendron" }).Result);

            //Console.WriteLine(templateService.Delete(1).Result);
        }
    }
}
