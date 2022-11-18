using DLL.EF;
using DLL.Entity1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public CustomerModel(Customer c)
        {
            Name = c.Name;
            Status = c.Status;
            Id = c.Customer_ID;
        }
    }
}
