using Microsoft.EntityFrameworkCore;
using Planteskole.WPF.Temporary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Planteskole.Domain.Models;

namespace Planteskole.WPF.Views
{
    /// <summary>
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView : UserControl
    {
        private readonly PlantContext _context = new PlantContext();

        private CollectionViewSource PlantViewSource, LocationViewSource, AreaViewSource;

        public AddView()
        {
            InitializeComponent();
            
            PlantViewSource = (CollectionViewSource)FindResource(nameof(PlantViewSource));
            LocationViewSource = (CollectionViewSource)FindResource(nameof(LocationViewSource));
            AreaViewSource = (CollectionViewSource)FindResource(nameof(AreaViewSource));

        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // this is for demo purposes only, to make it easier
            // to get up and running

            //Should be comment unless changes have been made to the tables


            // load the entities into EF Core
            _context.Plants.Load();

            // bind to the source
            PlantViewSource.Source = _context.Plants.Local.ToObservableCollection();

            _context.Locations.Load();
            LocationViewSource.Source = _context.Locations.Local.ToObservableCollection();

            _context.Areas.Load();
            AreaViewSource.Source = _context.Areas.Local.ToObservableCollection();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // all changes are automatically tracked, including
            // deletes!
            _context.SaveChanges();

            // this forces the grid to refresh to latest values
            PlantDataGrid.Items.Refresh();
            LocationDataGrid.Items.Refresh();
            AreaDataGrid.Items.Refresh();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            _context.Plants.Remove((Plant)PlantViewSource.View.CurrentItem);
            _context.SaveChanges();
            //PlantDataGrid.Items.Refresh();

        }
        private void TogglingButtonClicked(object sender, RoutedEventArgs e)
        {
            this.StackPanelInfoPlant.Visibility = Visibility.Visible;
            this.StackPanelInfoArea.Visibility = Visibility.Collapsed;
            this.StackPanelInfoLocation.Visibility = Visibility.Collapsed;
            this.PlantDataGrid.Visibility = Visibility.Visible;
            this.LocationDataGrid.Visibility = Visibility.Collapsed;
            this.AreaDataGrid.Visibility = Visibility.Collapsed;
            PlantDataGrid.Items.Refresh();
            LocationDataGrid.Items.Refresh();
            AreaDataGrid.Items.Refresh();
        }


        private void TogglingButtonClickedArea(object sender, RoutedEventArgs e)
        {
            this.StackPanelInfoPlant.Visibility = Visibility.Collapsed;
            this.StackPanelInfoLocation.Visibility = Visibility.Collapsed;
            this.StackPanelInfoArea.Visibility = Visibility.Visible;
            this.AreaDataGrid.Visibility = Visibility.Visible;
            this.PlantDataGrid.Visibility = Visibility.Collapsed;
            this.LocationDataGrid.Visibility = Visibility.Collapsed;
            PlantDataGrid.Items.Refresh();
            LocationDataGrid.Items.Refresh();
            AreaDataGrid.Items.Refresh();
        }
        private void TogglingButtonClickedLocation(object sender, RoutedEventArgs e)
        {
            this.StackPanelInfoPlant.Visibility = Visibility.Collapsed;
            this.StackPanelInfoArea.Visibility = Visibility.Collapsed;
            this.StackPanelInfoLocation.Visibility = Visibility.Visible;
            this.LocationDataGrid.Visibility = Visibility.Visible;
            this.PlantDataGrid.Visibility = Visibility.Collapsed;
            this.AreaDataGrid.Visibility = Visibility.Collapsed;
            PlantDataGrid.Items.Refresh();
            LocationDataGrid.Items.Refresh();
            AreaDataGrid.Items.Refresh();
        }
    }
}
