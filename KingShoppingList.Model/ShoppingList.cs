using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KingShoppingList.Model
{
    public class ShoppingList
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        public bool published { get; set; }


        public virtual ICollection<ListItem> ListItems { get; set; }

        public ShoppingList()
        {

        }


    }
}
