using RealState.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Services
{
    public class TransactionService : ITransactionService
    {
        public Transaction AddNewTransaction(Transaction block)
        {
            throw new NotImplementedException();
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
