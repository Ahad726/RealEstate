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
    public class RealStateUnitOfWork : UnitOfWork<RealStateContext>, IRealStateUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; set; }
        public IBlockRepository BlockRepository { get; set; }
        public IPlotRepository PlotRepository { get; set; }

        public RealStateUnitOfWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            CustomerRepository = new CustomerRepository(_dbContext);
            BlockRepository = new BlockRepository(_dbContext);
            PlotRepository = new PlotRepository(_dbContext);
        }
    }
}