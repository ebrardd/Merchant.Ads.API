using Merchant.Ads.API.Models;
using Merchant.Ads.API.Repositories;
using System.Security.Cryptography.X509Certificates;

namespace Merchant.Ads.API.Services
{
    public class Service:IService
    {
        private readonly IMerchantRepository _merchantRepository;
        public Service(IMerchantRepository merchantRepository) //_likullanmakicinaldık
        {
            _merchantRepository = merchantRepository; 
        }
        
        public void Create(MerchantModel merchant)
        {
          
            _merchantRepository.Create(merchant);
        }
        public MerchantModel GetById(int Id)
        {
            return _merchantRepository.GetById(Id);
        }

    }
}
