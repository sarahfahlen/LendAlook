using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;

namespace ServerAPI.Repository
{
    public class ClosetRepositoryMongoDB : IClosetRepository
    {
        private readonly IMongoCollection<tøj> _collection;

        public ClosetRepositoryMongoDB()
        {
            var connectionString = "mongodb+srv://App:app1234@lalapp.mgblbd3.mongodb.net/?retryWrites=true&w=majority&appName=LALApp";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("LALApp"); 
            _collection = database.GetCollection<tøj>("clothes"); 
        }


        public tøj[] GetAll()
        {
            return _collection.Find(new BsonDocument()).ToList().ToArray();
        }

        public void Add(tøj item)
        {
            _collection.InsertOne(item);
        }

        public void Remove(int id)
        {
            _collection.DeleteOne(t => t.id == id);
        }

        public void Update(int id, bool isDone)
        {
            var update = Builders<tøj>.Update.Set("isDone", isDone); 
            _collection.UpdateOne(t => t.id == id, update);
        }
    }
}