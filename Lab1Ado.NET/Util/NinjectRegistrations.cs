using BLL;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Ado.NET.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IBraceletService>().To<BraceletService>();
            Bind<IReportService>().To<ReportService>();
            Bind<IDbCrud>().To<DataContext>();
        }
    }
}
