using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class RegisterNewSalesTableItemCommand : SalesTableItemCommand<RegisterUnit>
    {
        public RegisterNewSalesTableItemCommand()
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewSalesTableItemCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}