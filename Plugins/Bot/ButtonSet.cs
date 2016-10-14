using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot {
    class ButtonSet {
        IntPtr HWND;
        public ButtonSet(IntPtr hwnd) {
            HWND = hwnd;
            gameStart = new Button(HWND, 490, 380, 740, 420);
            launch = new Button(HWND, 170, 230, 220, 280);
            backHome= new Button(HWND, 60, 225, 85, 285);
            supply = new Button(HWND, 50 ,200, 100, 250);
            backHome2 = new Button(HWND, 5, 5, 60, 60);
            supplyAll = new Button(HWND, 115, 115, 120, 120);
            launchExpendition = new Button(HWND, 620, 170, 750, 280);
            expenditionDecide = new Button(HWND, 640, 430, 710, 460);
            expenditionStart = new Button(HWND, 560, 425, 690, 465);
            for (int i = 1; i < 6; i++) {
                supplyFleet[i] = new Button(hwnd, 100 + 30 * i, 105, 130 + 30 * i, 125);
            }
            for(int i = 1; i < 6; i++) {
                expenditionPage[i] = new Button(hwnd, 54 + 56 * i + 10, 420, 110 + 56 * i - 10, 450);
            }
            for (int i = 1; i < 9; i++) {
                expenditionItem[i] = new Button(hwnd, 150, 130 + 30 * i + 5, 420, 160 + 30 * i - 5);
            }
            expenditionItem[0] = expenditionItem[8];
            for(int i = 1; i < 5; i++) {
                expenditionFleet[i] = new Button(hwnd, 320 + 30 * i + 5, 105, 350 + 30 * i - 5, 125);
            }
        }

        //490, 380, 740, 420
        public Button gameStart;

        //170 230 220 280
        public Button launch;

        //620,170,750,280
        public Button launchExpendition;

        //60  225  85  285
        public Button backHome;
        
        //5 5 60 60
        public Button backHome2;
       
        //50 200 100 250
        public Button supply;

        //115 115 125 125
        public Button supplyAll;

        //640 430 710 460
        public Button expenditionDecide;


        //560 425 690 465 
        public Button expenditionStart;

        //130 105 280 125
        //130 105 160 125   f1
        //160 105 190 125   f2
        //190 105 220 125   f3
        //220 105 250 125   f4
        //250 105 280 125   f5
        public Button[] supplyFleet=new Button[6];
       
        //110   415  390  455
        //110   415  166  455   p1
        //166   415  222  455   p2
        //222   415  278  455   p3 
        //278   415  334  455   p4
        //334   415  390  455   p5      //左右两边各+-10
        public Button[] expenditionPage = new Button[6];

        //150 160  420  400
        public Button[] expenditionItem = new Button[9];

        //350 105 470 125
        //350 105 380 125   f1
        //380 105 410 125   f2
        //410 105 440 125   f3
        //440 105 470 125   f4
        public Button[] expenditionFleet = new Button[5];
    }
}
