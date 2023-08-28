using System.ComponentModel.DataAnnotations;
using System.Globalization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Merchant.Ads.API.Models
{
    public class MerchantModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
        [Range(0,999)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter a full name")]
        public int TaxNo { get; set; }
        public string CompanyName { get; set; }
        public string BankAccountInformation { get; set; }
    }
    public class BankAccountInformation
    {
        public string IbanNumber { get; set; }
        private int CVC { get; set; }
        public string CartNo { get; set; }
    }
    public class FullName
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}