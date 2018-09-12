using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyManager.WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ICustomerAppService _customerAppService;

        public ValuesController(
            ICustomerAppService customerAppService,
            INotificationHandler<DomainNotification> notifications, 
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _customerAppService = customerAppService;
        }

        // GET api/values
        [HttpGet("customer/list")]
        public IActionResult Get()
        {
            return Response(_customerAppService.GetAll());
        }

        [HttpPost("customer/create")]
        public IActionResult Post([FromBody] CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _customerAppService.Register(customerViewModel);

            return Response(customerViewModel);
        }
    }
}
