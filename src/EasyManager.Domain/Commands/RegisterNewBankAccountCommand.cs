using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RegisterNewBankAccountCommand : BankAccountCommand
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