using System.Collections.Generic;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Commands
{
    public interface ICommandDispatcher
    {
        Task Send(ICommand command);

        Task Send(IEnumerable<ICommand> commands);
    }
}
