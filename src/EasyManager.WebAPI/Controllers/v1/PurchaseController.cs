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
    /// Controlls the version 1 of the purchase api
    /// </summary>
    [Route("[Controller]")]
    [Version(1)]
    public class PurchaseController : ApiController<IPurchaseAppService>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public PurchaseController(IPurchaseAppService appService, 
                                 INotificationHandler<DomainNotification> notifications, 
                                 IMediatorHandler mediator) : base(appService, notifications, mediator)
        {
        }

        /// <summary>
        /// Retrives all the purchases in a summarized version
        /// </summary>
        /// <response code="200">Customer retrived</response>
        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), 200)]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }

        /// <summary>
        /// Retives detailed information about a specific purchase
        /// </summary>
        /// <param name="id">Id of the purchase</param>
        /// <response code="200">purchase retrived</response>
        /// <response code="404">purchase not found</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Get(Guid id)
        {
            return Response(_appService.GetById(id));
        }
        
        /// <summary>
        /// Creates a new purchase
        /// </summary>
        /// <param name="purchase">Infomation about the purchase</param>
        /// <response code="200">purchase successfully created</response>
        /// <response code="400">Invalid request</response>
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Post([FromBody] PurchaseViewModel purchase)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(purchase);
            }

            _appService.Register(purchase);

            return Response("Purchase successfully created");
        }

        /// <summary>
        /// Updates the purchase information
        /// </summary>
        /// <param name="purchase">Infomation about yhe purchase</param>
        /// <response code="200">purchase successfully updated</response>
        /// <response code="400">Invalid request</response>
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Put([FromBody] PurchaseViewModel purchase)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(purchase);
            }

            _appService.Update(purchase);

            return Response("Purchase successfully updated");

        }

        /// <summary>
        /// Removes the purchase from the data base
        /// </summary>
        /// <param name="id">Id of the purchase to be removed</param>
        /// /// <response code="200">purchase successfully removed</response>
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

            return Response("Purchase successfully removed");
        }
    }
}