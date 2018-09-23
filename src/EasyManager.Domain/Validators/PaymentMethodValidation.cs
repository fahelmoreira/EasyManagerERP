using System;
using EasyManager.Domain.Commands;
using FluentValidation;

namespace EasyManager.Domain.Validators
{
    public class PaymentMethodValidation<T, R> :  AbstractValidator<T> where T : PaymentMethodCommand<R>
    {
        protected void ValidateDescription()
        {
            RuleFor(b => b.Description)
                .NotEmpty().WithMessage("Please ensure you have entered the payment method description")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateBankAccount()
        {
            RuleFor(c => c.BankAccount)
                .NotEqual(Guid.Empty);
        }
    }
}