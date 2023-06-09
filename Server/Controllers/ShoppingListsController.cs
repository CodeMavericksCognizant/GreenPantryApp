﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenPantryApp.Server.Data;
using GreenPantryApp.Server.Models;
using System.Security.Claims;

namespace GreenPantryApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ShoppingListsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/ShoppingLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingList>>> GetShoppingLists()
        {
          if (_context.ShoppingLists == null)
          {
              return NotFound();
          }
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var items = await _context.ShoppingLists.ToListAsync();
            return (List<ShoppingList>)items.Where(o => o.UserId == userId).ToList();
        }

        // GET: api/ShoppingLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingList>> GetShoppingList(int id)
        {
          if (_context.ShoppingLists == null)
          {
              return NotFound();
          }
            var shoppingList = await _context.ShoppingLists.FindAsync(id);

            if (shoppingList == null)
            {
                return NotFound();
            }

            return shoppingList;
        }

        // PUT: api/ShoppingLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingList(int id, ShoppingList shoppingList)
        {
            if (id != shoppingList.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShoppingLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShoppingList>> PostShoppingList(ShoppingList shoppingList)
        {
          if (_context.ShoppingLists == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ShoppingLists'  is null.");
          }
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            shoppingList.UserId = userId;
            _context.ShoppingLists.Add(shoppingList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingList", new { id = shoppingList.Id }, shoppingList);
        }

        // DELETE: api/ShoppingLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingList(int id)
        {
            if (_context.ShoppingLists == null)
            {
                return NotFound();
            }
            var shoppingList = await _context.ShoppingLists.FindAsync(id);
            if (shoppingList == null)
            {
                return NotFound();
            }

            _context.ShoppingLists.Remove(shoppingList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoppingListExists(int id)
        {
            return (_context.ShoppingLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
