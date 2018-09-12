using EasyManager.Domain.Commands;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
    {
        public RegisterNewCustomerCommandValidation()
        {
            ValidateTradeName();
            //ValidateIndividualTaxPayerId();
            //ValidateCorporateTaxPayerId();
            ValidadeAddress();
        }
    }
}