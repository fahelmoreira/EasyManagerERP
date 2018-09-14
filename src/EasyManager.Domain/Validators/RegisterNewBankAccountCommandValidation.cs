using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewBankAccountCommandValidation : BankAccountValidation<RegisterNewBankAccountCommand, RegisterUnit>
    {
        public RegisterNewBankAccountCommandValidation()
        {
            ValidateName();
        }
    }
}