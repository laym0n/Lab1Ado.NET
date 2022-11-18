using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using DLL;
using DLL.EF;
using DLL.Interfaces;

namespace BLL.Services
{
    public class ReportService : IReportService
    {
        IUnityOfWork db;
        public ReportService(IUnityOfWork db)
        {
            this.db = db;
        }
        public List<ReportBLL> ReportOrdersByMonth(int Id)
        {
            return (db.Reports.ReportOpByRecArea(Id).Select(i=> new ReportBLL() { Id = i.Id, Name = i.Name, BraceletId = i.BraceletId, sum = i.sum, NameRecreationArea = i.NameRecreationArea}).ToList());
        }
        public List<ReportBLL> ExecuteSP(int val1, int val2)
        {
            return (db.Reports.ExecuteSP(val1, val2).Select(i => new ReportBLL() { Id = i.Id, Name = i.Name, BraceletId = i.BraceletId, sum = i.sum, NameRecreationArea = i.NameRecreationArea }).ToList());
        }
    }
}
