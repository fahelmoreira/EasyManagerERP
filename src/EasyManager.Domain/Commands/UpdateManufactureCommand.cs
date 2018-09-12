using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class UpdateManufactureCommand : ManufactureCommand
    {
        public UpdateManufactureCommand()
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateManufactureCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}