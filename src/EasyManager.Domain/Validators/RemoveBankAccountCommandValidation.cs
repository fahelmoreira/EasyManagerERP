using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RemoveBankAccountCommandValidation: BankAccountValidation<RemoveBankAccountCommand , RemoveUnit>
    {
        public RemoveBankAccountCommandValidation()
        {
            ValidateId();
        }
    }
}