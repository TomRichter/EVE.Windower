using EVE.Windower.Common.Logging;
using EVE.Windower.Common.Services;
using Microsoft.Extensions.Logging;

namespace EVE.Windower.UI
{
    public class MainWindowViewModel : AbstractLoggable
    {
        public MainWindowViewModel(
            ILogger<MainWindowViewModel> logger,
            IProcessMonitor procMon
        ) : base(logger)
        {
            procMon.StartMonitoring();
        }
    }
}
