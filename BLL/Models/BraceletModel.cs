using DLL.EF;
using DLL.Entity1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class BraceletModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int Deposit { get; set; }
        public BraceletModel(bracelet b) 
        {
            Id = b.Bracelet_id;
            CustomerId = b.Customer_id;
            Deposit = b.Deposit;
        }
        public BraceletModel() { }
    }
}
