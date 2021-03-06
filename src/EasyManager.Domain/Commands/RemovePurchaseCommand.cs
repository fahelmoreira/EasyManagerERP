using System;
using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RemovePurchaseCommand : PurchaseCommand<RemoveUnit>
    {
        public RemovePurchaseCommand(Guid id) => Id = AggregateId = id;

        public override bool IsValid()
        {
            ValidationResult = new RemovePurchaseCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}