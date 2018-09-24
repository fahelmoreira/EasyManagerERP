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
    /// Controlls the version 1 of the departament api
    /// </summary>
    [Route("[Controller]")]
    [Version(1)]
    public class DepartamentController : ApiController<IDepartamentAppService>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DepartamentController(IDepartamentAppService appService, 
                                        INotificationHandler<DomainNotification> notifications, 
                                        IMediatorHandler mediator) : base(appService, notifications, mediator)
        {
        }

        /// <summary>
        /// Retrives all the departaments in a summarized version
        /// </summary>
        /// <response code="200">Departament retrived</response>
        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), 200)]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }
        

        /// <summary>
        /// Retives detailed information about a specific departament
        /// </summary>
        /// <param name="id">Id of the departament</param>
        /// <response code="200">Departament retrived</response>
        /// <response code="404">Departament not found</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Get(Guid id)
        {
            return Response(_appService.GetById(id));
        }

        /// <summary>
        /// Creates a new departament
        /// </summary>
        /// <param name="departament">Infomation about the departament</param>
        /// <response code="200">Departament successfully created</response>
        /// <response code="400">Invalid request</response>
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Post([FromBody] DepartamentViewModel departament)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(departament);
            }

            _appService.Register(departament);

            return Response("Departament successfully created");
        }

        /// <summary>
        /// Updates the departament information
        /// </summary>
        /// <param name="departament">Infomation about yhe departament</param>
        /// <response code="200">Departament successfully updated</response>
        /// <response code="400">Invalid request</response>
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Put([FromBody] DepartamentViewModel departament)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(departament);
            }

            _appService.Update(departament);

            return Response("Departament successfully updated");
        }

        /// <summary>
        /// Removes the departament from the data base
        /// </summary>
        /// <param name="id">Id of the departament to be removed</param>
        /// /// <response code="200">Departament successfully removed</response>
        /// <response code="400">Invalid request</response>
        [HttpDelete]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Delete([FromBody] Guid id)
        {
            _appService.Remove(id);

            return Response("Departament successfully removed");
        }
    }
}