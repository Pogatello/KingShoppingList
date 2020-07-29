using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingShoppingList.Model.Repositories
{
    public interface IShoppingListRepository
    {
        public Task<List<ShoppingList>> getAll();
        public  Task<ShoppingList> GetById(int id);
        public  Task Create(ShoppingList shoppingList);

        public Task Edit(ShoppingList shoppingList);

        public Task Delete(ShoppingList shoppingList);

        public bool Exists(int id);
    }
}
