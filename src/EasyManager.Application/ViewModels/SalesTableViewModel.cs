using System.ComponentModel.DataAnnotations;

namespace EasyManager.Application.ViewModels
{
    public class SalesTableViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }
        public double Profit { get; set; }
        public double Price { get; set; }
    }
}