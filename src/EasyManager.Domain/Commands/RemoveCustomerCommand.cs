using System;
using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RemoveCustomerCommand : CustomerCommand<RemoveUnit>
    {
        public RemoveCustomerCommand(Guid id) => Id = AggregateId = id;
        public override bool IsValid()
        {
            ValidationResult = new RemoveCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}