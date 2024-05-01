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