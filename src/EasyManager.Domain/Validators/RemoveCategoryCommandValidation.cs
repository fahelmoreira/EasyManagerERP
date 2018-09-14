using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RemoveCategoryCommandValidation : CategoryValidation<RemoveCategoryCommand, RemoveUnit>
    {
        public RemoveCategoryCommandValidation()
        {
            ValidateId();
        }
    }
}