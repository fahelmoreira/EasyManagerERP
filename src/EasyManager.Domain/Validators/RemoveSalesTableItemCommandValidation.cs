using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RemoveSalesTableItemCommandValidation : SalesTableItemValidation<RemoveSalesTableItemCommand, RemoveUnit>
    {
        public RemoveSalesTableItemCommandValidation()
        {
            ValidateId();
        }
    }
}