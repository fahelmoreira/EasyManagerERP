using EasyManager.Domain.Commands;

namespace EasyManager.Domain.Validators
{
    public class RemoveBankAccountCommandValidation: BankAccountValidation<BankAccountCommand>
    {
        public RemoveBankAccountCommandValidation()
        {
            ValidateId();
        }
    }
}