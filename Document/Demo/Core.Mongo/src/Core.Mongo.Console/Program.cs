using MongoDB.Bson;
using MongoDB.Driver;

namespace Core.Mongo.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("foo");
            var collection = database.GetCollection<BsonDocument>("bar");

            collection.InsertOneAsync(new BsonDocument("Name", "Jack"));

            var list = collection.Find(new BsonDocument("Name", "Jack")).ToList();

            foreach (var document in list)
            {
                System.Console.WriteLine(document["Name"]);
            }
        }
    }
}
