using FoodieFinder.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace FoodieFinder;

internal class RestaurantDbContext : DbContext
{
    public DbSet<Restaurant> Restaurants { get; init; }

    public static RestaurantDbContext Create(IMongoDatabase database)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RestaurantDbContext>();
        optionsBuilder.EnableSensitiveDataLogging().UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName);

        var dbContext = new RestaurantDbContext(optionsBuilder.Options);
        return dbContext;

    }
    
    
    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
    {}
       
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity <Restaurant> ();
    }
}