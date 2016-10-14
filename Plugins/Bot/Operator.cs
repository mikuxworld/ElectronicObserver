using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicObserver.Data;
using ElectronicObserver;
using ElectronicObserver.Utility;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Threading;
namespace Bot {
    class Operator {
        IntPtr HWND;
        int threshold = 300;
        ButtonSet btn;
        public Operator(IntPtr hwnd) {
            HWND = hwnd;
            btn = new ButtonSet(hwnd);
        }
        public bool do_supply (int fleet) {
            try {
                btn.supply.left_click();
                Thread.Sleep(500);
                bool flag = false;
                for (int i = 0; i < 10; i++) {
                    if (detect_supply()) {
                        flag = true;
                        ElectronicObserver.Utility.Logger.Add(3, "进入补给界面");
                        break;
                    }
                    Thread.Sleep(500);
                }
                if (!flag) {
                    ElectronicObserver.Utility.Logger.Add(3, "进入补给界面异常");
                    throw (new Exception());
                }

                btn.supplyFleet[fleet].left_click();
                Thread.Sleep(500);
                flag = false;
                for (int i = 0; i < 10; i++) {
                    if (detect_supply_fleet(fleet)) {
                        ElectronicObserver.Utility.Logger.Add(3, "选择补给舰队");
                        flag = true;
                        break;
                    }
                    btn.supplyFleet[fleet].left_click();
                    Thread.Sleep(500);
                }
                if (!flag) {
                    ElectronicObserver.Utility.Logger.Add(3, "选择补给舰队异常");
                    throw (new Exception());
                }

                btn.supplyAll.left_click();
                Thread.Sleep(500);
                flag = false;
                for (int i = 0; i < 10; i++) {                 
                    KCDatabase db = KCDatabase.Instance;
                    if (check_supply(db.Fleet.Fleets[fleet])) {
                        ElectronicObserver.Utility.Logger.Add(3, "进行补给");
                        flag = true;
                        break;
                    }
                    btn.supplyAll.left_click();
                    Thread.Sleep(500);
                }
                if (!flag) {
                    throw (new Exception());
                }
                else {
                    recover_home();
                    return true;
                }

            }
            catch (Exception) {
                ElectronicObserver.Utility.Logger.Add(3, "补给错误");
                recover_home();
                return false;
            }
            
            //return false;
        }
        public void do_expendition(int fleet,int number) {
            try {
                KCDatabase db = KCDatabase.Instance;
                
                for(int i = 2; i < 5; i++) {
                    FleetData fd = db.Fleet.Fleets[i];
                    if (fd.ExpeditionDestination == number) {
                        ElectronicObserver.Utility.Logger.Add(3, string.Format("远征{0} 正在进行", number));
                        return;
                        //return false;
                    }
                }

                btn.launch.left_click();
                Thread.Sleep(500);
                bool flag = false;
                for(int i = 0; i < 10; i++) {
                    if (detect_launch()) {
                        flag = true;
                        break;
                    }
                    Thread.Sleep(500);
                }
                if (!flag) {
                    throw (new Exception());
                }

                btn.launchExpendition.left_click();
                Thread.Sleep(1000);
                flag = false;
                for (int i = 0; i < 10; i++) {
                    if (detect_expedition()) {
                        flag = true;
                        break;
                    }
                    Thread.Sleep(500);
                }
                if (!flag) {
                    throw (new Exception());
                }

                btn.expenditionPage[number / 8 + 1].left_click();
                Thread.Sleep(1000);
                flag = false;
                for (int i = 0; i < 10; i++) {
                    if (detect_expendition_page(number / 8 + 1)) {
                        flag = true;
                        break;
                    }
                    btn.expenditionPage[number / 8 + 1].left_click();
                    Thread.Sleep(500);
                }
                if (!flag) {
                    throw (new Exception());
                }

                btn.expenditionItem[number % 8 ].left_click();
                Thread.Sleep(1000);
                flag = false;
                for (int i = 0; i < 10; i++) {
                    if (detect_expendition_decide()) {
                        flag = true;
                        break;
                    }
                    btn.expenditionItem[number % 8].left_click();
                    Thread.Sleep(500);
                }
                if (!flag) {
                    throw (new Exception());
                }

                btn.expenditionDecide.left_click();
                Thread.Sleep(500);
                flag = false;
                for (int i = 0; i < 10; i++) {
                    if (detect_expendition_start()) {
                        flag = true;
                        break;
                    }
                    Thread.Sleep(500);
                }
                if (!flag) {
                    throw (new Exception());
                }

                btn.expenditionFleet[fleet].left_click();
                Thread.Sleep(500);
                flag = false;
                for (int i = 0; i < 10; i++) {
                    if (detect_expendition_fleet(fleet)) {
                        flag = true;
                        break;
                    }
                    btn.expenditionFleet[fleet].left_click();
                    Thread.Sleep(500);
                }
                if (!flag) {
                    throw (new Exception());
                }

                btn.expenditionStart.left_click();
                Thread.Sleep(1000);
                recover_home();

            }
            catch (Exception e) {
                recover_home();
                ElectronicObserver.Utility.Logger.Add(3, e.Message + e.Source + e.StackTrace);
                ElectronicObserver.Utility.Logger.Add(3, string.Format("放远征{0}  舰队{1} 失败",number,fleet));
            }
        }
        public bool check_supply(FleetData fd) {
            int fuel = fd.MembersInstance.Sum(ship => ship == null ? 0 : (int)((ship.FuelMax - ship.Fuel) * (ship.IsMarried ? 0.85 : 1.00)));
            int ammo = fd.MembersInstance.Sum(ship => ship == null ? 0 : (int)((ship.AmmoMax - ship.Ammo) * (ship.IsMarried ? 0.85 : 1.00)));        
            if (fuel > 0 || ammo > 0) {

                return false;
            }
            return true;
        }
        public bool recover_home () {
            try {
                for(int i = 0; i < 10; i++) {
                    if (detect_home()) {
                        return true;
                    }
                    ElectronicObserver.Utility.Logger.Add(3,string.Format("尝试返回母港，次数{0}", i + 1));
                    if (detect_backhome()) {
                        btn.backHome.left_click();
                    }
                    if (detect_gamestart()) {
                        btn.gameStart.left_click();
                    }
                    Thread.Sleep(2000);
                    if (detect_home()) {
                        return true;
                    }
                    Thread.Sleep(2000);
                    if (!detect_home()) {
                        btn.backHome2.left_click();
                    }
                    Thread.Sleep(2000);
                }
                ElectronicObserver.Utility.Logger.Add(3, "无法返回母港，刷新");
                WinAPI.refreshBrowser(HWND);
            }
            catch(Exception e) {
                ElectronicObserver.Utility.Logger.Add(3,"无法返回母港，刷新");
                WinAPI.refreshBrowser(HWND);
            }
            return false;
        }

        public bool refresh_home () {
            try {
                bool flag = false;
                ElectronicObserver.Utility.Logger.Add(3, "刷新母港状态");

                
                if (!detect_home()) {
                    recover_home();
                }
                if (!detect_home()) {
                    return false;
                }
                btn.launch.left_click();
                Thread.Sleep(500);
                flag = false;
                for (int i = 0; i < 10; i++) {
                    if (detect_launch()) {   
                        flag = true;
                        break;
                    }                  
                    Thread.Sleep(1000);
                }
                if (!flag) {
                    ElectronicObserver.Utility.Logger.Add(3, "失败，下次执行时重试");
                    throw (new Exception());
                }

                for (int i = 0; i < 10; i++) {
                    if (!detect_home()) {
                        recover_home();
                        if (detect_home()) {
                            return true;
                        }
                    }
                    Thread.Sleep(1000);
                }
                
                

                ElectronicObserver.Utility.Logger.Add(3, "无法刷新母港");
                
                //WinAPI.refreshBrowser(HWND);
            }
            catch (Exception e) {
                recover_home();
                ElectronicObserver.Utility.Logger.Add(3, "无法刷新母港，强制返回母港");
                
            }
            return false;
        }

        public bool detect_gamestart () {
            try {
                if (WinAPI.match_area(HWND, @"images/gamestart.png", 100, 100, 200, 200) < threshold) {
                    return true;
                }
                return false;
            }
            catch (Exception) {
                ElectronicObserver.Utility.Logger.Add(3, "image not load");
                return false;
            }
        }

        public bool detect_home() {
            //765 440  785  460   
            try {
                if (WinAPI.match_area(HWND, @"images/home.png", 765, 440, 785, 460) < threshold) {
                    return true;
                }
                return false;
            }
            catch (Exception) {
                ElectronicObserver.Utility.Logger.Add(3, "image not load");
                return false;
            }
            
        }

        public bool detect_backhome() {
            //60  225  85  285
            if (WinAPI.match_area(HWND, @"images/backhome.png", 60, 225, 85, 285) < threshold) {
                return true;
            }
            return false;
        }

        public bool detect_launch () {
            //160  380  280  420
            if (WinAPI.match_area(HWND, @"images/launch.png", 160, 380, 280, 420) < threshold) {
                return true;
            }
            return false;
        }

        public bool detect_expedition () {
            //470  100  550  125
            if (WinAPI.match_area(HWND, @"images/expendition.png", 470,100,550,125) < threshold) {
                return true;
            }
            return false;
        }

        public bool detect_expendition_page (int page) {
            //110   415  390  455
            //110   415  166  455   p1
            //166   415  222  455   p2
            //222   415  278  455   p3 
            //278   415  334  455   p4
            //334   415  390  455   p5
            if (WinAPI.match_area(HWND, @"images/expendition_page"+page.ToString()+".png",54+56*page , 415, 110+56*page, 455) < threshold) {
                return true;
            }
            return false;
        }

        public bool detect_expendition_start () {
            //560 425 690 465 
            if (WinAPI.match_area(HWND, @"images/expendition_fleet1.png", 350,105,380,125 ) < threshold) {
                return true;
            }
            return false;
        }

        public bool detect_expendition_decide () {
            //640 430 710 460
            if (WinAPI.match_area(HWND, @"images/expendition_decide.png", 640,430,710,460) < threshold) {
                return true;
            }
            return false;
        }

        public bool detect_expendition_fleet(int fleetNum) {
            //350 105 470 125
            //350 105 380 125   f1
            //380 105 410 125   f2
            //410 105 440 125   f3
            //440 105 470 125   f4
            if (WinAPI.match_area(HWND, @"images/expendition_fleet" + fleetNum.ToString() + ".png", 320 + 30 * fleetNum, 105, 350 + 30 * fleetNum, 125) < threshold) {
                ElectronicObserver.Utility.Logger.Add(3, "已识别舰队" + fleetNum.ToString());
                return true;
            }
            ElectronicObserver.Utility.Logger.Add(3, string.Format("识别舰队{0}失败  位置{1} {2} {3} {4}", 320 + 30 * fleetNum, 105, 350 + 30 * fleetNum, 125));
            ElectronicObserver.Utility.Logger.Add(3, WinAPI.match_area(HWND, @"images/expendition_fleet" + fleetNum.ToString() + ".png", 320 + 30 * fleetNum, 105, 350 + 30 * fleetNum, 125).ToString());
            return false;
        }

        public bool detect_supply () {
            //15 190 40 225
            if (WinAPI.match_area(HWND, @"images/supply.png", 15,190,40,225) < threshold) {
                return true;
            }
            return false;
        }

        public bool detect_supply_fleet(int fleetNum) {
            //130 105 280 125
            //130 105 160 125   f1
            //160 105 190 125   f2
            //190 105 220 125   f3
            //220 105 250 125   f4
            //250 105 280 125   f5

            if (WinAPI.match_area(HWND, @"images/supply_fleet" + fleetNum.ToString() + ".png", 100 + 30 * fleetNum, 105, 130 + 30 * fleetNum, 125) < threshold) {
               // ElectronicObserver.Utility.Logger.Add(3, "已识别舰队"+fleetNum.ToString());
                return true;
            }
            //ElectronicObserver.Utility.Logger.Add(3, string.Format("识别舰队{0}失败  位置{1} {2} {3} {4}", fleetNum, 100 + 30 * fleetNum, 105, 130 + 30 * fleetNum, 125));
            //ElectronicObserver.Utility.Logger.Add(3, WinAPI.match_area(HWND, @"images/expendition_fleet" + fleetNum.ToString() + ".png", 100 + 30 * fleetNum, 105, 130 + 30 * fleetNum, 125).ToString());
            return false;
        }
    }
}
