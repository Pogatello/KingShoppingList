using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KingShoppingList.Model
{
    public class ShoppingCart
    {
        
        public int Id { get; set; }
        public virtual ICollection<ListItem> ListItems { get; set; }

        public ShoppingCart()
        {
            ListItems = new List<ListItem>();
        }
    }
}
