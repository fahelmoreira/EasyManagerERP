using System.Collections.Generic;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;
using EasyManager.Domain.Validators;
using Newtonsoft.Json;

namespace EasyManager.Domain.Commands
{
    public class RegisterCustomerCommand : CustomerCommand
    {
        public RegisterCustomerCommand(string tradeName, 
                                       ClientType type,
                                       string individualTaxPayer,
                                       string corporateTaxpayerId,
                                       Address address,
                                       List<Contact> contacts)
        {
            TradeName = tradeName;
            Type = type;
            IndividualTaxpayerId = IndividualTaxpayerId;
            CorporateTaxpayerId = corporateTaxpayerId;
            Address = address;
            Contacts = contacts;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}