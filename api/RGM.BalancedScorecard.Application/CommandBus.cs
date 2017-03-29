namespace RGM.BalancedScorecard.Domain.Commands
{
    using RGM.BalancedScorecard.Kernel.Domain.Commands;
    using RGM.BalancedScorecard.Kernel.IoC;

    public class CommandBus : ICommandBus
    {
        private readonly IDependencyContainer _dependencyContainer;

        public CommandBus(IDependencyContainer dependencyContainer)
        {
            _dependencyContainer = dependencyContainer;
        }

        public void Submit<TCommand>(TCommand command) where TCommand : ICommand
        {
            _dependencyContainer.GetCommandHandler<TCommand>().Execute(command);
        }
    }
}
