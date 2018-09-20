using EasyManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyManager.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class CategoryController
    {
        public CategoryController(ICategoryAppService category)
        {
        }
    }
}