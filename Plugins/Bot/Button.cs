using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot {
    class Button {
        IntPtr HWND;
        int _left, _top, _right, _bottom;
        public Button (IntPtr hwnd,int left,int top,int right,int bottom) {
            HWND = hwnd;
            _left = left;
            _top = top;
            _right = right;
            _bottom = bottom;
        }
        public void left_click () {
            IntPtr Ptr = this.GetPoint();
            IntPtr wParam = IntPtr.Zero;
            WinAPI.SendMessage(HWND, WinAPI.MouseEvent_Down, wParam, Ptr);
            WinAPI.SendMessage(HWND, WinAPI.MouseEvent_Down, wParam, Ptr); // Mouse button down 
            WinAPI.SendMessage(HWND, WinAPI.MouseEvent_Up, wParam, Ptr); // Mouse button up 
        }
        public IntPtr GetPoint () {
            Random rd = new Random();
            int x = rd.Next(_left, _right);
            int y = rd.Next(_top, _bottom);
            return ((IntPtr)((y << 16) | x));
        }
    }
}
