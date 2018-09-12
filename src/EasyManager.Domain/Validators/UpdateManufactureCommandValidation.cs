using EasyManager.Domain.Commands;

namespace EasyManager.Domain.Validators
{
    public class UpdateManufactureCommandValidation : ManufactureValidation<UpdateManufactureCommand>
    {
        public UpdateManufactureCommandValidation()
        {
            ValidateTradeName();
            ValidateTaxpayerId();
            ValidadeAddress();
        }
    }
}