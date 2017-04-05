using System;
using System.Collections.Generic;

namespace ECommerce.Models
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }
        public int CountTaken {get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }


        public Order()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}