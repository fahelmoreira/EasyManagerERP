using EasyManager.Domain.Commands;

namespace EasyManager.Domain.Validators
{
    public class RemoveManufactureCommandValidation : ManufactureValidation<RemoveManufactureCommand>
    {
        public RemoveManufactureCommandValidation()
        {
            ValidateId();
        }
    }
}