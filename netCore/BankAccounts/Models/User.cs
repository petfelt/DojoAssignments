using System;
using System.Collections.Generic;

namespace BankAccounts.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Transaction> Transactions {get; set; }
        public User()
        {
            Balance = 0;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Transactions = new List<Transaction>();
        }
    }
}