using System;
using System.Collections.Generic;

namespace ECommerce.Models
{
    public class Customer : BaseEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Order> Orders {get; set; }
        public Customer()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Orders = new List<Order>();

        }
    }
}