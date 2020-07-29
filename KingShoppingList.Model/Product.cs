using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KingShoppingList.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        public virtual ICollection<ListItem> ListItems { get; set; }


        public Product()
        {

        }

        public Product(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }


    }

}
