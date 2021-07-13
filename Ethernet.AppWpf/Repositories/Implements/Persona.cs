using Dapper;
using Ethernet.AppWpf.Models;
using Ethernet.AppWpf.Repositories.Interfaces;
using Ethernet.AppWpf.ViewModels;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethernet.AppWpf.Repositories.Implements
{
    public class Persona : IPersona
    {

        private readonly IOptions<ConnectionStrings> _connectionStrings;
        public Persona(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }
        public async Task<List<PersonViewModel>> InsertPerson(string name)
        {
            try
            {
                string sql = $"select * from personas";
                using var connection = new SqliteConnection(_connectionStrings.Value.SqlLiteConnection);
              var resul =   await connection.QueryAsync<PersonViewModel>("SELECT nombre FROM personas;");

                return resul.ToList();
             //  await connection.ExecuteAsync(sql);
                // await _dbConnection.ExecuteAsync(sql);
            }
            catch (Exception ex)
            {

                throw;
            }
      
     

        }
    }
}
