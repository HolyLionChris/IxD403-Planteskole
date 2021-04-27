using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planteskole.WPF.ViewModels;
using System.Windows.Input;

namespace Planteskole.WPF.Commands
{
    class OrderGroupCommand : ICommand
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

        private OrdersViewModel _viewModel;

        public OrderGroupCommand(OrdersViewModel viewModel)
        {
            this._viewModel = viewModel;
        }
    }

    public class GroupByCustomerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._viewModel.GroupByCustomer();
        }

        private OrdersViewModel _viewModel;

        public GroupByCustomerCommand(OrdersViewModel viewModel)
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

        private OrdersViewModel _viewModel;

        public RemoveGroupCommand(OrdersViewModel viewModel)
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

        private OrdersViewModel _viewModel;

        public GroupByAreaCommand(OrdersViewModel viewModel)
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

        private OrdersViewModel _viewModel;

        public SaveButtonCommand(OrdersViewModel viewModel)
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

        private OrdersViewModel _viewModel;

        public DeleteButtonCommand(OrdersViewModel viewModel)
        {
            this._viewModel = viewModel;
        }
    }
}