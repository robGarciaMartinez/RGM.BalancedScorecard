namespace RGM.BalancedScorecard.Domain.Commands
{
    using RGM.BalancedScorecard.SharedKernel.DependencyContainer;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public class CommandBus : ICommandBus
    {
        private readonly IDependencyContainer dependencyContainer;

        public CommandBus(IDependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        public void Submit<TCommand>(TCommand command) where TCommand : ICommand
        {
            this.dependencyContainer.GetCommandHandler<TCommand>().Execute(command);
        }
    }
}
