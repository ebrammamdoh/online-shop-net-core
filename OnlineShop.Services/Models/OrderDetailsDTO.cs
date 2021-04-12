using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Models
{
    public class OrderDetailsDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get { return TotalAfterDiscount > 0 ? TotalAfterDiscount : 0; } private set { } }
        public string UOM { get; set; }
        public decimal Tax { get { return SubTotal * Infrastructure.Constants.Taxes.PercentageTax / 100; } private set { } }
        public decimal Discount { get; set; }
        public decimal SubTotal { get { return ItemPrice * Quantity; } private set { } }
        private decimal TotalAfterDiscount { get { return Math.Round(SubTotal + Tax - Infrastructure.Constants.Discount.DiscountValue, 2); } set { } }
    }
}
