using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Bot {
    public static class WinAPI {
        public const uint MouseEvent_Down = 0x201;
        public const uint MouseEvent_Up = 0x202;
        public const uint WM_CHAR = 0X102;
        public const uint VK_SPACE = 0x20;
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint (Point point);

        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetDC (IntPtr hWnd);

        [DllImport("gdi32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetPixel (int hdc, int X, int y);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage (IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow (IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus (IntPtr hWnd);
    }
}
