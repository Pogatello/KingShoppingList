using KingShoppingList.Model;
using KingShoppingList.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingShoppingList.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingListDbContext _context;

        public ProductRepository(ShoppingListDbContext context)
        {
            _context = context;
        }


        public List<Product> getAll()
        {
            return _context.Products.ToList();
        }
    }
}
