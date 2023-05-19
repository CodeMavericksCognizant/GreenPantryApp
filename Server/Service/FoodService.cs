using GreenPantryApp.Server.Models;
using GreenPantryApp.Server.Repository;
using static GreenPantryApp.Server.Models.Food;

namespace GreenPantryApp.Server.Service
{
    public class FoodService : IFoodService
    {
        private readonly IRepository<Food> _food;
        public FoodService(IRepository<Food> food)
        {
            _food = food;
        }
        public async Task<Food> AddFood(Food food)
        {
            return await _food.CreateAsync(food);
        }
        public async Task<bool> UpdateFood(int id, Food food)
        {
            var data = await _food.GetByIdAsync(id);
            if (data != null)
            {
                data.GroceryItem = food.GroceryItem;
                data.PurchaseDate = food.PurchaseDate;
                data.ExpirationDate = food.ExpirationDate;
                await _food.UpdateAsync(data);
                return true;
            }
            else
                return false;
        }
        public async Task<bool> DeleteFood(int id)
        {
            await _food.DeleteAsync(id);
            return true;
        }
        public async Task<List<Food>> GetAllFoods()
        {
            return await _food.GetAllAsync();
        }
        public async Task<Food> GetFood(int id)
        {
            return await _food.GetByIdAsync(id);
        }
    }
}
