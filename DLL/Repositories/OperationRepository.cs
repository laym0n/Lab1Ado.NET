using DLL.EF;
using DLL.Entity1;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class OperationRepositorySQL : Interfaces.IRepository<operation>
    {
        private DBAquaparkContext db;

        public OperationRepositorySQL(DBAquaparkContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<operation> GetList()
        {
            return db.operation.ToList();
        }

        public operation GetItem(int id)
        {
            return db.operation.Find(id);
        }

        public void Create(operation item)
        {
            db.operation.Add(item);
        }

        public void Update(operation item)
        {
            //operation op = db.operation.Find(item.operation_id);
            //op.time = item.time;
            //op.sum = item.sum;
            //op.bracelet_id = item.bracelet_id;
            //op.recreation_area_id = item.recreation_area_id;
            db.operation.AddOrUpdate(item);
            //db.SaveChanges();
        }

        public void Delete(int id)
        {
            operation item = db.operation.Find(id);
            if (item != null)
                db.operation.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
