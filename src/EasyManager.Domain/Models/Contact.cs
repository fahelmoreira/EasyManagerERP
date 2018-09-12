using System;
using System.ComponentModel.DataAnnotations;
using EasyManager.Domain.Core.Model;

namespace EasyManager.Domain.Models
{
    public class Contact : Entity
    {
        /// <summary>
        /// Fistname of the contact
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The FistName is required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string FirstName { get; set; }
        /// <summary>
        /// Lastname of the contact
        /// </summary>
        [Required(ErrorMessage = "The Last is required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string LastName { get; set; }
        /// <summary>
        /// Fullname of the contact
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";
        /// <summary>
        /// The contact phone number
        /// </summary>
        [Required(ErrorMessage = "The Phone number is required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email of the contact
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The Email is required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
    }
}