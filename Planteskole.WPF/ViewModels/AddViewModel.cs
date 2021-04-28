using Planteskole.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planteskole.WPF.ViewModels
{
    public class AddViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private Plant _selectedItem;
        public Plant SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; NoticeMe("SelectedItem");}
        }
        private Location _selectedItemLocation;
        public Location SelectedItemLocation
        {
            get { return _selectedItemLocation; }
            set { _selectedItemLocation = value; NoticeMe("SelectedItemLocation"); }
        }
        private Area _selectedItemArea;
        public Area SelectedItemArea
        {
            get { return _selectedItemArea; }
            set { _selectedItemArea = value; NoticeMe("SelectedItemArea"); }
        }









        protected void NoticeMe(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
