using Ethernet.AppWpf.Commands;
using Ethernet.AppWpf.Repositories.Interfaces;
using Ethernet.AppWpf.Services;
using Ethernet.AppWpf.Stores;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Ethernet.AppWpf.ViewModels
{
    public class PeopleListingViewModel : ViewModelBase
    {
        private readonly PeopleStore _peopleStore;

        private readonly List<PersonViewModel> _people;
        private readonly IPersona _persona;
        
        public List<PersonViewModel> People => _people;

        public ICommand AddPersonCommand { get; }
        public ICommand LoadPersonCommand { get; }


        public  PeopleListingViewModel(PeopleStore peopleStore, INavigationService addPersonNavigationService, IPersona persona)
        {
            _peopleStore = peopleStore;
            _persona = persona;
            AddPersonCommand = new NavigateCommand(addPersonNavigationService);
            LoadPersonCommand = new NavigateCommand(addPersonNavigationService);
            _people = new List<PersonViewModel>();
       
            _peopleStore.PersonAdded += OnPersonAdded;


        }
        
        private void OnPersonAdded(List<PersonViewModel> personViewModels)
        {
            _people.AddRange(personViewModels);
        }
    }
}
