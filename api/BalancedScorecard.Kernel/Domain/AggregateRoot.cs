using Newtonsoft.Json;
using System.Collections.Generic;

namespace BalancedScorecard.Kernel.Domain
{
    public abstract class AggregateRoot : BaseEntity, IAggregateRoot
    {
        public AggregateRoot()
        {
            _events = new List<IDomainEvent>();
        }

        [JsonIgnore]
        public int Version { get; protected set; }

        [JsonIgnore]
        public ICollection<IDomainEvent> Events => _events;

        public void SetVersion(int version)
        {
            Version = version;
        }

        protected void AddEvent(IDomainEvent domainEvent)
        {
            if (_events == null)
            {
                _events = new List<IDomainEvent>();
            }

            _events.Add(domainEvent);
        }

        private ICollection<IDomainEvent> _events;
    }
}
