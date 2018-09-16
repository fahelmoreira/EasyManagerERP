using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RemovePurchaseCommandValidation : PurchaseValidation<RemovePurchaseCommand, RemoveUnit>
    {
        public RemovePurchaseCommandValidation()
        {
            ValidateId();
        }
    }
}