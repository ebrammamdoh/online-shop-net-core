using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Models
{
    public class OrderHeaderDTO
    {
        public string CustomerName { get; set; }
        public decimal TaxValue { get; set; }
        public string DiscountCode { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<OrderDetailsDTO> OrderDetails { get; set; }
    }
}
