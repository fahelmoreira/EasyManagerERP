using System;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using EasyManager.WebAPI.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyManager.WebAPI.Controllers.v1
{
    [Route("[Controller]")]
    [Version(1)]
    public class OrderController : ApiController<IOrderAppService>
    {
        public OrderController(IOrderAppService appService, 
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
        public IActionResult Post([FromBody] OrderViewModel order)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(order);
            }

            _appService.Register(order);

            return Response("Order successfully created");
        }

        [HttpPut]
        public IActionResult Put([FromBody] OrderViewModel order)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(order);
            }

            _appService.Update(order);

            return Response("Order successfully updated");

        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Guid id)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(id);
            }

            _appService.Remove(id);

            return Response("Order successfully removed");
        }
    }
}