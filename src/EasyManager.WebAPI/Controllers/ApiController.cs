using System.Collections.Generic;
using System.Linq;
using EasyManager.Application.Interfaces;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyManager.WebAPI.Controllers
{
    /// <summary>
    /// Main api controller
    /// </summary>
    public class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="mediator"></param>
        protected ApiController(INotificationHandler<DomainNotification> notifications, 
                                IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        /// <summary>
        /// Notifications
        /// </summary>
        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        /// <summary>
        /// Validates the operation
        /// </summary>
        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        /// <summary>
        /// Set the response
        /// </summary>
        /// <param name="result"></param>
        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        /// <summary>
        /// Notifies model state erros
        /// </summary>
        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        /// <summary>
        /// Notifies errors
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        protected void NotifyError(string code, string message)
        {
            _mediator.RaiseEvent(new DomainNotification(code, message));
        }

        /// <summary>
        /// Add aidentity errors
        /// </summary>
        /// <param name="result"></param>
        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                NotifyError(result.ToString(), error.Description);
            }
        }
    }

    /// <summary>
    /// Main api controller
    /// </summary>
    public class ApiController<T> : ApiController
    {
        /// <summary>
        /// application service
        /// </summary>
        protected internal readonly T _appService;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="appService"></param>
        /// <param name="notifications"></param>
        /// <param name="mediator"></param>
        protected ApiController(T appService,
                                INotificationHandler<DomainNotification> notifications, 
                                IMediatorHandler mediator) : base(notifications, mediator)
        {
            _appService = appService;
        }
    }
}