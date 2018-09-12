using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyManager.Domain.Core.Model;

namespace EasyManager.Domain.Models
{
    /// <summary>
    /// Model for the address information
    /// </summary>
    public class Address : Entity
    {
        /// <summary>
        /// The address
        /// </summary>
        [Required(ErrorMessage = "The Address is required")]
        public string AddressInfo { get; set; }
        /// <summary>
        /// The number of the address
        /// </summary>
        [Required(ErrorMessage = "The Number is required")]
        public int Number { get; set; }
        /// <summary>
        /// The complement
        /// </summary>
        public string Complement { get; set; }
        /// <summary>
        /// The zip-Code
        /// </summary>
        [Required(ErrorMessage = "The Zip-code is required")]
        public string ZipCode { get; set; }
        /// <summary>
        /// The city
        /// </summary>
        [Required(ErrorMessage = "The City is required")]
        public string City { get; set; }
        /// <summary>
        /// The state
        /// </summary>
        [Required(ErrorMessage = "The State is required")]
        public string State { get; set; }
        /// <summary>
        /// The constry
        /// </summary>
        [Required(ErrorMessage = "The Country is required")]
        public string Country { get; set; }
    }
}