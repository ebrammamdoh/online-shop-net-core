using OnlineShop.Data;
using OnlineShop.Data.Entities;

namespace Repositories.Customers
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(OnlineShopDBContext context) : base(context)
        {
        }
    }
}
