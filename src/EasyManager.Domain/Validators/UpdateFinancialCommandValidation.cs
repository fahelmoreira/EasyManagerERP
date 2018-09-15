using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class UpdateFinancialCommandValidation : FinancialValidation<UpdateFinancialCommand, UpdateUnit>
    {
        public UpdateFinancialCommandValidation()
        {
            ValidateDescription();
            ValidateId();
            ValidateDueDate();
        }
    }
}