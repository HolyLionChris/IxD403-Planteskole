using Microsoft.EntityFrameworkCore;
using Planteskole.Domain.Models;
using Planteskole.WPF.Temporary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace Planteskole.WPF.ViewModels
{
    public class AddViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ObservableCollection<Location> SuggestL { get; set; }
        private readonly PlantContext _context = new PlantContext();

        public AddViewModel()
        {
            _context.Locations.Load();
            UpdateLocations(_context.Locations, _context.Plants);
            _context.SaveChanges();
            SuggestL = _context.Locations.Local.ToObservableCollection();
        }

        #region Selected Items
        private Plant _selectedItem;
        public Plant SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; 
                  NoticeMe("SelectedItem");
                  //UpdateLocations(ListSuggestL, _context.Plants);
                  //SuggestL = CollectionViewSource.GetDefaultView(ListSuggestL);
                  //SuggestL.Refresh();
                  //SuggestL.Filter += new Predicate<object>(SuggestPlacementFilter);
                 }
        }


        private Location _selectedItemLocation;
        public Location SelectedItemLocation
        {
            get { return _selectedItemLocation; }
            set { _selectedItemLocation = value; NoticeMe("SelectedItemLocation"); }
        }


        private Area _selectedItemArea;
        public Area SelectedItemArea
        {
            get { return _selectedItemArea; }
            set { _selectedItemArea = value; NoticeMe("SelectedItemArea"); }
        }
        #endregion

        #region Suggested Location Filter
        public bool SuggestPlacementFilter(object de)
        {
            Location loc = de as Location;
            bool isCompatible = false;
            if (_selectedItem != null) 
            {
                //Compares - These two functions are nested, so we don't call the individual comparisons when _selectedItem is null. Might be changed later
                isCompatible = IsCompatibleWithAllProperties(_selectedItem, loc);
            }
            return isCompatible;
        }

        public bool IsCompatibleWithAllProperties(Plant plt, Location loc) 
        {
            bool isCompatible = false;

            if (EnoughSpace(plt, loc) 
                && LightCompatible(plt, loc) 
                && WateringCompatible(plt, loc) 
                && TemperatureCompatible(plt, loc) 
                && TreeSupportCompatible(plt, loc)) 
            {
                isCompatible = true;
            }

            return isCompatible;
        }

        public bool EnoughSpace(Plant plt, Location loc) 
        {
            bool spaceCompatible = false;

            loc.UpdateAvailableSquareFeet(_context.Plants);
            if (plt.TotalSquareFeet <= loc.AvailableSquareFeet)
            {
                spaceCompatible = true;
            }

            return spaceCompatible;
        }

        public bool LightCompatible(Plant plt, Location loc)
        {
            bool lightCompatible = false;

            //Only incompatible if the plant DOES need light but the location does NOT provide light
            if (!((plt.NeedsLight == true) && (loc.Light == false))) 
            {
                lightCompatible = true;
            }

            return lightCompatible;
        }

        public bool WateringCompatible(Plant plt, Location loc)
        {
            bool wateringCompatible = false;

            //Compatible if neither plant nor location is NA and watering need and method is the same
            if (plt.WNeeds != Plant.WateringNeeds.NA
                && loc.WMethod != Location.WateringMethod.NA
                && (int)plt.WNeeds == (int)loc.WMethod)
            {
                wateringCompatible = true;
            }

            return wateringCompatible;
        }

        public bool TemperatureCompatible(Plant plt, Location loc)
        {
            bool temperatureCompatible = false;

            //Compatible if neither plant nor location is NA and temperature need and provision is the same
            if (plt.PTemperature != Plant.TemperatureNeeds.NA
                && loc.LTemperatures != Location.Temperatures.NA
                && (int)plt.PTemperature == (int)loc.LTemperatures)
            {
                temperatureCompatible = true;
            }

            return temperatureCompatible;
        }

        public bool TreeSupportCompatible(Plant plt, Location loc)
        {
            bool treeSupCompatible = false;

            //Only incompatible if the plant DOES need light but the location does NOT provide light
            if (!((plt.NeedsTreeSupport == true) && (loc.TreeSupport == false)))
            {
                treeSupCompatible = true;
            }

            return treeSupCompatible;
        }
        #endregion

        #region UpdateLocations
        //Updates available and occupied square feet for all locations in an enumerable
        public void UpdateLocations(IEnumerable<Location> locs, DbSet<Plant> plantDbSet)
        {
            foreach (Location loc in locs)
            {
                loc.UpdateInfo(plantDbSet);
            }
        }
        #endregion

        protected void NoticeMe(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
