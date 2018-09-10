using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Events;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Events
{
    public class CustomerUpdatedEvent : Event
    {
        public Guid Id { get; protected set; }
        public string TradeName { get; protected set; }
        public ClientType Type { get; protected set; }
        public string IndividualTaxpayerId { get; protected set; }
        public string CorporateTaxpayerId { get; protected set; }
        public Address Address { get; protected set; }
        public List<Contact> Contacts { get; protected set; }

        public CustomerUpdatedEvent(Guid id,
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
    }
}