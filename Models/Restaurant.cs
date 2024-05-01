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
        
        [BsonElement("name")]
        public string Name { get; set; }
    }

    public class Address
    {
        [BsonElement("zipcode")]
        public string Zipcode { get; set; }
    }

    
}
