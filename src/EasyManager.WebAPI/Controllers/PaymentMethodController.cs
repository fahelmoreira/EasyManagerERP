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
    public class PaymentMethodController : ApiController<IPaymentMethodAppService>
    {
        public PaymentMethodController(IPaymentMethodAppService appService, 
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
        public IActionResult Post([FromBody] PaymentMethodViewModel paymentMethod)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(paymentMethod);
            }

            _appService.Register(paymentMethod);

            return Response("PaymentMethod successfully created");
        }

        [HttpPut]
        public IActionResult Put([FromBody] PaymentMethodViewModel paymentMethod)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(paymentMethod);
            }

            _appService.Update(paymentMethod);

            return Response("PaymentMethod successfully updated");

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

            return Response("PaymentMethod successfully removed");
        }
    }
}