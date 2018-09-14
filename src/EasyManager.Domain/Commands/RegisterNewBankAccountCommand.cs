using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RegisterNewBankAccountCommand : BankAccountCommand<RegisterUnit>
    {
        public RegisterNewBankAccountCommand()
        {
            
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewBankAccountCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}