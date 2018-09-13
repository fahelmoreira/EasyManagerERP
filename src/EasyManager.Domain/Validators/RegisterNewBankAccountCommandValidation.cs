using EasyManager.Domain.Commands;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewBankAccountCommandValidation : BankAccountValidation<BankAccountCommand>
    {
        public RegisterNewBankAccountCommandValidation()
        {
            ValidateName();
        }
    }
}