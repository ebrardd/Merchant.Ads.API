using Merchant.Ads.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Merchant.Ads.API.V1.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace Merchant.Ads.API.Services
{
    public interface IService
    {
        public Task<MerchantCreateRequestModel> CreateAsync(MerchantCreateRequestModel merchantCreateRequestModel);
        public Task<MerchantModel> GetByIdAsync(int id);

        public Task<MerchantModel> InsertMerchantAsync(MerchantModel merchantModel);

        public Task<MerchantModel> Update(int id, MerchantModel merchantModel);

        public Task<MerchantModel> DeleteMerchant(int id, MerchantModel merchantModel);

        public Task<MerchantModel> Get(int id, MerchantModel merchantModel);

        public Task<MerchantModel> GetAsync(int id);
        public Task<MerchantModel> UpdateAsync(int id, MerchantModel merchantModel);
        public  Task<MerchantModel> PartiallyUpdate(int id, [FromBody] MerchantPatchRequestModel merchantPatchRequestModel)

    }
    // public Task<MerchantModel> Get(int TaxNo, int Id);
    // public Task<MerchantModel> PartiallyUpdateMerchantForCompany(int TaxNo, int id);




}

