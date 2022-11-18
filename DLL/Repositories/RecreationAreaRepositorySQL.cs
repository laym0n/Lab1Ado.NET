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
    public class RecreationAreaRepositorySQL : Interfaces.IRepository<recreation_area>
    {
        private DBAquaparkContext db;

        public RecreationAreaRepositorySQL(DBAquaparkContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<recreation_area> GetList()
        {
            return db.recreation_area.ToList();
        }

        public recreation_area GetItem(int id)
        {
            return db.recreation_area.Find(id);
        }

        public void Create(recreation_area item)
        {
            db.recreation_area.Add(item);
        }

        public void Update(recreation_area item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            recreation_area item = db.recreation_area.Find(id);
            if (item != null)
                db.recreation_area.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
