using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class UpdatePurchaseCommand : PurchaseCommand<UpdateUnit>
    {
        public override bool IsValid()
        {
            ValidationResult = new UpdatePurchaseCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}