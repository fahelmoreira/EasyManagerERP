using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class UpdatePurchaseCommandValidation : PurchaseValidation<UpdatePurchaseCommand, UpdateUnit>
    {
        public UpdatePurchaseCommandValidation()
        {
            ValidateId();
        }
    }
}