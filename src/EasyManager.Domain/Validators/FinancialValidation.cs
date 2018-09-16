using System;
using EasyManager.Domain.Commands;
using FluentValidation;

namespace EasyManager.Domain.Validators
{
    public abstract class FinancialValidation <T, R> : AbstractValidator<T> where T : FinancialCommand<R>
    {
        protected void ValidateDescription()
        {
             RuleFor(b => b.description)
                .NotEmpty().WithMessage("Please ensure you have entered the description")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

         protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateDueDate()
        {
            RuleFor(c => c.DueDate)
            .NotNull().WithMessage("Please ensure you have entered the due date");
        }
    }
}