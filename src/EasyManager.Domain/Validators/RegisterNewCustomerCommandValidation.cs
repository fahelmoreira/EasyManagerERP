using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand, RegisterUnit>
    {
        public RegisterNewCustomerCommandValidation()
        {
            ValidateTradeName();
            ValidateTaxPayerId();
            ValidadeAddress();
        }
    }
}