using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddMyLayer
{
    public class Class1
    {
        /// <summary>
        /// 添加一个图层 addmylayer0   向集合对象中添加新成员
        /// </summary>
        [CommandMethod("AddMyLayer0")]

        public static void AddMyLayer0()
        {
            //获取当前文档和数据库，并启动事务
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                //返回当前数据库的图标层
                LayerTable acLyrTbl;

                acLyrTbl = acTrans.GetObject(acCurDb.LayerTableId, OpenMode.ForRead) as LayerTable;

                //检查图层表里是否有图层MyLayer
                if(acLyrTbl.Has("MyLayer0")!=true)
                {
                    //以写的模式打开图层表
                    acLyrTbl.UpgradeOpen();

                    //创建一个新的图层表记录.并命名为"MyLayer"
                    LayerTableRecord acLyrTblRec = new LayerTableRecord();
                    acLyrTblRec.Name = "MyLayer0";

                    //添加新的图层表记录到图层表，添加事务
                    acLyrTbl.Add(acLyrTblRec);
                    acTrans.AddNewlyCreatedDBObject(acLyrTblRec,true);

                    //提交修改
                    acTrans.Commit();
                }
            }
        }
        /// <summary>
        /// 添加一个图层addmylayer1   向集合对象中添加新成员
        /// </summary>
        [CommandMethod("AddMyLayer1")]

        public static void AddMyLayer1()
        {
            //获取当前文档和数据库，并启动事务
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                //返回当前数据库的图标层
                LayerTable acLyrTbl;

                acLyrTbl = acTrans.GetObject(acCurDb.LayerTableId, OpenMode.ForRead) as LayerTable;

                //检查图层表里是否有图层MyLayer
                if (acLyrTbl.Has("MyLayer1") != true)
                {
                    //以写的模式打开图层表
                    acLyrTbl.UpgradeOpen();

                    //创建一个新的图层表记录.并命名为"MyLayer"
                    LayerTableRecord acLyrTblRec = new LayerTableRecord();
                    acLyrTblRec.Name = "MyLayer1";

                    //添加新的图层表记录到图层表，添加事务
                    acLyrTbl.Add(acLyrTblRec);
                    acTrans.AddNewlyCreatedDBObject(acLyrTblRec, true);

                    //提交修改
                    acTrans.Commit();
                }
            }
        }
        /// <summary>
        /// 遍历图层表中的图层 输出名称  迭代集合对象
        /// </summary>
        [CommandMethod("IterateLayers")]

        public static void IterateLayers()
        {
            //获取当前数据库，启动事务
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                //This example 返回当前数据库的图层表
                LayerTable acLyrTbl;
                acLyrTbl = acTrans.GetObject(acCurDb.LayerTableId, OpenMode.ForRead) as LayerTable;

                //遍历图层表并打印每个图层的名字
                foreach(ObjectId acObjId in acLyrTbl)
                {
                    LayerTableRecord acLyrTblRec;
                    acLyrTblRec = acTrans.GetObject(acObjId, OpenMode.ForRead) as LayerTableRecord;

                    acDoc.Editor.WriteMessage("\n" + acLyrTblRec.Name);

                }
            }
        }
        /// <summary>
        /// 查看是否存在MyLayer0  
        /// </summary>
        [CommandMethod("FindMyLayer")]
        public static void FindMyLayer()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acDocDb = acDoc.Database;

            using (Transaction acTrans = acDocDb.TransactionManager.StartTransaction())
            {
                LayerTable acLyrTbl = (LayerTable)acTrans.GetObject(acDocDb.LayerTableId, OpenMode.ForRead);

                if(acLyrTbl.Has("MyLayer0")!=true)
                {
                    acDoc.Editor.WriteMessage("\n'MyLayer0' does exist");

                }
                else
                {
                    acDoc.Editor.WriteMessage("\n'MyLayer0' exist");
                }
            }
        }
        /// <summary>
        /// 从图层表中删除图层       从集合对象中删除成员
        /// </summary>
        [CommandMethod("RemoveMyLayer")]

        public static void RemoveMyLayer()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database dab = doc.Database;


            using (Transaction trans = dab.TransactionManager.StartTransaction())
            {
                LayerTable lyTbl = (LayerTable)trans.GetObject(dab.LayerTableId, OpenMode.ForRead);
                if(lyTbl.Has("MyLayer0")==true)
                {
                    LayerTableRecord lyTblRec = (LayerTableRecord)trans.GetObject(lyTbl["MyLayer0"], OpenMode.ForWrite);
                    try
                    {
                        lyTblRec.Erase();
                        doc.Editor.WriteMessage("\n'MyLayer0' was erased");

                        trans.Commit();
                    }
                    catch
                    {
                        doc.Editor.WriteMessage("\n'MyLayer0' could not be erased");
                    }
                }
                else
                {
                    doc.Editor.WriteMessage("\n'MyLayer0' does not exist");
                }
            }
        }
    }
}
