using System;
using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RemoveOrderCommand : OrderCommand<RemoveUnit>
    {
        public RemoveOrderCommand(Guid id) => Id = AggregateId = id;


        public override bool IsValid()
        {
            ValidationResult = new RemoveOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}