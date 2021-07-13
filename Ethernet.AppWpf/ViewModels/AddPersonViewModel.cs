using Ethernet.AppWpf.Commands;
using Ethernet.AppWpf.Services;
using Ethernet.AppWpf.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Ethernet.AppWpf.ViewModels
{
    public class AddPersonViewModel : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddPersonViewModel(PeopleStore peopleStore, INavigationService closeNavigationService)
        {
            SubmitCommand = new AddPersonCommand(this, peopleStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
