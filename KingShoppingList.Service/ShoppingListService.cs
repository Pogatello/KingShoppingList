using KingShoppingList.Contract;
using KingShoppingList.Model;
using KingShoppingList.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingShoppingList.Service
{
    public class ShoppingListService : IShoppingListService
    {

        private readonly IShoppingListRepository _shoppingListRepository;

        public ShoppingListService(IShoppingListRepository shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }



        public async Task<List<ShoppingList>> getAll()
        {
            return await _shoppingListRepository.getAll();
        
        }
        public async Task<ShoppingList> GetById(int id)
        {
            return await _shoppingListRepository.GetById(id);
        }


        public async Task Create(ShoppingList shoppingList)
        {
             await _shoppingListRepository.Create(shoppingList);
        }

        public async Task Edit(ShoppingList shoppingList)
        {
            await _shoppingListRepository.Edit(shoppingList);
        }

        public async Task Delete(ShoppingList shoppingList)
        {
            await _shoppingListRepository.Delete(shoppingList);
        }


        public bool Exists(int id)
        {
           return _shoppingListRepository.Exists(id);
        }





    }
}
