using KingShoppingList.Messeging;
using KingShoppingList.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingShoppingList.Contract
{
    public interface IListItemService
    {
        public Task<List<ListItem>> getAll();
        public Task<ListItem> GetById(int id);
        public Task Create(ListItem listItem);

        public Task Edit(ListItem listItem);

        public Task Delete(ListItem listItem);
        public bool Exists(int id);
    }
}
