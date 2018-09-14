using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class UpdateSalesTableItemCommand : SalesTableItemCommand<UpdateUnit>
    {
        public UpdateSalesTableItemCommand()
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateSalesTableItemCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}