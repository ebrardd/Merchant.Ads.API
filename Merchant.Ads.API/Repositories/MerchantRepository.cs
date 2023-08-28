using Merchant.Ads.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Merchant.Ads.API.Configs;
using Merchant.Ads.API.Extensions;
using System.Text.Json;
using Merchant.Ads.API.Services;
using Microsoft.AspNetCore.Mvc;
using Merchant.Ads.API.Repositories;
using MongoDB.Driver.Core.Events;
using System;
using Merchant.Ads.API.V1.Models.RequestModels;
using System.Linq.Expressions;


namespace Merchant.Ads.API.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly IMongoCollection<Models.MerchantModel> _merchantCollection;
        private readonly ILogger<MerchantRepository> _logger;

        public MerchantRepository(MongoDBSettings mongoDBSettings, ILogger<MerchantRepository> logger)
        {

            var client = new MongoClient(mongoDBSettings.ConnectionUri);
            var database = client.GetDatabase(mongoDBSettings.DatabaseName);
            _merchantCollection = database.GetCollection<MerchantModel>(mongoDBSettings.CollectionName);

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

        /* public void Create(MerchantCreateRequestModel merchant)
         {
             _merchantCollection.InsertOne(merchant);
             //dtbenmerchantalamkicinkullandım
             _logger.LogInformation("Merchant has been created");
             ////InsertOne yeni veri eklemek veya mevcut veriyi güncellemek için kullanılan bir SQL komutu   

         }*/

        /* public MerchantModel GetById(int Id)
         {
             var filter = Builders<MerchantModel>.Filter.Eq(merchant => merchant.Id, Id);
             return _merchantCollection.Find(filter).FirstOrDefault();
         }
         */

        public async Task<MerchantModel> GetByIdAsync(int id)
        {
            var filter = Builders<MerchantModel>.Filter.Eq("Id", id);
            return await _merchantCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<MerchantCreateRequestModel> CreateAsync(MerchantCreateRequestModel merchantCreateRequestModel)
        {
            await _merchantCollection.InsertOneAsync(merchantCreateRequestModel);
            return merchantCreateRequestModel;
        }


        public async Task<MerchantModel> CreateMerchantAsync(MerchantModel merchantModel)
        {
            await _merchantCollection.InsertOneAsync(merchantModel);
            return merchantModel;
        }

        /* public async Task<MerchantModel> UpdateAsync(int id, MerchantModel merchantModel)
         {
             var filter = Builders<MerchantModel>.Filter.Eq(e => e.Id, id);

             var updatedMerchantModel = await _merchantCollection.FindOneAndUpdateAsync(
                 filter,
                 Builders<MerchantModel>.Update
                     .Set(m => m.FullName, merchantModel.FullName)
                     .Set(m => m.CompanyName, merchantModel.CompanyName)
                     .Set(m => m.TaxNo, merchantModel.TaxNo)
                     .Set(m => m.BankAccountInformation, merchantModel.BankAccountInformation),
                 new FindOneAndUpdateOptions<MerchantModel>
                 {
                     ReturnDocument = ReturnDocument.After
                 });

             return updatedMerchantModel;
         }*/
        public async Task<MerchantModel> UpdateAsync(int id, MerchantModel merchantModel)
        {
            var filter = Builders<MerchantModel>.Filter.Eq(e => e.Id, id);

            await _merchantCollection.ReplaceOneAsync(filter, merchantModel);

            return merchantModel;
        }



        public async Task<MerchantModel> DeleteMerchant(int id, MerchantModel merchantModel)
        {

            var filter = Builders<MerchantModel>.Filter.Eq(m => m.Id, id);
            var result = await _merchantCollection.FindOneAndDeleteAsync(filter);

            return result;
        }
        public async Task<ActionResult<MerchantModel>> Get(int id)
        {
            var filter = Builders<MerchantModel>.Filter.Eq(e => e.Id, id);
            var merchant = await _merchantCollection.Find(filter).FirstOrDefaultAsync();
            return merchant;
        }
        public void UpdateMerchant(MerchantModel merchant)
        {
            var filter = Builders<MerchantModel>.Filter.Eq(c => c.Id, merchant.Id);
            _merchantCollection.ReplaceOne(filter, merchant);
        }

        public async Task<MerchantModel> PartiallyUpdate(int id, [FromBody] MerchantPatchRequestModel merchantPatchRequestpatchRequest)
        {
            var filter = Builders<MerchantModel>.Filter.Eq(e => e.Id, id);

            var updateDefinition = Builders<MerchantModel>.Update
                .Set(m => m.FullName, merchantPatchRequestpatchRequest.FullName)
                .Set(m => m.CompanyName, merchantPatchRequestpatchRequest.CompanyName)
                .Set(m => m.TaxNo, merchantPatchRequestpatchRequest.TaxNo)
                .Set(m => m.BankAccountInformation, merchantPatchRequestpatchRequest.BankAccountInformation);

            var options = new FindOneAndUpdateOptions<MerchantModel>
            {
                ReturnDocument = ReturnDocument.After
            };

            return await _merchantCollection.FindOneAndUpdateAsync(filter, updateDefinition, options);
        }






























        public Task<MerchantModel> Update(int id, MerchantModel merchantModel)
        {
            throw new NotImplementedException();
        }

        Task<MerchantModel> IMerchantRepository.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}








       




















     
       