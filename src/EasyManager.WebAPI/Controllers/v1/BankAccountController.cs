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
    public class BankAccountController : ApiController<IBankAccountAppService>
    {
        public BankAccountController(IBankAccountAppService appService, 
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
        public IActionResult Post([FromBody] BankAccountViewModel bankAccount)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(bankAccount);
            }

            _appService.Register(bankAccount);

            return Response("Bank account successfully created");
        }

        [HttpPut]
        public IActionResult Put([FromBody] BankAccountViewModel bankAccount)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(bankAccount);
            }

            _appService.Update(bankAccount);

            return Response("Bank account successfully updated");
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Guid id)
        {
             _appService.Remove(id);
            return Response("Bank account successfully removed");
        }
    }
}