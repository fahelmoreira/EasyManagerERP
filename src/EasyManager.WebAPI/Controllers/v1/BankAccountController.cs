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
    /// Controlls the version 1 of the bank api
    /// </summary>
    [Route("[Controller]")]
    [Version(1)]
    public class BankAccountController : ApiController<IBankAccountAppService>
    {
        /// <summary>
        /// Default Controller
        /// </summary>
        public BankAccountController(IBankAccountAppService appService, 
                                     INotificationHandler<DomainNotification> notifications, 
                                     IMediatorHandler mediator) : base(appService, notifications, mediator)
        {
        }

        /// <summary>
        /// Retrivers all bank accounts in a summarized version
        /// </summary>
        /// <response code="200">Bank retrived</response>
        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), 200)]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }
        
        /// <summary>
        /// Retives detailed information about a specific bank account
        /// </summary>
        /// <param name="id">Id of the bank account</param>
        /// <response code="200">Bank retrived</response>
        /// <response code="404">Bank not found</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Get(Guid id)
        {
            return Response(_appService.GetById(id));
        }

        /// <summary>
        /// Creates a new bank account
        /// </summary>
        /// <param name="bankAccount">Bank account information</param>
        /// <response code="200">Bank account successfully created</response>
        /// <response code="400">Invalid request</response>
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Post([FromBody] BankAccountViewModel bankAccount)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(bankAccount);
            }

            _appService.Register(bankAccount);

            return Response("Bank account successfully created");
        }

        /// <summary>
        /// Updates bank account
        /// </summary>
        /// <param name="bankAccount">Bank account information</param>
        /// <response code="200">Bank account successfully updated</response>
        /// <response code="400">Invalid request</response>
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Put([FromBody] BankAccountViewModel bankAccount)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(bankAccount);
            }

            _appService.Update(bankAccount);

            return Response("Bank account successfully updated");
        }

        /// <summary>
        /// Removes bank account
        /// </summary>
        /// <param name="id">Id of the bank account to remove</param>
        /// <response code="200">Bank account successfully removed</response>
        /// <response code="400">Invalid request</response>
        [HttpDelete]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Delete([FromBody] Guid id)
        {
             _appService.Remove(id);
            return Response("Bank account successfully removed");
        }
    }
}