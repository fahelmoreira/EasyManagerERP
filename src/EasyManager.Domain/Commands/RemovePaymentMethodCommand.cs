using System;
using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RemovePaymentMethodCommand : PaymentMethodCommand<RemoveUnit>
    {
        public RemovePaymentMethodCommand(Guid id) => Id = AggregateId = id;

        public override bool IsValid()
        {
            ValidationResult = new RemovePaymentMethodCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}