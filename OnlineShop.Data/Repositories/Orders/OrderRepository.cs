using OnlineShop.Data;
using OnlineShop.Data.Entities;

namespace Repositories.Orders
{
    public class OrderRepository : RepositoryBase<OrderHeader>, IOrderRepository
    {
        public OrderRepository(OnlineShopDBContext context) : base(context)
        {
        }
    }
}
