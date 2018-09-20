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
    public class ManufactureController : ApiController<IManufactureAppServices>
    {
        public ManufactureController(IManufactureAppServices appService, 
                                        INotificationHandler<DomainNotification> notifications, 
                                        IMediatorHandler mediator) : base(appService, notifications, mediator)
        {
        }

        [HttpGet("list")]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_appService.GetById(id));
        }
        
        [HttpPost("create")]
        public IActionResult Post([FromBody] ManufactureViewModel manufacture)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(manufacture);
            }

            _appService.Register(manufacture);

            return Response("Manufacture successfully created");
        }

        [HttpPut("update")]
        public IActionResult Put([FromBody] ManufactureViewModel manufacture)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(manufacture);
            }

            _appService.Update(manufacture);

            return Response("Manufacture successfully updated");

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

            return Response("Manufacture successfully removed");
        }
    }
}