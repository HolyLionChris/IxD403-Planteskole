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
  
    public partial class HomeView : UserControl
    {
        

        
        public HomeView()
        {
            InitializeComponent();
            //PlantViewSource = (CollectionViewSource)FindResource(nameof(PlantViewSource));
            DataContext = new ViewModels.HomeViewModel();


        }
        
    }
}
