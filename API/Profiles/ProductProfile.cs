using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDto>().ForMember(target=>target.ProductBrand, member=>member.MapFrom(x=>x.ProductBrand.Name))
                                                .ForMember(target =>target.ProductType, member => member.MapFrom(x => x.ProductType.Name))
                                                .ForMember(target => target.PictureUrl, member => member.MapFrom<ProductUrlResolver>());

            CreateMap<ProductWriteDto, Product>();

        }
    }
}
