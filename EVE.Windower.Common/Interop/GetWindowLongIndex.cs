namespace EVE.Windower.Common.Interop
{
    /// <summary>
    /// Arguments to <see cref="User32.GetWindowLongPtr"/>.
    /// </summary>
    /// <remarks><a href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowlongptra"/></remarks>
    public enum GetWindowLongIndex : int
    {
        /// <summary>
        /// Retrieves the pointer to the window procedure, or a handle representing the pointer to
        /// the window procedure. You must use the CallWindowProc function to call the window procedure.
        /// </summary>
        GWLP_WNDPROC = -4,

        /// <summary>
        /// Retrieves a handle to the application instance.
        /// </summary>
        GWLP_HINSTANCE = -6,

        /// <summary>
        /// Retrieves a handle to the parent window, if there is one.
        /// </summary>
        GWLP_HWNDPARENT = -8,

        /// <summary>
        /// Retrieves the identifier of the window.
        /// </summary>
        GWLP_ID = -12,

        /// <summary>
        /// Retrieves the window styles.
        /// </summary>
        GWL_STYLE = -16,

        /// <summary>
        /// Retrieves the extended window styles.
        /// </summary>
        GWL_EXSTYLE = -20,

        /// <summary>
        /// Retrieves the user data associated with the window. This data is intended for use by
        /// the application that created the window. Its value is initially zero.
        /// </summary>
        GWLP_USERDATA = -21,
    }
}
