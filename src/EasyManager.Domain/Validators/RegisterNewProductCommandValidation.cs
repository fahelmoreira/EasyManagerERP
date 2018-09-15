using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;

namespace EasyManager.Domain.Validators
{
    public class RegisterNewProductCommandValidation : ProductValidation<RegisterNewProductCommand, RegisterUnit>
    {
        public RegisterNewProductCommandValidation()
        {
            ValidateDescription();
            ValidateId();
        }
    }
}