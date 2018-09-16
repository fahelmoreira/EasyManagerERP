using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewPurchaseCommandValidation : PurchaseValidation<RegisterNewPurchaseCommand, RegisterUnit>
    {
        public RegisterNewPurchaseCommandValidation()
        {
            ValidateId();
        }
    }
}