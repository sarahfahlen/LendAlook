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

        public void Add(tøj item)
        {
            var max = 0;
            if (todoCollection.Count(Builders<ToDoItem>.Filter.Empty) > 0)
            {
                max = MaxId();
            }
            item.Id = max + 1;
            // alternative:
            //int newid = Guid.NewGuid().GetHashCode();
            //item.Id = newid;
            todoCollection.InsertOne(item);
        }
        
        private int MaxId() {
            /*var noFilter = Builders<BEBike>.Filter.Empty;
            var elementWithHighestId = collection.Find(noFilter).SortByDescending(r => r.Id).Limit(1).ToList()[0];
            return elementWithHighestId.Id;*/
            return GetAll().Select(b => b.Id).Max();
        }

        public void Remove(int id)
        {
            var deleteResult = todoCollection
                .DeleteOne(Builders<ToDoItem>.Filter.Where(r => r.Id == id));
        }
        
        public ToDoItem[] GetAll() {
            var noFilter = Builders<ToDoItem>.Filter.Empty;
            return todoCollection.Find(noFilter).ToList().ToArray();
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