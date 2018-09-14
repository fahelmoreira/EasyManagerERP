using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class UpdateBankAccountCommandValidation : BankAccountValidation<UpdateBankAccountCommand, UpdateUnit>
    {
        public UpdateBankAccountCommandValidation()
        {
            ValidateName();
        }
        
    }
}