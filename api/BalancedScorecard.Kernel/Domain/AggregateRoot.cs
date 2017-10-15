using Newtonsoft.Json;
using System.Collections.Generic;

namespace BalancedScorecard.Kernel.Domain
{
    public abstract class AggregateRoot : BaseEntity, IAggregateRoot
    {
        private ICollection<IDomainEvent> _events;

        public AggregateRoot()
        {
            _events = new List<IDomainEvent>();
        }

        [JsonIgnore]
        public int Version { get; protected set; }

        [JsonIgnore]
        public ICollection<IDomainEvent> Events => _events;
        
        public void AddEvent(IDomainEvent domainEvent)
        {
            if (_events == null)
            {
                _events = new List<IDomainEvent>();
            }

            _events.Add(domainEvent);
        }
    }
}
