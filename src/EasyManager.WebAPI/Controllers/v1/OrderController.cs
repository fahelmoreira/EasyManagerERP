using System;
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
    /// Controlls the version 1 of the order api
    /// </summary>
    [Route("[Controller]")]
    [Version(1)]
    public class OrderController : ApiController<IOrderAppService>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public OrderController(IOrderAppService appService, 
                                  INotificationHandler<DomainNotification> notifications, 
                                  IMediatorHandler mediator) : base(appService, notifications, mediator)
        {
        }

        /// <summary>
        /// Retrives all the orders in a summarized version
        /// </summary>
        /// <response code="200">Customer retrived</response>
        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), 200)]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }

        /// <summary>
        /// Retives detailed information about a specific order
        /// </summary>
        /// <param name="id">Id of the order</param>
        /// <response code="200">order retrived</response>
        /// <response code="404">order not found</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Get(Guid id)
        {
            return Response(_appService.GetById(id));
        }
        
        /// <summary>
        /// Creates a new order
        /// </summary>
        /// <param name="order">Infomation about the order</param>
        /// <response code="200">order successfully created</response>
        /// <response code="400">Invalid request</response>
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Post([FromBody] OrderViewModel order)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(order);
            }

            _appService.Register(order);

            return Response("Order successfully created");
        }

        /// <summary>
        /// Updates the order information
        /// </summary>
        /// <param name="order">Infomation about yhe order</param>
        /// <response code="200">order successfully updated</response>
        /// <response code="400">Invalid request</response>
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Put([FromBody] OrderViewModel order)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(order);
            }

            _appService.Update(order);

            return Response("Order successfully updated");

        }

        /// <summary>
        /// Removes the order from the data base
        /// </summary>
        /// <param name="id">Id of the order to be removed</param>
        /// /// <response code="200">order successfully removed</response>
        /// <response code="400">Invalid request</response>
        [HttpDelete]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Delete([FromBody] Guid id)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(id);
            }

            _appService.Remove(id);

            return Response("Order successfully removed");
        }
    }
}