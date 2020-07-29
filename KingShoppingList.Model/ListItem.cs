using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingShoppingList.Model
{
    public class ListItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }





        [ForeignKey(nameof(Product))]
        public int? ProductId { get; set; }
        public Product Product { get; set; }



        [ForeignKey(nameof(ShoppingList))]
        public int ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }

       
        public bool InCart { get; set; }

        public ListItem()
        {

        }


    }
}
