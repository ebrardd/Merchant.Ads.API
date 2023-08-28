namespace Merchant.Ads.API.V1.Models.RequestModels
{
    public class MerchantPatchRequestModel
    {
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public int TaxNo { get; set; }
        public string BankAccountInformation { get; set; }
    }
}
