using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KingShoppingList.Model;
using KingShoppingList.Repository;
using KingShoppingList.Contract;
using Newtonsoft.Json;

namespace KingShoppingList.Web.Controllers
{
    public class ShoppingListsController : Controller
    {
        private readonly IShoppingListService _shoppingListService;
        private readonly IListItemService _listItemService;

        public ShoppingListsController(ShoppingListDbContext context, IShoppingListService shoppingListService, IListItemService listItemService)
        {
            _shoppingListService = shoppingListService;
            _listItemService = listItemService;
        }

        // done
        public async Task<IActionResult> Index()
        {
            return View(await _shoppingListService.getAll());
        }

        // done
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingList = await _shoppingListService.GetById(id.Value);


            if (shoppingList == null)
            {
                return NotFound();
            }

            //istrazi linq
            var insideList = shoppingList.ListItems;
            insideList = insideList.OrderBy(d => d.InCart).ThenBy(d => d.Product.Name).ToList();
            shoppingList.ListItems = insideList;

            return View(shoppingList);
        }

        // done
        public IActionResult Create()
        {
            return View();
        }

        //done
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,published")] ShoppingList shoppingList)
        {
            if (ModelState.IsValid)
            {
                await _shoppingListService.Create(shoppingList);
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingList);
        }





        // done
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingList = await _shoppingListService.GetById(id.Value);
            if (shoppingList == null)
            {
                return NotFound();
            }
            return View(shoppingList);
        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,published")] ShoppingList shoppingList)
        {
            if (id != shoppingList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _shoppingListService.Edit(shoppingList);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingListExists(shoppingList.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingList);
        }


        public async Task<IActionResult> RemoveProductsInCart(int idShoppingList)
        {

            var listItems = _listItemService.getAll().Result.Where(p => p.InCart == true && p.ShoppingListId == idShoppingList);

            foreach (var listItem in listItems)
            {
                try
                {
                    listItem.InCart = false;
                    await _listItemService.Edit(listItem);

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;

                }
            }
            return RedirectToAction("Index", "ShoppingLists");







        }


        public async Task<IActionResult> Delete(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var shoppingList = await _shoppingListService.GetById(id.Value);
            if (shoppingList == null)
            {
                return NotFound();
            }

            var itemsInCart = new List<ListItem>();
            foreach (var li in shoppingList.ListItems)
            {
                if(li.InCart == true)
                {
                    itemsInCart.Add(li);


                }
            }
            if(itemsInCart.Count != 0)
            {
                ViewBag.shoppingListId = id;
                return View("DeleteError", itemsInCart);

            }
           

            return View(shoppingList);
        }

        // POST: ShoppingLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingList = await _shoppingListService.GetById(id);

            await _shoppingListService.Delete(shoppingList);
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingListExists(int id)
        {
            return _shoppingListService.Exists(id);
        }




















    }
}
