using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingShoppingList.Model.Repositories
{
    public interface IListItemRepository
    {

        public Task<List<ListItem>> getAll();
        public Task<ListItem> GetById(int id);
        public Task Create(ListItem listItem);

        public Task Edit(ListItem listItem);

        public Task Delete(ListItem listItem);

        public bool Exists(int id);
    }

}

