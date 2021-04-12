using OnlineShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Data.Entities
{
    public class OrderHeader : BaseEntity
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string TaxCode { get; set; }
        public decimal TaxValue { get; set; }
        public string DiscountCode { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderHeaderStatus Status { get; set; }
        public DateTime? RequestDate { get { return DateTime.Now; } private set { } }
        public DateTime OrderDate { get { return DateTime.Now; } private set { } }
        public DateTime? DuoDate { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
