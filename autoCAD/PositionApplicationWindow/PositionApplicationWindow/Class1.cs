using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using System.Windows;
using Autodesk.AutoCAD.Windows;

namespace PositionApplicationWindow
{
    public class Class1
    {
        /// <summary>
        /// 把CAD窗口调为400x400
        /// </summary>
        [CommandMethod("PositionApplicationWindow")]

        public static void PositionApplicationWindow()
        {
            //设置应用程序窗口位置
            Point ptApp = new Point(0, 0);
            Application.MainWindow.DeviceIndependentLocation = ptApp;  

            //设置应用程序窗口大小
            Size szApp = new Size(400, 400);
            Application.MainWindow.DeviceIndependentSize = szApp;
        }

        /// <summary>
        ///最小化CAD应用程序窗口
        /// </summary>
        [CommandMethod("MinApplicationWindow")]
        public static void MinMaxApplicationWindow()
        {
            //最小化应用程序窗口
            Application.MainWindow.WindowState = Window.State.Minimized;
            System.Windows.Forms.MessageBox.Show("Minimized", "MinMax",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.None,
                System.Windows.Forms.MessageBoxDefaultButton.Button1,
                System.Windows.Forms.MessageBoxOptions.ServiceNotification);
         
        }

        /// <summary>
        /// 最大化CAD应用程序窗口
        /// </summary>
        [CommandMethod("MaxApplicationWindow")]
        public static void MaxApplicationWindow()
        {

            //最大化应用程序窗口
            Application.MainWindow.WindowState = Window.State.Maximized;
            System.Windows.Forms.MessageBox.Show("Maximized", "MinMax");

        }

        /// <summary>
        /// 获得应用程序窗口当前状态
        /// </summary>
        [CommandMethod("CurrentWindowState")]

        public static void CurrentWindowState()
        {
            System.Windows.Forms.MessageBox.Show("The application window is" + Application.MainWindow.WindowState.ToString(), "Window State");
        }

        /// <summary>
        /// 隐藏应用程序窗口
        /// </summary>
        [CommandMethod("HideWindowState")]

        public static void HideWindowState()
        {
            //隐藏应用程序窗口
            Application.MainWindow.Visible = false;
            System.Windows.Forms.MessageBox.Show("Invisible", "Hide");
        }

        /// <summary>
        /// 隐藏应用程序窗口
        /// </summary>
        [CommandMethod("ShowWindowState")]

        public static void ShowWindowState()
        {
            //隐藏应用程序窗口
            Application.MainWindow.Visible = true;
            System.Windows.Forms.MessageBox.Show("Invisible", "Show");
        }
    }
}
