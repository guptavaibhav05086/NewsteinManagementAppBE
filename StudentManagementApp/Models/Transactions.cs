using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementApp.Models
{
    public class Transactions
    {
        public int TransactionId { get; set; }
        public string TransactionType { get; set; }
        public Nullable<int> StudentId { get; set; }
        public decimal Amount { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public string Comment { get; set; }
        public string PaidBy { get; set; }
        public string PaidTo { get; set; }
        public string TransactionMode { get; set; }

       
    }

    public class TransactionResponse
    {
        public List<Transactions> transactions { get; set; }
        public List<UserDetailsModel> students { get; set; }
    }
}