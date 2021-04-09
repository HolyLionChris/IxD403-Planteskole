using Microsoft.Data.Sqlite;
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

        private CollectionViewSource TemplateViewSource;

        public DatabaseView()
        {
            InitializeComponent();
            TemplateViewSource = (CollectionViewSource)FindResource(nameof(TemplateViewSource));

        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // this is for demo purposes only, to make it easier
            // to get up and running

            //Should be comment unless changes have been made to the tables
            

            // load the entities into EF Core
            _context.Templates.Load();

            // bind to the source
            TemplateViewSource.Source =
                _context.Templates.Local.ToObservableCollection();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // all changes are automatically tracked, including
            // deletes!
            _context.SaveChanges();

            // this forces the grid to refresh to latest values
            TemplateDataGrid.Items.Refresh();
        }
    }
}
