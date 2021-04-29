using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planteskole.WPF.ViewModels;
using System.Windows.Input;

namespace Planteskole.WPF.Commands
{
    class PlantGroupCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._viewModel.RemoveGroup();
        }

        private HomeViewModel _viewModel;

        public PlantGroupCommand(HomeViewModel viewModel)
        {
            this._viewModel = viewModel;
        }
    }

    public class GroupByLocationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._viewModel.GroupByLocation();
        }

        private HomeViewModel _viewModel;

        public GroupByLocationCommand(HomeViewModel viewModel)
        {
            this._viewModel = viewModel;
        }
    }
    public class RemoveGroupCommand : ICommand
    {
        #region ICommand implementation

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._viewModel.RemoveGroup();
        }

        #endregion

        private HomeViewModel _viewModel;

        public RemoveGroupCommand(HomeViewModel viewModel)
        {
            this._viewModel = viewModel;
        }
    }

    public class GroupByAreaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._viewModel.GroupByArea();
        }

        private HomeViewModel _viewModel;

        public GroupByAreaCommand(HomeViewModel viewModel)
        {
            this._viewModel = viewModel;
        }
    }

    public class SaveButtonCommand : ICommand
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

        private HomeViewModel _viewModel;

        public SaveButtonCommand(HomeViewModel viewModel)
        {
            this._viewModel = viewModel;
        }
    }

    public class DeleteButtonCommand : ICommand
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

        private HomeViewModel _viewModel;

        public DeleteButtonCommand(HomeViewModel viewModel)
        {
            this._viewModel = viewModel;
        }
    }

}