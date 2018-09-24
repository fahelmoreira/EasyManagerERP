using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using EasyManager.WebAPI.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyManager.WebAPI.Controllers.V1
{
    /// <summary>
    /// Controlls the version 1 of the customer api
    /// </summary>
    [Route("[Controller]")]
    [Version(1)]
    public class CustomerController : ApiController<ICustomerAppService>
    {
        /// <summary>
        ///  Default constructor
        /// </summary>
        public CustomerController(ICustomerAppService appService,
                                  INotificationHandler<DomainNotification> notifications, 
                                  IMediatorHandler mediator) : base(appService, notifications, mediator)
        {
        }

        /// <summary>
        /// Retrives all the customer registered in a summarized version
        /// </summary>
        /// <response code="200">Customer retrived</response>
        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), 200)]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }

        /// <summary>
        /// Retives detailed information about a specific customer
        /// </summary>
        /// <param name="id">Id of the customer</param>
        /// <response code="200">Customer retrived</response>
        /// <response code="404">Customer not found</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Get(Guid id)
        {
            return Response(_appService.GetById(id));
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="customerViewModel">Infomation about the customer</param>
        /// <response code="200">Customer successfully created</response>
        /// <response code="400">Invalid request</response>
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Post([FromBody] CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _appService.Register(customerViewModel);

            return Response("Customer successfully created");
        }
        
        /// <summary>
        /// Updates the customer information
        /// </summary>
        /// <param name="customerViewModel">Infomation about yhe customer</param>
        /// <response code="200">Customer successfully updated</response>
        /// <response code="400">Invalid request</response>
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Put([FromBody] CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _appService.Update(customerViewModel);

            return Response("Customer successfully updated");
        }

        /// <summary>
        /// Removes the customer from the data base
        /// </summary>
        /// <param name="id">Id of the customer to be removed</param>
        /// /// <response code="200">Customer successfully removed</response>
        /// <response code="400">Invalid request</response>
        [HttpDelete]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Delete([FromBody] Guid id)
        {
            _appService.Remove(id);

            return Response("Customer successfully removed from the database");
        }
    }
}
