using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Events;

namespace EasyManager.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}