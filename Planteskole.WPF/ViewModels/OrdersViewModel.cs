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



namespace Planteskole.WPF.ViewModels
{
    public class OrdersViewModel : ViewModelBase
    {
        public ICollectionView OrdersView { get; set; }

        public OrdersViewModel()
        {
            IList<Plant> plants = new Plants();
            OrdersView = CollectionViewSource.GetDefaultView(plants);
            OrdersView.GroupDescriptions.Add(new PropertyGroupDescription("noGroup"));

            groupByCustomerCommand = new GroupByCustomerCommand(this);
            removeGroupCommand = new RemoveGroupCommand(this);

        }

        public void RemoveGroup()
        {
            OrdersView.GroupDescriptions.Clear();
            OrdersView.GroupDescriptions.Add(new PropertyGroupDescription("noGroup"));
        }

        public void GroupByCustomer()
        {
            OrdersView.GroupDescriptions.Clear();
            OrdersView.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
        }

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
