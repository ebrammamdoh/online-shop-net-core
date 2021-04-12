using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Data.Entities
{
    public class AttributeName : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<AttributeNameItem> AttributeNameItems { get; set; }
    }
}
