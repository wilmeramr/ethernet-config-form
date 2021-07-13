using System;
using System.Collections.Generic;
using System.Text;

namespace Ethernet.AppWpf.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        public string nombre { get; }

        public PersonViewModel(string Nombre)
        {
            nombre = Nombre;
        }
    }
}
