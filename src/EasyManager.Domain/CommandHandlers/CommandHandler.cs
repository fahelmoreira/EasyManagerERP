using System.Threading.Tasks;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Commands;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.Interfaces;
using MediatR;

namespace EasyManager.Domain.CommandHandlers
{
    /// <summary>
    /// Handle all the sistem commands
    /// </summary>
    public class CommandHandler
    {
        #region Private fields
        private readonly IUnitOfWork _uow;
        protected readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
        }

        /// <summary>
        /// Notifies the domain when a error occur asynchronously
        /// </summary>
        /// <param name="message">Command to sent</param>
        /// <returns></returns>
        protected async Task NotifyValidationErrorsAsync(Command message)
        {
            foreach (var erro in message.ValidationResult.Errors)
            {
                await _bus.RaiseEvent(new DomainNotification(message.MessageType, erro.ErrorMessage));
            }
        }

        /// <summary>
        /// Notifies the domain when a error occur
        /// </summary>
        /// <param name="message">Command to sent</param>
        /// <returns></returns>
        protected void NotifyValidationErrors(Command message)
        {
            foreach (var erro in message.ValidationResult.Errors)
            {
                 _bus.RaiseEvent(new DomainNotification(message.MessageType, erro.ErrorMessage));
            }
        }
        
        /// <summary>
        /// Commits all changes asynchronously
        /// </summary>
        public async Task<bool> CommitAsync()
        {
            if(_notifications.HasNotifications())
                return false;
            
            if(await _uow.CommitAsync())
                return true;

            await _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }

        /// <summary>
        /// Commits all changes
        /// </summary>
        public bool Commit()
        {
            if(_notifications.HasNotifications())
                return false;
            
            if(_uow.Commit())
                return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}