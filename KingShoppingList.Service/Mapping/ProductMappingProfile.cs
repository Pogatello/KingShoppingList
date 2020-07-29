using AutoMapper;
using KingShoppingList.Messeging;
using KingShoppingList.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingShoppingList.Service.Mapping
{
   public  class ProductMappingProfile : Profile
    {

        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }


    }
}
