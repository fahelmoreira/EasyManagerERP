using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RegisterNewOrderCommand : OrderCommand<RegisterUnit>
    {
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}