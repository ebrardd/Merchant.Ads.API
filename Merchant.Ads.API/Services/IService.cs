using Merchant.Ads.API.Models;


namespace Merchant.Ads.API.Services
{
    public interface IService
    {
        public void Create(MerchantModel merchant);
        public MerchantModel GetById(int Id);

    }
}
