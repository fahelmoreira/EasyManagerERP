using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class UpdateSalesTableItemCommandValidation : SalesTableItemValidation<UpdateSalesTableItemCommand, UpdateUnit>
    {
        public UpdateSalesTableItemCommandValidation()
        {
            ValidateName();
            ValidateId();
        }
    }
}