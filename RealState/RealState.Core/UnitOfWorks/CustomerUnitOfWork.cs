using RealState.Core.Context;
using RealState.Core.Repositories;
using RealState.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.UnitOfWorks
{
    public class CustomerUnitOfWork : UnitOfWork<RealStateContext>, ICustomerUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; set; }

        public CustomerUnitOfWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            CustomerRepository = new CustomerRepository(_dbContext);
        }
    }
}