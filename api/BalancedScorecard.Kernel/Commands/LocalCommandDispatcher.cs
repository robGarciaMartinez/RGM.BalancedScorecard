using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Commands
{
    public class LocalCommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandDispatcherDependencyContainer _dependencyContainer;

        public LocalCommandDispatcher(ICommandDispatcherDependencyContainer dependencyContainer)
        {
            _dependencyContainer = dependencyContainer;
        }

        public Task Submit<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = _dependencyContainer.GetCommandHandler<TCommand>();
            return commandHandler.Execute(command);
        }
    }
}
