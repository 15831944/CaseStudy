using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListEntities
{
    public class Class1
    {
        [CommandMethod("ListEntities")]

        public static void ListEntities()
        {
            //获取当前数据库
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            //启动事务
            using (Transaction trans = acCurDb.TransactionManager.StartTransaction())
            {
                //以读的方式 打开块表
                BlockTable acBlkTbl = (BlockTable)trans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead);
                //以读的方式打开块表记录模型空间
                BlockTableRecord acBlkTblRec = (BlockTableRecord)trans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                int Cont = 0;

                acDoc.Editor.WriteMessage("\nModel space objects:");

                //遍历模型空间里的每个对象，并显示找到的对象
                foreach(ObjectId acObjId in acBlkTblRec)
                {
                    acDoc.Editor.WriteMessage("\n" + acObjId.ObjectClass.DxfName);
                    Cont += 1 ;
                }
                //如果没有发现对象则显示提示信息
                if(Cont==0)
                {
                    acDoc.Editor.WriteMessage("\n No objects found");
                }
            }
        }
    }
}
