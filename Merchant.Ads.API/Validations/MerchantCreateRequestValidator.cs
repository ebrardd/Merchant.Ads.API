using FluentValidation;
using Merchant.Ads.API.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace Merchant.Ads.API.Validations
{
    public class MerchantCreateRequestValidator : AbstractValidator<MerchantModel>
        {
            public MerchantCreateRequestValidator()
            {

                RuleFor(merchantModel => merchantModel.FullName).NotEmpty().NotEmpty();
                RuleFor(merchantModel => merchantModel.CompanyName).NotNull().NotEmpty();
                RuleFor(merchantModel => merchantModel.TaxNo).Equal(10);
                RuleFor(merchantModel => merchantModel.Id).InclusiveBetween(0, 1);
               
            }
        }
    }

