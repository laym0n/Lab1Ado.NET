using DLL.EF;
using DLL.Entity1;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class ReportsRepositorySQL : IReportsRepository
    {
        DBAquaparkContext db = new DBAquaparkContext();
        public ReportsRepositorySQL(DBAquaparkContext db)
        {
            this.db = db;
        }

        public List<Report> ExecuteSP(int LowSum, int UpSum)
        {
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@low_sum", LowSum);
            System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@upper_sum", UpSum);
            var ans = db.Database.SqlQuery<operation>("operations_between @low_sum,@upper_sum", new object[] { param1, param2 })
                .Join(db.recreation_area, i => i.recreation_area_id, i => i.recreation_area_id,
                (op, rec) => new { Id = op.operation_id, sum = op.sum, NameRecArea = rec.Name, BraceletId = op.bracelet_id })
                .Join(db.bracelet, i => i.BraceletId, i => i.Bracelet_id, (op, rec) =>
                new { Id = op.Id, sum = op.sum, NameRecArea = op.NameRecArea, BraceletId = op.BraceletId, IdCustomer = rec.Customer_id })
                .Join(db.Customer, i => i.IdCustomer, i => i.Customer_ID, (op, rec) =>
                new Report { Id = op.Id, sum = op.sum, NameRecreationArea = op.NameRecArea, BraceletId = op.BraceletId, Name = rec.Name })
                .ToList();
            return ans;
        }
        public List<Report> ReportOpByRecArea(int Id)
        {
            DBAquaparkContext db = new DBAquaparkContext();
            List<Report> ans = db.operation.Join(db.recreation_area, i => i.recreation_area_id, i => i.recreation_area_id, (op, rec) => op)
                .Where(i => i.recreation_area_id == Id).ToList()
                .Join(db.recreation_area, i => i.recreation_area_id, i => i.recreation_area_id,
                (op, rec) => new { Id = op.operation_id, sum = op.sum, NameRecArea = rec.Name, BraceletId = op.bracelet_id })
                .Join(db.bracelet, i => i.BraceletId, i => i.Bracelet_id, (op, rec) =>
                new { Id = op.Id, sum = op.sum, NameRecArea = op.NameRecArea, BraceletId = op.BraceletId, IdCustomer = rec.Customer_id })
                .Join(db.Customer, i => i.IdCustomer, i => i.Customer_ID, (op, rec) =>
                new Report { Id = op.Id, sum = op.sum, NameRecreationArea = op.NameRecArea, BraceletId = op.BraceletId, Name = rec.Name })
                .ToList();
            return ans;
        }
    }
}
