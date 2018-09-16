using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class UpdateOrderCommandValidation : OrderValidation<UpdateOrderCommand, UpdateUnit>
    {
        public UpdateOrderCommandValidation()
        {
            ValidateId();
        }
    }
}