using System;
using System.Collections.Generic;
using System.Text;

namespace KingShoppingList.Messeging
{
    public class ProductDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<ListItemDTO> ListItems { get; set; }


        public ProductDTO(int id, string name, List<ListItemDTO> listItems)
        {
            this.Id = id;
            this.Name = name;
            this.ListItems = listItems;
        }

    }
}
