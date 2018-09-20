using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Model;

namespace EasyManager.Domain.Models
{
    public class Category : Entity
    {
        public Category()
        {
        }

        public Category(Guid? ParentCategory)
        {
            if(ParentCategory != null)
                this.ParentCategory = new Category{ Id = ParentCategory.Value };
            else
                this.ParentCategory = null;
        }

        public string Description { get; set; }
        public string Location { get; set; }   
        public Category ParentCategory { get; set; }  

    }
}