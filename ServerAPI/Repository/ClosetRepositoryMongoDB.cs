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
        
        private IMongoClient client;
        private readonly IMongoCollection<tøj> tøjcollection;

        public ClosetRepositoryMongoDB()
        {
            // atlas database
            //var password = ""; //add
            //var mongoUri = $"mongodb+srv://olee58:{password}@cluster0.olmnqak.mongodb.net/?retryWrites=true&w=majority";
           
            //local mongodb
            var mongoUri = "mongodb://localhost:27017/";
            
            try
            {
                client = new MongoClient(mongoUri);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem connecting to your " +
                                  "Atlas cluster. Check that the URI includes a valid " +
                                  "username and password, and that your IP address is " +
                                  $"in the Access List. Message: {e.Message}");
                throw; }

            // Provide the name of the database and collection you want to use.
            var dbName = "LALCloset";
            var collectionName = "Clothes";

            tøjcollection = client.GetDatabase(dbName)
                .GetCollection<tøj>(collectionName);
        }


        public tøj[] GetAll()
        {
            return tøjcollection.Find(new BsonDocument()).ToList().ToArray();
        }

        public void Add(tøj item)
        {
            tøjcollection.InsertOne(item);
        }

        public void Remove(int id)
        {
            tøjcollection.DeleteOne(t => t.id == id);
        }

        public void Update(tøj item)
        {
            var updateDef = Builders<tøj>.Update
                .Set(x => x.type, item.type)
                .Set(x => x.størrelse, item.størrelse)
                .Set(x => x.farve, item.farve)
                .Set(x => x.mærke, item.mærke)
                .Set(x => x.beskrivelse, item.beskrivelse)
                .Set(x => x.img, item.img)
                .Set(x => x.slutDato, item.slutDato)
                .Set(x => x.reserveret, item.reserveret);
            tøjcollection.UpdateOne(x => x.id == item.id, updateDef);
            
        }
    }
}