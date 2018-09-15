using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RemovePaymentMethodCommandValidation : PaymentMethodValidation<RemovePaymentMethodCommand, RemoveUnit>
    {
        public RemovePaymentMethodCommandValidation()
        {
            ValidateId();
        }
    }
}