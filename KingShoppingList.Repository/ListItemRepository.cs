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
    public class ListItemRepository : IListItemRepository
    {
        private readonly ShoppingListDbContext _context;

        public ListItemRepository(ShoppingListDbContext context)
        {
            _context = context;
        }

        public async Task<List<ListItem>> getAll()
        {
            return await _context.ListItems.Include(l => l.Product).Include(l => l.ShoppingList).ToListAsync();
        }


        public async Task<ListItem> GetById(int id)
        {
           

            var listItem = await _context.ListItems
                .Include(l => l.Product)
                .Include(l => l.ShoppingList)
                .FirstOrDefaultAsync(m => m.Id == id);

            return listItem;
        }



        public async Task Create(ListItem listItem)
        {
            _context.Add(listItem);
            await _context.SaveChangesAsync();

        }

        public async Task Edit(ListItem listItem)
        {
            _context.Update(listItem);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ListItem listItem)
        {
            _context.ListItems.Remove(listItem);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.ListItems.Any(e => e.Id == id);
        }
    }
}
