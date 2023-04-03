using Autofac;
using Microsoft.AspNetCore.Hosting;
using RealState.Core.Entity;
using RealState.Core.Services;
using RealState.SD;

namespace RealState.Models.TransactionModels
{
    public class TransactionUM
    {

        private ITransactionService _transactionService;
        private ICategoryService _categoryService;
        private IAccountService _accountService;
        public TransactionUM()
        {
            _transactionService = Startup.AutofacContainer.Resolve<ITransactionService>();
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
            _accountService = Startup.AutofacContainer.Resolve<IAccountService>();

        }


        public void AddExpense( TransactionModel transaction)
        {
            _transactionService.AddNewTransaction(new Transaction
            {
                Amount = transaction.Amount,
                ImageUrl = transaction.ImageUrl,
                CategoryId = transaction.CategoryId,
                AccountId = transaction.AccountId,
                Date = transaction.Date.Date,
                Time = transaction.Date.TimeOfDay,
                Flag = TransactionType.Expense
            });
        }

        public void AddIncome(TransactionModel transaction)
        {
            _transactionService.AddNewTransaction(new Transaction
            {
                Amount = transaction.Amount,
                ImageUrl = transaction.ImageUrl,
                CategoryId = transaction.CategoryId,
                AccountId = transaction.AccountId,
                Date = transaction.Date.Date,
                Time = transaction.Date.TimeOfDay,
                Flag = TransactionType.Income
            });
        }
    }
}
