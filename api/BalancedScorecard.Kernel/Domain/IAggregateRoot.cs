using System.Collections.Generic;

namespace BalancedScorecard.Kernel.Domain
{
    public interface IAggregateRoot
    {
        ICollection<IDomainEvent> Events { get; }
    }
}
