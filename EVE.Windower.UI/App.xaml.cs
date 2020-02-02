using Autofac;
using Autofac.Extensions.DependencyInjection;
using EVE.Windower.UI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace EVE.Windower
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _services;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _services = ConfigureServiceProvider();

            Current.MainWindow = _services.GetService<MainWindow>();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures dependency injection service provider.
        /// </summary>
        /// <returns>Configured service provider.</returns>
        private IServiceProvider ConfigureServiceProvider()
        {
            // Register Microsoft.Extensions-compatible types
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();

            // Populate above into Autofac container
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);

            // Register custom types here (will override types registered above!)
            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<MainWindowViewModel>();

            // Build service provider
            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            return serviceProvider;
        }
    }
}
