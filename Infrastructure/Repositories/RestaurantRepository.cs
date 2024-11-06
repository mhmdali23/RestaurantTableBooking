using Core.Entities;
using Core.Interfaces;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantAppDbContext _dbContext;

        public RestaurantRepository(RestaurantAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<Restaurant>> GetRestaurantsAsync()
        {
            return await _dbContext.Restaurants.AsNoTracking().ToListAsync();
        }

        public async Task<RestaurantBranch> GetRestaurantBranchByRestaurantIdAsync(int restaurantId)
        {
            return await _dbContext.RestaurantBranches.AsNoTracking().Where(r => r.RestaurantId == restaurantId).SingleOrDefaultAsync();
        }

       
    }
}
