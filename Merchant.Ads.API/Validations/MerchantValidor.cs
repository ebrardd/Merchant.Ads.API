using FluentValidation;
using Merchant.Ads.API.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace Merchant.Ads.API.Validations
{
    public class MerchantValidator : AbstractValidator<MerchantModel>
        {
            public MerchantValidator()
            {

               RuleFor(merchantModel => merchantModel.Name).NotEmpty().NotEmpty();
                RuleFor(merchantModel => merchantModel.Surname).NotNull().NotEmpty();

                /*Validate Phone with a custom error message
                RuleFor(merchantModel => merchantModel..NotEmpty().WithMessage("Please add a phone number");

                // Validate Age for submitted customer has to be between 21 and 100 years old
                RuleFor(merchantModel => merchantModel.Age).InclusiveBetween(21, 100);

                // Validate the address (its a complex property)
                RuleFor(merchantModel => merchantModel).InjectValidator();*/
            }
        }
    }

