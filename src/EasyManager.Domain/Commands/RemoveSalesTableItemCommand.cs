using System;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RemoveSalesTableItemCommand : SalesTableItemCommand
    {
        public RemoveSalesTableItemCommand(Guid id) => Id = AggregateId = id;

        public override bool IsValid()
        {
            ValidationResult = new RemoveSalesTableItemCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}