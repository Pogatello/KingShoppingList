using System;
using System.Collections.Generic;
using System.Text;

namespace KingShoppingList.Messeging
{
    public class ShoppingListDTO
    {

        public int Id { get; set; }

        public bool published { get; set; }


        public virtual List<ListItemDTO> ListItems { get; set; }


    }
}
