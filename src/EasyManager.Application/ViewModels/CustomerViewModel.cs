using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Application.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string TradeName { get; set; }
        public ClientType Type { get; set; }
        public string IndividualTaxpayerId { get; set; }
        public string CorporateTaxpayerId { get; set; }
        public Address Address { get; set; }
        public List<Contact> Contacts { get; set; }

    }
}