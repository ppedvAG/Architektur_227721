using Microsoft.Extensions.DependencyInjection;
using ppedv.Rent_A_Wheel.Data.EfCore;
using ppedv.Rent_A_Wheel.Demodaten;
using ppedv.Rent_A_Wheel.Logic;
using ppedv.Rent_A_Wheel.Model.Contracts;
using ppedv.Rent_A_Wheel.UI.Wpf.ViewModels;
using System;
using System.Windows;

namespace ppedv.Rent_A_Wheel.UI.Wpf
{
    public sealed partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            string conString = "Server=(localdb)\\mssqllocaldb;Database=Rent-A-Wheel_dev;Trusted_Connection=true;";

            //services.AddTransient<IRepository, EfRepository>(x => new EfRepository(conString));
            services.AddTransient<IUnitOfWork, EfUnitOfWork>(x => new EfUnitOfWork(conString));

            services.AddSingleton<CarViewModel>();
            services.AddSingleton<ICarStatService, CarStatService>();
            services.AddSingleton<IDemoDatenService, DemoDataService>();

            return services.BuildServiceProvider();
        }
    }
}
