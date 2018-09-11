using System;
using System.Collections.Generic;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;
using EasyManager.Domain.Validators;
using Newtonsoft.Json;

namespace EasyManager.Domain.Commands
{
    /// <summary>
    /// Command to register new customer
    /// </summary>
    public class RegisterNewCustomerCommand : CustomerCommand
    {
        public RegisterNewCustomerCommand(
                                          string tradeName, 
                                          ClientType type,
                                          string individualTaxPayer,
                                          string corporateTaxpayerId,
                                          Address address,
                                          List<Contact> contacts)
        {
            Id = new Guid();
            TradeName = tradeName;
            Type = type;
            IndividualTaxpayerId = IndividualTaxpayerId;
            CorporateTaxpayerId = corporateTaxpayerId;
            Address = address;
            Contacts = contacts;
            AggregateId = Id;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}