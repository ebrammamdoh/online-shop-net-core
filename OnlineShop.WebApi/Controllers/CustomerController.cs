using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.CustomersService;
using OnlineShop.WebApi.Models;

namespace OnlineShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public ActionResult Post([FromBody] CreateCustomerModel model)
        {
            try
            {
                _customerService.Create(new Services.Models.CustomerDTO
                {
                    UserId = model.UserId,
                    DescriptionEn = model.DescriptionEn,
                    DescriptionAr = model.DescriptionAr
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
