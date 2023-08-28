using System.Text.Json;
using System.Runtime.InteropServices.JavaScript;
using Merchant.Ads.API.Models;
using Merchant.Ads.API.Extensions;


namespace Merchant.Ads.API.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}