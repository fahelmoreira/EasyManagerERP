using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;
using EasyManager.Domain.Validators;
using Newtonsoft.Json;

namespace EasyManager.Domain.Commands
{
    /// <summary>
    /// Command to register new customer
    /// </summary>
    public class RegisterNewCustomerCommand : CustomerCommand<RegisterUnit>
    {
        public RegisterNewCustomerCommand()
        {
            
        }

        public override bool IsValid()
        {
            try
            {
                ValidationResult = new RegisterNewCustomerCommandValidation().Validate(this);
                return ValidationResult.IsValid;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }
    }
}