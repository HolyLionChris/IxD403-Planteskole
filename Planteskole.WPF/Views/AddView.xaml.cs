using Microsoft.EntityFrameworkCore;
using Planteskole.WPF.Temporary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Planteskole.Domain.Models;
using System.ComponentModel;

namespace Planteskole.WPF.Views
{
    /// <summary>
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView : UserControl 
    {
        private readonly PlantContext _context = new PlantContext();


        public AddView()
        {
            InitializeComponent();
        }

        public ViewModels.AddViewModel AddViewModel
        {
            get => default;
            set
            {
            }
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
            if (StackPanelInfoPlant.IsVisible == true)
            {
                //_context.Plants.Remove((Plant)PlantViewSource.View.CurrentItem);
            }
            else if (StackPanelInfoLocation.IsVisible == true)
            {
                //_context.Locations.Remove((Location)LocationViewSource.View.CurrentItem);
            }
            else if (StackPanelInfoArea.IsVisible == true)
            {
                //_context.Areas.Remove((Area)AreaViewSource.View.CurrentItem);
            }
            //_context.SaveChanges();
            PlantDataGrid.Items.Refresh();

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
        private void DataGridCell_Selected(object sender, RoutedEventArgs e)
        {
            // Lookup for the source to be DataGridCell
            if (e.OriginalSource.GetType() == typeof(DataGridCell))
            {
                // Starts the Edit on the row;
                DataGrid grd = (DataGrid)sender;
                grd.BeginEdit(e);
            }
        }

        private void OnTargetUpdated(object sender, DataTransferEventArgs args)
        {
            _context.SaveChanges();
        }
    }
}
