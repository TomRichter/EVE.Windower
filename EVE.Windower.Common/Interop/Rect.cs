using System.Runtime.InteropServices;

namespace EVE.Windower.Common.Interop
{
    /// <summary>
    /// Defines a rectangle by the coordinates of its upper-left and lower-right corners.
    /// 
    /// The bottom-right coordinates of the returned rectangle are exclusive. In other words,
    /// the pixel at (right, bottom) lies immediately outside the rectangle.
    /// </summary>
    /// <remarks><a href="https://docs.microsoft.com/en-us/windows/win32/api/windef/ns-windef-rect"/></remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        /// <summary>
        /// Specifies the x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public long Left;

        /// <summary>
        /// Specifies the y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public long Top;

        /// <summary>
        /// Specifies the x-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public long Right;

        /// <summary>
        /// Specifies the y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public long Bottom;
    }
}
