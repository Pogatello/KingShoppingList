using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingShoppingList.Contract;
using KingShoppingList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KingShoppingList.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IListItemService _listItemService;
        private ShoppingCart shoppingCart;

        public CartController( IListItemService listItemService)
        {
        _listItemService = listItemService;
         shoppingCart = new ShoppingCart();
        
        }







        public async Task<IActionResult> AddToCart(int id, int shpId)
        {

            var listItem = _listItemService.GetById(id);
            listItem.Result.InCart = !listItem.Result.InCart;

                try
                {
                    await _listItemService.Edit(listItem.Result);
               
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
                    
                }
                return RedirectToAction("Details", "ShoppingLists",new { id = shpId });
        }


        public IActionResult Refresh()
        {

            var list = _listItemService.getAll().Result.Where(a => a.InCart == true);
            if (this.shoppingCart.ListItems.Count == 0)
            {
                this.shoppingCart.ListItems = list.ToList();
            }
            else
            {
                foreach(var itm in list)
                {
                    this.shoppingCart.ListItems.Add(itm);
                }
            }
            return PartialView("_ShoppingCart", this.shoppingCart);
        }

        
        public IActionResult RefreshPerCart(int id)
        {
            var aa = id;

            var list = _listItemService.getAll().Result.Where(a=> a.ShoppingListId == id).Where(a => a.InCart == true);
            if (this.shoppingCart.ListItems.Count == 0)
            {
                this.shoppingCart.ListItems = list.ToList();
            }
            else
            {
                foreach (var itm in list)
                {
                    this.shoppingCart.ListItems.Add(itm);
                }
            }
            return PartialView("_ShoppingCart", this.shoppingCart);
        }


        

    }


    }
