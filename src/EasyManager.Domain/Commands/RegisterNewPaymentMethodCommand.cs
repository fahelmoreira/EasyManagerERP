using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RegisterNewPaymentMethodCommand : PaymentMethodCommand<RegisterUnit>
    {
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewPaymentMethodCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}