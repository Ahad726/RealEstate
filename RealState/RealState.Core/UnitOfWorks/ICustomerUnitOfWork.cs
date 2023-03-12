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
    public interface ICustomerUnitOfWork : IUnitOfWork<RealStateContext>
    {
        ICustomerRepository CustomerRepository { get; set; }
    }
}
