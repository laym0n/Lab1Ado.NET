using BLL.Models;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IReportService
    {
        List<ReportBLL> ExecuteSP(int val1, int val2);
        List<ReportBLL> ReportOrdersByMonth(int Id);
    }
}
