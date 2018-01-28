using BalancedScorecard.Kernel.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BalancedScorecard.Api.Bus
{
    public interface ICommandBus
    {
        Task Send(ICommand command);

        Task Send(IEnumerable<ICommand> commands);
    }
}
