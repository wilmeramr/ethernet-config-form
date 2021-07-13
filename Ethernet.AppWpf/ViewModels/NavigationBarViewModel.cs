using Ethernet.AppWpf.Commands;
using Ethernet.AppWpf.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Ethernet.AppWpf.ViewModels
{
   public class NavigationBarViewModel: ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
       public ICommand NavigatePeopleListingCommand { get; }

        public NavigationBarViewModel(INavigationService homeNavigationService, INavigationService peopleListingNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigatePeopleListingCommand = new NavigateCommand(peopleListingNavigationService);

        }

        private void OnCurrentAccountChanged()
        {
          //  OnPropertyChanged(nameof(IsLoggedIn));
        }

        public override void Dispose()
        {
            //_accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}
