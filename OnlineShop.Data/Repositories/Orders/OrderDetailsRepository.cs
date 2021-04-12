using OnlineShop.Data;
using OnlineShop.Data.Entities;

namespace Repositories.Orders
{
    public class OrderDetailsRepository : RepositoryBase<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(OnlineShopDBContext context) : base(context)
        {
        }
    }
}
