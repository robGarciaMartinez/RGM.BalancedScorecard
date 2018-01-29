using BalancedScorecard.Infrastructure.SqlServerDb.Model;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace BalancedScorecard.Infrastructure.SqlServerDb
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
                }, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() })
            };
        }
    }
}
