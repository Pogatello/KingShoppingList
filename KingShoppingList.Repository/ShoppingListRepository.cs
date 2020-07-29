using KingShoppingList.Model;
using KingShoppingList.Model.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingShoppingList.Repository
{
    public class ShoppingListRepository : IShoppingListRepository
    {

        private readonly ShoppingListDbContext _context;

        public ShoppingListRepository(ShoppingListDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShoppingList>> getAll()
        {
            return await _context.ShoppingLists.Include(s => s.ListItems).ThenInclude(l => l.Product).ToListAsync();
        }


        public async Task<ShoppingList> GetById(int id)
        {
            var shoppingList = await _context.ShoppingLists.Include(s => s.ListItems).ThenInclude(l => l.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
           
            return shoppingList;
        }



        public async Task Create(ShoppingList shoppingList)
        {
            await _context.AddAsync(shoppingList);
            await _context.SaveChangesAsync();

        }

        public async Task Edit(ShoppingList shoppingList)
        {
             _context.Update(shoppingList);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ShoppingList shoppingList)
        {
            _context.ShoppingLists.Remove(shoppingList);
            await _context.SaveChangesAsync();
        }


        public bool Exists(int id)
        {
            return _context.ShoppingLists.Any(e => e.Id == id);
        }









    }

}