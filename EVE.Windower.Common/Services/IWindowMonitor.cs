using EVE.Windower.Common.Models;

namespace EVE.Windower.Common.Services
{
    internal interface IWindowMonitor
    {
        /// <summary>
        /// Event fired when window title gets changed.
        /// </summary>
        /// <param name="window">Renamed window</param>
        public delegate void WindowRenamed(WindowInfo window);

        /// <summary>
        /// Event fired when window gets moved.
        /// </summary>
        /// <param name="window">Moved window</param>
        public delegate void WindowMoved(WindowInfo window);

        /// <summary>
        /// Event fired when window gets resized.
        /// </summary>
        /// <param name="window">Resized window</param>
        public delegate void WindowResized(WindowInfo window);

        /// <summary>
        /// Event fired when window becomes focused (e.g., alt-tabbed to).
        /// </summary>
        /// <param name="window">Focused window</param>
        public delegate void WindowFocused(WindowInfo window);

        /// <summary>
        /// Event fired when window becomes unfocused (e.g., alt-tabbed away from).
        /// </summary>
        /// <param name="window">Unfocused window</param>
        public delegate void WindowUnfocused(WindowInfo window);
    }
}
