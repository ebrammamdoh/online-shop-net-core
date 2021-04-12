using Repositories.Customers;
using Repositories.Items;
using Repositories.Orders;
using Repositories.UOMs;

namespace Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IItemRepository Items { get; }
        IUOMRepository UOMs { get; }
        IOrderRepository Orders { get; }
        IOrderDetailsRepository OrderDetails { get; }
        void SaveChanges();
    }
}
