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
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace ElectronicObserver.Window {
    public partial class FormBot : DockContent {

        public FormBot (FormMain parent) {
            this.SuspendLayoutForDpiScale();
            InitializeComponent();
        }
        private void FormBot_Load (object sender, EventArgs e) {
            FormBot.CheckForIllegalCrossThreadCalls = false;
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
        Executor ex;
        private void work(object sender,EventArgs e) {
            if (mutex) {
               
                return;
            }
            mutex = true;
            
           // Utility.Logger.Add(2, "开始工作循环");
            ex= new Executor(HWND);
            ex.start();
            Thread.Sleep(1000);
            mutex = false;
        }
        private void browserRefresh () {
            WinAPI.SetForegroundWindow(HWND);
            WinAPI.SetFocus(HWND);
            SendKeys.Send("{F5}");
        }

        private void buttonTest_Click (object sender, EventArgs e) {
            int left = Convert.ToInt32(textBoxLeft.Text);
            int right= Convert.ToInt32(textBoxRight.Text);
            int top = Convert.ToInt32(textBoxTop.Text);
            int bottom = Convert.ToInt32(textBoxBottom.Text);
            Image<Bgr, Byte> img = WinAPI.getImg(HWND, left, top, right, bottom);
            pictureBoxTest.Image = img.ToBitmap();
        }

        private void buttonSave_Click (object sender, EventArgs e) {
            Image bitmap = pictureBoxTest.Image;
            string filename = textBoxFilename.Text;
            bitmap.Save(@"E:\74makai\ElectronicObserver\output\images\" + filename);
        }

        private void buttonTestDiff_Click (object sender, EventArgs e) {
            string filename = textBoxFilename.Text;
            Image<Bgr, byte> img2 = new Image<Bgr, byte>(@"E:\74makai\ElectronicObserver\output\images\" + filename);
            int left = Convert.ToInt32(textBoxLeft.Text);
            int right = Convert.ToInt32(textBoxRight.Text);
            int top = Convert.ToInt32(textBoxTop.Text);
            int bottom = Convert.ToInt32(textBoxBottom.Text);
            Image<Bgr, Byte> img = WinAPI.getImg(HWND, left, top, right, bottom);
            //Mat img2 = CvInvoke.Imread(@"E:\74makai\ElectronicObserver\output\images\" + filename, LoadImageType.AnyColor | LoadImageType.AnyDepth);
            //Mat img=
            pictureBoxTest.Image = img.ToBitmap();
            pictureBoxTest2.Image = img2.ToBitmap();
            textHWND.Text = WinAPI.match_picture(img, img2).ToString();
        }

        private void buttonExpenditionSet_Click (object sender, EventArgs e) {
            try {
                if (textBoxExpendition2.Text != "") {
                    config.expendition[2] = Convert.ToInt32(textBoxExpendition2.Text);
                    Utility.Logger.Add(3, string.Format("Expendition  {0}  Fleet  2  set!", config.expendition[2]));
                }
                if (textBoxExpendition3.Text != "") {
                    config.expendition[3] = Convert.ToInt32(textBoxExpendition3.Text);
                    Utility.Logger.Add(3, string.Format("Expendition  {0}  Fleet  2  set!", config.expendition[3]));
                }
                if (textBoxExpendition4.Text != "") {
                    config.expendition[4] = Convert.ToInt32(textBoxExpendition4.Text);
                    Utility.Logger.Add(3, string.Format("Expendition  {0}  Fleet  2  set!", config.expendition[4]));
                }
            }
            catch(Exception) {
                Utility.Logger.Add(3, "数字输入不正确");
            }
            
            

        }
    }
}
