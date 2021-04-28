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
            _context.Plants.Load();
            IList<Plant> plants = _context.Plants.Local.ToObservableCollection();
            HomeView = CollectionViewSource.GetDefaultView(plants);
            //OrdersView.GroupDescriptions.Add(new PropertyGroupDescription("noGroup"));

            groupByLocationCommand = new GroupByLocationCommand(this); //OrderGroupCommand.cs
            groupByAreaCommand = new GroupByAreaCommand(this); 
            removeGroupCommand = new RemoveGroupCommand(this);
            saveButtonCommand = new SaveButtonCommand(this);
            deleteButtonCommand = new DeleteButtonCommand(this);

            HomeView.GroupDescriptions.Add(new PropertyGroupDescription("Area"));
            HomeView.GroupDescriptions.Add(new PropertyGroupDescription("Location"));

        }

        public void RemoveGroup()
        {
            HomeView.GroupDescriptions.Clear();
            HomeView.GroupDescriptions.Add(new PropertyGroupDescription("noGroup"));
        }

        public void GroupByLocation()
        {
            HomeView.GroupDescriptions.Clear();
            HomeView.GroupDescriptions.Add(new PropertyGroupDescription("Area"));
            HomeView.GroupDescriptions.Add(new PropertyGroupDescription("Location"));
        }

        public void GroupByArea()
        {
            HomeView.GroupDescriptions.Clear();
            HomeView.GroupDescriptions.Add(new PropertyGroupDescription("Area"));
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
    public class GroupsToTotalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is ReadOnlyObservableCollection<object>)
            {
                var items = (ReadOnlyObservableCollection<object>)value;
                Decimal total = 0;
                foreach (Plant element in items)
                {
                    total += element.Amount;
                }
                return total.ToString();
            }
           
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
