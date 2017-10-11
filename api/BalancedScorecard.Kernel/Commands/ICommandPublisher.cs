using System.Collections.Generic;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Commands
{
    public interface ICommandPublisher
    {
        Task Publish<TCommand>(TCommand command) where TCommand : ICommand;

        Task PublishBatch<TCommand>(ICollection<TCommand> commandCollection) where TCommand : ICommand;
    }
}
