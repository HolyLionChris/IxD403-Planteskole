﻿using Planteskole.Domain.Models;
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
    public class OrdersViewModel : ViewModelBase
    {
        public ICollectionView OrdersView { get; set; }

        private readonly PlantContext _context = new PlantContext();

        public OrdersViewModel()
        {
            _context.Plants.Load();
            IList<Plant> plants = _context.Plants.Local.ToObservableCollection();
            OrdersView = CollectionViewSource.GetDefaultView(plants);
            OrdersView.GroupDescriptions.Add(new PropertyGroupDescription("noGroup"));

            groupByCustomerCommand = new GroupByCustomerCommand(this); //OrderGroupCommand.cs
            groupByAreaCommand = new GroupByAreaCommand(this); 
            removeGroupCommand = new RemoveGroupCommand(this);
            saveButtonCommand = new SaveButtonCommand(this);
            deleteButtonCommand = new DeleteButtonCommand(this);


        }

        public void RemoveGroup()
        {
            OrdersView.GroupDescriptions.Clear();
            OrdersView.GroupDescriptions.Add(new PropertyGroupDescription("noGroup"));
        }

        public void GroupByCustomer()
        {
            OrdersView.GroupDescriptions.Clear();
            OrdersView.GroupDescriptions.Add(new PropertyGroupDescription("Location"));
        }

        public void GroupByArea()
        {
            OrdersView.GroupDescriptions.Clear();
            OrdersView.GroupDescriptions.Add(new PropertyGroupDescription("Area"));
        }

        public void SaveButton()
        {
            _context.SaveChanges();
        }

        public void DeleteButton()
        {
            _context.Plants.Remove((Plant)OrdersView.CurrentItem);
            _context.SaveChanges();
        }
        //We can just add more to get more different groupings, such as date added which can be automated

        public ICommand groupByCustomerCommand
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
