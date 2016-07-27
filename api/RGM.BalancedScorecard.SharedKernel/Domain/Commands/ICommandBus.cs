namespace RGM.BalancedScorecard.SharedKernel.Domain.Commands
{
    public interface ICommandBus
    {
        CommandResponse Submit<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
