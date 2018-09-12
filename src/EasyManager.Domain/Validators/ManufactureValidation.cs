using System;
using EasyManager.Domain.Commands;
using FluentValidation;

namespace EasyManager.Domain.Validators
{
    public abstract class ManufactureValidation<T> : AbstractValidator<T> where T : ManufactureCommand
    {
        protected void ValidateTradeName()
        {
            RuleFor(m => m.TradeName)
                .NotEmpty().WithMessage("Please ensure you have entered the Trade name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }
        
        /// <summary>
        /// Validates the manufacture taxpayer information
        /// </summary>
        protected void ValidateTaxpayerId()
        {
            RuleFor(m => m.CorporateTaxpayerId)
            .NotEmpty().WithMessage("Please ensure you have entered the the taxpayer id");
        }

        /// <summary>
        /// Validates the manufacture address informations
        /// </summary>
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
        
        /// <summary>
        /// Validates the manufacture id
        /// </summary>
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}