using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RegisterNewFinancialCommand : FinancialCommand<RegisterUnit>
    {
        public RegisterNewFinancialCommand()
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewFinancialCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}