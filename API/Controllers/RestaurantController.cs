using Core.DTOS;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }


        [HttpGet("restaurants")]
        public async Task<ActionResult<IReadOnlyList<RestaurantDTO>>> GetRestaurantsAsync()
        {
            var restaurants = await _restaurantService.GetRestaurantsAsync();
            return Ok(restaurants);
        } 
        
        [HttpGet("restaurants/{restaurantId}")]
        public async Task<ActionResult<RestaurantBranchDTO>> GetRestaurantBranchByRestaurantIdAsync(int restaurantId)
        {
            var restaurant = await _restaurantService.GetRestaurantBranchByRestaurantIdAsync(restaurantId);
            return Ok(restaurant);
        }




    }
}
