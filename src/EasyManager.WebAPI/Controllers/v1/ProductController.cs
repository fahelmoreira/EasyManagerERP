using System;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.Models;
using EasyManager.WebAPI.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyManager.WebAPI.Controllers.V1
{
    /// <summary>
    /// Controlls the version 1 of the product api
    /// </summary>
    [Route("[Controller]")]
    [Version(1)]
    public class ProductController : ApiController<IProductAppService>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductController(IProductAppService appService, 
                                 INotificationHandler<DomainNotification> notifications, 
                                 IMediatorHandler mediator) : base(appService, notifications, mediator)
        {
        }

        /// <summary>
        /// Retrives all the products in a summarized version
        /// </summary>
        /// <response code="200">Customer retrived</response>
        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), 200)]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }

        /// <summary>
        /// Retives detailed information about a specific product
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <response code="200">product retrived</response>
        /// <response code="404">product not found</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Get(Guid id)
        {
            return Response(_appService.GetById(id));
        }
        
        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="product">Infomation about the product</param>
        /// <response code="200">product successfully created</response>
        /// <response code="400">Invalid request</response>
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Post([FromBody] ProductViewModel product)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(product);
            }

            _appService.Register(product);

            return Response("Product successfully created");
        }

        /// <summary>
        /// Updates the product information
        /// </summary>
        /// <param name="product">Infomation about yhe product</param>
        /// <response code="200">product successfully updated</response>
        /// <response code="400">Invalid request</response>
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public IActionResult Put([FromBody] ProductViewModel product)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(product);
            }

            _appService.Update(product);

            return Response("Product successfully updated");

        }

        /// <summary>
        /// Removes the product from the data base
        /// </summary>
        /// <param name="id">Id of the product to be removed</param>
        /// /// <response code="200">product successfully removed</response>
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

            return Response("Product successfully removed");
        }
    
    }
}