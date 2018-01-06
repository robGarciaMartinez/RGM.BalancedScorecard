using System.Collections.Generic;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Queries;
using BalancedScorecard.Kernel.Validation;
using StructureMap;

namespace BalancedScorecard.Api.IoC
{
    public class StructureMapMediator :
        ICommandDispatcherDependencyContainer,
        IQueryDispatcherDependencyContainer,
        IValidationDependencyContainer
    {
        public readonly IContainer _container;

        public StructureMapMediator(IContainer container)
        {
            _container = container;
        }

        public ICollectionQuery<TViewModel> GetCollectionQuery<TViewModel>() where TViewModel : IViewModel
        {
            throw new System.NotImplementedException();
        }

        public ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : ICommand
        {
            return _container.GetInstance<ICommandHandler<TCommand>>();
        }

        public IQuery<TViewModel, TFilter> GetFilteredQuery<TViewModel, TFilter>()
            where TViewModel : IViewModel
            where TFilter : IFilter
        {
            return _container.GetInstance<IQuery<TViewModel, TFilter>>();
        }

        public IQuery<TViewModel> GetQuery<TViewModel>() where TViewModel : IViewModel
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ISpecification<TCommand>> GetSpecifications<TCommand>() where TCommand : ICommand
        {
            return _container.GetAllInstances<ISpecification<TCommand>>();
        }

        public IEnumerable<ISpecification<TAggregateRoot, TCommand>> GetSpecifications<TAggregateRoot, TCommand>()
            where TAggregateRoot : IAggregateRoot
            where TCommand : ICommand
        {
            throw new System.NotImplementedException();
        }
    }
}
