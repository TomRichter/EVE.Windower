using Microsoft.Extensions.Logging;

namespace EVE.Windower.UI
{
    public class MainWindowViewModel
    {
        readonly ILogger<MainWindowViewModel> _logger;

        public MainWindowViewModel(ILogger<MainWindowViewModel> logger)
        {
            _logger = logger;

            _logger.LogDebug("MainWindowViewModel created.");
        }
    }
}
