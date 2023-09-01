using MongoDB.Driver;
using System.Security.Authentication;

namespace Low_Bank.Api
{
    public class MongoDbContext
    {
        private IMongoDatabase database;

        public MongoDbContext() 
        {
            var config = MongoClientSettings.FromUrl(new MongoUrl("mongodb+srv://lowbank:tALoRaYwKZXVDqKd@lowbankcluster.btzosuo.mongodb.net/?retryWrites=true&w=majority"));

            config.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = SslProtocols.Tls12
            };

            var client = new MongoClient(config);
            database = client.GetDatabase("LowBankDB");
        }

        public void CreateUser(Customer newCustomer)
        {
            var collection = database.GetCollection<Customer>("Customer");
            collection.InsertOne(newCustomer);
        }

        public List<Customer> GetCustomers()
        {
            var collection = database.GetCollection<Customer>("Customer");
            return collection.Find(c => true).ToList();
        }
    }
}
