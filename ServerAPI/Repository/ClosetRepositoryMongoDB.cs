using Core;
using MongoDB.Driver;
using ServerAPI.Repository;

namespace ServerAPI.Repository;

public class ClosetRepositoryMongoDB : IClosetRepository
{
    private IMongoClient client;
        
    private IMongoCollection<tøj> closetCollection;

    public ClosetRepositoryMongoDB() {
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
}