using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Data.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<AttributeNameItem> AttributeNameItems { get; set; }
        public string Description { get; set; }
        public int UOMId { get; set; }
        public UOM UOM { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
