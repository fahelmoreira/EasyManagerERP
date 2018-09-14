using System;
using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RemoveCategoryCommand : CategoryCommand<RemoveUnit>
    {
        public RemoveCategoryCommand(Guid id) => Id = AggregateId = id;

        public override bool IsValid()
        {
            ValidationResult = new RemoveCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}