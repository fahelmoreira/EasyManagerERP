using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Events;
using EasyManager.Domain.Models;

namespace EasyManager.Domain.Events
{
    public abstract class ManufactureEvent : Event
    {
        public Guid Id { get; protected set; }
        public string TradeName { get; protected set; }
        public string CorporateTaxpayerId { get; protected set; }
        public Address Address { get; protected set; }
        public List<Contact> Contacts { get; protected set; }
        public string Email { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public bool Active { get; protected set; }
    }
}