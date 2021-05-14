using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planteskole.WPF.ViewModels;
using System.Windows.Input;

namespace Planteskole.WPF.Commands
{
    class AddViewCommands : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public class AddSaveButtonCommand : ICommand
        {

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                this._viewModel.SaveButton();
            }

            private AddViewModel _viewModel;

            public AddSaveButtonCommand(AddViewModel viewModel)
            {
                this._viewModel = viewModel;
            }
        }

        public class AddDeleteButtonCommand : ICommand
        {

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                this._viewModel.DeleteButton();
            }

            private AddViewModel _viewModel;

            public AddDeleteButtonCommand(AddViewModel viewModel)
            {
                this._viewModel = viewModel;
            }
        }
    }
}
