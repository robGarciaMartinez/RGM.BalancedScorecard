using BalancedScorecard.Kernel.Queries;
using StructureMap;

namespace BalancedScorecard.Api.IoC
{
    public class StructureMapMediator : IQueryDispatcherDependencyContainer
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

        public IQuery<TViewModel, TFilter> GetFilteredQuery<TViewModel, TFilter>() where TViewModel : IViewModel where TFilter : IFilter
        {
            return _container.GetInstance<IQuery<TViewModel, TFilter>>();
        }

        public IQuery<TViewModel> GetQuery<TViewModel>() where TViewModel : IViewModel
        {
            throw new System.NotImplementedException();
        }

        public ICollectionQuery<TViewModel, TFilter> GetCollectionFilteredQuery<TViewModel, TFilter>() where TViewModel : IViewModel where TFilter : IFilter
        {
            return _container.GetInstance<ICollectionQuery<TViewModel, TFilter>>();
        }
    }
}
