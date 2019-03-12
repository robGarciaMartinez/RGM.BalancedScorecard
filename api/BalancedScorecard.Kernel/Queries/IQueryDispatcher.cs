using System.Collections.Generic;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Queries
{
    public interface IQueryDispatcher
    {
        Task<TViewModel> Get<TViewModel>() where TViewModel : IViewModel;

        Task<TViewModel> Get<TViewModel, TFilter>(TFilter filter) where TViewModel : IViewModel where TFilter : IFilter;

        Task<List<TViewModel>> GetList<TViewModel>() where TViewModel : IViewModel;

        Task<List<TViewModel>> GetList<TViewModel, TFilter>(TFilter filter) where TViewModel : IViewModel where TFilter : IFilter;
    }
}
