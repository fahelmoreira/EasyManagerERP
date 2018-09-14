using System;
using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RemoveDepartamentCommand : DepartamentCommand<RemoveUnit>
    {
        public RemoveDepartamentCommand(Guid id) => Id = AggregateId = id;

        public override bool IsValid()
        {
            ValidationResult = new RemoveDepartamentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}