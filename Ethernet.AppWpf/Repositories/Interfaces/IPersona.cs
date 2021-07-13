using Ethernet.AppWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Ethernet.AppWpf.Repositories.Interfaces
{
    public interface IPersona
    {

        Task<List<PersonViewModel>> InsertPerson(string name);
    }
}
