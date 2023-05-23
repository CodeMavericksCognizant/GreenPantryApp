using GreenPantryApp.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GreenPantryApp.Server.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Food> Foods { get; set; }
    }
}
