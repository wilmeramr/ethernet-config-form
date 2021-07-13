using Ethernet.AppWpf.Repositories.Interfaces;
using Ethernet.AppWpf.Services;
using Ethernet.AppWpf.Stores;
using Ethernet.AppWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ethernet.AppWpf.Commands
{
    public class LoadPersonCommand : CommandBase
    {
        private readonly PeopleListingViewModel _addPersonViewModel;
        private readonly PeopleStore _peopleStore;
        private readonly INavigationService _navigationService;
        private readonly IPersona _persona;


        public LoadPersonCommand(PeopleListingViewModel addPersonViewModel, PeopleStore peopleStore, INavigationService navigationService, IPersona persona)
        {
            _addPersonViewModel = addPersonViewModel;
            _peopleStore = peopleStore;
            _persona = persona;
            _navigationService = navigationService;
        }

        public override async void Execute(object parameter)
        {
            var result= await _persona.InsertPerson("wilmer");
            _peopleStore.AddPerson(result);
           _navigationService.Navigate();
        }


    }
 

}
