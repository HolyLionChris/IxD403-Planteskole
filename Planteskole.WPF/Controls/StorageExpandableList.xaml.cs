using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Planteskole.Domain.Models;
using Planteskole.WPF.Temporary;

namespace Planteskole.WPF.Controls
{
    /// <summary>
    /// Interaction logic for StorageExpandableList.xaml
    /// </summary>
    public partial class StorageExpandableList : UserControl
    {

        public StorageExpandableList()
        {
            InitializeComponent();

            StorageO MyStorage = new StorageO("This Storage");
            trvMenu.Items.Add(MyStorage);

            /*vv DEMO vv
             
            StorageO root = new StorageO() { Title = "Storage" };

            AreaO childItem1 = new AreaO() { Title = "Greenhouse" };

            LocationO child1Child1 = new LocationO() { Title = "B12 West" };
            Plant childChildChild11 = new Plant() { Name = "Rododendrun" };
            Plant childChildChild12 = new Plant() { Name = "Acapella" };
            child1Child1.Items.Add(childChildChild11);
            child1Child1.Items.Add(childChildChild12);

            LocationO child1Child2 = new LocationO() { Title = "B12 East" };
            Plant childChildChild2 = new Plant() { Name = "Thisle" };
            child1Child2.Items.Add(childChildChild2);

            childItem1.Items.Add(child1Child1);
            childItem1.Items.Add(child1Child2);


            AreaO childItem2 = new AreaO() { Title = "Outdoor Storage" };

            LocationO child2Child1 = new LocationO() { Title = "Row 1" };
            Plant childChildChild3 = new Plant() { Name = "Aspirin Rose" };
            child2Child1.Items.Add(childChildChild3);

            LocationO child2Child2 = new LocationO() { Title = "Row 2" };
            Plant childChildChild4 = new Plant() { Name = "Clematis" };
            child2Child2.Items.Add(childChildChild4);

            childItem2.Items.Add(child2Child1);
            childItem2.Items.Add(child2Child2);

            root.Items.Add(childItem1);
            root.Items.Add(childItem2);
            trvMenu.Items.Add(root);
            
             ^^ DEMO ^^*/
        }
    }



    class AbstractO 
    {
    }



    class StorageO : AbstractO
    {
        public StorageO(string title)
        {
            this.Title = title;

            PlantContext context = new PlantContext();
            context.Database.EnsureCreated();

            context.Plants.Load();
            context.Areas.Load();
            context.Locations.Load();

            List<Plant> ListOfPlants = context.Plants.Local.ToList();
            List<Location> ListOfLocations = context.Locations.Local.ToList();
            List<Area> ListOfAreas = context.Areas.Local.ToList();

            this.Items = new ObservableCollection<AreaO>();

            //Populates the storage with one of each area
            foreach (Area area in ListOfAreas)
            {
                AreaO tempArea = new AreaO(area.Name, area.Id, ListOfLocations, ListOfPlants);
                this.Items.Add(tempArea);
            }
        }

        public string Title { get; set; }
        public ObservableCollection<AreaO> Items { get; set; }
    }



    class AreaO : AbstractO
    {
        public AreaO(string title, int areaID, List<Location> ListOfLocations, List<Plant> ListOfPlants)
        {
            //Temporary?
            this.Title = title;

            this.Items = new ObservableCollection<LocationO>();

            //Populates the area with locations of the AreaID
            foreach (Location loc in ListOfLocations)
            {

                if (loc.AreaId == areaID)
                {
                    LocationO tempLoc = new LocationO(loc.Name, loc.Id, ListOfPlants);
                    this.Items.Add(tempLoc);
                }
            }
        }

        public string Title { get; set; }
        public ObservableCollection<LocationO> Items { get; set; }
    }



    class LocationO : AbstractO
    {
        public LocationO(string title, int locID, List<Plant> ListOfPlants)
        {
            //Temporary?
            this.Title = title;

            this.Items = new ObservableCollection<Plant>();

            //Populates the location with plants of the LocationID
            foreach (Plant plt in ListOfPlants)
            {
                if (plt.LocationId == locID)
                    this.Items.Add(plt);
            }
        }

        public string Title { get; set; }
        public ObservableCollection<Plant> Items { get; set; }
    }
}
