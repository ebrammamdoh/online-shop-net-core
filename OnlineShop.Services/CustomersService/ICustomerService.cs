using OnlineShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.CustomersService
{
    public interface ICustomerService
    {
        CustomerDTO GetCustomerByUserId(string userId);
        void Create(CustomerDTO model);
    }
}
