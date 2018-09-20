using System;
using System.ComponentModel.DataAnnotations;

namespace EasyManager.Application.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "The category description is required")]
        public string Description { get; set; }
        public string Location { get; set; }   
        public Guid? ParentCategory { get; set; }  
    }
}