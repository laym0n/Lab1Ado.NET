using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDbCrud
    {
        List<BraceletModel> GetAllBracelet();
        List<CustomerModel> GetAllCustomer();
        List<OperationModel> GetAllOperations();
        List<RecreationAreaModel> GetAllRecreationAres();
        OperationModel GetPhone(int Id);
        void CreateOperation(OperationModel p);
        void UpdateOperation(OperationModel p);
        void DeleteOperation(int id);
    }
}
