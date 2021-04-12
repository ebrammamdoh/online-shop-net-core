using OnlineShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.ItemsService
{
    public interface IItemService
    {
        IEnumerable<ItemsDTO> GetAll();
        ItemsDTO GetById(int itemId);
    }
}
