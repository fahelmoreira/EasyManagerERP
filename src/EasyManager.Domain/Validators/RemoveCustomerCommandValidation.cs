using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RemoveCustomerCommandValidation : CustomerValidation<RemoveCustomerCommand, RemoveUnit>
    {
        public RemoveCustomerCommandValidation()
        {
            ValidateId();
        }
    }
}