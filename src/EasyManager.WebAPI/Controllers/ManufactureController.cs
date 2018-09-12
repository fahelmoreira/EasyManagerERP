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
    public class ManufactureController : ApiController
    {
        private readonly IManufactureAppServices _manufacureAppServices;

        public ManufactureController(
            IManufactureAppServices manufacureAppServices,
            INotificationHandler<DomainNotification> notifications, 
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _manufacureAppServices = manufacureAppServices;
        }

        [HttpGet("list")]
        public IActionResult Get()
        {
            return Response(_manufacureAppServices.GetAll());
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_manufacureAppServices.GetById(id));
        }
        
        [HttpPost("create")]
        public IActionResult Post([FromBody] ManufactureViewModel manufacture)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(manufacture);
            }

            _manufacureAppServices.Register(manufacture);

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

            _manufacureAppServices.Update(manufacture);

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

            _manufacureAppServices.Remove(id);

            return Response("Manufacture successfully removed");
        }
    }
}