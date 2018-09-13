using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class UpdateBankAccountCommand : BankAccountCommand
    {
        public UpdateBankAccountCommand()
        {
            
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateBankAccountCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}