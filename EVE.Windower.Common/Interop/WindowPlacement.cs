using System.Drawing;
using System.Runtime.InteropServices;

namespace EVE.Windower.Common.Interop
{
    /// <summary>
    /// Contains information about the placement of a window on the screen.
    /// </summary>
    /// <remarks><a href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-windowplacement"/></remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowPlacement
    {
        /// <summary>
        /// The length of the structure, in bytes. Before calling the <see cref="User32.GetWindowPlacement"/>
        /// or <see cref="User32.SetWindowPlacement"/> functions, set this member to
        /// <see langword="sizeof"/>(<see cref="WindowPlacement"/>).
        /// </summary>
        public uint length;

        /// <summary>
        /// The flags that control the position of the minimized window and the method by which the window is restored.
        /// </summary>
        public uint flags;

        /// <summary>
        /// The current show state of the window.
        /// </summary>
        public ShowWindowCmd showCmd;

        /// <summary>
        /// The coordinates of the window's upper-left corner when the window is minimized.
        /// </summary>
        public Point ptMinPosition;

        /// <summary>
        /// The coordinates of the window's upper-left corner when the window is maximized.
        /// </summary>
        public Point ptMaxPosition;

        /// <summary>
        /// The window's coordinates when the window is in the restored position.
        /// </summary>
        public Rect rcNormalPosition;

        /// <summary>
        /// 
        /// </summary>
        public Rect rcDevice;
    }
}
