using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Events;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Events
{
    public class CustomerEvent : Event
    {
        public Guid Id { get; protected set; }
        public string TradeName { get; protected set; }
        public ClientType Type { get; protected set; }
        public string IndividualTaxpayerId { get; protected set; }
        public string CorporateTaxpayerId { get; protected set; }
        public Address Address { get; protected set; }
        public List<Contact> Contacts { get; protected set; }
    }
}