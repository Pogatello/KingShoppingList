using System;
using System.Collections.Generic;
using System.Text;

namespace KingShoppingList.Messeging
{
    public class ListItemDTO
    {

        public int Id { get; set; }
        public int Quantity { get; set; }


        public ProductDTO Product { get; set; }


        public ShoppingListDTO ShoppingList { get; set; }


    }
}
