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
    /// Controlls the version 1 of the category api
    /// </summary>
    [Route("[Controller]")]
    [Version(1)]
    public class CategoryController : ApiController<ICategoryAppService>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CategoryController(ICategoryAppService appService, 
                                  INotificationHandler<DomainNotification> notifications, 
                                  IMediatorHandler mediator) : base(appService, notifications, mediator)
        {
        }

        /// <summary>
        /// Retrivers all categories in a summarized version
        /// </summary>
        /// <response code="200">Category retrived</response>
        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), 200)]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }
        
        /// <summary>
        /// Retives detailed information about a specific category
        /// </summary>
        /// <param name="id">Id of the category</param>
        /// <response code="200">Category retrived</response>
        /// <response code="404">Category not found</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Get(Guid id)
        {
            return Response(_appService.GetById(id));
        }
        
        /// <summary>
        /// Creates a new category
        /// </summary>
        /// <param name="category">Category information</param>
        /// <response code="200">Category successfully created</response>
        /// <response code="400">Invalid request</response>
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Post([FromBody] CategoryViewModel category)
        {
             if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(category);
            }

            _appService.Register(category);

            return Response("Category successfully created");
        }
        
        /// <summary>
        /// Updates a new category
        /// </summary>
        /// <param name="category">Category information</param>
        /// <response code="200">Category successfully updated</response>
        /// <response code="400">Invalid request</response>
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Put([FromBody] CategoryViewModel category)
        {
             if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(category);
            }

            _appService.Update(category);

            return Response("Category successfully updated");
        }

        /// <summary>
        /// Removes category
        /// </summary>
        /// <param name="id">Id of the category to remove</param>
        /// <response code="200">category successfully removed</response>
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