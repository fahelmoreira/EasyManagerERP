using System;
using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RemoveBankAccountCommand : BankAccountCommand<RemoveUnit>
    {
        public RemoveBankAccountCommand(Guid id) => Id = AggregateId = id;

        public override bool IsValid()
        {
            ValidationResult = new RemoveBankAccountCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}