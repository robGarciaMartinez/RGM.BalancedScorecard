namespace RGM.BalancedScorecard.Domain.Dependencies
{
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public interface IDomainDependencyService
    {
        ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : ICommand;
    }
}
