using System.ComponentModel.DataAnnotations;

namespace EasyManager.Application.ViewModels
{
    public class DepartamentViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }
    }
}