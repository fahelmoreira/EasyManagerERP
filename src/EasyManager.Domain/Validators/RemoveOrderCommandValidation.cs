using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RemoveOrderCommandValidation : OrderValidation<RemoveOrderCommand, RemoveUnit>
    {
        public RemoveOrderCommandValidation()
        {
            ValidateId();
        }
    }
}