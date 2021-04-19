using Microsoft.EntityFrameworkCore;
using Planteskole.Domain.Models;
using Planteskole.WPF.Temporary;
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
using Planteskole.WPF.ViewModels;

namespace Planteskole.WPF.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private readonly PlantContext _context = new PlantContext();

        private CollectionViewSource PlantViewSource;
        private CollectionViewSource AreaViewSource;
        private CollectionViewSource LocationViewSource;

        public HomeView()
        {
            InitializeComponent();

            PlantViewSource = (CollectionViewSource)FindResource(nameof(PlantViewSource));
            AreaViewSource = (CollectionViewSource)FindResource(nameof(AreaViewSource));
            LocationViewSource = (CollectionViewSource)FindResource(nameof(LocationViewSource));
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //_context.Database.EnsureDeleted();

            _context.Database.EnsureCreated();

            _context.Plants.Load();
            _context.Areas.Load();
            _context.Locations.Load();

            PlantViewSource.Source = _context.Plants.Local.ToObservableCollection();
            AreaViewSource.Source = _context.Areas.Local.ToObservableCollection();
            LocationViewSource.Source = _context.Locations.Local.ToObservableCollection();

            this.StorageList.DataContext = new StorageExpandableListViewModel();
        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();

            //PlantDataGrid.Items.Refresh();
        }*/

        /*private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            if ((e.Item as DomainObject).Id == 1)
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }*/
    }
}
