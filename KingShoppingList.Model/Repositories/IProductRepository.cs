using System;
using System.Collections.Generic;
using System.Text;

namespace KingShoppingList.Model.Repositories
{
    public interface IProductRepository
    {

        public List<Product> getAll();

    }
}
