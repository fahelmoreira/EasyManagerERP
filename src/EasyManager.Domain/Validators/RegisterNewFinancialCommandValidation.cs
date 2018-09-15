using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewFinancialCommandValidation : FinancialValidation<RegisterNewFinancialCommand, RegisterUnit>
    {
        public RegisterNewFinancialCommandValidation()
        {
            ValidateDescription();
            ValidateId();
            ValidateDueDate();
        }
    }
}