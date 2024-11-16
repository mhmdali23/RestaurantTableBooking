using Core.Entities;
using Core.Interfaces;
using Data.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Service.Services
{
    public class SeedService
    {
        private readonly RestaurantAppDbContext _context;
        private readonly IFileService _fileService;
        private readonly ILoggerAdapter<SeedService> _logger;
        private readonly string? _seedDataPath;

        public SeedService(RestaurantAppDbContext context, IFileService fileService, ILoggerAdapter<SeedService> logger, IConfiguration configuration)
        {
            _context = context;
            _fileService = fileService;
            _logger = logger;
            _seedDataPath = configuration["SeedDataPath"];
        }

        public async Task SeedDataAsync()
        {
            try
            {
                _logger.LogInformation("Starting the data seeding process...");

                // Call each seeding method independently
                await SeedRestaurantsAsync();
                await SeedBranchesAsync();

                _logger.LogInformation("Data seeding completed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred during the seeding process.");
                throw;
            }
        }

        private async Task SeedRestaurantsAsync()
        {
            if (_context.Restaurants.Any())
            {
                _logger.LogInformation("Restaurants already exist in the database. Skipping restaurant seeding.");
                return;
            }

            _logger.LogInformation("No restaurants found in the database, seeding data...");

            var restaurantsPath = Path.Combine(_seedDataPath, "restaurants.json");

            if (!File.Exists(restaurantsPath))
            {
                _logger.LogError(new FileNotFoundException(), $"Restaurants file not found at path: {restaurantsPath}");
                return;
            }

            var restaurantsJsonData = await _fileService.ReadFileAsync(restaurantsPath);
            var restaurants = JsonSerializer.Deserialize<List<Restaurant>>(restaurantsJsonData);

            if (restaurants == null || !restaurants.Any())
            {
                _logger.LogError(new Exception("Invalid JSON data"), "No valid restaurant data found in the JSON file.");
                return;
            }

            _logger.LogInformation($"Found {restaurants.Count} restaurants to seed.");
            _context.Restaurants.AddRange(restaurants);
            await _context.SaveChangesAsync();
        }

        private async Task SeedBranchesAsync()
        {
            if (_context.RestaurantBranches.Any())
            {
                _logger.LogInformation("Branches already exist in the database. Skipping branch seeding.");
                return;
            }

            _logger.LogInformation("No branches found in the database, seeding data...");

            var branchesPath = Path.Combine(_seedDataPath, "restaurant_branches.json");

            if (!File.Exists(branchesPath))
            {
                _logger.LogError(new FileNotFoundException(), $"Branches file not found at path: {branchesPath}");
                return;
            }

            var branchesJsonData = await _fileService.ReadFileAsync(branchesPath);
            var branches = JsonSerializer.Deserialize<List<RestaurantBranch>>(branchesJsonData);

            if (branches == null || !branches.Any())
            {
                _logger.LogError(new Exception("Invalid JSON data"), "No valid branch data found in the JSON file.");
                return;
            }

            _logger.LogInformation($"Found {branches.Count} branches to seed.");

            foreach (var branch in branches)
            {
                var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == branch.RestaurantId);
                if (restaurant != null)
                {
                    _logger.LogInformation($"Seeding branch: {branch.Name} for restaurant: {restaurant.Name}");
                    _context.RestaurantBranches.Add(branch);
                }
                else
                {
                    _logger.LogWarning($"Branch {branch.Name} is missing a valid associated restaurant.");
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
