// See https://aka.ms/new-console-template for more information

using FoodieFinder;
using FoodieFinder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;


// Fetch MongoDB Atlas Connection String from User Secrets
IConfiguration config = new ConfigurationBuilder()
    .AddUserSecrets<MongoDBSettings>()
    .Build();

string MongoDBAtlasConnectionString = config.GetValue<string>("MongoDBAtlasConnectionString");

MongoClient mongoClient = new(MongoDBAtlasConnectionString);
IMongoDatabase database = mongoClient.GetDatabase("sample_restaurants");
IMongoCollection<Restaurant> restaurantCollection = database.GetCollection<Restaurant>("restaurants");

RestaurantDbContext dbContext = RestaurantDbContext.Create(database);

#region DisplayRestaurants
//DisplayRestaurants(5);
#endregion

#region InsertNewRestaurant

//await InsertNewRestaurant(new Restaurant()
//{
//    Id = new ObjectId().ToString(),
//    Name = "My Awesome Restaurant",
//    Borough = "Brooklyn",
//    Cuisine = "American",
//    Address = new Address()
//    {
//        Building = "123",
//        Coord = new double[] { 0, 0 },
//        Street = "Main St",
//        Zipcode = "11201"
//    },
//    Grades = new List<Grade>()
//        {
//            new Grade()
//            {
//                Date = DateTime.Now,
//                GradeLetter = "A",
//                Score = 100
//            }
//        },
//    IsTestData = true,
//    RestaurantId = "123456"
//});

#endregion

#region Find Restaurant By Name

//var newRestaurants = FindRestaurants("My Awesome Restaurant");

//foreach(var newRestaurant in newRestaurants)
//{
//    Console.WriteLine($"{newRestaurant.Id.ToLower()}: {newRestaurant.Name} - {newRestaurant.Borough}, {newRestaurant.Address.Zipcode}");
//}

#endregion

#region Find Restaurant By Id
var restaurant = FindRestaurantById("5eb3d668b31de5d588f42956");
Console.WriteLine($"{restaurant.Id.ToLower()}: {restaurant.Name} - {restaurant.Borough}, {restaurant.Address.Zipcode}");
foreach (var grade in restaurant.Grades)
{
    Console.WriteLine($"Grade: {grade.GradeLetter}, Score: {grade.Score}");
}
#endregion


Console.ReadLine();

void DisplayRestaurants(int numOfDocsToReturn)
{
    var restaurants = dbContext.Restaurants.AsNoTracking().Take(numOfDocsToReturn).AsEnumerable<Restaurant>();

    foreach (var restaurant in restaurants)
    {
        Console.WriteLine($"{restaurant.Id.ToLower()}: {restaurant.Name} - {restaurant.Borough}, {restaurant.Address.Zipcode}");
        foreach (var grade in restaurant.Grades)
        {
            Console.WriteLine($"Grade: {grade.GradeLetter}, Score: {grade.Score}");
        }
        Console.WriteLine("--------------------");
    }
}

async Task InsertNewRestaurant(Restaurant newResturant)
{
    dbContext.Add(newResturant);

    await dbContext.SaveChangesAsync();
}

IEnumerable<Restaurant> FindRestaurants (string restaurantName)
{
    return dbContext.Restaurants.Where(r => r.Name == restaurantName);
}

Restaurant FindRestaurantByName(string restaurantName)
{
    return dbContext.Restaurants.FirstOrDefault(r => r.Name == restaurantName);
}

Restaurant FindRestaurantById(string restaurantId)
{
    return dbContext.Restaurants.FirstOrDefault(r => r.Id == restaurantId);
}