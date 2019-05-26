using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCircle
{
    public class Class1
    {
        [CommandMethod("NewCircle")]

        public void NewCircle()
        {
            //获取当前活动的数据库
            Database db = HostApplicationServices.WorkingDatabase;
            //定义圆心和半径
            Point3d circlePoint = new Point3d(300, 300, 0);
            int ridus = 300;
            //新建一个圆
            Circle circle = new Circle(circlePoint, Vector3d.ZAxis, ridus);
            //定义一个指向当前数据库的事务处理
            using (Transaction tran = db.TransactionManager.StartTransaction())
            {
                //以读的方式打开块表
                BlockTable bt = (BlockTable)tran.GetObject(db.BlockTableId, OpenMode.ForRead);
                //以写的方式打开块表
                BlockTableRecord btr = (BlockTableRecord)tran.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                //将图形对象的信息添加到块表记录中，并返回Object对象
                btr.AppendEntity(circle);
                //将对象添加到事务处理中
                tran.AddNewlyCreatedDBObject(circle, true);
                //提交事务处理
                tran.Commit();
            }

        }
    }
}
