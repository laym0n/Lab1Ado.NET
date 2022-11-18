using DLL.EF;
using DLL.Entity1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IUnityOfWork
    {
        IRepository<operation> operations { get; }
        IRepository<bracelet> bracelets { get; }
        IRepository<recreation_area> recreation_areas { get; }
        IRepository<Customer> Customers { get; }
        IReportsRepository Reports { get; }
        int Save();

    }
}
