using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyManager.Application.Interfaces;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyManager.WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ICustomerAppService _customerAppService;

        protected ValuesController(
            ICustomerAppService customerAppService,
            INotificationHandler<DomainNotification> notifications, 
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _customerAppService = customerAppService;
        }

        // GET api/values
        [HttpGet, Route("customer/list")]
        public IActionResult Get()
        {
            return Response(_customerAppService.GetAll());
        }
    }
}
