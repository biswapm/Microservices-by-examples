using System;
using OnlineHotel.Infra.Domain.Core.Events;

namespace OnlineHotel.Infra.Domain.Events
{
    public class CustomerRemovedEvent : Event
    {
        public CustomerRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}