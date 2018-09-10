using System.Collections.Generic;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;
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
            Address = JsonConvert.SerializeObject(address);
            Contacts = JsonConvert.SerializeObject(contacts);;
        }
        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}