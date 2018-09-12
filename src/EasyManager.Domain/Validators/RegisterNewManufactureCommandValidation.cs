using EasyManager.Domain.Commands;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewManufactureCommandValidation : ManufactureValidation<RegisterNewManufactureCommand>
    {
        public RegisterNewManufactureCommandValidation()
        {
            ValidateTradeName();
            ValidateTaxpayerId();
            ValidadeAddress();
        }
    }
}