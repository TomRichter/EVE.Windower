using System.Diagnostics;

namespace EVE.Windower.Common.Models
{
    /// <summary>
    /// Wrapper around a running system process.
    /// </summary>
    public class ProcessInfo
    {
        private readonly Process _process;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessInfo"/> class.
        /// </summary>
        public ProcessInfo(Process process)
        {
            _process = process;
        }
    }
}
