using Planteskole.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;
using Planteskole.WPF.Commands;
using Microsoft.EntityFrameworkCore;
using Planteskole.WPF.Temporary;



namespace Planteskole.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICollectionView HomeView { get; set; }
        private readonly PlantContext _context = new PlantContext();


        public HomeViewModel()
        {
            _context.Database.EnsureCreated();
            _context.Plants.Load();
            _context.Locations.Load();
            _context.Areas.Load();

            IList<Location> locations = _context.Locations.Local.ToObservableCollection();
            IList<Area> areas = _context.Areas.Local.ToObservableCollection();
            IList<Plant> plants = _context.Plants.Local.ToObservableCollection();
            List<Object> allS = (from x in plants select (Object)x).ToList();
            allS.AddRange((from x in locations select (Object)x).ToList());
            allS.AddRange((from x in areas select (Object)x).ToList());

            HomeView = CollectionViewSource.GetDefaultView(allS);

            //OrdersView.GroupDescriptions.Add(new PropertyGroupDescription("noGroup"));

            groupByLocationCommand = new GroupByLocationCommand(this); //OrderGroupCommand.cs
            groupByAreaCommand = new GroupByAreaCommand(this); 
            removeGroupCommand = new RemoveGroupCommand(this);
            saveButtonCommand = new SaveButtonCommand(this);
            deleteButtonCommand = new DeleteButtonCommand(this);

            HomeView.GroupDescriptions.Add(new PropertyGroupDescription("AreaName"));
            HomeView.GroupDescriptions.Add(new PropertyGroupDescription("LocationName"));
        }


        public void AutoSave ()
        {
            _context.SaveChanges();
        }

        public void RemoveGroup()
        {
            HomeView.GroupDescriptions.Clear();
            HomeView.GroupDescriptions.Add(new PropertyGroupDescription("noGroup"));
        }

        public void GroupByLocation()
        {
            HomeView.GroupDescriptions.Clear();
            HomeView.GroupDescriptions.Add(new PropertyGroupDescription("AreaName"));
            HomeView.GroupDescriptions.Add(new PropertyGroupDescription("LocationName"));
        }

        public void GroupByArea()
        {
            HomeView.GroupDescriptions.Clear();
            HomeView.GroupDescriptions.Add(new PropertyGroupDescription("AreaName"));
        }

        public void SaveButton()
        {
            _context.SaveChanges();
        }

        public void DeleteButton()
        {
            _context.Plants.Remove((Plant)HomeView.CurrentItem);
            _context.SaveChanges();
        }


        //We can just add more to get more different groupings, such as date added which can be automated

        public ICommand groupByLocationCommand
        {
            get;
            private set;
        }

        public ICommand removeGroupCommand
        {
            get;
            private set;
        }

        public ICommand groupByAreaCommand
        {
            get;
            private set;
        }

        public ICommand saveButtonCommand
        {
            get;
            private set; 
        }

        public ICommand deleteButtonCommand
        {
            get;
            private set;
        }
    }
}
