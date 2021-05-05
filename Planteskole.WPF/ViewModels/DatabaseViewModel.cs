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

        private string templateTextBox;
        public string TemplateTextBox
        {
            get { return this.templateTextBox; }
            set
            {
                if (!string.Equals(this.templateTextBox, value))
                {
                    this.templateTextBox = value;
                }
            }
        } //Takes the Textbox "TemplateTextBox" and makes it accessble in the viewmodel

        public DatabaseViewModel()
        {
            _context.Templates.Load();
            IList<Template> TemplateList = _context.Templates.Local.ToObservableCollection();
            TemplateDataGridView = CollectionViewSource.GetDefaultView(TemplateList);

            searchButtonDatabaseCommand = new SearchButtonDatabaseCommand(this);
            saveButtonDatabaseCommand = new SaveButtonDatabaseCommand(this);
        }

        private bool NameFilter(object item)
        {
            if (String.IsNullOrEmpty(TemplateTextBox))
                return true;
            else
                return ((item as Template).Name.IndexOf(TemplateTextBox, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public void SearchDatabaseButton()
        {
            TemplateDataGridView.Filter = NameFilter;
        }

        public void SaveDatabaseButton()
        {
            _context.SaveChanges();
            TemplateDataGridView.Refresh();
        }

        public ICommand searchButtonDatabaseCommand
        {
            get;
            private set;
        }

        public ICommand saveButtonDatabaseCommand
        {
            get;
            private set;
        }

    }
}
