namespace EasyManager.Domain.Core.Events
{
    public interface IEventStore
    {
        /// <summary>
        /// Save the event
        /// </summary>
        /// <param name="theEvent">Event to persist</param>
        void Save<T>(T theEvent) where T : Event;
    }
}