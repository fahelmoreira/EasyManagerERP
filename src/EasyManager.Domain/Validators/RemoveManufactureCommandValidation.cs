using EasyManager.Domain.Commands;

namespace EasyManager.Domain.Validators
{
    public class RemoveManufactureCommandValidation : ManufactureValidation<RegisterNewManufactureCommand>
    {
        public RemoveManufactureCommandValidation()
        {
            ValidateId();
        }
    }
}