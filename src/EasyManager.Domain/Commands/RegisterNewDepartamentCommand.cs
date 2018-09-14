using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RegisterNewDepartamentCommand : DepartamentCommand<RegisterUnit>
    {
        public RegisterNewDepartamentCommand()
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewDepartamentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}