using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyManager.Domain.Core.Events;
using EasyManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyManager.Infra.Data.Repository.EventSourcing
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        private readonly EventStoreSQLContext _context;

        public EventStoreSQLRepository(EventStoreSQLContext context) => _context = context;
        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }
        public IList<StoredEvent> All(Guid aggregateId) => _context.StoredEvent.AsNoTracking().Where(x => x.Id == aggregateId).ToList();

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}