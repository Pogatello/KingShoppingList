using KingShoppingList.Messeging;
using KingShoppingList.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingShoppingList.Contract
{
    public interface IProductService
    {
        List<Product> getAll();
    }
}
