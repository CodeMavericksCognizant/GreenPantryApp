using GreenPantryApp.Server.Models;
using static GreenPantryApp.Server.Models.Food;

namespace GreenPantryApp.Server.Service
{
    public interface IFoodService
    {
        Task<Food> AddFood(Food food);
        Task<bool> UpdateFood(int id, Food food);
        Task<bool> DeleteFood(int id);
        Task<List<Food>> GetAllFoods();
        Task<Food> GetFood(int id);
    }
}
