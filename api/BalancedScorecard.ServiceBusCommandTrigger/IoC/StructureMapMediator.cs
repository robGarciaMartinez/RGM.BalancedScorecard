using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Validation;
using StructureMap;
using System.Collections.Generic;

namespace BalancedScorecard.ServiceBusQueueTrigger.IoC
{
    public class StructureMapMediator :
        IValidationDependencyContainer
    {
        public readonly IContainer _container;

        public StructureMapMediator(IContainer container)
        {
            _container = container;
        }

        public IEnumerable<ISpecification<TCommand>> GetSpecifications<TCommand>() where TCommand : ICommand
        {
            return _container.GetAllInstances<ISpecification<TCommand>>();
        }

        public IEnumerable<ISpecification<TAggregateRoot, TCommand>> GetSpecifications<TAggregateRoot, TCommand>()
            where TAggregateRoot : IAggregateRoot
            where TCommand : ICommand
        {
            return _container.GetAllInstances<ISpecification<TAggregateRoot, TCommand>>();
        }
    }
}
