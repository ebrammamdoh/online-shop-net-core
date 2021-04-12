using OnlineShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.OrdersService
{
    public interface IOrderService
    {
        bool Create(OrderDTO model);
        OrderHeaderDTO CalculateOrder(OrderDTO model);
    }
}
