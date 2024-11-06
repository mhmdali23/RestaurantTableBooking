using Core.DTOS;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<IReadOnlyList<Restaurant>> GetRestaurantsAsync();
        Task<RestaurantBranch> GetRestaurantBranchByRestaurantIdAsync(int restaurantId);

    }
}
