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

namespace EasyManager.WebAPI.Controllers.v1
{
    [Route("[Controller]")]
    [Version(1)]
    public class CustomerController : ApiController<ICustomerAppService>
    {
        public CustomerController(ICustomerAppService appService,
                                  INotificationHandler<DomainNotification> notifications, 
                                  IMediatorHandler mediator) : base(appService, notifications, mediator)
        {
        }

        /// <summary>
        /// Gets all the customer registered in a summarized version
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }

        /// <summary>
        /// Gets the detailed customer information
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_appService.GetById(id));
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="customerViewModel">Infomation about yhe customer</param>
        [HttpPost]
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
        [HttpPut]
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
        [HttpDelete]
        public IActionResult Delete([FromBody] Guid id)
        {
            _appService.Remove(id);

            return Response("Customer successfully removed from the database");
        }
    }
}
