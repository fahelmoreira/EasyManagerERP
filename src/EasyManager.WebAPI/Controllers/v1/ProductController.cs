using System;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.Models;
using EasyManager.WebAPI.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyManager.WebAPI.Controllers.v1
{
    [Route("[Controller]")]
    [Version(1)]
    public class ProductController : ApiController<IProductAppService>
    {
        public ProductController(IProductAppService appService, 
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
        public IActionResult Post([FromBody] ProductViewModel product)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(product);
            }

            _appService.Register(product);

            return Response("Product successfully created");
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProductViewModel product)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(product);
            }

            _appService.Update(product);

            return Response("Product successfully updated");

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

            return Response("Product successfully removed");
        }
    
    }
}