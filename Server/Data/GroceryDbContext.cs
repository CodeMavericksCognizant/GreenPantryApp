using GreenPantryApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenPantryApp.Server.Data
{
    public class GroceryDbContext: DbContext
    {
        public GroceryDbContext(DbContextOptions<GroceryDbContext> options) : base(options)
        {

        }
        public DbSet<GroceryItem> Groceries { get; set; }
    }
   
}
