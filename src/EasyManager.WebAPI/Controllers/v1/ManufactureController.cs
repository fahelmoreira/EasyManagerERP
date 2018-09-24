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
    /// Controlls the version 1 of the manufacture api
    /// </summary>
    [Route("[Controller]")]
    [Version(1)]
    public class ManufactureController : ApiController<IManufactureAppServices>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ManufactureController(IManufactureAppServices appService, 
                                     INotificationHandler<DomainNotification> notifications, 
                                     IMediatorHandler mediator) : base(appService, notifications, mediator)
        {
        }

        /// <summary>
        /// Retrives all the manufactures in a summarized version
        /// </summary>
        /// <response code="200">Customer retrived</response>
        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), 200)]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }

        /// <summary>
        /// Retives detailed information about a specific manufacture
        /// </summary>
        /// <param name="id">Id of the manufacture</param>
        /// <response code="200">manufacture retrived</response>
        /// <response code="404">manufacture not found</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Get(Guid id)
        {
            return Response(_appService.GetById(id));
        }
        
        /// <summary>
        /// Creates a new manufacture
        /// </summary>
        /// <param name="manufacture">Infomation about the manufacture</param>
        /// <response code="200">manufacture successfully created</response>
        /// <response code="400">Invalid request</response>
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Post([FromBody] ManufactureViewModel manufacture)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(manufacture);
            }

            _appService.Register(manufacture);

            return Response("Manufacture successfully created");
        }

        /// <summary>
        /// Updates the manufacture information
        /// </summary>
        /// <param name="manufacture">Infomation about yhe manufacture</param>
        /// <response code="200">manufacture successfully updated</response>
        /// <response code="400">Invalid request</response>
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Put([FromBody] ManufactureViewModel manufacture)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(manufacture);
            }

            _appService.Update(manufacture);

            return Response("Manufacture successfully updated");

        }

        /// <summary>
        /// Removes the manufacture from the data base
        /// </summary>
        /// <param name="id">Id of the manufacture to be removed</param>
        /// /// <response code="200">manufacture successfully removed</response>
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

            return Response("Manufacture successfully removed");
        }
    }
}