﻿using Microsoft.EntityFrameworkCore;
using Planteskole.Domain.Models;
using Planteskole.WPF.Temporary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Planteskole.WPF.ViewModels
{
    public class AddViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ICollectionView SuggestL { get; set; }
        private readonly PlantContext _context = new PlantContext();

        public AddViewModel()
        {
            _context.Locations.Load();
            IList<Location> ListSuggestL = _context.Locations.Local.ToObservableCollection();
            SuggestL = CollectionViewSource.GetDefaultView(ListSuggestL);
        }

        private Plant _selectedItem;
        public Plant SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; NoticeMe("SelectedItem"); SuggestL.Filter += new Predicate<object>(SuggestPlacementFilter); }
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

        public bool SuggestPlacementFilter(object de)
        {
            Location loc = de as Location;
            //Compares - TEMPORARY
            return (loc.Warm == _selectedItem.Sellable);
        }










        protected void NoticeMe(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
