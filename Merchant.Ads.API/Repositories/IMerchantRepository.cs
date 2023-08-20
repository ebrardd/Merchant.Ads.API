using Merchant.Ads.API.Models;
using Merchant.Ads.API.Repositories;
using MongoDB.Driver;
using Merchant.Ads.API.Services;


namespace Merchant.Ads.API.Repositories
{
    public interface IMerchantRepository
    {
        public void Create(MerchantModel merchant);
        public MerchantModel GetById(int Id);
        public List<MerchantModel> GetAll();




    }
}
