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
        [Required(ErrorMessage = "The Trade Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Trade Name")]
        public string TradeName { get; set; }

        [Required(ErrorMessage = "The Type is Required")]
        [DisplayName("Customer type")]
         public ClientType? Type { get; set; }

        [DisplayName("Individual taxpayer id")]
        public string IndividualTaxpayerId { get; set; }

        [DisplayName("Corporate taxpayer id")]
        public string CorporateTaxpayerId { get; set; }

        [DisplayName("Address")]
        public Address Address { get; set; }

        [DisplayName("Contacts")]
        public List<Contact> Contacts { get; set; }

    }
}