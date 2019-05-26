using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    public class Class1
    {
        [CommandMethod("Hello World")]//设计新的命令

        public void HelloWorld()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;//获取当前的活动文档
            Editor acEd = acDoc.Editor;//当前编译器对象，命令行对象
            acEd.WriteMessage("Hello World 2019 autoCAD");
        }

    }
}
