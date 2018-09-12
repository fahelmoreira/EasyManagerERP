using EasyManager.Domain.Core.Model;

namespace EasyManager.Domain.Models
{
    public class Category : Entity
    {
        public string Description { get; set; }
        public string Location { get; set; }   
        public Category ParentCategory { get; set; }  
        public Category ChildCategory { get; set; }  
    }
}