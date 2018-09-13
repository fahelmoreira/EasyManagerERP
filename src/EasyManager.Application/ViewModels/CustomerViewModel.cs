using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Application.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
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
        [DisplayName("Birthdate")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Gender")]
        public GenderType Gender { get; set; }
        [DisplayName("Profession")]
        public string Profession { get; set; }
        [DisplayName("Pather's name")]
        public string FatherName { get; set; }
        [DisplayName("Mother's name")]
        public string MotherName { get; set; }
        [DisplayName("Matrial status")]
        public MaritalStatus MaritalStatus { get; set; }
        [DisplayName("Receive email")]
        public bool ReceiveEmail { get; set; }
        [DisplayName("Credit Limit")]
        public double CreditLimit { get; set; }
        [DisplayName("Active")]
        public bool Active { get; set; }
    }
}