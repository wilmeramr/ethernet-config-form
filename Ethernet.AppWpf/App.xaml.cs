using Ethernet.AppWpf.Models;
using Ethernet.AppWpf.Repositories.Implements;
using Ethernet.AppWpf.Repositories.Interfaces;
using Ethernet.AppWpf.Services;
using Ethernet.AppWpf.Stores;
using Ethernet.AppWpf.View;
using Ethernet.AppWpf.ViewModels;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Ethernet.AppWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        private  IConfiguration _configuration;

        public App()
        {
            IServiceCollection services = new ServiceCollection();


            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();

            services.Configure<ConnectionStrings>(_configuration.GetSection(nameof(ConnectionStrings)));
            //services.AddScoped<IDbConnection>(_ => new SqliteConnection(_configuration.GetConnectionString("SqlLiteConnection")));
            //SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_dynamic_cdecl());
            //services.AddSingleton<AccountStore>();
            services.AddSingleton<PeopleStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();
            services.AddSingleton<IPersona, Persona>();
            services.AddSingleton(s => CreateHomeNavigationService(s));
            services.AddSingleton<CloseModalNavigationService>();

            services.AddTransient<HomeViewModel>(s => new HomeViewModel());
            //services.AddTransient<AccountViewModel>(s => new AccountViewModel(
            //    s.GetRequiredService<AccountStore>(),
            //    CreateHomeNavigationService(s)));
            //services.AddTransient<LoginViewModel>(CreateLoginViewModel);
            services.AddTransient<PeopleListingViewModel>(s => new PeopleListingViewModel(
                s.GetRequiredService<PeopleStore>(),
                CreateAddPersonNavigationService(s),
                  s.GetRequiredService<IPersona>()
                ));
   
            services.AddTransient<AddPersonViewModel>(s => new AddPersonViewModel(
                s.GetRequiredService<PeopleStore>(),
                s.GetRequiredService<CloseModalNavigationService>()
                ));
            services.AddTransient<NavigationBarViewModel>(CreateNavigationBarViewModel);
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {

            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }
        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(
                CreateHomeNavigationService(serviceProvider),
               // CreateAccountNavigationService(serviceProvider),
                //CreateLoginNavigationService(serviceProvider),
                CreatePeopleListingNavigationService(serviceProvider));
        }
        private INavigationService CreateAddPersonNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddPersonViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddPersonViewModel>());
        }

        private INavigationService CreatePeopleListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<PeopleListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<PeopleListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
    }
}
