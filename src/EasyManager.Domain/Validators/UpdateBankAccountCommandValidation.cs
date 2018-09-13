using EasyManager.Domain.Commands;

namespace EasyManager.Domain.Validators
{
    public class UpdateBankAccountCommandValidation : BankAccountValidation<BankAccountCommand>
    {
        public UpdateBankAccountCommandValidation()
        {
            ValidateName();
        }
        
    }
}