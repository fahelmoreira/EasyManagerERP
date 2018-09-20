using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EasyManager.Domain.Models;

namespace EasyManager.Application.ViewModels
{
    public class ManufactureViewModel : BaseViewModel
    {
        /// <summary>
        /// Manufacture trade name
        /// </summary>
        [Required(ErrorMessage = "The trade name is required")]
        public string TradeName { get; set; }
        /// <summary>
        /// Corporate taxpayer's number
        /// </summary>
        public string CorporateTaxpayerId { get; set; }
        /// <summary>
        /// Manufacture address
        /// </summary>
        public Address Address { get; set; }
        /// <summary>
        /// Manufacture contacts
        /// </summary>
        public List<Contact> Contacts { get; set; }
        /// <summary>
        /// Manufacture main email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Manufacture main phone number
        /// </summary>
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }

        public string Name { get; protected set; }
        public string CorporateName { get; protected set; }
        public string IndividualTaxpayerId { get; protected set; }
        public string Code { get; protected set; }

    }
}