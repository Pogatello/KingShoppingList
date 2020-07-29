using AutoMapper;
using KingShoppingList.Messeging;
using KingShoppingList.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingShoppingList.Service.Mapping
{
    public class ListItemProfile : Profile
    {

        public ListItemProfile()
        {

            CreateMap<ListItem, ListItemDTO>();
            CreateMap<ListItemDTO, ListItem>();
        }

    }
}
