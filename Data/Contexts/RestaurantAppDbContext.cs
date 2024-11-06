using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public partial class RestaurantAppDbContext : DbContext
{
    public RestaurantAppDbContext()
    {
    }

    public RestaurantAppDbContext(DbContextOptions<RestaurantAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DinningTable> DinningTables { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<RestaurantBranch> RestaurantBranches { get; set; }

    public virtual DbSet<TimeSlot> TimeSlots { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
