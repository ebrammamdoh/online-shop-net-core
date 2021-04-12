using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Models
{
    public class OrderDTO
    {
        public List<OrderItemDTO> OrderItems { get; set; }
        public int CustomerId { get; set; }
    }
}
