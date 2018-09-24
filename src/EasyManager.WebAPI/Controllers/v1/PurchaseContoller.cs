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
    public class PurchaseContoller : ApiController<IPurchaseAppService>
    {
        public PurchaseContoller(IPurchaseAppService appService, 
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
        public IActionResult Post([FromBody] PurchaseViewModel purchase)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(purchase);
            }

            _appService.Register(purchase);

            return Response("Purchase successfully created");
        }

        [HttpPut]
        public IActionResult Put([FromBody] PurchaseViewModel purchase)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(purchase);
            }

            _appService.Update(purchase);

            return Response("Purchase successfully updated");

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

            return Response("Purchase successfully removed");
        }
    }
}