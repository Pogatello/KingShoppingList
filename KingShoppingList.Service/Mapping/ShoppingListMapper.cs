using AutoMapper;
using KingShoppingList.Messeging;
using KingShoppingList.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingShoppingList.Service.Mapping
{
    public static class ShoppingListMapper
    {

        public static ShoppingListDTO MapToDto(this ShoppingList source, IMapper mapper)
        {
            return mapper.Map<ShoppingList, ShoppingListDTO>(source);
        }

        public static IEnumerable<ShoppingListDTO> MapToDto(this IEnumerable<ShoppingList> source, IMapper mapper)
        {
            return mapper.Map<IEnumerable<ShoppingList>, IEnumerable<ShoppingListDTO>>(source);
        }

        public static ShoppingList MapToModel(this ShoppingListDTO source, IMapper mapper)
        {
            return mapper.Map<ShoppingListDTO, ShoppingList>(source);
        }


    }
}
