namespace RGM.BalancedScorecard.Kernel.Domain.Commands
{
    public interface ICommandBus
    {
        void Submit<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
