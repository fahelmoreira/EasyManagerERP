using System;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RemoveBankAccountCommand : BankAccountCommand
    {
        public RemoveBankAccountCommand(Guid id)
        {
            Id = id;
            AggregateId = id;   
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveBankAccountCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}