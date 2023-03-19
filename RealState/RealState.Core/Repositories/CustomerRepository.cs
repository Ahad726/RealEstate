using Microsoft.EntityFrameworkCore;
using RealState.Core.Entity;
using RealState.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Repositories
{
    public class CustomerRepository : Repository<Customer> , ICustomerRepository
    {
        private DbContext _dbContext;
        private DbSet<Customer> _customerDB;
        public CustomerRepository(DbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _customerDB = _dbContext.Set<Customer>();
        }


        public async Task<IList<Customer>> GetCustomerAsync()
        {
            var customers = await _customerDB.ToListAsync();
            return customers;
        }


    }
}
