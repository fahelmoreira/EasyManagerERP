using EasyManager.Domain.Commands;

namespace EasyManager.Domain.Validators
{
    public class UpdateSalesTableItemCommandValidation : SalesTableItemValidation<SalesTableItemCommand>
    {
        public UpdateSalesTableItemCommandValidation()
        {
            ValidateName();
        }
    }
}