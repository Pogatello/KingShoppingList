using KingShoppingList.Messeging;
using KingShoppingList.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingShoppingList.Contract
{
    public interface IShoppingListService
    {
        public  Task<List<ShoppingList>> getAll();
        public  Task<ShoppingList> GetById(int id);
        public  Task Create(ShoppingList shoppingList);

        public  Task Edit(ShoppingList shoppingList);

        public Task Delete(ShoppingList shoppingList);
        public bool Exists(int id);
    }
}
