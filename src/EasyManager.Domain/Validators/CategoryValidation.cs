using System;
using EasyManager.Domain.Commands;
using FluentValidation;

namespace EasyManager.Domain.Validators
{
    public abstract class CategoryValidation<T, R> : AbstractValidator<T> where T : CategoryCommand<R>
    {
        protected void ValidateDescription()
        {
            RuleFor(b => b.Description)
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