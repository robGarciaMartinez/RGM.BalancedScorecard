namespace RGM.BalancedScorecard.SharedKernel.Domain.Commands
{
    public interface ICommandBus
    {
        CommandHandlerResponse Submit<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
