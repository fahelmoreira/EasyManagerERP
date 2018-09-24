using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class UpdateProductCommand : ProductCommand<UpdateUnit>
    {
        public UpdateProductCommand(string bundle):base(bundle)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}