using BalancedScorecard.Infrastructure.Persistence.Model;
using BalancedScorecard.Kernel.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BalancedScorecard.Infrastructure.Persistence
{
    public static class Extensions
    {
        public static EventData ToEventData(this IDomainEvent @event, IAggregateRoot aggregate, int version)
        {
            return new EventData
            {
                Id = Guid.NewGuid(),
                AggregateId = aggregate.Id,
                AggregateType = aggregate.GetType().Name,
                Created = DateTime.Now,
                Event = JsonConvert.SerializeObject(@event),
                Version = version,
                Metadata = JsonConvert.SerializeObject(new Dictionary<string, object>
                {
                    { "EventClrType", @event.GetType().Name }
                })
            };
        }
    }
}
