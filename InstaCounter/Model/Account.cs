using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace InstaCounter
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Username { set; get; }
        public Medium Medium { set; get; }
        public IList<Measurement> Measurements = new List<Measurement>();

        public Account(string username, Medium medium)
        {
            Username = username;
            Medium = medium;
        }
    }
    
}