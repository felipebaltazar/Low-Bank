using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbGenericRepository;
using System.Security.Authentication;

namespace LowBank.Api
{
    public class MongoDbContext : IMongoDbContext
    {
        public IMongoClient Client { get; private set; }

        public IMongoDatabase Database { get; private set; }

        public MongoDbContext()
        {
            var config = MongoClientSettings.FromUrl(new MongoUrl("mongodb+srv://felipedasilvabaltazar:<PASS>@lowbankcluster.zmsaz9v.mongodb.net/?retryWrites=true&w=majority"));
            config.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = SslProtocols.Tls12
            };

            Client = new MongoClient(config);
            Database = Client.GetDatabase("LowBankDB");
        }


        public void DropCollection<TDocument>(string partitionKey = null)
        {
            Database.DropCollection(partitionKey);
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>(string partitionKey = null)
        {
            string collectionName = partitionKey ?? typeof(TDocument).Name;

            var result = Database.GetCollection<TDocument>(collectionName);

            return result;
        }

        public void SetGuidRepresentation(GuidRepresentation guidRepresentation)
        {
        }
    }
}
