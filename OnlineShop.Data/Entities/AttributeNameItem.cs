using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Data.Entities
{
    public class AttributeNameItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int AttributeNameId { get; set; }
        public AttributeName AttributeName { get; set; }
    }
}
