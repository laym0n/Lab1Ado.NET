using BLL.Interfaces;
using BLL.Models;
using DLL.EF;
using DLL.Entity1;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DataContext : IDbCrud
    {
        IUnityOfWork db;
        public DataContext(IUnityOfWork db)
        {
            this.db = db;
            
        }
        public List<BraceletModel> GetAllBracelet() => db.bracelets.GetList().Select(i => new BraceletModel(i)).ToList();
        public List<CustomerModel> GetAllCustomer() => db.Customers.GetList().Select(i => new CustomerModel(i)).ToList();
        public List<OperationModel> GetAllOperations() => db.operations.GetList().Select(i => new OperationModel(i)).ToList();
        public List<RecreationAreaModel> GetAllRecreationAres() => db.recreation_areas.GetList().Select(i => new RecreationAreaModel(i)).ToList();
        //public List<OperationModel> GetOperations() => db.operation.ToList().Select(i => new OperationModel(i)).ToList();
        //public List<BraceletModel> GetBracelets() => db.bracelet.ToList().Select(i => new BraceletModel(i)).ToList();
        //public List<RecreationAreaModel> GetRecreationAreas() => db.recreation_area.ToList().Select(i => new RecreationAreaModel(i)).ToList();
        //public List<CustomerModel> GetCustomers() => db.Customer.ToList().Select(i => new CustomerModel(i)).ToList();
        public void UpdateOperation(OperationModel opModel)
        {
            operation op = new operation();
            op.time = opModel.time;
            op.recreation_area_id = opModel.RecreationAreaId;
            op.sum = opModel.sum;
            op.bracelet_id = opModel.BraceletId;
            op.operation_id = opModel.Id;
            db.operations.Update(op);
            db.Save();
        }
        public void CreateOperation(OperationModel opModel)
        {
            operation op = new operation();
            op.time = opModel.time;
            op.recreation_area_id = opModel.RecreationAreaId;
            op.sum = opModel.sum;
            //op.operation_id = opModel.Id;
            op.bracelet_id = opModel.BraceletId;
            op.operation_id = opModel.Id;
            db.operations.Create(op);
            db.Save();
        }
        public void DeleteOperation(int ID)
        {
            db.operations.Delete(ID);
            db.Save();
        }

        public OperationModel GetPhone(int Id)
        {
            return new OperationModel(db.operations.GetItem(Id));
        }
    }
}
