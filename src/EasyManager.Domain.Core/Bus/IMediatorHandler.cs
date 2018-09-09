using System.Threading.Tasks;
using EasyManager.Domain.Core.Commands;
using EasyManager.Domain.Core.Events;

namespace EasyManager.Domain.Core.Bus
{
    /// <summary>
    /// Mediator for the bus handler
    /// </summary>
    public interface IMediatorHandler
    {
        /// <summary>
        /// Sends the command to handler
        /// </summary>
        /// <param name="Commmad">Command to be executed</param>
        Task SendCommand<T>(T Commmad) where T : Command; 

        /// <summary>
        /// Rase an event
        /// </summary>
        /// <param name="@event">Event to be rise</param>
        Task RiseEvent<T>(T @event) where T : Event;
    }
}