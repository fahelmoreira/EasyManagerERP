using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RemoveProductCommandValidation : ProductValidation<RemoveProductCommand, RemoveUnit>
    {
        public RemoveProductCommandValidation()
        {
            ValidateId();
        }
    }
}