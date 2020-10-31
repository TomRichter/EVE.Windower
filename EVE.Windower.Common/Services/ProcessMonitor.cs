using EVE.Windower.Common.Localization;
using EVE.Windower.Common.Models;
using EVE.Windower.Common.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;

namespace EVE.Windower.Common.Services
{
    /// <summary>
    /// Keeps track of relevant system processes and emits events when they start or end.
    /// </summary>
    public class ProcessMonitor : AbstractLoggableWithOptions, IProcessMonitor
    {
        private readonly Dictionary<int, ProcessInfo> _knownProcesses;

        private Timer _timer;

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
        /// Initializes a new instance of the <see cref="ProcessMonitor"/> class.
        /// </summary>
        public ProcessMonitor(
            ILogger<ProcessMonitor> logger,
            IOptionsMonitor<ProcessMonitorOptions> procMonOptionsMonitor
        ) : base(logger, procMonOptionsMonitor)
        {
            _knownProcesses = new Dictionary<int, ProcessInfo>(64);
        }

        /// <inheritdoc/>
        public void StartMonitoring()
        {
            StopMonitoring();

            _timer = new Timer()
            {
                AutoReset = true,
                Interval = ProcessMonitorOptions.ScanInterval,
            };

            _timer.Elapsed += OnTick;
            _timer.Start();

            Logger.LogInformation(Translations.LOG_PROCMON_STARTED);
        }

        /// <inheritdoc/>
        public void StopMonitoring()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();

                Logger.LogInformation(Translations.LOG_PROCMON_STOPPED);
            }
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            Logger.LogTrace(Translations.LOG_PROCMON_TICKED);

            Process[] freshProcesses = Process.GetProcessesByName(ProcessMonitorOptions.ProcessName);

            foreach (Process process in freshProcesses)
            {
                if (_knownProcesses.ContainsKey(process.Id))
                {
                    // Check for process/window updates
                    // Emit events as needed
                }
                // Wait for new windows to be fully loaded
                else if (process.MainWindowHandle != IntPtr.Zero)
                {
                    process.EnableRaisingEvents = true;
                    process.Exited += OnProcessExited;

                    _knownProcesses.Add(process.Id, new ProcessInfo(process));

                    Logger.LogInformation(Translations.LOG_PROCMON_ADDED, process.MainWindowTitle, process.MainModule.FileName);
                }
            }
        }

        private void OnProcessExited(object sender, System.EventArgs e)
        {
            Process process = (Process)sender;
            _knownProcesses.Remove(process.Id);

            Logger.LogInformation(Translations.LOG_PROCMON_REMOVED, process.MainWindowTitle, process.ProcessName);
        }

        /// <inheritdoc/>
        public ProcessInfo StartProcess()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public void ExitProcess(ProcessInfo process)
        {
            throw new System.NotImplementedException();
        }
    }
}
