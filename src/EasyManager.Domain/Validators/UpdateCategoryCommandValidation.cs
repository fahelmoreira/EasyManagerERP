using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class UpdateCategoryCommandValidation : CategoryValidation<UpdateCategoryCommand, UpdateUnit>
    {
        public UpdateCategoryCommandValidation()
        {
            ValidateDescription();
            ValidateId();
        }
    }
}