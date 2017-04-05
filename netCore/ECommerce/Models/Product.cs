using System;
using System.Collections.Generic;

namespace ECommerce.Models
{
    public class Product : BaseEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductLeft { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Order> Orders {get; set; }
        public Product()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Orders = new List<Order>();

        }
    }
}