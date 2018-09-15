using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewPaymentMethodCommandValidation : PaymentMethodValidation<RegisterNewPaymentMethodCommand, RegisterUnit>
    {
        public RegisterNewPaymentMethodCommandValidation()
        {
            ValidateId();
            ValidateDescription();
        }
    }
}