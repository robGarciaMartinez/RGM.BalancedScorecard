using System;
using System.Collections.Generic;

namespace BalancedScorecard.Kernel.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }

        int Version { get; }

        ICollection<IDomainEvent> Events { get; }
    }
}
