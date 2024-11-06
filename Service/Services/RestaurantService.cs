using Core.DTOS;
using Core.Interfaces;

namespace Service.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository) 
        {
            _restaurantRepository = restaurantRepository;
        }


        public async Task<List<RestaurantDTO>> GetRestaurantsAsync()
        {
            var restaurants = await _restaurantRepository.GetRestaurantsAsync();

            return restaurants.Select(r=>new RestaurantDTO(r.Id,r.Name,r.Address,r.Phone,r.Email,r.ImageUrl)).ToList();
        }
        public async Task<RestaurantBranchDTO> GetRestaurantBranchByRestaurantIdAsync(int restaurantId)
        {
            var restaurant = await _restaurantRepository.GetRestaurantBranchByRestaurantIdAsync(restaurantId);

            return new RestaurantBranchDTO(restaurant.Id,restaurant.RestaurantId,restaurant.Name,restaurant.Address,restaurant.Phone,restaurant.Email,restaurant.ImageUrl);
        }
    }
}
