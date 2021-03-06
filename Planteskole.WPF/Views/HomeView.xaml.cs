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
using Planteskole.WPF.Commands;

namespace Planteskole.WPF.Views
{
  
    public partial class HomeView : UserControl
    {

        public HomeView()
        {
            InitializeComponent();
            //PlantViewSource = (CollectionViewSource)FindResource(nameof(PlantViewSource));
            DataContext = new ViewModels.HomeViewModel();

        }

        public HomeViewModel HomeViewModel
        {
            get => default;
            set
            {
            }
        }

        private void Button_Click_Print(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void OnTargetUpdated(object sender, DataTransferEventArgs args)
        {
            var ctx = (HomeViewModel)this.DataContext;
            ctx.AutoSave();
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
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
