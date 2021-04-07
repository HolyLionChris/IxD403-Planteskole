using Microsoft.EntityFrameworkCore;
using Planteskole.WPF.Temporary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for DatabaseView.xaml
    /// </summary>
    public partial class DatabaseView : UserControl
    {
        private readonly PlantContext _context = new PlantContext();

        private CollectionViewSource categoryViewSource;
        private CollectionViewSource categoryProductsViewSource;

        public DatabaseView()
        {
            InitializeComponent();
            categoryViewSource =
                (CollectionViewSource)FindResource(nameof(categoryViewSource));
            categoryProductsViewSource =
                (CollectionViewSource)FindResource(nameof(categoryProductsViewSource));
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // this is for demo purposes only, to make it easier
            // to get up and running
            _context.Database.EnsureCreated();

            // load the entities into EF Core
            _context.Templates.Load();
            _context.Plants.Load();

            // bind to the source
            categoryViewSource.Source =
                _context.Templates.Local.ToObservableCollection();
            categoryProductsViewSource.Source =
                _context.Plants.Local.ToObservableCollection();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // all changes are automatically tracked, including
            // deletes!
            _context.SaveChanges();

            // this forces the grid to refresh to latest values
            categoryDataGrid.Items.Refresh();
            productsDataGrid.Items.Refresh();
        }

        //protected override void OnClosing(CancelEventArgs e)
        //{
            // clean up database connections
            //_context.Dispose();
            //base.OnClosing(e);
        //}
    }
}
