

using OnlineShop.Data;
using Repositories.Customers;
using Repositories.Items;
using Repositories.Orders;
using Repositories.UOMs;

namespace Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private OnlineShopDBContext _context;
        public ICustomerRepository Customers { get; }
        public IItemRepository Items { get; }
        public IUOMRepository UOMs { get; }
        public IOrderRepository Orders { get; }
        public IOrderDetailsRepository OrderDetails { get; }
        public UnitOfWork(OnlineShopDBContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Items = new ItemRepository(_context);
            UOMs = new UOMRepository(_context);
            Orders = new OrderRepository(_context);
            OrderDetails = new OrderDetailsRepository(_context);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
