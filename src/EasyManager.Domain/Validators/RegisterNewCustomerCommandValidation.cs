using EasyManager.Domain.Commands;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterCustomerCommand>
    {
        public RegisterNewCustomerCommandValidation()
        {
            ValidateTradeName();
            ValidateIndividualTaxPayerId();
            ValidateCorporateTaxPayerId();
            ValidadeAddress();
        }
    }
}