using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Data.Entities
{
    public class UOM : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
