using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RegisterNewPurchaseCommand : PurchaseCommand<RegisterUnit>
    {
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewPurchaseCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}