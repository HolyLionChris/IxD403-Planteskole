﻿using Planteskole.WPF.State.Navigators;
using Planteskole.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Planteskole.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;
                    case ViewType.Add:
                        _navigator.CurrentViewModel = new AddViewModel();
                        break;
                    case ViewType.Database:
                        _navigator.CurrentViewModel = new DatabaseViewModel();
                        break;
                    case ViewType.Testing:
                        _navigator.CurrentViewModel = new TestingViewModel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}