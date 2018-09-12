using System;
using System.ComponentModel.DataAnnotations;

namespace EasyManager.Application.ViewModels
{
    public class BaseViewModel
    {
        [Key]

        public Guid Id { get; set; }
        public BaseViewModel()
        {
            Id = Guid.NewGuid();
        }

        
    }
}