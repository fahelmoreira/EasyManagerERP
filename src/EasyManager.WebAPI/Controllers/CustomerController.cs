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
    [Route("[Controller]")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(
            ICustomerAppService customerAppService,
            INotificationHandler<DomainNotification> notifications, 
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _customerAppService = customerAppService;
        }

        /// <summary>
        /// Gets all the customer registered in a summarized version
        /// </summary>
        [HttpGet("list")]
        public IActionResult Get()
        {
            return Response(_customerAppService.GetAll());
        }

        /// <summary>
        /// Gets the detailed customer information
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_customerAppService.GetById(id));
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="customerViewModel">Infomation about yhe customer</param>
        [HttpPost("create")]
        public IActionResult Post([FromBody] CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _customerAppService.Register(customerViewModel);

            return Response("Customer successfully created");
        }
        
        /// <summary>
        /// Updates the customer information
        /// </summary>
        /// <param name="customerViewModel">Infomation about yhe customer</param>
        [HttpPut("update")]
        public IActionResult Put([FromBody] CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _customerAppService.Update(customerViewModel);

            return Response("Customer successfully updated");
        }

        /// <summary>
        /// Removes the customer from the data base
        /// </summary>
        /// <param name="id">Id of the customer to be removed</param>
        [HttpDelete]
        public IActionResult Delete([FromBody] Guid id)
        {
            _customerAppService.Remove(id);

            return Response("Customer successfully removed from the database");
        }
    }
}
