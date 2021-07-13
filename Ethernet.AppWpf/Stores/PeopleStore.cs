using Ethernet.AppWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ethernet.AppWpf.Stores
{
    public  class PeopleStore
    {
        public  Action<List<PersonViewModel>> PersonAdded;

        public void AddPerson(List<PersonViewModel> personViewModel)
        {
            PersonAdded?.Invoke(personViewModel);
        }
    }
}
