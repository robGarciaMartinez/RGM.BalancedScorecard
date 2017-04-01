using RGM.BalancedScorecard.Kernel.Domain.Commands;
using RGM.BalancedScorecard.Kernel.Domain.Model;
using RGM.BalancedScorecard.Kernel.Domain.Validation;
using RGM.BalancedScorecard.Kernel.IoC;
using StructureMap;
using System.Collections.Generic;

namespace RGM.BalancedScorecard.MessageProcessor
{
    public sealed class DependencyContainer : IDependencyContainer
    {
        private readonly IContainer _container;

        public DependencyContainer(IContainer container)
        {
            _container = container;
        }

        public IEnumerable<ISpecification<TCommand>> GetSpecifications<TCommand>() where TCommand : ICommand
        {
            return _container.GetAllInstances<ISpecification<TCommand>>();
        }

        public IEnumerable<ISpecification<TAggregateRoot, TCommand>> GetSpecifications<TAggregateRoot, TCommand>()
            where TAggregateRoot : AggregateRoot
            where TCommand : ICommand
        {
            return _container.GetAllInstances<ISpecification<TAggregateRoot, TCommand>>();
        }
    }
}
