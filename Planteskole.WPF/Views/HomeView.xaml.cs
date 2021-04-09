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

namespace Planteskole.WPF.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private readonly PlantContext _context = new PlantContext();

        private CollectionViewSource PlantViewSource;

        public HomeView()
        {
            InitializeComponent();

            PlantViewSource = (CollectionViewSource)FindResource(nameof(PlantViewSource));
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //_context.Database.EnsureDeleted();

            _context.Database.EnsureCreated();

            _context.Plants.Load();

            PlantViewSource.Source = _context.Plants.Local.ToObservableCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();

            PlantDataGrid.Items.Refresh();
        }
    }
}
