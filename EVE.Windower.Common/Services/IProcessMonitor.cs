using EVE.Windower.Common.Models;

namespace EVE.Windower.Common.Services
{
    /// <summary>
    /// Keeps track of relevant system processes and emits events when they start or end.
    /// </summary>
    public interface IProcessMonitor
    {
        /// <summary>
        /// Event fired when a new process has started.
        /// </summary>
        /// <param name="process">Process that started.</param>
        public delegate void ProcessStarted(ProcessInfo process);

        /// <summary>
        /// Event fired when a process has exited.
        /// </summary>
        /// <param name="process">Process that exited.</param>
        public delegate void ProcessExited(ProcessInfo process);

        /// <summary>
        /// Starts monitoring system processes in a separate thread.
        /// </summary>
        public void StartMonitoring();

        /// <summary>
        /// Stops monitoring system processes.
        /// </summary>
        public void StopMonitoring();
    }
}
