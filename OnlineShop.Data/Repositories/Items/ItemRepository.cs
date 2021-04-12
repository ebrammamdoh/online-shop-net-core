using OnlineShop.Data;
using OnlineShop.Data.Entities;

namespace Repositories.Items
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(OnlineShopDBContext context) : base(context)
        {
        }
    }
}
