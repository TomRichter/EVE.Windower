using System;
using System.Runtime.InteropServices;

namespace EVE.Windower.Common.Interop
{
    /// <summary>
    /// Native methods from user32.dll, primarily for window manipulation.
    /// </summary>
    public static class User32
    {
        /// <summary>
        /// Retrieves a handle to the foreground window (the window with which the user is currently working).
        /// The system assigns a slightly higher priority to the thread that creates the foreground window
        /// than it does to other threads.
        /// </summary>
        /// <returns>Foreground window handle.</returns>
        /// <remarks><a href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getforegroundwindow"/></remarks>
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// Brings the thread that created the specified window into the foreground and activates the window.
        /// Keyboard input is directed to the window, and various visual cues are changed for the user. The
        /// system assigns a slightly higher priority to the thread that created the foreground window than
        /// it does to other threads.
        /// </summary>
        /// <param name="hWnd">Handle of window to bring to foreground.</param>
        /// <returns><see langword="true"/> if brought to foreground.</returns>
        /// <remarks><a href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setforegroundwindow"/></remarks>
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Sets the show state of a window without waiting for the operation to complete.
        /// </summary>
        /// <param name="hWnd">Handle of window to set show state of.</param>
        /// <param name="nCmdShow">Controls how the window is to be shown.  See <see cref="ShowWindowCmd"/>.</param>
        /// <returns><see langword="true"/> if operation successfully started.</returns>
        /// <remarks><a href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-showwindowasync"/></remarks>
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, ShowWindowCmd nCmdShow);

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure
        /// for the specified window and does not return until the window procedure has processed the message.
        /// </summary>
        /// <param name="hWnd">Handle of window whose window procedure will receive the message.</param>
        /// <param name="msg">The message to be sent.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>Result of the message processing; it depends on the message sent.</returns>
        /// <remarks><a href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessage"/></remarks>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        /// <summary>
        /// Retrieves information about the specified window. The function also retrieves the value at
        /// a specified offset into the extra window memory.
        /// </summary>
        /// <param name="hWnd">Handle of window to retrieve information about.</param>
        /// <param name="nIndex">The zero-based offset to the value to be retrieved. Valid values are in the
        /// range zero through the number of bytes of extra window memory, minus the size of a LONG_PTR.
        /// To retrieve any other value, see <see cref="GetWindowLongIndex"/>.</param>
        /// <returns></returns>
        /// <remarks><a href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowlongptra"/></remarks>
        [DllImport("user32.dll")]
        public static extern int GetWindowLongPtr(IntPtr hWnd, GetWindowLongIndex nIndex);

        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window. The dimensions are
        /// given in screen coordinates that are relative to the upper-left corner of the screen.
        /// </summary>
        /// <param name="hWnd">Handle of window to get dimensions of.</param>
        /// <param name="rect"><see cref="Rect"/> that receives the screen coordinates of the upper-left
        /// and lower-right corners of the window.</param>
        /// <returns><see langword="true"/> if <paramref name="rect"/> was populated.</returns>
        /// <remarks><a href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowrect"/></remarks>
        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hWnd, out Rect rect);

        /// <summary>
        /// Retrieves the coordinates of a window's client area, relative to itself (e.g., top-left is always (0, 0) ).
        /// Client area is rectangle internal to the window, excluding title, status, and scroll bars, etc.
        /// </summary>
        /// <param name="hWnd">Handle of window whose client coordinates are to be retrieved.</param>
        /// <param name="rect"><see cref="Rect"/> that receives the client coordinates. The left and top members are zero.
        /// The right and bottom members contain the width and height of the window.</param>
        /// <returns><see langword="true"/> if <paramref name="rect"/> was populated.</returns>
        /// <remarks><a href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclientrect"/></remarks>
        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out Rect rect);

        /// <summary>
        /// Retrieves the show state and the restored, minimized, and maximized positions of the specified window.
        /// </summary>
        /// <param name="hWnd">Handle of window to get placement information of.</param>
        /// <param name="lpwndpl"><see cref="WindowPlacement"/> that receives the show state and position information.</param>
        /// <returns><see langword="true"/> if <paramref name="lpwndpl"/> was populated.</returns>
        /// <remarks><a href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowplacement"/></remarks>
        [DllImport("user32.dll")]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref WindowPlacement lpwndpl);

        /// <summary>
        /// Sets the show state and the restored, minimized, and maximized positions of the specified window.
        /// </summary>
        /// <param name="hWnd">Handle of window to set placement information of.</param>
        /// <param name="lpwndpl"><see cref="WindowPlacement"/> that specifies the new show state and window positions.</param>
        /// <returns><see langword="true"/> if window placement set successfully.</returns>
        /// <remarks><a href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowplacement"/></remarks>
        [DllImport("user32.dll")]
        public static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WindowPlacement lpwndpl);

        /// <summary>
        /// Changes the position and dimensions of the specified window.
        /// </summary>
        /// <param name="hWnd">Handle of window to move.</param>
        /// <param name="X">The new position of the left side of the window.</param>
        /// <param name="Y">The new position of the top of the window.</param>
        /// <param name="nWidth">The new width of the window.</param>
        /// <param name="nHeight">The new height of the window.</param>
        /// <param name="bRepaint">Indicates whether the window is to be repainted.</param>
        /// <returns><see langword="true"/> if window moved successfully.</returns>
        /// <remarks><a href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-movewindow"/></remarks>
        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        /// <summary>
        /// Determines whether the specified window is minimized (iconic).
        /// </summary>
        /// <param name="hWnd">Handle of window to be tested.</param>
        /// <returns><see langword="true"/> if window is minimized (iconic).</returns>
        /// <remarks><a href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-isiconic"/></remarks>
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);

        /// <summary>
        /// Determines whether the specified window is maximized (zoomed).
        /// </summary>
        /// <param name="hWnd">Handle of window to be tested.</param>
        /// <returns><see langword="true"/> if window is maximized (zoomed).</returns>
        /// <remarks><a href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-iszoomed"/></remarks>
        [DllImport("user32.dll")]
        public static extern bool IsZoomed(IntPtr hWnd);
    }
}
