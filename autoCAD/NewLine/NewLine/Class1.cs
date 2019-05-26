using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLine
{
    public class Class1
    {
        /// <summary>
        /// 用C#创建autoCAD中的直线
        /// </summary>
        [CommandMethod("NewLine")]
        public void NewLine()
        {
            //设置当前活动的图形数据库
            Database db = HostApplicationServices.WorkingDatabase;
            //直线的起点
            Point3d startPoint = new Point3d(0, 0, 0);
            //直线的结束点
            Point3d endPoint = new Point3d(300,300,0);
            //新建一个直线对象
            Line newLine = new Line(startPoint, endPoint);
            //定义一个指向当前数据库的事务处理，用来添加直线
            using (Transaction tran = db.TransactionManager.StartTransaction())//开始事务处理
            {
                //以读的方式打开块表
                BlockTable bt = (BlockTable)tran.GetObject(db.BlockTableId, OpenMode.ForRead);
                //以写的方式打开块表
                BlockTableRecord btr = (BlockTableRecord)tran.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                //将图形对象的信息添加到块表记录中，并返回ObjectId对象
                btr.AppendEntity(newLine);
                //把对象添加到事务处理中
                tran.AddNewlyCreatedDBObject(newLine, true);
                //提交事务处理
                tran.Commit();

            }

        }
    }
}
