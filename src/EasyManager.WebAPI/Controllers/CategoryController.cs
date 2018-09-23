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

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }
        
        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_appService.GetById(id));
        }
        
        [HttpPost]
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

        [HttpPut]
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

        [HttpDelete]
        public IActionResult Delete([FromBody] Guid id)
        {
            _appService.Remove(id);

            return Response("Customer successfully removed from the database");
        }
    }
}