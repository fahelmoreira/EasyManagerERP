using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewDepartamentCommandValidation : DepartamentValidation<RegisterNewDepartamentCommand, RegisterUnit>
    {
        public RegisterNewDepartamentCommandValidation()
        {
            ValidateName();
            ValidateId();
        }
    }
}