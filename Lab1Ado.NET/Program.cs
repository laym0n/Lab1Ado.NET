using BLL.Interfaces;
using BLL.Util;
using Lab1Ado.NET.Util;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1Ado.NET
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule(""));

            IDbCrud crudServ = kernel.Get<IDbCrud>();
            IBraceletService braceletServ = kernel.Get<IBraceletService>();
            IReportService reportServ = kernel.Get<IReportService>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(crudServ, reportServ, braceletServ));
        }
    }
}
