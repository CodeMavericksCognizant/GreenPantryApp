using GreenPantryApp.Server.Controllers;
using GreenPantryApp.Server.Models;
using GreenPantryApp.Server.Repository;
using System.Security.Claims;
using static GreenPantryApp.Server.Models.Food;

namespace GreenPantryApp.Server.Service
{
    public class FoodService : IFoodService
    {
        private readonly IRepository<Food> _food;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FoodService(IRepository<Food> food, IHttpContextAccessor httpContextAccessor)
        {
            _food = food;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Food> AddFood(Food food)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            food.UserId = userId;
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
                data.Cost = food.Cost;
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
            var items = await _food.GetAllAsync();
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return (List<Food>)items.Where(o => o.UserId == userId).ToList();
        }
        public async Task<Food> GetFood(int id)
        {
            return await _food.GetByIdAsync(id);
        }

    }



}
