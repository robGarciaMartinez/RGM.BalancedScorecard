namespace BalancedScorecard.Kernel.Queries
{
    public interface IQueryDispatcherDependencyContainer
    {
        IQuery<TViewModel> GetQuery<TViewModel>() where TViewModel : IViewModel;

        ICollectionQuery<TViewModel> GetCollectionQuery<TViewModel>() where TViewModel : IViewModel;

        IQuery<TViewModel, TFilter> GetFilteredQuery<TViewModel, TFilter>() where TViewModel : IViewModel where TFilter : IFilter;
    }
}
