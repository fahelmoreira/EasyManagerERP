using EasyManager.Domain.Commands;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
    {
        public RegisterNewCustomerCommandValidation()
        {
            ValidateTradeName();
            ValidateTaxPayerId();
            ValidadeAddress();
        }
    }
}