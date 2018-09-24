using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class UpdateProductCommandValidation : ProductValidation<UpdateProductCommand, UpdateUnit>
    {
        public UpdateProductCommandValidation()
        {
            ValidateDescription();
            ValidateId();
            ValidateType();
        }
    }
}