using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SizeDocumentWindow
{
    public class Class1
    {

        /// <summary>
        /// 调整活动文档窗口大小
        /// </summary>
        [CommandMethod("SizeDocumentWindow")]

        public static void SizeDocumentWindow()
        {
            //获取当前文档窗口
            Document doc = Application.DocumentManager.MdiActiveDocument;
            doc.Window.WindowState = Window.State.Normal;
            //设置文档窗口位置
            Point ptDoc = new Point(0, 0);
            doc.Window.DeviceIndependentLocation = ptDoc;
            //设置文档窗口大小
            Size szDoc = new Size(400, 400);
            doc.Window.DeviceIndependentSize = szDoc;
        }

        /// <summary>
        /// 最大化最小化活动文档窗口
        /// </summary>
        [CommandMethod("MinMaxDocumentWindow")]
        public static void MinMaxDocumentWindow()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            // 最小化文档窗口   
            acDoc.Window.WindowState = Window.State.Minimized;
            System.Windows.Forms.MessageBox.Show("Minimized", "MinMax");
            // 最大化文档窗口   
            acDoc.Window.WindowState = Window.State.Maximized;
            System.Windows.Forms.MessageBox.Show("Maximized", "MinMax"); 
        }

        /// <summary>
        /// 获得活动文档窗口状态
        /// </summary>
        [CommandMethod("CurrentDocWindowState")]
        public static void CurrentDocWindowState()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            System.Windows.Forms.MessageBox.Show("The document window is " +
                acDoc.Window.WindowState.ToString(), "Window State"); }
    }
}
