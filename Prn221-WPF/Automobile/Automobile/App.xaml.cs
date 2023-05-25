﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Automobile.Repository;

namespace Automobile
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(typeof(ICarRepository), typeof(CarRepository));
            services.AddSingleton<MainWindow>();
        }

        private void OnStartUp(object sender, StartupEventArgs e)
        {
            var window = serviceProvider.GetService<MainWindow>();
            window.Show();
        }

    }
}
