using RealState.Core.Entity;
using System.Collections.Generic;

namespace RealState.Core.Services
{
    public interface ITransactionService
    {
        Transaction AddNewTransaction(Transaction block);
        IEnumerable<Transaction> GetAllTransaction();
        Transaction GetTransactionById(int id);
        void EditTransaction(Transaction block);
        void Remove(int id);
        IEnumerable<Transaction> GetTransactions(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered);
    }
}