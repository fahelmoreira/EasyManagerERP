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
    /// Controlls the version 1 of the payment method api
    /// </summary>
    [Route("[Controller]")]
    [Version(1)]
    public class PaymentMethodController : ApiController<IPaymentMethodAppService>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public PaymentMethodController(IPaymentMethodAppService appService, 
                                          INotificationHandler<DomainNotification> notifications, 
                                          IMediatorHandler mediator) : base(appService, notifications, mediator)
        {
        }

        /// <summary>
        /// Retrives all the payment methods in a summarized version
        /// </summary>
        /// <response code="200">Customer retrived</response>
        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), 200)]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }

        /// <summary>
        /// Retives detailed information about a specific payment method
        /// </summary>
        /// <param name="id">Id of the payment method</param>
        /// <response code="200">payment method retrived</response>
        /// <response code="404">payment method not found</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Get(Guid id)
        {
            return Response(_appService.GetById(id));
        }
        
        /// <summary>
        /// Creates a new payment method
        /// </summary>
        /// <param name="paymentMethod">Infomation about the payment method</param>
        /// <response code="200">payment method successfully created</response>
        /// <response code="400">Invalid request</response>
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Post([FromBody] PaymentMethodViewModel paymentMethod)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(paymentMethod);
            }

            _appService.Register(paymentMethod);

            return Response("PaymentMethod successfully created");
        }

        /// <summary>
        /// Updates the payment method information
        /// </summary>
        /// <param name="paymentMethod">Infomation about yhe payment method</param>
        /// <response code="200">payment method successfully updated</response>
        /// <response code="400">Invalid request</response>
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Put([FromBody] PaymentMethodViewModel paymentMethod)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(paymentMethod);
            }

            _appService.Update(paymentMethod);

            return Response("PaymentMethod successfully updated");

        }

        /// <summary>
        /// Removes the payment method from the data base
        /// </summary>
        /// <param name="id">Id of the payment method to be removed</param>
        /// /// <response code="200">payment method successfully removed</response>
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

            return Response("PaymentMethod successfully removed");
        }
    }
}