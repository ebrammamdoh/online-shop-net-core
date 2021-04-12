using AutoMapper;
using OnlineShop.Data.Entities;
using OnlineShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.DescriptionAr,
                    opt => opt.MapFrom(src => src.DescriptionAr))
                .ForMember(dest =>
                    dest.DescriptionEn,
                    opt => opt.MapFrom(src => src.DescriptionEn));

        }
    }
}
