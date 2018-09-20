using EasyManager.Application.Interfaces;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyManager.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class BankAccountController : ApiController<IBankAccountAppService>
    {
        protected BankAccountController(IBankAccountAppService appService, 
                                        INotificationHandler<DomainNotification> notifications, 
                                        IMediatorHandler mediator) : base(appService, notifications, mediator)
        {
        }

        [HttpGet("list")]
        public IActionResult Get()
        {
            return Response(_appService.GetAll());
        }
    }
}