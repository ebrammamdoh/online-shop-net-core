using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Data.Entities
{
    public class OrderDetails : BaseEntity
    {
        public int OrderHeaderId { get; set; }
        public virtual OrderHeader OrderHeader { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get { return TotalAfterDiscount > 0 ? TotalAfterDiscount : 0; } set { } }
        public int UOMId { get; set; }
        public virtual UOM UOM { get; set; }
        public decimal Tax { get { return SubTotal * Infrastructure.Constants.Taxes.PercentageTax / 100; } private set { } }
        public decimal Discount { get; set; }
        public decimal SubTotal { get { return ItemPrice * Quantity; } private set { } }
        public decimal TotalAfterDiscount { get { return Math.Round(SubTotal + Tax - Infrastructure.Constants.Discount.DiscountValue, 2); } private set { } }
    }
}
