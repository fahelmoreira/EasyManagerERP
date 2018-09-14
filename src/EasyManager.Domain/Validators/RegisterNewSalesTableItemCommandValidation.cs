using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewSalesTableItemCommandValidation : SalesTableItemValidation<RegisterNewSalesTableItemCommand, RegisterUnit>
    {
        public RegisterNewSalesTableItemCommandValidation()
        {
            ValidateName();
        }
    }
}