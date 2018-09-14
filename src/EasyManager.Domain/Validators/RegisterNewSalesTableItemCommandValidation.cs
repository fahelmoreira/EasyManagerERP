using EasyManager.Domain.Commands;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewSalesTableItemCommandValidation : SalesTableItemValidation<SalesTableItemCommand>
    {
        public RegisterNewSalesTableItemCommandValidation()
        {
            ValidateName();
        }
    }
}