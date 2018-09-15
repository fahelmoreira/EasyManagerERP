using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class UpdateFinancialCommand : FinancialCommand<UpdateUnit>
    {
        public UpdateFinancialCommand()
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateFinancialCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}