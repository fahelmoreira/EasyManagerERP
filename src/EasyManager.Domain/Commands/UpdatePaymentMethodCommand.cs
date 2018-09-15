using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class UpdatePaymentMethodCommand : PaymentMethodCommand<UpdateUnit>
    {
        public override bool IsValid()
        {
            ValidationResult = new UpdatePaymentMethodCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}