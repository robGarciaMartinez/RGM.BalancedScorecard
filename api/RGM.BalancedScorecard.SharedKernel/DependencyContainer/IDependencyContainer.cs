namespace RGM.BalancedScorecard.SharedKernel.DependencyContainer
{
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public interface IDependencyContainer
    {
        ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : ICommand;
    }
}
