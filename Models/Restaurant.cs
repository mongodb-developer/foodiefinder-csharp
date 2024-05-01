using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

namespace FoodieFinder.Models;

[Collection("restaurants")]
public class Restaurant
{
    [BsonId]
    public string Id { get; set; }

    [BsonElement("address")]
    public Address Address { get; set; }
    [BsonElement("borough")]
    public string Borough { get; set; }
    [BsonElement("cuisine")]
    public string Cuisine { get; set; }
    [BsonElement("grades")]
    public IEnumerable<Grade> Grades { get; set; }
    [BsonElement("name")]
    public string Name { get; set; }
    [BsonElement("restaurant_id")]
    public string RestaurantId { get; set; }

    [BsonElement("isTestData")]
    public bool? IsTestData { get; set; }

}

public class Address
{
    [BsonElement("building")]
    public string Building { get; set; }
    [BsonElement("coord")]
    public double[] Coord { get; set; }
    [BsonElement("street")]
    public string Street { get; set; }

    [BsonElement("zipcode")]
    public string Zipcode { get; set; }
}

public class Grade
{
    [BsonElement("date")]
    public DateTime? Date { get; set; }

    [BsonElement("grade")]
    public string? GradeLetter { get; set; }
    [BsonElement("score")]
    public int? Score { get; set; }
}







