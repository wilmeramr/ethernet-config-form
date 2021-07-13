using Ethernet.AppWpf.Commands;
using Ethernet.AppWpf.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Ethernet.AppWpf.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        public string WelcomeMessage => "Welcome to my application.";

        public ICommand NavigateLoginCommand { get; }

        public HomeViewModel()
        {
           // NavigateLoginCommand = new NavigateCommand(loginNavigationService);
        }
    }
}
