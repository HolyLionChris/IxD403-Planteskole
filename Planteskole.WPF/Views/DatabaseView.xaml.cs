using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Planteskole.Domain.Models;
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

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Templates.Load();

            TemplateViewSource.Source = _context.Templates.Local.ToObservableCollection();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();

            TemplateDataGrid.Items.Refresh();
        }
    }
}
