using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RemoveDepartamentCommandValidation : DepartamentValidation<RemoveDepartamentCommand, RemoveUnit>
    {
        public RemoveDepartamentCommandValidation()
        {
            ValidateId();
        }
    }
}