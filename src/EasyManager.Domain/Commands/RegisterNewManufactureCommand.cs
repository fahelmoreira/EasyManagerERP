using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RegisterNewManufactureCommand : ManufactureCommand
    {
        public RegisterNewManufactureCommand()
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewManufactureCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}