namespace BalancedScorecard.Kernel.Commands
{
    public interface ICommandDispatcherDependencyContainer
    {
        ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : ICommand;
    }
}
