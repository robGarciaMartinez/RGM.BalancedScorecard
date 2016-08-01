namespace RGM.BalancedScorecard.SharedKernel.Domain.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        CommandHandlerResponse Execute(TCommand command);
    }
}
