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
    public class DepartamentController : ApiController<IDepartamentAppService>
    {
        public DepartamentController(IDepartamentAppService appService, 
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
        public IActionResult Post([FromBody] DepartamentViewModel departament)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(departament);
            }

            _appService.Register(departament);

            return Response("Departament successfully created");
        }

        [HttpPut]
        public IActionResult Put([FromBody] DepartamentViewModel departament)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(departament);
            }

            _appService.Update(departament);

            return Response("Departament successfully updated");
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Guid id)
        {
            _appService.Remove(id);

            return Response("Departament successfully removed");
        }
    }
}