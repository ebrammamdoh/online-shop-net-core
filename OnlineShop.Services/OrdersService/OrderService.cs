using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Entities;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Constants;
using OnlineShop.Services.Models;
using Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Services.OrdersService
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Create(OrderDTO model)
        {
            var orderDetails = new List<OrderDetails>();
            decimal totalDiscountValue = 0;
            decimal totalTaxesValue = 0;
            var itemIds = model.OrderItems.Select(o => o.ItemId).ToList();
            var items = _unitOfWork.Items.GetWhere(i => itemIds.Contains(i.Id)).ToList();
            items.ForEach(item =>
            {
                var quentity = model.OrderItems.Where(i => i.ItemId == item.Id).Select(i => i.Qty).FirstOrDefault();
                if (item.Qty < quentity)
                    throw new Exception($"The amount is more than actual Quentity in {item.Name}");
                else
                {
                    item.Qty -= quentity;
                    var oDetails = new OrderDetails
                    {
                        Discount = Discount.DiscountValue,
                        ItemId = item.Id,
                        ItemPrice = item.UnitPrice,
                        Quantity = quentity,
                        UOMId = item.UOMId,
                    };
                    orderDetails.Add(oDetails);
                    totalDiscountValue += Discount.DiscountValue;
                    totalTaxesValue += oDetails.Tax;
                }
            });
            var orderModel = new OrderHeader
            {
                CustomerId = model.CustomerId,
                DiscountCode = Discount.DiscountCode,
                DiscountValue = totalDiscountValue,
                Status = OrderHeaderStatus.Open,
                TaxCode = Taxes.TaxCode,
                TaxValue = totalTaxesValue,
                TotalPrice = orderDetails.Sum(o => o.TotalPrice),
                OrderDetails = orderDetails,
                DuoDate = DateTime.Now.AddDays(2),
            };
            _unitOfWork.Orders.Create(orderModel);
            _unitOfWork.SaveChanges();
            return true;
        }

        public OrderHeaderDTO CalculateOrder(OrderDTO model)
        {
            var orderDetails = new List<OrderDetailsDTO>();
            decimal totalDiscountValue = 0;
            decimal totalTaxesValue = 0;
            var itemIds = model.OrderItems.Select(o => o.ItemId).ToList();
            var items = _unitOfWork.Items.GetWhere(i => itemIds.Contains(i.Id)).Include(i => i.UOM).ToList();
            items.ForEach(item =>
            {
                var quentity = model.OrderItems.Where(i => i.ItemId == item.Id).Select(i => i.Qty).FirstOrDefault();
                if (item.Qty < quentity)
                    throw new Exception($"The amount is more than actual Quentity in {item.Name}");
                else
                {
                    var oDetails = new OrderDetailsDTO
                    {
                        Discount = Discount.DiscountValue,
                        ItemName = item.Name,
                        ItemId = item.Id,
                        ItemPrice = item.UnitPrice,
                        Quantity = quentity,
                        UOM = item.UOM.Name
                    };
                    orderDetails.Add(oDetails);
                    totalDiscountValue += Discount.DiscountValue;
                    totalTaxesValue += oDetails.Tax;
                }
            });
            return new OrderHeaderDTO
            {
                DiscountCode = Discount.DiscountCode,
                DiscountValue = totalDiscountValue,
                TaxValue = totalTaxesValue,
                TotalPrice = orderDetails.Sum(o => o.TotalPrice),
                CustomerName = "",
                OrderDetails = orderDetails
            };
        }
    }
}
