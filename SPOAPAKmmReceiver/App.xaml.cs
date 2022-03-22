using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SPOAPAKmmReceiver.ViewModels;

namespace SPOAPAKmmReceiver
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost? _hosting;

        public static IServiceProvider Services => Hosting.Services;
        public static IHost Hosting => _hosting
            ??= Host.CreateDefaultBuilder(Environment.GetCommandLineArgs())
                .ConfigureHostConfiguration(cfg => cfg
                    .AddJsonFile("appconfig.json", true, true))
                .ConfigureAppConfiguration(cfg => cfg.AddJsonFile("appconfig.json", true, true))
                .ConfigureServices(ConfigureServices)
            .Build();

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();

            var path = host.Configuration.GetConnectionString("Default");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }
}
