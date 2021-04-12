using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.WebApi.Models
{
    public class CreateOrderModel
    {
        public List<OrderItemModel> OrderItemModels { get; set; }
    }
}
