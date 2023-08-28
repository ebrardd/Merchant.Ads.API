using Merchant.Ads.API.Models;
using Merchant.Ads.API.Repositories;
using MongoDB.Driver;
using System.Security.Cryptography.X509Certificates;
using Merchant.Ads.API.Services;
using Microsoft.AspNetCore.Mvc;
using Merchant.Ads.API.V1.Models.RequestModels;
using Merchant.Ads.API.V1.Controllers;
using System;

namespace Merchant.Ads.API.Services
{
    public class Service : IService
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly ILogger<MerchantController> _logger; 
        public Service(IMerchantRepository merchantRepository) //_likullanmakicinaldık
        {
            _merchantRepository = merchantRepository; 
        }

        /* public void Create(MerchantCreateRequestModel merchant)
         {

             _merchantRepository.Create(merchant);
         }*/
        public async Task<MerchantCreateRequestModel>CreateAsync(MerchantCreateRequestModel merchantCreateRequestModel)
        {
          return  await _merchantRepository.CreateAsync(merchantCreateRequestModel);
            
        }

        /* public MerchantModel GetById(int Id)
         {
             return _merchantRepository.GetById(Id);
         }*/
        public async Task<MerchantModel> GetByIdAsync(int id)
        {
            return await _merchantRepository.GetByIdAsync(id);
        }
        public  Task<MerchantModel> InsertMerchantAsync(MerchantModel merchantModel)
        {
            return _merchantRepository.CreateMerchantAsync(merchantModel);
        }
        public async Task<MerchantModel> Update(int id, MerchantModel merchantModel)
        {
            var updatedMerchantModel = await _merchantRepository.Update(id, merchantModel);
            return updatedMerchantModel;
        }
        public async Task<MerchantModel> DeleteMerchant(int id,MerchantModel merchantModel)
        {   
            var deletedMerchantModel = await _merchantRepository.DeleteMerchant(id,merchantModel); 
            return deletedMerchantModel;
        }
        public async Task<MerchantModel> Get(int id, MerchantModel merchantModel)
        {
            return merchantModel;
        }
        public async Task<MerchantModel> UpdateAsync(int id, MerchantModel merchantModel)
        {
            return await _merchantRepository.UpdateAsync(id, merchantModel);
        }
        public async Task<MerchantModel> GetAsync(int id)
        {
            return await _merchantRepository.GetByIdAsync(id);
        }
        public async Task<MerchantModel> PartiallyUpdate(int id, [FromBody] MerchantPatchRequestModel merchantPatchRequestModel)
        {
            return await _merchantRepository.PartiallyUpdate(id, merchantPatchRequestModel);
        }



    }
    
}










  
   



        /* public void UpdateMerchant(MerchantModel merchant)
         {
             var filter = Builders<MerchantModel>.Filter.Eq(c => c.Id, merchant.Id);
             _merchantCollection.ReplaceOne(filter, merchant);
         }*/
    
    /* public async Task<> Get(int TaxNo, int Id)
     {

     }
      public async Task<MerchantModel> PartiallyUpdateMerchantForCompany(int TaxNo, int id)
      {
          return;
      }
     */


