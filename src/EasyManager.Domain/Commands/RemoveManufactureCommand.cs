using System;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RemoveManufactureCommand : ManufactureCommand
    {
        public RemoveManufactureCommand(Guid id) => Id = AggregateId = id;

        public override bool IsValid()
        {
            ValidationResult = new RemoveManufactureCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}