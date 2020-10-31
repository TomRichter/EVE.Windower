using EVE.Windower.Common.Services;

namespace EVE.Windower.Common.Options
{
    /// <summary>
    /// Strongly-typed options for the <see cref="IProcessMonitor"/>.
    /// </summary>
    public class ProcessMonitorOptions
    {
        /// <summary>
        /// How often new processes are scanned for, in milliseconds.
        /// </summary>
        public int ScanInterval { get; set; }

        /// <summary>
        /// Process name to scan for.
        /// </summary>
        public string ProcessName { get; set; }
    }
}
