using System;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyManager.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class CategoryController : ApiController<ICategoryAppService>
    {
        public CategoryController(ICategoryAppService appService, 
                                     INotificationHandler<DomainNotification> notifications, 
                                     IMediatorHandler mediator) : base(appService, notifications, mediator)
        {
        }

        [HttpGet("list")]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }
        
        [HttpPost("create")]
        public IActionResult Post([FromBody] CategoryViewModel category)
        {
             if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(category);
            }

            _appService.Register(category);

            return Response("Category successfully created");
        }

        [HttpPut("update")]
        public IActionResult Put([FromBody] CategoryViewModel category)
        {
             if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(category);
            }

            _appService.Update(category);

            return Response("Category successfully updated");
        }

        [HttpDelete("remove")]
        public IActionResult Delete([FromBody] Guid id)
        {
            _appService.Remove(id);

            return Response("Customer successfully removed from the database");
        }
    }
}