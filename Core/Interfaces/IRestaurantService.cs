using Core.DTOS;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IRestaurantService
    {
        Task<List<RestaurantDTO>> GetRestaurantsAsync();
        Task<RestaurantBranchDTO> GetRestaurantBranchByRestaurantIdAsync(int restaurantId);
    }
}
