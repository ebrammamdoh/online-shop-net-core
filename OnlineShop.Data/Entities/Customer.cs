using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Data.Entities
{
    public class Customer : BaseEntity
    {
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public virtual ICollection<OrderHeader> OrderHeaders { get; set; }
        public string UserId { get; set; }
    }
}
