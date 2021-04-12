using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Constants;
using OnlineShop.Services.CustomersService;
using OnlineShop.Services.Models;
using OnlineShop.Services.OrdersService;
using OnlineShop.WebApi.Models;

namespace OnlineShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        public OrdersController(IOrderService orderService, ICustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;
        }
        [HttpPost]
        public ActionResult Post([FromBody] CreateOrderModel model)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "42d9354c-38a1-4e39-91de-dce6dd2e9d66"; // dummy UserId
                var customer = _customerService.GetCustomerByUserId(userId);
                var result = _orderService.Create(new OrderDTO
                {
                    OrderItems = model.OrderItemModels.Select(c => new OrderItemDTO
                    {
                        ItemId = c.ItemId,
                        Qty = c.Qty
                    }).ToList(),
                    CustomerId = customer.Id
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("CalculateOrder")]
        public ActionResult CalculateOrder([FromBody] CreateOrderModel model)
        {
            try
            {
                var result = _orderService.CalculateOrder(new OrderDTO
                {
                    OrderItems = model.OrderItemModels.Select(c => new OrderItemDTO
                    {
                        ItemId = c.ItemId,
                        Qty = c.Qty
                    }).ToList(),
                    CustomerId = 100
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
