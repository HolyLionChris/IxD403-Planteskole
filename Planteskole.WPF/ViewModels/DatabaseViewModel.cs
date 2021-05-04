using Microsoft.EntityFrameworkCore;
using Planteskole.Domain.Models;
using Planteskole.WPF.Commands;
using Planteskole.WPF.Temporary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Planteskole.WPF.ViewModels
{
    public class DatabaseViewModel : ViewModelBase
    {
        public ICollectionView TemplateDataGridView { get; set; }
        private readonly PlantContext _context = new PlantContext();

        public DatabaseViewModel()
        {
            _context.Templates.Load();
            IList<Template> TemplateList = _context.Templates.Local.ToObservableCollection();
            TemplateDataGridView = CollectionViewSource.GetDefaultView(TemplateList);
            TemplateDataGridView.Filter = NameFilter;

            searchButtonCommand = new SearchButtonCommand(this);

        }

        private bool NameFilter(object item)
        {
            if (String.IsNullOrEmpty(TemplateTextBox.Text))
                return true;
            else
                return ((item as Template).Name.IndexOf(TemplateTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void TemplateTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(TemplateDataGridView).Refresh();
        }


        public void SearchButton()
        {
            NameFilter
        }

        public ICommand searchButtonCommand
        {
            get;
            private set;
        }

    }
}
