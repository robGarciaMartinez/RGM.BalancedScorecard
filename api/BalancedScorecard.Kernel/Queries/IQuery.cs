using System.Collections.Generic;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Queries
{
    public interface IQuery<TViewModel> where TViewModel : IViewModel
    {
        Task<TViewModel> Execute();
    }

    public interface ICollectionQuery<TViewModel> where TViewModel : IViewModel
    {
        Task<List<TViewModel>> Execute();
    }

    public interface IQuery<TViewModel, TFilter>
        where TViewModel : IViewModel
        where TFilter : IFilter
    {
        Task<TViewModel> Execute(TFilter filter);
    }
}
