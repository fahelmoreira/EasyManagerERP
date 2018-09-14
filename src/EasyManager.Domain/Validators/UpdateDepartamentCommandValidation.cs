using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class UpdateDepartamentCommandValidation : DepartamentValidation<UpdateDepartamentCommand, UpdateUnit>
    {
        public UpdateDepartamentCommandValidation()
        {
            ValidateName();
            ValidateId();
        }
    }
}