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
using System.Timers;
using Bot;
using System.Threading;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Bot {
    class Executor {
        KCDatabase db = KCDatabase.Instance;
        IntPtr HWND;
        Operator op;
        public Executor(IntPtr hwnd) {
            HWND = hwnd;
        }
        public void start () {
            op = new Operator(HWND);
            try {
                op.recover_home();
            }
            catch(Exception e) {
                ElectronicObserver.Utility.Logger.Add(3, e.Message+e.StackTrace+e.Source);
                ElectronicObserver.Utility.Logger.Add(3, "返回母港出错！");
            }
            try {
                think();
            }
            catch(Exception e) {
                ElectronicObserver.Utility.Logger.Add(3, "执行出错！");
                op.recover_home();
            }
        }

        public void think () {
            think_expendition();
        }
        public void action_loop () {

        }
        private void think_expendition () {
            try {
                for (int fleet = 2; fleet < 5; fleet++) {
                    FleetData fd = db.Fleet.Fleets[fleet];
                    if (config.expendition[fleet]!=0 && fd.ExpeditionState==0) {
                        op.check_supply(fd);
                        if (op.do_supply(fleet)) {
                            op.do_expendition(fleet, config.expendition[fleet]);
                        }

                    }
                    if (config.expendition[fleet] != 0 && fd.ExpeditionState == 2) {
                        op.refresh_home();
                    }
                    DateTime now = DateTime.Now;
                    DateTime stop = fd.ExpeditionTime;
                    if (config.expendition[fleet] != 0) {
                        now = now.ToUniversalTime();
                        stop = stop.ToUniversalTime();
                        TimeSpan ts = now.Subtract(stop);

                        if(DateTime.Compare(now, stop) > 0) {
                            if (ts.TotalSeconds > 90) {
                                op.refresh_home();
                            }
                            
                        }
                    }
                }
            }
            catch(Exception e) {
                ElectronicObserver.Utility.Logger.Add(3, "Expendition  Error!");
            }
            
        }
    }
}
