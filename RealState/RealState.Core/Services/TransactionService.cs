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
            return _realStateUnitOfWork.TransactionRepository.GetAll();
        }

        public Transaction GetTransactionById(int id)
        {
            return _realStateUnitOfWork.TransactionRepository.GetById(id);
        }

        public IEnumerable<Transaction> GetTransactions(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            return _realStateUnitOfWork.TransactionRepository.Get(

               out total,
               out totalFiltered,
                x => x.Flag == -1,
               null,
               "",
               pageIndex,
               pageSize,
               true);
        }

        public void Remove(int id)
        {
            _realStateUnitOfWork.TransactionRepository.Remove(id);
            _realStateUnitOfWork.Save();
        }
    }
}
