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
    }
}