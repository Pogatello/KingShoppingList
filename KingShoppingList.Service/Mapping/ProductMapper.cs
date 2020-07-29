using AutoMapper;
using KingShoppingList.Messeging;
using KingShoppingList.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingShoppingList.Service.Mapping
{
    public static class ProductMapper
    {


        public static ProductDTO MapToDto(this Product source, IMapper mapper)
        {
            return mapper.Map<Product, ProductDTO>(source);
        }

        public static IEnumerable<ProductDTO> MapToDto(this IEnumerable<Product> source, IMapper mapper)
        {
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(source);
        }

        public static Product MapToModel(this ProductDTO source, IMapper mapper)
        {
            return mapper.Map<ProductDTO, Product>(source);
        }







    }
}
