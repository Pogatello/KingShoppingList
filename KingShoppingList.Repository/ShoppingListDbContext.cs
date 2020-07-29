using KingShoppingList.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace KingShoppingList.Repository
{
    public class ShoppingListDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }




        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
        : base(options)
        {
        }

        public ShoppingListDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }


    }
}
