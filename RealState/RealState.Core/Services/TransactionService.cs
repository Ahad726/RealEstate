using RealState.Core.Entity;
using RealState.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private IRealStateUnitOfWork _realStateUnitOfWork;
        public TransactionService( IRealStateUnitOfWork realStateUnitOfWork)
        {
            _realStateUnitOfWork = realStateUnitOfWork;
        }
        public void AddNewTransaction(Transaction transaction)
        {
            _realStateUnitOfWork.TransactionRepository.Add(transaction);
            _realStateUnitOfWork.Save();
        }

        public void EditTransaction(Transaction block)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetAllTransaction()
        {
            throw new NotImplementedException();
        }

        public Transaction GetTransactionById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactions(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
