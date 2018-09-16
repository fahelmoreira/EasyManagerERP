using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class UpdateOrderCommand : OrderCommand<UpdateUnit>
    {
        public override bool IsValid()
        {
            ValidationResult = new UpdateOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}