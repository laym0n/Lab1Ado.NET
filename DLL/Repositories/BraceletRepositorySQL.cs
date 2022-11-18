using DLL.EF;
using DLL.Entity1;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class BraceletRepositorySQL : Interfaces.IRepository<bracelet>
    {
        private DBAquaparkContext db;

        public BraceletRepositorySQL(DBAquaparkContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<bracelet> GetList()
        {
            return db.bracelet.ToList();
        }

        public bracelet GetItem(int id)
        {
            return db.bracelet.Find(id);
        }

        public void Create(bracelet item)
        {
            db.bracelet.Add(item);
        }

        public void Update(bracelet item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            bracelet item = db.bracelet.Find(id);
            if (item != null)
                db.bracelet.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
