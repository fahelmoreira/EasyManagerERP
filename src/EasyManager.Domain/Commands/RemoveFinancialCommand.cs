using System;
using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RemoveFinancialCommand : FinancialCommand<RemoveUnit>
    {
        public RemoveFinancialCommand(Guid id) => Id = AggregateId = id;

        public override bool IsValid()
        {
            ValidationResult = new RemoveFinancialCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}