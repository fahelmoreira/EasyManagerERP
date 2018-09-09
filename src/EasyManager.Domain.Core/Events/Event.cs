using MediatR;

namespace EasyManager.Domain.Core.Events
{
    public abstract class Event : Message, INotification
    {
        
    }
}