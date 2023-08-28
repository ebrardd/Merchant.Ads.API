using Merchant.Ads.API.Models;

namespace Merchant.Ads.API.V1.Models.RequestModels
{
    public class MerchantCreateRequestModel:MerchantModel
    {
        public int TaxNo { get; set; }
        public int Id { get; set; }
    }
    public MerchantModel ToModel()
}
