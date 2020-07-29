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

namespace KingShoppingList.Web.Controllers
{
    public class ListItemsController : Controller
    {
        private readonly ShoppingListDbContext _context;
        private readonly IListItemService _listItemService;
        private readonly IProductService _productService;

        public ListItemsController(ShoppingListDbContext context, IListItemService listItemService, IProductService productService)
        {
            _context = context;
            _productService = productService;
            _listItemService = listItemService;
        }

        
        public async Task<IActionResult> Index()
        {
            var list = await _listItemService.getAll();
            return View(list.OrderBy(l => l.InCart ? 0 : 1).ThenBy(l => l.Product.Name));
        }

        
        // ne koristim
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listItem = await _listItemService.GetById(id.Value);
            if (listItem == null)
            {
                return NotFound();
            }

            return View(listItem);
        }

        
      
        public IActionResult Create(int shoppinglistid)
        {
            //DORADI
            ViewData["ProductId"] = new SelectList( _productService.getAll(), "Id", "Name");
            ViewData["ShoppingListId"] = shoppinglistid;
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantity,ProductId,ShoppingListId")] ListItem listItem)
        {
            if (ModelState.IsValid)
            {
                await _listItemService.Create(listItem);
                return RedirectToAction("Details", "ShoppingLists", new { id = listItem.ShoppingListId });
            }

            //DORADI
            ViewData["ProductId"] = new SelectList(_productService.getAll(), "Id", "Name", listItem.ProductId);

            return RedirectToAction("Index", "ShoppingLists");
        }

        // GET: ListItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listItem = await _listItemService.GetById(id.Value);
            if (listItem == null)
            {
                return NotFound();
            }
            //DORADI
            ViewData["ProductId"] = new SelectList(_productService.getAll(), "Id", "Name", listItem.ProductId);
            // ViewData["ShoppingListId"] = new SelectList(_context.ShoppingLists, "Id", "Id", listItem.ShoppingListId);
            return View(listItem);
        }

        // POST: ListItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,ProductId,ShoppingListId")] ListItem listItem)
        {
            if (id != listItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _listItemService.Edit(listItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListItemExists(listItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "ShoppingLists", new { id = listItem.ShoppingListId });
            }
            ViewData["ProductId"] = new SelectList(_productService.getAll(), "Id", "Name", listItem.ProductId);
           // ViewData["ShoppingListId"] = new SelectList(_context.ShoppingLists, "Id", "Id", listItem.ShoppingListId);
            return View(listItem);
        }

        // GET: ListItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listItem = await _listItemService.GetById(id.Value);
            if (listItem == null)
            {
                return NotFound();
            }

            return View(listItem);
        }

        

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listItem = await  _listItemService.GetById(id);
            await _listItemService.Delete(listItem);

            return RedirectToAction("Details", "ShoppingLists", new { id = listItem.ShoppingListId });
        }

        private bool ListItemExists(int id)
        {
            return _listItemService.Exists(id);
        }
    }
}
