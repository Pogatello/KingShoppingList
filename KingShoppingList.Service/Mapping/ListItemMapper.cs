using AutoMapper;
using KingShoppingList.Messeging;
using KingShoppingList.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingShoppingList.Service.Mapping
{
    public static class ListItemMapper
    {
        public static ListItemDTO MapToDto(this ListItem source, IMapper mapper)
        {
            return mapper.Map<ListItem, ListItemDTO>(source);
        }

        public static IEnumerable<ListItemDTO> MapToDto(this IEnumerable<ListItem> source, IMapper mapper)
        {
            return mapper.Map<IEnumerable<ListItem>, IEnumerable<ListItemDTO>>(source);
        }

        public static ListItem MapToModel(this ListItemDTO source, IMapper mapper)
        {
            return mapper.Map<ListItemDTO, ListItem>(source);
        }



    }
}
