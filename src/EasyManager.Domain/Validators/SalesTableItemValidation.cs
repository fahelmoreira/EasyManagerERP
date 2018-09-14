using System;
using EasyManager.Domain.Commands;
using FluentValidation;

namespace EasyManager.Domain.Validators
{
    public class SalesTableItemValidation<T> : AbstractValidator<T> where T : SalesTableItemCommand
    {
        protected void ValidateName()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Please ensure you have enter the item name");
        }
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}