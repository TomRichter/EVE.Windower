using EVE.Windower.Common.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EVE.Windower.Common.Options
{
    /// <summary>
    /// Adds options under a standard field name.
    /// </summary>
    public abstract class AbstractLoggableWithOptions : AbstractLoggable
    {
        /// <summary>
        /// Tracks the live state of <see cref="Options.ProcessMonitorOptions"/> in settings file, env vars, etc.
        /// </summary>
        private readonly IOptionsMonitor<ProcessMonitorOptions> _processMonitorOptionsMonitor;

        /// <summary>
        /// Gets the current values for <see cref="Options.ProcessMonitorOptions"/>.
        /// </summary>
        protected ProcessMonitorOptions ProcessMonitorOptions => _processMonitorOptionsMonitor.CurrentValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractLoggableWithOptions"/> class.
        /// </summary>
        public AbstractLoggableWithOptions(
            ILogger logger,
            IOptionsMonitor<ProcessMonitorOptions> faithOptionsMonitor
        ) : base(logger)
        {
            _processMonitorOptionsMonitor = faithOptionsMonitor;
        }
    }
}
