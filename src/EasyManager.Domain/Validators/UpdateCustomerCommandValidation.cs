using EasyManager.Domain.Commands;

namespace EasyManager.Domain.Validators
{
    public class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidation()
        {
            ValidateTradeName();
            ValidateIndividualTaxPayerId();
            ValidateCorporateTaxPayerId();
            ValidadeAddress();
        }
    }
}