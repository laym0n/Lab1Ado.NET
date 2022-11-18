using BLL.Interfaces;
using BLL.Models;
using DLL.EF;
using DLL.Entity1;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BraceletService : IBraceletService
    {
        IUnityOfWork db;
        public BraceletService(IUnityOfWork db)
        {
            this.db = db;
        }
        public void GiveBracelet(BraceletModel br)
        {
            int deposit = new Bonus().RealSum(br.Deposit, db.bracelets.GetList().Count());
            bracelet Bracelet = new bracelet() 
            { 
                Bracelet_id = br.Id,
                Deposit = deposit,
                Customer_id = br.CustomerId
                };
            db.bracelets.Create(Bracelet);
            db.Save();
        }
    }
}
