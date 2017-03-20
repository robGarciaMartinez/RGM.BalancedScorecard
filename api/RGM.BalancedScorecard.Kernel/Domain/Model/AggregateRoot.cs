using RGM.BalancedScorecard.Kernel.Domain.Events;
using System.Collections.Generic;

namespace RGM.BalancedScorecard.Kernel.Domain.Model
{
    public abstract class AggregateRoot : DomainEntity
    {
        public List<IDomainEvent> Events { get; protected set; }
        
        protected void AddEvent(IDomainEvent domainEvent)
        {
            if (Events == null)
            {
                Events = new List<IDomainEvent>();
            }

            Events.Add(domainEvent);
        } 
    }
}
