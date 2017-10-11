using System.Collections.Generic;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Queries
{
    public class LocalQueryDispatcher : IQueryDispatcher
    {
        private readonly IQueryDispatcherDependencyContainer _dependencyContainer;

        public LocalQueryDispatcher(IQueryDispatcherDependencyContainer dependencyContainer)
        {
            _dependencyContainer = dependencyContainer;
        }

        public Task<TViewModel> Get<TViewModel>() where TViewModel : IViewModel
        {
            var query = _dependencyContainer.GetQuery<TViewModel>();
            return query.Execute();
        }

        public Task<TViewModel> Get<TViewModel, TFilter>(TFilter filter)
            where TViewModel : IViewModel
            where TFilter : IFilter
        {
            var query = _dependencyContainer.GetFilteredQuery<TViewModel, TFilter>();
            return query.Execute(filter);
        }

        public Task<List<TViewModel>> GetList<TViewModel>() where TViewModel : IViewModel
        {
            var query = _dependencyContainer.GetCollectionQuery<TViewModel>();
            return query.Execute();
        }
    }
}
