using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Commands;
using EasyManager.Domain.Models;

namespace EasyManager.Domain.Commands
{
    public abstract class ManufactureCommand<T>: Command<T>
    {
        public string TradeName { get; protected set; }
        public string CorporateTaxpayerId { get; protected set; }
        public Address Address { get; protected set; }
        public List<Contact> Contacts { get; protected set; }
        public string Email { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public bool Active { get; protected set; }

    }
}