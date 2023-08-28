using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;
using Merchant.Ads.API.Models;
using Microsoft.Net.Http.Headers;
using Merchant.Ads.API.Services;

namespace Merchant.Ads.API.Helpers
{ 
    public  class CsvOutputFormatter:TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        protected override bool CanWriteType(Type? type)
            => typeof(MerchantModel).IsAssignableFrom(type)
                || typeof(IEnumerable<MerchantModel>).IsAssignableFrom(type);
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();
            if (context.Object is IEnumerable<MerchantModel>)
            {
                foreach (var merchantModel in (IEnumerable<MerchantModel>)context.Object)
                {
                    FormatCsv(buffer, merchantModel);
                }
            }
            else
            {
                FormatCsv(buffer, (MerchantModel)context.Object);
            }
            await response.WriteAsync(buffer.ToString(), selectedEncoding);
        }
        private static void FormatCsv(StringBuilder buffer,MerchantModel merchantModel)
        {
           
            {
                buffer.AppendLine($"{merchantModel.FullName},\"{merchantModel.Id},\"{merchantModel.BankAccountInformation},\"{merchantModel.CompanyName},\"{merchantModel.TaxNo}\"");
            }
        }
    }
}

