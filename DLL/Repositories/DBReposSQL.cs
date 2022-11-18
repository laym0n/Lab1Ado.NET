using DLL.EF;
using DLL.Entity1;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class DBReposSQL : IUnityOfWork
    {
        private DBAquaparkContext db;
        private BraceletRepositorySQL BraceletRepository;
        private CustomerRepositorySQL CustomerRepository;
        private OperationRepositorySQL OperationRepository;
        private RecreationAreaRepositorySQL RecreationAreaRepository;
        private ReportsRepositorySQL reportRepository;

        public DBReposSQL()
        {
            db = new DBAquaparkContext();
        }

        public IRepository<operation> operations
        {
            get
            {
                if (OperationRepository == null)
                    OperationRepository = new OperationRepositorySQL(db);
                return OperationRepository;
            }
        }

        public IRepository<bracelet> bracelets
        {
            get
            {
                if (BraceletRepository == null)
                    BraceletRepository = new BraceletRepositorySQL(db);
                return BraceletRepository;
            }
        }

        public IRepository<Customer> Customers
        {
            get
            {
                if (CustomerRepository == null)
                    CustomerRepository = new CustomerRepositorySQL(db);
                return CustomerRepository;
            }
        }

        public IRepository<recreation_area> recreation_areas
        {
            get
            {
                if (RecreationAreaRepository == null)
                    RecreationAreaRepository = new RecreationAreaRepositorySQL(db);
                return RecreationAreaRepository;
            }
        }
        public IReportsRepository Reports
        {
            get
            {
                if (reportRepository == null)
                    reportRepository = new ReportsRepositorySQL(db);
                return reportRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
