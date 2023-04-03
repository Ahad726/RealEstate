using Autofac;
using RealState.Core.Services;
using RealState.Models.PlotBooking;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

namespace RealState.Models.TransactionModels
{
    public class TransactionVM
    {
        private ITransactionService _transactionService;
        private ICategoryService _categoryService;
        private IAccountService _accountService;

        public TransactionVM()
        {
            _transactionService = Startup.AutofacContainer.Resolve<ITransactionService>();
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
            _accountService = Startup.AutofacContainer.Resolve<IAccountService>();
        }


        public object GetExpenses(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _transactionService.GetTransactions(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);

            var expenselList = new List<TransactionModel>();

            foreach (var expense in records)
            {
                var category = _categoryService.GetCategoryById(expense.CategoryId).Name;
                var accountName = _accountService.GetAccountById(expense.AccountId).Name;

                expenselList.Add(new TransactionModel
                {
                    Id = expense.Id,
                    AccountId = expense.AccountId,
                    Description = expense.Description,
                    Amount = expense.Amount,
                    Date = expense.Date,
                    Time = expense.Time,
                    ImageUrl = expense.ImageUrl,
                    AccountName = accountName,
                    CategoryName = category

                }); ;
            }


            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in expenselList
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.AccountName,
                                record.CategoryName,
                                record.Amount.ToString(),
                                record.Date.ToString("MM/dd/yyyy"),
                                record.Time.ToString(),
                                record.ImageUrl
                        }
                    ).ToArray()

            };
        }
    }
}
