using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IReportsRepository
    {
        List<Report> ExecuteSP(int LowSum, int UpSum);
        List<Report> ReportOpByRecArea(int Id);
    }
}
