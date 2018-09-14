using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class UpdateManufactureCommandValidation : ManufactureValidation<UpdateManufactureCommand, UpdateUnit>
    {
        public UpdateManufactureCommandValidation()
        {
            ValidateTradeName();
            ValidateTaxpayerId();
            ValidadeAddress();
            ValidateId();
        }
    }
}