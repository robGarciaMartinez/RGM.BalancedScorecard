namespace RGM.BalancedScorecard.SharedKernel.Domain.Commands
{
    public interface ICommandBus
    {
        void Submit<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
