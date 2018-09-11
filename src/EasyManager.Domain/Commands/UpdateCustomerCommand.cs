using System;
using System.Collections.Generic;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;
using EasyManager.Domain.Validators;

namespace EasyManager.Domain.Commands
{
    public class UpdateCustomerCommand : CustomerCommand
    {
        public UpdateCustomerCommand(Guid id,
                                     string tradeName, 
                                     ClientType type,
                                     string individualTaxPayer,
                                     string corporateTaxpayerId,
                                     Address address,
                                     List<Contact> contacts)
        {
            Id = id;
            TradeName = tradeName;
            Type = type;
            IndividualTaxpayerId = IndividualTaxpayerId;
            CorporateTaxpayerId = corporateTaxpayerId;
            Address = address;
            Contacts = contacts;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}