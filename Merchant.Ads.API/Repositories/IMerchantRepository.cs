using Merchant.Ads.API.Models;
using Merchant.Ads.API.Repositories;
using MongoDB.Driver;
using Merchant.Ads.API.Services;
using Merchant.Ads.API.V1.Models.RequestModels;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

namespace Merchant.Ads.API.Repositories
{
    public interface IMerchantRepository
    {
      //  public void Create(MerchantCreateRequestModel merchant);
      //  public MerchantModel GetById(int Id);
        public List<MerchantModel> GetAll();
        public Task<MerchantModel> CreateMerchantAsync(MerchantModel merchantModel);
        public Task<MerchantModel> Update(int id, MerchantModel merchantModel);
        public Task<MerchantModel> DeleteMerchant(int id,MerchantModel merchantModel);
       public  Task<MerchantModel> Get(int id);
      
       public void UpdateMerchant(MerchantModel merchant);
       public Task<MerchantModel> GetByIdAsync(int id);
       public Task<MerchantCreateRequestModel> CreateAsync(MerchantCreateRequestModel merchantCreateRequestModel);
       public Task<MerchantModel> UpdateAsync(int id, MerchantModel merchantModel);
        public Task<MerchantModel> PartiallyUpdate(int id, [FromBody] MerchantPatchRequestModel merchantPatchRequestpatchRequest);
    }
}

