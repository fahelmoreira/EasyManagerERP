using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand, UpdateUnit>
    {
        public UpdateCustomerCommandValidation()
        {
            ValidateTradeName();
            ValidateTaxPayerId();
            ValidadeAddress();
            ValidateId();
        }
    }
}