using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.WebApi.Models
{
    public class OrderItemModel
    {
        public int ItemId { get; set; }
        public int Qty { get; set; }
    }
}
