using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDrawing
{
    public class Class1
    {
        /// <summary>
        /// 创建新图形 
        /// </summary>
        [CommandMethod("NewDrawing",CommandFlags.Session)]
        public static void NewDrawing()
        {
            string strTemplatePath = "acad.dwt"; //新建一个图形文档

            DocumentCollection acDocMgr = Application.DocumentManager;
            Document acDoc = acDocMgr.Add(strTemplatePath);
            acDocMgr.MdiActiveDocument = acDoc;
        }
        /// <summary>
        /// 打开现有图形
        /// </summary>
        [CommandMethod("OpenDrawing",CommandFlags.Session)]
        public static void OpenDrawing()
        {
            string strFileName = "D:\\MyPlane\\CaseStudy\\autoCAD\\guobao.dwg";  //打开拥有一些图形的图形文档

            DocumentCollection acDocMgr = Application.DocumentManager;
            if(File.Exists(strFileName))
            {
                acDocMgr.Open(strFileName, false);
            }
            else
            {
                acDocMgr.MdiActiveDocument.Editor.WriteMessage("File" + strFileName + "dose not exist");
            }
        }
        /// <summary>
        /// 保存当前图形
        /// 功能就是当你的文件已经保存之后再修改可以通过这个指令保存
        /// </summary>
        [CommandMethod("SaveActiveDrawing")]
        public static void SaveActiveDrawing()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            string strDWGName = acDoc.Name;

            object obj = Application.GetSystemVariable("DWGTITLED");

            //图形命名了吗？ 0-没呢
            if(System.Convert.ToInt16(obj)==0)
            {
                //如果图形使用了默认名（Drawing1，Drawing2等）
                //就提供一个新文件名
                strDWGName = "D:\\MyPlane\\CaseStudy\\autoCAD\\MyDrawing.dwg";
            }
            else
            {
                //保存图形
                acDoc.Database.SaveAs(strDWGName, true, DwgVersion.Current, acDoc.Database.SecurityParameters);
            }
        }
    }
}
