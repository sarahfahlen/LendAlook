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
        private readonly IMongoCollection<bruger> usercollection;

        public ClosetRepositoryMongoDB()
        {
            // atlas database
            var password = "LAL1234";
            var mongoUri = $"mongodb+srv://App:{password}@lalapp.mgblbd3.mongodb.net/?appName=LALApp";

            //local mongodb
            //var mongoUri = "mongodb://localhost:27017/";

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
                throw;
            }

            // Provide the name of the database and collection you want to use.
            var dbName = "LALApp";
            var collectionName = "clothes";
            var collectionUser = "Users";

            tøjcollection = client.GetDatabase(dbName)
                .GetCollection<tøj>(collectionName);
            usercollection = client.GetDatabase(dbName)
                .GetCollection<bruger>(collectionUser);
        }

        public void Add(tøj item)
        {
            var max = 0;
            if (tøjcollection.Count(Builders<tøj>.Filter.Empty) > 0)
            {
                max = MaxId();
            }

            item.id = max + 1;
            // alternative:
            //int newid = Guid.NewGuid().GetHashCode();
            //item.Id = newid;
            tøjcollection.InsertOne(item);
        }

        private int MaxId()
        {
            /*var noFilter = Builders<BEBike>.Filter.Empty;
            var elementWithHighestId = collection.Find(noFilter).SortByDescending(r => r.Id).Limit(1).ToList()[0];
            return elementWithHighestId.Id;*/
            return GetAll().Select(b => b.id).Max();
        }

        public void Remove(int id)
        {
            var deleteResult = tøjcollection
                .DeleteOne(Builders<tøj>.Filter.Where(r => r.id == id));
        }

        public tøj[] GetAll()
        {
            var noFilter = Builders<tøj>.Filter.Empty;
            var items = tøjcollection.Find(noFilter).ToList(); // Henter alle tøj-objekter

            foreach (var item in items)
            {
                if (item.ejerId.HasValue)
                {
                    var ejer = usercollection.Find(u => u.id == item.ejerId.Value).FirstOrDefault();
                    if (ejer != null)
                    {
                        item.ejer = ejer; // Tildeler ejer til tøj-objektet
                    }
                }
            }

            return items.ToArray(); // Returnerer tøj-objekterne som array
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

        public bruger[] GetAllUsers()
        {
            var filter = Builders<bruger>.Filter.Empty;
            return usercollection.Find(filter).ToList().ToArray();
        }
    }
}