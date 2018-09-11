using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Events;

namespace EasyManager.Infra.Data.Repository.EventSourcing
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        public EventStoreSQLRepository(Parameters)
        {
            
        }
        public void Store(StoredEvent theEvent)
        {
            throw new NotImplementedException();
        }
        public IList<StoredEvent> All(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}