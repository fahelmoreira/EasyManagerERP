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
    public class FinancialController : ApiController<IFinancialAppService>
    {
        public FinancialController(IFinancialAppService appService, 
                                      INotificationHandler<DomainNotification> notifications, 
                                      IMediatorHandler mediator) : base(appService, notifications, mediator)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }
        
        [HttpGet("id:Guid")]
        public IActionResult Get(Guid id)
        {
            return Response(_appService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] FinancialViewModel financial)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(financial);
            }

            _appService.Register(financial);

            return Response("Financial successfully created");
        }

        [HttpPut]
        public IActionResult Put([FromBody] FinancialViewModel financial)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(financial);
            }

            _appService.Update(financial);

            return Response("Financial successfully updated");
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Guid id)
        {
            _appService.Remove(id);

            return Response("Financial successfully removed");
        }
    }
}