using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class UpdateBankAccountCommand : BankAccountCommand<UpdateUnit>
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