using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Queries;
using StructureMap;

namespace BalancedScorecard.Api.IoC
{
    public class StructureMapMediator :
        ICommandDispatcherDependencyContainer,
        IQueryDispatcherDependencyContainer
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
    }
}
