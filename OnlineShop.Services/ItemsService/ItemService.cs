using OnlineShop.Services.Models;
using Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineShop.Services.ItemsService
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ItemsDTO GetById(int itemId)
        {
            return  _unitOfWork.Items.GetWhere(c => c.Id == itemId).Select(c => new ItemsDTO { 
                Id = c.Id,
                Description = c.Description,
                Name = c.Name,
                Qty = c.Qty,
                UnitPrice = c.UnitPrice,
                UOM = c.UOM.Name,
                Attributes = c.AttributeNameItems.Select(a => a.AttributeName.Name).ToList()
            }).FirstOrDefault();
        }

        public IEnumerable<ItemsDTO> GetAll()
        {
            return _unitOfWork.Items.GetAll().Select(c => new ItemsDTO
            {
                Id = c.Id,
                Description = c.Description,
                Name = c.Name,
                Qty = c.Qty,
                UnitPrice = c.UnitPrice,
                UOM = c.UOM.Name
            }).ToList();
        }
    }
}
