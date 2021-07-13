using Ethernet.AppWpf.Services;
using Ethernet.AppWpf.Stores;
using Ethernet.AppWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ethernet.AppWpf.Commands
{
    public class AddPersonCommand : CommandBase
    {
        private readonly AddPersonViewModel _addPersonViewModel;
        private readonly PeopleStore _peopleStore;
        private readonly INavigationService _navigationService;

        public AddPersonCommand(AddPersonViewModel addPersonViewModel, PeopleStore peopleStore, INavigationService navigationService)
        {
            _addPersonViewModel = addPersonViewModel;
            _peopleStore = peopleStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            string name = _addPersonViewModel.Name;
            _peopleStore.AddPerson(new List<PersonViewModel>() { new PersonViewModel(name) });

            _navigationService.Navigate();
        }
    }
}
