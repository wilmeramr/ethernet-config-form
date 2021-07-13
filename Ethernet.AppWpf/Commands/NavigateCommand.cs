using Ethernet.AppWpf.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ethernet.AppWpf.Commands
{
    public class NavigateCommand: CommandBase
    {
        private readonly INavigationService _navigationService;

        public NavigateCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
