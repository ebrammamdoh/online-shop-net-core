using AutoMapper;
using OnlineShop.Services.Models;
using Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Services.CustomersService
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(CustomerDTO model)
        {
            _unitOfWork.Customers.Create(new Data.Entities.Customer
            {
                DescriptionAr = model.DescriptionAr,
                DescriptionEn = model.DescriptionEn,
                UserId = model.UserId
            });
            _unitOfWork.SaveChanges();
        }

        public CustomerDTO GetCustomerByUserId(string userId)
        {
            var customer = _unitOfWork.Customers.GetWhere(c => c.UserId == userId).FirstOrDefault();
            return _mapper.Map<CustomerDTO>(customer);
        }
    }
}
