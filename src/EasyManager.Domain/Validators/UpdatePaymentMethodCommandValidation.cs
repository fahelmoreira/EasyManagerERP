using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class UpdatePaymentMethodCommandValidation : PaymentMethodValidation<UpdatePaymentMethodCommand, UpdateUnit>
    {
        public UpdatePaymentMethodCommandValidation()
        {
            ValidateId();
            ValidateDescription();
        }
    }
}