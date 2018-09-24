using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RegisterNewProductCommand : ProductCommand<RegisterUnit>
    {
        public RegisterNewProductCommand(string bundle):base(bundle)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}