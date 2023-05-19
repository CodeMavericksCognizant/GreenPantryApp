using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GreenPantryApp.Server.Data;
using GreenPantryApp.Server.Models;

namespace GreenPantryApp.Server.Controllers
{
    public class GroceryItemsController : Controller
    {
        private readonly GroceryDbContext _context;

        public GroceryItemsController(GroceryDbContext context)
        {
            _context = context;
        }

        // GET: GroceryItems
        public async Task<IActionResult> Index()
        {
              return _context.Groceries != null ? 
                          View(await _context.Groceries.ToListAsync()) :
                          Problem("Entity set 'GroceryDbContext.Groceries'  is null.");
        }

        // GET: GroceryItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Groceries == null)
            {
                return NotFound();
            }

            var groceryItem = await _context.Groceries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groceryItem == null)
            {
                return NotFound();
            }

            return View(groceryItem);
        }

        // GET: GroceryItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroceryItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ExpiryDate,Quantity")] GroceryItem groceryItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groceryItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groceryItem);
        }

        // GET: GroceryItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Groceries == null)
            {
                return NotFound();
            }

            var groceryItem = await _context.Groceries.FindAsync(id);
            if (groceryItem == null)
            {
                return NotFound();
            }
            return View(groceryItem);
        }

        // POST: GroceryItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ExpiryDate,Quantity")] GroceryItem groceryItem)
        {
            if (id != groceryItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groceryItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroceryItemExists(groceryItem.Id))
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
            return View(groceryItem);
        }

        // GET: GroceryItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Groceries == null)
            {
                return NotFound();
            }

            var groceryItem = await _context.Groceries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groceryItem == null)
            {
                return NotFound();
            }

            return View(groceryItem);
        }

        // POST: GroceryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Groceries == null)
            {
                return Problem("Entity set 'GroceryDbContext.Groceries'  is null.");
            }
            var groceryItem = await _context.Groceries.FindAsync(id);
            if (groceryItem != null)
            {
                _context.Groceries.Remove(groceryItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroceryItemExists(int id)
        {
          return (_context.Groceries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
