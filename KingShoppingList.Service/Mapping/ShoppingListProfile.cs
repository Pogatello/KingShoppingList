using AutoMapper;
using KingShoppingList.Messeging;
using KingShoppingList.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingShoppingList.Service.Mapping
{
    class ShoppingListProfile : Profile
    {

        public ShoppingListProfile() 
        {
            CreateMap<ShoppingList, ShoppingListDTO>();
            CreateMap<ShoppingListDTO, ShoppingList>();

        }
    }
}
