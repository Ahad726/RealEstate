using Microsoft.AspNetCore.Http;
using RealState.Core.Entity;
using System;

namespace RealState.Models.TransactionModels
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImageUrl { get; set; }
        public int Flag { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
