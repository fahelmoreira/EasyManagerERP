using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class UpdateDepartamentCommand : DepartamentCommand<UpdateUnit>
    {
        public UpdateDepartamentCommand()
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateDepartamentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}