using EVE.Windower.Common.Models;
using Microsoft.Extensions.Logging;
using System.Timers;

namespace EVE.Windower.Common.Services
{
    public class ProcessMonitor : IProcessMonitor
    {
        private readonly ILogger<ProcessMonitor> _logger;
        private readonly ProcessMonitorOptions _options;
        private Timer _timer;

        public ProcessMonitor(ILogger<ProcessMonitor> logger, ProcessMonitorOptions options)
        {
            _logger = logger;
            _options = options;
        }

        public void Start()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }

            _timer = new Timer()
            {
                AutoReset = true,
                Interval = _options.ScanInterval,
            };

            _timer.Elapsed += OnTick;

            _timer.Start();
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            _logger.LogInformation("aaaa");
        }
    }
}
