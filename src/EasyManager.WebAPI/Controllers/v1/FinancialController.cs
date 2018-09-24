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
    /// Controlls the version 1 of the financia api
    /// </summary>
    [Route("[Controller]")]
    [Version(1)]
    public class FinancialController : ApiController<IFinancialAppService>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public FinancialController(IFinancialAppService appService, 
                                      INotificationHandler<DomainNotification> notifications, 
                                      IMediatorHandler mediator) : base(appService, notifications, mediator)
        {
        }

        /// <summary>
        /// Retrives all the financiais in a summarized version
        /// </summary>
        /// <response code="200">Customer retrived</response>
        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), 200)]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }
        
        /// <summary>
        /// Retives detailed information about a specific financia
        /// </summary>
        /// <param name="id">Id of the financia</param>
        /// <response code="200">financia retrived</response>
        /// <response code="404">financia not found</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Get(Guid id)
        {
            return Response(_appService.GetById(id));
        }

        /// <summary>
        /// Creates a new financia
        /// </summary>
        /// <param name="financial">Infomation about the financia</param>
        /// <response code="200">financia successfully created</response>
        /// <response code="400">Invalid request</response>
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Post([FromBody] FinancialViewModel financial)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(financial);
            }

            _appService.Register(financial);

            return Response("Financial successfully created");
        }

        /// <summary>
        /// Updates the financia information
        /// </summary>
        /// <param name="financial">Infomation about yhe financia</param>
        /// <response code="200">financia successfully updated</response>
        /// <response code="400">Invalid request</response>
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Put([FromBody] FinancialViewModel financial)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(financial);
            }

            _appService.Update(financial);

            return Response("Financial successfully updated");
        }

        /// <summary>
        /// Removes the financia from the data base
        /// </summary>
        /// <param name="id">Id of the financia to be removed</param>
        /// /// <response code="200">financia successfully removed</response>
        /// <response code="400">Invalid request</response>
        [HttpDelete]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Delete([FromBody] Guid id)
        {
            _appService.Remove(id);

            return Response("Financial successfully removed");
        }
    }
}