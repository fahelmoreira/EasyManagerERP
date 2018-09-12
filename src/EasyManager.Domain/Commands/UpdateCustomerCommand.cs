using System;
using System.Collections.Generic;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class UpdateCustomerCommand : CustomerCommand
    {
        public UpdateCustomerCommand()
        {

        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}