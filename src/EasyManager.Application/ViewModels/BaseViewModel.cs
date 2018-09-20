using System;
using System.ComponentModel.DataAnnotations;

namespace EasyManager.Application.ViewModels
{
    public class BaseViewModel
    {
        public Guid Id { get; set; }
        public BaseViewModel()
        {
            Id = Guid.NewGuid();
        }
    }
}