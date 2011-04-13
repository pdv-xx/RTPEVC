using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RTPEVCView
{
    class Win32API
    {
        /* The following enum was taken from http://www.pinvoke.net/default.aspx/Enums/SetWindowPosFlags.html to
         * save time; there's no reason to write out all of these flags' hex values.
         * - Padraic
         */
        public enum SetWindowPosFlags : uint
        {
            /// <summary>
            ///     If the calling thread and the thread that owns the window are attached to different input queues, the system posts the request to the thread that owns the window. This prevents the calling thread from blocking its execution while other threads process the request.
            /// </summary>
            SWP_ASYNCWINDOWPOS = 0x4000,

            /// <summary>
            ///     Prevents generation of the WM_SYNCPAINT message.
            /// </summary>
            SWP_DEFERERASE = 0x2000,

            /// <summary>
            ///     Draws a frame (defined in the window's class description) around the window.
            /// </summary>
            SWP_DRAWFRAME = 0x0020,

            /// <summary>
            ///     Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE is sent only when the window's size is being changed.
            /// </summary>
            SWP_FRAMECHANGED = 0x0020,

            /// <summary>
            ///     Hides the window.
            /// </summary>
            SWP_HIDEWINDOW = 0x0080,

            /// <summary>
            ///     Does not activate the window. If this flag is not set, the window is activated and moved to the top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter parameter).
            /// </summary>
            SWP_NOACTIVATE = 0x0010,

            /// <summary>
            ///     Discards the entire contents of the client area. If this flag is not specified, the valid contents of the client area are saved and copied back into the client area after the window is sized or repositioned.
            /// </summary>
            SWP_NOCOPYBITS = 0x0100,

            /// <summary>
            ///     Retains the current position (ignores X and Y parameters).
            /// </summary>
            SWP_NOMOVE = 0x0002,

            /// <summary>
            ///     Does not change the owner window's position in the Z order.
            /// </summary>
            SWP_NOOWNERZORDER = 0x0200,

            /// <summary>
            ///     Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of the window being moved. When this flag is set, the application must explicitly invalidate or redraw any parts of the window and parent window that need redrawing.
            /// </summary>
            SWP_NOREDRAW = 0x0008,

            /// <summary>
            ///     Same as the SWP_NOOWNERZORDER flag.
            /// </summary>
            SWP_NOREPOSITION = 0x0200,

            /// <summary>
            ///     Prevents the window from receiving the WM_WINDOWPOSCHANGING message.
            /// </summary>
            SWP_NOSENDCHANGING = 0x0400,

            /// <summary>
            ///     Retains the current size (ignores the cx and cy parameters).
            /// </summary>
            SWP_NOSIZE = 0x0001,

            /// <summary>
            ///     Retains the current Z order (ignores the hWndInsertAfter parameter).
            /// </summary>
            SWP_NOZORDER = 0x0004,

            /// <summary>
            ///     Displays the window.
            /// </summary>
            SWP_SHOWWINDOW = 0x0040,
        }

        internal class Win32API
        {
            const string _user32dll = "User32.dll";
            const string _kernel32dll = "Kernel32.dll";

            /*
             * API structs
             */
            public struct WINDOWINFO
            {
                public ulong cbSize;
                public System.Drawing.Rectangle rcWindow;
                public System.Drawing.Rectangle rcClient;
                public ulong dwStyle;
                public ulong dwExStyle;
                public ulong dwWindowStatus;
                public uint cxWindowBorders;
                public uint cyWindowBorders;
                public UInt16 atomWindowType;
                public UInt16 wCreatorVersion;
            };
            /*
            public struct RECT
            {
                public long left;
                public long top;
                public long right;
                public long bottom;
            };
            */
            public struct WINDOWPLACEMENT
            {
                public uint length;
                public uint flags;
                public uint showCmd;
                public POINT ptMinPosition;
                public POINT ptMaxPosition;
                public System.Drawing.Rectangle rcNormalPosition;
            };

            public struct POINT
            {
                public long x;
                public long y;
            };

            /*
             * User32.dll interface
             */
            [DllImport(_user32dll)]
            public static extern Boolean EnumWindows(Delegate cb, int lParam);
            [DllImport(_user32dll)]
            public static extern Boolean EnumChildWindows(int hWnd, Delegate cb, int lParam);
            [DllImport(_user32dll)]
            public static extern Int32 GetWindowText(int hWnd, StringBuilder s, int nMaxCount);
            [DllImport(_user32dll)]
            public static extern int GetDesktopWindow();
            [DllImport(_user32dll)]
            public static extern Boolean EnumDesktopWindows(int hDesktop, Delegate cb, int lParam);
            [DllImport(_user32dll)]
            public static extern int GetThreadDesktop(Int32 dwThreadId);
            [DllImport(_user32dll)]
            public static extern Boolean SetWindowText(int hWnd, String s);
            [DllImport(_user32dll)]
            public static extern Boolean GetWindowInfo(int hWnd, ref WINDOWINFO pwi);
            [DllImport(_user32dll)]
            public static extern Boolean GetWindowPlacement(int hWnd, ref WINDOWPLACEMENT lpwndpl);
            [DllImport(_user32dll)]
            public static extern Boolean SetWindowPlacement(int Hwnd, ref WINDOWPLACEMENT lpwndpl);
            [DllImport(_user32dll)]
            public static extern Boolean SetWindowPos(int hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
            [DllImport(_user32dll)]
            public static extern void MoveWindow(int hWnd, int x, int y, int nWidth, int nHeight, Boolean bRepaint = true);

            /*
             * Kernel32.dll interface
             */
            [DllImport(_kernel32dll)]
            public static extern int GetCurrentThreadId();
        }
    }
}
