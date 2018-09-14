using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class UpdateCategoryCommand : CategoryCommand<UpdateUnit>
    {
        public UpdateCategoryCommand()
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}