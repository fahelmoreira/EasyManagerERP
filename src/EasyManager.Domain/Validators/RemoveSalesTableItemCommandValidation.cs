using EasyManager.Domain.Commands;

namespace EasyManager.Domain.Validators
{
    public class RemoveSalesTableItemCommandValidation : SalesTableItemValidation<SalesTableItemCommand>
    {
        public RemoveSalesTableItemCommandValidation()
        {
            ValidateId();
        }
    }
}