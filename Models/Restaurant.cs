using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

namespace FoodieFinder.Models
{
    [Collection("restaurants")]
    public class Restaurant
    {
        public ObjectId Id { get; set; }

        [BsonElement("address")]
        public Address Address { get; set; }
        [BsonElement("borough")]
        public string Borough { get; set; }
        [BsonElement("cuisine")]
        public string Cuisine { get; set; }
        [BsonElement("grades")]
        public List<Grade> Grades { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("restaurant_id")]
        public string RestaurantId { get; set; }

    }

    public class Address
    {
        [BsonElement("building")]
        public string Building { get; set; }
        [BsonElement("coord")]
        public float[] Coord { get; set; }
        [BsonElement("street")]
        public string Street { get; set; }

        [BsonElement("zipcode")]
        public string Zipcode { get; set; }
    }

    public class Grade
    {
        public DateTime? Date { get; set; }
        
        public string? GradeAsString { get; set; }
        public int? Score { get; set; }
    }
}