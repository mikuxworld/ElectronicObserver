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
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ElectronicObserver.Window;
using ElectronicObserver.Utility;
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


        //获取left top right bottom范围内图像，不包含right及bottom
        public static Image<Bgr,Byte> getImg(IntPtr HWND,int left,int top,int right,int bottom) {
            Image<Bgr, Byte> img = new Image<Bgr, byte>(right - left, bottom - top);
            int dc = GetDC(HWND);
            int count = 0;
            for (int x=left; x< right; x++) {
                for(int y = top; y < bottom; y++) {
                    if (++count > 10000) {
                        dc = GetDC(HWND);
                        count = 0;
                    }
                    int i = x - left;
                    int j = y - top;
                    int c = GetPixel(dc, x, y);
                    Color cl = Color.FromArgb(c);

                    Bgr color=img[j,i];
                    color.Blue = cl.R;
                    color.Green = cl.G;
                    color.Red = cl.B;
                    img[j, i] = color;
                    
                }
            }

            return img;
        }
        //public static Mat getImgMat (IntPtr HWND, int left, int top, int right, int bottom) {
        //    Mat img = new Mat(bottom - top, right - left, DepthType.Cv8U, 3);
        //    int dc = GetDC(HWND);
        //    int count = 0;
        //    for (int x = left; x < right; x++) {
        //        for (int y = top; y < bottom; y++) {
        //            if (++count > 10000) {
        //                dc = GetDC(HWND);
        //                count = 0;
        //            }
        //            int i = x - left;
        //            int j = y - top;
        //            int c = GetPixel(dc, x, y);
        //            Color cl = Color.FromArgb(c);
        //            img.
        //            Bgr color = img;
        //            color.Blue = cl.R;
        //            color.Green = cl.G;
        //            color.Red = cl.B;
        //            img[j, i] = color;

        //        }
        //    }

        //    return img;
        //}

        public static void refreshBrowser(IntPtr hwnd) {
            WinAPI.SetForegroundWindow(hwnd);
            WinAPI.SetFocus(hwnd);
            SendKeys.SendWait("{F5}");
        }


        //public static double match_picture (Image<Bgr,Byte> image1, Image<Bgr, Byte> image2) {

        //    int[] hist_size = new int[] {50,50,50 };//建一个数组来存放直方图数据  
        //                                         //准备轮廓   
        //    int[] channels = new int[] {0,1,2};
        //    float[] ranges = new float[] { 0.0F, 256.0F,0.0F,256.0F,0.0f,256.0f };

        //    //CvInvoke.CvtColor(image1, image1, ColorConversion.Bgr2Hsv);
        //    //CvInvoke.CvtColor(image2, image2, ColorConversion.Bgr2Hsv);
        //    //Image<Bgr, Byte> mask = new Image<Bgr, byte>(image1.Width, image1.Height);
        //    // IntPtr HistImg1;
        //    MatND<Byte> hist1 = new MatND<Byte>(3);
        //    MatND<Byte> hist2 = new MatND<Byte>(3);
        //    //Mat hist1 = new Mat();
        //    //Mat hist2 = new Mat();
        //    //IntPtr hist1;
        //    //IntPtr hist2;
        //    CvInvoke.CalcHist(image1, channels, new Mat(), hist1, hist_size, ranges, false);
        //    CvInvoke.CalcHist(image2, channels, new Mat(), hist2, hist_size, ranges, false);

        //    double compareResult;
        //    //Emgu.CV.CvEnum.HISTOGRAM_COMP_METHOD compareMethod = Emgu.CV.CvEnum.HISTOGRAM_COMP_METHOD.CV_COMP_BHATTACHARYYA;  
        //    //Emgu.CV.CvEnum.HISTOGRAM_COMP_METHOD compareMethod = Emgu.CV.CvEnum.HISTOGRAM_COMP_METHOD.CV_COMP_CHISQR;  
        //    //Emgu.CV.CvEnum.HISTOGRAM_COMP_METHOD compareMethod = Emgu.CV.CvEnum.HISTOGRAM_COMP_METHOD.CV_COMP_CORREL; 

        //    compareResult = Emgu.CV.CvInvoke.CompareHist(hist1, hist2, Emgu.CV.CvEnum.HistogramCompMethod.Intersect);

        //    return compareResult;


        //}
        public static double match_area(IntPtr HWND,string path,int left,int top,int right,int bottom) {
            Image<Bgr, byte> img2 = new Image<Bgr, byte>(path);
            Image<Bgr, Byte> img = WinAPI.getImg(HWND, left, top, right, bottom);
            return match_picture(img, img2);
        }
        public static double match_picture (Image<Bgr, Byte> image1, Image<Bgr, Byte> image2) {

            CvInvoke.Resize(image1, image1, new Size(image1.Cols,image1.Rows));
            CvInvoke.Resize(image2, image2, new Size(image1.Cols,image1.Rows));
            double dist = 0;
            for(int i = 0; i < image1.Cols; i++) {
                for(int j = 0; j < image1.Rows; j++) {
                    double d = 0;
                    d += (image1[j, i].Blue - image2[j, i].Blue) * (image1[j, i].Blue - image2[j, i].Blue);
                    d += (image1[j, i].Red - image2[j, i].Red) * (image1[j, i].Red - image2[j, i].Red);
                    d += (image1[j, i].Green - image2[j, i].Green) * (image1[j, i].Green - image2[j, i].Green);
                    d = Math.Sqrt(d);
                    dist += d;
                }
            }
            return dist;


            }

        }
    }
