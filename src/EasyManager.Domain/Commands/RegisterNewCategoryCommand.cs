using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RegisterNewCategoryCommand : CategoryCommand<RegisterUnit>
    {
        public RegisterNewCategoryCommand()
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}