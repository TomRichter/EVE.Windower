using Microsoft.Extensions.Logging;

namespace EVE.Windower.UI
{
    public class MainWindowViewModel
    {
        private readonly ILogger<MainWindowViewModel> _logger;

        public MainWindowViewModel(ILogger<MainWindowViewModel> logger)
        {
            _logger = logger;
        }
    }
}
