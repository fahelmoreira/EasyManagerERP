using EasyManager.Domain.Commands;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;
using FluentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EasyManager.Domain.Validators
{
    public abstract class CustomerValidation<T> : AbstractValidator<T> where T : CustomerCommand
    {
        protected void ValidateTradeName()
        {
            RuleFor(c => c.TradeName)
                .NotEmpty().WithMessage("Please ensure you have entered the Trade name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateIndividualTaxPayerId()
        {
            RuleFor(c => c.Type)
                .Custom( (c, r) => {
                    if (c != ClientType.Individual)
                        return;
                    
                    RuleFor(z => z.IndividualTaxpayerId)
                    .NotEmpty().WithMessage("Please ensure you have entered the Taxpayer ID");
                });
        }

        protected void ValidateCorporateTaxPayerId()
        {
            RuleFor(c => c.Type)
                .Custom( (type, r) => {
                    if (type != ClientType.Corporation)
                        return;
                    
                    RuleFor(c => c.CorporateTaxpayerId)
                    .NotEmpty().WithMessage("Please ensure you have entered the Taxpayer ID");
                });
        }

        protected void ValidadeAddress()
        {
            RuleFor(c => c.Address.AddressInfo)
                .NotEmpty().WithMessage("Please ensure you have address information");
            RuleFor(c => c.Address.Number)
                .NotEmpty().WithMessage("Please ensure you have address number");
            RuleFor(c => c.Address.City)
                .NotEmpty().WithMessage("Please ensure you have address city");
            RuleFor(c => c.Address.State)
                .NotEmpty().WithMessage("Please ensure you have address state");
            RuleFor(c => c.Address.Country)
                .NotEmpty().WithMessage("Please ensure you have address country");
        }
    }
}