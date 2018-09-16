using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewOrderCommandValidation : OrderValidation<RegisterNewOrderCommand, RegisterUnit>
    {
        public RegisterNewOrderCommandValidation()
        {
            ValidateId();
        }
    }
}