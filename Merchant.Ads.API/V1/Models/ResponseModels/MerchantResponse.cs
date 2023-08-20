namespace Merchant.Ads.API.V1.Models.ResponseModels
{
    public class MerchantResponse
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int TaxNo { get; set; }

        public string CompanyName { get; set; }
        public string BankAccountInformation { get; set; }
    }
}
