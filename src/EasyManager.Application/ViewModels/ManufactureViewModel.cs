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
        [Required(ErrorMessage = "The corporate taxpayer id is required")]
        public string CorporateTaxpayerId { get; set; }
        /// <summary>
        /// Manufacture address
        /// </summary>
        public Address Address { get; set; }
        /// <summary>
        /// Manufacture contacts
        /// </summary>
        public List<Contact> Contacts { get; set; }
    }
}