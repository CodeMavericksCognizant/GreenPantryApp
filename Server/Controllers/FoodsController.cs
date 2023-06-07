using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenPantryApp.Server.Data;
using GreenPantryApp.Server.Models;
using GreenPantryApp.Server.Service;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace GreenPantryApp.Server.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<List<Food>> GetAll()
        {
            return await _foodService.GetAllFoods();
        }

        [HttpGet("{id}")]
        public async Task<Food> Get(int id)
        {
            return await _foodService.GetFood(id);
        }

        [HttpPost]
        public async Task<Food> AddFood([FromBody] Food food)
        {
            return await _foodService.AddFood(food);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteFood(int id)
        {
            await _foodService.DeleteFood(id);
            return true;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateFood(int id, [FromBody] Food Object)
        {
            await _foodService.UpdateFood(id, Object);
            return true;
        }


    }
}