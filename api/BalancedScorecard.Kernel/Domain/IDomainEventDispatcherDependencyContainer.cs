using System;
using System.Collections;

namespace BalancedScorecard.Kernel.Domain
{
    public interface IDomainEventDispatcherDependencyContainer
    {
        IEnumerable GetDomainEventHandlers(Type type);
    }
}
