using GreenPantryApp.Server.Data;
using GreenPantryApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenPantryApp.Server.Repository
{
    public class FoodRepository : IRepository<Food>
    {
        private readonly ApplicationDbContext _dbContext;
        public FoodRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Food> CreateAsync(Food _object)
        {
            var obj = await _dbContext.Foods.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        public async Task UpdateAsync(Food _object)
        {
            _dbContext.Foods.Update(_object);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Food>> GetAllAsync()
        {
            return await _dbContext.Foods.ToListAsync();
        }
        public async Task<Food> GetByIdAsync(int Id)
        {
            return await _dbContext.Foods.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task DeleteAsync(int id)
        {
            var data = _dbContext.Foods.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
