using EVE.Windower.Common.Logging;
using EVE.Windower.Common.Services;
using Microsoft.Extensions.Logging;

namespace EVE.Windower.UI
{
    /// <summary>
    /// ViewModel behind the <see cref="MainWindow"/>.
    /// </summary>
    public class MainWindowViewModel : AbstractLoggable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel(
            ILogger<MainWindowViewModel> logger,
            IProcessMonitor procMon
        ) : base(logger)
        {
            procMon.StartMonitoring();
        }
    }
}
