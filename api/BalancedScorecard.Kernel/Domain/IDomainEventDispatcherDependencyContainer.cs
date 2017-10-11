using System;
using System.Collections;

namespace BalancedScorecard.Kernel.Domain
{
    public interface IDomainEventDispatcherDependencyContainer
    {
        IEnumerable GetTransactionalDomainEventHandlers(Type type);


        IEnumerable GetIntegrationDomainEventHandlers(Type type);
    }
}
