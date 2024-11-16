using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class RestaurantAppDbContext : DbContext
{
    public RestaurantAppDbContext()
    {
    }

    public RestaurantAppDbContext(DbContextOptions<RestaurantAppDbContext> options)
        : base(options)
    {
    }

    public  DbSet<DiningTable> DinningTables { get; set; }

    public  DbSet<Reservation> Reservations { get; set; }

    public  DbSet<Restaurant> Restaurants { get; set; }

    public  DbSet<RestaurantBranch> RestaurantBranches { get; set; }

    public  DbSet<TimeSlot> TimeSlots { get; set; }

    public  DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
