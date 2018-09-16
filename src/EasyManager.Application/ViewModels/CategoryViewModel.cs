using System;

namespace EasyManager.Application.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public string Description { get; set; }
        public string Location { get; set; }   
        public Guid ParentCategory { get; set; }  
    }
}