using System;
using EasyManager.Domain.Commands;
using FluentValidation;

namespace EasyManager.Domain.Validators
{
    public class BankAccountValidation<T> : AbstractValidator<T> where T : BankAccountCommand
    {
        protected void ValidateName()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the bank name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}