using Merchant.Ads.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Merchant.Ads.API.Configs;
using Merchant.Ads.API.Extensions;
using System.Text.Json;
using Merchant.Ads.API.Services;
using Merchant.Ads.API.Repositories;


namespace Merchant.Ads.API.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly IMongoCollection<Models.MerchantModel> _merchantCollection;
        private readonly ILogger<MerchantRepository> _logger;
        
        public MerchantRepository(MongoDBSettings mongoDBSetting, ILogger<MerchantRepository> logger)
        {
            const string connectionUri = mongoDBSetting.ConnectionUri;
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            _logger = logger;
            var client = new MongoClient(settings);
            var database = client.GetDatabase("AdsAPI");
            _merchantCollection = database.GetCollection<Models.MerchantModel>("Merchant");
            try
            {
                var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                _logger.LogInformation("MongoDatabase connection has been succesfull");
                Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
            }
            catch (Exception ex)
            {
                _logger.LogInformation("ERROR!Something went wrong");
                Console.WriteLine(ex);
            }
        }
        public List<MerchantModel> GetAll()
        {
            var merchantList = _merchantCollection.Find(Builders<MerchantModel>.Filter.Empty).ToList();
            return merchantList;
        }
        public void Create(MerchantModel merchant)
        {
            _merchantCollection.InsertOne(merchant);//dtbenmerchantalamkicinkullandım
            _logger.LogInformation("Merchant has been created");
            ////InsertOne yeni veri eklemek veya mevcut veriyi güncellemek için kullanılan bir SQL komutu   

        }
        public MerchantModel GetById(int Id)
        {
            var filter = Builders<MerchantModel>.Filter.Eq(merchant => merchant.ID, Id);
            return _merchantCollection.Find(filter).FirstOrDefault();
        }
    }
}
