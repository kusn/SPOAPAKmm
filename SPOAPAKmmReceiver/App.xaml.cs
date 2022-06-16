using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SPOAPAKmmReceiver.Data;
using SPOAPAKmmReceiver.Data.Stores.InDb;
using SPOAPAKmmReceiver.Interfaces;
using SPOAPAKmmReceiver.Models;
using SPOAPAKmmReceiver.ViewModels;

namespace SPOAPAKmmReceiver
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost _hosting;

        public static IServiceProvider Services => Hosting.Services;

        public static IHost Hosting => _hosting
            ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)                
                .ConfigureAppConfiguration(opt => opt.AddJsonFile("appsettings.json", true, true))
                .ConfigureServices(ConfigureServices);
        
        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddDbContext<SPOAPAKmmDB>(opt => opt.UseSqlite(host.Configuration.GetConnectionString("Default")));
            services.AddTransient<DbInitializer>();
            services.AddScoped(typeof(IStore<>), typeof(DbStore<>));

            services.AddScoped<MainWindowViewModel>();
            services.AddScoped<SettingsWindowViewModel>();

            services.Configure<InstrumentSettings>(InstrumentSettings.Generator, host.Configuration.GetSection("InstrumentSettings:Generator"));
            services.Configure<InstrumentSettings>(InstrumentSettings.Receiver, host.Configuration.GetSection("InstrumentSettings:Receiver"));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (var scope = Services.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
                initializer.InitializeAsync().Wait();
            }

            base.OnStartup(e);
        }
    }
}
