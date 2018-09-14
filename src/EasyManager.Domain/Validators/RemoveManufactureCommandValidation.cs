using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RemoveManufactureCommandValidation : ManufactureValidation<RemoveManufactureCommand, RemoveUnit>
    {
        public RemoveManufactureCommandValidation()
        {
            ValidateId();
        }
    }
}