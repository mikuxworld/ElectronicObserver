using ElectronicObserver.Data;
using ElectronicObserver.Data.Battle;
using ElectronicObserver.Data.Battle.Phase;
using ElectronicObserver.Observer;
using ElectronicObserver.Resource;
using ElectronicObserver.Window.Control;
using ElectronicObserver.Window.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Timers;
using Bot;
using System.Threading;
namespace ElectronicObserver.Window {
    public partial class FormBot : DockContent {

        public FormBot (FormMain parent) {
            this.SuspendLayoutForDpiScale();
            InitializeComponent();
        }
        private void FormBot_Load (object sender, EventArgs e) {
            buttonStart.Enabled = false;
            buttonStop.Enabled = false;
        }
        IntPtr HWND;
        System.Timers.Timer timerSearchHandle = new System.Timers.Timer();
        System.Timers.Timer timerWork;
        bool mutex = false;
        private void buttonGetHWND_MouseDown (object sender, MouseEventArgs e) {
            timerSearchHandle.Interval = 40;
            timerSearchHandle.Elapsed += new System.Timers.ElapsedEventHandler(getHWND);
            timerSearchHandle.Start();
        }
        private void getHWND(object sender, EventArgs e) {
            int _cursorX, _cursorY;
            Point _cursorPoint;
            _cursorX = Cursor.Position.X;
            _cursorY = Cursor.Position.Y;
            _cursorPoint = new Point(_cursorX, _cursorY);
            HWND = WinAPI.WindowFromPoint(_cursorPoint);
            textHWND.Text = HWND.ToString();
        }

        private void buttonGetHWND_MouseUp (object sender, MouseEventArgs e) {
            timerSearchHandle.Stop();
            Utility.Logger.Add(3,"BOT获取句柄：" + HWND.ToString() + "\n");
            buttonStart.Enabled = true;
        }

        private void buttonStart_Click (object sender, EventArgs e) {
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            timerWork = new System.Timers.Timer();
            timerWork.Interval = 1000;
            timerWork.Elapsed += new System.Timers.ElapsedEventHandler(work);
            timerWork.Start();
        }
        private void buttonStop_Click (object sender, EventArgs e) {
            timerWork.Stop();
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }
        private void work(object sender,EventArgs e) {
            if (mutex) {
                Utility.Logger.Add(2, "正忙\n");
                return;
            }
            mutex = true;
            KCDatabase db = KCDatabase.Instance;
            Utility.Logger.Add(2, "工作中，查看是否阻塞\n");
            Thread.Sleep(2000);
            mutex = false;
        }
        private void browserRefresh () {
            WinAPI.SetForegroundWindow(HWND);
            WinAPI.SetFocus(HWND);
            SendKeys.Send("{F5}");
        }
       
    }
}
