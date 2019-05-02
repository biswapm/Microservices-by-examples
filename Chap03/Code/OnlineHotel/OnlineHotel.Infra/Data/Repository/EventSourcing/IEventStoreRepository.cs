using System;
using System.Collections.Generic;
using OnlineHotel.Infra.Domain.Core.Events;

namespace OnlineHotel.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}