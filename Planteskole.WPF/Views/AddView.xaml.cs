using Microsoft.EntityFrameworkCore;
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
using Planteskole.Domain;
using Planteskole.WPF.ViewModels;
using Planteskole.WPF.Models;
using Planteskole.WPF.Commands;
using Planteskole.Domain.Models;

namespace Planteskole.WPF.Views
{
    /// <summary>
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView : UserControl
    {
        private readonly PlantContext _context = new PlantContext();

        private CollectionViewSource PlantViewSource;

        public AddView()
        {
            InitializeComponent();
            PlantViewSource = (CollectionViewSource)FindResource(nameof(PlantViewSource));

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
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // all changes are automatically tracked, including
            // deletes!
            _context.SaveChanges();

            // this forces the grid to refresh to latest values
            PlantDataGrid.Items.Refresh();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            _context.Plants.Remove((Plant)PlantViewSource.View.CurrentItem);
            _context.SaveChanges();
            //PlantDataGrid.Items.Refresh();

        }
    }
}
