using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewCategoryCommandValidation : CategoryValidation<RegisterNewCategoryCommand, RegisterUnit>
    {
        public RegisterNewCategoryCommandValidation()
        {
            ValidateDescription();
        }
    }
}