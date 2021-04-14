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
            set { _selectedItem = value; NoticeMe("SelectedItem"); ButtonAddContent = "Add"; }
        }

        private string _buttonAddContent;
        public string ButtonAddContent
        {
            get { return _buttonAddContent; }

            set { _buttonAddContent = value; NoticeMe("ButtonAddContent"); }
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
