﻿using EVE.Windower.Common.Options;
using EVE.Windower.Common.Services;
using EVE.Windower.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Serilog;
using Serilog.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace EVE.Windower
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly AssemblyName assembly = Assembly.GetExecutingAssembly().GetName();

        private IServiceProvider _services;

        /// <summary>
        /// Main entry point for the program.
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IConfiguration config = BuildConfiguration();
            StartLogger(config);
            _services = BuildServiceProvider(config);

            Current.MainWindow = _services.GetService<MainWindow>();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Inflates configuration object from configuration sources.
        /// </summary>
        /// <returns>Configuration</returns>
        private IConfiguration BuildConfiguration()
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: false);

            return configBuilder.Build();
        }

        /// <summary>
        /// Creates logging provider and writes basic info to beginning of log.
        /// </summary>
        /// <param name="config">Application configuration</param>
        private void StartLogger(IConfiguration config)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Verbose()
                .WriteTo.File($"Logs/{assembly.Name}_{DateTime.Now:yyy-MM-dd_HH-mm-ss}.log",
                    restrictedToMinimumLevel: LevelConvert.ToSerilogLevel(config.GetValue<LogLevel>("Logging:LogLevel:File")),
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{SourceContext:l}] {Message:lj}{NewLine}{Exception}",
                    // Auto-split logs that get too large; "exe-datetime_#.log"
                    // Max 7 MB logs to work with Discord's 8 MB file size limits
                    rollOnFileSizeLimit: true,
                    fileSizeLimitBytes: 7_340_032
                )
                .WriteTo.Console(
                    restrictedToMinimumLevel: LevelConvert.ToSerilogLevel(config.GetValue<LogLevel>("Logging:LogLevel:Default")),
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{SourceContext:l}] {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();

            Log.Information("{Name} v{Version}", assembly.Name, assembly.Version);
            Log.Information("Working Directory: {Dir}", Directory.GetCurrentDirectory());
            Log.Information("CLI Call: {Args}", Environment.CommandLine);
        }

        /// <summary>
        /// Configures and builds dependency injection service provider.
        /// </summary>
        /// <param name="config">Application configuration</param>
        /// <returns>Service provider</returns>
        private IServiceProvider BuildServiceProvider(IConfiguration config)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging(logging =>
            {
                logging.AddConfiguration(config.GetSection("Logging"));
                logging.AddSerilog(dispose: true);
            });

            services.AddScoped<MainWindow>();
            services.AddScoped<MainWindowViewModel>();

            services.Configure<ProcessMonitorOptions>(config.GetSection("ProcessMonitor"));
            services.AddScoped<IProcessMonitor, ProcessMonitor>();

            return services.BuildServiceProvider();
        }
    }
}
