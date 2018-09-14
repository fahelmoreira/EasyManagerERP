using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewManufactureCommandValidation : ManufactureValidation<RegisterNewManufactureCommand, RegisterUnit>
    {
        public RegisterNewManufactureCommandValidation()
        {
            ValidateTradeName();
            ValidateTaxpayerId();
            ValidadeAddress();
        }
    }
}