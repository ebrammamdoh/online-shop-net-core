using OnlineShop.Data;
using OnlineShop.Data.Entities;

namespace Repositories.UOMs
{
    public class UOMRepository : RepositoryBase<UOM>, IUOMRepository
    {
        public UOMRepository(OnlineShopDBContext context) : base(context)
        {
        }
    }
}
